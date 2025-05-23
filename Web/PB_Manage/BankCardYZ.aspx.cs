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
        //Email email = new Email(realUser.Email, "ƴ�����߲���ͨ������п���֤", result);
        //email.Send();
        //Response.Write(JS.Alert("�Ѿ����������䷢��һ��֪ͨ�ʼ�������գ�"));
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
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //�û���
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {
                bu.Append(" and UserName like '%" + Input.Filter(Request["strUsername"].Trim()) + "%' ");
            }

            //��ʵ����
            if (!string.IsNullOrEmpty(Request["strRealName"]))
            {
                bu.Append(" and RealName like '%" + Input.Filter(Request["strRealName"].Trim()) + "%' ");
            }


            //���п���
            if (!string.IsNullOrEmpty(Request["strAccountNumber"]))
            {
                bu.Append(" and AccountNumber ='" + Input.Filter(Request["strAccountNumber"].Trim()) + "' ");
            }

            //״̬
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
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                // string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());
                //this.lblTotal.Text = "�ܼƽ�" + strTotalTemp.Split(new char[] { '&' })[1] + "Ԫ&nbsp;�ܼ�:" + strTotalTemp.Split(new char[] { '&' })[0] + "����¼";
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
                        result = "δ������֤";                       
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                    case "1":
                        lblState.Visible = false;
                        lbtnEdite.Visible = true;
                        break;
                    case "2":
                        result = "<span  style='color:red;' >��֤ʧ��</span>";
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                    case "3":
                        result = "<span  style='color:green;' >��֤ͨ��</span>";
                        lbtnEdite.Visible = false;
                        lblState.Visible = true;
                        break;
                    case "4":
                        result = "<span>�Ѵ���</span>";
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
                    return "δ��֤";
                case"1":
                    return "��֤��";
                case "2":
                    return "<font color='red'>��֤ʧ��</font>";
                case "3":
                    return "<font color='green'>��֤ͨ��</font>";
                case "4":
                    return "�ȴ���֤";
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
