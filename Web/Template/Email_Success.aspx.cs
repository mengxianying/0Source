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

namespace Pbzx.Web.Template
{
    public partial class Email_Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                if (Request["type"] == "EmailYZ")
                {
                    Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                    Pbzx.Model.PBnet_UserTable userModel = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                    lblUname.Text = userModel.RealName;
                    if(userModel != null)
                    {
                        string YZM = Method.CreateVerifyCode(8);
                        userModel.EmailCode = YZM;
                        userModel.EmailCodeCount = 0;
                        userModel.EmailCodeTime = DateTime.Now;
                        userModel.EmailState = 1;
                        userModel.EmailCode = YZM;
                        userBll.Update(userModel);
                        string strContent = "您的邮箱验证码为："+YZM+"<br/>";
                        strContent += "请您登录拼搏在线彩神通软件，进入“用户中心”，在“我的资料”中的“真实信息管理”中，点击Email验证，在相应位置输入验证码，完成Email验证。验证码的有效期为14天。";
                        this.lblContent.Text = strContent;
                    }
                }
                else if (Request["type"] == "AccountNumberStateYZ" && !string.IsNullOrEmpty(Input.FilterAll(Request["uid"])))
                {
                    Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                    Pbzx.Model.PBnet_UserTable userModel = userBll.GetModel(int.Parse(Request["uid"]));
                    lblUname.Text = userModel.RealName;
                    if (userModel != null)
                    {
                        string strContent = "";
                        strContent += " 拼搏在线彩神通软件已向您申请验证的银行卡进行汇款，汇入的金额即为您的银行卡验证码。<br/>";
                        strContent += "银行："+userModel.BankName+"<br/>";
                        strContent += "卡号：" + userModel.AccountNumber + "<br/>";
                        strContent += "汇款单号：" + Request["DH"] + "<br/>";
                        strContent += "请您在收到汇款后，登录拼搏在线彩神通软件，进入“用户中心”，在“我的资料”中的“真实信息管理”中，点击银行卡验证，在相应位置输入验证码，完成银行卡验证。验证码的有效期为14天。";
                        this.lblContent.Text = strContent;
                    }               
                }
            }
        }
    }
}
