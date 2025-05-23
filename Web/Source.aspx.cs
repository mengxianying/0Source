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

namespace Pbzx.Web
{
    public partial class Source : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageConfig pageConfig = WebInit.pageConfig;
                SourceTitle1.Count = Convert.ToInt32(pageConfig.Sourcelie);
                SourceTitle1.TilteLength = Convert.ToInt32(pageConfig.Sourcelegth);

                SourceTitle2.Count = Convert.ToInt32(pageConfig.Sourcecountlie);
                SourceTitle2.TilteLength = Convert.ToInt32(pageConfig.Sourcecountlegth);
                labzong.InnerText = pageConfig.Sourcecountlie;


                SourceTitle3.Count = Convert.ToInt32(pageConfig.SourceMlie);
                SourceTitle3.TilteLength = Convert.ToInt32(pageConfig.SourceMlegth);
                labyue.InnerText = pageConfig.SourceMlie;
                BindData();
                BindTop();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Soft MyBLL = new Pbzx.BLL.PBnet_Soft();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");//and pb_ClassID in(select IntClassID from  PBnet_SoftClass where IntSetting='1') 
            bu.Append(this.AddParameter());

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                bu.Append(" and pb_ClassID ='" + Input.FilterAll(Input.Decrypt(Request["id"])) + "' ");

                Pbzx.BLL.PBnet_SoftClass softClassBll = new Pbzx.BLL.PBnet_SoftClass();
                Pbzx.Model.PBnet_SoftClass softClassModel = softClassBll.GetModel(Convert.ToInt32(Input.FilterAll(Input.Decrypt(Request["id"]))));
                this.Title = softClassModel.NvarClassName + "_��Դ����_ƴ�����߲���ͨ���";
            }
            bu.Append(" and " + Method.soft + " ");
            string Searchstr = bu.ToString();
            string order = "pb_UpdateTime desc ";
            int mycount = 0;
            DataTable IsResult = new Pbzx.BLL.PBnet_Soft().GuestGetBySearch(Searchstr, "*", order, 10, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.Repeater1.DataSource = IsResult;
            this.Repeater1.DataBind();
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
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            //AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + Repeater1.Items.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["strType"]))
            {
                if (!string.IsNullOrEmpty(Request["strKey"]))
                {
                    if (Request["strType"] == "0")
                    {
                        bu1.Append(" and PBnet_SoftName like '%" + Input.FilterAll(Request["strKey"]) + "%'");
                    }
                    else if (Request["strType"] == "1")
                    {
                        bu1.Append(" and PBnet_SoftIntro like '%" + Input.FilterAll(Request["strKey"]) + "%'");
                    }
                }
            }

            return bu1.ToString();
        }
        public static string GetType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 1:
                    type = "��Ѱ�";
                    break;
                case 2:
                    type = "�����";
                    break;
                case 3:
                    type = "���ð�";
                    break;
                case 4:
                    type = "��ʾ��";
                    break;
                case 5:
                    type = "ע���";
                    break;
                case 6:
                    type = "�ƽ��";
                    break;
                case 7:
                    type = "���۰�";
                    break;
                case 8:
                    type = "OEM��";
                    break;

                default:
                    type = "��������";
                    break;
            }
            return type;
        }
        private void BindTop()
        {
            DataSet dsProduct = DbHelperSQL.Query("select top 4 * from PBnet_Soft where  " + Method.soft + " and pb_OnTop=1  order by pb_UpdateTime desc ");
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                this.tuijian.Visible = true;
            }
            this.dlProductTop.DataSource = dsProduct;
            this.dlProductTop.DataBind();
            //dlProductTop
        }
    }
}
