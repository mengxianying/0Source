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
    public partial class Broker_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                   BindRate();
                   this.txtCreateTime.Text = DateTime.Now.ToString();
                   BindGrade();
                   BindData();


            }              
        }
        private void BindGrade()
        {
            Pbzx.BLL.PBnet_broker_Config CfBLL = new Pbzx.BLL.PBnet_broker_Config();
            CfBLL.BindGrade(this.ddlgrade);         
        }
        private void BindRate()
        {
            Pbzx.BLL.PBnet_broker_Config CfBLL = new Pbzx.BLL.PBnet_broker_Config();
            CfBLL.BindRate(this.ddlrate);
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_broker MyBLL = new Pbzx.BLL.PBnet_broker();
            Pbzx.Model.PBnet_broker MyModel;

            string str = Request.QueryString["ID"];
            
            if(!string.IsNullOrEmpty(str))
            {
                MyModel = MyBLL.GetModel(Convert.ToInt32(str));
                this.lblUserName.Text = MyModel.UserName;
                this.lblApply_time.Text = MyModel.Apply_time.ToString();
                if (string.IsNullOrEmpty(MyModel.Pass_time.ToString()))
                {
                    this.txtCreateTime.Text = DateTime.Now.ToString();
                }
                else
                {
                    this.txtCreateTime.Text = MyModel.Pass_time.ToString();
                }

                this.lblLastLogin_time.Text = MyModel.LastLogin_time.ToString();
                this.lblYear_tradeMoney.Text = ((decimal)MyModel.Year_tradeMoney).ToString("0.00") + "元";
                this.lblYear_incomeMoney.Text = ((decimal)MyModel.Year_incomeMoney).ToString("0.00") + "元";

                this.lblTotal_tradeMoney.Text = ((decimal)MyModel.Total_tradeMoney).ToString("0.00") + "元";
                this.lblTotal_incomeMoney.Text = ((decimal)MyModel.Total_incomeMoney).ToString("0.00") + "元";

                this.lblUserName.Text = MyModel.UserName;

                this.lblYearStart_time.Text = MyModel.YearStart_time.ToString();
                this.lblLastTrade_time.Text = MyModel.LastTrade_time.ToString();
                this.ddlgrade.SelectedValue = MyModel.Discount_gradeName.ToString();

                this.ddlrate.SelectedValue = MyModel.Discount_rate.ToString();
                this.ddlsate.SelectedValue = MyModel.State.ToString();
                if (string.IsNullOrEmpty(MyModel.Auditing_Manager))
                {
                    this.txtManager.Text = WebFunc.GetCurrentAdmin();
                }
                else
                {
                    this.txtManager.Text = MyModel.Auditing_Manager;
                }
                this.txtRemark.Text = MyModel.Remark;        
                //
            }

            if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(UserName) from PBnet_UserTable where UserName='" + lblUserName.Text + "'")) < 1)
            {
                this.really.Visible = false;
            }
            else
            {
                this.really.Visible = true;
                Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(lblUserName.Text);

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

        protected void btnUp_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_broker MyBLL = new Pbzx.BLL.PBnet_broker();
            Pbzx.Model.PBnet_broker MyModel;

            int intid = Convert.ToInt32(Request.QueryString["ID"]);
            if (intid > 0)
            {
                MyModel = MyBLL.GetModel(intid);
               string strState = MyModel.State.ToString();
               if (strState != "1")
               {
                   if (this.ddlsate.SelectedValue == "1")
                   {
                       MyModel.YearStart_time = DateTime.Parse(DateTime.Now.ToShortDateString());
                       MyModel.LastTrade_time = DateTime.Now;
                   }
               }
            }
            else
            {
                MyModel = new Pbzx.Model.PBnet_broker();
            }
            MyModel.Discount_gradeName =this.ddlgrade.SelectedValue;
            MyModel.Discount_rate = int.Parse(this.ddlrate.SelectedValue);
            MyModel.State = int.Parse(this.ddlsate.SelectedValue);
            MyModel.Auditing_Manager = this.txtManager.Text;
            MyModel.Remark = this.txtRemark.Text;
            MyModel.Pass_time = DateTime.Parse(Request["txtCreateTime"]);
            MyModel.YearStart_time = DateTime.Parse(Request["txtCreateTime"]);
            MyModel.LastTrade_time = DateTime.Parse(Request["txtCreateTime"]);

           
            if (intid > 0)
            {
                if (MyBLL.Update(MyModel))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改经纪人[" + this.lblUserName.Text + "]信息");
                    Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
                }
            }
            else {

                if (MyBLL.Add(MyModel))
                {
                    
                     ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Broker.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("添加失败."));
                }
            }
           
        }
    }
}
