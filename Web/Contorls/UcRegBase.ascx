<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcRegBase.ascx.cs" Inherits="Pbzx.Web.Contorls.UcRegBase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript" src="/javascript/SearchAjax.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<script type="text/javascript">
    function pro_change(type) {
        Open_yzm(type);
    }
</script>
<style>
    .registration-card
    {
        max-width: 600px;
        margin: 2rem auto;
        box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        border-radius: 8px;
    }
    .form-input
    {
        border: 1px solid #e0e0e0;
        transition: border-color 0.3s ease;
    }
    .form-input:focus
    {
        border-color: #007bff;
        box-shadow: none;
    }
    .btn-action
    {
        min-width: 120px;
        letter-spacing: 0.8px;
    }
    .step-title
    {
        color: #2c3e50;
        font-weight: 600;
        margin-bottom: 1.5rem;
    }
</style>
<asp:Panel ID="p3" runat="server" Width="100%" Visible="true">
    <!-- Register.aspx -->
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <!-- 第一步：账户信息 -->
        <asp:View ID="View1" runat="server">
            <h3>
                步骤1/4 - 账户信息</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="21%" height="42" align="right" valign="top">
                        用户名：
                    </td>
                    <td width="79%" align="left" valign="top">
                        <asp:TextBox ID="txtUserName" runat="server" ValidationGroup="baseinfo" onblur="CheckUser5(this.value,'mySpUname');"
                            Width="210px" MaxLength="12"></asp:TextBox>&nbsp;<font color="red">*</font>&nbsp;<span
                                class="font_gray">这是您在本网站的唯一标识,用户名为3-12位的字母、数字、汉字组成。</span><br />
                        <span id="mySpUname"></span>
                        <iframe id="zz" src="about:blank" style="display: none;"></iframe>
                        <script>
                            function CheckUser5(aa, bb) {
                                document.getElementById("zz").src = "/reg.aspx?checkUserName=" + escape(aa);
                            }
                        </script>
                        <%--                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                        <%--                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    正在检测中...........
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        设置登录密码：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPassWord" runat="server" ValidationGroup="baseinfo" TextMode="Password"
                            Width="210px" MaxLength="16"></asp:TextBox>&nbsp;<font color="red">*</font>&nbsp;<span
                                class="font_gray">请输入您的密码，密码必须是字母和数字的组合，确保您的信息安全</span><br />
                        <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtPassWord"
                            ErrorMessage="密码必须是6-16位的字母和数字" ValidationExpression="^[a-zA-Z0-9_]{6,18}$" ValidationGroup="baseinfo"
                            SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        确认登录密码：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtRePassWord" runat="server" ValidationGroup="baseinfo" TextMode="Password"
                            Width="210px" MaxLength="16"></asp:TextBox>&nbsp;<font color="red">*</font>&nbsp;<span
                                class="font_gray">请再次输入登录密码</span><br />
                        <asp:CompareValidator ID="crepassword" runat="server" ErrorMessage="两次输入的密码不一致" ControlToCompare="txtPassWord"
                            ControlToValidate="txtRePassWord" ValidationGroup="baseinfo" SetFocusOnError="True"
                            Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr height="42" align="left" valign="top">
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnNext1" runat="server" Text="下一步" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnNext_Click" CommandArgument="1" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <!-- 第二步：邮箱验证 -->
        <asp:View ID="View2" runat="server">
            <h3>
                步骤2/4 - 邮箱验证</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        密码找回Email：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtEmail" onblur="CheckEmail6(this.value,'mySpUserEmail');" runat="server"
                            ValidationGroup="baseinfo" Width="210px" MaxLength="50"></asp:TextBox>&nbsp;<font
                                color="red">*</font> <span class="font_gray">请输入您最常用的Email地址，忘记密码时可以用该邮箱找回密码</span><br />
                        <span id="mySpUserEmail"></span>
                        <iframe id="eee" src="about:blank" style="display: none;"></iframe>
                        <script>
                            function CheckEmail6(aa, bb) {
                                document.getElementById("eee").src = "/reg.aspx?CheckUserEmail=" + escape(aa);
                            }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        Email验证码：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtEmailCode" runat="server" Width="210px" MaxLength="6"></asp:TextBox>&nbsp;<font
                            color="red">*</font>
                        <input type="button" value="发送验证码" onclick="javascript:tosendEmail();" id="emailButton1">
                        <span class="font_gray" id="Span1"></span>
                        <br />
                        <script type="text/javascript">
                            var daojishi = 0;
                            function tosendEmail() {
                                // 检测是否为360浏览器兼容模式
                                if (navigator.userAgent.indexOf('MSIE') !== -1 ||
			    navigator.userAgent.indexOf('Trident') !== -1 ||
			    (navigator.userAgent.indexOf('360EE') !== -1 && document.documentMode)) {

                                    alert('请切换到极速模式或使用Chrome/Firefox等现代浏览器');
                                    // 或者提供切换浏览器模式的指导
                                } else {



                                    var rs = pro_change("Email");
                                    xianshidaoshiji();
                                }
                            }
                            // 注释
                            function xianshidaoshiji() {
                                document.getElementById("emailButton1").disabled = true;
                                daojishi = 0;

                                setTimeout("sixth()", 1000);
                            }
                            function sixth() {
                                daojishi = daojishi + 1;

                                if (daojishi < 60) {
                                    var ksq = "还剩余" + (60 - daojishi) + "秒";

                                    document.getElementById("emailButton1").value = ksq;
                                    setTimeout("sixth()", 1000);

                                }
                                else {
                                    document.getElementById("emailButton1").disabled = false;
                                    document.getElementById("emailButton1").value = "发送验证码";
                                    document.getElementById("txtEmailCode").readonly = false;
                                }
                            }
                            
                        </script>
                    </td>
                </tr>
                <tr height="42" align="left" valign="top">
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnPrev2" runat="server" Text="上一步" CssClass="btn btn-secondary btn-action rounded-pill"
                            OnClick="btnPrev_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNext2" runat="server" Text="下一步" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnNext_Click" CommandArgument="2" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <!-- 第三步：手机验证 -->
        <asp:View ID="View3" runat="server">
            <h3>
                步骤3/4 - 手机验证</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        手机号码：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtQQ" onblur="CheckMobile7(this.value,'mySpUserMobile');" runat="server"
                            ValidationGroup="baseinfo" Width="210px" MaxLength="11"></asp:TextBox>&nbsp;<font
                                color="red">*</font> <span class="font_gray">请输入11位的手机号码</span><br />
                        <span id="mySpUserMobile"></span>
                        <iframe id="mmm" src="about:blank" style="display: none;"></iframe>
                        <script>
                            function CheckMobile7(aa, bb) {
                                document.getElementById("mmm").src = "/reg.aspx?CheckUserMobile=" + escape(aa);
                            }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        手机验证码：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPhoneCode" runat="server" Width="210px" MaxLength="4"></asp:TextBox>&nbsp;<font
                            color="red">*</font>
                        <input type="button" value="发送验证码" onclick="javascript:tosendSms();" id="yanzhengmabutton">
                        <span class="font_gray" id="ktishi5">当日限发3次，提交出错时验证码可以再次使用</span><br />
                        <iframe name="Runwin" id="Runwin" style="display: none;"></iframe>
                        <script>
                            var daojishi = 0;
                            function tosendSms() {

                                // 检测是否为360浏览器兼容模式
                                if (navigator.userAgent.indexOf('MSIE') !== -1 ||
			    navigator.userAgent.indexOf('Trident') !== -1 ||
			    (navigator.userAgent.indexOf('360EE') !== -1 && document.documentMode)) {

                                    alert('请切换到极速模式或使用Chrome/Firefox等现代浏览器');
                                    // 或者提供切换浏览器模式的指导
                                } else {
                                    var rs = pro_change("Phone");
                                    //xianshidaoshiji();
                                }
                            }

                            function xianshidaoshiji() {
                                document.getElementById("yanzhengmabutton").disabled = true;
                                daojishi = 0;

                                setTimeout("sixth()", 1000);
                            }

                            function sixth() {
                                daojishi = daojishi + 1;

                                if (daojishi < 60) {
                                    var ksq = "还剩余" + (60 - daojishi) + "秒";

                                    document.getElementById("yanzhengmabutton").value = ksq;
                                    setTimeout("sixth()", 1000);

                                }
                                else {
                                    document.getElementById("yanzhengmabutton").disabled = false;
                                    document.getElementById("yanzhengmabutton").value = "发送验证码";
                                    document.getElementById("UcRegBase1_txtQQ").readonly = false;
                                }
                            }
                        </script>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        如果手机接收不到短信，请上班时间致电010-62132803找客服解决
                    </td>
                </tr>
                <tr align="left" height="42" valign="top">
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnPrev3" runat="server" CssClass="btn btn-secondary btn-action rounded-pill"
                            OnClick="btnPrev_Click" Text="上一步" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNext3" runat="server" CommandArgument="3" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnNext_Click" Text="下一步" />
                    </td>
            </table>
        </asp:View>
        <!-- 第四步：安全问题 -->
        <asp:View ID="View4" runat="server">
            <h3>
                步骤4/4 - 密码保护</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        密码提示问题：
                    </td>
                    <td align="left" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="35%">
                                    <asp:UpdatePanel ID="UpPWD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtQuestion" runat="server" Width="210px" Visible="false" MaxLength="100"></asp:TextBox>
                                            <asp:DropDownList ID="ddlPassWordQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPassWordQuestion_SelectedIndexChanged"
                                                Width="217px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 10px">
                                    <font color="red">&nbsp;*</font>
                                </td>
                                <td width="65%" align="left">
                                    <span class="font_gray" id="spQuestionTS" runat="server">&nbsp;请选择您常用的密码问题，以便您在忘记密码后根据问题取回密码
                                    </span>
                                </td>
                            </tr>
                        </table>
                        <%--                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            
                        <asp:TextBox ID="txtQuestion" runat="server" MaxLength="40" Visible="false" onblur="if(this.value==''){document.getElementById('spQuestion').innerHTML='请输入密码提示问题'};" Width="210px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                        <br />
                        <span id="spQuestion" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        密码问题答案：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPassWordAnswer" runat="server" ValidationGroup="baseinfo" Width="210px"
                            MaxLength="100"></asp:TextBox>&nbsp;<font color="red">*</font><asp:RequiredFieldValidator
                                ID="vPasswordanswer" runat="server" ControlToValidate="txtPassWordAnswer" ValidationGroup="baseinfo"
                                SetFocusOnError="True"></asp:RequiredFieldValidator><span class="font_gray">请输入您的密码答案</span><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassWordAnswer"
                            ErrorMessage="密码答案不能为空"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr height="42" align="left" valign="top">
                    <td>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnPrev4" runat="server" Text="上一步" CssClass="btn btn-secondary btn-action rounded-pill"
                            OnClick="btnPrev_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSubmit" Visible="false" runat="server" Text="完成注册" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/Web/U_btn1.jpg" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false" />
    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="1" bgcolor="#ffccff">
            </td>
        </tr>
    </table>
    <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" valign="middle" align="left" class="title1">
                用户注册协议
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
                <asp:TextBox ID="RegeditAgreement" runat="server" Height="200px" TextMode="MultiLine"
                    Width="820" ReadOnly="True" BackColor="White" CssClass="xieyi"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="bottom" align="center" style="height: 50px">
                <!-- OnClick="btnSave_Click"-->
                &nbsp; &nbsp;<asp:ImageButton runat="server" Visible="false" ID="btnDisagree" OnClick="btnDisagree_Click"
                    ImageUrl="~/Images/Web/U_btn2.jpg" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pgaoji" runat="server" Width="100%" Visible="False">
    <table width="962" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin: 13px;
        border: 1px solid #D0E3F9;">
        <tr>
            <td align="center">
                <table width="70%" border="0" cellpadding="2" cellspacing="0" class="MT5">
                    <tr>
                        <td width="7%">
                            <img src="/Images/Web/user_go_li.gif" width="33" height="33" />
                        </td>
                        <td width="93%" class="user_go_zi16">
                            <asp:Label ID="lblNmaeT" runat="server"></asp:Label>
                            注册成功，并且已登录网站！
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="8%">
                            &nbsp;
                        </td>
                        <td width="92%" align="left">
                            您的用户名：<asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            您的电子邮箱：<asp:Label ID="lblUserEmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            升级为高级会员后，您将享受更多的拼搏服务，强烈建议您升级为高级会员。
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="15">
                    <tr>
                        <td width="52%">
                            &nbsp;<asp:ImageButton ID="imbbtn" runat="server" ImageUrl="~/Images/Web/user_go_btn.gif"
                                OnClick="imbbtn_Click" />
                        </td>
                        <td width="48%">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="7%">
                        </td>
                        <td width="93%" align="left">
                            <strong>暂时不升级高级会员，页面跳转到：</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/UserCenter/User_Center.aspx">进入会员中心</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                href="/">回到拼搏首页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://bbs.pinble.com/">去拼搏论坛</a>
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="7%">
                        </td>
                        <td width="93%" align="left">
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Panel>
<%--<asp:Panel ID="p5" runat="server" Width="100%" Visible="False">
    <table style="width: 100%">
        <tr>
            <td style="height: 21px">
                <table cellpadding="3" cellspacing="1" align="center" class="tableborder1">
                    <tr>
                        <td height="24">
                            注册成功：拼搏在线彩神通软件 欢迎您的到来!</td>
                    </tr>
                    <tr>
                        <td style="height: 24px">
                            <div>
                                <span id="spTime">3</span><a href="javascript:countDown(3)"></a>秒后自动跳转…
                            </div>
                            <div>
                                若没有跳转,请手动点击<a href="Default.aspx">首页</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>

<script type="text/javascript">
function countDown(secs){ 
 var sp_Time = document.getElementById("spTime");
 sp_Time.innerText=secs; 
    if(--secs>0){
     setTimeout("countDown("+secs+")",3000); 
     }
     else
     {
     location.href="Default.aspx"
     }
 } 
</script>
--%>
