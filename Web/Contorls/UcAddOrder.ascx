<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAddOrder.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcAddOrder" %>

<script type="text/javascript" src="/UserCenter/js/advance.js"></script>

<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"
    class="MT">
    <tr>
        <td height="20" colspan="4" align="left" background="/Images/Web/shop_serve.jpg">
            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <strong>使用者信息</strong>&nbsp;&nbsp;（请务必如实填写，以便以后出现问题时核对您的注册信息）</td>
                    <td align="right">
                        <span class="shop_red">带*为必填项</span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td width="11%" align="right">
            姓名：</td>
        <td width="22%" align="left">
            <asp:TextBox ID="txtReceiverName" runat="server" Width="100px" MaxLength="16"></asp:TextBox>&nbsp;<span
                class="shop_red">*</span><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReceiverName"
                ErrorMessage="姓名不能空！" Display="Dynamic"></asp:RequiredFieldValidator></td>
        <td width="13%" align="right">
            电话：</td>
        <td width="54%" align="left">
            <asp:TextBox ID="txtReceiverPhone" runat="server" Width="200px" MaxLength="16"></asp:TextBox>&nbsp;<span
                class="shop_red">*</span><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReceiverPhone"
                ErrorMessage="电话不能空！" Display="Dynamic"></asp:RequiredFieldValidator>
                <iframe style="display:none" src="/BoilingSoft/getm.aspx?act=getm&returnobjid=AddOrder1_txtReceiverPhone"></iframe>
                </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td align="right">
            邮编：</td>
        <td align="left">
            <asp:TextBox ID="txtReceiverPostalCode" runat="server" Width="100px" MaxLength="6"></asp:TextBox>
            <br />
        </td>
        <td align="right">
            Email：</td>
        <td align="left">
            <asp:TextBox ID="txtReceiverEmail" runat="server" Width="200px" MaxLength="32"></asp:TextBox>
            <br />
            </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td align="right">
            详细地址：</td>
        <td colspan="3" align="left">
            <asp:TextBox ID="txtReceiverAddress" runat="server" Width="300px" MaxLength="32"></asp:TextBox>&nbsp;<span
                class="shop_red">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReceiverAddress"
                ErrorMessage="地址不能空！" Display="Dynamic"></asp:RequiredFieldValidator><br />
            (如果您选择了[购买新软件狗]方式的软件，请务必填写详细准确的地址，以确保能收到软件狗)</td>
    </tr>
</table>
<asp:Panel runat="server" ID="tbPortType" Width="100%">
    <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"
        class="MT">
        <tr>
            <td height="20" bgcolor="#FFF4DD" align="left" 
                background="/Images/Web/shop_serve.jpg">
                &nbsp;<b class="bTitle">结算信息</b></td>
        </tr>
        <tr bgcolor="#ffffff">
            <td align="left" style="padding-top: 7px; padding-left: 8px;" valign="top">
                <%--<asp:RadioButtonList ID="rblPortType" runat="server" DataSourceID="objectDSPortType"
                DataTextField="PortTypeName" DataValueField="PortTypeID" RepeatLayout="Flow">
            </asp:RadioButtonList>--%>
                <asp:Label ID="lblJSXX" runat="server"></asp:Label><%--<asp:Repeater ID="repPortType" runat="server" DataSourceID="objectDSPortType">
                <ItemTemplate>
                    运费：<%# Eval("PortPrice","{0:C2}") %><br />
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="objectDSPortType" runat="server" SelectMethod="GetAllList"
                TypeName="Pbzx.BLL.PBnet_PortType"></asp:ObjectDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblPortType"
                EnableViewState="False" ErrorMessage="运输方式未选择！" Display="Dynamic"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr bgcolor="#ffffff">
            <td align="right" style="padding-top: 7px" valign="top">
                <asp:Label ID="lblYFJE" runat="server"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>
