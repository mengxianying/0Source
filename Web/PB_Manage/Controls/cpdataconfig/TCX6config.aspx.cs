using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;
using System.IO;
using System.Net;

namespace Pbzx.Web.PB_Manage.Controls.cpdataconfig
{
    public partial class TCX6config : AdminBasic
    {
        int otherIssue = 7;//期号长度
        int intCode = 5;//号码长度
        protected string FormarSXtCode(object objTCode)
        {
            string result = "";

            if (ViewState["tableName"].ToString() == "FCP61Data_HD6S")
            {
                string sx = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
                result = "(" + sx.Substring(int.Parse(objTCode.ToString()) - 1, 1) + ")";               
            }
            return result;
        }
        #region
        // bool IsLianXu = true;
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                if (Request["city"] != null)
                {
                    if (ViewState["tableName"] == null)
                    {
                        ViewState["tableName"] = Input.FilterAll(Request["city"]);
                    }

                    BindData();
                }
                else
                {
                    JS.Alert("参数传递错误！");
                    return;
                }

            }
            SetLinkAdd();
        }
        private void SetYZValue(string min,string max)
        {
            this.rvd1.MinimumValue = min;
            this.rvd1.MaximumValue = max;
            this.txtTcode.MaxLength = max.Length;
            this.rvd1.ErrorMessage = "特别号码有误，范围（"+min+" - "+max+"）";
        }
        private void SetLinkAdd()
        {
            string linkAdd = "";
            linkAdd = GetInfo(ViewState["tableName"].ToString());
            this.lblLinkAdd.Text = linkAdd;
        }

        //得到开奖网址，每天开奖时间起始+期数+间隔
        private string GetInfo(string type)
        {
            string[] result = new string[] { "", "" };
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + type + "' ");
            string linkAdd = "";
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                this.txtIssue.MaxLength = Convert.ToInt32(row["IssueLen"]);
                otherIssue = Convert.ToInt32(row["IssueLen"]);

                string[] lotTypeSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] kjHaoSZ = lotTypeSZ[0].Split(new char[] { ',' });
                if (kjHaoSZ[5] == "数字型")
                {
                    intCode = Convert.ToInt32(kjHaoSZ[1]);                    
                }
                else
                {
                    intCode = Convert.ToInt32(kjHaoSZ[1]) * 2;
                }                
                txtCode.MaxLength = intCode;
                lblCodeFW.Text = "范围：（" + kjHaoSZ[2] + " - " + kjHaoSZ[3]+"）";

                this.Title = row["NvarName"] + "开奖信息管理";
                linkAdd += "<font color=333333><b>" + row["NvarName"] + "开奖信息管理</b></font>&nbsp;&nbsp;&nbsp;"; 
                string[] kjInfo = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string codes = kjInfo[0];
                string tcodes = null;

                ////号码验证
                //string[] codeArray = codes.Split(new char[] { ',' });
                //if (codeArray.Length > 4)
                //{
                //    if (codeArray[2] == "1")
                //    {
                //        codeArray[2] = "01";
                //    }
                //    SetYZValue(codeArray[2], codeArray[3]);
                //}
                //特别号码验证
                if (kjInfo.Length > 1 && !string.IsNullOrEmpty(kjInfo[1]))
                {
                    tcodes = kjInfo[1];
                    string[] tcodeArray = tcodes.Split(new char[] { ',' });
                    if (tcodeArray.Length > 4)
                    {
                        if (tcodeArray[5] != "数字型")
                        {
                            if (type == "TC7XCData_New")
                            {
                                tcodeArray[2] = "00";
                            }
                            else
                            {
                                tcodeArray[2] = "01";
                            }
                            txtTcode.MaxLength = 2;
                        }
                        else
                        {
                            txtTcode.MaxLength = 1;
                        }
                        this.lblTcodeFW.Text = "格式：" + tcodeArray[2] + "&nbsp;范围：" + tcodeArray[2] + " - " + tcodeArray[3];
                        SetYZValue(tcodeArray[2], tcodeArray[3]);
                    }
                }

                string[] wzSZ = row["LottWebsites"].ToString().Split(new char[] { '|' });
                //网址
                foreach (string str in wzSZ)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] wzName = str.Split(new char[] { ',' });
                        if (!string.IsNullOrEmpty(wzName[0]) && !string.IsNullOrEmpty(wzName[1]))
                        {
                            result[0] += "<a href='" + wzName[1] + "' target='_blank'>" + wzName[0] + "</a>&nbsp;&nbsp;&nbsp;";
                        }
                    }
                }
                //时间
                object objTime = row["TimeList"];
                if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
                {
                    string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                    result[1] += tmSZ[0] + " — " + tmSZ[tmSZ.Length - 1] + "&nbsp;&nbsp;每天" + row["DayLottCount"] + "期&nbsp;";

                    TimeSpan tsStart = new TimeSpan();
                    TimeSpan tsEnd = new TimeSpan();
                    if (!TimeSpan.TryParse(tmSZ[0], out tsStart) || !TimeSpan.TryParse(tmSZ[1], out tsEnd))
                    {
                        Response.Write("<script>alert('时间序列有误!')</script>");
                    }
                    else
                    {
                        int jg = 0;
                        tsEnd.Subtract(tsStart);
                        while (tsStart < tsEnd)
                        {
                            tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                            jg++;
                        }
                        result[1] += jg.ToString() + "分钟一期";
                    }
                }
                else
                {
                    object objDate = row["NvarLott_date"];
                    result[1] = Method.GetLottDate(objDate.ToString());
                }


                if (row["Mark"] != null && !string.IsNullOrEmpty(row["Mark"].ToString()))
                {
                    result[1] += "&nbsp;" + row["Mark"].ToString();
                }
            }
            return linkAdd + result[0] + result[1];
        }

        protected void BindData()
        {
            string sql = "select top 15 * from " + ViewState["tableName"] + " order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            this.MyGridView.DataSource = dt;
            this.MyGridView.DataBind();
            ViewState["hide"] = "0";
        }
        //#region
        protected void BindDivAdd()
        {
            if (ViewState["hide"].ToString() == "0")
            {
                FC7LC_add_code_main(false, "", "");
                this.txtIssue.Enabled = true;
                this.txtDate.Enabled = true;
                this.btnSave.Text = "添加";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from " + ViewState["tableName"] + " where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"].ToString(), row["issue"].ToString());
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "修改";
            }
        }

        protected void FC7LC_add_code_main(object bModify, string sdate, string sissue)
        {
            string code="", s_number = "",tCode="";
           

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sissue = dt.Rows[0]["issue"].ToString();
                sdate = dt.Rows[0]["date"].ToString();
                int intTemp = int.Parse(sissue.ToString()) + 1;
                sissue = intTemp.ToString();

                lblFW.Text = "格式：" + dt.Rows[0]["code"].ToString();

                if (Request["lottDate"] == "0" || Request["lottDate"] == "")
                {
                    sdate = DateTime.Parse(sdate).AddDays(1).ToShortDateString();
                    //判断是否在休市时间之内start(孟2010-02-23)
                    if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                    {
                        if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                        {
                            sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString();//下一期开始时间 
                        }
                    }
                    //判断是否在休市时间之内end(孟2010-02-23)
                }
                else if (Request["lottDate"].Length > 1)
                {
                    int intWeek = (((int)DateTime.Parse(sdate).DayOfWeek) + 1);
                    s_number = Request["lottDate"].IndexOf("" + intWeek.ToString() + "").ToString();
                    if (int.Parse(s_number) == Request["lottDate"].Length - 1)
                    {
                        sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(0, 1))) + 7 - int.Parse(Request["lottDate"].Substring(Request["lottDate"].Length - 1, 1))).ToShortDateString();
                    }
                    else
                    {
                        sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(int.Parse(s_number) + 1, 1))) - int.Parse(Request["lottDate"].Substring(int.Parse(s_number), 1))).ToShortDateString();
                    }


                    //判断是否在休市时间之内start(孟2010-02-23)
                    bool isInXS = false;
                    if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                    {
                        if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                        {
                            sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).ToShortDateString();//下一期开始时间 
                            isInXS = true;
                        }
                    }
                    if (isInXS)
                    {
                        string[] checkResult = WebFunc.GetYearEndDate(Convert.ToDateTime(sdate), Request["lottDate"]);
                        if (checkResult[0] == "true")
                        {
                            int intWeek1 = (((int)DateTime.Parse(sdate).DayOfWeek) + 1);
                            s_number = Request["lottDate"].IndexOf("" + intWeek1.ToString() + "").ToString();
                            if (int.Parse(s_number) == Request["lottDate"].Length - 1)
                            {
                                sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(0, 1))) + 7 - int.Parse(Request["lottDate"].Substring(Request["lottDate"].Length - 1, 1))).ToShortDateString();
                            }
                            else
                            {
                                sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(int.Parse(s_number) + 1, 1))) - int.Parse(Request["lottDate"].Substring(int.Parse(s_number), 1))).ToShortDateString();
                            }
                        }
                        else
                        {
                            sdate = checkResult[1];
                        }
                    }
                    //判断是否在休市时间之内end(孟2010-02-23)

                }

                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    Response.Write("<script>alert('最新数据已经录入，请到下期开奖日再来录入新的数据！');history.go(-1);</script>");
                    Response.End();
                    //btnClear_Click(new object(), new EventArgs());
                    return;
                }
                if (DateTime.Parse(sdate).Year.ToString() != sissue.Substring(0, 4))
                {
                    sissue = DateTime.Now.Year.ToString() + "001";
                }    
                ViewState["hide"] = "0";
                this.btnSave.Text = "添加";
            }
            else
            {
                string sql = "select * from " + ViewState["tableName"] + " where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"].ToString();
                sissue = dt.Rows[0]["issue"].ToString();
                code = dt.Rows[0]["code"].ToString();
                tCode = dt.Rows[0]["tcode"].ToString();
                ViewState["hide"] = sissue;
                this.btnSave.Text = "修改";

                lblFW.Text = "格式：" + code;

            }
            this.txtDate.Text = sdate.ToString();
            this.txtIssue.Text = sissue.ToString();
            this.txtCode.Text = code;
            this.txtTcode.Text = tCode;

            //期号
            this.lblIssue.Text = "格式：" + sissue;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string strErrMsg = "";
            if (this.txtIssue.Text.Length != otherIssue)
            {
                strErrMsg += "期号错误：位数不符.\\r\\n";
            }
            if (txtTcode.Text.Length < this.txtTcode.MaxLength)
            {
                txtTcode.Text = "0" + txtTcode.Text;
            }
            if (txtTcode.Text.Length != this.txtTcode.MaxLength)
            {
                strErrMsg += "特别号码输入错误：位数不符.\\r\\n";
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "开奖日期格式不正确.\\r\\n";
            }

            if (Request["city"] == "江苏P51")
            {
                if (this.txtCode.Text.Length != 5)
                {
                    strErrMsg += "奖号输入不正确，请输入五位数字.\\r\\n";
                }
            }
            else
            {
                if (this.txtCode.Text.Length != intCode)
                {
                    strErrMsg += "奖号：位数不符.\\r\\n";
                }               
            }
            string resultCode = "";
            //if (this.txtTcode.MaxLength == 2)
            //{
            //    if (int.Parse(this.txtTcode.Text) > 12 || int.Parse(this.txtTcode.Text) < 1 || this.txtTcode.Text.Length < 2)
            //    {
            //        strErrMsg += "特别号码输入错误，请输入（01-12）之间的整数.\\r\\n";
            //    }
            //    resultCode = this.txtTcode.Text;
            //}
            //else
            //{
            //    if (int.Parse(this.txtTcode.Text) > 9 || int.Parse(this.txtTcode.Text) < 0 || this.txtTcode.Text.Length !=1)
            //    {
            //        strErrMsg += "特别号码输入错误，请输入（0-9）之间的整数.\\r\\n";
            //    }
            //    resultCode = int.Parse(this.txtTcode.Text).ToString();
            //}
            resultCode = this.txtTcode.Text;

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            if (ViewState["hide"].ToString() == "0")
            {
                if (dt.Rows[0]["issue"].ToString() == this.txtIssue.Text)
                {
                    strErrMsg += "该开奖日期的开奖信息已经存在.\\r\\n";
                }
                if (strErrMsg != "")
                {
                    strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                    return;
                }
                if (basicDAL.ExecuteSql(" insert into " + ViewState["tableName"] + "(issue,[date],Code,tcode,LastModifytime,OpIp,OpName) values('" + this.txtIssue.Text + "','" + this.txtDate.Text + "','" + this.txtCode.Text + "','" + resultCode + "','" + DateTime.Now + "','" + Request.UserHostAddress + "','"+WebFunc.GetCurrentAdmin()+"')") > 0)
                {
                    ViewState["hide"] = "0";
                    btnList_Click(new object(), new EventArgs());
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("添加失败!"));
                    return;
                }
                if (ViewState["tableName"].ToString() == "TC7XCData_New")
                {
                    Application["TC7XCData_New"] = "false";
                    if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                    {
                        WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TC7XCData_New");
                    }
                }
            }
            else
            {
                if (basicDAL.ExecuteSql("update " + ViewState["tableName"] + " set issue='" + this.txtIssue.Text + "',[date]='" + this.txtDate.Text + "',Code='" + this.txtCode.Text + "',tcode='"+resultCode+"',LastModifytime='" + DateTime.Now + "',OpIp='" + Request.UserHostAddress + "',OpName='"+WebFunc.GetCurrentAdmin()+"' where issue='" + ViewState["hide"] + "' ") > 0)
                {
                    ViewState["hide"] = "0";
                    btnList_Click(new object(), new EventArgs());
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("更新失败!"));
                    return;
                }
                if (ViewState["tableName"].ToString() == "TC7XCData_New")
                {
                    Application["TC7XCData_New"] = "false";
                    if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                    {
                        WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TC7XCData_New");
                    }
                }
                //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
            }
        }

        protected void FC7LC_del_code()
        {
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string sql = "";
            //判断是否搜索的数据
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("没有可删除的开奖信息!"));
                return;
            }
            if (basicDAL.ExecuteSql("delete " + ViewState["tableName"] + "  where issue='" + row["issue"] + "'") > 0)
            {
                btnList_Click(new object(), new EventArgs());
            }
            ViewState["hide"] = "0";
            if (ViewState["tableName"].ToString() == "TC7XCData_New")
            {
                Application["TC7XCData_New"] = "false";
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TC7XCData_New");
                }
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string strIssue = e.CommandArgument.ToString();
            this.hfNewsID.Value = strIssue;
            ViewState["hide"] = strIssue;
            btnDivAdd_Click(new object(), new EventArgs());
        }
        //#endregion
        //格式化IP地址
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }
        //#region
        //让列表显示
        protected void btnList_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
            txt_Condition.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();
        }

        //让添加显示
        protected void btnDivAdd_Click(object sender, EventArgs e)
        {
            BindDivAdd();
            this.divList.Visible = false;
            this.divAdd.Visible = true;
            //this.divBatchAdd.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
        }





        #endregion


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                ////判断长度
                //string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                //}
                sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "%" + "'" + " order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                this.MyGridView.DataSource = dt;
                this.MyGridView.DataBind();
                ViewState["hide"] = "0";
            }
        }
    }
}
