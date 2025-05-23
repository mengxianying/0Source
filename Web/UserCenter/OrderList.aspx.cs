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

namespace Pbzx.Web.UserCenter
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrderList();

            }
        }

        //private void BindOrderList()
        //{
        //    Pbzx.Model.PBnet_UserTable userLogined = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
        //    Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
        //    DataSet ds = orderBll.SelectOrdersByUserID(int.Parse(Method.Get_UserID));
        //    gvOrderList.DataSource = ds;
        //    gvOrderList.DataBind();            
        //}
        public static string Totall(object TotalProductPrice, object PortPrice)
        {
            decimal Tprice = Convert.ToDecimal(TotalProductPrice) + Convert.ToDecimal(PortPrice);
            return string.Format("{0:C2}", Tprice);
        }
        public static string NotPlay(object TotalProductPrice, object PortPrice, object HasPayedPrice)
        {
            decimal NotPrice = Convert.ToDecimal(TotalProductPrice) + Convert.ToDecimal(PortPrice) - Convert.ToDecimal(HasPayedPrice);
            return string.Format("{0:C2}", NotPrice);
        }

        private void BindOrderList()
        {
            Pbzx.Model.PBnet_UserTable userLogined = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(" and UserID='" + int.Parse(Method.Get_UserID) + "'");
            bu.Append(this.AddParameter());

            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "OrderDate desc";
            int myCount = 0;
            DataTable lsResult = orderBll.GuestGetBySearch(Searchstr, "OrderID,UserID,UserName,OrderDate,TotalProductPrice,HasPayedPrice,PortPrice,PayTypeID,PayTypeName,TipID,TipName,UpdateStaticDate,Type,IsPay,IsCancel,OrderClass", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.gvOrderList.DataSource = lsResult;
            this.gvOrderList.DataBind();
            AspNetPagerConfig(myCount);

            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
                //  lblMsg.Text = "暂无订单！";
            }
            else
            {
                this.litContent.Text = "";
                //  lblMsg.Text = "您现在共有订单记录：" + lsResult.Rows.Count + "条记录";
            }
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条记录&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页共计<font color=\"red\"><b>" + gvOrderList.Rows.Count + "</b></font>条记录&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindOrderList();
        }

        protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderList.PageIndex = e.NewPageIndex;
            BindOrderList();
        }
        private string AddParameter()
        {
            string strState = Input.FilterAll(Request["strState"]);
            string dateType = Input.FilterAll(Request["dateType"]);
            string strCreateTime1 = Input.FilterAll(Request["strCreateTime1"]);
            string strCreateTime2 = Input.FilterAll(Request["strCreateTime2"]);
            string IsCancel = Input.FilterAll(Request["IsCancel"]);

            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(strState))
            {
                bu.Append(" and TipID='" + strState + "' ");
            }
            if (!string.IsNullOrEmpty(dateType))
            {
                if (!string.IsNullOrEmpty(strCreateTime1) && !string.IsNullOrEmpty(strCreateTime2))
                {
                    bu.Append(" and OrderDate between '" + strCreateTime1 + "' and '" + strCreateTime2 + " 23:59:59'  ");
                }
            }
            if (!string.IsNullOrEmpty(IsCancel) && IsCancel != "-1")
            {
                if (IsCancel == "0")
                {
                    bu.Append(" and IsCancel ='0' ");
                }
                else
                {
                    bu.Append(" and (IsCancel ='1' or IsCancel ='2') ");
                }
            }
            else if (IsCancel != "-1")
            {
                bu.Append(" and IsCancel ='0' ");
            }
            //IsCancel
            return bu.ToString();

        }

        protected void gvOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                // string href = "<a href='/SoftRegisterLog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                // e.Row.Cells[0].Text = href + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString();//+ "</a>";
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }

        protected void gvOrderList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string orderID = gvOrderList.DataKeys[e.Row.RowIndex].Values["OrderID"].ToString();
                string payTypeID = gvOrderList.DataKeys[e.Row.RowIndex].Values["PayTypeID"].ToString();
                string payTypeName = gvOrderList.DataKeys[e.Row.RowIndex].Values["PayTypeName"].ToString();
                string type = gvOrderList.DataKeys[e.Row.RowIndex].Values["Type"].ToString();
                string isCancel = gvOrderList.DataKeys[e.Row.RowIndex].Values["IsCancel"].ToString();
                int TipID = Convert.ToInt32(gvOrderList.DataKeys[e.Row.RowIndex].Values["TipID"]);
                string IsPay = gvOrderList.DataKeys[e.Row.RowIndex].Values["IsPay"].ToString();



                if (isCancel == "1")
                {
                    e.Row.Cells[5].Text = "用户取消";
                    e.Row.Cells[8].Text = " --- ";
                }
                else if (isCancel == "2")
                {
                    e.Row.Cells[5].Text = "系统取消";
                    e.Row.Cells[8].Text = " --- ";
                }
                else
                {
                    LinkButton lbtnCancel = new LinkButton();
                    if (TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.等待付款 || TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.款额不足)
                    {
                        if (IsPay == "1")
                        {
                            e.Row.Cells[5].Text = "已付款，等待验证";
                            e.Row.Cells[8].Text = " --- ";
                        }
                        else
                        {

                            if (type == "0")
                            {
                                HyperLink hlWSZF = new HyperLink();
                                hlWSZF.Text = "网上支付";
                                hlWSZF.NavigateUrl = "OnlinePay.aspx?OrderID=" + orderID + "";
                           //   hlWSZF.Target = "top";
                                hlWSZF.Target = "_blank";
                                e.Row.Cells[8].Controls.Add(hlWSZF);
                                Label lblFG = new Label();
                            //  lblFG.Text = "&nbsp;|&nbsp;";
                                e.Row.Cells[8].Controls.Add(lblFG);
                            }
                            else
                            {
                                HyperLink hlYHZZ = new HyperLink();
                                hlYHZZ.Text = "银行转账";
                                hlYHZZ.NavigateUrl = "BankTransfer.aspx?OrderID=" + orderID + "";
                                hlYHZZ.Target = "top";
                                e.Row.Cells[8].Controls.Add(hlYHZZ);

                                Label lblFG = new Label();
                               lblFG.Text = "&nbsp;|&nbsp;";
                                e.Row.Cells[8].Controls.Add(lblFG);

                                HyperLink hlQRFK = new HyperLink();
                                hlQRFK.Text = "确认付款";
                                hlQRFK.NavigateUrl = "detailsorder.aspx?OrderID=" + orderID + "";
                                hlQRFK.Target = "top";
                                e.Row.Cells[8].Controls.Add(hlQRFK);

                                Label lblFG1 = new Label();
                             //   lblFG1.Text = "&nbsp;|&nbsp;";
                                e.Row.Cells[8].Controls.Add(lblFG1);
                            }
                            lbtnCancel.Text = "取消";
                            lbtnCancel.Enabled = false;
                            lbtnCancel.Visible = false;
                            lbtnCancel.CommandArgument = orderID;
                            lbtnCancel.OnClientClick = "return confirm('您确定要取消该订单吗？')";
                            lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
                            e.Row.Cells[8].Controls.Add(lbtnCancel);
                        }
                    }
                    //else if (TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.已开通)
                    //{
                    //    lbtnCancel.Text = "交易完成确认";
                    //    lbtnCancel.CommandArgument = orderID;
                    //    lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
                    //    e.Row.Cells[8].Controls.Add(lbtnCancel);//
                    //}
                    else
                    {
                        e.Row.Cells[8].Text = " --- ";
                    }
                }
            }
        }

        protected void lbtnCancel_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbtnCancel = (LinkButton)sender;
            if (lbtnCancel.Text == "取消")
            {
                DbHelperSQL.ExecuteSql(" update  PBnet_Orders set IsCancel=1 where OrderID='" + e.CommandArgument.ToString() + "'   ");
            }
            else if (lbtnCancel.Text == "交易完成确认")
            {
                DbHelperSQL.ExecuteSql(" update  PBnet_Orders set TipID=" + ((int)Pbzx.Model.PBnet_OrderStaticTip.已完成) + ",TipName='" + WebFunc.GetTipNameByTipID((int)Pbzx.Model.PBnet_OrderStaticTip.已完成) + "'  where OrderID='" + e.CommandArgument.ToString() + "'   ");
            }

            BindOrderList();
        }
    }
}
