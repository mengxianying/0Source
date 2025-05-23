<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairMobile.aspx.cs" Inherits="RepairMobile" %>

<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>手机号码验证_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/user.css" rel="stylesheet" type="text/css" />
    <link href="css/verify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function pro_change(type) {
            Open_yzm(type);
        }
    </script>
    <%
    if (Request.Params["act"] != null)
    {
        if (Request.Params["act"].ToString().Trim().Length > 0)
        {
            if (strErrMsg.Length > 0)
            {
    %>
    <script>
        alert("<%=strErrMsg%>");
        //parent.reshuaxin();

    </script>
    <%
            }
            else 
            {
    %>
    <script>
                alert("手机验证提交成功，请重新登录");
                <%
                if(Request.Params["backtorul"]!=null)
                {
                    if(Request.Params["backtorul"].ToString().Trim().Length>0)
                    {
                    %>
                    window.top.location.href = '<%=Request.Params["backtorul"]%>';
                    <%
                    }
                    else
                    {
                    %>
                    window.top.location.href = '/login.aspx';
                    <%  
                    }
                }
                else
                {
                %>
                window.top.location.href = '/login.aspx';
                <%
                }
                %>
                
    </script>
    <%            
            }
        }
    }
    %>
</head>
<body>
    <form id="form1" runat="server">
    <iframe name="_executewnm" id="_executewnm" style="display: none;"></iframe>
    <uc1:Head ID="Head1" runat="server" />
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
        <tr>
            <td style="height: 85px">
                <img src="images/web/MobileVerify.jpg" width="990" height="82" />
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <!-- 第一步：账户信息 -->
        <asp:View ID="View1" runat="server">
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#D0E3F9">
                <tr>
                    <td bgcolor="#F5F9FE">
                        <h3>
                            步骤1/2 - 邮箱验证</h3>
                        <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" height="10">
                                </td>
                            </tr>
                            <tr>
                                <td height="42" align="right" valign="top">
                                    Email邮箱：
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="baseinfo" Width="210px"
                                        Enabled="false" MaxLength="50"></asp:TextBox>&nbsp; <span class="font_gray">
                                    </span>
                                    <br />
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
                                                var rs = pro_change("CheckEmailCode");
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
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnNext2" runat="server" Text="下一步" CssClass="btn btn-primary btn-action rounded-pill"
                                        OnClick="btnNext_Click" CommandArgument="1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <!-- 第二步：邮箱验证 -->
        <asp:View ID="View2" runat="server">
            <h3>
                步骤2/2 - 手机验证</h3>
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#D0E3F9">
                <tr>
                    <td bgcolor="#F5F9FE">
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
                                                var rs = pro_change("CheckPhone");
                                            }
                                            //xianshidaoshiji();
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
                            <tr align="left" height="50" valign="top">
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnPrev3" runat="server" CssClass="btn btn-secondary btn-action rounded-pill"
                                        OnClick="btnPrev_Click" Text="上一步" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnNext3" runat="server" CommandArgument="3" CssClass="btn btn-primary btn-action rounded-pill loginbtn"
                                        OnClick="btnSave_Click" Text="提交" Width="60px" Height="30px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<script>
    function btnSave_Click() {
        var fobj = document.act_form;
        if (fobj.upass.value != "" && fobj.UID.value != "" && fobj.txtQQ.value != "" && fobj.TextBox1.value != "" && fobj.txtMSN.value != "") {
            document.act_form.submit();
        }
        else {
            alert("请填写完整");
        }

    }
</script>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
