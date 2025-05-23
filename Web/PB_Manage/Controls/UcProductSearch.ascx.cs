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

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcProductSearch : System.Web.UI.UserControl
    {
        private string _url = "Soft_Manage.aspx";

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClass();
                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                Method.BindText(txtSoftName, "softName", true);
                Method.BindDdlOrRadio(this.ddlSoftClass, "softClass", true);
                Method.BindDdlOrRadio(this.ddlSoftVersion, "SoftVersion", true);

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        private void BindClass()
        {
            Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();
            if (Url == "Soft_Manage.aspx")
            {
                softClassBLL.BindSoftClass(this.ddlSoftClass, 1);
                this.ddlSoftClass.Items.Insert(0, new ListItem("所有", ""));
            }
            else
            {
                softClassBLL.BindSoftClass(this.ddlSoftClass, 0);
                this.ddlSoftClass.Items.Insert(0, new ListItem("所有", ""));
            }

            // Pbzx.Common.Method.BindProductVersionByEnum(ref this.ddlSoftVersion);
            //  this.ddlSoftVersion.Items.Insert(0,new ListItem("所有",""));

            //绑定软件版本类别
            WebFunc.BindDropdownOrList(this.ddlSoftVersion, "PBnet_ProductVersion", "ProductVersionName", "ProductVersionName");
            this.ddlSoftVersion.Items.Insert(0, new ListItem("所有", ""));
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder();

            bu.Append(Method.BindText(txtSoftName, "softName", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlSoftClass, "softClass", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlSoftVersion, "SoftVersion", false));

            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            Response.Redirect(_url + "?" + bu.ToString(), true);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect(_url);
        }


    }
}