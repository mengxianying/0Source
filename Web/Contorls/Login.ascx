<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Login.ascx.cs" Inherits="Pbzx.Web.Contorls.Login" %>
<div id="Login1" runat="server">
            <table width="83%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" height="30">
                        用户名：</td>
                    <td align="left">
                        <asp:TextBox ID="txtName" runat="server" Width="130px" MaxLength="12"></asp:TextBox>&nbsp;<a style="cursor: pointer;"
                            href="/Register.aspx" tabindex="-1">免费注册</a></td>
                </tr>
                <tr>
                    <td align="right"  height="30">
                        密&nbsp;&nbsp;码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtPWD" runat="server" MaxLength="16" Width="130px" TextMode="Password"></asp:TextBox>&nbsp;<a
                            style="cursor: pointer;" href="/RecoverPasswd1.aspx" target="_blank" tabindex="-2">密码找回</a></td>
                </tr>
                <tr>
                    <td align="right"  height="30">
                        验证码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtCode" MaxLength="4" onkeyup="CheckYZM2(this.value)" 
                            runat="server" Width="46px"></asp:TextBox>
                        <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                            id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
                             <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                             <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />

                            <iframe id="eee" src="about:blank" style="display:none;"></iframe>
                            <script>
                                function CheckYZM2(aaaaa) 
                                {
                                    document.getElementById("eee").src = "/reg.aspx?keyUpCheckVerifyCode="+aaaaa+"&type=3";
                                }
                                function yanzhengmacallback(r)
                                {
                                    if(r=="Y")
                                    {
                                        document.getElementById("imgOKL").style.display = "inline";
                                        document.getElementById("imgErrorL").style.display = "none";
                                    }
                                    if(r=="N")
                                    {
                                        document.getElementById("imgOKL").style.display = "none";
                                        document.getElementById("imgErrorL").style.display = "inline";
                                    }
                                    if(r=="P")
                                    {
                                        alert("验证码已经失效！请点击验证码图片重新获取验证码");
                                    }
                                }

                            </script>

                            </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="30">
                        <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="loginbtn" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="loginbtn2" OnClick="btnreset_Click" />
                        &nbsp;<asp:CheckBox ID="cbState" runat="server" Text="保存登录状态" />
                    </td>
                </tr>
            </table>
  
            </div>
            <div id="hasLogin" runat="server" visible="false">
                <table cellspacing="4" cellpadding="4" width="85%" align="center" border="0">
                    <tbody>
                        <tr>
                            <td align="left">
                                <b>欢迎您：</b>
                                <asp:Label ID="lblUName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr><td>
                          
                                <asp:Button ID="btnChangePWD" runat="server" CssClass="loginbtn3" Text="修改密码" OnClick="btnChangePWD_Click" />
                         
                                <asp:Button ID="btnExit" runat="server" Text="退出" CssClass="loginbtn" OnClick="btnExit_Click" /></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnIn" runat="server" Text="用户中心" CssClass="loginbtn3" OnClick="btnIn_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
     
</div>
