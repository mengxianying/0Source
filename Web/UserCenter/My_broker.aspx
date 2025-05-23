<%@ Page Language="C#" AutoEventWireup="true" Codebehind="My_broker.aspx.cs" Inherits="Pbzx.Web.UserCenter.My_broker" %>

<%@ Register Src="Contorls/UcMy_Broker.ascx" TagName="UcMy_Broker" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拼搏在线 - 经纪人</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />

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
            <table width="800" border="0" align="center" cellpadding="2" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="780" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">『彩神通』经纪人</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                            ID="lblgrade" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="1" cellspacing="1" bgcolor="#FFCB99" align="center">
                <tr>
                    <td bgcolor="#FFF8EE">
                        <uc1:UcMy_Broker ID="UcMy_Broker1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="GridViewStyle"
                            CellPadding="0" DataKeyNames="ID" AutoGenerateColumns="False"
                            PageSize="20" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">                               
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单号">
                                    <ItemTemplate>
                                        <a onclick="OpenEdite('<%#Eval("OrderID") %>');" href="#">
                                            <%#Eval("OrderID") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="32%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户用户名" SortExpression="CustomerName">
                                    <ItemTemplate>
                                        <%#Eval("CustomerName")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="17%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户支付金额">
                                    <ItemTemplate>
                                        <%#Eval("CustomerPay","{0:C2}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="我应得金额">
                                    <ItemTemplate>
                                        <%#Eval("BrokerIncome", "{0:C2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="交易时间">
                                    <ItemTemplate>
                                        <%#Eval("CreateTime","{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="17%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EmptyDataTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 6%" align="center">
                                            序号
                                        </td>
                                        <td style="width: 32%" align="center">
                                            订单号
                                        </td>
                                        <td style="width: 17%" align="center">
                                            客户姓名
                                        </td>
                                        <td style="width: 13%" align="center">
                                            客户支付金额
                                        </td>
                                        <td style="width: 13%" align="center">
                                            我应得金额
                                        </td>
                                        <td style="width: 17%" align="center">
                                            交易时间
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle BackColor="#DCEDFC" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="4" cellspacing="0" bgcolor="#ffffff" align="center">
                <tr>
                    <td>
                        <asp:Label ID="lblMoney" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="第一页"
                            LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上一页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="30%"
                            CustomInfoTextAlign="Center" SubmitButtonClass="page_go">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
