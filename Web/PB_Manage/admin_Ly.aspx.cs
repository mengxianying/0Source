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
    public partial class admin_Ly : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "LyLogTime";
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
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["strLy_Email"]))
            {
                bu.Append(" and LyUserName like '%" + Request["strLy_Email"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strLyContent"]))
            {
                bu.Append(" and LyContent like '%" + Request["strLyContent"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["State"]))
            {
                bu.Append(" and LyState ='" + Request["State"] + "'");
            }

            if (!string.IsNullOrEmpty(Request["Sort"]))
            {
                bu.Append(" and LySort= '" + Request["Sort"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {

                    bu.Append(" and LyLogTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
              
                }
            }
            return bu.ToString();

        }

        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_LyBook BookBLL = new Pbzx.BLL.PBnet_LyBook();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
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

            DataTable lsResult = BookBLL.GuestGetBySearch2(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
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
                string href = "<a href='admin_Ly_Edit.aspx?ID=" + e.Row.Cells[0].Text + "'  target='_blank' >";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
     
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_LyBook BookBLL = new Pbzx.BLL.PBnet_LyBook();
            if (BookBLL.Delete(id))
            {
                JS.Alert("ɾ���ɹ���");
            }
            else
            {
                JS.Alert("ɾ��ʧ�ܣ�");
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
    }
}
