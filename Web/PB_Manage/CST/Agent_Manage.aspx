<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Agent_Manage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.Agent_Manage" %>

<%@ Register Src="../Controls/UcAgentSearch.ascx" TagName="UcAgentSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>注册代理商信息管理</title>
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
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />注册代理商信息管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--<table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="Agent_Manage.aspx">代理商信息管理</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加代理商信息</asp:LinkButton></td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left" style="width: 100%">
                        <uc1:UcAgentSearch ID="UcAgentSearch1" runat="server"></uc1:UcAgentSearch>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID,UserName" CssClass="GridView_Table"
                             OnRowDeleting="MyGridView_RowDeleting" OnRowDataBound="MyGridView_RowDataBound"
                            AllowSorting="True" OnSorting="MyGridView_Sorting">
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <FooterStyle CssClass="GridView_Footer" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField HeaderText="序号" DataField="ID">
                                    <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="用户名" DataField="UserName" >
                                
                                </asp:BoundField>
                                <asp:BoundField HeaderText="真实姓名" DataField="Name" >
                                
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="电话">
                                    <ItemTemplate>
                                        <%#Eval("Telephone")%>
                                    </ItemTemplate>
                                 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属省份">
                                    <ItemTemplate>
                                        <%#Eval("Province")%>
                                    </ItemTemplate>
                                   
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="未处理" SortExpression="Status">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("Status")) ? "" : "<font color=blue>未通过</font>"%>
                                    </ItemTemplate>
                                   
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请时间" SortExpression="CreateDate">
                                    <ItemTemplate>
                                        <%# Eval("ExpireDate", "{0:yyyy-MM-dd}")%>
                                    </ItemTemplate>
                                 
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Agent_Editor.aspx?ID={0}"
                                    HeaderText="编辑" Text="编辑">
                                  
                                </asp:HyperLinkField>
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;" >
                              
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="全选" Visible="False">
                                    <HeaderTemplate>
                                        <span style="cursor: pointer;" onclick="AllChecked()">全选</span></HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="sel" value="<%#Eval("ID") %>" /></ItemTemplate>
                                   
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="GridView_Row" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        </asp:GridView>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            CustomInfoStyle='vertical-align:middle;' OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" runat="server" Text="desc" Visible="false"></asp:Label>
    </form>
</body>
</html>
