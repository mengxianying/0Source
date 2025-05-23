<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Money_Log.aspx.cs" Inherits="Pbzx.Web.UserCenter.Money_Log" %>

<%@ Register Src="Contorls/UcMoney_Log.ascx" TagName="UcMoney_Log" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资金往来</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>
 <script type="text/javascript" language="javascript">
        function OpenEdite(id)
        {
            var result =  window.showModalDialog('OrderShow.aspx?ID='+id+'','','dialogHeight:400px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
            if(result == 'yes')
            {
               location.reload();    
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="780" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">充值/取款</span></td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="1" cellspacing="1" bgcolor="#FFCB99" align="center">
                <tr>
                    <td bgcolor="#FFF8EE">
                        <uc1:UcMoney_Log ID="UcMoney_Log1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowDataBound="MyGridView_RowDataBound" CssClass="GridViewStyle" DataKeyNames="OrderID,PayTypeID,PayTypeName,IsCancel"
                            OnRowCreated="MyGridView_RowCreated">
                            <Columns>
                                <asp:BoundField HeaderText="序号" DataField="Id">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="订单号">
                                    <ItemTemplate>
                                        <%# GetLinkUrl(Eval("Type"), Eval("Id"), Eval("OrderID"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="14%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类别" SortExpression="Type">
                                    <ItemTemplate>
                                        <%# Eval("Type").ToString() == "1" ?" <font color=red>取款</font>" : "充值" %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>                             
                                <asp:TemplateField HeaderText="充值金额" SortExpression="PayMoney">
                                    <ItemTemplate>
                                        <%# Eval("Type").ToString() == "1" ? "" : Eval("HasPayedPrice", "{0:C2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="取款金额" SortExpression="PayMoney">
                                    <ItemTemplate>
                                        <%# Eval("Type").ToString() == "1" ? Eval("PayMoney", "{0:C2}") : "" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="时间" SortExpression="OrderDate">
                                    <ItemTemplate>
                                        <%#Eval("OrderDate", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="State">
                                    <ItemTemplate>
                                        <%# GetState(Eval("State"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnCancel" runat="server" OnCommand="lbtnCancel_Command"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EmptyDataTemplate>
                                <table width="100%" border="0" cellpadding="3" cellspacing="0" bgcolor="#DCEDFC">
                                    <tr>
                                        <td width="5%" align="center">
                                            序号
                                        </td>
                                        <td width="12%" align="center">
                                            交易编号</td>
                                        <td width="5%" align="center">
                                            类别</td>
                                        <td width="9%" align="center">
                                            充值金额</td>
                                        <td width="9%" align="center">
                                            实际充值</td>
                                        <td width="9%" align="center">
                                            取款金额</td>
                                        <td width="14%" align="center">
                                            摘要</td>
                                        <td width="15%" align="center">
                                            日期</td>
                                        <td width="9%" align="center">
                                            状态</td>
                                        <td width="13%" align="center">
                                            操作
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" height="28" valign="bottom">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页;" LastPageText="最后一页;" NextPageText="下一页;" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页;" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center" SubmitButtonClass="page_go">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        当前可用余额（<asp:Label ID="lblUserBalance" runat="server"></asp:Label>）</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
