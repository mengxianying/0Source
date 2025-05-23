<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChargeDetails.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.ChargeDetails" %>

<%@ Register Src="../Contorls/OrderInfo.ascx" TagName="OrderInfo" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<html>
<head id="Head1">
    <title>充值详细信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script type="text/javascript" language="javascript">
        function OpenEdite(id)
        {
        }
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        } 
        function CheckYE()
        {        
            var objYE = document.getElementById("txtHasPayed").value;
            if(confirm('您确定要给该用户充值'+objYE+'元吗？'))
            {           
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>

</head>
<body>
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
                                                当前位置：充值详细信息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <div id="dvProductList">
                                        <table cellpadding="2" cellspacing="1" bgcolor="#CED7F7" runat="server" id="tbOrderType">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp; 注：
                                                    <asp:Label ID="lblStateZS" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td height="20" bgcolor="#FFF4DD" align="left" colspan="6">
                                                    &nbsp;<b class="bTitle">充值详细信息</b></td>
                                            </tr>
                                        </table>
                                        <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left" class="mshu_borderxia" height="36">
                                                    &nbsp; 订单<span class="mshu_font16black">编号：<span class="mshu_font16red">
                                                        <asp:Label ID="lblOrderID" runat="server"></asp:Label></span><span class="mshu_font16red"></span>
                                                        （<asp:Label ID="lblState" runat="server"></asp:Label>）</span><asp:Label ID="lblOrderDate"
                                                            runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table width="100%" align="center" border="0" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                            <tr bgcolor="#F2F8FB">
                                                <td colspan="4" align="left" class="mshu_font14black">
                                                    <strong>&nbsp;基本信息：</strong></td>
                                            </tr>
                                            <tr bgcolor="#F2F8FB">
                                                <td align="right" width="16%">
                                                    真实姓名：</td>
                                                <td width="27%" align="left">
                                                    <asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                                <td width="12%" align="right">
                                                    更新时间：</td>
                                                <td width="45%" align="left">
                                                    <asp:Label ID="lblUpdateStaticDate" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr bgcolor="#F2F8FB">
                                                <td align="right">
                                                    充值方式：</td>
                                                <td align="left">
                                                    <asp:Label ID="lblPayTypeName" runat="server"></asp:Label></td>
                                                <td align="right">
                                                    充值金额：</td>
                                                <td align="left">
                                                    <asp:Label ID="lblPayMoney" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr bgcolor="#F2F8FB">
                                                <td align="right">
                                                    已充值：</td>
                                                <td align="left">
                                                    <asp:Label ID="lblHasPay" runat="server"></asp:Label></td>
                                                <td align="right">
                                                    下单IP：</td>
                                                <td align="left">
                                                    <asp:Label ID="lblIP" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="dvOrderInfo">
                                    </div>
                                    <div id="dvCancel" runat="server" visible="false">
                                        订单已经取消
                                    </div>
                                    <div id="dvSuccess" runat="server" visible="false">
                                        <div>
                                            充值成功！
                                        </div>
                                        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                            <tr bgcolor="#f2f8fb">
                                                <td class="bold">
                                                    用户付款信息：</td>
                                                <td colspan="3">
                                                    实际汇款方式：<asp:Label ID="lblSJHKFS" runat="server"></asp:Label>
                                                    &nbsp;&nbsp; &nbsp;实际汇款金额：<asp:Label ID="lblSJHKJE" runat="server"></asp:Label>
                                                    &nbsp; &nbsp; &nbsp;处理结果：<asp:Label ID="lblSJResult" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#CED7F7"
                                        id="zhifu" runat="server">
                                        <tr bgcolor="#f2f8fb">
                                            <td width="16%" class="bold">
                                                付款信息：</td>
                                            <td width="84%" colspan="3">
                                                汇款方式：
                                                <asp:Label ID="lblHKFS" runat="server"></asp:Label>
                                                &nbsp;&nbsp; &nbsp;汇款金额：<asp:Label ID="lblHKJE" runat="server"></asp:Label>
                                                &nbsp; &nbsp; &nbsp;汇款日期：<asp:Label ID="lblHKRQ" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb" style="line-height: 30px;">
                                            <td height="25" class="bold" style="width: 15%">
                                                用户留言：</td>
                                            <td colspan="3">
                                                <asp:Label ID="lblUserRemark" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb">
                                            <td valign="top" class="bold">
                                                审核操作：</td>
                                            <td colspan="3">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                    <tr>
                                                        <td colspan="3">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                <tr>
                                                                    <td width="15%" align="right">
                                                                        实际付款方式：</td>
                                                                    <td width="83%" align="left">
                                                                        <asp:DropDownList ID="ddlPayType" runat="server">
                                                                        </asp:DropDownList><span style="color: #ff0000">*</span></td>
                                                                    <td width="2%">
                                                                        <span style="color: #ff0000"></span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        实际付款金额：</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtHasPayed" onkeypress="isnum()" runat="server" Width="80px" MaxLength="6">0</asp:TextBox><span
                                                                            style="color: #ff0000">*</span>元</td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            处理结果（如果未通过，请简要说明原因）：</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Height="100px" MaxLength="200"
                                                                Width="400px"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr bgcolor="#f2f8fb">
                                            <td class="bold" style="width: 15%; height: 23px;">
                                                订单状态:</td>
                                            <td colspan="3" style="height: 23px">
                                                <asp:RadioButtonList ID="rblOrderStaticTip" runat="server" RepeatDirection="Horizontal"
                                                    RepeatLayout="Flow" OnSelectedIndexChanged="rblOrderStaticTip_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:RadioButtonList>&nbsp; （当查到用户款项准确无误后，请先在上面的“购买软件清单”中给用户输入注册码，然后订单状态中选择“已开通”）</td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb">
                                            <td class="bold" style="width: 15%">
                                                是否取消：</td>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chbIsCancel" runat="server" AutoPostBack="True" OnCheckedChanged="chbIsCancel_CheckedChanged"
                                                    Text="是" /></td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb">
                                            <td class="bold" style="width: 15%">
                                                已付款：</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtHasPay" runat="server" Width="80px" MaxLength="8">0</asp:TextBox>元</td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB"  align="left">
                                <td align="left" style="height: 24px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;                                  
                                 <asp:Button ID="btnRight" runat="server" Text="给用户充值" OnClientClick="return CheckYE()"
                                        OnClick="btnRight_Click" />
                                    &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                    <asp:Button ID="btnFail" runat="server" OnClick="btnFail_Click" Text="未付款" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
