<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SMSStart.aspx.cs" Inherits="Pinble_Market.admin.Note.SMSStart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>拼搏在线短信测试平台</title>
    <style type="text/css">
<!--
body {
	font-size: 14px;
	font-weight: normal;
	text-decoration: none;
}
input
{
border:1px  #C1C9E8 solid;
}
.btn
{
border:1px #C1C9E8 solid; background-color:#f5f5f5; color:#0000FF
}
.STYLE1 {
	color: #FFFFFF;
	font-weight: bold;
}
-->
</style>

    <script type="text/javascript">
function sendsms()
{
	var s_sendno=document.getElementById("t_sendNo").value;
	var s_memo=document.getElementById("t_sendMemo").value;
	if(s_sendno=="")
	{
		alert("请输入对方手机号码!");
		document.getElementById("t_sendNo").focus();
		return false;
	}
	if(s_memo=="")
	{
		alert("请输入发送内容!");
		document.getElementById("t_sendMemo").focus();
		return false;
	}
	return true;
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#0066CC">
                <tr>
                    <td bgcolor="#0066CC" colspan='3'>
                        <span class="STYLE1">发送短信
                            <input id="h_eid" type="hidden" value="0" runat="server" /><!--企业ID代码-->
                            <input id="h_uid" type="hidden" value="10086" runat="server" /><!--会员登陆账户-->
                            <input id="h_pwd" type="hidden" value="10086" runat="server" /><!--登陆密码-->
                            <input id="h_gate_id" type="hidden" value="300" runat="server" /><!--使用通道的ID--></span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td width="25%" align="right">
                                    目标号码:</td>
                                <td width="75%" colspan="2">
                                    &nbsp;<asp:TextBox ID="t_sendNo" runat="server" Width="472px"></asp:TextBox><br />
                                    (多个号码用[,]逗号分开)</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    发送时间:</td>
                                <td colspan="2">
                                    &nbsp;<asp:TextBox ID="t_sendTime" runat="server"></asp:TextBox>(立即发送.为空.定时发送,请输入发送时间)例如:2008-08-08
                                    12:20:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    发送内容:</td>
                                <td colspan="2">
                                    <asp:TextBox ID="t_sendMemo" runat="server" TextMode="MultiLine" Height="150px" Width="427px"></asp:TextBox>
                                    (每条短信内容长度要求请参考通道说明)
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:Button ID="Button1" runat="server" Text="发送" CssClass="btn" Width="56px" OnClientClick="return sendsms();"
                                        OnClick="Button1_Click" />
                                    <input type="reset" name="Submit2" value="重置" class="btn" style="width: 57px" />
                                    <asp:Label ID="Label1" runat="server" Text="Label" Width="139px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#0066CC">
                        <span class="STYLE1">接收短信
                            <asp:Button ID="Button2" runat="server" Text="读取短信" CssClass="btn" OnClick="Button2_Click" /></span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF">
                        <div id="div_sms" runat="server">
                        </div>
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                            AutoGenerateColumns="False" Width="100%">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="回复者号码">
                                    <ItemTemplate>
                                        <%#Eval("SenderNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="内容">
                                    <ItemStyle Width="50%" />
                                    <ItemTemplate>
                                        <%#Eval("MsgContent") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发送时间">
                                    <ItemTemplate>
                                        <%#Eval("SendTime") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回复运营商SP">
                                    <ItemTemplate>
                                        <%#Eval("SP_PID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
