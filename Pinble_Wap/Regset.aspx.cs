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

namespace Pinble_Wap
{
    public partial class Regset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["msg"] != null)
                {
                    switch (Request.QueryString["msg"])
                    {
                        case "1":
                            labtext.Text = "���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�";
                            break;
                        case "2":
                            labtext.Text = "����ʧ�ܣ�";
                            break;
                        case "3":
                            labtext.Text = "���ʧ�ܣ�";
                            break;
                        case "4":
                            labtext.Text = "��ӳɹ���";
                            break;
                        case "5":
                            labtext.Text = "���³ɹ���";
                            break;
                        case "6":
                            labtext.Text = "�Բ��𣡴��������֧�֣�";
                            break;
                    }

                }
            }
        }

        protected void lnkbut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                if (Request.QueryString["msg"] != "6")
                {
                    Response.Redirect("Manage/List3DManage.aspx");
                    return;
                }

            }
            Response.Redirect("http://www.pinble.com");
        }
    }
}
