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

namespace Pbzx.Web.UserCenter
{
    public partial class AccountNumYZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Pbzx.Model.PBnet_UserTable userModel = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            if (userModel == null)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert("", "����δ����Ϊ�߼��û����Ƿ����ھ�ȥ�����Ϊ�߼��û���", 400, "1", "top.location='UserRealInfo.aspx';", "", false, false));
                Response.End();
                return;
            }
            else
            {
                int count = (int)userModel.AccountNumberCodeCount;
                string AccountNumberCode = userModel.AccountNumberCode;
                DateTime dtYzTime = (DateTime)userModel.AccountNumberCodeTime;
                int intState = (int)userModel.AccountNumberState;
                if (intState != 4)
                {
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "��֤����������������֤��", 400, "1", "top.location='/UserCenter/User_Info.aspx';", "", false, false));   
                    return;
                }
                if (dtYzTime.AddDays(14) < DateTime.Now)
                {
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "��֤����ڣ�������������֤��", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false));   
                    return;
                }
                if (count >= 4)
                {                    
                    userModel.AccountNumberCodeCount = 0;
                    userModel.AccountNumberState = 2;
                    userModel.AccountNumberCode = "";
                    userBll.Update(userModel);
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "��֤����������࣡������������֤��", 400, "1", "top.location='/UserCenter/User_Info.aspx';", "", false, false));   
                    return;
                }
                if (userModel.AccountNumberCode != this.txtYZM.Text.Trim())
                {
                    userModel.AccountNumberCodeCount += 1;
                    userBll.Update(userModel);
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "��֤�����", 400, "1", "", "", false, false));   

                    return;
                }
                if (userModel.AccountNumberCode == this.txtYZM.Text.Trim())
                {
                    userModel.AccountNumberState = 3;
                    userBll.Update(userModel);
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "���п���֤�ɹ���", 400, "1", "location.href='Bank_Info.aspx';", "", false, false));   
                }
            }
        }
    }
}
