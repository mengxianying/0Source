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

namespace Pbzx.Web.PB_Manage
{
    public partial class Transit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //��ֵ������ƽ̨
                if (Request["PageState"].ToString() == "help")
                {
                    //ȡ��cookie�б����ֵ
                    string url = System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
                    Response.Redirect("http://192.168.1.121:8013/pinbleHelp/HelpList.aspx?urlAddress=" + url);
                }
                //������Ʊ����
                if (Request["PageState"].ToString() == "Market")
                {
                    //ȡ��cookie�б����ֵ
                    string url = System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
                }
                //�����������ƽ̨
                if (Request["PageState"].ToString() == "Chipped")
                { 
                   //���������ƽ̨�ĵ�ַ
                }
            }
        }
    }
}
