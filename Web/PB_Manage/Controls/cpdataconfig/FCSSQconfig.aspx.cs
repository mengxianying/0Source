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
    public partial class FCSSQconfig : AdminBasic
    {
        int intIssue = 7;//期号长度
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                BindData();
            }
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='FCSSData' ");
            txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            intIssue = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            this.lblLinkAdd.Text = WebFunc.GetInfo("FCSSData");    
        }
        protected void BindData()
        {
            string sql = "select top 15 * from FCSSData order by issue desc";
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
                this.btnSave.Text = "添加";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from FCSSData where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "修改";
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string redcode1, redcode2, redcode3, redcode4, redcode5, redcode6, bluecode, bluecode2;

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from FCSSData order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();
                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToShortDateString();


                //双色球开奖为：每周二、周四、周日
                switch (((int)DateTime.Parse(sdate.ToString()).DayOfWeek) + 1)
                {
                    case 1: //星期天
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString(); ;//下个星期二
                        break;
                    case 3:   //星期二 
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期四
                        break;
                    case 5: // 星期四
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// 下个星期天 
                        break;
                }

                bool isInXS = false;
                //判断是否在休市时间之内start(孟2010-02-23)
                if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                {
                    if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                    {
                        sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).ToShortDateString();//下一期开始时间 
                        isInXS = true;
                    }
                }
                //判断是否在休市时间之内end(孟2010-02-23)

                if(isInXS)
                {
                    string[] checkResult = WebFunc.GetYearEndDate(Convert.ToDateTime(sdate), "135");
                    if (checkResult[0] == "true")
                    {
                        //双色球开奖为：每周二、周四、周日
                        switch (((int)DateTime.Parse(sdate.ToString()).DayOfWeek) + 1)
                        {
                            case 1: //星期天
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString(); ;//下个星期二
                                break;
                            case 3:   //星期二 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期四
                                break;
                            case 5: // 星期四
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// 下个星期天 
                                break;
                        }
                    }
                    else
                    {
                        sdate = checkResult[1];
                    }
                }




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
                redcode1 = "";
                redcode2 = "";
                redcode3 = "";
                redcode4 = "";
                redcode5 = "";
                redcode6 = "";
                bluecode = "";
                bluecode2 = "00";
                ViewState["hide"] = "0";
                this.btnSave.Text = "添加";
            }
            else
            {
                string redcode = "";
                string sql = "select * from FCSSData where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"];
                sissue = dt.Rows[0]["issue"];
                redcode = dt.Rows[0]["redcode"].ToString();

                redcode1 = redcode.Substring(0, 2);
                redcode2 = redcode.Substring(2, 2);
                redcode3 = redcode.Substring(4, 2);
                redcode4 = redcode.Substring(6, 2);
                redcode5 = redcode.Substring(8, 2);
                redcode6 = redcode.Substring(10, 2);
                bluecode = dt.Rows[0]["bluecode"].ToString();
                bluecode2 = dt.Rows[0]["bluecode2"].ToString();
                ViewState["hide"] = sissue;
                this.btnSave.Text = "修改";
            }
           
            this.txtIssue.Text = sissue.ToString();
            this.txtRedcode1.Text = redcode1;
            this.txtRedcode2.Text = redcode2;
            this.txtRedcode3.Text = redcode3;
            this.txtRedcode4.Text = redcode4;
            this.txtRedcode5.Text = redcode5;
            this.txtRedcode6.Text = redcode6;
            this.txtBluecode.Text = bluecode;
            this.txtBluecode2.Text = bluecode2;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString(); 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.FCSSData FC7LCBLL = new Pbzx.BLL.FCSSData();
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string strErrMsg = "";

            if (this.txtIssue.Text.Length != intIssue)
            {
                strErrMsg += "期号错误：位数不符.\\r\\n";
            }

            if (this.txtRedcode1.Text.Trim().Length != 2 || this.txtRedcode2.Text.Trim().Length != 2 || this.txtRedcode3.Text.Trim().Length != 2 || this.txtRedcode4.Text.Trim().Length != 2 || this.txtRedcode5.Text.Trim().Length != 2 || this.txtRedcode6.Text.Trim().Length != 2 || this.txtBluecode.Text.Trim().Length != 2 || this.txtBluecode2.Text.Trim().Length != 2)
            {
                strErrMsg += "红球号码输入不完整.\\r\\n";
            }

            if (this.txtBluecode.Text.Trim().Length != 2 || this.txtBluecode2.Text.Trim().Length != 2)
            {
                strErrMsg += "蓝球号码或快乐星期天输入不完整.\\r\\n";                
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




            string code = this.txtRedcode1.Text + this.txtRedcode2.Text + this.txtRedcode3.Text + this.txtRedcode4.Text + this.txtRedcode5.Text + this.txtRedcode6.Text;
           // string tempCode = code + this.txtTcode.Text;
            string isCF = Method.showCheckStr(Method.FormartCode(code, ""), 33);
            if (isCF.Length > 0)
            {
                strErrMsg += isCF + ".\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.FCSSData FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCModel = new Pbzx.Model.FCSSData();
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(ViewState["hide"].ToString());
                }
                FC7LCModel.redcode = Method.OrderCode(Method.FormartCode(code, ""), "");
                FC7LCModel.bluecode = this.txtBluecode.Text;
                FC7LCModel.bluecode2 = this.txtBluecode2.Text;
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.issue = this.txtIssue.Text;
                FC7LCModel.LastModifytime = DateTime.Now;
                FC7LCModel.OpIP = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    if (FC7LCBLL.Add(FC7LCModel))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
                        Application["FCSSData"] = "false";
                        if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                        {
                            WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FCSSData");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("添加失败!"));
                        return;
                    }
                }
                else
                {
                    if (FC7LCBLL.Update(FC7LCModel))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
                        Application["FCSSData"] = "false";
                        if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                        {
                            WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FCSSData");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("更新失败!"));
                        return;
                    }
                }
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FCSSData");
        }
        protected void FC7LC_del_code()
        {
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string sql = "";
            //判断是否搜索的数据
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from FCSSData where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from FCSSData where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from FCSSData order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("没有可删除的开奖信息!"));
                return;
            }
            //TimeSpan ts = DateTime.Now - DateTime.Parse(row["date"].ToString());
            //if (ts.Days > 2)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("您只能删除最近二天的开奖信息"));
            //    return;
            //}
            if (basicDAL.ExecuteSql("delete FCSSData  where issue='" + row["issue"] + "'") > 0)
            {
                btnList_Click(new object(), new EventArgs());
            }
            Application["FCSSData"] = "false";
            if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
            {
                WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FCSSData");
            }
            ViewState["hide"] = "0";
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FCSSData");
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
                //string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 15 * from FCSSData where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 15 * from FCSSData where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
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
