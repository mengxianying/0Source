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
                    Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='UserRealInfo.aspx';}</script>");
                    Response.End();
                    return;  
                }
                //if (!login[ELoginSort.AccountNumber.ToString()])
                //{
                //    Response.Write(JS.Alert("�������п���û��ͨ����֤���޷���ֵ��������֤�������п�", "Bank_Info.aspx"));
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
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ĳ�ֵ����ȷ')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ĳ�ֵ����ȷ')", true);
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
                model.PayTypeName = "����֧��";
                int result = chargeBLL.Add(model);
                //   Response.Redirect("~/YunWangCncard/SendOrder.aspx?ChargeID=" + model.OrderID); <script> this.parent.location= '../login.aspx ';self.close(); </script> 
                Response.Write("<script>top.location.href='/YunWangCncard/SendOrder.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
            else if (this.radio2.Checked && Request["radio3"] != "")
            {
                model.c_memo1 = "chinabank";
                model.PayTypeID = 1;
                model.PayTypeName = "����֧��";
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='/chinabank/Send.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
            else if (this.radio1.Checked)
            {
                model.c_memo1 = "99bill";
                model.PayTypeID = 1;
                model.PayTypeName = "����֧��";
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='/99bill/send.aspx?OrderID=" + model.OrderID + "';</script>");
                return;
            }
            else if(this.radio4.Checked)
            {
                model.c_memo1 = "Alipay";
                model.PayTypeID = 1;
                model.PayTypeName = "����֧��";
                int result = chargeBLL.Add(model);
                Response.Write("<script>top.location.href='/Alipay/Default.aspx?OrderID=" + model.OrderID + "';</script>");
                return;    
            }
            else
            {
                model.c_memo1 = "";
                model.PayTypeID = 2;
                model.PayTypeName = "����ת��";
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
            //                                    �߼��û�ע�����Э��</p>
            //                                <p style="line-height: 150%; text-align: left;">
            //                                    һ�� ����������ע�᡺ƴ�����ߡ��߼��û�֮ǰ��ϸ�Ķ����û�ע�����Э�顣�����ͬ�Ⲣ����ע�����ˡ�ƴ�����ߡ��߼��û����г����񣬼���ʾ����ȫͬ������������Щ���<br>
            //                                    ���� �������ͬ�������Щ������������뿪��<br />
            //                                    ����ע���Ϊ��ƴ�����ߡ��߼��û�ʱ���谴Ҫ����д��ʵ��ϸ�ĸ���������ϡ�������סַ����ϵ�绰�������ʺš����������������ϣ�<br />
            //                                    �ġ��߼��û�ע��ɹ���Ҫ���ܺ������û����ͽ������룬��Ҫ�������û����ͽ������밲ȫ��ȫ�����Ρ������Բ��������������Ľ������룬����߰�ȫ�ԡ�<br />
            //                                    �塢�߼��û�ע��ɹ�����Ҫ�������û������е����л���¼���ȫ��<br />
            //                                    �����߼��û��ڽ����г�����ʱ��Ҫ���涨��ʽ֧����صķ�����ã�<br />
            //                                    �ߡ��߼��û���Ȩ��������<br />
            //                                    1���߼��û����Է��������������г��������ݣ�<br />
            //                                    2���߼��û�������������ʹ������������ط��ɡ�Э�顢�涨�͹��������ø��Ż��ƻ��뱾���������ķ����������硣<br />
            //                                    3���߼��û����÷����κηǷ��ġ�ɧ���Եġ��������˵ġ������Եġ������Եġ��˺��Եġ�ӹ�׵ģ�����ĵ���Ϣ���ݡ�<br />
            //                                    4���߼��û�Ҫ���ء�ƴ�����ߡ������г��������������ϼ������ļ��İ�Ȩ�����������Ĺ���涨����վ���ṩ���г��������������Ͻ����ڸ߼��û����˲ο�ʹ�ã���������ת�ػ򴫲���<br />
            //                                    5���߼��û�Ҫ��֤ע�����ϵ���ʵ�ɿ��ԣ�����֤�˺�ʹ�õ�Ψһ�ԣ����ý��˺���Ϣ�ṩ������ʹ�û�������紫����<br />
            //                                    �ˡ�����վ��Ȩ��������<br />
            //                                    1����ƴ�����ߡ���ʱ�ṩ�Ը��Ѹ߼��û�Ȩ�������������г��������������ϡ�<br />
            //                                    2����ƴ�����ߡ����ṩ���г��������������Ͻ������Ѹ߼��û��ο�ʹ�ã�����֤���ṩ���г���������������һ���н������е��κ��⳥���Σ�<br />
            //                                    3����ƴ�����ߡ���Υ���߼��û����������ᵽ������û�����վ��Ȩ���������жϲ�����ø߼��û���ʹ��Ȩ�ޣ�<br />
            //                                    4����ƴ�����ߡ����ѿ�ͨ�г��������ݵ��û������ɵķ������������ԭ��վˡ���˻���<br />
            //                                    5����ƴ�����ߡ�����ϵͳά��������������ͣ�߼��û�����ʱ�����ȹ��档��˶���ɵ����������жϣ�����������⡣���򲻿ɿ����������޷����Ƶ�ԭ�򣬶����¸߼��û�������ͣ������ͣ�����ڼ���ɵ�һ�в�������ʧ����վ�����е��κ��������⳥��<br />
            //                                    �š�����ȷ�ϱ�ע��Э��󣬱�ע��Э�鼴�����͡�ƴ�����ߡ�֮���������Ч�������������ע��֮ǰ�����Ķ�ȫ��Э�����ݣ������κ����ʣ�����ƴ�����ߡ���ѯ��
            //                                </p>
            //                                <p align="right">
            //                                    ƴ�����ߣ��������Ƽ���չ���޹�˾</p>
            //                                <!--</div>-->
            //                            </td>
            //                        </tr>
            //                    </table>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td align="center">
            //                    <input type="button" id="btnTong" value="��ͬ�ⱾЭ��" onclick='$("#tb1").hide();$("#tb2").show();' />
            //                    &nbsp; &nbsp;&nbsp;
            //                    <input id="btnNo" type="button" value="�ݲ�����߼��û�" onclick='top.location="User_Center.aspx";' />
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
            //                    <asp:Button ID="btmSemd" runat="server" Text="�ύ" OnClick="btmSemd_Click" OnClientClick="$.unblockUI();" />
            //                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            //                    <input id="Button1" type="button" value="ȡ��" onclick='top.location="User_Center.aspx";' />
            //                   <%-- <asp:Button ID="btnCancel" runat="server" Text="ȡ��" OnClick="btnCancel_Click" />--%></td>
            //            </tr>
            //        </table>
            //    </div>
            //</div>