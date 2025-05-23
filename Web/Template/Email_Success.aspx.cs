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
                        string strContent = "����������֤��Ϊ��"+YZM+"<br/>";
                        strContent += "������¼ƴ�����߲���ͨ��������롰�û����ġ����ڡ��ҵ����ϡ��еġ���ʵ��Ϣ�����У����Email��֤������Ӧλ��������֤�룬���Email��֤����֤�����Ч��Ϊ14�졣";
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
                        strContent += " ƴ�����߲���ͨ���������������֤�����п����л�����Ľ�Ϊ�������п���֤�롣<br/>";
                        strContent += "���У�"+userModel.BankName+"<br/>";
                        strContent += "���ţ�" + userModel.AccountNumber + "<br/>";
                        strContent += "���ţ�" + Request["DH"] + "<br/>";
                        strContent += "�������յ����󣬵�¼ƴ�����߲���ͨ��������롰�û����ġ����ڡ��ҵ����ϡ��еġ���ʵ��Ϣ�����У�������п���֤������Ӧλ��������֤�룬������п���֤����֤�����Ч��Ϊ14�졣";
                        this.lblContent.Text = strContent;
                    }               
                }
            }
        }
    }
}
