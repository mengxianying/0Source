<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebBaseAdminConfig.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.WebBaseAdminConfig" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站基本配置</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <script src="../../javascript/calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
            <tr bgcolor="#f2f8fb">
                <td background="images/Us_table _bg.jpg">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td background="images/Us_table _bg.jpg" class="webconfigbg">
                                <strong>基本配置</strong>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>网站基本配置：</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                网站地址：
                            </td>
                            <td width="24%" align="left">
                                <asp:TextBox ID="txtWebUrl" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td width="16%" align="right">
                                后台分页每页数：
                            </td>
                            <td width="46%" align="left">
                                每页
                                <asp:TextBox ID="txtWebPageNum" runat="server" Width="120px" MaxLength="4"></asp:TextBox>条（注：请设置数字）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" valign="top">
                                聊彩室地址：
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtChatUrl" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td align="right" valign="top">
                                春节休市起始时间：
                            </td>
                            <td align="left" valign="top">
                                开始
                                <asp:TextBox ID="txtYearStart" runat="server" onfocus="calendar();" Width="120px"></asp:TextBox>
                                －结束<asp:TextBox ID="txtYearEnd" runat="server" onfocus="calendar();" Width="120px"></asp:TextBox>
                                <br />
                                （注：文本框内点击选择时间）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" valign="top">
                                用户填写经纪人后所得返点：
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtUserGet" runat="server" Width="50px"></asp:TextBox>（请输入0－1之间的小数）
                            </td>
                            <td align="right" valign="top">
                                同一IP每天可发送的短信验证码次数：
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TxtIP_ValideCode_Count" runat="server" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" valign="top">
                                下载详情页下载描述：
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TxtDowloadTips" runat="server" Width="220px"></asp:TextBox>
                            </td>
                            <td align="right" valign="top">
                                首页试机号是否显示：
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TxtFirstPageTcodeDisp" runat="server" Width="50px"></asp:TextBox>（0 - 不显示，1 - 显示）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Button2" runat="server" OnClick="btnBaseConfig_Click" Text="保存修改" />
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" style="height: 18px; text-align: left">
                                <strong>密码找回配置管理</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" style="text-align: center">
                                限定找回密码次数：<asp:TextBox ID="txtcount" runat="server" Width="68px"></asp:TextBox>
                            </td>
                            <td colspan="2" style="text-align: center">
                                密码找回间隔：<asp:TextBox ID="txtjg" runat="server" Width="51px"></asp:TextBox>(小时)
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; width: 53px;">
                                限制IP：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:TextBox ID="txtip" runat="server" Height="96px" TextMode="MultiLine" Width="163px"></asp:TextBox>
                            </td>
                            <td style="width: 58px; text-align: center">
                                限制省份：&nbsp;
                            </td>
                            <td style="width: 30px; text-align: center">
                                <asp:TextBox ID="txtsf" runat="server" Height="98px" TextMode="MultiLine" Width="174px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="4">
                                <asp:Button ID="btnok" runat="server" OnClick="btnok_Click" Text="保存修改" Width="75px" />&nbsp;
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />

                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" style="height: 18px; text-align: left">
                                <strong>用户注册限制IP管理</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; width: 53px;">
                                限制IP：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:TextBox ID="txtregistip" runat="server" Height="96px" TextMode="MultiLine" Width="163px"></asp:TextBox>
                            </td>
                            <td style="width: 58px; text-align: center">
                                限制省份：&nbsp;
                            </td>
                            <td style="width: 30px; text-align: center">
                                <asp:TextBox ID="txtregistsf" runat="server" Height="98px" TextMode="MultiLine" Width="174px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="4">
                                <asp:Button ID="btnregist" runat="server" OnClick="btnregist_Click" Text="保存修改" Width="75px" />&nbsp;
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" style="height: 18px; text-align: left">
                                <strong>用户登录限制IP管理</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; width: 53px;">
                                限制IP：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:TextBox ID="txtuserloginip" runat="server" Height="96px" TextMode="MultiLine"
                                    Width="163px"></asp:TextBox>
                            </td>
                            <td style="width: 58px; text-align: center">
                                限制省份：&nbsp;
                            </td>
                            <td style="width: 30px; text-align: center">
                                <asp:TextBox ID="txtuserloginaddress" runat="server" Height="98px" TextMode="MultiLine"
                                    Width="174px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="4">
                                <asp:Button ID="btnuserlogin" runat="server" OnClick="btnuserlogin_Click" Text="保存修改"
                                    Width="75px" />&nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                    
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" style="height: 18px; text-align: left">
                                <strong>用户使用代理ip设置</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; width: 53px;">
                                禁止代理找回密码：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 58px; text-align: center">
                               开奖条件调用设置：
                            </td>
                            <td style="width: 30px; text-align: center">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">开启</asp:ListItem>
                                <asp:ListItem Selected="True" Value="0">关闭</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="4">
                              <asp:Button ID="Button3" runat="server" Text="保存修改"
                                    Width="75px" onclick="Button3_Click" />&nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                    
                    <br />
                      <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" style="height: 18px; text-align: left">
                                <strong>后台登录限制IP管理</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" style="text-align: center">
                                
                            </td>
                            <td colspan="2" style="text-align: center">
                               
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; width: 53px;">
                                登录限制IP：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:TextBox ID="txtloginip" runat="server" Height="96px" TextMode="MultiLine" Width="163px"></asp:TextBox>
                            </td>
                            <td style="width: 58px; text-align: center">
                                限制省份：&nbsp;
                            </td>
                            <td style="width: 30px; text-align: center">
                                <asp:TextBox ID="txtsave" runat="server" Height="98px" TextMode="MultiLine" Width="174px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="4">
                            <asp:Button ID="btn_UserIp" runat="server" Text="保存修改" Width="75px" 
                        onclick="btn_UserIp_Click" />
                                &nbsp;
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="3" style="height: 18px; text-align: left">
                                <strong>注册用户名屏蔽字符</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" style="text-align: center">
                                &nbsp;
                            </td>
                            <td style="text-align: center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center;" class="style1">
                                屏蔽字符：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:TextBox ID="txtuserpb" runat="server" Height="96px" TextMode="MultiLine" Width="426px"></asp:TextBox>
                            </td>
                            <td>
                                (屏蔽字符用逗号分割)
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="3">
                                <asp:Button ID="btnuserpb" runat="server" OnClick="btnuserpb_Click" Text="保存修改" Width="75px" />&nbsp;
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" align="left">
                                <strong>软件基本信息：</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="16%" align="right">
                                软件狗价格：
                            </td>
                            <td width="84%" align="left" bgcolor="#f2f8fb">
                                <asp:TextBox ID="txtSoftdogPrice" runat="server" Width="100px"></asp:TextBox>元
                            </td>
                        </tr>
                        <%-- <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    网络版价格：
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>--%>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="Button1" runat="server" OnClick="btnBaseConfig_Click" Text="保存修改" />
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" style="height: 18px; text-align: left">
                                <strong>首页SEO优化配置</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td >
                                网站关键词：
                            </td>
                            <td>
                                <asp:TextBox ID="keywords" runat="server" Height="96px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="width: 100px;">
                                描述标签：&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="description" runat="server" Height="98px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="width: 100px;">
                                Author标题：&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="author" runat="server" Height="98px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="2">
                                <asp:Button ID="btn_Default" runat="server" Text="保存修改"
                                    Width="75px" onclick="btn_Default_Click" />&nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" align="left">
                                <strong>购物信息配置：</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="16%" align="right">
                                快递公司名称：
                            </td>
                            <td width="84%" align="left" bgcolor="#f2f8fb">
                                <asp:TextBox ID="txtExpress" runat="server" TextMode="MultiLine" Width="300px" Height="60px"></asp:TextBox>（注：多个快递公司名称用
                                ,&nbsp; &nbsp;分割）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" valign="top" bgcolor="#f2f8fb">
                                购物车通知：
                            </td>
                            <td align="left">
                                <FCKeditorV2:FCKeditor ID="weBuy" runat="server" Width="95%" Height="380px">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBaseConfig" runat="server" OnClick="btnBaseConfig_Click" Text="保存修改" />
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="2" align="left">
                                <strong>代理、经纪人注册协议配置：</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="16%" align="right">
                                经纪人注册协议：
                            </td>
                            <td width="84%" align="left" bgcolor="#f2f8fb">
                                <FCKeditorV2:FCKeditor ID="txtBrokerAgreement" runat="server" Width="95%" Height="380px">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" width="16%">
                            </td>
                            <td align="left" bgcolor="#f2f8fb" width="84%">
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" valign="middle" bgcolor="#f2f8fb">
                                代理注册协议：
                            </td>
                            <td align="left">
                                <FCKeditorV2:FCKeditor ID="txtAgentAgreement" runat="server" Width="95%" Height="380px">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnDLJJJ" runat="server" OnClick="btnDLJJJ_Click" Text="保存修改" />
                                &nbsp;&nbsp;&nbsp;
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
