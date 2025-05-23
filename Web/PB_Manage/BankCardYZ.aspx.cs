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
using System.Text;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class BankCardYZ : AdminBasic
    {
        //string result = Pbzx.Common.Method.GetEmailContent(("/Template/Email_Success.aspx?type=AccountNumberStateYZ&DH=123456"));
        //Email email = new Email(realUser.Email, "拼搏在线彩神通软件银行卡验证", result);
        //email.Send();
        //Response.Write(JS.Alert("已经向您的邮箱发送一封通知邮件，请查收！"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "AccountNumberCodeTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //用户名
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {
                bu.Append(" and UserName like '%" + Input.Filter(Request["strUsername"].Trim()) + "%' ");
            }

            //真实姓名
            if (!string.IsNullOrEmpty(Request["strRealName"]))
            {
                bu.Append(" and RealName like '%" + Input.Filter(Request["strRealName"].Trim()) + "%' ");
            }


            //银行卡号
            if (!string.IsNullOrEmpty(Request["strAccountNumber"]))
            {
                bu.Append(" and AccountNumber ='" + Input.Filter(Request["strAccountNumber"].Trim()) + "' ");
            }

            //状态
            if (!string.IsNullOrEmpty(Request["state"]))
            {
                bu.Append(" and State ='" + Input.Filter(Request["state"].Trim()) + "' ");
            }

            if (!string.IsNullOrEmpty(Request["strdate"]))
            {
                bu.Append(" and AccountNumberCodeTime between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
            }
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_UserTable mBLL = new Pbzx.BLL.PBnet_UserTable();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and CardID IS NOT NULL and len(CardID)>0 and  AccountNumber IS NOT NULL and len(AccountNumber)>0  ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = column;
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            int myCount = 0;
            DataTable lsResult = mBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                // string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());
                //this.lblTotal.Text = "总计金额：" + strTotalTemp.Split(new char[] { '&' })[1] + "元&nbsp;总计:" + strTotalTemp.Split(new char[] { '&' })[0] + "条记录";
                this.litContent.Text = "";
            }

        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string strState = MyGridView.DataKeys[e.Row.RowIndex].Values["AccountNumberState"].ToString();
                string intid = MyGridView.DataKeys[e.Row.RowIndex].Values["Id"].ToString();
                string result = "";
                e.Row.Cells[1].Text = "("+ Convert.ToString(((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id)+")";//+ "</a>";
                HtmlControl lbtnEdite = (HtmlControl)e.Row.Cells[8].FindControl("lbtnEdite");

                Literal lblState = (Literal)e.Row.Cells[8].FindControl("lblState");
                lbtnEdite.Attributes.Add("onclick", "var kk = window.showModalDialog(\"UserBankCardYZ.aspx?uid=" + intid + "\",\"\",\"help: No; resizable: No; status: No;scrollbars:No;scroll:yes;center:yes;dialogWidth:390px;dialogHeight:250px;\"); if(kk ==\"1\"){ window.parent.frames['ShowPage'].location.reload();}");
                switch (strState)
                {
                    case "0":
                        result = "未申请验证";                       
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                    case "1":
                        lblState.Visible = false;
                        lbtnEdite.Visible = true;
                        break;
                    case "2":
                        result = "<span  style='color:red;' >验证失败</span>";
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                    case "3":
                        result = "<span  style='color:green;' >验证通过</span>";
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                    case "4":
                        result = "<span>已处理</span>";
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                }
                lblState.Text = result;
                //style='color:blue;'
            }
        }
        

        protected string GetStateNameByStateID( object state)
        { 
            switch(state.ToString())
            {
                case "0":
                    return "未验证";
                case"1":
                    return "验证中";
                case "2":
                    return "<font color='red'>验证失败</font>";
                case "3":
                    return "<font color='green'>验证通过</font>";
                case "4":
                    return "等待验证";
            }
            return "";
        }

        protected string GetUserIDByUserName(object uName)
        {
            object uid = DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + uName + "'  ");
            if (uid != null)
            {
                return uid.ToString();
            }
            else
            {
                return "";
            }
        }

    }
}
