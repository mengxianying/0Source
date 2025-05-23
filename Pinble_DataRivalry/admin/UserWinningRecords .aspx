<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWinningRecords .aspx.cs" Inherits="Pinble_DataRivalry.admin.UserWinningRecords" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户中奖详细页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="期号">
                <ItemTemplate>
                    <%# Eval("Rt_Period")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开奖号码">
                    <ItemTemplate>
                        <%# Eval("Rt_AwardNum") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中单">
                    <ItemTemplate>
                        <%# Eval("Rt_Single")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中组">
                    <ItemTemplate>
                        <%# Eval("Rt_Group") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中2位">
                    <ItemTemplate>
                        <%# Eval("Rt_two") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中1位">
                    <ItemTemplate>
                        <%# Eval("Rt_one") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中0位">
                    <ItemTemplate>
                        <%# Eval("Rt_zero") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="变单">
                    <ItemTemplate>
                        <%# Eval("Rt_Radio")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="变组">
                    <ItemTemplate>
                        <%# Eval("Rt_choose")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
    </form>
</body>
</html>
