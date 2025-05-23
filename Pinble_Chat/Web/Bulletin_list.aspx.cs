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
    public partial class Bulletin_list : System.Web.UI.Page
    {
        public string Tonglan = "";
        public string TypeName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindClass();        
                ShowAllAd();
                if (!string.IsNullOrEmpty(Request["BitIsHot"]))
                {
                    lblTypeName.Text = "�ȵ��Ƽ�";
                }
                Bulletin_Hot1.Count = int.Parse(WebInit.pageConfig.BulletinNewUpdateCount);
                Bulletin_Hot2.Count = int.Parse(WebInit.pageConfig.BulletinNewHotCount);
                this.Title = lblTypeName.Text + "�б� - ��վ���� - ƴ�����߲���ͨ���";
            }
         }
        private void ShowAllAd()
        {
            Pbzx.BLL.PBnet_Adv AdBll = new Pbzx.BLL.PBnet_Adv();
            Pbzx.Model.PBnet_Adv AdModel_Tonglan = AdBll.GetModelName("����ͨ������1�У���1��");

            if ((AdModel_Tonglan.pb_ENDTime > DateTime.Now.Date) && AdModel_Tonglan.pb_IsSelected)
            {
                this.DIVTonglan.Visible = true;
                lblTonglan.Text += "<a href='" + AdModel_Tonglan.pb_SiteUrl + "' title='" + AdModel_Tonglan.pb_SiteName + "' target='_blank'>";
                lblTonglan.Text += "<img src='" + AdModel_Tonglan.pb_ImgUrl + "' width='" + AdModel_Tonglan.pb_ImgWidth + "' border='0' height='" + AdModel_Tonglan.pb_ImgHeight + "'>";
                lblTonglan.Text += "</a>";
            }
        }    
        private void BindClass()
        {
            Pbzx.BLL.PBnet_BulletinType TypeBll = new Pbzx.BLL.PBnet_BulletinType();
            Pbzx.Model.PBnet_BulletinType TypeModel;
            if (Request["NewsType"] != null)
            {
                TypeModel = TypeBll.GetModel(int.Parse(Input.FilterAll(Input.Decrypt(Request["NewsType"]))));
                lblTypeName.Text = TypeModel.VarTypeName;
            }
            else
            {
                lblTypeName.Text = "���¹���";
            }          
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Bulletin MyBLL = new Pbzx.BLL.PBnet_Bulletin();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            if (Request["ChannelID"] != null && Request["ChannelID"] != "")
            {
                bu.Append(" and IntChannelID=" + Input.FilterAll(Input.Decrypt(Request["ChannelID"]) + ""));
            }          
            bu.Append(" and BitIsPass=1");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "BitIsTop desc,datdateandtime desc ";

            int myCount = 0;

            DataTable lsResult = new Pbzx.BLL.PBnet_Bulletin().GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
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
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum2;
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
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["Title"]))
            {
                bu1.Append("NvarTitle like '% " + Input.FilterAll(Input.Decrypt(Request["Title"])) + " %'");
            }
            if (Request["NewsType"] != null)
            {

                bu1.Append(" and IntShowType=" + Input.FilterAll(Input.Decrypt(Request["NewsType"])) + " ");
            }
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
            if (Request["Search"] != null)
            {
                string result = Input.FilterAll(Input.Decrypt(Request["Search"]));
                if (result.Length > 0)
                {
                    bu1.Append(" and NvarTitle like '%" + result + "%' ");
                }
            }
            return bu1.ToString();
        }
    }
}
