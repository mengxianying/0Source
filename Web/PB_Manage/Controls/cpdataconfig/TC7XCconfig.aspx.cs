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

namespace Pbzx.Web.PB_Manage.Controls.cpdataconfig
{
    public partial class TC7XCconfig : AdminBasic
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
            DataSet ds = lotBLL.GetList(" NvarApp_name='TC7XCData' ");
            txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            otherIssue = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            this.lblLinkAdd.Text = WebFunc.GetInfo("TC7XCData");    
        }
        protected void BindData()
        {
            string sql = "select top 15 * from TC7XCData order by issue desc";
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
                DataRow row = basicDAL.GetRowBySql("select * from TC7XCData where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "修改";
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string code, money, first, second, summoney, bigsmallmoney, oddevenmoney;

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from TC7XCData order by date desc";
                DataTable dt = basicDAL.GetLisBySql(sql);

                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToShortDateString();
                int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();
                //七星彩开奖为：每周二、周五、周日
                switch (((int)((DateTime.Parse(sdate.ToString())).DayOfWeek))+1)
                {
                    case 1: //星期天
                        sdate = (DateTime.Parse(sdate.ToString())).AddDays(2).ToShortDateString();//下个星期二
                        break;
                    case 3:   //星期二 
                        sdate = (DateTime.Parse(sdate.ToString())).AddDays(3).ToShortDateString();//下个星期五
                        break;
                    case 6: // 星期五
                        sdate = (DateTime.Parse(sdate.ToString())).AddDays(2).ToShortDateString();// 下个星期天 
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
                        //七星彩开奖为：每周二、周五、周日
                        switch (((int)((DateTime.Parse(sdate.ToString())).DayOfWeek)) + 1)
                        {
                            case 1: //星期天
                                sdate = (DateTime.Parse(sdate.ToString())).AddDays(2).ToShortDateString();//下个星期二
                                break;
                            case 3:   //星期二 
                                sdate = (DateTime.Parse(sdate.ToString())).AddDays(3).ToShortDateString();//下个星期五
                                break;
                            case 6: // 星期五
                                sdate = (DateTime.Parse(sdate.ToString())).AddDays(2).ToShortDateString();// 下个星期天 
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
                if ((DateTime.Parse(sdate.ToString().ToString())).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }
                code = "";
                money = "";
                first = "5000000";
                second = "";
                summoney = "0";
                bigsmallmoney = "0";
                oddevenmoney = "0";
            }
            else
            {
                string sql = "select * from TC7XCData where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToShortDateString();
                sissue = dt.Rows[0]["issue"];
                code = dt.Rows[0]["code"].ToString();
                summoney = dt.Rows[0]["summoney"].ToString();

                bigsmallmoney = dt.Rows[0]["bigsmallmoney"].ToString();
                oddevenmoney = dt.Rows[0]["oddevenmoney"].ToString();
                money = dt.Rows[0]["money"].ToString();
                first = dt.Rows[0]["first"].ToString();
                second = dt.Rows[0]["second"].ToString();
            }
            this.txtIssue.Text = sissue.ToString();            
            txtCode.Text = code.ToString();

            //期号
            this.lblIssue.Text = "格式：" + sissue;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.TC7XCData FC7LCBLL = new Pbzx.BLL.TC7XCData();
            string strErrMsg = "";
            if (this.txtCode.Text.Length != 7)
            {
                strErrMsg += "号码输入不完整.\\r\\n";
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
            else
            {
                Pbzx.Model.TC7XCData FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCModel = new Pbzx.Model.TC7XCData();
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(ViewState["hide"].ToString());
                }
                FC7LCModel.code = this.txtCode.Text.Trim();                
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.issue = this.txtIssue.Text;
                FC7LCModel.LastModifyTime = DateTime.Now;
                FC7LCModel.OpIp = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCBLL.Add(FC7LCModel);
                }
                else
                {
                    FC7LCBLL.Update(FC7LCModel);
                }
                Application["TC7XCData"] = "false";
            }
            ViewState["hide"] = "0";
            btnList_Click(new object(), new EventArgs());
           // Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=TC7XCData");
        }

        protected void FC7LC_del_code()
        {
            string sql = "";
            //判断是否搜索的数据
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from TC7XCData where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from TC7XCData where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from TC7XCData order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("没有可删除的开奖信息!"));
                return;
            }
            TimeSpan ts = DateTime.Now - DateTime.Parse(row["date"].ToString());
            //if (ts.Days > 2)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("您只能删除最近二天的开奖信息"));
            //    return;
            //}
            if (basicDAL.ExecuteSql("delete TC7XCData  where issue='" + row["issue"] + "'") > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("删除最近开奖信息成功！"));
                Application["TC7XCData"] = "false";
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=TC7XCData");
            ViewState["hide"] = "0";
            BindData();
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
                //    sql = "select top 120 * from TC7XCData where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from TC7XCData where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
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

