<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Group_Manage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Group_Manage" %>

<html>
<head id="Head1" runat="server">
    <title>WebSite</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div id="divOperator" runat="server" visible="false">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                新增用户组</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--	<table width="100%" border="0" cellspacing="0" cellpadding="4">
  <tr>
    <td  align="CENTER"><a  href="Group_Manage.aspx">用户组管理 </a>|
        <asp:LinkButton ID="LinkButton2"   runat="server"  OnClick="LinkButton1_Click" >新增用户组</asp:LinkButton></td>
  </tr>
</table>--%>
                    </td>
                </tr>
            </table>
            <table bgcolor="#CED7F7" border="0" align="center" cellpadding="2" cellspacing="1"
                width="100%">
                <tr bgcolor="#F2F8FB">
                    <td class="Manage_Title" colspan="2">
                        &nbsp;&nbsp;用户组名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" bgcolor="#F2F8FB" class="Manage_Title">
                        请选择用户组权限</td>
                </tr>
                <tr bgcolor="#F2F8FB">
                    <td colspan="2" valign="top">
                        <asp:DataList ID="dlRoot" runat="server" RepeatDirection="Horizontal" Width="100%"
                            RepeatColumns="2">
                            <ItemTemplate>
                                <div class="Root_Module">
                                    &nbsp;&nbsp;<b> +
                                        <%# getChild(Eval("Name"), Eval("RootID"))%>
                                    </b>
                                </div>
                                <asp:DataList ID="dlChild" DataSource="<%# Dview %>" runat="server">
                                    <ItemTemplate>
                                        <div class="Module_Left">
                                            &nbsp;&nbsp;<%# Eval("Name")%>
                                            &gt &gt</div>
                                        <div class="Module_Right">
                                            &nbsp;&nbsp;<%# showRights(Eval("URL"))%></div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </ItemTemplate>
                            <AlternatingItemStyle Width="300px" />
                            <SelectedItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" Width="320px" />
                        </asp:DataList>
                    </td>
                </tr>
                <tr bgcolor="#F2F8FB">
                    <td colspan="2" align="center" style="height: 40px">
                        <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />
                        <asp:HiddenField ID="hfID" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divList" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F1F3F5">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                用户组管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER">
                                    <a href="Group_Manage.aspx">用户组管理 </a>|
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">新增用户组</asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#ffffff">
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataSourceID="odsMaster" DataKeyNames="ID"
                            OnRowCreated="MyGridView_RowCreated" CssClass="GridView_Table" PageSize="15"
                            OnRowCommand="MyGridView_RowCommand">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="ID" />
                                <asp:TemplateField HeaderText="用户组名称">
                                    <ItemTemplate>
                                        <div align="left" style="padding-left: 5px;">
                                            <%# Eval("GroupName")%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField CommandName="EditCate" HeaderText="编辑" Text="编辑" />
                                <asp:ButtonField CommandName="DelCate" HeaderText="删除" Text="删除" />
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
            <asp:ObjectDataSource ID="odsMaster" runat="server" SelectMethod="GetAllList" TypeName="Pbzx.BLL.PBnet_Group">
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
