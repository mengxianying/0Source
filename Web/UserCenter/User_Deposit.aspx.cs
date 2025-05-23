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
using System.Text;

namespace Pbzx.Web.UserCenter
{
    public partial class User_Deposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
                {
                    Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='UserRealInfo.aspx';}</script>");
                    Response.End();
                    return;  
                }
                //if (!login[ELoginSort.AccountNumber.ToString()])
                //{
                //    Response.Write(JS.Alert("您的银行卡还没有通过验证，无法充值！请先验证您得银行卡", "Bank_Info.aspx"));
                //    Response.End();
                //    return;
                //}
                Pbzx.Model.PBnet_UserTable ut = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                this.lblBalance.Text = string.Format("{0:C2}", ut.CurrentMoney);
            }
        }

        protected void ibtnCharge_Click(object sender, ImageClickEventArgs e)
        {

            Pbzx.Model.PBnet_UserTable ut = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = new Pbzx.Model.PBnet_Charge();
          
            model.OrderID = Method.CreateOrderID("CZ","PBnet_Charge");
            model.UserID = int.Parse(Method.Get_UserID);
            model.UserName = Method.Get_UserName;
            model.RealName = ut.RealName;    
            model.OrderDate = DateTime.Now;

            decimal mo = 0;
            if (!decimal.TryParse(this.txMoney.Text, out mo))
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('您输入的充值金额不正确')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('您输入的充值金额不正确')", true);
                return;
            }
            model.PayMoney = mo;

            model.State = 0;
            model.Type = 0;
            model.PayNum = "";
            model.HasPayedPrice = 0;
            model.IsPay = 0;
            model.IsCancel = 0;
            model.UpdateStaticDate = DateTime.Now;
            model.OnlineType = 0;
            model.UserIP = Request.UserHostAddress;
            if (this.radio3.Checked)
            {
                model.c_memo1 = "cncard";
                model.PayTypeID = 1;
                model.PayTypeName = "网上支付";
                int result = chargeBLL.Add(model);
                //   Response.Redirect("~/YunWangCncard/SendOrder.aspx?ChargeID=" + model.OrderID); <script> this.parent.location= '../login.aspx ';self.close(); </script> 
                Response.Write("<script>top.location.href='/YunWangCncard/SendOrder.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
            else if (this.radio2.Checked && Request["radio3"] != "")
            {
                model.c_memo1 = "chinabank";
                model.PayTypeID = 1;
                model.PayTypeName = "网上支付";
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='/chinabank/Send.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
            else if (this.radio1.Checked)
            {
                model.c_memo1 = "99bill";
                model.PayTypeID = 1;
                model.PayTypeName = "网上支付";
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='/99bill/send.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
            else if(this.radio4.Checked)
            {
                model.c_memo1 = "Alipay";
                model.PayTypeID = 1;
                model.PayTypeName = "网上支付";
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='/Alipay/Default.aspx?OrderID=" + model.OrderID + "';</script>");
                return;    
            }
            else
            {
                model.c_memo1 = "";
                model.PayTypeID = 2;
                model.PayTypeName = "银行转帐";
                model.OnlineType = 1;
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='BankTransferCZ.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
        }
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{

        //}

    }
}

































































































































































            //<div id="dvRealInfo" style="display: none; text-align: center;">
            //    <div style="width: 830px; overflow-x: hidden; height: 620px; display: block; overflow: scroll;"
            //        id="tb1">
            //        <table style="width: 805px;">
            //            <tr>
            //                <td>
            //                    <table id="rule" width="100%" align="center" border="0" cellspacing="0" cellpadding="0"
            //                        style="line-height: 150%">
            //                        <tr>
            //                            <td height="10">
            //                            </td>
            //                        </tr>
            //                        <tr>
            //                            <td valign="top" style="padding-bottom: 10px; padding-left: 10px; padding-top: 2px;">
            //                                <!--<div style="overflow:auto; height:650px">-->
            //                                <p align="center" class="blue_bold">
            //                                    高级用户注册服务协议</p>
            //                                <p style="line-height: 150%; text-align: left;">
            //                                    一、 请您在申请注册『拼搏在线』高级用户之前仔细阅读本用户注册服务协议。如果您同意并申请注册用了『拼搏在线』高级用户的有偿服务，即表示您完全同意遵守所有这些条款。<br>
            //                                    二、 如果您不同意接受这些条款，请您立即离开。<br />
            //                                    三、注册成为『拼搏在线』高级用户时，需按要求填写真实详细的个人身分资料、姓名、住址、联系电话、银行帐号、电子邮箱等相关资料；<br />
            //                                    四、高级用户注册成功后，要保管好您的用户名和交易密码，并要对您的用户名和交易密码安全负全部责任。您可以不定期来更换您的交易密码，以提高安全性。<br />
            //                                    五、高级用户注册成功后，您要对以其用户名进行的所有活动和事件负全责。<br />
            //                                    六、高级用户在接受有偿服务时，要按规定方式支付相关的服务费用；<br />
            //                                    七、高级用户的权利与义务：<br />
            //                                    1、高级用户可以访问所申请或购买的有偿服务内容；<br />
            //                                    2、高级用户必须遵守所有使用网络服务的相关法律、协议、规定和惯例，不得干扰或破坏与本服务相连的服务器和网络。<br />
            //                                    3、高级用户不得发表任何非法的、骚扰性的、中伤他人的、辱骂性的、恐吓性的、伤害性的、庸俗的，淫秽的等信息内容。<br />
            //                                    4、高级用户要遵守『拼搏在线』关于有偿服务内容与资料及其他文件的版权声明和其他的管理规定，本站所提供的有偿服务内容与资料仅用于高级用户本人参考使用，不得随意转载或传播。<br />
            //                                    5、高级用户要保证注册资料的真实可靠性，并保证账号使用的唯一性，不得将账号信息提供给他人使用或进行网络传播。<br />
            //                                    八、本网站的权利与义务：<br />
            //                                    1、『拼搏在线』按时提供对付费高级用户权利中所包含的有偿服务内容与资料。<br />
            //                                    2、『拼搏在线』所提供的有偿服务内容与资料仅供付费高级用户参考使用，不保证所提供的有偿服务内容与资料一定中奖，不承担任何赔偿责任；<br />
            //                                    3、『拼搏在线』对违反高级用户义务中所提到条款的用户，本站有权独立作出判断并冻结该高级用户的使用权限；<br />
            //                                    4、『拼搏在线』对已开通有偿服务内容的用户所交纳的服务费用无特殊原因本站恕不退还。<br />
            //                                    5、『拼搏在线』如因系统维护或升级而需暂停高级用户服务时将事先公告。因此而造成的正常服务中断，请您予以理解。如因不可抗力或其他无法控制的原因，而导致高级用户服务暂停，于暂停服务期间造成的一切不便与损失，本站将不承担任何责任与赔偿；<br />
            //                                    九、在您确认本注册协议后，本注册协议即在您和『拼搏在线』之间产生法律效力。请您务必在注册之前认真阅读全部协议内容，如有任何疑问，可向『拼搏在线』咨询。
            //                                </p>
            //                                <p align="right">
            //                                    拼搏在线（北京）科技发展有限公司</p>
            //                                <!--</div>-->
            //                            </td>
            //                        </tr>
            //                    </table>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td align="center">
            //                    <input type="button" id="btnTong" value="我同意本协议" onclick='$("#tb1").hide();$("#tb2").show();' />
            //                    &nbsp; &nbsp;&nbsp;
            //                    <input id="btnNo" type="button" value="暂不申请高级用户" onclick='top.location="User_Center.aspx";' />
            //                </td>
            //            </tr>
            //        </table>
            //    </div>
            //    <%--overflow-x:hidden;--%>
            //    <div style="width: 830px; display: none; height: 720px; overflow: scroll;" id="tb2">
            //        <table style="width: 805px;">
            //            <tr>
            //                <td>
            //                    <uc1:UcRegRealInfo ID="UcRegRealInfo1" runat="server" />
            //                </td>
            //            </tr>
            //            <tr>
            //                <td align="center">
            //                    <asp:Button ID="btmSemd" runat="server" Text="提交" OnClick="btmSemd_Click" OnClientClick="$.unblockUI();" />
            //                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            //                    <input id="Button1" type="button" value="取消" onclick='top.location="User_Center.aspx";' />
            //                   <%-- <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />--%></td>
            //            </tr>
            //        </table>
            //    </div>
            //</div>