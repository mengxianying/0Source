using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pbzx.Common;
using Pbzx.BLL;
using System.Text;

namespace Pinble_Chipped.admin
{
    public partial class ExpectDtl : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_issueN get_pub = new Pbzx.BLL.Chipped_issueN();
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
            sb.Append("In_RnId=" + "'" + Request.QueryString["rn_id"] + "'");
            string Searchstr = sb.ToString();
            string order = "In_issue asc";
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
        Pbzx.BLL.Chipped_Num numnamager = new Chipped_Num();
        protected void My_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.My_GridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                int number = 0;
                //得到最新的一期
                PBnet_LotteryMenu lotry = new PBnet_LotteryMenu();
                Pbzx.Model.PBnet_LotteryMenu menu = lotry.GetModel(Convert.ToInt32(Request.QueryString["cpName"]));
                if (Request.QueryString["cpName"] != null && Request.QueryString["cpName"] != "")
                {

                    if (menu != null)
                    {
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 issue from " + menu.NvarApp_name + " order by issue desc");
                        if (dsperiod != null && dsperiod.Tables.Count > 0)
                            number = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]);
                    }
                }


                Label N_num = this.My_GridView.Rows[i].Cells[0].FindControl("N_num") as Label;
                Label N_Status = this.My_GridView.Rows[i].Cells[0].FindControl("N_Status") as Label;


                if (Convert.ToInt32(IResult.Rows[i]["In_issue"]) == number + 1)
                {
                    List<Pbzx.Model.Chipped_Num> list = numnamager.GetModelList("N_InId='" + IResult.Rows[i]["In_id"] + "'");
                    publicMethod pbmt = new publicMethod();
                    if (list != null && list.Count > 0)
                    {
                        foreach (Pbzx.Model.Chipped_Num item in list)
                        {

                            N_num.Text = "机选号码：" + item.N_num;
                        }

                    }
                    N_Status.Text = "未开奖";
                }

                else if (Convert.ToInt32(IResult.Rows[i]["In_issue"]) > number)
                {
                    N_num.Text = "********";
                    N_Status.Text = "未开奖";
                }
                else
                {

                    List<Pbzx.Model.Chipped_Num> list = numnamager.GetModelList("N_InId='" + IResult.Rows[i]["In_id"] + "'");
                    publicMethod pbmt = new publicMethod();
                    if (list != null && list.Count > 0)
                    {
                        foreach (Pbzx.Model.Chipped_Num item in list)
                        {

                            N_num.Text = "机选号码：" + item.N_num + " 开奖号码：" + pbmt.RlotteryNum(menu.NvarApp_name, menu.IntId, Convert.ToInt32(IResult.Rows[i]["In_issue"]));
                        }

                    }
                    N_Status.Text = "已开奖";
                }
                //出票状态
                Label lab_slt = this.My_GridView.Rows[i].Cells[0].FindControl("lab_slt") as Label;
                if (Convert.ToInt32(IResult.Rows[i]["In_mark"]) == 0)
                {
                    lab_slt.Text = "等待出票";
                }
                if (Convert.ToInt32(IResult.Rows[i]["In_mark"]) == 1)
                {
                    lab_slt.Text = "已出票";
                }
                if (Convert.ToInt32(IResult.Rows[i]["In_mark"]) == 2)
                {
                    lab_slt.Text = "出票失败";
                }

            }
        }

        public static string IsStatusName(object status)
        {
            if (status == null)
            {
                status = 0;
            }
            switch (Convert.ToInt32(status))
            {
                case 1:
                    return "已开奖";
                case 2:
                    return "退款";
                default:
                    return "未开奖";
            }
        }
    }
}