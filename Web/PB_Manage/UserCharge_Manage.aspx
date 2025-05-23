<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserCharge_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.UserCharge_Manage" %>

<%@ Register Src="Controls/UcUserCharge.ascx" TagName="UcUserCharge" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Controls/UcBulletinSearch.ascx" TagName="UcBulletinSearch" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript">
function openCharge()
{
   //                     showModalDialog("modal.htm",,"dialogWidth=200px;dialogHeight=100px");
   // var result = window.open('Charge_value.aspx', 'newwindow', 'height='+myHeight+', width='+myWidth+', top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');    
   var result = window.showModalDialog("Charge_value.aspx",,"help: No; resizable: No; status: No;scrollbars:No;scroll:yes;center:yes;dialogWidth:650px;dialogHeight:450px");
   if(result =="1")
   {
        window.reload();
   }
}
    </script>

    <title>用户充值管理</title>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3" align="center">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />充值管理</td>
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
                                    <a href="UserCharge_Manage.aspx">充值管理</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClientClick="window.showModalDialog('Charge_value.aspx','','dialogWidth:650px;dialogHeight:450px;')">给用户充值
                                    </asp:LinkButton>
                                    &nbsp; |&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.showModalDialog('Cut_value.aspx','','dialogWidth:650px;dialogHeight:450px;')">给用户扣款
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
                        <uc2:UcUserCharge ID="UcUserCharge1" runat="server">
                        </uc2:UcUserCharge>
                    </td>
                </tr>
            </table>
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
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="序号" DataField="Id">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText=" 充值日期" SortExpression="OrderDate">
                                    <ItemTemplate>
                                        <%#Eval("OrderDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单号" SortExpression="OrderID">
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <ItemTemplate>
                                        <%#Eval("OrderID")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <a href="WebUser_Editor.aspx?ID=<%#GetUserIDByUserName(Eval("UserName")) %>" target="_blank">
                                            <%#Eval("UserName")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="真实姓名" SortExpression="RealName">
                                    <ItemTemplate>
                                        <a href='UserCharge_Manage.aspx?RealName=<%#Eval("RealName") %>' style="cursor: pointer;">
                                            <%#Eval("RealName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="充值方式" SortExpression="PayTypeName">
                                    <ItemTemplate>
                                        <a href='UserCharge_Manage.aspx?PayTypeName=<%#Eval("PayTypeName") %>' style="cursor: pointer;">
                                            <%#Eval("PayTypeName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="充值金额" SortExpression="PayMoney">
                                    <ItemTemplate>
                                        <%#Eval("PayMoney", "{0:f2}")%>
                                        元
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="已充金额" SortExpression="HasPayedPrice">
                                    <ItemTemplate>
                                        <%#Statusprice(Eval("State"), Eval("HasPayedPrice", "{0:f2}"), Eval("PayMoney", "{0:f2}"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="State">
                                    <ItemTemplate>
                                        <%# GetState(Eval("State"), Eval("IsPay"), Eval("IsCancel"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href='ChargeDetails.aspx?ID=<%#Eval("Id") %>'>查看/编辑</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
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
                    <td align="center">
                        <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
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
