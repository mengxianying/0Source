<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminData.aspx.cs" Inherits="Pinble_Challenge.challenge.adminData" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理数据 - 拼搏擂台 - 拼搏在线彩神通软件</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="txt_condition" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;</asp:TextBox>
    <asp:Button ID="but_search"
        runat="server" Text="搜索" onclick="but_search_Click" />



    <div>
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" Width="99%"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
            onrowcreated="GridView1_RowCreated" 
            onrowdatabound="GridView1_RowDataBound" 
            onrowdeleting="GridView1_RowDeleting">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cb" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户名">
                <ItemTemplate>
                    <%# Eval("C_name") %>
                </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="日期">
                <ItemTemplate>
                    <%# Eval("C_time") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="彩种">
                <ItemTemplate>
                    <asp:Label ID="lab_lottName" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期号">

                <ItemTemplate>
                    <%# Eval("C_issue") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="条件">
                <ItemTemplate>
                    <%# Eval("T_cond") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="号码">
                    <ItemTemplate>
                        <%# Eval("C_num") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否中奖">
                    <ItemTemplate>
                        <asp:Label ID="lab_win" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开奖号码">
                    <ItemTemplate>
                        <asp:Label ID="lab_num" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
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
    </div>
    </form>
</body>
</html>
