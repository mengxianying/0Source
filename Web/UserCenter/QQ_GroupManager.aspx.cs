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

namespace Pbzx.Web.UserCenter
{
    public partial class QQ_GroupManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataRow row = WebFunc.GetQQLookUser();
                if (row == null)
                {
                    Response.Write(JS.Alert("�Բ�����û�з���Ȩ�ޣ�", "User_Center.aspx"));
                    return;
                }

                if (row["UserClass"].ToString() == "����Ա" || row["UserClass"].ToString() == "��������")
                {                   
                }
                else
                {
                    Response.Write(JS.Alert("�Բ�����û�з���Ȩ�ޣ�", "User_Center.aspx"));
                    return;
                }

                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "SortID";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = false;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
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
            AspNetPager1.CustomInfoHTML = "�ܼ�:<font color=\"blue\">" + AspNetPager1.RecordCount.ToString() + "</font>��&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\">" + gvOrderList.Rows.Count + "</font>��&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\">" + AspNetPager1.CurrentPageIndex.ToString() + "/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["GroupID"]))
            {
                bu.Append(" and QQ_GroupID like'%" + Input.FilterAll(Request["GroupID"])+ "%' ");
            }
            if (!string.IsNullOrEmpty(Request["GroupName"]))
            {
                bu.Append(" and QQ_GroupName like'%" + Input.FilterAll(Request["GroupName"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["GroupType"]))
            {
                bu.Append(" and QQ_GroupType='" + Input.FilterAll(Request["GroupType"]) + "' ");
            }

            if (!string.IsNullOrEmpty(Request["QQ_GroupAdmin"]))
            {
                bu.Append(" and QQ_GroupAdmin='" + Input.FilterAll(Request["QQ_GroupAdmin"]) + "' ");
            }

            if (!string.IsNullOrEmpty(Request["IsSoftGroup"]))
            {
                bu.Append(" and IsSoftGroup='" + Input.FilterAll(Request["IsSoftGroup"]) + "' ");
            } 
            

            
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_QQ_Group PBnet_QQ_GroupBLL = new Pbzx.BLL.PBnet_QQ_Group();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
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


            DataTable lsResult = PBnet_QQ_GroupBLL.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.gvOrderList.DataSource = lsResult;
            this.gvOrderList.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }

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

        //protected void gvOrderList_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string orderID = gvOrderList.DataKeys[e.Row.RowIndex].Values["OrderID"].ToString();
        //        string payTypeID = gvOrderList.DataKeys[e.Row.RowIndex].Values["PayTypeID"].ToString();
        //        string payTypeName = gvOrderList.DataKeys[e.Row.RowIndex].Values["PayTypeName"].ToString();
        //        string type = gvOrderList.DataKeys[e.Row.RowIndex].Values["Type"].ToString();
        //        string isCancel = gvOrderList.DataKeys[e.Row.RowIndex].Values["IsCancel"].ToString();
        //        Pbzx.BLL.PBnet_Orders ordersBll = new Pbzx.BLL.PBnet_Orders();
        //        Pbzx.Model.PBnet_Orders orderModel = ordersBll.GetModel(orderID);


        //        if (Convert.ToBoolean(isCancel))
        //        {
        //            e.Row.Cells[5].Text = "��ȡ��";
        //            e.Row.Cells[8].Text = " --- ";
        //        }
        //        else
        //        {
        //            LinkButton lbtnCancel = new LinkButton();
        //            if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ�����)
        //            {
        //                if (orderModel.IsPay == 1)
        //                {
        //                    e.Row.Cells[5].Text = "�Ѹ���ȴ���֤";
        //                    e.Row.Cells[8].Text = " --- ";
        //                }
        //                else
        //                {
        //                    string strWSZF = "";
        //                    if (type == "0")
        //                    {
        //                        HyperLink hlWSZF = new HyperLink();
        //                        Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
        //                        string SelectAddress = payTypeBll.GetModel(int.Parse(payTypeID)).SelectAddress;
        //                        hlWSZF.Text = "����֧��";
        //                        hlWSZF.NavigateUrl = "OnlinePay.aspx?OrderID=" + orderID + "";
        //                        hlWSZF.Target = "top";
        //                        e.Row.Cells[8].Controls.Add(hlWSZF);
        //                        Label lblFG = new Label();
        //                        lblFG.Text = "&nbsp;|&nbsp;";
        //                        e.Row.Cells[8].Controls.Add(lblFG);
        //                    }
        //                    else
        //                    {
        //                        HyperLink hlWSZF = new HyperLink();
        //                        Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
        //                        string SelectAddress = payTypeBll.GetModel(int.Parse(payTypeID)).SelectAddress;
        //                        hlWSZF.Text = "����ת��";
        //                        hlWSZF.NavigateUrl = "BankTransfer.aspx?OrderID=" + orderID + "";
        //                        hlWSZF.Target = "top";
        //                        e.Row.Cells[8].Controls.Add(hlWSZF);
        //                        Label lblFG = new Label();
        //                        lblFG.Text = "&nbsp;|&nbsp;";
        //                        e.Row.Cells[8].Controls.Add(lblFG);
        //                    }
        //                    lbtnCancel.Text = "ȡ��";
        //                    lbtnCancel.CommandArgument = orderID;
        //                    lbtnCancel.OnClientClick = "return confirm('��ȷ��Ҫȡ���ö�����')";
        //                    lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
        //                    e.Row.Cells[8].Controls.Add(lbtnCancel);
        //                }
        //            }
        //            else if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ѿ�ͨ)
        //            {
        //                lbtnCancel.Text = "�������ȷ��";
        //                lbtnCancel.CommandArgument = orderID;
        //                lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
        //                e.Row.Cells[8].Controls.Add(lbtnCancel);//
        //            }
        //            else
        //            {
        //                e.Row.Cells[8].Text = " --- ";
        //            }
        //        }
        //    }
        //}



        protected void gvOrderList_Sorting(object sender, GridViewSortEventArgs e)
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
