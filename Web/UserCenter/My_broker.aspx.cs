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

namespace Pbzx.Web.UserCenter
{
    public partial class My_broker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='UserRealInfo.aspx';}</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {

            Pbzx.BLL.PBnet_broker_TradeInfo MyBll = new Pbzx.BLL.PBnet_broker_TradeInfo();
            StringBuilder bu = new StringBuilder();
            string name = Method.Get_UserName;
            Pbzx.BLL.PBnet_broker brokerBll = new Pbzx.BLL.PBnet_broker();
            Pbzx.Model.PBnet_broker brokerModel = brokerBll.GetModelName(name);
            if (brokerModel != null && brokerModel.State == 1)
            {               
            }
            else
            {
                Response.Redirect("userManage.aspx");
                return;
            }
            string rebate = (100 - brokerModel.Discount_rate).ToString();
            this.lblgrade.Text = "�ҵľ��͵ȼ���" + brokerModel.Discount_gradeName + "���ҵ�Ӷ������׼Ϊ������ۿ�ģ�" + rebate + "%��";
            this.lblMoney.Text = "ͳ����Ϣ���ܽ��׶" + Math.Round((decimal)brokerModel.Total_tradeMoney,2) + "Ԫ����������"+ Math.Round((decimal)brokerModel.Total_incomeMoney,2) + "Ԫ����&nbsp;&nbsp;&nbsp;&nbsp;����Ƚ��׶" +Math.Round((decimal)brokerModel.Year_tradeMoney,2) + "Ԫ������������" + Math.Round((decimal)brokerModel.Year_incomeMoney,2) + "Ԫ��";          
            bu.Append(" 1=1");
            bu.Append(" and BrokerName='" + name + "'");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "CreateTime desc ";
            int myCount = 0;
            DataTable lsResult = MyBll.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);
            //if(lsResult.Rows.Count == 0)
            //{
            //    lsResult.Rows.InsertAt(lsResult.NewRow(), 0);
            //}
            this.GridView1.DataSource = lsResult;
            this.GridView1.DataBind();
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
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>����¼&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + GridView1.Rows.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                //if (!string.IsNullOrEmpty(e.Row.Cells[1].Text))
                //{
                    e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
               // }               
            }
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            return softBLL.Chksofttype(num) + softBLL.Chksettype(num, st);
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            if (!string.IsNullOrEmpty(Input.FilterAll(Request["strBrokerName"])))
            {
                bu1.Append(" and CustomerName like '%" + Input.FilterAll(Request["strBrokerName"]) + "%'");
            }
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["dateType"])))
            {               
                bu1.Append(" and CreateTime between '" + Input.FilterAll(Request["strCreateTime1"].Trim()) + "' and '" + DateTime.Parse(Input.FilterAll(Request["strCreateTime2"])).AddDays(1).ToShortDateString() + "'  ");
            }
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["strOrderID"])))
            {
                bu1.Append(" and OrderID='" + Input.FilterAll(Request["strOrderID"]) + "'");
            }
            return bu1.ToString();
        }
    }
}
