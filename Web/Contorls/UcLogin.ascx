<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcLogin.ascx.cs" Inherits="Pbzx.Web.Contorls.UcLogin" %>
<div id="Login" runat="server">
 �û�����<asp:TextBox ID="txtName" runat="server" Width="110px" style="margin-top:2px; margin-bottom:2px;"></asp:TextBox>
��&nbsp;&nbsp;�룺<asp:TextBox ID="txtPWD" runat="server" maxlength="20" Width="110px" style="margin-top:2px; margin-bottom:2px;" TextMode="Password"></asp:TextBox>                                                             
��֤�룺<asp:TextBox ID="txtCode" maxlength="4"  onKeyDown="{if (event.keyCode==13) return chk_userfrm();}"   runat="server" Width="46px"></asp:TextBox>
		   <img src="/publicPage/VerifyCode.aspx" alt="�����壿�������" name="imgVerify" align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
&nbsp;<asp:ImageButton ID="ibtnLogin" runat="server" AlternateText="��¼ƴ��" OnClick="ibtnLogin_Click" ImageUrl="~/Images/Web/Lo.jpg" align="absmiddle" CausesValidation="False" />&nbsp;<a href="/Register.aspx" class="blue" target="_top">���ע��</a>&nbsp;<a href="/RecoverPasswd1.aspx" target="_top" class="blue">�������룿</a>
</div>
<div id="hasLogin" runat="server" visible="false">
��ӭ�� 
    <asp:Label ID="lblUName" runat="server" Text=""></asp:Label>
</div>


<%--onKeyUp="this.value=this.value.replace(/[^\d]+?/g,'')"--%>