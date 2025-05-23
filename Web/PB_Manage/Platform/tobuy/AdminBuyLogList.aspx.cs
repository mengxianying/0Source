using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.BLL;
using System.Data;
using System.Text;

namespace Pbzx.Web.PB_Manage.Platform.tobuy
{
    public partial class AdminBuyLogList : AdminBasic
    {
        Pbzx.BLL.PlatformPublic_payments get_pub = new Pbzx.BLL.PlatformPublic_payments();
        DataTable IResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                
            }
        }

        public void BindPrice()
        {
            StringBuilder sb = new StringBuilder();
            //     sb.Append("Pp_name=" + "'" + Method.Get_UserName.ToString() + "'");
            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {

                sb.Append(" and Pp_Type='" + Request.QueryString["type"] + "' ");
            }

            string Searchstr = sb.ToString();
            DataSet ds = get_pub.GetList(Searchstr);


            //总计
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
                {
                    double price = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        price += Convert.ToDouble(ds.Tables[0].Rows[i]["Pp_data"]);
                    }
                    if (Request.QueryString["type"].ToString() == "1")
                    {
                        lab_count.Text = "当前总支出：<font color='red'>" + price.ToString() + "</font>元";
                    }
                    else if (Request.QueryString["type"].ToString() == "2")
                    {
                        lab_count.Text = "当前总收入：<font color='red'>" + price.ToString() + "</font>元";
                    }
                    else
                    {
                        lab_count.Text = "当前总冻结：<font color='red'>" + price.ToString() + "</font>元";
                    }
                }
                else
                {
                    double zcprice = 0;
                    double sqprice = 0;
                    double djprice = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["Pp_Type"].ToString() == "1")
                            zcprice += Convert.ToDouble(ds.Tables[0].Rows[i]["Pp_data"]);
                        else if (ds.Tables[0].Rows[i]["Pp_Type"].ToString() == "2")
                            sqprice += Convert.ToDouble(ds.Tables[0].Rows[i]["Pp_data"]);
                        else if (ds.Tables[0].Rows[i]["Pp_Type"].ToString() == "3")
                            djprice += Convert.ToDouble(ds.Tables[0].Rows[i]["Pp_data"]);

                    }
                    lab_count.Text = "当前总支出：<font color='red'>" + zcprice.ToString() + "</font>元 当前总收取：<font color='red'>" + sqprice.ToString() + "</font>元 当前总冻结：<font color='red'>" + djprice.ToString() + "</font>元";
                }
            }
        }

        /// <summary>
        /// 绑定我的购彩记录
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            //    sb.Append("Pp_name=" + "'" + Method.Get_UserName.ToString() + "'");
            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {

                sb.Append(" and Pp_Type='" + Request.QueryString["type"] + "' ");
            }

            string Searchstr = sb.ToString();
            string order = "Pp_Time desc";
            int myCount = 0;
            IResult = get_pub.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                MyGridView.DataSource = IResult;
                MyGridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
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
            BindMy_GridView();
        }



        public static string IsTypeName(object Typeid)
        {
            if (Typeid == null)
            {
                Typeid = 3;
            }
            switch (Convert.ToInt32(Typeid))
            {
                case 1:
                    return "<a href='BuyLogList.aspx?type=1'>支出</a>";
                case 2:
                    return "<a href='BuyLogList.aspx?type=2'>收取</a>";
                default:
                    return "<a href='BuyLogList.aspx?type=3'>冻结</a>";
            }
        }


        public static string GetLottoryName(object lottoryId)
        {
            if (lottoryId != null)
            {
                if (lottoryId.ToString() == "9999")
                {
                    return "排列三";
                }
                PBnet_LotteryMenu lot = new PBnet_LotteryMenu();
                Pbzx.Model.PBnet_LotteryMenu model = lot.GetModel(Convert.ToInt32(lottoryId));
                return model.NvarName;
            }
            return "";
        }
        /// <summary>
        /// 序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }
    }
}