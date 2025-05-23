<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChatRegister.aspx.cs" Inherits="Pbzx.Web.ChatRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>聊彩室个人资料修改 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩神通软件www.pinble.com" />

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <style type="text/css">
<!--
.regist_title{
	color: #0045A2;
	font-size: 12px;
	line-height: 170%;
	font-weight: 600;
	text-align: right;
}
.font_red{
	color: #FF0000;
}
.font_gray{
	color: #666666;
}
td {
	font-family: "宋体";
	font-size: 12px;
	line-height: 170%;
	color: #0F0F0F;
}
-->
    </style>

    <script type="text/javascript" language="javascript">
        function OnSelectIcon()
        {
	        //window.open("../selecticon01.htm", "select", "toolbar=no,location=no,directories=no,menubar=no,resizable=yes") ;
	        //window.open("../selecticon01.htm", "select", "toolbar=no,location=no,directories=no,menubar=no,resizable=yes") ;\
	        var imgUrl = window.showModalDialog("/selecticon01.htm", "main", "toolbar=no,location=no,directories=no,menubar=no,resizable=yes,width=600,height=200") ;	
	        if(imgUrl > 0)
	        {	        
	            document.getElementById("imgPhoto").src= "icon/"+imgUrl+".gif";
	            document.getElementById("hfImg").value= "icon/"+imgUrl+".gif";
	        }
        }
    </script>

</head>
<body style="margin: 0; padding: 0;">
    <form id="regist" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upChartReg" runat="server">
            <ContentTemplate>
                <div align="center">
                    <table width="400" border="0" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td height="53" valign="top" background="/Images/Web/Regist_topbg.jpg">
                                <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td height="36" align="right" class="font_red">
                                            带 * 号为必须填写项目</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="400" border="0" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td background="/Images/Web/Regist_centerbg.jpg">
                                <table width="88%" border="0" align="center" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td width="27%" class="regist_title">
                                            用户名:</td>
                                        <td width="73%" align="left">
                                            <font color="red">
                                                <!--$UserName-->
                                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="12" Width="135px" onblur="CheckUser(this.value,'mySpUname');">
                                                </asp:TextBox>*</font></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title" width="27%">
                                        </td>
                                        <td align="left" width="73%">
                                            <span id="mySpUname"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title" width="27%">
                                            密码:</td>
                                        <td align="left" width="73%">
                                            <asp:TextBox ID="txtPassWord" runat="server" MaxLength="18" Width="135px" TextMode="Password">
                                            </asp:TextBox><span style="color: #ff0000">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title" width="27%">
                                        </td>
                                        <td align="left" width="73%">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord"
                                                Display="Dynamic" ErrorMessage="密码不能为空">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtPassWord"
                                                ErrorMessage="密码必须是6-16位的字母和数字" ValidationExpression="^[a-zA-Z0-9_]{6,18}$" ValidationGroup="baseinfo"
                                                SetFocusOnError="True" Display="Dynamic">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title" width="27%">
                                            确认:</td>
                                        <td align="left" width="73%">
                                            <asp:TextBox ID="txtRePassWord" runat="server" MaxLength="18" Width="135px" TextMode="Password">
                                            </asp:TextBox><span style="color: #ff0000">*</span> <span class="font_gray">请重新输入密码</span></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title" width="27%">
                                        </td>
                                        <td align="left" width="73%">
                                            <asp:CompareValidator ID="crepassword" runat="server" ErrorMessage="两次输入的密码不一致" ControlToCompare="txtPassWord"
                                                ControlToValidate="txtRePassWord" ValidationGroup="baseinfo" SetFocusOnError="True"
                                                Display="Dynamic">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                            年龄:</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAge" runat="server" MaxLength="3" Width="43px">
                                            </asp:TextBox><span class="font_red">*<span style="color: #0f0f0f"> </span><span
                                                class="font_gray">请输入数字</span></span></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="年龄不能为空"
                                                ControlToValidate="txtAge" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="年龄请输入数字"
                                                ValidationExpression="^[0-9]+$" ControlToValidate="txtAge" Display="Dynamic">
                                            </asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                            真实性别:</td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSex_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                                <asp:ListItem Value="0">女</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <%--  <tr>
                                        <td class="regist_title">
                                            邮件地址:</td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                                    </tr>--%>
                                    <tr>
                                        <td class="regist_title">
                                            邮件地址</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" onblur="CheckEmail(this.value,'mySpUserEmail');"
                                                MaxLength="50" Width="135px">
                                            </asp:TextBox><span style="color: #ff0000">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                        </td>
                                        <td align="left">
                                            <span id="mySpUserEmail"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                            Oicq:</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtOicq" runat="server" MaxLength="30" Width="135px">
                                            </asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                            找密码问题:</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPassWordQuestion" runat="server">
                                            </asp:DropDownList><span style="color: #ff0000">*</span></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                            答案:</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPassWordAnswer" runat="server" MaxLength="50" ValidationGroup="baseinfo"
                                                Width="210px">
                                            </asp:TextBox><span style="color: #ff0000">*</span></td>
                                    </tr>
                                    <tr>
                                        <td class="regist_title">
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassWordAnswer"
                                                ErrorMessage="密码答案不能为空" Display="Dynamic">
                                            </asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="regist_title">
                                            头像:</td>
                                        <td align="left">
                                            <asp:Image ID="imgPhoto" runat="server" ImageUrl="icon/1.gif" />
                                            <asp:HiddenField ID="hfImg" runat="server" Value="icon/1.gif" />
                                            <span class="regist_head"><a href="javascript:OnSelectIcon();">选择头像</a></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <span class="regist_title">个人简介 / 爱好兴趣 (方便网友查询)</span><br>
                                            <asp:TextBox ID="txtResume" runat="server" Height="50px" TextMode="MultiLine" Width="300px"
                                                MaxLength="100">
                                            </asp:TextBox>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnReg" runat="server" Text="开始注册" OnClick="btnReg_Click" />&nbsp;<input
                                                name="button1" type="button" class="regist_btnbg" onclick="window.close();" value="关闭窗口">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="400" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="/Images/Web/Regist_btbg.jpg" width="400" height="25"></td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
