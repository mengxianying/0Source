<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserDraw_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.UserDraw_Manage" EnableEventValidation="false" %>

<%@ Register Src="Controls/UcUserDraw.ascx" TagName="UcUserDraw" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Controls/UcBulletinSearch.ascx" TagName="UcBulletinSearch" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <title>用户取款申请管理</title>
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
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />取款申请管理</td>
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
                                    <a href="UserDraw_Manage.aspx">用户取款申请管理</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClientClick="window.showModalDialog('Cut_valueSXF.aspx','','dialogWidth:650px;dialogHeight:450px;')">汇款手续费填写
                                    </asp:LinkButton>                                    
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
                        <uc2:UcUserDraw ID="UcUserDraw1" runat="server"></uc2:UcUserDraw>
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
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="Id,State,UserName,PayMoney,IsCancel,PayTypeID"
                                    CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="全选" Visible="False">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" name="sel" value="<%#Eval("Id") %>" /></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="序号">
                                            <ItemStyle Width="4%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                            <ItemStyle HorizontalAlign="center" Width="8%" />
                                            <ItemTemplate>
                                                <a href="WebUser_Editor.aspx?ID=<%#GetUserIDByUserName(Eval("UserName")) %>" target="_blank">
                                                    <%#Eval("UserName")%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="真实姓名" SortExpression="RealName">
                                            <ItemTemplate>
                                                <a href='UserDraw_Manage.aspx?strRealName=<%#Eval("RealName") %>' style="cursor: pointer;">
                                                    <%#Eval("RealName")%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="订单号" SortExpression="OrderID">
                                            <ItemTemplate>
                                                <%#Eval("OrderID")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开户行">
                                            <ItemTemplate>
                                                <a href="#" title="银行名称:<%#GetBankInfo(Eval("UserName"))[1]%> ">
                                                    <%#GetBankInfo(Eval("UserName"))[0]%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle Width="11%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="账号" SortExpression="PayNum">
                                            <ItemTemplate>
                                                <%#GetBankInfo(Eval("UserName"))[2]%>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="取款金额" SortExpression="PayMoney">
                                            <ItemTemplate>
                                                <%#Eval("PayMoney","{0:f2}")%>
                                                元
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="申请日期" SortExpression="OrderDate">
                                            <ItemTemplate>
                                                <%#Eval("OrderDate", "{0:yyyy-MM-dd HH:mm}")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="13%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态和操作">
                                            <ItemTemplate>
                                                [<asp:Literal ID="lblState" runat="server"></asp:Literal>]
                                                <asp:LinkButton ID="lbtnEdite" runat="server" OnClientClick="return confirm('您确定要通过吗?')"
                                                    OnCommand="lbtnEdite_Command" CommandArgument='<%# Eval("Id") %>'>通过|</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnCancel" runat="server" OnClientClick="return confirm('您确定要未通过吗?')"
                                                    OnCommand="lbtnCancel_Command" CommandArgument='<%# Eval("Id") %>'>未通过</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="17%" />
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
                    <%--            <table cellpadding="4" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <b>数据批量操作：</b></td>
                    <td colspan="4">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 13%">
                                    <asp:Button ID="btnManySH" runat="server" Text="发布" OnClientClick="return CheckBatchUpdate('发布')"
                                        OnClick="btnManySH_Click" Width="60px" Height="26px" />
                                </td>
                                <td style="width: 13%">
                                    <asp:Button ID="btnNoFB" runat="server" Text="不发布" OnClientClick="return CheckBatchUpdate('设置不发布')"
                                        OnClick="btnNoFB_Click" Width="60px" Height="26px" /></td>
                                <td style="width: 13%">
                                    <asp:Button ID="btnGD" runat="server" Text="固顶" OnClientClick="return CheckBatchUpdate('固顶')"
                                        OnClick="btnGD_Click" Width="60px" Height="26px" /></td>
                                <td style="width: 13%">
                                    <asp:Button ID="btnNoGD" runat="server" Text="不固顶" OnClientClick="return CheckBatchUpdate('设置不固顶')"
                                        OnClick="btnNoGD_Click" Width="60px" Height="26px" /></td>
                                <td style="width: 16%">
                                    <asp:Button ID="btnSC" runat="server" Text="批量删除" OnClientClick="return CheckBatchUpdate('删除')"
                                        OnClick="btnSC_Click" Width="60px" Height="26px" /></td>
                                <td style="width: 16%">
                                    <asp:Button ID="btnCreate" runat="server" Text="批量生成" OnClientClick="return CheckBatchUpdate('批量生成')"
                                        OnClick="btnCreate_Click" Width="60px" Height="26px" />
                                </td>
                                <td style="width: 16%">
                                    <asp:Button ID="btnAllCreate" runat="server" Text="全部生成" OnClientClick="return CheckBatchUpdate('全部生成')"
                                        OnClick="btnAllCreate_Click" Width="60px" Height="26px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10px;">
                    </td>
                </tr>
            </table>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                <td align="center">
                <asp:Label id="lblTotal" runat="server"></asp:Label>
                </td>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
