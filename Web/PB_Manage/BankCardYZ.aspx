<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BankCardYZ.aspx.cs" Inherits="Pbzx.Web.PB_Manage.BankCardYZ" %>

<%@ Register Src="Controls/UcBankCardYZ.ascx" TagName="UcBankCardYZ" TagPrefix="uc3" %>

<%@ Register Src="Controls/UcUserCharge.ascx" TagName="UcUserCharge" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Controls/UcBulletinSearch.ascx" TagName="UcBulletinSearch" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript">
function open(uid)
{
alert(uid);
//   var result =   window.showModalDialog("UserBankCardYZ.aspx?uid=12","","help: No; resizable: No; status: No;scrollbars:No;scroll:yes;center:yes;dialogWidth:650px;dialogHeight:450px;");
//   if(result =="1")
//   {
//        window.reload();
//   }  
}
    </script>

    <title>银行卡验证</title>
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
                                                <asp:Label ID="labAction" runat="server" />用户银行卡验证</td>
                                            <td width="9%" align="right">
                                              </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left"><uc3:UcBankCardYZ id="UcBankCardYZ1" runat="server"></uc3:UcBankCardYZ></td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                             CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="Id,UserName,AccountNumberState,AccountNumberCode,AccountNumberCodeTime"
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
                                <asp:BoundField HeaderText="序号"  DataField="Id">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                    <ItemStyle HorizontalAlign="Left" Width="9%" />
                                    <ItemTemplate>
                                         <a href="WebUser_Editor.aspx?ID=<%#GetUserIDByUserName(Eval("UserName")) %>" target="_blank">  <%#Eval("UserName")%> </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="真实姓名" SortExpression="RealName">
                                    <ItemTemplate>
                                        <%#Eval("RealName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="银行账号申请验证时间" SortExpression="AccountNumberCodeTime">
                                    <ItemTemplate>
                                        <%#Eval("AccountNumberCodeTime", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开户银行名" SortExpression="AccountNumber">
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    <ItemTemplate>
                                        <%#Eval("AccountNumber")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开户行信息" SortExpression="AccountNumber">
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    <ItemTemplate>
                                        <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("BankInfo"),15*2)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="账号" SortExpression="AccountNumber">
                                    <ItemTemplate>
                                        <%#Eval("AccountNumber")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="14%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="银行卡验证状态" SortExpression="AccountNumberState">
                                    <ItemTemplate>
                                        <%#GetStateNameByStateID(Eval("AccountNumberState"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="银行卡验证码" SortExpression="AccountNumberCode">
                                    <ItemTemplate>
                                        <%#Eval("AccountNumberCode")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态和操作">
                                    <ItemTemplate>
                                        [<asp:Literal ID="lblState" runat="server"></asp:Literal><span id="lbtnEdite" style="cursor:pointer;"  color="blue" runat="server">处理</span>]
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
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
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
