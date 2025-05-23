<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackingList.aspx.cs" Inherits="Pinble_Chipped.admin.TrackingList" %>

<%@ Register Src="../Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>

<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户订制跟单</title>
    <link type="text/css" rel="Stylesheet" href="../Css/Title.css" />
    <link type="text/css" rel="stylesheet" href="../Css/footer.css" />
    <link href="../Css/logion.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
.rec_table{text-align:center;border-collapse:separate; border:1px solid #cee9f4;}
.rec_table th{background:url(../images/tablelist1_trt.gif) repeat-x bottom; height:35px; height:33px\9; line-height:33px; font-weight:normal; border-bottom:1px solid #cee9f4; color:#333;text-align:center;border-left:1px solid #cee9f4;}
.rec_table td{height:28px;border-top:1px solid #fff;text-align:center; vertical-align:middle;border-left:1px solid #cee9f4;}
body,td,th {
	font-size: 12px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
                <!--header部分-->
        <div class="header">
            <div class="logo">
            </div>
            <div class="login_info">
                 <uc2:login ID="Login1" runat="server" />
                </div>
            <div class="nav">
                <dl class="b-top-nav">
                </dl>
            </div>
        </div>
        <!--header部分-->
    <div style="margin-top:10px; margin-bottom:10px">
        <asp:GridView ID="My_GridView" runat="server" AutoGenerateColumns="False" Width="99%" CssClass="rec_table" AllowPaging="True" OnRowCreated="My_GridView_RowCreated" OnRowDataBound="My_GridView_RowDataBound" Style="text-align: center;">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="彩种">
                <ItemTemplate>
                    <asp:Label ID="lab_lottery" runat="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="定制发起人">
                <ItemTemplate>
                <%# Eval("UserN") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="定制时间">
                <ItemTemplate>
                <%# Eval("TrackingTime")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="定制方案">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lab_tar" runat="server"></asp:Label></td>
                            
                        </tr>
                        <tr><td>总金额：<%# (Convert.ToDecimal(Eval("BuyMoney")) * Convert.ToInt32(Eval("SubscribeNum"))).ToString("￥#,##0.00")%></td></tr>
                    </table>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="已认购/总次数">
                <ItemTemplate>
                   <%# Eval("TrackingN")%> /<%# Eval("SubscribeNum") %>个
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="认购金额/次">
                <ItemTemplate>
                    <%#Convert.ToDecimal(Eval("BuyMoney")).ToString("￥#,##0.00")%> 元/次
                </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="类型">
                <ItemTemplate>
                
                </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="详细">
                <ItemTemplate>
                    <a href='Customized.aspx?tNum=<%# Eval("TrackingLNum") %>&name=<%# Eval("UserN") %>&id=<%# Eval("TrackingID") %>' target="mainFrame">详细</a>
                    
                </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:CommandField HeaderText="操作" ShowEditButton="True" />--%>
            </Columns>
             
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" border="0" width="99%">
                <tr>
                    <td style="height: 41px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
            
    </div>
        <uc1:Footer ID="Footer1" runat="server" />
       
    </form>
</body>
</html>
