using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Pbzx.Common;
using Pbzx.BLL;
using System.Data;

namespace Pinble_Chipped.admin
{
    public partial class ExpectList : System.Web.UI.Page
    {

        Pbzx.BLL.Chipped_RandomNum get_pub = new Pbzx.BLL.Chipped_RandomNum();
        DataTable IResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href ='/LoginPage.aspx'</script>");
                //Response.Write("<script type='text/javascript'>window.top.location.href ='/LoginPage.aspx'</script>");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {

                BindMy_GridView();
            }
        }
        /// <summary>
        /// 绑定我的购彩记录
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Rn_name=" + "'" + Method.Get_UserName.ToString() + "'");
            string Searchstr = sb.ToString();
            string order = "Rn_id desc";
            int myCount = 0;
            IResult = get_pub.GuestGetBySearch(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                My_GridView.DataSource = IResult;
                My_GridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 30;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + My_GridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMy_GridView();
        }

        //序号生成
        protected void My_GridView_RowCreated(object sender, GridViewRowEventArgs e)
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
        //绑定事件
        protected void My_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.My_GridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //彩种名称
                Label lab_lotteryName = this.My_GridView.Rows[i].Cells[0].FindControl("lab_lotteryName") as Label;

                Label Rn_state = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_state") as Label;

                Label Rn_multiple = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_multiple") as Label;

                Label Rn_note = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_note") as Label;

                Label Rn_tmtion = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_tmtion") as Label;

                Label Rn_mess = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_mess") as Label;

                Label Rn_number = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_number") as Label;

                Label Rn_begin = this.My_GridView.Rows[i].Cells[0].FindControl("Rn_begin") as Label;


                //查询用户帐户的余额是否能支付购买
                publicMethod pubMod = new publicMethod();
                if (IResult.Rows[i]["Rn_play"].ToString() == "9999")
                {
                    lab_lotteryName.Text = "排列三";
                }
                else
                {
                    DataSet ds = pubMod.Chipped_Table("PBnet_LotteryMenu", "NvarName", "IntId=" + "'" + IResult.Rows[i]["Rn_play"] + "'");
                    if (ds != null)
                    {
                        lab_lotteryName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                    }
                }
                Rn_multiple.Text = IResult.Rows[i]["Rn_multiple"].ToString();

                Rn_note.Text = IResult.Rows[i]["Rn_note"].ToString();

                Chipped_issueN chipped = new Chipped_issueN();
                DataSet dse = chipped.GetList(" In_RnId= " + IResult.Rows[i]["Rn_id"].ToString());
                if (dse != null && dse.Tables.Count > 0)
                    Rn_number.Text = dse.Tables[0].Rows.Count + "期";
                if (dse != null && dse.Tables.Count > 0 && dse.Tables[0].Rows.Count > 0)
                    Rn_begin.Text = dse.Tables[0].Rows[0]["In_issue"].ToString() + "- " + dse.Tables[0].Rows[dse.Tables[0].Rows.Count - 1]["In_issue"].ToString();



                if (Convert.ToInt32(IResult.Rows[i]["Rn_tmtion"]) <= 0)
                    Rn_tmtion.Text = "无";
                else
                    Rn_tmtion.Text = IResult.Rows[i]["Rn_tmtion"].ToString()+" 元";

                if (IResult.Rows[i]["Rn_mess"].ToString() == "0")
                    Rn_mess.Text = "否";
                else
                    Rn_mess.Text = "是";

                if (Convert.ToInt32(IResult.Rows[i]["Rn_state"]) == 1)
                {
                    Rn_state.Text = "正常";
                }
                else
                {
                    Rn_state.Text = "终止";
                }

            }
        }
    }
}