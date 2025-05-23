<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MsgDetail.aspx.cs" Inherits="Pbzx.Web.PB_Manage.MsgDetail" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head id="Head1" runat="server">
    <title>留言详细信息</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

</head>
<body>
    <form id="form1" runat="server">       
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <table width="600" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT2">
                    <tr>
                        <td width="10">
                            <img src="../images/web/UC_weibg1.jpg" width="10" height="28" alt="" /></td>
                        <td width="584" background="../images/web/UC_weibg2.jpg">
                            <span class="uc_weib">短消息</span></td>
                        <td width="6">
                            <img src="../images/web/UC_weibg3.jpg" width="6" height="28" /></td>
                    </tr>
                </table>
                <table width="600" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD"
                    id="tbBig" runat="server" class="uc_MT2">
                    <tr>
                        <td align="center" bgcolor="#FFFFFF">
                            <asp:ImageButton ID="ibtnDel" runat="server" ImageUrl="~/Images/Web/m_delete.gif"
                                AlternateText="删除消息" OnClick="ibtnDel_Click" />&nbsp;
                            <asp:ImageButton ID="ibtnWrite" runat="server" ImageUrl="~/Images/Web/m_write.gif"
                                AlternateText="发送消息" OnClick="ibtnWrite_Click" />&nbsp;
                            <asp:ImageButton ID="ibtnReplypm" runat="server" ImageUrl="~/Images/Web/replypm.gif"
                                AlternateText="回复消息" OnClick="ibtnReplypm_Click" />&nbsp;
                            <asp:ImageButton ID="ibtnFw" runat="server" ImageUrl="~/Images/Web/m_fw.gif" AlternateText="转发消息"
                                OnClick="ibtnFw_Click" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" align="center" cellpadding="4" cellspacing="1" id="tbSend"
                                runat="server" visible="false">
                                <tr>
                                    <td width="100" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                        收件人：</td>
                                    <td width="500" bgcolor="#FFFFFF">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                &nbsp;<asp:TextBox ID="txtToUser" runat="server" Width="230px"></asp:TextBox>&nbsp;
                                                <asp:DropDownList ID="ddlFriends" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFriends_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                        标题：</td>
                                    <td width="500" bgcolor="#FFFFFF">
                                        &nbsp;<asp:TextBox ID="txtTitle" runat="server" Width="450px" MaxLength="50"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td width="100" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                        内容：</td>
                                    <td width="500" bgcolor="#FFFFFF">
                                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" ToolbarSet="My" Height="200px">
                                        </FCKeditorV2:FCKeditor>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" bgcolor="#F6F6F6" class="uc_font_blue" colspan="2">
                                        <strong>说明</strong>：<br />
                                        <%--您可以使用<b>Ctrl+Enter</b>键快捷发送短信<br />--%>
                                        ① 可以用英文状态下的逗号将用户名隔开实现群发，最多<b><asp:Label ID="lblSenduserCount" runat="server" Text=""></asp:Label></b>个用户<br />
                                        ② 标题最多<b>50</b>个字符<br />
                                        ③ 您今天还可以发 <b>
                                            <asp:Label ID="lblTodayCount" runat="server" Text=""></asp:Label></b> 条消息
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#ffffff" colspan="2">
                                        <asp:Button ID="btnSend" runat="server" Text="发送" OnClick="btnSend_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />&nbsp;
                                        <input class="input0" name="Clear" onclick="$('#txtToUser').val('');$('#txtTitle').val('');$('#txtContent').val('');"
                                            type="reset" value="清除" />
                                        &nbsp;<input class="input0" name="close" onclick="window.close();" type="button"
                                            value="关闭" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="4" cellspacing="1" id="tbRead" runat="server"
                                visible="false" bgcolor="#FFFFFF">
                                <tr>
                                    <td style="background-color: #edf5f8">
                                        <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-bottom: #dddddd 1px solid">
                                        <b>消息标题：
                                            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-bottom: #dddddd 1px solid">
                                        <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <img src="../Images/Web/UC_btcolse.jpg" alt="关闭" border="0" onclick="window.close();"
                                            style="cursor: pointer;" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="4" cellspacing="1" id="tbAlert" runat="server"
                                visible="false" bgcolor="#FFFFFF">
                                <tr>
                                    <td bgcolor="#F6F6F6" class="uc_font_blue">
                                        <asp:Label ID="lblAlertTitle" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAlertContent" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#F6F6F6" class="uc_font_blue">
                                        <img runat="server" id='imgClose' src="../Images/Web/UC_btcolse.jpg" border="0" onclick="window.close();"
                                            alt="关闭" style="cursor: pointer;" />
                                        <%--<a href="javascript:history.go(-1)">&lt;&lt; 返回上一页</a> &nbsp; || &nbsp; <a
                                        href="javascript:wndClose();">关闭窗口&gt;&gt;</a>
                                    <script type="text/javascript">
		                                function wndClose(){
			                                try{
				                                parent.DvWnd.close();
			                                }
			                                catch(e){
				                                window.close()
			                                }
	                                    }		
                                    </script>--%>
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
