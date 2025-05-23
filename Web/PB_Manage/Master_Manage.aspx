<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Master_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Master_Manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>管理员信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript">
  window.onload = function(){
           GridViewColor();
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td width="91%" align="left">
                                管理员信息</td>
                            <td width="9%" align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr bgcolor="#ffffff">
                <td>
                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        Width="100%" AllowPaging="True" DataKeyNames="Master_Id,Master_Name" OnRowCreated="MyGridView_RowCreated"
                        OnRowDeleting="MyGridView_RowDeleting" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                        <FooterStyle CssClass="GridView_Footer" />
                        <Columns>
                            <asp:BoundField HeaderText="序号" DataField="Master_Id" />
                            <asp:TemplateField HeaderText="用户名">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Master_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="登录次数">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("LoginCount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="上次登录时间">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("LasTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="上次登录ＩＰ">
                                <ItemTemplate>                                   
                                    <div title='IP地址:<%#DataBinder.Eval(Container.DataItem,"LastIP")%>&#13;'>
                                        <%# Pbzx.Web.WebFunc.GetIpName(Eval("LastIP"))%>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="允许登录ip">
                                <ItemTemplate>                                   
                                    <%# Eval("ipLimit").ToString() == "" ? "无范围" : Eval("ipLimit").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="省份">
                                <ItemTemplate>                                   
                                    <%# Eval("regionLimit").ToString() == "" ? "无范围" : Eval("regionLimit").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="权限">
                                <ItemTemplate>
                                    <a href='AdminPower.aspx?curUser=<%# Eval("Master_Name") %>'>编辑权限</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <%# Convert.ToBoolean(Eval("State")) ? "正常" : "<font color='red'>禁止</font>" %>
                                </ItemTemplate>
                            </asp:TemplateField>                          
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt; " />
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
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT2">
            <tr>
                <td height="32px">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" CssClass="pagestyle" HorizontalAlign="Right"
                        CustomInfoStyle='vertical-align:middle;'>
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </form>
</body>
</html>
