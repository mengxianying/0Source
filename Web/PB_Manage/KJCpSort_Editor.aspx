<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KJCpSort_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.KJCpSort_Editor" EnableEventValidation="false" %>

<html>
<head runat="server">
    <title>开奖彩种</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript">
        function AddList()
        {
            var txt1 = document.getElementById('txtTimeList').value.trim() ;
            if(txt1.length > 0)
            {
                document.getElementById('txtTimeList').value += "&"+document.getElementById('txtTempResult').value;
            } 
            else
            {
                document.getElementById('txtTimeList').value =document.getElementById('txtTempResult').value;
            } 
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="CENTER">
                                <a href="KJCpSort_Manage.aspx" class="zilan">开奖彩种管理</a> | <a href="KJCpSort_Editor.aspx"
                                    class="zilan">添加开奖彩种</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr>
                <td bgcolor="#F3F3F3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td width="91%" align="left">
                                            当前位置：
                                            <asp:Label ID="lblAction" runat="server"></asp:Label>开奖彩种</td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpCpSort" runat="server">
                        <ContentTemplate>
                            <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" width="15%">
                                        彩种名称：</td>
                                    <td width="85%">
                                        <asp:TextBox ID="txtNvarName" runat="server" Width="150px" MaxLength="30"></asp:TextBox><span
                                            style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        彩种类别：</td>
                                    <td>
                                        <asp:DropDownList ID="ddlNvarClass" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        所属类别排序编号：</td>
                                    <td>
                                        <asp:TextBox ID="txtIntClass_OrderId" runat="server" Width="150px" MaxLength="30"></asp:TextBox><span
                                            style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td align="right" class="bold">
                                        本类别内排序编号：</td>
                                    <td>
                                        <asp:TextBox ID="txtNvarOrderId" runat="server" MaxLength="30" Width="150px"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        前台是否显示：</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rblBitIs_show" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                            <asp:ListItem Value="0">否</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        是否刷新：</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rblIsRefresh" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                            <asp:ListItem Value="0">否</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        程序调用数字：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtIntCase" runat="server" Width="68px" MaxLength="30"></asp:TextBox>
                                        <span style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        数据库表名称：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNvarApp_name" runat="server" Width="150px" MaxLength="30"></asp:TextBox><span
                                            style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        刷新时间间隔：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNvarLott_date" runat="server" Width="150px" MaxLength="30"></asp:TextBox><span
                                            style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold" align="right">
                                        期号长度：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtIssueLen" runat="server" Width="150px" MaxLength="2"></asp:TextBox><span
                                            style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td align="right" class="bold">
                                        期号类型信息：</td>
                                    <td align="left">
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    日期部分：
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblIssueY" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="yyyy">4位年</asp:ListItem>
                                                        <asp:ListItem Value="yy">2位年</asp:ListItem>
                                                        <asp:ListItem Value="">无</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblIssueM" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="MM">2位月</asp:ListItem>
                                                        <asp:ListItem Value="">无</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblIssueD" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="dd">2位日</asp:ListItem>
                                                        <asp:ListItem Value="">无</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    流水号1：
                                                </td>
                                                <td>
                                                    &nbsp;<asp:TextBox ID="txtLSH" runat="server" MaxLength="2" Width="30px">2</asp:TextBox>位<span
                                                        style="color: #ff0000">*（请输入数字）</span></td>
                                                <td>
                                                    &nbsp;流水号2：</td>
                                                <td>
                                                    &nbsp;<asp:TextBox ID="txtLSH2" runat="server" MaxLength="2" Width="30px">0</asp:TextBox>位</td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    流水号清空时间：</td>
                                                <td>
                                                    <asp:CheckBoxList ID="chbClear" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="日">每天</asp:ListItem>
                                                        <asp:ListItem Value="年">每年</asp:ListItem>
                                                    </asp:CheckBoxList></td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                        每日开奖次数：
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDayLottCount" runat="server" Width="150px" Text="1" MaxLength="30"></asp:TextBox><span
                                            style="color: #ff0000">*</span><asp:Button ID="btnCal" runat="server" Text="根据时间序列计算"
                                                OnClick="btnCal_Click" />
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" style="height: 47px" align="right">
                                        开奖时间序列：
                                    </td>
                                    <td align="left" style="height: 47px">
                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td align="center">
                                                    <asp:TextBox ID="txtTimeList" runat="server" Font-Bold="True" Height="170px" TextMode="MultiLine"
                                                        Width="170px" MaxLength="8000"></asp:TextBox><br />
                                                    <input type="button" value="清空" onclick="document.getElementById('txtTimeList').value=''"
                                                        style="width: 57px" />
                                                </td>
                                                <td valign="top" align="left">
                                                    <table width="100%" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <table width="100%">
                                                                    <tr align="center">
                                                                        <td colspan="3">
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序列计算器：</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="14%" align="right">
                                                                            开始时间：</td>
                                                                        <td width="36%" align="left">
                                                                            <asp:TextBox ID="txtStart" runat="server" onkeyup='CheckCode(this,"txtEnd",4)' Width="120px"
                                                                                MaxLength="30"></asp:TextBox></td>
                                                                        <td width="50%" rowspan="4" align="left">
                                                                            <asp:TextBox ID="txtTempResult" runat="server" Font-Bold="True" Height="170px" TextMode="MultiLine"
                                                                                Width="170px" onfocus="javascript:this.select()" MaxLength="800"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            结束时间：</td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtEnd" runat="server" onkeyup='CheckCode(this,"txtJG",4)' Width="120px"
                                                                                MaxLength="30"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            时间间隔：</td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtJG" runat="server" onkeyup='CheckCode(this,"btnCalc",2)' Width="44px"
                                                                                MaxLength="30"></asp:TextBox>分钟<span style="color: #ff0000">（填写数字）</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:Button ID="btnCalc" runat="server" Text="计算" OnClick="btnCalc_Click" />
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" runat="server" Text="清空" OnClick="btnClear_Click" /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <input id="btnZhuan" type="button" value="<<转过" style="width: 69" onclick="AddList();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <span style="color: #ff0000">注：（此序列只对高频彩种有效，分段时间序列之间用'&'符号分割）</span>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                        号码类型信息：</td>
                                    <td align="left">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 100%" valign="top">
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                        <tr valign="top">
                                                            <td width="45%" valign="top">
                                                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                    <tr>
                                                                        <td colspan="2" style="height: 22px">
                                                                            <strong>类型1：</strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            彩票类型：</td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlCpType1" runat="server" Width="110px" OnSelectedIndexChanged="ddlCpType1_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Selected="True">数字型</asp:ListItem>
                                                                                <asp:ListItem>乐透型</asp:ListItem>
                                                                                <asp:ListItem>扑克型</asp:ListItem>
                                                                                <asp:ListItem>扑克3型</asp:ListItem>
                                                                                <asp:ListItem>按位乐透型</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            类型名：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <span style="color: #ff0000">
                                                                                <asp:DropDownList ID="ddlCodeTypeName1" runat="server" Width="110px">
                                                                                    <asp:ListItem Selected="True">开奖号码</asp:ListItem>
                                                                                    <asp:ListItem>基本号码</asp:ListItem>
                                                                                    <asp:ListItem>特别号码</asp:ListItem>
                                                                                    <asp:ListItem>红球</asp:ListItem>
                                                                                    <asp:ListItem>蓝球</asp:ListItem>
                                                                                    <asp:ListItem>前区号码</asp:ListItem>
                                                                                    <asp:ListItem>排列5</asp:ListItem>
                                                                                </asp:DropDownList></span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            号码个数：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <span style="color: #ff0000">
                                                                                <asp:DropDownList ID="ddlCodeCount1" runat="server" Width="110px">
                                                                                    <asp:ListItem Selected="True">1</asp:ListItem>
                                                                                    <asp:ListItem>2</asp:ListItem>
                                                                                    <asp:ListItem>3</asp:ListItem>
                                                                                    <asp:ListItem>4</asp:ListItem>
                                                                                    <asp:ListItem>5</asp:ListItem>
                                                                                    <asp:ListItem>6</asp:ListItem>
                                                                                    <asp:ListItem>7</asp:ListItem>
                                                                                    <asp:ListItem>8</asp:ListItem>
                                                                                    <asp:ListItem>9</asp:ListItem>
                                                                                    <asp:ListItem>10</asp:ListItem>
                                                                                    <asp:ListItem>11</asp:ListItem>
                                                                                    <asp:ListItem>12</asp:ListItem>
                                                                                    <asp:ListItem>13</asp:ListItem>
                                                                                    <asp:ListItem>14</asp:ListItem>
                                                                                    <asp:ListItem>15</asp:ListItem>
                                                                                    <asp:ListItem>16</asp:ListItem>
                                                                                    <asp:ListItem>17</asp:ListItem>
                                                                                    <asp:ListItem>18</asp:ListItem>
                                                                                    <asp:ListItem>19</asp:ListItem>
                                                                                    <asp:ListItem>20</asp:ListItem>
                                                                                </asp:DropDownList></span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            最小号码：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <span style="color: #ff0000">
                                                                                <asp:DropDownList ID="ddlMinCode1" runat="server" Width="110px">
                                                                                    <asp:ListItem Selected="True">0</asp:ListItem>
                                                                                    <asp:ListItem>1</asp:ListItem>
                                                                                </asp:DropDownList></span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            最大号码：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:TextBox ID="txtMaxCode1" runat="server" Width="110px" MaxLength="20"></asp:TextBox><span
                                                                                style="color: #ff0000">*</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            字段名：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:TextBox ID="txtCodeZD1" runat="server" Width="110px" MaxLength="20">code</asp:TextBox><span
                                                                                style="color: #ff0000">*</span></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td width="55%">
                                                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <strong>类型2：</strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            彩票类型：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:DropDownList ID="ddlCpType2" runat="server" Width="110px" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlCpType2_SelectedIndexChanged">
                                                                                <asp:ListItem Selected="True">数字型</asp:ListItem>
                                                                                <asp:ListItem>乐透型</asp:ListItem>
                                                                                <asp:ListItem>按位乐透型</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            类型名：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:DropDownList ID="ddlCodeTypeName2" runat="server" Width="110px">
                                                                                <asp:ListItem Selected="True">开奖号码</asp:ListItem>
                                                                                <asp:ListItem>基本号码</asp:ListItem>
                                                                                <asp:ListItem>特别号码</asp:ListItem>
                                                                                <asp:ListItem>红球</asp:ListItem>
                                                                                <asp:ListItem>蓝球</asp:ListItem>
                                                                                <asp:ListItem>后区号码</asp:ListItem>
                                                                                <asp:ListItem>排列3</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            号码个数：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:DropDownList ID="ddlCodeCount2" runat="server" Width="110px">
                                                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                                                <asp:ListItem>2</asp:ListItem>
                                                                                <asp:ListItem>3</asp:ListItem>
                                                                                <asp:ListItem>4</asp:ListItem>
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>6</asp:ListItem>
                                                                                <asp:ListItem>7</asp:ListItem>
                                                                                <asp:ListItem>8</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            最小号码：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:DropDownList ID="ddlMinCode2" runat="server" Width="110px">
                                                                                <asp:ListItem Selected="True">0</asp:ListItem>
                                                                                <asp:ListItem>1</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            最大号码：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:TextBox ID="txtMaxCode2" runat="server" Width="110px" MaxLength="20"></asp:TextBox><span
                                                                                style="color: #ff0000"></span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            字段名：</td>
                                                                        <td align="left" style="width: 70%">
                                                                            <asp:TextBox ID="txtCodeZD2" runat="server" Width="110px" MaxLength="20"></asp:TextBox><span
                                                                                style="color: #ff0000"><span style="color: #000000">(格式：tcode)</span></span></td>
                                                                    </tr>
                                                                </table>
                                                                <span style="color: #ff0000">注：类型2最大号码和字段名都填写才会记录类型2</span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td align="right" class="bold">
                                        后台此彩种调用地址：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtUrl" runat="server" Width="400px" MaxLength="100"></asp:TextBox><span
                                            style="color: #ff0000">*</span><span style="color: #ff0000">（后台此彩种开奖信息调用地址）</span></td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                        开奖网址1：</td>
                                    <td align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="10%" align="right">
                                                    网站名称：</td>
                                                <td width="22%" align="left">
                                                    <asp:TextBox ID="txtWebSiteName1" runat="server" Text="网址一" Width="100" MaxLength="20"></asp:TextBox><span
                                                        style="color: #ff0000">*</span></td>
                                                <td width="12%" align="right">
                                                    &nbsp;url地址：</td>
                                                <td width="56%">
                                                    <asp:TextBox ID="txtWebSite1" runat="server" Width="320px" MaxLength="200"></asp:TextBox><span
                                                        style="color: #ff0000">*</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                        开奖网址2：</td>
                                    <td align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="10%" align="right">
                                                    网站名称：</td>
                                                <td width="22%">
                                                    <asp:TextBox ID="txtWebSiteName2" runat="server" Text="网址二" Width="100" MaxLength="20"></asp:TextBox></td>
                                                <td width="12%" align="right">
                                                    &nbsp;url地址：</td>
                                                <td width="56%" align="left">
                                                    <asp:TextBox ID="txtWebSite2" runat="server" Width="320px" MaxLength="200"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                        开奖网址3：</td>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="10%" align="right">
                                                    网站名称：</td>
                                                <td width="22%">
                                                    <asp:TextBox ID="txtWebSiteName3" Width="100" runat="server" Text="网址三" MaxLength="20"></asp:TextBox></td>
                                                <td width="12%" align="right">
                                                    &nbsp;url地址：</td>
                                                <td width="56%" align="left">
                                                    <asp:TextBox ID="txtWebSite3" runat="server" Width="320px" MaxLength="200"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                        开奖网址4：</td>
                                    <td align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="10%" align="right">
                                                    网站名称：</td>
                                                <td width="22%">
                                                    <asp:TextBox ID="txtWebSiteName4" runat="server" Text="网址四" Width="100" MaxLength="20"></asp:TextBox></td>
                                                <td height="12%" align="right">
                                                    &nbsp;url地址：</td>
                                                <td width="56%" align="left">
                                                    <asp:TextBox ID="txtWebSite4" runat="server" Width="320px" MaxLength="200"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td align="right" class="bold">
                                        备注：</td>
                                    <td align="left">
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Height="120px" MaxLength="400"
                                            onfocus="javascript:this.select()" TextMode="MultiLine" Width="560px"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#f2f8fb">
                                    <td class="bold" align="right">
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <table style="width: 100%">
                        <tr bgcolor="#F2F8FB">
                            <td colspan="2" align="center" style="height: 30px">
                                <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                                <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
