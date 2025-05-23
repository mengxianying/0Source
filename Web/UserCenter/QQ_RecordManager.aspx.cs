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
    public partial class QQ_RecordManager : System.Web.UI.Page
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
                    this.lblQQGroupLink.Text = "<a href='QQ_GroupManager.aspx'>QQȺ����</a>";
                }
                else
                {
                    this.lblQQGroupLink.Text = "";
                }
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "AddTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
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

            if (!string.IsNullOrEmpty(Request["QQ_ID"]))
            {
                bu.Append(" and QQ_ID like '%" + Input.FilterAll(Request["QQ_ID"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                bu.Append(" and UserName like '%" + Input.FilterAll(Request["UserName"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["OnlineState"]))
            {
                bu.Append(" and OnlineState='" + Input.FilterAll(Request["OnlineState"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["GropID"]))
            {
                bu.Append(" and QQ_GropID='" + Input.FilterAll(Request["GropID"]) + "' ");
                //lblGroup.Text = WebFunc.GetGroupByID(Input.FilterAll(Request["GropID"])).QQ_GroupName;
            }
  
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            
            Pbzx.BLL.PBnet_QQ_Record PBnet_QQ_RecordBLL = new Pbzx.BLL.PBnet_QQ_Record();
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

            DataTable lsResult = PBnet_QQ_RecordBLL.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }

        //protected void gvOrderList_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string ID = gvOrderList.DataKeys[e.Row.RowIndex].Values["ID"].ToString();
        //        string QQ_GropID = gvOrderList.DataKeys[e.Row.RowIndex].Values["QQ_GropID"].ToString();
        //        string OnlineState = gvOrderList.DataKeys[e.Row.RowIndex].Values["OnlineState"].ToString();

        //        bool IsHavePower  = WebFunc.CheckIsGroupManager(WebFunc.GetGroupByID(QQ_GropID).QQ_GroupAdmin);

        //        LinkButton lbtnCancel = new LinkButton();
        //        if (!IsHavePower)
        //        {
        //            HyperLink hlWSZF = new HyperLink();
        //            Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
        //            string SelectAddress = payTypeBll.GetModel(int.Parse(payTypeID)).SelectAddress;
        //            hlWSZF.Text = "�鿴";
        //            hlWSZF.NavigateUrl = "QQ_RecordEdite.aspx?ID=" + ID + "";
        //            hlWSZF.Target = "top";
        //            e.Row.Cells[8].Controls.Add(hlWSZF);
        //        }
        //        else
        //        {
        //            HyperLink hlWSZF = new HyperLink();
        //            Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
        //            string SelectAddress = payTypeBll.GetModel(int.Parse(payTypeID)).SelectAddress;
        //            hlWSZF.Text = "�鿴";
        //            hlWSZF.NavigateUrl = "QQ_RecordEdite.aspx?ID=" + ID + "";
        //            hlWSZF.Target = "top";
        //            e.Row.Cells[8].Controls.Add(hlWSZF);
        //            Label lblFG = new Label();
        //            lblFG.Text = "&nbsp;|&nbsp;";
        //            e.Row.Cells[8].Controls.Add(lblFG);

        //            lbtnCancel.Text = "�߳�";
        //            lbtnCancel.CommandArgument = orderID;
        //            lbtnCancel.OnClientClick = "return confirm('��ȷ��Ҫ�߳����û���')";
        //            lbtnCancel.Command += new CommandEventHandler(lbtnCancel_Command);
        //            e.Row.Cells[8].Controls.Add(lbtnCancel);
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
