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

namespace Pinble_Ask
{
    public partial class OpenAsk : AskUserBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginSort login = new LoginSort();
                if (login[ELoginSort.ask_User.ToString()])
                {
                    Response.Write("<script>alert('���Ѿ���ͨ��ƴ���ɣ��벻Ҫ�ظ���ͨ��');window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                    return;
                }
                else
                {
                    string uName = Method.Get_UserName;
                    Pbzx.Model.PBnet_ask_User askUser = new Pbzx.Model.PBnet_ask_User();
                    askUser.OpenTime = DateTime.Now;
                    askUser.Point = 0;
                    askUser.State = 0;
                    askUser.UserGroup = "";
                    askUser.UserName = uName;
                    Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
                    if (userBLL.Add(askUser))
                    {
                        Pbzx.BLL.PinbleLogin myLogin = new Pbzx.BLL.PinbleLogin();
                        myLogin.CheckLogin(uName, Method.Get_UserPwd);
                        Response.Write("<script>alert('ƴ���ɿ�ͨ�ɹ���');window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                        return;
                    }
                    else
                    {
                        Response.Write("<script>alert('��Ǹ��ƴ���ɿ�ͨʧ�ܣ��������Ա��ϵ');window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                        return;
                    }
                }
            }
        }
    }
}
