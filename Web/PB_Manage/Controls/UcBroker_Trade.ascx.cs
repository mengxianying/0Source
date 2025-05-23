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
    public partial class UcBroker_Trade : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
              //  BindRate();

                //Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType", true); 
                //Method.BindDdlOrRadio(this.ddlInstallType, "installType", true);
                //if (!string.IsNullOrEmpty(Request["softwareType"]))
                //{
                //    Pbzx.Web.PB_Manage.CST.GetInstallType get = new Pbzx.Web.PB_Manage.CST.GetInstallType();
                //    string[] data = get.GetData(int.Parse(Request["softwareType"])).Split(new char[] { ',' });
                //    this.ddlInstallType.Items.Clear();
                //    foreach (string str in data)
                //    {
                //        string[] strSZ = str.Split(new char[] { '&' });
                //        this.ddlInstallType.Items.Add(new ListItem(strSZ[0], strSZ[1]));
                //    }
                //    this.ddlInstallType.Items.Insert(0, new ListItem("所有", ""));
                //}
                //if (!string.IsNullOrEmpty(Request["installType"]))
                //{
                //    this.ddlInstallType.SelectedValue = Request["installType"];
                //}
                Method.BindText(txtOrderID, "strOrderID", true);
                Method.BindText(txtBrokerName, "strBrokerName", true);
                Method.BindText(txtCustomerName, "strCustomerName", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
             //   Method.BindDdlOrRadio(this.ddlrate, "strrate", true);

            }
        }
        //private void BindRate()
        //{
        //    Pbzx.BLL.PBnet_broker_Config CfBLL = new Pbzx.BLL.PBnet_broker_Config();
        //    CfBLL.BindRate(this.ddlrate);
        //    ListItem item = new ListItem("所有", "");
        //    ddlrate.Items.Insert(0, item);
        //}
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            //bu1.Append(Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType", false));
            //if (!string.IsNullOrEmpty(Request.Form[this.ddlInstallType.UniqueID]))
            //{
            //    bu1.Append("&installType=" + Request.Form[this.ddlInstallType.UniqueID]);
            //}
            bu1.Append(Method.BindText(txtOrderID, "strOrderID", false));
            bu1.Append(Method.BindText(txtBrokerName, "strBrokerName", false));
            bu1.Append(Method.BindText(txtCustomerName, "strCustomerName", false));

             bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
             bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));

            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
          //  bu1.Append(Method.BindDdlOrRadio(this.ddlrate, "strrate", false));

            Response.Redirect("Broker_TradeInfo.aspx?" + bu1.ToString());
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Broker_TradeInfo.aspx");
        }
    }
}