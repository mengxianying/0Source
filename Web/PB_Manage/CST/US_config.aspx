<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_config.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_config" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/PB_Manage/Controls/Uc_menu.ascx" TagName="Uc_menu" TagPrefix="uc1" %>
<html>
<head runat="server">
    <title>配置信息管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：配置信息管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <uc1:Uc_menu ID="Uc_menu1" runat="server"></uc1:Uc_menu>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT" style="word-break: break-all; word-wrap: break-word">
                <tr bgcolor="#F1F1F1">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            Width="100%" DataKeyNames="ID" CssClass="GridView_Table" HorizontalAlign="Center"
                            OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" ItemStyle-Width="5%" />
                                <asp:TemplateField HeaderText="配置名称">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ConfigName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="配置值">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ConfigValue") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="配置详细信息">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ConfigDetails") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ConfigDetails") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标志">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ConfigFlag") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ConfigFlag") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <%# GetFlag(Eval("Status"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>                                
                            </Columns>
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 31px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="25%"
                            CustomInfoTextAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
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
                                            <td align="CENTER" height="32">
                                                软件配置信息列表
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <div id="SoftWareID" runat="server">
                                    <table width='98%' border="0" cellpadding="1" cellspacing="1" bgcolor="#CED7F7" align="center">
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px; height: 22px">
                                                <font color="#FF0000">17</font> ：<font color="#0033FF">数字三 专业版</font></td>
                                            <td align="left" style="width: 168px; height: 22px">
                                                <font color="#FF0000">19</font> ：<font color="#0033FF">数字三 标准版</font></td>
                                            <td align="left" style="height: 22px">
                                                <font color="#FF0000">20</font> ：<font color="#0033FF">数字三 3D标准</font></td>
                                            <td align="left" style="height: 22px">
                                                <font color="#FF0000">21</font> ：<font color="#0033FF">数字三 P3标准</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">22</font> ：<font color="#0033FF">数字三 免费版</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">24</font> ：<font color="#0033FF">数字三 3D专业</font></td>
                                            <td align="left">
                                                <font color="#FF0000">25</font> ：<font color="#0033FF">数字三 P3专业</font></td>
                                            <td align="left">
                                                <font color="#FF0000">26</font> ：<font color="#0033FF">数字三 SL专业</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">27</font> ：<font color="#0033FF">数字三 睿智版</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">28</font> ：<font color="#0033FF">数字三 胆杀版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">29</font> ：<font color="#0033FF">数字三 SL胆杀</font></td>
                                            <td align="left">
                                                <font color="#FF0000">30</font> ：<font color="#0033FF">数字三 专业珍藏版</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">31</font> ：<font color="#0033FF">3D 图表珍藏版</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">33</font> ：<font color="#0033FF">排列五 专业版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">35</font> ：<font color="#0033FF">排列五 标准版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">38</font> ：<font color="#0033FF">排列五 免费版</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">42</font> ：<font color="#0033FF">排列五 SC专业</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">45</font> ：<font color="#0033FF">排列五 SC胆杀</font></td>
                                            <td align="left">
                                                <font color="#FF0000">49</font> ：<font color="#0033FF">七星彩 专业版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">51</font> ：<font color="#0033FF">七星彩 标准版</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">54</font> ：<font color="#0033FF">七星彩 免费版</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">65</font> ：<font color="#0033FF">双色球 专业版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">67</font> ：<font color="#0033FF">双色球 标准版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">86</font> ：<font color="#0033FF">彩神通 免费版</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">87</font> ：<font color="#0033FF">彩神通 全能版</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">94</font> ：<font color="#0033FF">彩神通 打印一</font></td>
                                            <td align="left">
                                                <font color="#FF0000">95</font> ：<font color="#0033FF">彩神通 打印二</font></td>
                                            <td align="left">
                                                <font color="#FF0000">97</font> ：<font color="#0033FF">七乐彩 专业版</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">99</font> ：<font color="#0033FF">七乐彩 标准版</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">100</font> ：<font color="#0033FF">七乐彩 选7专</font></td>
                                            <td align="left">
                                                <font color="#FF0000">113</font> ：<font color="#0033FF">大乐透 专业版</font></td>
                                            <td align="left">
                                                <font color="#FF0000">115</font> ：<font color="#0033FF">大乐透 标准版</font></td>
                                        </tr>
                                        <tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>
                                            <td align="left" style="width: 167px">
                                                <font color="#FF0000">116</font> ：<font color="#0033FF">大乐透 选5专</font></td>
                                            <td align="left" style="width: 168px">
                                                <font color="#FF0000">120</font> ：<font color="#0033FF">大乐透 高5专</font></td>
                                            <td align="left">
                                                <font color="#FF0000">145</font> ：<font color="#0033FF">数字6+1 专业版</font></td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    </div>
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
