<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CL_PrintLine_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.CL_PrintLine_Manage" %>

<%@ Register Src="../Controls/UcPrintLineSearch.ascx" TagName="UcPrintLineSearch"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/UcRegInfoSearch.ascx" TagName="UcRegInfoSearch" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_online.ascx" TagName="Uc_online" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>打印注册信息管理</title>
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
                                                当前位置：打印线信息</td>
                                            <td width="9%" align="right">
                                              </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER" style="height: 28px">
                                    <a href="CL_PrintLine_Manage.aspx">管理打印线信息</a> |&nbsp; <a href="CL_PrintLine_Editor.aspx">
                                        添加打印线信息</a></td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc3:UcPrintLineSearch ID="UcPrintLineSearch2" runat="server"></uc3:UcPrintLineSearch>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                            AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" >
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="序列号" SortExpression="SN">
                                    <ItemTemplate>
                                        <%#Eval("SN") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建时间" SortExpression="CreateTime">
                                    <ItemTemplate>
                                        <%# Eval("CreateTime", "{0:yyyy-MM-dd hh:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建者" SortExpression="Creator">
                                    <ItemTemplate>
                                        <%#Eval("Creator") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="入库时间" SortExpression="AcceptTime">
                                    <ItemTemplate>
                                        <%# Eval("Accepter").ToString() == "" ? "---" : Eval("AcceptTime", "{0:yyyy-MM-dd hh:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="入库者" SortExpression="Accepter">
                                    <ItemTemplate>
                                        <%# Eval("Accepter").ToString() == "" ? "---" : Eval("Accepter")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="销售时间" SortExpression="SellTime">
                                    <ItemTemplate>
                                        <%# Eval("Seller").ToString() == "" ? "---" : Eval("SellTime","{0:yyyy-MM-dd hh:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="销售者" SortExpression="Seller">
                                    <ItemTemplate>
                                        <%# Eval("Seller").ToString()=="" ? "---" : Eval("Seller")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="Status">
                                    <ItemTemplate>
                                        <%# GetStatus(Eval("Status"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类型" SortExpression="Type">
                                    <ItemTemplate>
                                        <%# GetType(Eval("Type"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" SortExpression="Remarks">
                                    <ItemTemplate>
                                        <%# Eval("Remarks").ToString().Length > 18 ? Eval("Remarks").ToString().Substring(0, 16) + "..." : Eval("Remarks").ToString() %>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
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
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
