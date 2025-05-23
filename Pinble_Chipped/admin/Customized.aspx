<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customized.aspx.cs" Inherits="Pinble_Chipped.admin.Customized" %>

<%@ Register Src="../Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>定制跟单详细页</title>
        <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />   
    <link type="text/css" rel="Stylesheet" href="../Css/Title.css" />
    <link type="text/css" rel="stylesheet" href="../Css/footer.css" />
    <link href="../Css/logion.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../Css/style.css" />
    <script type="text/javascript" src="../jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="../jQuery/jquery.XYTipsWindow.min.2.7.js"></script>
    <script type="text/javascript" src="../js/GridView.js"></script>
    <script type="text/javascript" charset="gb2312" src="../js/public.js"></script>
    <style type="text/css">
        /*====整个表格样式开始*/
        .form
        {
            background: #fff url(../images/tablelist1_trt.gif) repeat-x bottom;
            height: 30px;
            color: #666;
        }
        td, tr, table, div
        {
            font-family: "宋体";
            font-size: 12px;
            line-height: 180%;
        }
        /*====左右表格样式开始*/
    </style>
    <style type="text/css">
        .rec_table
        {
            text-align: center;
            border-collapse: separate;
            border: 1px solid #cee9f4;
        }
        .rec_table th
        {
            background: url(../images/tablelist1_trt.gif) repeat-x bottom;
            height: 35px;
            height: 33px\9;
            line-height: 33px;
            font-weight: normal;
            border-bottom: 1px solid #cee9f4;
            color: #333;
            text-align: center;
            border-left: 1px solid #cee9f4;
        }
        .rec_table td
        {
            height: 28px;
            border-top: 1px solid #fff;
            text-align: center;
            vertical-align: middle;
            border-left: 1px solid #cee9f4;
        }
        body, td, th
        {
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <div class="logo">
        </div>
        <div class="login_info">
            <uc2:login ID="Login1" runat="server" />
        </div>
    </div>
    <div style="margin-left: 5px; margin-top: 10px; margin-bottom: 20px;">
        <table width="98%">
            <tr>
                <td rowspan="2">
                    
                </td>
                <td>
                    发起人
                </td>
                <td>
                    <asp:Label ID="lab_name" runat="server"></asp:Label>
                </td>
                <td>
                    每次认购：</td>
                <td>
                    <asp:Label ID="lab_buy" runat="server"></asp:Label>
                </td>
                <td>
                    总金额
                </td>
                <td>
                    <asp:Label ID="lab_TotalAmount" runat="server"></asp:Label>
                </td>
                <td>
                    撤销订单
                </td>
            </tr>
            <tr>
                <td>
                    定制单号：</td>
                <td>
                    <asp:Label ID="lab_orderNum" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    认购时间：</td>
                <td>
                    <asp:Label ID="lab_time" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    进度：</td>
                <td>
                    已认购<font color="red"><asp:Label ID="lab_buyNum" runat="server"></asp:Label></font>次/剩余<font color="red"><asp:Label ID="lab_Surplus" runat="server"></asp:Label></font>次
                </td>
                <td>
                    
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="My_GridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="None" Width="99%"  CssClass="rec_table" EnableModelValidation="True"
            ForeColor="#333333" onrowdatabound="My_GridView_RowDataBound" 
            onrowcreated="My_GridView_RowCreated">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="单号">
                    <ItemTemplate>
                        <%# Eval("QNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="彩种">
                    <ItemTemplate>
                        <asp:Label ID="lab_lotter" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发起人">
                    <ItemTemplate>
                        <%# Eval("UserName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发起时间">
                    <ItemTemplate>
                        <%# Eval("LaunchTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方案进度">
                    <ItemTemplate>
                        <asp:Label ID="lab_speed" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="参与金额">
                    <ItemTemplate>
                        <asp:Label ID="lab_money" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="中奖金额">
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("bounsAllost")).ToString("￥#,##0.00")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订单状态">
                    <ItemTemplate>
                        <asp:Label ID="lab_SState" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle Font-Bold="True" CssClass="form" />
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 10px;
            margin-bottom: 15px">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    </form>
</body>
</html>
