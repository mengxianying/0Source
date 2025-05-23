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

namespace Pbzx.Web.PB_Manage
{
    public partial class FriendLink_Manage : AdminBasic
    {
        #region

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                //this.IsAuthority(0); 

                //给排序属性赋初值
                //默认 PostTime 
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "SortOrder";
                }
                if (ViewState["isDesc"] == null)
                {
//                    ViewState["isDesc"] = false;
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex >= 0)
            //{
            //    TableCell MyCell = e.Row.Cells[8];
            //    MyCell.Attributes.Add("onclick", "return confirm('您确定要删除吗?');");
            //}   
        }




        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FriendLink_Manage.aspx");
        }

        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_Links linkBLL = new Pbzx.BLL.PBnet_Links();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string strCount = bu.ToString();
            ///////////////////////////////////////////////////////////////////////////////////

            string Searchstr = bu.ToString();

            //排序条件
            string order = column;
            //判断是升序排列还是降序
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }
            int myCount = 0;



            DataTable lsResult = linkBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
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

        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["IntSiteName"]))
            {
                bu1.Append(" and (IntSiteName like '%" + Input.FilterAll(Request["IntSiteName"].Trim()) + "%' or NteSiteUrl like '%" + Input.FilterAll(Request["IntSiteName"].Trim()) + "%') ");
            }

            if (!string.IsNullOrEmpty(Request["IntLinkType"]))
            {
                bu1.Append(" and IntLinkType='" + Request["IntLinkType"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["BitIsOK"]))
            {
                bu1.Append(" and BitIsOK='" + Request["BitIsOK"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["IsGood"]))
            {
                bu1.Append(" and BitIsGood='" + Request["IsGood"] + "' ");
            }
            return bu1.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Links LinkBll = new Pbzx.BLL.PBnet_Links();
            Pbzx.Model.PBnet_Links LinkMedol = LinkBll.GetModel(id);
            string Nvname = LinkMedol.IntSiteName.ToString();
            if (LinkBll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除友情链接[" + Nvname + "]");
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }



        #endregion

        protected void lbtnIsGood_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Links.ChangeAudit(id, "BitIsGood");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void lbtnIsOK_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Links.ChangeAudit(id, "BitIsOK");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        public static string GetPic(object strUrl)
        {
            string strPic = strUrl.ToString();

            if (strPic != null && strPic != "")
            {
                return "<img src='" + strPic + "' border='0'>";
            }
            else
            {
                return null;
            }
        }

        public static string GetStatus(object Status)
        {
            if (Status != null)
            {
                if (Status.ToString() == "1")
                {
                    return "<font color='blue'>已通过</font>";
                }
                else if (Status.ToString() == "0")
                {
                    return "<font color='black'>未通过</font>";
                }
                else
                {
                    return "<font color='red'>未审核</font>";
                }

            }
  
                return "Error";
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
