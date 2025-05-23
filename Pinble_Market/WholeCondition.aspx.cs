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

namespace Pinble_Market
{
    public partial class WholeCondition : System.Web.UI.Page
    {
        Pbzx.BLL.Market_TypeManager get_type = new Pbzx.BLL.Market_TypeManager();
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        DataTable IsResult = new DataTable();
        private int rowCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMyRep();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindMyRep()
        {
            StringBuilder str = new StringBuilder();
            str.Append("1=1");
            string Searchstr = str.ToString();
            string order = "Id desc";
            int mycount = 0;
            IsResult = get_type.GuestGetBySearch(Searchstr, "*", order,Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            MyRep.DataSource = IsResult;
            MyRep.DataBind();

            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            rowCount = IsResult.Rows.Count;
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetCount());
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMyRep();
        }

        
        protected void MyRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.MyRep.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    LinkButton lab_NvarName = RI.FindControl("lab_NvarName") as LinkButton;
                   
                    DataSet ds = get_page.Market_Table("PBnet_LotteryMenu", "top 1 NvarName", "IntId=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["LotteryID"].ToString()));
                    if (ds != null && ds.Tables[0].Rows.Count>0)
                    {
                        lab_NvarName.Text = ds.Tables[0].Rows[0][0].ToString();
                        lab_NvarName.CommandArgument = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }

        }

        protected void lab_NvarName_Command(object sender, CommandEventArgs e)
        {
            Response.Write("<script> parent.mainFrame.location.href='Condi.aspx?name=" + Pbzx.Common.Input.Encrypt(e.CommandArgument.ToString()) + "&lott=" + Pbzx.Common.Input.Encrypt("0") + "';</script>");
        }

        //搜索
        protected void Ibtn_img_Click(object sender, ImageClickEventArgs e)
        {
            //查询是什么彩种
            DataSet dstable=get_page.Market_Table("PBnet_LotteryMenu","IntId","NvarName="+"'"+ Request.Form["username"].ToString() +"'");
            if (dstable != null && dstable.Tables[0].Rows.Count > 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append("LotteryID like'%" + Convert.ToInt32(dstable.Tables[0].Rows[0][0])  + "%'");
                string Searchstr = str.ToString();
                string order = "Id desc";
                int mycount = 0;
                IsResult = get_type.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
                MyRep.DataSource = IsResult;
                MyRep.DataBind();

                AspNetPagerConfig(mycount);
                if (IsResult == null)
                {
                    this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
                }
                else
                {
                    this.litContent.Text = "";
                }
                rowCount = IsResult.Rows.Count;
            }
            else
            {
                StringBuilder str = new StringBuilder();
                str.Append("TypeName like'%" +  Request.Form["username"].ToString()  + "%'");
                string Searchstr = str.ToString();
                string order = "Id desc";
                int mycount = 0;
                IsResult = get_type.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
                MyRep.DataSource = IsResult;
                MyRep.DataBind();

                AspNetPagerConfig(mycount);
                if (IsResult == null)
                {
                    this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
                }
                else
                {
                    this.litContent.Text = "";
                }
                rowCount = IsResult.Rows.Count;
            }
        }

    }
}
