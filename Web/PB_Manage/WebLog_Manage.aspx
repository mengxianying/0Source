<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLog_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.WebLog_Manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>操作日志管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
    <script src="../javascript/calendar.js" type="text/javascript"></script>
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
                                            当前位置：操作日志管理
                                        </td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%--	<table width="100%" border="0" cellspacing="0" cellpadding="4">
  <tr>
    <td align="CENTER"><a href="Product_Manage.aspx">产品管理首页</a> | 
                           <a href="Product_Editor.aspx">添加产品信息</a>&nbsp; |
                             <a href="ProductReorderList.aspx">产品显示排序</a></td>
  </tr>
</table>--%>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
            class="MT">
            <tr>
                <td bgcolor="#F7FBFF" align="left">
                    <table width="100%">
                        <tr>
                            <td>
                                &nbsp;<b>筛选条件:</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlActionType" runat="server" Width="154px" OnSelectedIndexChanged="ddlActionType_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True">所有</asp:ListItem>
                                    <asp:ListItem>后台登录</asp:ListItem>
                                    <asp:ListItem>新增</asp:ListItem>
                                    <asp:ListItem>修改</asp:ListItem>
                                    <asp:ListItem>删除</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;<b>具体操作:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="tb_jt" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;<b>操作者:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="tb_Operator" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<b>IP:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="tb_IP" runat="server"></asp:TextBox>
                            </td>
                            <td>
                               
                                 &nbsp;<b> 日期段:从:</b>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox>
                                至&nbsp;&nbsp;
                                <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_Query" runat="server" Text="查询" OnClick="btn_Query_Click" />
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
                        CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" OnRowDeleting="MyGridView_RowDeleting"
                        CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                        <FooterStyle CssClass="GridView_Footer" />
                        <Columns>
<%--                            <asp:TemplateField HeaderText="全选">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" name="sel" value="<%#Eval("ID") %>" /></ItemTemplate>
                                <ItemStyle Width="4%" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="序号" SortExpression="ID">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="4%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ActionType" HeaderText="操作" SortExpression="ActionType">
                                <ItemStyle Width="9%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="具体操作" SortExpression="Detail">
                                <ItemTemplate>
                                    <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("Detail"),60)%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="50%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作者" SortExpression="Operator">
                                <ItemTemplate>
                                    <a href="weblog_manage.aspx?Operator=<%# Eval("Operator") %>">
                                        <%# Eval("Operator") %></a>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作者IP" SortExpression="UserIP">
                                <ItemTemplate>
                                    <div title='IP地址:<%#DataBinder.Eval(Container.DataItem,"UserIP")%>&#13;'>
                                       <a href="weblog_manage.aspx?UserIP=<%# Eval("UserIP") %>"> <%# GetIpName(Eval("UserIP"))%></a>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作时间">
                                <ItemTemplate>
                                    <%#Eval("ActionTime","{0:yyyy-MM-dd HH:mm}")%>
                                </ItemTemplate>
                                <ItemStyle Width="13%" />
                            </asp:TemplateField>
                            <%--<asp:CommandField DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt; "
                                    HeaderText="删除" ShowDeleteButton="True">
                                    <ItemStyle Width="6%" />
                                </asp:CommandField>--%>
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="GridView_Pager" />
                        <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                        <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        <RowStyle CssClass="GridView_Row" HorizontalAlign="Left" />
                        <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table cellpadding="4" cellspacing="0" width="100%">
            <tr>
                <td width="107" align="right">
                    <b>数据批量操作：</b>
                </td>
                <td colspan="4">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="37%" align="left">
                                <asp:Button ID="btnSC" runat="server" Visible="false" Text="批量删除" OnClientClick="return CheckBatchUpdate('删除')"
                                    OnClick="btnSC_Click" />
                            </td>
                            <td width="63%">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10" style="width: 10px;">
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                        ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                        CssClass="pagestyle" EnableTheming="True" CustomInfoSectionWidth="25%" HorizontalAlign="Center">
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
