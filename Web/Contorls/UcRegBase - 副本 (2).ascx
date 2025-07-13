<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcRegBase.ascx.cs" Inherits="Pbzx.Web.Contorls.UcRegBase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript" src="/javascript/SearchAjax.js"></script>
<script type="text/javascript" src="/js/CrossBrowserHumanCheck.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<script type="text/javascript">
    function pro_change(type) {
        Open_yzm(type);
    }
</script>

    <style type="text/css">
        body {
            font-family: "Microsoft YaHei", "Segoe UI", Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f8fafc;
            color: #1f2937;
        }
        
        .container {
            max-width: 800px;
            margin: 0 auto;
            background: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        
        .header {
            text-align: center;
            margin-bottom: 30px;
        }
        
        .header h1 {
            color: #1f2937;
            margin-bottom: 10px;
        }
        
        .header p {
            color: #6b7280;
            margin: 5px 0;
        }
        
        .browser-badges {
            display: flex;
            justify-content: center;
            gap: 10px;
            margin-top: 15px;
            flex-wrap: wrap;
        }
        
        .badge {
            background: #22c55e;
            color: white;
            padding: 4px 8px;
            border-radius: 12px;
            font-size: 12px;
        }
        
        .demo-section {
            margin: 30px 0;
            padding: 20px;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            background: #f8fafc;
        }
        
        .demo-section h3 {
            margin-top: 0;
            color: #1f2937;
        }
        
        .form-group {
            margin: 15px 0;
        }
        
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        
        .form-control {
            width: 100%;
            max-width: 300px;
            padding: 8px 12px;
            border: 1px solid #e2e8f0;
            border-radius: 4px;
            font-size: 14px;
        }
        
        .btn {
            background: #22c55e;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
            margin: 10px 5px 0 0;
        }
        
        .btn:hover {
            background: #16a34a;
        }

        .btn-primary {
            background: #3b82f6;
        }

        .btn-primary:hover {
            background: #2563eb;
        }

        .verification-buttons {
            display: flex;
            gap: 15px;
            margin-bottom: 10px;
        }

        .verification-status {
            display: flex;
            flex-direction: column;
            gap: 5px;
            margin-top: 10px;
        }

        .status-text {
            font-size: 14px;
            padding: 5px 10px;
            border-radius: 4px;
            background: #f8f9fa;
            border: 1px solid #dee2e6;
        }

        .status-verified {
            background: #d4edda !important;
            border-color: #c3e6cb !important;
            color: #155724;
        }

        /* 遮罩层样式 */
        .modal-overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.6);
            display: flex;
            align-items: center;
            justify-content: center;
            z-index: 1000;
            backdrop-filter: blur(3px);
        }

        .modal-content {
            background: linear-gradient(135deg, #ffffff 0%, #f8fafc 100%);
            border-radius: 12px;
            box-shadow: 
                0 20px 40px rgba(0, 0, 0, 0.15),
                0 10px 20px rgba(0, 0, 0, 0.1),
                inset 0 1px 0 rgba(255, 255, 255, 0.8);
            max-width: 420px;
            width: 90%;
            max-height: 80vh;
            overflow: hidden;
            position: relative;
            border: 1px solid rgba(255, 255, 255, 0.2);
        }



        .modal-body {
            padding: 16px 24px 24px 24px;
        }

        /* 人机验证控件在弹窗中的样式调整 */
        .modal-body .cb-human-check-widget {
            background: transparent;
            border: none;
            box-shadow: none;
            padding: 0;
            margin: 0;
            max-width: none;
        }
        
        .btn-secondary {
            background: #6b7280;
        }
        
        .btn-secondary:hover {
            background: #4b5563;
        }
        
        .result {
            margin-top: 15px;
            padding: 10px;
            border-radius: 4px;
            display: none;
        }
        
        .result.success {
            background: #22c55e;
            color: white;
        }
        
        .result.error {
            background: #ef4444;
            color: white;
        }
        
        .code-example {
            background: #1f2937;
            color: #f8fafc;
            padding: 15px;
            border-radius: 4px;
            margin: 15px 0;
            font-family: "Consolas", "Monaco", monospace;
            font-size: 12px;
            overflow-x: auto;
        }
        
        .feature-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 20px;
            margin: 20px 0;
        }
        
        .feature-card {
            padding: 15px;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            background: white;
        }
        
        .feature-card h4 {
            margin-top: 0;
            color: #22c55e;
        }
        
        .feature-list {
            list-style: none;
            padding: 0;
        }
        
        .feature-list li {
            padding: 3px 0;
            color: #6b7280;
        }
        
        .feature-list li:before {
            content: "• ";
            color: #22c55e;
            font-weight: bold;
        }
    </style>


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

    <style type="text/css">
    /* 遮罩层样式 */
    .modal-overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, 0.6);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 1000;
        backdrop-filter: blur(3px);
    }

    .modal-content {
        background: linear-gradient(135deg, #ffffff 0%, #f8fafc 100%);
        border-radius: 12px;
        box-shadow: 
            0 20px 40px rgba(0, 0, 0, 0.15),
            0 10px 20px rgba(0, 0, 0, 0.1),
            inset 0 1px 0 rgba(255, 255, 255, 0.8);
        max-width: 420px;
        width: 90%;
        max-height: 80vh;
        overflow: hidden;
        position: relative;
        border: 1px solid rgba(255, 255, 255, 0.2);
    }

    .modal-header {
        display: flex;
        justify-content: space-between;
        align-items: flex-start; /* 改为顶部对齐 */
        padding: 16px 20px 8px 20px; /* 减少顶部和底部padding，让内容更靠上 */
        background: transparent;
        min-height: 60px; /* 设置最小高度 */
        position: relative; /* 确保标题和关闭按钮的对齐 */
    }

    .modal-header h3 {
        margin: 0;
        color: #1f2937;
        font-size: 18px;
        font-weight: 600;
        text-shadow: 0 1px 2px rgba(255, 255, 255, 0.8);
        align-self: flex-start; /* 确保标题在顶部 */
        line-height: 1.2; /* 调整行高 */
        padding-top: 2px; /* 微调顶部位置 */
        position: absolute; /* 精确控制顶部位置 */
        left: 20px;
        top: 16px;
    }

    .close-btn {
        font-size: 20px; /* 稍微减小字体大小 */
        color: #6b7280;
        cursor: pointer;
        line-height: 1;
        padding: 6px; /* 减少内边距 */
        background: rgba(255, 255, 255, 0.6);
        border: none;
        border-radius: 50%;
        width: 32px; /* 减小按钮尺寸 */
        height: 32px;
        display: flex;
        align-items: center;
        justify-content: center;
        transition: all 0.2s ease;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        align-self: flex-start; /* 确保按钮在顶部 */
        margin-top: 0; /* 移除顶部边距 */
        flex-shrink: 0; /* 防止按钮收缩 */
        position: absolute; /* 精确控制顶部位置 */
        right: 20px;
        top: 12px;
    }

    .close-btn:hover {
        color: #374151;
        background: rgba(255, 255, 255, 0.9);
        transform: scale(1.05);
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
    }

    .modal-body {
        padding: 8px 24px 24px 24px; /* 减少顶部padding */
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
                        <input type="button" value="发送验证码" onclick="showEmailVerification(); return false;"  id="emailButton1">
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
                        <input type="button" value="发送验证码" onclick="showPhoneVerification(); return false;" id="yanzhengmabutton">
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




       <!-- 邮箱验证遮罩层 -->
       <div id="emailModal" class="modal-overlay" style="display: none;">
           <div class="modal-content">
               <div class="modal-header">
                   <h3>邮箱人机验证</h3>
                   <span class="close-btn" onclick="closeEmailModal()">&times;</span>
               </div>
               <div class="modal-body">
                   <div id="emailHumanCheckContainer" class="human-check-container"></div>
               </div>
           </div>
       </div>



       <!-- 短信验证遮罩层 -->
       <div id="phoneModal" class="modal-overlay" style="display: none;">
           <div class="modal-content">
               <div class="modal-header">
                   <h3>短信人机验证</h3>
                   <span class="close-btn" onclick="closePhoneModal()">&times;</span>
               </div>
               <div class="modal-body">
                   <div id="phoneHumanCheckContainer" class="human-check-container"></div>
               </div>
           </div>
       </div>

<!-- 4. 在页面底部添加弹窗容器 -->


    <!-- 弹窗模式人机验证控件 -->
    <script type="text/javascript">


        // 全局变量存储验证控件实例
        var emailHumanCheck = null;
        var phoneHumanCheck = null;

        // 显示邮箱验证弹窗
        function showEmailVerification() {
            document.getElementById('emailModal').style.display = 'flex';

            // 如果还没有初始化，则创建控件
            if (!emailHumanCheck) {
                try {
                    emailHumanCheck = new CrossBrowserHumanCheck('emailHumanCheckContainer', {
                        onVerificationComplete: function (isVerified) {
                           
                            var statusElement = document.getElementById('emailStatus');
                            if (isVerified) {
                                statusElement.textContent = '邮箱验证：已通过';
                                statusElement.className = 'status-text status-verified';
                                showResult('邮箱人机验证通过！', true);
                                setTimeout(function () {
                                    closeEmailModal();
                                }, 1500);
                            } else {
                                statusElement.textContent = '邮箱验证：验证失败';
                                statusElement.className = 'status-text';
                                showResult('邮箱人机验证失败，请重试！', false);
                            }
                        }
                    });
                } catch (e) {
                    console.error('初始化邮箱验证控件失败:', e);
                    document.getElementById('emailHumanCheckContainer').innerHTML =
                        '<p style="color: red;">人机验证控件加载失败，请刷新页面重试。</p>';
                }
            }
        }

        // 显示短信验证弹窗
        function showPhoneVerification() {
            document.getElementById('phoneModal').style.display = 'flex';

            // 如果还没有初始化，则创建控件
            if (!phoneHumanCheck) {
                try {
                    phoneHumanCheck = new CrossBrowserHumanCheck('phoneHumanCheckContainer', {
                        onVerificationComplete: function (isVerified) {
                          
                            
/*                            var statusElement = document.getElementById('phoneStatus');*/
                            if (isVerified) {
                                //statusElement.textContent = '短信验证：已通过';
                                //statusElement.className = 'status-text status-verified';
                                showResult('短信人机验证通过！', true);
                                setTimeout(function() {
                                    closePhoneModal();
                                }, 1500);
                            } else {
                                //statusElement.textContent = '短信验证：验证失败';
                                //statusElement.className = 'status-text';
                                showResult('短信人机验证失败，请重试！', false);
                            }
                        }
                    });
                } catch (e) {
                    console.error('初始化短信验证控件失败:', e);
                    document.getElementById('phoneHumanCheckContainer').innerHTML = 
                        '<p style="color: red;">人机验证控件加载失败，请刷新页面重试。</p>';
                }
            }
        }

        // 关闭邮箱验证弹窗
        function closeEmailModal() {
            document.getElementById('emailModal').style.display = 'none';
        }

        // 关闭短信验证弹窗
        function closePhoneModal() {
            document.getElementById('phoneModal').style.display = 'none';
        }

        // 点击遮罩层外部关闭弹窗
        document.addEventListener('click', function(event) {
            var emailModal = document.getElementById('emailModal');
            var phoneModal = document.getElementById('phoneModal');
            
            if (event.target === emailModal) {
                closeEmailModal();
            }
            if (event.target === phoneModal) {
                closePhoneModal();
            }
        });

        // 显示结果消息
        function showResult(message, isSuccess) {
            var resultDiv = document.getElementById('resultMessage');
            var labelElement = document.getElementById('<%= lblMessage.ClientID %>');

            if (resultDiv && labelElement) {
                labelElement.innerHTML = message;
                resultDiv.className = 'result ' + (isSuccess ? 'success' : 'error');
                resultDiv.style.display = 'block';

                // 3秒后自动隐藏
                setTimeout(function () {
                    resultDiv.style.display = 'none';
                }, 3000);
            }
        }



        function toSend(type) {

            //start-cghd
            if (type == "Email") {
                var txtEmail = document.getElementById("UcRegBase1_txtEmail").value;
                if (txtEmail != "") {
                    document.getElementById("UcRegBase1_txtEmail").readonly = true;

                    $.get("/reg.aspx", { checkEmail: "checkEmail", email: txtEmail }, function (data) {
                        if (data == "true") {
                            closs();
                            alert("邮件发送成功！");
                        }
                        else {
                            closs();
                            alert(data);
                        }
                    });
                    //xianshidaoshiji();
                }
            }
            else if (type == "Phone") {
                var txtPhone = document.getElementById("UcRegBase1_txtQQ").value;
                if (txtPhone != "") {
                    document.getElementById("UcRegBase1_txtQQ").readonly = true;
                    $.get("/reg.aspx", { checkPhone: "checkPhone", phone: txtPhone }, function (data) {
                        if (data == "true") {
                            closs();
                            alert("验证码发送成功");
                        }
                        else {
                            closs();
                            alert(data);
                        }
                    });
                }
            }
            else if (type == "CheckEmailCode") {
                var txtEmail = document.getElementById("txtEmail").value;
                if (txtPhone != "") {
                    document.getElementById("txtEmail").readonly = true;

                    $.get("/reg.aspx", { CheckEmailCode: "CheckEmailCode", email_RM: txtEmail }, function (data) {
                        if (data == "true") {
                            closs();
                            alert("验证码发送成功");
                        }
                        else {
                            closs();
                            alert(data);
                        }
                    });
                }
            }
            else if (type == "CheckPhone") {
                var txtPhone = document.getElementById("txtQQ").value;
                if (txtPhone != "") {
                    document.getElementById("txtQQ").readonly = true;
                    $.get("/reg.aspx", { CheckPhoneCode: "CheckPhoneCode", phone: txtPhone }, function (data) {
                        if (data == "true") {
                            closs();
                            alert("验证码发送成功");
                        }
                        else {
                            closs();
                            alert(data);
                        }
                    });
                }
            }



            //end-cghd

        }
    </script>

