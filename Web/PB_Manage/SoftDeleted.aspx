<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftDeleted.aspx.cs" Inherits="Pbzx.Web.PB_Manage.SoftDeleted" %>

<%@ Register Src="Controls/UcProductSearch.ascx" TagName="UcProductSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>资源回收站管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>

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
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：资源回收站管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="Soft_Manage.aspx">资源下载管理</a> |&nbsp;<asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加资源下载</asp:LinkButton> |&nbsp;<a href="SoftDeleted.aspx">资源下载回收站</a>
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
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="3" Width="100%" AllowPaging="True" DataKeyNames="PBnet_SoftID" OnRowDeleting="MyGridView_RowDeleting"
                            CssClass="GridView_Table" PageSize="20">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="全选">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" /></HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="sel" value="<%#Eval("PBnet_SoftID") %>" /></ItemTemplate>
                                    <ItemStyle Width="4%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PBnet_SoftID" HeaderText="ID" ReadOnly="True" SortExpression="PBnet_SoftID">
                                    <ItemStyle Width="3%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="资源名称及版本" SortExpression="PBnet_SoftName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("PBnet_SoftName").ToString()+Eval("PBnet_SoftVersion").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="28%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属类别" SortExpression="pb_ClassID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Text='<%# Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(Eval("pb_ClassID").ToString()))   %>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="16%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="资源大小" SortExpression="PBnet_SoftSize">
                                    <ItemTemplate>
                                        <%# Eval("PBnet_SoftSize")+"KB" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日/周/月/总" SortExpression="pb_Hits">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("pb_DayHits")+"/"+ Eval("pb_WeekHits")+"/"+ Eval("pb_MonthHits")+"/"+Eval("pb_Hits") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="属性" SortExpression="IntAddPurview">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# GetFlag(Eval("pb_DayHits").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审核">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnAduting" runat="server" CommandArgument='<%# Eval("PBnet_SoftID") %>'
                                            OnCommand="lbtnAduting_Command"><%# Convert.ToBoolean(Eval("pb_Passed")) ? "<font color=green>已发布</font>" : "<font color=red>未发布</font>" %></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("PBnet_SoftID") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                            runat="server" OnCommand="lbtnDel_Command">彻底删除</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="lbtnPb_Elite" CommandArgument='<%# Eval("PBnet_SoftID") %>' runat="server"
                                            OnCommand="lbtnPb_Elite_Command">还原</asp:LinkButton>
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
                        <table cellpadding="6" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <b>数据批量操作：</b></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnManySH" runat="server" Text="还原选中资源" OnClientClick="return CheckBatchUpdate('还原')"
                                        OnClick="btnManySH_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnGD" runat="server" Text="还原所有资源" OnClientClick="return CheckBatchUpdate('还原所有')"
                                        OnClick="btnGD_Click" />
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnTJ" runat="server" Text="彻底删除选中资源" OnClientClick="return CheckBatchUpdate('彻底删除')"
                                        OnClick="btnTJ_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnNotIndex" runat="server" Text="清空回收站" OnClientClick="return CheckBatchUpdate('清空')"
                                        OnClick="btnNotIndex_Click" />&nbsp;
                                </td>
                                <td>
                                </td>
                                <td style="width: 15px;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                           FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            CustomInfoStyle='vertical-align:middle;' class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
