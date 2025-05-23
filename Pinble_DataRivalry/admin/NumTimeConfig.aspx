<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumTimeConfig.aspx.cs" Inherits="Pinble_DataRivalry.admin.NumTimeConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>开奖时间配置 - 大底比拼 - 拼搏在线彩神通软件</title>
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
                                <strong>开奖彩种执行时间设置</strong>
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
                                执行开奖：(Y:强制执行,默认为N)
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txt_LottCompulsory" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                               <%-- 热点论坛：--%>
                            </td>
                            <td align="left">
                                <%--<asp:TextBox ID="txtBbs" runat="server" Width="60px"></asp:TextBox>--%>
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
                                <%--图片链接：--%>
                            </td>
                            <td align="left">
                              <%--  <asp:TextBox ID="LinkCountPic" runat="server" Width="60px"></asp:TextBox>--%>
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
                                <strong>上传下载配置设置：</strong>  
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="">
                                &nbsp;</td>
                            <td width="16%" align="right">
                                金币下载：</td>
                            <td width="23%" align="left">
                            
                                <asp:RadioButtonList ID="rbl_yn" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">金币下载</asp:ListItem>
                                <asp:ListItem Value="2" Selected="True">免费下载</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td width="53%" align="left">
                               
                                    
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                               单选大底上传范围：
                            </td>
                            <td align="left">
                            最小注数：   <asp:TextBox ID="txt_LeastRange" runat="server" Width="60px"></asp:TextBox><br />   
                            最大注数：  <asp:TextBox ID="txt_MaximumRange" runat="server" Width="60px"></asp:TextBox> 
                            </td>
                            <td align="right">
                              组选大底上传范围：
                            </td>
                            <td align="left">
                            最小注数：  <asp:TextBox ID="tLeastRange" runat="server" Width="60px"></asp:TextBox><br />   
                            最大注数：  <asp:TextBox ID="tMaximumRange" runat="server" Width="60px"></asp:TextBox> 
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" rowspan="3">
                            基数设置 (1000底基数)
                                </td>
                            <td align="left" rowspan="3">
                               2D基数：<asp:TextBox ID="txt_InTwo" runat="server" Width="60px"></asp:TextBox><br />   
                               1D基数：<asp:TextBox ID="txt_InOne" runat="server" Width="60px"></asp:TextBox><br /> 
                               0D基数：<asp:TextBox ID="txt_InZero" runat="server" Width="60px"></asp:TextBox>
                               </td>
                            <td align="right">
                                基数设置 (组6设置)
                                </td>
                            <td align="left">
                                2D基数：<asp:TextBox ID="tInTwo" runat="server" Width="60px"></asp:TextBox><br />   
                               1D基数：<asp:TextBox ID="tInOne" runat="server" Width="60px"></asp:TextBox><br /> 
                               0D基数：<asp:TextBox ID="tInZero" runat="server" Width="60px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                 基数设置 (组3设置)</td>
                            <td align="left">
                               2D基数：<asp:TextBox ID="tInTwozt" runat="server" Width="60px"></asp:TextBox><br />   
                               1D基数：<asp:TextBox ID="tInOnezt" runat="server" Width="60px"></asp:TextBox><br /> 
                               0D基数：<asp:TextBox ID="tInZerozt" runat="server" Width="60px"></asp:TextBox>
                               </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                  基数设置 (豹子设置)</td>
                            <td align="left">
                               2D基数：<asp:TextBox ID="tInTwobz" runat="server" Width="60px"></asp:TextBox><br />   
                               1D基数：<asp:TextBox ID="tInOnebz" runat="server" Width="60px"></asp:TextBox><br /> 
                               0D基数：<asp:TextBox ID="tInZerobz" runat="server" Width="60px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                积分设置：
                                </td>
                            <td align="left">
                               2D积分：<asp:TextBox ID="txt_IntegralTwo" runat="server" Width="60px"></asp:TextBox><br /> 
                               1D积分：<asp:TextBox ID="txt_IntegralOne" runat="server" Width="60px"></asp:TextBox><br />  
                               0D积分：<asp:TextBox ID="txt_IntegralZero" runat="server" Width="60px"></asp:TextBox><br /> 
                               全中：<asp:TextBox ID="txt_IntegralGroup" runat="server" Width="60px"></asp:TextBox> 
                               </td>
                            <td align="right">
                                积分设置：
                                </td>
                            <td align="left">
                                2D积分：<asp:TextBox ID="tIntegralTwo" runat="server" Width="60px"></asp:TextBox><br /> 
                               1D积分：<asp:TextBox ID="tIntegralOne" runat="server" Width="60px"></asp:TextBox><br />  
                               0D积分：<asp:TextBox ID="tIntegralZero" runat="server" Width="60px"></asp:TextBox> <br /> 
                               全中：<asp:TextBox ID="tIntegralGroup" runat="server" Width="60px"></asp:TextBox> 
                                </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                              获得金币设置：
                                </td>
                            <td align="left">
                               2D金币：<asp:TextBox ID="txt_CoinTwo" runat="server" Width="60px"></asp:TextBox><br /> 
                               1D金币：<asp:TextBox ID="txt_CoinOne" runat="server" Width="60px"></asp:TextBox><br />  
                               0D金币：<asp:TextBox ID="txt_CoinZero" runat="server" Width="60px"></asp:TextBox><br />
                               全中：<asp:TextBox ID="txt_CoinGroup" runat="server" Width="60px"></asp:TextBox> 
                                </td>
                            <td align="right">
                                获得金币设置：
                                </td>
                            <td align="left">
                                 2D金币：<asp:TextBox ID="tCoinTwo" runat="server" Width="60px"></asp:TextBox><br /> 
                               1D金币：<asp:TextBox ID="tCoinOne" runat="server" Width="60px"></asp:TextBox><br />  
                               0D金币：<asp:TextBox ID="tCoinZero" runat="server" Width="60px"></asp:TextBox><br />
                               全中：<asp:TextBox ID="tCoinGroup" runat="server" Width="60px"></asp:TextBox> 
                                </td>
                        </tr>
                          
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                            设置上下限(按大底百分比)：
                               </td>
                            <td align="left">
                                2D上限：<asp:TextBox ID="txt_InTwoUpperlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                2D下限：<asp:TextBox ID="txt_InTwoLowerlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                -------------------<br />
                                1D上限：<asp:TextBox ID="txt_InOneUpperlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                1D下限：<asp:TextBox ID="txt_InOneLowerlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                -------------------<br />
                                0D上限：<asp:TextBox ID="txt_InZeroUpperlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                0D下限：<asp:TextBox ID="txt_InZeroLowerlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                               </td>
                            <td align="right">
                                设置上下限（按大底百分比）：</td>
                            <td align="left">
                                2D上限：<asp:TextBox ID="tInTwoUpperlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                2D下限：<asp:TextBox ID="tInTwoLowerlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                -------------------<br />
                                1D上限：<asp:TextBox ID="tInOneUpperlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                1D下限：<asp:TextBox ID="tInOneLowerlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                -------------------<br />
                                0D上限：<asp:TextBox ID="tInZeroUpperlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                                0D下限：<asp:TextBox ID="tInZeroLowerlimit" runat="server" Width="60px"></asp:TextBox>%<br /> 
                               </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btn_scope" runat="server" Text="提交修改" 
                                    onclick="btn_scope_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                              <asp:Button ID="btn_group" runat="server" Text="提交修改" 
                                    onclick="btn_group_Click" />
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
