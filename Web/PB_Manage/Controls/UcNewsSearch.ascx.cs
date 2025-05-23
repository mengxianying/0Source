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

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcNewsSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClass();
                if (!string.IsNullOrEmpty(Request["IntChannelID"]))
                {
                    this.ddlChannel.SelectedValue = Request["IntChannelID"];
                }
                if (!string.IsNullOrEmpty(Request["NvarTitle"]))
                {
                    this.txtNvarTitle.Text = Request["NvarTitle"];
                }
                if (!string.IsNullOrEmpty(Request["IntShowType"]))
                {
                    this.ddlIntShowType.SelectedValue = Request["IntShowType"];
                }
                if (!string.IsNullOrEmpty(Request["regedit"]))
                {
                    this.ddlTime.SelectedValue = Request["regedit"];
                }
                if (!string.IsNullOrEmpty(Request["BitIsPass"]))
                {
                    this.ddlrelease.SelectedValue = Request["BitIsPass"];
                }
                if (!string.IsNullOrEmpty(Request["ShowIndex"]))
                {
                    this.ddlAccording.SelectedValue = Request["ShowIndex"];
                }
                

            }
        }

        private void BindClass()
        {
            Pbzx.BLL.PBnet_NewsType newTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            newTypeBLL.BindNewsType(this.ddlIntShowType, 0);
            this.ddlIntShowType.Items.Insert(0, new ListItem("所有", "所有"));

            Pbzx.BLL.PBnet_Channel channelBLL = new Pbzx.BLL.PBnet_Channel();
            channelBLL.BindChannelType(this.ddlChannel, 0);
            ddlChannel.Items.Insert(0, new ListItem("所有", ""));

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();
            bu1.Append("1=1");
            if (!string.IsNullOrEmpty(this.txtNvarTitle.Text))
            {
                bu1.Append("&NvarTitle=" + this.txtNvarTitle.Text);
            }
            if (this.ddlChannel.SelectedValue != "")
            {
                bu1.Append("&IntChannelID=" + this.ddlChannel.SelectedValue);
            }
            if (this.ddlIntShowType.SelectedValue != "所有")
            {
                bu1.Append("&IntShowType=" + this.ddlIntShowType.SelectedValue);
            }
            if (this.ddlTime.SelectedValue != "所有")
            {
                bu1.Append("&regedit=" + this.ddlTime.SelectedValue.Trim());
            }
            if (this.ddlAccording.SelectedValue != "所有")
            {
                bu1.Append("&ShowIndex=" + this.ddlAccording.SelectedValue.Trim());
            }
            if (this.ddlrelease.SelectedValue != "所有")
            {
                bu1.Append("&BitIsPass=" + this.ddlrelease.SelectedValue.Trim());
            }
            Response.Redirect("News_Manage.aspx?" + bu1.ToString(), true);
        }
    }
}