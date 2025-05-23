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
    public partial class School_Coutent_List : System.Web.UI.Page
    {
        public string TypeName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                BindClass();
                if (!string.IsNullOrEmpty(Request["BitIsHot"]))
                {
                    lblTypeName.Text = "�ȵ��Ƽ�";
                }
                this.Title = lblTypeName.Text + "�б�_���ѧԺ_ƴ�����߲���ͨ���";
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_School MyBLL = new Pbzx.BLL.PBnet_School();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            if (Request["NewsType"] != null && Request["NewsType"] != "")
            {
                bu.Append(" and IntShowType=" + Input.FilterAll(Input.Decrypt(Request["NewsType"]) + ""));
            }
            if (!string.IsNullOrEmpty(Request["Search"]))
            {
                string result = Input.FilterAll(Input.Decrypt(Request["Search"]));
                if (result.Length > 0)
                {
                    bu.Append(" and NvarTitle like '%" + result + "%' ");
                }
            }

            bu.Append(" and BitIsPass=1");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "BitIsTop desc,DatDateAndTime desc ";
            int myCount = 0;

            DataTable lsResult = new Pbzx.BLL.PBnet_School().GuestGetBySearch(Searchstr, "*", order, int.Parse(WebInit.pageConfig.ScholCenterList), 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.rpt_list.DataSource = lsResult;
            this.rpt_list.DataBind();
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
            AspNetPager1.PageSize = int.Parse(WebInit.pageConfig.ScholCenterList);
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            //AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + rpt_list.Items.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindClass()
        {
            Pbzx.BLL.PBnet_SchoolType TypeBll = new Pbzx.BLL.PBnet_SchoolType();
            Pbzx.Model.PBnet_SchoolType TypeModel;
            if (Request["NewsType"] != null)
            {
                TypeModel = TypeBll.GetModel(int.Parse(Input.FilterAll(Input.Decrypt(Request["NewsType"]))));
                 lblTypeName.Text  = TypeModel.VarTypeName;
            }
            else
            {
                lblTypeName.Text = "������Ϣ";
            }
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["BitIsHot"]))
            {
                if (Input.FilterAll(Input.Decrypt(Request["BitIsHot"])) == "1")
                {
                    bu1.Append(Method.CheckNewsHot(true));
                }
                else
                {
                    bu1.Append(Method.CheckNewsHot(false));
                }
            }
            if (Request["NewsType"] != null)
            {

                bu1.Append(" and IntShowType=" + Input.FilterAll(Input.Decrypt(Request["NewsType"])) + " ");
            }

            return bu1.ToString();
        }
    }
}
