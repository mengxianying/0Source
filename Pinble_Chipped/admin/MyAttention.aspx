<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAttention.aspx.cs" Inherits="Pinble_Chipped.admin.MyAttention" %>

<%@ Register Src="../Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>

<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>我的关注</title>
    <link type="text/css" rel="Stylesheet" href="../Css/Title.css" />
    <link type="text/css" rel="stylesheet" href="../Css/footer.css" />
    <link href="../Css/logion.css" rel="stylesheet" type="text/css" />
     <link type="text/css" rel="stylesheet" href="../Css/style.css" />
        <style type="text/css">
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
        <asp:GridView ID="My_GridView" runat="server"  AutoGenerateColumns="False" CellPadding="4" GridLines="None" Width="99%" AllowPaging="True" OnRowCreated="My_GridView_RowCreated" CssClass="rec_table" OnRowDeleting="My_GridView_RowDeleting"  ForeColor="#333333">
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="我的关注">
                       <ItemTemplate>
                        <%# Eval("AName") %>
                       </ItemTemplate>         
                </asp:TemplateField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                
            </Columns>
            <HeaderStyle Font-Bold="True" CssClass="form" />
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
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
