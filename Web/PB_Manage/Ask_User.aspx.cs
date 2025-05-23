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
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_User : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = " Score - Pointpenalty-otherPointpenalty DESC,OpenTime  ";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = false;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
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
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_ask_User MyBll = new Pbzx.BLL.PBnet_ask_User();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = column;
            int myCount = 0;

            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            DataTable IsResult = MyBll.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();


            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                bu.Append(" and UserName like '%" + Request["UserName"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["State"]))
            {
                bu.Append(" and State = '" + Request["State"].Trim() + "' ");
            }
             if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {

                    bu.Append(" and OpenTime between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");

                }
            }
            return bu.ToString();
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Ask_User_Edit.aspx?id=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("���뱣֤������һ����¼");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["UserName"].ToString();
            Pbzx.BLL.PBnet_ask_User MyBll = new Pbzx.BLL.PBnet_ask_User();
            if (MyBll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ��ƴ�����û�[" + nvarname + "]");
                 //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "FriendLink_Manage.aspx"));
                JS.Alert("ɾ�����[" + nvarname + "]�ɹ���");
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        public static string GetState(object nState)
        {
            string state = "";
            int intst = int.Parse(nState.ToString());
            switch (intst)
            {
                case 0:
                    state = "<font color='#FF6600'>����</font>";
                    break;
                case 1:
                    state = "<font color='#0066FF'>����</font>";
                    break;              
                default:
                    state = "δ֪";
                    break;
            }
            return state;
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
    }
}
