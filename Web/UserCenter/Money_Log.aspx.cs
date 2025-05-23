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
    public partial class Money_Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='UserRealInfo.aspx';}</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)         
            {
             
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "OrderDate";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
                Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(Method.Get_UserName);
                this.lblUserBalance.Text = Math.Round((decimal)userModel.CurrentMoney - (decimal)userModel.FrozenMoney, 2) + "元";
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
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页共<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            string strType = Input.FilterAll(Request["strType"]);
            string strState = Input.FilterAll(Request["strState"]);
            string IsCancel = Input.FilterAll(Request["IsCancel"]);
            string dateType = Input.FilterAll(Request["dateType"]);
            string strCreateTime1 = Input.FilterAll(Request["strCreateTime1"]);
            string strCreateTime2 = Input.FilterAll(Request["strCreateTime2"]);
         
            //注册类型
            //if (!string.IsNullOrEmpty(Request["registerType"]))
            //{
            //    switch (Request["registerType"])
            //    {
            //        case "公司注册":
            //            bu.Append(" and RegisterType=1 ");
            //            break;
            //        case "代理注册":
            //            bu.Append(" and RegisterType=2 ");
            //            break;
            //        case "充值卡注册":
            //            bu.Append(" and RegisterType=3 ");
            //            break;
            //        default:
            //            bu.Append(" and AgentName='" + Request["registerType"] + "' ");
            //            break;
            //    }
            //}
            //状态
            if (!string.IsNullOrEmpty(strType))
            {
                bu.Append(" and Type ='" + strType + "'");
            }

          //状态
            if (!string.IsNullOrEmpty(strState))
            {
                bu.Append(" and State ='" + strState + "'");
            }
            //是否取消
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


            if (!string.IsNullOrEmpty(dateType))
            {

                bu.Append(" and OrderDate between '" + Input.FilterAll(strCreateTime1) + "' and '" + DateTime.Parse(strCreateTime2).AddDays(1).ToShortDateString() + "'  ");             
            }

            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_Charge mBLL = new Pbzx.BLL.PBnet_Charge();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and UserName='"+Method.Get_UserName+"' ");
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

            DataTable lsResult = mBLL.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
               // string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());
                //this.lblTotal.Text = "总计金额：" + strTotalTemp.Split(new char[] { '&' })[1] + "元&nbsp;总计:" + strTotalTemp.Split(new char[] { '&' })[0] + "条记录";
                this.litContent.Text = "";
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

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
               // string href = "<a href='/SoftRegisterLog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
               // e.Row.Cells[0].Text = href + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString();//+ "</a>";
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }

        protected string GetZY(object type, object state, object PayTypeName,object PayMoney)
        { 
            string result ="";
            //result += PayTypeName;

            if (type.ToString() == "0")
            {
                result += "充值";
            }
            else
            {
                string srtPay = Convert.ToDecimal(PayMoney).ToString("0.00");
                if (state.ToString() == "2")
                {
                    result += "<span color='red'>取款" + srtPay + "元<span>";
                }
                else
                {
                    result += "取款" + srtPay + "元";
                }
            }
            return result;
        }

        protected string GetState(object state)
        {

            string strSta = state.ToString();
            string result = "";
            switch (strSta)
            {
                case "0":
                    result = "处理中";
                    break;
                case "1":
                    result = "已通过";
                    break;
                case "2":
                    result = "审核未通过";//<span  style='color:red;' ></span>
                    break;
            }
            return result;
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string orderID =  MyGridView.DataKeys[e.Row.RowIndex].Values["OrderID"].ToString();
                string payTypeID = MyGridView.DataKeys[e.Row.RowIndex].Values["PayTypeID"].ToString();
                string payTypeName = MyGridView.DataKeys[e.Row.RowIndex].Values["PayTypeName"].ToString();
                Pbzx.BLL.PBnet_PayType payBll = new Pbzx.BLL.PBnet_PayType();

                string type = payBll.GetModel(int.Parse(payTypeID)).PayValue.ToString(); 

                string isCancel = MyGridView.DataKeys[e.Row.RowIndex].Values["IsCancel"].ToString();
                Pbzx.BLL.PBnet_Charge chargeBll = new Pbzx.BLL.PBnet_Charge();
                Pbzx.Model.PBnet_Charge chargeModel = chargeBll.GetModelByOrderId(orderID);
                if (isCancel== "1")
                {
                    e.Row.Cells[6].Text = "用户取消";
                    e.Row.Cells[7].Text = " --- ";
                }
                if (isCancel == "2")
                {
                    e.Row.Cells[6].Text = "系统取消";
                    e.Row.Cells[7].Text = " --- ";
                }
                else
                {
                    if (chargeModel.Type == 0)
                    {
                        LinkButton lbtnCancel = new LinkButton();
                        if (chargeModel.State == 0)
                        {
                            if (chargeModel.IsPay == 1)
                            {
                                e.Row.Cells[6].Text = "已付款，等待验证";
                            }
                            
                            if (type == "0")
                            {
                                HyperLink hlWSZF = new HyperLink();
                                Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
                                string SelectAddress = payTypeBll.GetModel(int.Parse(payTypeID)).SelectAddress;
                                hlWSZF.Text = "网上支付";
                                hlWSZF.NavigateUrl = "OnlinePay.aspx?OrderID=" + orderID + "";
                                hlWSZF.Target = "top";
                                e.Row.Cells[7].Controls.Add(hlWSZF);
                                Label lblFG = new Label();
                                lblFG.Text = "&nbsp;|&nbsp;";
                                e.Row.Cells[7].Controls.Add(lblFG);
                            }
                            else
                            {
                                HyperLink hlWSZF = new HyperLink();
                                hlWSZF.Text = "银行转账";
                                hlWSZF.NavigateUrl = "BankTransferCZ.aspx?OrderID=" + orderID + "";
                                hlWSZF.Target = "top";
                                e.Row.Cells[7].Controls.Add(hlWSZF);
                                Label lblFG = new Label();
                                lblFG.Text = "&nbsp;|&nbsp;";
                                e.Row.Cells[7].Controls.Add(lblFG);

                                HyperLink hlQRFK = new HyperLink();
                                hlQRFK.Text = "确认付款";
                                hlQRFK.NavigateUrl = "MoneyLog_Edit.aspx?OrderID=" + orderID + "";
                                hlQRFK.Target = "top";
                                e.Row.Cells[7].Controls.Add(hlQRFK);

                                Label lblFG1 = new Label();                             
                                lblFG1.Text = "&nbsp;|&nbsp;"; 
                                e.Row.Cells[7].Controls.Add(lblFG1);
                            }

                            lbtnCancel.Text = "取消";
                            lbtnCancel.CommandArgument = orderID;
                            lbtnCancel.OnClientClick = "return confirm('您确定要取消该该订单？')";
                            lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
                            e.Row.Cells[7].Controls.Add(lbtnCancel);
                        }
                        else
                        {
                            e.Row.Cells[7].Text = " --- ";
                        }
                    }
                    else
                    {
                        if (chargeModel.State == 0)
                        {
                            LinkButton lbtnCancel = new LinkButton();
                            lbtnCancel.Text = "取消";
                            lbtnCancel.CommandArgument = orderID;
                            lbtnCancel.OnClientClick = "return confirm('您确定要取消该该订单？')";
                            lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
                            e.Row.Cells[7].Controls.Add(lbtnCancel);
                        }
                        else
                        {                         
                            e.Row.Cells[7].Text = " --- ";
                        }
                        
                    }
                }
            } 
        }


        protected void lbtnCancel_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbtnCancel = (LinkButton)sender;
            if (lbtnCancel.Text == "取消")
            {
                Pbzx.BLL.PBnet_Charge chargeBll = new Pbzx.BLL.PBnet_Charge();
                Pbzx.Model.PBnet_Charge chargeModel = chargeBll.GetModelByOrderId(e.CommandArgument.ToString());
                if(chargeModel.Type == 1)
                {
                    Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
                    Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(chargeModel.UserName);
                    if (UsModel != null)
                    {
                        if (UsModel.FrozenMoney >= chargeModel.PayMoney)
                        {
                            UsModel.FrozenMoney -= chargeModel.PayMoney;
                        }
                        else
                        {
                            throw new Exception("用户冻结余额发生异常！");
                        }
                        UsBll.Update(UsModel);
                    }
                }
                DbHelperSQL.ExecuteSql(" update  PBnet_Charge set IsCancel=1,Result='订单已经取消' where OrderID='" + e.CommandArgument.ToString() + "'   ");
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        protected string GetLinkUrl(object  type ,object id,object orderID)
        { 
            if(type.ToString()=="0")
            {
                return "<a href='/UserCenter/MoneyLog_Edit.aspx?OrderID=" + orderID + "' target='_blank'>" + orderID + "</a>";
            }
            else
            {
                return "<a href='/UserCenter/MoneyLog_EditQK.aspx?OrderID=" + orderID + "' target='_blank'>" + orderID + "</a>";
            }
            
                                        
        }
    }
}
