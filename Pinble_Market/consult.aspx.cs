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

namespace Pinble_Market
{
    public partial class consult : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_appendItemManager get_app = new Pbzx.BLL.Market_appendItemManager();
        DataTable IsResult = new DataTable();
        private int rowCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindmyRep();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="name">name</param>
        private void BindmyRep()
        {
            string condition = Input.Decrypt(Request["search"]).ToString();
            StringBuilder sb = new StringBuilder();
            if (condition == "免费")
            {
                sb.Append("Charge=0");
            }
            else if (condition == "收费")
            {
                sb.Append( "Charge=1");
            }
            else
            {
                sb.Append("UserId like'%" + condition +"%'");
                sb.Append(" or TypeName like '%" +  condition +"%'");
                sb.Append(" or NvarName like '%" +  condition +"%'");
                //sb.Append(" group by NvarName,TypeName,UserId,Charge,[Time],appendid,say");
               
            }
            string Searchstr = sb.ToString();
            string order = "[Time] desc ";
            int mycount = 0;
            IsResult = get_app.GuestGetBySearch(Searchstr, "NvarName,TypeName,UserId,Charge,[Time],appendid,say", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            if (IsResult != null && IsResult.Rows.Count > 0)
            {
                myRep.DataSource = IsResult;
                myRep.DataBind();
                litContent.Text = "";
            }
            else
            {
                litContent.Text = "<b>没有您搜索的数据</b>";
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
            BindmyRep();
        }
        //myRep事件
        protected void myRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myRep.Items)
            {
                //不属于页眉或是页脚
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_charge = RI.FindControl("lab_charge") as Label;
                    Label lab_ExpectNum = RI.FindControl("lab_ExpectNum") as Label;
                    //根据彩种 查询最新的一期
                    DataSet ds = get_page.Market_GetNum(" top 1 ExpectNum","appendID="+"'"+ IsResult.Rows[RI.ItemIndex]["appendid"].ToString() +"'"+" order by ExpectNum desc");
                    lab_ExpectNum.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Charge"]) == 0)
                    {
                        lab_charge.Text = "免费";
                    }
                    else
                    {
                        lab_charge.Text = "收费";
                    }
                }
            }
        }
    }
}
