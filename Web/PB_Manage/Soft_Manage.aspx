<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Soft_Manage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Soft_Manage" EnableEventValidation="false" %>

<%@ Register Src="Controls/UcProductSearch.ascx" TagName="UcProductSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>资源下载管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                                当前位置：资源下载管理</td>
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
                                    <a href="Soft_Manage.aspx">资源下载管理</a> |&nbsp;<asp:LinkButton ID="btn_add" runat="server"
                                        OnClick="btn_add_Click">添加资源下载</asp:LinkButton>&nbsp;|&nbsp;<a href="SoftDeleted.aspx">资源下载回收站</a>
                                    |
                                    <asp:LinkButton ID="lbtnCreate" runat="server" OnClick="lbtnCreate_Click" Text="更新首页最新资源"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcProductSearch ID="UcProductSearch1" runat="server" Url="Soft_Manage.aspx"></uc1:UcProductSearch>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="3" Width="100%" AllowPaging="True" DataKeyNames="PBnet_SoftID" OnRowDeleting="MyGridView_RowDeleting"
                                    CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="全选">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" /></HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" name="sel" value="<%#Eval("PBnet_SoftID") %>" /></ItemTemplate>
                                            <ItemStyle Width="3%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PBnet_SoftID" HeaderText="ID" ReadOnly="True" SortExpression="PBnet_SoftID">
                                            <ItemStyle Width="3%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="资源名称及版本" SortExpression="PBnet_SoftName">
                                            <ItemTemplate>
                                                <a href='Soft_Manage.aspx?softClass=<%#Eval("pb_ClassID") %>'>[<%# Pbzx.Web.WebFunc.GetSoftClassNameById(Eval("pb_ClassID"))%>]</a>
                                                <a href='Soft_Editor.aspx?id=<%#Eval("PBnet_SoftID") %>'>
                                                    <%# Eval("PBnet_SoftName").ToString()+" "+Eval("PBnet_SoftVersion").ToString() %>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle Width="46%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="所属类别" SortExpression="pb_ClassID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Text='<%# Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(Eval("pb_ClassID").ToString()))   %>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="16%" />
                                </asp:TemplateField>--%>
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
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="固顶">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnPb_OnTop" CommandArgument='<%# Eval("PBnet_SoftID") %>' runat="server"
                                                    OnCommand="lbtnPb_OnTop_Command"><%# Convert.ToBoolean(Eval("pb_OnTop")) ? "<font color='blue'>已固顶</font>" : "<font color='black'>未固顶</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnAduting" runat="server" CommandArgument='<%# Eval("PBnet_SoftID") %>'
                                                    OnCommand="lbtnAduting_Command"><%# Convert.ToBoolean(Eval("pb_Passed")) ? "<font color=blue>已发布</font>" : "<font color=red>未发布</font>" %></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <a href="Soft_Editor.aspx?id=<%#Eval("PBnet_SoftID") %>"  >编辑</a> |
                                                <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("PBnet_SoftID") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                                    runat="server" OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="lbtnPb_Elite" CommandArgument='<%# Eval("PBnet_SoftID") %>' runat="server"
                                                    OnCommand="lbtnPb_Elite_Command"><%# Convert.ToBoolean(Eval("pb_indexshow")) ? "<font color='blue'>首页显示</font>" : "<font color='black'>首页不显</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" />
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                </asp:GridView>
                                <table cellpadding="4" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <b>数据批量操作：</b></td>
                                        <td>
                                            <asp:Button ID="btnManySH" runat="server" Text="批量发布" OnClientClick="return CheckBatchUpdate('发布')"
                                                OnClick="btnManySH_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnGD" runat="server" Text="批量不发布" OnClientClick="return CheckBatchUpdate('不发布')"
                                                OnClick="btnGD_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnTJ" runat="server" Text="批量首页显示" OnClientClick="return CheckBatchUpdate('首页显示')"
                                                OnClick="btnTJ_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNotIndex" runat="server" Text="批量首页不显示" OnClientClick="return CheckBatchUpdate('首页不显示')"
                                                OnClick="btnNotIndex_Click" />
                                            <td>
                                                <asp:Button ID="btnOnTop" runat="server" Text="批量固定" OnClientClick="return CheckBatchUpdate('固定')"
                                                    OnClick="btnOnTop_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNotOnTop" runat="server" Text="批量不固定" OnClientClick="return CheckBatchUpdate('不固定')"
                                                    OnClick="btnNotOnTop_Click" />
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
              
                </ContentTemplate>
            </asp:UpdatePanel> 
                 <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                    PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                    Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                    class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
        </div>
    </form>
</body>
</html>
