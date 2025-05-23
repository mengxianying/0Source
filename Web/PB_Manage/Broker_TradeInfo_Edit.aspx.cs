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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class Broker_TradeInfo_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_broker_TradeInfo MyBLL = new Pbzx.BLL.PBnet_broker_TradeInfo();
                Pbzx.Model.PBnet_broker_TradeInfo MyModel;

                string str = Request["ID"];
                MyModel = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblBrokerName.Text = MyModel.BrokerName;
                this.lblCustomerName.Text = MyModel.CustomerName;
                this.lblOrderID.Text = MyModel.OrderID;

                this.lblCreateTime.Text = MyModel.CreateTime.ToString();
                this.lblBrokerIncome.Text = Convert.ToDecimal(MyModel.BrokerIncome).ToString("0.00");
                this.lblCustomerPay.Text = Convert.ToDecimal(MyModel.CustomerPay).ToString("0.00");
                this.lblRegManager.Text = MyModel.RegManager;
                this.txtRemark.Text = MyModel.Remark;

                if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(UserName) from PBnet_UserTable where UserName='" + MyModel.BrokerName + "'")) < 1)
                {
                    this.really.Visible = false;
                }
                else
                {
                    this.really.Visible = true;
                    Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                    Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(MyModel.BrokerName);

                    lblRealName.Text = userModel.RealName;
                    lblSex.Text = Convert.ToBoolean(userModel.Sex) ? "男" : "女";
                    lblCardID.Text = userModel.CardID;

                    lblBirthday.Text = userModel.Birthday.ToString();
                    lblTelphone.Text = userModel.Telphone;
                    lblEmail.Text = userModel.Email;

                    lblMobile.Text = userModel.Mobile;
                    lblQQ.Text = userModel.QQ;
                    lblProvince.Text = userModel.Province;

                    lblMSN.Text = userModel.MSN;
                    lblCity.Text = userModel.City;
                    lblPostCode.Text = userModel.PostCode;
                    lblAddress.Text = userModel.Address;

                    lblAccountNumber.Text = userModel.AccountNumber;
                    lblBankName.Text = userModel.BankName;
                    lblBankInfo.Text = userModel.BankInfo;
                }
                

            
        }        
      }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_broker_TradeInfo MyBLL = new Pbzx.BLL.PBnet_broker_TradeInfo();
            Pbzx.Model.PBnet_broker_TradeInfo MyModel;
            string str = Request["ID"];
            MyModel = MyBLL.GetModel(Convert.ToInt32(str));

            MyModel.Remark = this.txtRemark.Text;

            if (MyBLL.Update(MyModel))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改经纪人[" + this.lblBrokerName.Text + "]交易备注");
                //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }

        }

    }
}
