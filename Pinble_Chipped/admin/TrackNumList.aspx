<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackNumList.aspx.cs" Inherits="Pinble_Chipped.admin.TrackNumList" %>

<%@ Register Src="../Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>追号详情</title>
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
                    订单号
                </td>
                <td>
                    <asp:Label ID="lab_orderNum" runat="server"></asp:Label>
                </td>
                <td>
                    创建时间：
                </td>
                <td>
                    <asp:Label ID="lab_time" runat="server"></asp:Label>
                </td>
                <td>
                    总金额
                </td>
                <td>
                    <asp:Label ID="lab_TotalAmount" runat="server"></asp:Label>
                </td>
                <td rowspan="2">
                    <asp:Label ID="lab_Condition" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    进度
                </td>
                <td>
                    已追<asp:Label ID="lab_Complete" runat="server"></asp:Label>期/共<asp:Label ID="lab_Intotal"
                        runat="server"></asp:Label>期
                </td>
                <td>
                    订单状态
                </td>
                <td>
                    <asp:Label ID="lab_state" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="My_GridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="None" Width="99%" OnRowCreated="My_GridView_RowCreated"
            OnRowDataBound="My_GridView_RowDataBound" CssClass="rec_table" EnableModelValidation="True"
            ForeColor="#333333">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="订单号">
                    <ItemTemplate>
                        <%# Eval("tn_orderNum")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期次">
                    <ItemTemplate>
                        <%# Eval("tn_issue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="下注方案">
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="view_s('<%# Eval("tn_num") %>','<%# Eval("tn_playname") %>')">号码详情</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额">
                    <ItemTemplate>
                        <%# Eval("tn_money")%>元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="当期开奖号码">
                    <ItemTemplate>
                        <asp:Label ID="lab_ln" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="lab_state" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中奖信息">
                    <ItemTemplate>
                        <asp:Label ID="lab_info" runat="server"></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        继续购买
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
