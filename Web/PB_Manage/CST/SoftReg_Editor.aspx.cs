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
    public partial class SoftReg_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.RegisterInfo2 Info2BLL = new Pbzx.BLL.RegisterInfo2();
                Pbzx.Model.RegisterInfo2 MyInfo2;

                string str = Request.QueryString["ID"];
                MyInfo2 = Info2BLL.GetModel(Convert.ToInt32(str));

                this.lblHDSN.Text = MyInfo2.HDSN;
                this.lblRN.Text = MyInfo2.RN;

                this.lblSoftwaretype.Text = ChkSoftType2(MyInfo2.SoftwareType);
                this.lblInstallType.Text = ChkSoftType(MyInfo2.SoftwareType.ToString(),MyInfo2.InstallType.ToString());

                this.lblRegisterDate.Text = MyInfo2.RegisterDate.ToString();
                this.lblUserType.Text =BindGetUserType(MyInfo2.UserType);

                this.lblExpireDate.Text = MyInfo2.ExpireDate.ToString();
                this.lblUserType2.Text =BindGetUseType(MyInfo2.UserType);

                this.lblUpdateCount.Text = MyInfo2.UpdateCount.ToString();
                this.lblLastUpdateDate.Text = MyInfo2.LastUpdateDate.ToString();

                this.txtUserTel.Text = MyInfo2.UserTel;
                this.lblLastUpdateVersion.Text = MyInfo2.LastUpdateVersion;

                this.txtUserEmail.Text = MyInfo2.UserEmail;
                this.lblDD_Date.Text = MyInfo2.DD_Date.ToString();

                this.txtUserAddress.Text = MyInfo2.UserAddress;
                this.lblDD_Count.Text = MyInfo2.DD_Count.ToString();

                this.txtBBsID.Text = MyInfo2.BBsID;
                this.lblOperator.Text = MyInfo2.Operator;

                this.txtPayMoney.Text =MyInfo2.PayMoney.ToString();
                this.lblCardNo.Text = MyInfo2.CardNo;

                this.txtPayType.Text = MyInfo2.PayType;
                this.lblCardPassword.Text = MyInfo2.CardPassword;

                this.txtPayDetails.Text = MyInfo2.PayDetails;
                this.lblTimeType.Text = BindGetTimeType(MyInfo2.TimeType);

                this.txtAgentID.Text = MyInfo2.AgentID.ToString();
                this.lblOrgSN.Text = MyInfo2.OrgSN;

                this.txtAgentName.Text = MyInfo2.AgentName;
                this.lblOldSN.Text = MyInfo2.OldSN;
                this.txtRemarks.Text = MyInfo2.Remarks;
                this.rdlstatus.SelectedValue = MyInfo2.Status.ToString();
                this.rdlIsReh.SelectedValue = MyInfo2.IsReRegistered.ToString();
                this.txtUsername.Text = MyInfo2.Username;

                string strRegMode = "常规注册";
                if (MyInfo2.RegisterMode == 0)
                {
                    strRegMode = "常规注册";
                }
                else if (MyInfo2.RegisterMode == 1)
                {
                    strRegMode = "网络手工";
                }
                else if (MyInfo2.RegisterMode == 10)
                {
                    strRegMode = "网络自动";
                }
                lblRegisterMode.Text = strRegMode;

            }
        }
        protected string BindGetUseType(object obj)
        {
            return Pbzx.Common.Method.GetUseType(obj);
        }

        protected string BindGetTimeType(object obj)
        {
            return Pbzx.Common.Method.GetTimeType(obj);
        }

        protected string BindGetUserType(object obj)
        {
            return Pbzx.Common.Method.GetUserType(obj);
        }

        protected string ChkSoftType2(object num)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            return softBLL.Chksofttype(num);
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return result[0] + "(" + result[1] + ")";
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            if (!OperateText.IsNumber(this.txtPayMoney.Text))
            {
                strErrMsg += "支付金额不是数字.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtAgentID.Text))
            {
                strErrMsg += "代理ID不是数字.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.BLL.RegisterInfo2 InfoBLL = new Pbzx.BLL.RegisterInfo2();
            string str = Request.QueryString["ID"];               
            Pbzx.Model.RegisterInfo2 MyInfo = InfoBLL.GetModel(Convert.ToInt32(str));

            MyInfo.Username = this.txtUsername.Text;
            MyInfo.UserTel = this.txtUserTel.Text;
            MyInfo.UserEmail = this.txtUserEmail.Text;
            MyInfo.PayMoney = decimal.Parse(this.txtPayMoney.Text);
            MyInfo.UserAddress = this.txtUserAddress.Text;
            MyInfo.BBsID = this.txtBBsID.Text;
            MyInfo.PayType = this.txtPayType.Text;
            MyInfo.PayDetails = this.txtPayDetails.Text;
            MyInfo.AgentID =int.Parse(this.txtAgentID.Text);
            MyInfo.AgentName = this.txtAgentName.Text;
            MyInfo.Status = int.Parse(this.rdlstatus.SelectedValue);
            MyInfo.Remarks = this.txtRemarks.Text;
            MyInfo.IsReRegistered = int.Parse(this.rdlIsReh.SelectedValue);
            if (InfoBLL.Update(MyInfo))
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改软件注册信息[注册码：" + this.lblHDSN.Text + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("SoftReg_Manager.aspx"));
                Response.Write("<script>window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }
        }

      }
}
