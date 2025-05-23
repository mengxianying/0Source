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

namespace Pbzx.Web.UserCenter
{
    public partial class LyBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_LyType typeBll = new Pbzx.BLL.PBnet_LyType();
                this.ddlSort.DataSource = typeBll.GetList(" IsAuditing=1 order by OrderID ");
                this.ddlSort.DataTextField = "TypeName";
                this.ddlSort.DataValueField = "ID";
                this.ddlSort.DataBind();
            }
        }

        protected void bton_Click(object sender, ImageClickEventArgs e)
        {
            string strErrMsg = "";
            if (txtEmail.Text.Trim() == "")
            {
                strErrMsg += "���Ա��ⲻ��Ϊ��.\\r\\n";
            }
            if (txtcontent.Text.Trim() == "")
            {
                strErrMsg += "�������ݲ���λ��.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.BLL.PBnet_LyBook MyBll = new Pbzx.BLL.PBnet_LyBook();
                Pbzx.Model.PBnet_LyBook MyModel = new Pbzx.Model.PBnet_LyBook();

                MyModel.LyUserName = Method.Get_UserName.ToString();
                MyModel.Ly_Email = Input.FilterHTML(this.txtEmail.Text);
                MyModel.LySort = int.Parse(this.ddlSort.SelectedValue);
                MyModel.LyContent = Input.FilterHTML(this.txtcontent.Text);
                MyModel.LyLogTime = DateTime.Now;
                MyModel.LyState = 0;
                if (MyBll.Add(MyModel))
                {
                    Response.Write("<script>alert('���Գɹ���');window.returnValue='aaa';self.close();</script>");
                   // Response.Write(" onload="if(window!=top)parent.location.reload()" ");
                   // Response.Redirect("LyBookDisp.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("����ʧ��."));
                }
            }
        }

        protected void btreset_Click(object sender, ImageClickEventArgs e)
        {
            this.txtEmail.Text = "";
            this.txtcontent.Text = "";
        }
    }
}
