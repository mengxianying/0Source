<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserIntegral.aspx.cs" Inherits="Pinble_Challenge.challenge.UserIntegral" %>

<%@ Register Src="../Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户积分 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="../cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../cssTab/global.css" />
    <script type="text/javascript" src="../js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="../js/btnSwitch.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
    </div>
    <div class="zanneiy_top_C">
        <uc1:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj" style="text-align:center" id="gd1" runat="server">
                    <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" Width="99%"
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None"
                        BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCreated="GridView1_RowCreated"
                        OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
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
                                    <%# Eval("I_name")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="彩种">
                                <ItemTemplate>
                                    <asp:Label ID="lab_lott" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="条件名称">
                                <ItemTemplate>
                                    <asp:Label ID="lab_name" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="积分">
                                <ItemTemplate>
                                    <%# Eval("I_Integral")%>
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
                <div class="yny_zhongj" style="text-align:center" id="gduser" runat="server" visible="false">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        Width="99%" CssClass="tabs-main" 
                        EnableModelValidation="True"
                        onrowcreated="GridView2_RowCreated" onrowdatabound="GridView2_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="序号" />

                            <asp:TemplateField HeaderText="用户名">
                                <ItemTemplate>
                                    <%# Eval("I_name")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="彩种">
                                <ItemTemplate>
                                    <asp:Label ID="lab_lott" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="条件名称">
                                <ItemTemplate>
                                    <asp:Label ID="lab_name" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="积分">
                                <ItemTemplate>
                                    <%# Eval("I_Integral")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="yny_neirong_C">
            </div>
        </div>
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
            <div class="footer" style="clear: both;">
                <uc2:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
