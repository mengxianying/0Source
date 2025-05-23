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
    public partial class SoftRegisterLog_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.CN_RegisterLog logBLL = new Pbzx.BLL.CN_RegisterLog();
                Pbzx.Model.CN_RegisterLog Mylog;

                string str = Request.QueryString["ID"];
                Mylog = logBLL.GetModel(Convert.ToInt32(str));

                this.lblBbsName.Text = Mylog.BbsName;
                this.lblSoftwareType.Text = ChkSoftType(Mylog.SoftwareType, Mylog.InstallType);
                this.lbluserType.Text = Pbzx.Common.Method.GetNetUseType(Mylog.UseType);
                this.lblUseValue.Text = Pbzx.Common.Method.GetNetUseValue(Mylog.UseType, Mylog.UseValue);
                this.lblOperator.Text = Mylog.Operator;
                this.lblRegisterType.Text = Mylog.AgentName.ToString();

                this.lblOld_UserType.Text = BindShowUserType(Mylog.Old_UserType);
                this.lblOld_ExpireDate.Text = Mylog.Old_ExpireDate.ToString();
                this.lblOld_ValidDays.Text = Mylog.Old_ValidDays.ToString();

                this.txtUsername.Text = Mylog.Username;
                this.txtPayType.Text = Mylog.PayType;
                this.txtPayMoney.Text = Mylog.PayMoney.ToString();

                this.rblPayStatus.SelectedValue =Mylog.PayStatus.ToString();
                this.txtPayTime.Text = Mylog.PayTime.ToString();
                this.txtRemarks.Text = Mylog.Remarks;
                lblCreateTime.Text = Mylog.PayTime.ToString();
                string strRegMode = "常规注册";
                if(Mylog.RegisterMode == 0)
                {
                    strRegMode = "常规注册";
                }
                else if(Mylog.RegisterMode == 1)
                {
                    strRegMode = "网络手工";
                }
                else if(Mylog.RegisterMode == 10)
                {
                    strRegMode = "网络自动";
                }
                lblRegisterMode.Text = strRegMode;
            }
        }

        protected string BindGetTimeType(object obj)
        {
            return Pbzx.Common.Method.GetTimeType(obj);
        }
        
       protected string BindShowUserType(object obj)
        {
            return Pbzx.Common.Method.ShowUserType(obj);
        }


        protected string BindGetdanwei(object obj)
        {
            return Pbzx.Common.Method.Getdanwei(obj);
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return result[0] + "(" + result[1] + ")";
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            if (!OperateText.IsNumber(this.txtPayMoney.Text))
            {
                strErrMsg += "付费金额:不是数字.\\r\\n";
            }
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(this.txtPayTime.Text.Trim(), out dt))
            {
                strErrMsg += "付费时间格式不正确.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.BLL.CN_RegisterLog logBLL = new Pbzx.BLL.CN_RegisterLog();
            string str = Request.QueryString["ID"];
            Pbzx.Model.CN_RegisterLog Mylog = logBLL.GetModel(Convert.ToInt32(str));

            Mylog.Username = this.txtUsername.Text;
            Mylog.PayType = this.txtPayType.Text;

            Mylog.PayMoney =decimal.Parse(this.txtPayMoney.Text);

            Mylog.PayStatus =int.Parse(this.rblPayStatus.SelectedValue);
            Mylog.PayTime = Convert.ToDateTime(this.txtPayTime.Text);
            Mylog.Remarks = this.txtRemarks.Text;

            if (logBLL.Update(Mylog))
            {
              //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
                Response.Write("<script>window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }
        }
    }
}
