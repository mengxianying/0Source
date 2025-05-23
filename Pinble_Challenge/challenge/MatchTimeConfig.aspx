<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchTimeConfig.aspx.cs" Inherits="Pinble_Challenge.challenge.MatchTimeConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>开奖时间配置 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link type="text/css" rel="stylesheet" href="css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
            <tr bgcolor="#f2f8fb">
                <td background="../images/Us_table _bg.jpg">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td background="../images/Us_table _bg.jpg" class="webconfigbg">
                                <strong>平台开奖时间设置</strong>
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
                                <strong>开奖彩种执行时间设置：</strong>  时间格式：00:00:00
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                福彩3D：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txt_FC3DDataTime" runat="server" Width="60px"></asp:TextBox> 
                            </td>
                            <td width="13%" align="right">
                                双色球：
                            </td>
                            <td width="53%" align="left">
                                <asp:TextBox ID="txt_FCSSDataTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                七乐彩：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_FC7LCTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                排列三五：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_TCPL35DataTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                七星彩：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_TC7XCDataTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                大乐透：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_TCDLTDataTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                执行开奖：(Y:强制执行)
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_LottCompulsory" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                
                            </td>
                            <td align="left">
                              
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                允许执行页面时间：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_ExecutionTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                               
                            </td>
                            <td align="left">
                                
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="height: 28px">
                            </td>
                            <td align="left" colspan="3" style="height: 28px">
                                <asp:Button ID="btnIndex" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                     <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>平台发布信息截止时间设置：</strong>  时间格式：00:00:00 
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                双色球：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txt_ssqEndTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="13%" align="right">
                            福彩3D：
                            </td>
                            <td width="53%" align="left">
                            <asp:TextBox ID="txt_3DEndTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                排列三五：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_plEndTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                               <%-- 七星彩：--%>
                            </td>
                            <td align="left">
                                <%--<asp:TextBox ID="txt_7xcEndTime" runat="server" Width="60px"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                <%--七乐彩：--%>
                            </td>
                            <td align="left">
                                <%--<asp:TextBox ID="txt_7lcEndTIme" runat="server" Width="60px"></asp:TextBox>--%>
                            </td>
                            <td align="right">
                               <%-- 大乐透：--%>
                            </td>
                            <td align="left">
                                <%--<asp:TextBox ID="txt_dltEndTime" runat="server" Width="60px"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="btnEndTime" runat="server" Text="提交修改" 
                                    onclick="btnEndTime_Click"/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>会员中奖所得积分设置：</strong> 
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                红球3胆：
                            </td>
                            <td width="16%" align="left">
                                1胆：<asp:TextBox ID="txt_h3HitOne" runat="server" Width="60px"></asp:TextBox><br />
                                2胆：<asp:TextBox ID="txt_h3HitTwo" runat="server" Width="60px"></asp:TextBox><br />
                                3胆：<asp:TextBox ID="txt_h3HitThree" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="13%" align="right">
                            红球6胆：
                            </td>
                            <td width="53%" align="left">
                            1胆：<asp:TextBox ID="txt_h6HitOne" runat="server" Width="60px"></asp:TextBox><br />
                            2胆：<asp:TextBox ID="txt_h6HitTwo" runat="server" Width="60px"></asp:TextBox><br />
                            3胆：<asp:TextBox ID="txt_h6HitThree" runat="server" Width="60px"></asp:TextBox><br />
                            4胆：<asp:TextBox ID="txt_h6HitFour" runat="server" Width="60px"></asp:TextBox><br />
                            5胆：<asp:TextBox ID="txt_h6HitFive" runat="server" Width="60px"></asp:TextBox><br />
                            6胆：<asp:TextBox ID="txt_h6HitSix" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                杀3红球：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_s3hHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              杀6红球：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_s6hHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              蓝球1胆：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_lHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              蓝球3胆：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_l3Hit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              杀3蓝球：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_s3lHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              杀6蓝球：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_s6lHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              12红+3蓝：
                            </td>
                            <td align="left">
                                6红+1蓝：<asp:TextBox ID="txt_h3l61Hit" runat="server" Width="60px"></asp:TextBox><br />
                                6红+0蓝：<asp:TextBox ID="txt_h3l60Hit" runat="server" Width="60px"></asp:TextBox><br />
                                5红+1蓝：<asp:TextBox ID="txt_h3l51Hit" runat="server" Width="60px"></asp:TextBox><br />
                                5红+0蓝：<asp:TextBox ID="txt_h3l50Hit" runat="server" Width="60px"></asp:TextBox><br />
                                4红+1蓝：<asp:TextBox ID="txt_h3l41Hit" runat="server" Width="60px"></asp:TextBox><br />
                                4红+0蓝：<asp:TextBox ID="txt_h3l40Hit" runat="server" Width="60px"></asp:TextBox><br />
                                3红+1蓝：<asp:TextBox ID="txt_h3l31Hit" runat="server" Width="60px"></asp:TextBox><br />
                                3红+0蓝：<asp:TextBox ID="txt_h3l30Hit" runat="server" Width="60px"></asp:TextBox><br />
                                2红+1蓝：<asp:TextBox ID="txt_h3l21Hit" runat="server" Width="60px"></asp:TextBox><br />
                                2红+0蓝：<asp:TextBox ID="txt_h3l20Hit" runat="server" Width="60px"></asp:TextBox><br />
                                1红+1蓝：<asp:TextBox ID="txt_h3l11Hit" runat="server" Width="60px"></asp:TextBox><br />
                                0红+1蓝：<asp:TextBox ID="txt_h3l01Hit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              9红+2蓝：
                            </td>
                            <td align="left">
                                6红+1蓝：<asp:TextBox ID="txt_h2l61Hit" runat="server" Width="60px"></asp:TextBox><br />
                                6红+0蓝：<asp:TextBox ID="txt_h2l60Hit" runat="server" Width="60px"></asp:TextBox><br />
                                5红+1蓝：<asp:TextBox ID="txt_h2l51Hit" runat="server" Width="60px"></asp:TextBox><br />
                                5红+0蓝：<asp:TextBox ID="txt_h2l50Hit" runat="server" Width="60px"></asp:TextBox><br />
                                4红+1蓝：<asp:TextBox ID="txt_h2l41Hit" runat="server" Width="60px"></asp:TextBox><br />
                                4红+0蓝：<asp:TextBox ID="txt_h2l40Hit" runat="server" Width="60px"></asp:TextBox><br />
                                3红+1蓝：<asp:TextBox ID="txt_h2l31Hit" runat="server" Width="60px"></asp:TextBox><br />
                                3红+0蓝：<asp:TextBox ID="txt_h2l30Hit" runat="server" Width="60px"></asp:TextBox><br />
                                2红+1蓝：<asp:TextBox ID="txt_h2l21Hit" runat="server" Width="60px"></asp:TextBox><br />
                                2红+0蓝：<asp:TextBox ID="txt_h2l20Hit" runat="server" Width="60px"></asp:TextBox><br />
                                1红+1蓝：<asp:TextBox ID="txt_h2l11Hit" runat="server" Width="60px"></asp:TextBox><br />
                                0红+1蓝：<asp:TextBox ID="txt_h2l01Hit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              独胆：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_ddHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              双胆：
                            </td>
                            <td align="left">
                                双胆中1：<asp:TextBox ID="txt_sdHitOne" runat="server" Width="60px"></asp:TextBox><br />
                                双胆中2：<asp:TextBox ID="txt_sdHitTwo" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              组选1注：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_GroupHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              单选1注：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_dirHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              杀1码：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_sMHitOne" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              杀2码：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_sMHitTwo" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              独跨：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_dKHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              独合：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_dhHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              杀1合：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_shHit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              5码：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_m5Hit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              5*5*5定位：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_dw5Hit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                              3*3*3定位：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_dw3Hit" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Button1" runat="server" Text="提交修改" 
                                    onclick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>
        <br />
    </div>
    </form>
</body>
</html>
