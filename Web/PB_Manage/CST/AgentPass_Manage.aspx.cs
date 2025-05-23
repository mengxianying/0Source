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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class AgentPass_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "ExpireDate";
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
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["name"]))
            {
                bu.Append(" and name like '%" + Request["name"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["province"]))
            {
                bu.Append(" and province like '%" + Request["province"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strSate"]))
            {
                bu.Append(" and Status='" + Request["strSate"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                bu.Append(" and UserName like '%" + Request["UserName"] + "%' ");
            }
            return bu.ToString();

        }


        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("必须保证至少有一条记录");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["Name"].ToString();
            Pbzx.BLL.AgentInfo bll = new Pbzx.BLL.AgentInfo();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除代理[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除代理[" + nvarname + "]成功！");
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgentPass_Editor.aspx?ID=[*]");
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
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


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.AgentInfo agentInfoBLL = new Pbzx.BLL.AgentInfo();
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


            DataTable lsResult = agentInfoBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }

        }
        public string GetSpot(object names, object lie)
        {
            string valueL = "";
            string Name = names.ToString();
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(Name);

            if (DbHelperSQL.Exists("select count(UserName) from PBnet_UserTable where UserName='" + Name + "'"))
            {
                if (lie.ToString() == "City")
                {
                    valueL = userModel.City;
                }
                else if (lie.ToString() == "Province")
                {
                    valueL = userModel.Province;
                }
                else if (lie.ToString() == "Telphone")
                {
                    valueL = userModel.Telphone + "&nbsp;" + userModel.Mobile;
                }
                else
                {
                    valueL = "";
                }
            }
            else
            {
                valueL = "";
            }
            return valueL.ToString();

        }

        protected void lbtnAdshow_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.AgentInfo AgentBLL = new Pbzx.BLL.AgentInfo();
            AgentBLL.ChangeAudit(id, "delshow");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);

        }
        protected void lbtnSate_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.AgentInfo AgentBLL = new Pbzx.BLL.AgentInfo();
            AgentBLL.ChangeState(id, "Status");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);


        }
        public static string GetDateTime(object strTime)
        {
            if (DateTime.Parse(strTime.ToString()) > DateTime.Now)
            {
                return strTime.ToString();
            }
            else
            {
                return "<font color='red'>" + strTime.ToString() + "</font>";
            }
        }
    }
}
