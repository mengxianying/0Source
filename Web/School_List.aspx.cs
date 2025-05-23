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

namespace Pbzx.Web
{
    public partial class School_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
             
                BindData();

            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_School MyBLL = new Pbzx.BLL.PBnet_School();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1");
            bu.Append(this.AddParameter());

            if (!string.IsNullOrEmpty(Request["type"]))
            {
                int temp = 0;
                if (!int.TryParse(Request["type"], out temp))
                {
                    Response.Write("<script>alert('�벻Ҫ����url����');top.location='/Error.htm';</script>");
                    return;
                }
                Pbzx.BLL.PBnet_SchoolType schoolTypeBll = new Pbzx.BLL.PBnet_SchoolType();
                Pbzx.Model.PBnet_SchoolType typeModel = schoolTypeBll.GetModel(Convert.ToInt32(Input.FilterAll(Request["type"])));
                if (typeModel != null)
                {
                    lblType.Text += " >> " + typeModel.VarTypeName + "";
                }
                bu.Append(" and IntShowType ='" + Input.FilterAll(Request["type"]) + "' ");
            }
       
            bu.Append(" and IntChannelID=9");
            bu.Append(" and BitIsPass=1");
            string Searchstr = bu.ToString();
            string order = " BitIsTop desc,DatDateAndTime desc ";
            int mycount = 0;
            DataTable IsResult = MyBLL.GuestGetBySearch(Searchstr, "*", order, int.Parse(WebInit.pageConfig.ScholCenterList), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.RptList.DataSource = IsResult;
            this.RptList.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
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
            AspNetPager1.PageSize = int.Parse(WebInit.pageConfig.ScholCenterList);
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            //AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + RptList.Items.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
          StringBuilder bu1 = new StringBuilder();

          if (!string.IsNullOrEmpty(Request["Search"]))
          {
              bu1.Append(" and NvarTitle like '%" + Input.FilterAll(Request["Search"]) + "%'");
          }
           return bu1.ToString();
        }

    }
}
