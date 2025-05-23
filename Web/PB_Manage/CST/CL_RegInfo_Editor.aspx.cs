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
    public partial class CL_RegInfo_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CL_RegisterInfo MyBLL = new Pbzx.BLL.CL_RegisterInfo();
                Pbzx.Model.CL_RegisterInfo Myinfo;
                string str = Request.QueryString["ID"];
                Myinfo = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblId.Text = Myinfo.ID.ToString();

                int softType = Myinfo.SoftwareType;
                int InstallType = Myinfo.InstallType;

                this.lblSoftwareType.Text = ChkSoftType(softType, InstallType).ToString();
                this.lblSNs.Text = Myinfo.SNs;

                this.lblCreateTime.Text = Myinfo.CreateTime.ToString();
                this.lblOperator.Text = Myinfo.Operator;


                this.lblRegisterType.Text = GetRegisterType(Myinfo);
              
                this.lblAgentName.Text = Myinfo.AgentName;
                this.lblCardInfo.Text = Myinfo.CardInfo.ToString();
                this.txtUserName.Text = Myinfo.UserName;

                this.txtPayType.Text = Myinfo.PayType;
                this.txtPayMoney.Text = Myinfo.PayMoney.ToString();
                this.rblPayStatus.SelectedValue = Myinfo.PayStatus.ToString();

                this.txtPayTime.Text = Myinfo.PayTime.ToString();
                this.txtPayDetails.Text = Myinfo.PayDetails;
                this.txtUserEmail.Text = Myinfo.UserEmail;

                this.txtUserTel.Text = Myinfo.UserTel;
                this.txtUserAddress.Text = Myinfo.UserAddress;
                this.txtRemarks.Text = Myinfo.Remarks;

            }
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return result[0] + "(" + result[1] + ")";
        }

        private  string GetRegisterType(Pbzx.Model.CL_RegisterInfo Myinfo)
        {
            string Type = "";
            switch (Myinfo.RegisterType)
            {
                case 1:
                    Type = "公司注册";
                    break;
                case 2:
                    Type = "<font color=003399>" + Myinfo.AgentName + "</font>";
                    break;
                case 3:
                    Type = "<font color=66cc00>" + Myinfo.CardInfo.Substring(0,10) + "</font>";
                    break;
                default:
                    Type = "其他";
                    break;
            }
            return Type;
        }
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            if (!OperateText.IsNumber(this.txtPayMoney.Text))
            {
                strErrMsg += "付费金额不是数字.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtUserTel.Text))
            {
                strErrMsg += "客户电话不是数字.\\r\\n";
            }
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(this.txtPayTime.Text.Trim(), out dt))
            {
                strErrMsg += "付费时间数据格式不正确.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.BLL.CL_RegisterInfo MyBLL = new Pbzx.BLL.CL_RegisterInfo();
            Pbzx.Model.CL_RegisterInfo MyInfo;
            string str = Request.QueryString["ID"];
            MyInfo = MyBLL.GetModel(Convert.ToInt32(str));

            MyInfo.UserName = this.txtUserName.Text;
            MyInfo.PayType = this.txtPayType.Text;
            MyInfo.PayMoney =int.Parse(this.txtPayMoney.Text);
            MyInfo.PayStatus = int.Parse(this.rblPayStatus.SelectedValue);
            MyInfo.PayTime =DateTime.Parse(this.txtPayTime.Text);
            MyInfo.PayDetails = this.txtPayDetails.Text;
            MyInfo.UserEmail = this.txtUserEmail.Text;
            MyInfo.UserTel = this.txtUserTel.Text;
            MyInfo.UserAddress = this.txtUserAddress.Text;
            MyInfo.Remarks = this.txtRemarks.Text;
            if (MyBLL.Update(MyInfo))
            {
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改打印注册信息[客户名：" + this.txtUserName.Text + "]");
                Response.Write("<script>window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
             
            }
            else 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }
        }
    }
}
