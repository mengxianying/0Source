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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class CL_PrintLine_Hao : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CL_PrintLine MyBLL = new Pbzx.BLL.CL_PrintLine();
                Pbzx.Model.CL_PrintLine Myinfo;
                string str = Request.QueryString["ID"];
                Myinfo = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblSN.Text = Myinfo.SN.ToString();
                this.lblAcceptTime.Text = Myinfo.AcceptTime.ToString();
                this.lblCreateTime.Text = Myinfo.CreateTime.ToString();

                this.lblAccepter.Text = Myinfo.Accepter.ToString();
                this.lblCreator.Text = Myinfo.Creator.ToString();
                this.lblSellTime.Text = Myinfo.SellTime.ToString();

                this.ddlStatus.SelectedValue = Myinfo.Status.ToString();
                this.lblSeller.Text = Myinfo.Seller.ToString();
                this.lblType.Text = Myinfo.Type.ToString();
                this.txtRemarks.Text = Myinfo.Remarks.ToString();            

            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CL_PrintLine MyBLL = new Pbzx.BLL.CL_PrintLine();
            Pbzx.Model.CL_PrintLine Myinfo;          
            Myinfo = MyBLL.GetModel(Convert.ToInt32( Request.QueryString["ID"]));

            Myinfo.Status =int.Parse(this.ddlStatus.SelectedValue);
            Myinfo.Remarks =Input.FilterAll(this.txtRemarks.Text.Trim());

            if (MyBLL.Update(Myinfo))
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("CL_RegInfo_Manage.aspx"));
            }
            else 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("CL_RegInfo_Manage.aspx");
        }
    }
}
