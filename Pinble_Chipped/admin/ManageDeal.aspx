<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageDeal.aspx.cs" Inherits="Pinble_Chipped.admin.ManageDeal" %>

<%@ Register Src="../Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理查询方案</title>
    <link type="text/css" rel="Stylesheet" href="../Css/Title.css" />
    <link type="text/css" rel="stylesheet" href="../Css/footer.css" />
    <script src="/js/GridView.js" type="text/javascript"></script>
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script language="javascript" type="text/javascript" charset="gb2312" src="/js/public.js?date=new date().gettime()"></script>
    <style type="text/css">
        body
        {
            font-family: "宋体";
            margin: 0px;
            padding: 12px;
            font-size: 12px;
            font-style: normal;
            line-height: 170%;
            font-weight: normal;
            overflow: scroll;
            overflow-x: hidden;
        }
        
        
        html, body
        {
            height: 100%;
        }
        .XYTipsWindow .boxLoading
        {
            position: absolute;
            display: block;
            width: 90px;
            height: 30px;
            line-height: 30px;
            margin-left: -45px;
            margin-top: -15px;
            left: 50%;
            top: 50%;
            color: #f00;
        }
        .XYTipsWindow .boxLoading
        {
            width: 28px;
            margin-left: -14px;
            background: url("loading.gif") no-repeat;
            text-indent: -999em;
            text-align: center;
        }
        .XYTipsWindow .boxTitle, .XYTipsWindow .boxTitle span, .XYTipsWindow .boxTitle span.hover, .XYTipsWindow .loadinglayer, .XYTipsWindow .tipslayer, .XYTipsWindow .arrowLeft, .XYTipsWindow .colseBtn, .XYTipsWindow .boxError em, .XYTipsWindow .dialogBtn, .XYTipsWindow .dialogBtn.hover
        {
            background-image: url("../image/ico.png");
            background-repeat: no-repeat;
        }
        .XYTipsWindow .boxTitle
        {
            position: relative;
            border: 1px solid #A6C9E1;
            border-bottom: none;
            background-position: 0 0;
            background-repeat: repeat-x;
            height: 30px;
            line-height: 30px;
        }
        .XYTipsWindow .boxTitle h3
        {
            float: left;
            font-weight: normal;
            color: #666;
            font-size: 14px;
            margin: 0;
            text-indent: 10px;
        }
        .XYTipsWindow .boxTitle span
        {
            position: absolute;
            width: 10px;
            background-position: -80px -40px;
            text-indent: -10em;
            right: 10px;
            top: 10px;
            height: 16px;
            overflow: hidden;
            cursor: pointer;
        }
        .XYTipsWindow .boxTitle span.hover
        {
            background-position: -90px -40px;
        }
        .XYTipsWindow .loadinglayer
        {
            line-height: 40px;
            background-position: 0 -100px !important;
        }
        .XYTipsWindow .tipslayer
        {
            line-height: 20px;
            text-align: left;
        }
        .XYTipsWindow .arrowLeft
        {
            position: absolute;
            width: 8px;
            height: 16px;
            background-position: -20px -170px;
            text-indent: -9999em;
            z-index: 20591;
            overflow: hidden;
        }
        .XYTipsWindow .colseBtn
        {
            position: absolute;
            top: 5px;
            right: 5px;
            width: 8px;
            height: 8px;
            background-position: -55px -170px;
            text-indent: -9999em;
            cursor: pointer;
            z-index: 20591;
            overflow: hidden;
        }
        .XYTipsWindow .boxError
        {
            position: absolute;
            left: 50%;
            top: 50%;
            margin-left: -60px;
            margin-top: -15px;
            width: 120px;
            height: 30px;
            line-height: 30px;
            color: #f00;
        }
        .XYTipsWindow .boxError em
        {
            float: left;
            width: 30px;
            height: 30px;
            background-position: -35px -140px;
        }
        .XYTipsWindow .dialogBtn
        {
            margin: 5px 5px 0 0;
            width: 80px;
            height: 35px;
            background-position: 0 -30px;
            border: none;
            color: #333;
        }
        .XYTipsWindow .dialogBtn.hover
        {
            background-position: 0 -65px;
        }
        .XYTipsWindow.shadow
        {
            box-shadow: 2px 2px 5px #C0BBB5;
            -moz-box-shadow: 2px 2px 5px #C0BBB5;
            -webkit-box-shadow: 2px 2px 5px #C0BBB5;
        }
    </style>
    <link href="../Css/logion.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GridViewColor();">
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
    <table border="1">
        <tr>
            <td>
                方案编号：
            </td>
            <td>
                <asp:TextBox ID="txtQnumber" runat="server"></asp:TextBox>
            </td>
            <td>
                发布人：
            </td>
            <td style="width: 160px">
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 160px">
                <asp:Button ID="btnOK" runat="server" Text="查询" OnClick="btnOK_Click" Width="83px" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="批量删除" />
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="My_GridView" runat="server" AutoGenerateColumns="False" Width="100%"
            OnRowCreated="myGridView_RowCreated" OnRowDataBound="myGridView_RowDataBound"
            EnableModelValidation="True">
            <FooterStyle CssClass="GridView_Footer" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <input id="checkAll" type="checkbox" onclick="CheckAll(this)" />
                        全选
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方案编号">
                    <ItemTemplate>
                        <asp:Label ID="lab_Qnumber" Text='<%# Eval("QNumber") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="彩种">
                    <ItemTemplate>
                        <asp:Label ID="lab_lottName" runat="server"></asp:Label>
                        <%# LotteryFmt(Eval("playName"))%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期号">
                    <ItemTemplate>
                        <%# Eval("ExpectNum")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方案标题">
                    <ItemTemplate>
                        <%# Eval("Title") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方案金额">
                    <ItemTemplate>
                        ￥
                        <%# Eval("AtotalMoney") %>
                        元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="份数">
                    <ItemTemplate>
                        <%# Eval("Share")%>
                        份
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="每份金额">
                    <ItemTemplate>
                        ￥
                        <asp:Label ID="lab_each" runat="server"></asp:Label>
                        元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="保底">
                    <ItemTemplate>
                        <asp:Label ID="lab_Protect" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="购买会员">
                    <ItemTemplate>
                        <a href="ChippedName.aspx?Id=<%# Eval("QNumber") %>">查看</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否成功">
                    <ItemTemplate>
                        <asp:Label ID="lab_yn" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布人">
                    <ItemTemplate>
                        <%# Eval("UserName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布时间">
                    <ItemTemplate>
                        <%# Eval("LaunchTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="返回状态">
                    <ItemTemplate>
                        <%#  Pbzx.Common.Method.GetXmlLottoryByValue(Convert.ToInt32(Eval("Opens")), 2)%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="认购份数">
                    <ItemTemplate>
                        <%# Eval("BuyShare") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方案内容">
                    <ItemTemplate>
                        <a href="#" onclick="view_s('<%#Eval("ChoiceNum")%>','<%#Eval("playName")%>')">查看</a>
                        <%--   <%# Content(Eval("ChoiceNum"), Eval("QNumber"), Eval("playName"))%>--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit1"
                            Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete1"
                            Text="删除" CommandArgument='<%# Eval("QNumber") %>' OnCommand="LinkButton2_Command"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="GridView_Pager" />
            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
            <RowStyle CssClass="GridView_Row" />
            <PagerSettings Mode="NumericFirstLast" Visible="False" />
        </asp:GridView>
        <script>
            function CheckAll(val) {

                var items = document.getElementsByTagName("input");
                for (var i = 0; i < items.length; i++) {

                    if (items[i].type == "checkbox") {
                        items[i].checked = val.checked;
                    }
                }
            }
        </script>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="height: 48px">
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
    </div>
    <uc1:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
