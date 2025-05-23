<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChatChangeInfo.aspx.cs"
    Inherits="Pbzx.Web.ChatChangeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head runat="server">
    <title>聊彩室个人资料修改_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
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
       function shuaxin(){
            location.reload();
       }
       var num = window.setTimeout("shuaxin()",1000);
       window.clearTimeout(num);
    </script>

</head>
<body style="margin: 0; padding: 0;">
    <form id="regist" runat="server">
       <table width="400" border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr>
                        <td valign="top" background="Images/Web/Regist_topbg.jpg" style="height: 45px">
                            <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td height="36" align="right" class="font_red">
                                        带 * 号为必须填写项目</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="400" border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr>
                        <td background="Images/Web/Regist_centerbg.jpg">
                            <table width="88%" border="0" align="center" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td width="27%" class="regist_title">
                                        呢 称:</td>
                                    <td width="73%" align="left">
                                        <font color="red"><b>
                                            <!--$UserName-->
                                            <asp:Label ID="lblUName" runat="server" Text=""></asp:Label>
                                        </b></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="regist_title">
                                        年龄:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAge" runat="server" MaxLength="5" Width="65px"></asp:TextBox><span
                                            class="font_red">*</span></td>
                                </tr>
                                <tr>
                                    <td class="regist_title">
                                        真实性别:</td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td valign="middle">
                                                    <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                                        <asp:ListItem Value="0">女</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <span class="font_red">*</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%--  <tr>
                                        <td class="regist_title">
                                            邮件地址:</td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                                    </tr>--%>
                                <tr>
                                    <td class="regist_title">
                                        Oicq:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQicq" runat="server" MaxLength="50" Width="118px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td valign="top" class="regist_title">
                                        头像:</td>
                                    <td align="left">
                                        <asp:Image ID="imgPhoto" runat="server" />
                                        <asp:HiddenField ID="hfImg" runat="server" />
                                        <span class="regist_head"><a href="javascript:OnSelectIcon();">选择头像</a></td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <span class="regist_title">个人简介 / 爱好兴趣 (方便网友查询)</span><br>
                                        <asp:TextBox ID="txtResume" runat="server" Height="50px" TextMode="MultiLine" Width="300px"
                                            MaxLength="100"></asp:TextBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnUpdate" runat="server" Text="更新资料" OnClick="btnUpdate_Click" />&nbsp;<input
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
                            <img src="Images/Web/Regist_btbg.jpg" width="400" height="25"></td>
                    </tr>
                </table>
    </form>
</body>
</html>
