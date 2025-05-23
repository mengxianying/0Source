<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseManage.aspx.cs"
    Inherits="Pinble_DataRivalry.admin.ReleaseManage" %>


<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../Contorls/logion1.ascx" tagname="logion1" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户发布管理</title>
    <link type="text/css" rel="Stylesheet" href="../cssTab/global.css" />
    <link type="text/css" rel="stylesheet" href="../cssTab/css.css" />
    <link type="text/css" rel="stylesheet" href="../cssTab/style.css" />
    <script type="text/javascript" src="../js/GridView.js"></script>
         <script type="text/javascript" src="../jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="../jQuery/jquery.XYTipsWindow.min.2.7.js"></script>
    <script type="text/javascript" src="../js/JScript1.js"></script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
    <!--header部分-->
    <div class="header">
        <div class="logo">
        </div>
        <div class="login_info">
            <uc2:logion1 ID="logion11" runat="server" />
        </div>
        <div class="nav">
            <dl class="b-top-nav">
            </dl>
        </div>
    </div>
    <div>
        <!--header部分-->
        <asp:GridView ID="my_GridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
            Width="99%" AllowPaging="True" OnRowCreated="my_GridView_RowCreated" OnRowDeleting="my_GridView_RowDeleting"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            EnableModelValidation="True" onrowediting="my_GridView_RowEditing" 
            PageSize="60">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cb" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期号">
                    <ItemTemplate>
                        <%# Eval("F_Period")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件名">
                    <ItemTemplate>
                        <%# Eval("F_FileName") %>
                        .txt
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="大底范围">
                    <ItemTemplate>
                        <%# Eval("F_FileNum") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="大底类型">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("F_SingleGroup"))==1 ? "单选大底" : "多选大底" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上传时间">
                    <ItemTemplate>
                        <%# Eval("F_addTime") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="属于彩种">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("F_lottery"))==1 ? "福彩3D" : "排列三" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="属于彩种">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("F_state")) == 0 ? "等待开奖" : "开奖完成"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="属于彩种">
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="SelectNum('<%# Eval("Ct_Num") %>',<%# Eval("F_Period") %>,<%# Eval("F_lottery") %>)">查看号码</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" CssClass="form" BackColor="#006699" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <table width="98%">
            <tr>
                <td align="left">
                    <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                    <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                    <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" />
                </td>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <uc1:Footer ID="Footer1" runat="server"></uc1:Footer>
    </div>
    </form>
</body>
</html>
