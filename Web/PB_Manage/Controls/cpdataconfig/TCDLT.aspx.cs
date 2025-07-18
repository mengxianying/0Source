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
    public partial class TCDLT : AdminBasic
    {
        int otherIssue = 7;
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                BindData();
            }
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='TCDLTData' ");
            txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            otherIssue = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            this.lblLinkAdd.Text = WebFunc.GetInfo("TCDLTData");
        }
        protected void BindData()
        {
            string sql = "select top 15 * from TCDLTData order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            this.MyGridView.DataSource = dt;
            this.MyGridView.DataBind();
            ViewState["hide"] = "0";
        }

        protected void BindDivAdd()
        {
            if (ViewState["hide"].ToString() == "0")
            {
                FC7LC_add_code_main(false, "", "");
                this.txtIssue.Enabled = true;
                this.txtDate.Enabled = true;
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from TCDLTData where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string code1, code2, code3, code4, code5, bcode1, bcode2;
            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from TCDLTData order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();
                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToShortDateString();
                //体彩大乐透开奖为：每周一、周三、周六
                switch (((int)DateTime.Parse(sdate.ToString()).DayOfWeek) + 1)
                {
                    //星期一开奖
                    case 2:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期一
                        break;
                    //星期三
                    case 4:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//下个星期三
                        break;
                    //星期六
                    case 6:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//下个星期六
                        break;
                    //星期一开奖
                    case 7:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期一
                        break;
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
                    string[] checkResult = WebFunc.GetYearEndDate(Convert.ToDateTime(sdate), "246");
                    if (checkResult[0] == "true")
                    {
                        //体彩大乐透开奖为：每周一、周三、周六
                        switch (((int)DateTime.Parse(sdate.ToString()).DayOfWeek) + 1)
                        {
                            //星期一开奖
                            case 2:
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期一
                                break;
                            //星期三
                            case 4:
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//下个星期三
                                break;
                            //星期六
                            case 6:
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//下个星期六
                                break;
                        }
                    }
                    else
                    {
                        sdate = checkResult[1];
                    }
                }
                //判断是否在休市时间之内end(孟2010-02-23)



                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    Response.Write("<script>alert('最新数据已经录入，请到下期开奖日再来录入新的数据！');history.go(-1);</script>");
                    Response.End();
                    //btnClear_Click(new object(), new EventArgs());
                    return;
                }
                //跨年处理 
                if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }
                code1 = "";
                code2 = "";
                code3 = "";
                code4 = "";
                code5 = "";
                bcode1 = "";
                bcode2 = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "添加";
            }
            else
            {
                string code, bcode;
                string sql = "select * from TCDLTData where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"];
                sissue = dt.Rows[0]["issue"];
                code = dt.Rows[0]["code"].ToString();
                bcode = dt.Rows[0]["code2"].ToString();
                code1 = code.Substring(0, 2);
                code2 = code.Substring(2, 2);
                code3 = code.Substring(4, 2);
                code4 = code.Substring(6, 2);
                code5 = code.Substring(8, 2);
                bcode1 = bcode.Substring(0, 2);
                bcode2 = bcode.Substring(2, 2);


                ViewState["hide"] = sissue;
                this.btnSave.Text = "修改";
            }
            this.txtIssue.Text = sissue.ToString();
            this.txtCode1.Text = code1;
            this.txtCode2.Text = code2;
            this.txtCode3.Text = code3;
            this.txtCode4.Text = code4;
            this.txtCode5.Text = code5;
            this.txtCode6.Text = bcode1;
            this.txtCode7.Text = bcode2;

            //期号
            this.lblIssue.Text = "格式：" + sissue;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.TCDLTData FC7LCBLL = new Pbzx.BLL.TCDLTData();
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string strErrMsg = "";
            if (this.txtCode1.Text.Length != 2 || this.txtCode2.Text.Length != 2 || this.txtCode3.Text.Length != 2 || this.txtCode4.Text.Length != 2 || this.txtCode5.Text.Length != 2)
            {
                strErrMsg += "红球号码输入不完整，请按照右边格式输入\\r\\n";
            }
            if (this.txtCode6.Text.Length != 2 || this.txtCode7.Text.Length != 2)
            {
                strErrMsg += "蓝球号码输入不完整，请按照右边格式输入\\r\\n";
            }



            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "开奖日期格式不正确.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }


            string code = this.txtCode1.Text + this.txtCode2.Text + this.txtCode3.Text + this.txtCode4.Text + this.txtCode5.Text;
            string bcode = this.txtCode6.Text + this.txtCode7.Text;
            string isCF = Method.showCheckStr(Method.FormartCode(code, ""), 35);
            string bisCF = Method.showCheckStr(Method.FormartCode(bcode, ""), 12);
            if (isCF.Length > 0)
            {
                strErrMsg += "红球号码-" + isCF + ".\\r\\n";
            }
            if (bisCF.Length > 0)
            {
                strErrMsg += "蓝球号码-" + bisCF + ".\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.TCDLTData FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCModel = new Pbzx.Model.TCDLTData();
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(ViewState["hide"].ToString());
                }
                FC7LCModel.code = Method.OrderCode(Method.FormartCode(code, ""), "");
                FC7LCModel.code2 = Method.OrderCode(Method.FormartCode(bcode, ""), "");
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.issue = this.txtIssue.Text;
                FC7LCModel.LastModifytime = DateTime.Now;
                FC7LCModel.OpIp = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCBLL.Add(FC7LCModel);
                    btnList_Click(new object(), new EventArgs());
                    Application["TCDLTData"] = "false";
                    if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                    {
                        WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TCDLTData");
                    }
                }
                else
                {
                    FC7LCBLL.Update(FC7LCModel);
                    btnList_Click(new object(), new EventArgs());
                }
                Application["TCDLTData"] = "false";
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TCDLTData");
                }
            }
            ViewState["hide"] = "0";
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=TCDLTData");
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
                    sql = "select top 1 * from TCDLTData where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from TCDLTData where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from TCDLTData order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("没有可删除的开奖信息!"));
                return;
            }
            TimeSpan ts = DateTime.Now - DateTime.Parse(row["date"].ToString());
            if (ts.Days > 2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("您只能删除最近二天的开奖信息"));
                return;
            }
            if (basicDAL.ExecuteSql("delete TCDLTData  where issue='" + row["issue"] + "'") > 0)
            {
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TCDLTData");
                }
                Application["TCDLTData"] = "false";
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("删除最近开奖信息成功！"));
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=TCDLTData");
            ViewState["hide"] = "0";
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string strIssue = e.CommandArgument.ToString();
            this.hfNewsID.Value = strIssue;
            ViewState["hide"] = strIssue;
            btnDivAdd_Click(new object(), new EventArgs());
        }

        //格式化IP地址
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }

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
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
        }


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
                //    sql = "select top 120 * from TCDLTData where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from TCDLTData where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
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
