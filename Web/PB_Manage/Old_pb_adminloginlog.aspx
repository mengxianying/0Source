<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Old_pb_adminloginlog.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Old_pb_adminloginlog" %>

<%@ Register Src="Controls/UcOldAdminLog.ascx" TagName="UcOldAdminLog" TagPrefix="uc2" %>
<%@ Register Src="Controls/UcNewsSearch.ascx" TagName="UcNewsSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>用户日志管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function OpenEdite(id)
        {
            var result =  window.showModalDialog('LockUserIP.aspx?UserIP='+id+'','','dialogHeight:200px;dialogWidth:410px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
        }
    </script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
            <tr>
                <td bgcolor="#F3F3F3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td width="91%" align="left">
                                            当前位置：<%--<asp:Label ID="labAction" runat="server" />--%>用户日志管理</td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td align="CENTER" style="height: 26px">
                                <a href="Old_pb_adminloginlog.aspx">用户日志管理</a>
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
                    <uc2:UcOldAdminLog ID="UcOldAdminLog1" runat="server"></uc2:UcOldAdminLog>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr bgcolor="#ffffff">
                <td>
                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="id" CssClass="GridView_Table"
                        OnRowDataBound="MyGridView_RowDataBound">
                        <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        <FooterStyle CssClass="GridView_Footer" />
                        <Columns>
                            <asp:BoundField DataField="id"  HeaderStyle-Width="30px" HeaderText="序号" >
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="用户名">
                                <ItemStyle HorizontalAlign="left" Width="12%" />
                                <ItemTemplate>
                                    <a href="Old_pb_adminloginlog.aspx?log_username=<%#Eval("log_username")%>">
                                        <%#Eval("log_username")%>
                                    </a>
                                    <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("log_username") %>' OnClientClick="return confirm('您确定要锁定该用户吗?')"
                                        runat="server" OnCommand="lbtnDel_Command">[锁]</asp:LinkButton>
                                          <asp:LinkButton ID="lbtnJie" CommandArgument='<%# Eval("log_username") %>' OnClientClick="return confirm('您确定要给该用户解锁吗?')"
                                        runat="server" OnCommand="lbtnJie_Command">[解]</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="密码/注入符号">
                                <ItemTemplate>
                                    <%# FormartTemp_pass(Eval("log_password"), Eval("log_stepinto"))%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="16%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="侵入场合">
                                <ItemStyle  HorizontalAlign="Left" Width="6%" />
                                <ItemTemplate>
                                    <a href="Old_pb_adminloginlog.aspx?log_stepinto=<%#Eval("log_stepinto")%>">
                                        <%#Eval("log_stepinto")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="调用URL">
                                <ItemTemplate>
                                    <a href="Old_pb_adminloginlog.aspx?log_urlname=<%#Eval("log_urlname")%>">
                                        <%#Eval("log_urlname")%>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Left" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="用户IP">
                                <ItemTemplate>
                                    <a href="Old_pb_adminloginlog.aspx?log_Ip=<%#Eval("log_Ip")%>">
                                        <%#Eval("log_Ip")%>
                                    </a>
                                    <a onclick="OpenEdite('<%#Eval("log_Ip")%>');"  href="#">[锁]</a>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="用户地址">
                                <ItemTemplate>
                                    <%#Eval("log_country")%>
                                    &nbsp;<%#Eval("log_city")%>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Left" Width="16%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="登录/侵入时间">
                                <ItemTemplate>
                                    <%#Eval("log_time")%>
                                </ItemTemplate>
                                <ItemStyle Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <a href="Old_pb_adminloginlog.aspx?log_state=<%#Eval("log_state")%>">
                                        <%#Eval("log_state")%>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="GridView_Row" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="GridView_Pager" />
                        <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                        <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
            </tr>
        </table>
        <%--        <asp:ObjectDataSource ID="MyODS" runat="server" DeleteMethod="Delete" SelectMethod="GetArticleList" TypeName="RM.BLL.Article">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClass" DefaultValue="0" Name="ClassID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>
    </form>
</body>
</html>
