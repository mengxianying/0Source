<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_countlog.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_countlog" %>

<%@ Register Src="~/PB_Manage/Controls/Uc_menu.ascx" TagName="Uc_menu" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_countlog.ascx" TagName="Uc_countlog" TagPrefix="uc2" %>
<html>
<head runat="server">
    <title>统计日志管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
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
                                                当前位置：统计日志管理
                                            </td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td>
                                    <uc1:Uc_menu ID="Uc_menu1" runat="server"></uc1:Uc_menu>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc2:Uc_countlog ID="Uc_countlog1" runat="server"></uc2:Uc_countlog>
                    </td>
                </tr>
            </table>
           <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开始时间" SortExpression="StartTime">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strStartTime=<%#Eval("StartTime") %>"><%# Eval("StartTime", "{0:yyyy-MM-dd HH:mm:ss}")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结束时间" SortExpression="EndTime">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strEndTime=<%#Eval("EndTime") %>"><%# Eval("EndTime", "{0:yyyy-MM-dd HH:mm:ss}")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="运行">
                                    <ItemTemplate>
                                        <%# GetRun((Eval("EndTime")),(Eval("StartTime")))%>/秒
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结果" SortExpression="Result">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strResult=<%#Eval("Result") %>"><%# Eval("Result")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="错误信息" SortExpression="ErrorInfo">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strErrorInfo=<%#Eval("ErrorInfo") %>"><%# Eval("ErrorInfo")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="统计截至" SortExpression="EndDate">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strEndDate=<%#Eval("EndDate") %>"><%# Eval("EndDate","{0:yyyy-MM-dd HH:mm:ss}")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="16%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="统计天" SortExpression="Days">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strDays=<%#Eval("Days") %>"><%# Eval("Days")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标志" SortExpression="Flag">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strFlag=<%#Eval("Flag") %>"><%# Eval("Flag")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="统计表名" SortExpression="StatTableName">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strStatTableName=<%#Eval("StatTableName") %>"><%# Eval("StatTableName")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="18%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" class="pagestyle" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
