<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyRecord.aspx.cs" Inherits="Pinble_Chipped.admin.BuyRecord" %>

<%@ Register Src="../Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户购买记录</title>
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
<body onload="GridViewColor()">
    <form id="form1" runat="server">
    <!--header部分-->
    <div class="header">
        <div class="logo">
        </div>
        <div class="login_info">
            <uc2:login ID="Login1" runat="server" />
        </div>
        <%--            <div class="nav">
                <dl class="b-top-nav">
                </dl>            </div>--%>
    </div>
    <!--header部分-->
    <div style="margin-top: 10px; margin-bottom: 10px; text-align: center">
        <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="None" Width="99%" OnRowCreated="myGridView_RowCreated"
            OnRowDataBound="myGridView_RowDataBound" CssClass="rec_table" EnableModelValidation="True"
            ForeColor="#333333">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="订单号">
                    <ItemTemplate>
                        <%# Eval("QNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="彩种">
                    <ItemTemplate>
                        <asp:Label ID="lab_lotteryName" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="玩法">
                    <ItemTemplate>
                        <asp:Label ID="lan_playName" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期号">
                    <ItemTemplate>
                        <%# Eval("ExpectNum") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发起人">
                    <ItemTemplate>
                        <%# Eval("UserName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="认购金额">
                    <ItemTemplate>
                        <asp:Label ID="lab_subscriptyion" runat="server"></asp:Label>元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总份数">
                    <ItemTemplate>
                        <%# Eval("Share")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="购买份数">
                    <ItemTemplate>
                        <%# Eval("ChippedShare")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="倍数">
                    <ItemTemplate>
                        <asp:Label ID="lab_dub" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="进度">
                    <ItemTemplate>
                        <asp:Label ID="lab_plan" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结算状态">
                    <ItemTemplate>
                        <asp:Label ID="lab_SState" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总奖金">
                    <ItemTemplate>
                        <asp:Label ID="lab_Toal" runat="server"></asp:Label>元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所获奖金">
                    <ItemTemplate>
                        <asp:Label ID="lab_bonus" runat="server"></asp:Label>元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中奖">
                    <ItemTemplate>
                        <asp:Label ID="lab_Winning" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="认购时间">
                    <ItemTemplate>
                        <%# Eval("chippedTime").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="奖号">
                    <ItemTemplate>
                        <asp:Label ID="lab_Serial" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方案详情">
                    <ItemTemplate>
                      <a href="javascript:void(0)" onclick="view_s('<%# Eval("ChoiceNum")%>','<%# Eval("playName")%>')">查看</a> 
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
