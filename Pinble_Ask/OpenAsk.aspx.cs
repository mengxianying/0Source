using System;
using System.Web.UI;
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
                    Response.Write("<script>alert('您已经开通了拼搏吧，请不要重复开通！');window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
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
                        Response.Write("<script>alert('拼搏吧开通成功！');window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                        return;
                    }
                    else
                    {
                        Response.Write("<script>alert('抱歉！拼搏吧开通失败！请与管理员联系');window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                        return;
                    }
                }
            }
        }
    }
}
