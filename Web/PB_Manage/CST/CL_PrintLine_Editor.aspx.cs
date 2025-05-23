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
    public partial class CL_PrintLine_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CL_PrintLine MyBLL = new Pbzx.BLL.CL_PrintLine();
                Pbzx.Model.CL_PrintLine Myline;

                string str = Request.QueryString["ID"];
                Myline = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblSN.Text = Myline.SN;
                this.lblAcceptTime.Text = Myline.AcceptTime.ToString();
                this.lblCreateTime.Text = Myline.CreateTime.ToString();

                this.lblAccepter.Text = Myline.Accepter;
                this.lblCreator.Text = Myline.Creator;

                this.lblSellTime.Text = Myline.SellTime.ToString();
                this.ddlStatus.SelectedValue = Myline.Status.ToString();

                this.lblSeller.Text = Myline.Seller;

                this.lblType.Text = GetType(Myline.Type.ToString());
                this.txtRemarks.Text = Myline.Remarks;

            }
        }
        public static string GetType(object num)
        {
            string Type = "";
            int intNum = int.Parse(num.ToString());
            switch (intNum)
            { 
            case 0:
                    Type="<font color='#999999'>未定</font>";
                    break;
                case 1:
                    Type = "<font color='#0000ff'>USB</font>";
                    break;
                case 2:
                    Type = "COM";
                    break;
                default:
                    Type = "其他";
                    break;
            }
            return Type;
        }
        
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CL_PrintLine MyBLL = new Pbzx.BLL.CL_PrintLine();
            Pbzx.Model.CL_PrintLine Myline;

            string str = Request.QueryString["ID"];
            Myline = MyBLL.GetModel(Convert.ToInt32(str));


            Myline.Status = int.Parse(this.ddlStatus.SelectedValue);
            Myline.Remarks = this.txtRemarks.Text;
            if (MyBLL.Update(Myline))
            {
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改打印线信息[序列号：" + this.lblSN.Text + "]");
                Response.Write("<script>window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("CL_PrintLine_Manage.aspx");
        }
    }
}
