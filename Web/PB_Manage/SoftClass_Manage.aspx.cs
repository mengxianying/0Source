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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftClass_Manage : AdminBasic
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();               
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            Pbzx.BLL.PBnet_SoftClass softclassBLL = new Pbzx.BLL.PBnet_SoftClass();
            //if (!string.IsNullOrEmpty(Request["IntSetting"]))
            //{
            //    int index = int.Parse(Request["IntSetting"]) + 1;
            //    this.rblIntSetting.SelectedIndex = index;
            //}
         
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            if (Request["classType"] == "yuan")
            {
                this.yuanID.Visible = true;
                bu.Append(" and IntSetting=1");
            }
            else if (Request["classType"] == "chan")
            {
                this.chanID.Visible = true;
                bu.Append(" and IntSetting=0");
            }
            bu.Append(this.AddParameter());
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "IntOrderID asc ";
            int myCount = 0;

            DataTable lsResult = softclassBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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


        /// <summary>
        /// 分页控件配置
        /// </summary>
        /// <param name="tempCount"></param>
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

        /// <summary>
        /// 页面改变重新绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("必须保证至少有一条记录");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["NvarClassName"].ToString();
            Pbzx.BLL.PBnet_SoftClass bll = new Pbzx.BLL.PBnet_SoftClass();
            DbHelperSQL.ExecuteSql("delete from PBnet_Product where pb_ClassID='"+id+"' ");
            DbHelperSQL.ExecuteSql("delete from PBnet_Soft where pb_ClassID='" + id + "' ");
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除商品资源类别[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除软件类别[" + nvarname + "]成功！");
            }
            BindData();
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <returns></returns>
        private string  AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["IntSetting"]) && Request["IntSetting"] != "-1")
            {
                bu.Append(" and IntSetting=" + Request["IntSetting"]);
            }
            return bu.ToString();
        }

        //protected void rblIntSetting_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect("SoftClass_Manage.aspx?IntSetting="+this.rblIntSetting.SelectedValue, true);
        //}

        /// <summary>
        /// 得到浏览权限
        /// </summary>
        /// <param name="browsePurview"></param>
        /// <returns></returns>
        protected string GetBrowsePurview(object browsePurview)
        {
            switch (browsePurview.ToString())
            {
                case "9999":
                    return "游客";
                case "999":
                    return "注册用户";
                case "99":
                    return "收费用户";
                case "9":
                    return "VIP用户";
                case "5":
                    return "管理员";
                default:
                    return "未设置";
            }//AddPurview
        }


        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString()+")";
            }
        }

        protected void lbtnIsAuditing_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_SoftClass.ChangeAudit(id, "BitIsElite");
            BindData();
        }

        protected void lbtnBitComment_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_SoftClass.ChangeAudit(id, "pb_ShowOnTop");
            BindData();
        }

    }
}
