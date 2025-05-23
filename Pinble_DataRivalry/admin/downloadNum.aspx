<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloadNum.aspx.cs" Inherits="Pinble_DataRivalry.admin.downloadNum" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员下载次数 - 大底比拼 - 拼搏在线彩神通软件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" EnableModelValidation="True" GridLines="Vertical" 
            Width="99%" onrowcreated="GridView1_RowCreated" 
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
                <asp:TemplateField HeaderText="会员名">
                <ItemTemplate>
                    <%# Eval("Dl_name")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="下载次数">
                <ItemTemplate>
                    <%# Eval("Dl_dl")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="下载时间">
                <ItemTemplate>
                    <%# Eval("Dl_Time")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="大底名称">
                <ItemTemplate>
                    <%# Eval("F_FileName")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布会员">
                <ItemTemplate>
                    <%# Eval("F_username")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属彩种">
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("F_lottery"))==1 ? "福彩3D" : "排列三"%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="大底类型">
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("F_SingleGroup")) == 1 ? "单选" : "组选"%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />
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
