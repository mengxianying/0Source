<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChangePWD.aspx.cs" Inherits="Pbzx.Web.ChangePWD" %>

<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>更改密码 - 拼搏在线彩票网</title>
    <meta name="keywords" content="彩票 彩票软件 彩神通 3D P3 3D彩票 预测 彩票预测 拼搏 短信 排列三 排列五 双色球 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票  图表 走势图 选号 升级 购买 软件下载 代理 彩票论坛 彩票博客 彩票聊天室 彩票新闻 彩票技巧 中奖 开奖信息 号码 试机号" />
    <meta name="description" content="拼搏在线网站是国内资深的专业彩票网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线将一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩票网www.pinble.com" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/soft.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--header-->
        
                <uc2:Head ID="Head1" runat="server" />         
        
          
                 <table width="750" border="0" align="center" cellpadding="2" cellspacing="0">    
                <tr>
                    <td align="left" valign="bottom" style="height: 70px">
                        <img src="images/Web/ChangPwd_biao.gif" width="180" height="60" /></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCDAF8">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="1" cellpadding="4" cellspacing="0" bordercolor="#FFFFFF">                                 
                                        <tr>
                                            <td align="left" bgcolor="#EDF2FC"> 
                                                &nbsp;<img src="images/Web/l_c_li.gif" width="14" height="14"  vspace="4" align="bottom" />&nbsp;请输入</td>
                                               
                                        </tr>
                                    </table><table width="63%" border="0" align="center" cellpadding="4" cellspacing="0">
                                              <tr>
                                            <td colspan="3" height="12"> </td>
                                        </tr>
                                    <tr>
                            <td width="28%" align="right" valign="top">
                                <span class="red">*</span>您的旧密码:</td>
                            <td width="31%" align="left" valign="top">
                                <asp:TextBox ID="txtOldPWD" runat="server" MaxLength="16" Width="150px" TextMode="Password"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPWD"
                                    ErrorMessage="请输入旧密码"></asp:RequiredFieldValidator></td>
                            <td width="41%" align="left">&nbsp;                                </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <span class="red">*</span>输入新密码:</td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtNewPWD" runat="server" MaxLength="16" Width="150px" TextMode="Password"></asp:TextBox><br />
                                <div id="errNewPwd" class="errMsg">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPWD"
                                        ErrorMessage="请输入新密码"></asp:RequiredFieldValidator></div>
                          </td>
                            <td rowspan="2" align="left" valign="top" class="desc">
                                                                    密码字母有大小写之分，<font color="#d11b00"><b>6～16</b></font>位。限用字母、数字、特殊字符。                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <span class="red">*</span>新密码确认:</td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtConfirmPWD" runat="server" MaxLength="16" Width="150px" TextMode="Password"></asp:TextBox><br />
                                <div id="errNewConfirmPwd" class="errMsg">
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPWD"
                                        ControlToValidate="txtConfirmPWD" ErrorMessage="新密码两次输入不一致"></asp:CompareValidator>&nbsp;</div>
                          </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="red">*</span>请输入右图验证码:</td>
                            <td align="left">
                                <asp:TextBox ID="txtCode" runat="server" MaxLength="25" Width="150px"></asp:TextBox><div
                                    id="errcheckcode" class="errMsg">
                                </div>
                          </td>
                            <td align="left" valign="top">
                                <div id="checkcode">
                                    <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                        id="imgVerify" onclick="this.src=this.src+'?'" height="25" width="80" /><span></span></div>
                          </td>
                        </tr>
                     
                        <tr>
                            <td colspan="3" align="center" class="center">
                            
                          <asp:Button ID="btnUpdate" runat="server" Height="22px" OnClick="btnUpdate_Click"
                                    Text="提交" Width="80px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
									          <tr>
                                            <td colspan="3" height="12"> </td>
                                        </tr>
                                  </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                <td>&nbsp; </td>
                </tr>
            </table>
              
            </div>
            <!-- footer-->

                <uc1:Footer ID="Footer1" runat="server" />
             
    </form>
</body>
<script>GetKDJS();</script>
</html>