<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"
    class="MT">
    <tr>
        <td height="20" bgcolor="#FFF4DD" align="left" background="/Images/Web/shop_serve.jpg">
            &nbsp;<b class="bTitle">支付方式</b></td>
    </tr>
    <tr bgcolor="#ffffff">
        <td align="left" style="padding-top: 7px;">
                    <asp:UpdatePanel ID="UpFKFS" runat="server">
                <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="left">
                        <table style="width: 100%; border-right: #99ccff 1px dashed; border-top: #99ccff 1px dashed; border-left: #99ccff 1px dashed; border-bottom: #99ccff 1px dashed;"  >
                            <tr>
                                <td style="width: 100px" valign="top">
                                    <asp:RadioButton ID="rblOnline" runat="server" GroupName="PayTypes" Text="在线支付" Checked="true"
                                        AutoPostBack="True" OnCheckedChanged="rblOnline_CheckedChanged" Font-Bold="True" ForeColor="Black" />
                                </td>
                                <td align="right">
                                    <table id="tbOnline" runat="server" style="color:Black;">
                                        <tr>
                                            <td style="width: 50px" valign="top" align="left">
                                               说明：</td>
                                            <td align="left">
                                               1、全自动的软件注册购买方式，在线支付成功后，系统将实时自动开通您注册的软件，软件即可使用。 （在“用户中心-我的订单”查看您的购买信息，购买新软件狗的用户请注意查收您的快递）                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px">
                                            </td>
                                            <td align="left">
                                                2、支持在线付款的平台有：网银在线、快钱、支付宝。(即时到帐，支持绝大多数银行借记卡及信用卡，准确快捷，推荐您使用此支付方式！
                                                <a href='/Payment.htm' target='_blank'>查看银行及限额</a>) 
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trOnlinePay" runat="server" visible="True">
                                <td colspan="2" align="center" >
                                    <table width="96%" runat="server" style="color:Black;" id="tbOnline2">
                                        <tr>                                        
                                            <td colspan="4" align="left">
                                             <table width="100%">
                                                <tr>
                                                    <td style="width:70px">
                                                    
                                                    </td>
                                                    <td>
                                                       支付平台：（<font color="red">以下平台均支持工商银行、建设银行、招商银行、交通银行、农业银行、中国银行等银行在线支付</font>）
                                                    </td>
                                                </tr>
                                             </table>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                               <%-- &nbsp;<img alt="云网支付" src="/Images/Web/yunwang.jpg" />--%></td>
                                            <td align="center">
                                               <%-- &nbsp;<img src="/Images/Web/jdzf.png" width="111" height="44" alt="" border="0" />--%></td>
                                            <td align="center">
                                                </td>
                                            <td align="center">
                                                &nbsp;<img alt="支付宝支付" src="/Images/Web/Pay_treasure.jpg" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table style="width: 100%; border-right: #99ccff 1px dashed; border-top: #99ccff 1px dashed; border-left: #99ccff 1px dashed; border-bottom: #99ccff 1px dashed;"  >
                            <tr>
                                <td style="width: 100px" valign="top">
                                    <asp:RadioButton ID="rblBank" runat="server" GroupName="PayTypes" Text="离线支付" OnCheckedChanged="rblBank_CheckedChanged" AutoPostBack="True" Font-Bold="True" ForeColor="Black" />
                                </td>
                                <td align="left">
                                    <table >
                                        <tr>
                                            <td style="width: 50px" valign="top" align="left">
                                               说明：</td>
                                            <td align="left">
                                                离线支付(包含财付通支付方式），是指您在网上下订单，然后去银行汇款；在“用户中心-我的订单”点击确认已汇款。公司将在查到你的真实汇款金额后1-3个工作日内为您开通软件。
                                                    <a href='/Payment.htm' target='_blank'>查看银行帐号</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table style="width: 100%; border-right: #99ccff 1px dashed; border-top: #99ccff 1px dashed; border-left: #99ccff 1px dashed; border-bottom: #99ccff 1px dashed;" >
                            <tr>
                                <td style="width: 100px;" valign="top">
                                    <asp:RadioButton ID="rblBalancePay" runat="server" GroupName="PayTypes" Text="余额支付" OnCheckedChanged="rblBalancePay_CheckedChanged" AutoPostBack="True" Font-Bold="True" ForeColor="Black" />
                                </td>
                                <td align="left" valign="top">
                                    <table >
                                        <tr>
                                            <td style="width: 50px" valign="top" align="left">
                                                说明：</td>
                                            <td style="text-align: left;">
                                                全自动的软件注册购买方式，余额支付成功后，系统将实时自动开通您注册的软件，软件即可使用。（在“用户中心-我的订单”查看您的购买信息，购买新软件狗的用户请注意查收您的快递）
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td align="left" valign="top">
                                   <asp:Panel ID="pnlYEZF" runat="server"  Visible="false">
                                        应付总额：<asp:Label ID="lblSumPrice" runat="server" Text=""></asp:Label>
                                        <asp:Panel ID="pnlNoMoney" runat="server" Visible="true">
                                            您的余额：<asp:Label ID="lblCurrentMoney" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label
                                                ID="lblAlert" runat="server" Text="" Visible="false"></asp:Label>
                                            <a href="/UserCenter/User_Center.aspx?myUrl=User_Deposit.aspx" class="uc_linkBlack"
                                                onclick="">
                                                <asp:Image ID="imgCZ" runat="server" border="0" AlternateText="充值" ImageUrl="/Images/Web/UC_bt2.png"
                                                    Visible="false" /></a>
                                        </asp:Panel>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                    </td>
                </tr>
            </table>

                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="hdPortPrice" runat="server" />
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="4">
    <tr>
        <td align="center">
            <asp:Button ID="btnAddOrders" runat="server" Text="提交订单" CssClass="shop_Button" 
                OnCommand="btnAddOrders_Command" />
            &nbsp;<asp:Button ID="btnModifyOrders" runat="server" OnClick="btnModifyOrders_Click"
                Text="修改订单" CssClass="shop_Button" /><br />
            <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label></td>
    </tr>
</table>
