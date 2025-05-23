<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_GradeConfig.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_GradeConfig" %>

<html>
<head runat="server">
    <title>用户等级配置管理 - 拼搏吧</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">             
            <div>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                    <tr>
                        <td bgcolor="#F3F3F3">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="Right_bg1" style="height: 26px">
                                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                            <tr>
                                                <td width="91%" align="left">
                                                    当前位置：等级信息管理</td>
                                                <td width="9%" align="right">
                                                   <%-- <asp:Button ID="Button2" runat="server" Text=">>返回" OnClientClick="history.back();return false;" />--%></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                <tr>
                                    <td align="CENTER">
                                       <a href="Ask_GradeConfig.aspx">管理等级信息</a>
                                        |&nbsp;
                                         <a href="Ask_GradeConfig_Edit.aspx">添加等级信息</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    class="MT">
                    <tr bgcolor="#ffffff">
                        <td>
                            <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                CellPadding="0" DataKeyNames="ID" Width="100%" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound" OnRowDeleting="MyGridView_RowDeleting">
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <PagerStyle CssClass="GridView_Pager" />
                                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                <RowStyle CssClass="GridView_Row" />
                                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                <Columns>
                                 <asp:TemplateField HeaderText="序号" SortExpression="ID">
                                        <ItemTemplate>
                                     <%# Eval("ID")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="等级名称" SortExpression="GradeName">
                                        <ItemTemplate>
                                            <%#Eval("GradeName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="最小积分" SortExpression="MinPoint">
                                        <ItemTemplate>
                                            <%#Eval("MinPoint")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="最大积分" SortExpression="MaxPoint">
                                        <ItemTemplate>
                                            <%#Eval("MaxPoint")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Ask_GradeConfig_Edit.aspx?ID={0}"
                                        HeaderText="编辑" Text="编辑" />
                                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowDeleteButton="True" HeaderText="删除" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
