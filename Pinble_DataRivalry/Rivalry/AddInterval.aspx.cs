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

namespace Pinble_DataRivalry.Rivalry
{
    public partial class AddInterval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                
            }
        }

        //ȡ��
        protected void btn_cnacel_Click(object sender, EventArgs e)
        {
            Response.Write("<script>history.go(-1)</script>");
            Response.End();
        }

        //��Ӷ�Ӧ��Χ
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_BenginRang.Text == "" || txt_EndRang.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(),"tip","<script>alert('����дһ����Χ')</script>");
            }
            else if (Convert.ToInt32(txt_BenginRang.Text) < 0 || Convert.ToInt32(txt_EndRang.Text) < 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(),"tip","<script>alert('����������')</script>");
            }
            else
            { 
                //���
            }
        }
    }
}
