<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker_TradeInfo_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Broker_TradeInfo_Edit" %>

<html>
<head runat="server">
    <title>经纪人交易信息-修改</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
</head>
<body >
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：经纪人交易信息修改</td>
                                            <td width="9%" align="right">
                                              </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    经纪人用户名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBrokerName" runat="server" Text=""></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    客户用户名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    订单号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    交易时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    经纪人收益:</td>
                                <td>
                                    <asp:Label ID="lblBrokerIncome" runat="server" Text=""></asp:Label>
                                    </td>
                                <td class="bold">
                                    客户支付金额:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCustomerPay" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册人员:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblRegManager" runat="server" Text=""></asp:Label></td>
                                <td class="bold">
                                </td>
                                <td>
                                    &nbsp;<span class="red12"></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    备注信息</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" Rows="6" TextMode="MultiLine" Width="370px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td colspan="4">
                                    <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7" id="really"
                            runat="server" visible="false">
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="left">
                                    <b>&nbsp;经纪人真实信息：</b>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td width="15%" class="bold">
                                    真实姓名:</td>
                                <td width="36%">
                                    &nbsp;<asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                <td width="15%" class="bold">
                                    性别:</td>
                                <td width="34%">
                                    &nbsp;<asp:Label ID="lblSex" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    身份证号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCardID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    出生年月:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBirthday" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    联系电话:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTelphone" runat="server"></asp:Label></td>
                                <td class="bold">
                                    E-mail:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    手机号码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                <td class="bold">
                                    QQ号码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblQQ" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    省份:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblProvince" runat="server"></asp:Label></td>
                                <td class="bold">
                                    MSN:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblMSN" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    城市:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                <td class="bold">
                                    邮编:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblPostCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    详细地址:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    银行卡号:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblAccountNumber" runat="server"></asp:Label></td>
                                <td class="bold">
                                    发卡银行:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    开户行:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblBankInfo" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnUp" runat="server" Text="确定提交" OnClick="btnUp_Click" />
                                       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
