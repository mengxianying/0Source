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
    public partial class Master_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Pbzx.Model.PBnet_tpman MyAdmin = Pbzx.BLL.PBnet_tpman.GetNowUser();
            if (!IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();    
            }
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Pbzx.Model.PBnet_tpman MyAdmin = Pbzx.BLL.PBnet_tpman.GetNowUser();

            if (MyGridView.Rows[e.RowIndex].Cells[1].Text == MyAdmin.Master_Name)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "killself", JS.Alert("不能删除自己."));
                e.Cancel = true;
                return;
            }
            if (MyGridView.Rows[e.RowIndex].Cells[1].Text.ToLower() == "administrator")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "killadmin", JS.Alert("超级管理员帐户不能被删除."));
                e.Cancel = true;
                return;
            }

            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string Master_Name = MyGridView.DataKeys[e.RowIndex].Values["Master_Name"].ToString();
            Pbzx.BLL.PBnet_tpman bll = new Pbzx.BLL.PBnet_tpman();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除管理员[" + Master_Name + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除管理员[" + Master_Name + "]成功！");
            }


            BindData();
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex >= 0)
            //{
            //    TableCell MyCell = e.Row.Cells[6];
            //    MyCell.Attributes.Add("onclick", "return confirm('您确定要删除吗?');");
            //}
        }



        private void BindData()
        {
            Pbzx.BLL.PBnet_tpman tpmanBLL = new Pbzx.BLL.PBnet_tpman();
            StringBuilder bu = new StringBuilder();

            bu.Append(" 1=1 ");
            //bu.Append(this.AddParameter());
            string strCount = bu.ToString();
            ///////////////////////////////////////////////////////////////////////////////////

            string Searchstr = bu.ToString();
            string order = "state desc,LasTime desc ";
            int myCount = 0;

            DataTable lsResult = tpmanBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum,3, AspNetPager1.CurrentPageIndex,out myCount);

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

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "  <a href='Master_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }



        #region 添加查询参数，暂时不用
        //private string AddParameter()
        //{
        //    StringBuilder bu = new StringBuilder();
        //    if (!string.IsNullOrEmpty(Request["IsAuditing"]))
        //    {
        //        bu.Append(" and IsAuditing = '" + Request["IsAuditing"].ToString() + "'");
        //    }

        //    if (!string.IsNullOrEmpty(Request["Nominate1"]))
        //    {
        //        bu.Append(" and Nominate1 = '" + Request["Nominate1"].ToString() + "'");
        //    }
        //    if (!string.IsNullOrEmpty(Request["regedit"]))
        //    {
        //        bu.Append(" and [Time] between dateAdd(day," + this.Request["regedit"].ToString() + ",getdate()) and getdate()  ");
        //    }
        //    if (!string.IsNullOrEmpty(Request["key"]))
        //    {
        //        string key = Request["key"].ToString();
        //        if (key == "已审核")
        //        {
        //            bu.Append(" and IsAuditing = 1 ");
        //        }
        //        if (key == "未审核")
        //        {
        //            bu.Append(" and IsAuditing = 0 ");
        //        }
        //        bu.Append(" and Username like '%" + key + "%' or Title  like '%" + key + "%'or  [Time] like '%" + key + "%' or JobDescription  like '%" + key + "%' or OwnEvaluation  like '%" + key + "%' ");
        //    }
        //    return bu.ToString();
        //}
        #endregion



    }
}













