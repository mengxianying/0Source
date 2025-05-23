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
    public partial class EmailYZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Pbzx.Model.PBnet_UserTable userModel = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            if (userModel == null)
            {
                Response.Write(JS.Alert("����δ��Ϊ�߼��û���", "/UserCenter/User_Center.aspx"));
                return;
            }
            else
            {
                int count = (int)userModel.EmailCodeCount;
                string emailCode = userModel.EmailCode;
                DateTime dtYzTime = (DateTime)userModel.EmailCodeTime;
                int intState = (int)userModel.EmailState;
                if(intState != 1)
                {
                    Response.Write(JS.Alert("��֤����������������֤��", "/UserCenter/User_Info.aspx"));
                    return;
                }
                if(dtYzTime.AddDays(14) < DateTime.Now)
                {
                    userModel.EmailCode = "";
                    userModel.EmailCodeCount = 0;
                    userModel.EmailState = 2;
                    userBll.Update(userModel);
                    Response.Write(JS.Alert("��֤����ڣ�", "/UserCenter/User_Info.aspx"));
                    return;
                }
                if(count >= 4)
                {
                    userModel.EmailCode = "";
                    userModel.EmailCodeCount = 0;
                    userModel.EmailState = 2;
                    userBll.Update(userModel);
                    Response.Write(JS.Alert("��֤����������࣡������������֤��", "/UserCenter/User_Info.aspx"));
                    return;
                }
                if(userModel.EmailCode != this.txtYZM.Text.Trim())
                {
                    userModel.EmailCodeCount += 1;
                    userBll.Update(userModel);
                    Response.Write(JS.Alert("��֤�����"));
                    return;
                }
                if(userModel.EmailCode == this.txtYZM.Text.Trim())
                {
                    userModel.EmailState = 3;
                    userBll.Update(userModel);
                    Response.Write(JS.Alert("��֤��ɹ���", "User_Info.aspx"));
                }
                
            }

        }
    }
}
