<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="platform_add.aspx.cs" Inherits="Pbzx.Web.PB_Manage.platform_add" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>平台图标添加</title>
    <link type="text/css" rel="stylesheet" href="StyleCss/css.css" />
    <style type="text/css">
        .style1
        {
            width: 105px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
            <tr bgcolor="#f2f8fb">
                <td background="images/Us_table _bg.jpg">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td background="images/Us_table _bg.jpg" class="webconfigbg">
                                <strong>添加主页平台图标</strong>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>添加主页导航图标：</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                图片名称：
                            </td>
                            <td width="24%" align="left">
                                <asp:TextBox ID="txtImgName" runat="server" Width="180px"></asp:TextBox><br />
                                (注：添加图片的全称带后缀名 没有图片可以为空)
                            </td>
                            <td width="16%" align="right">
                                平台网址：
                            </td>
                            <td width="46%" align="left">
                                <asp:TextBox ID="txtUrl" runat="server" Width="200px"></asp:TextBox>（例：http://xxx.xx.com）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" valign="top">
                                平台的名称：
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtPname" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td align="right" valign="top">
                                是否开启：
                            </td>
                            <td align="left" valign="top">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Selected="True">开启</asp:ListItem>
                                    <asp:ListItem Value="1">关闭</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" />
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" Width="100%" AllowSorting="True"
                        EnableModelValidation="True" OnRowCreated="MyGridView_RowCreated" 
                        onrowcancelingedit="MyGridView_RowCancelingEdit" 
                        onrowediting="MyGridView_RowEditing" 
                        onrowupdating="MyGridView_RowUpdating" 
                        onrowdatabound="MyGridView_RowDataBound" onrowdeleting="MyGridView_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="序号" />
                            <asp:TemplateField HeaderText="平台名称">
                                <ItemTemplate>
                                    <%# Eval("P_pfName")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_pfName" runat="server" Text='<%# Eval("P_pfName")%>' Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="18%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="网址">
                                <ItemTemplate>
                                    <%# Eval("P_pfPath")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_pfPath" runat="server" Text='<%# Eval("P_pfPath")%>' Width="210px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="23%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="图片名称">
                                <ItemTemplate>
                                    <%# Eval("p_imgName")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_imgName" runat="server" Text='<%# Eval("p_imgName")%>' Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="17%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态" SortExpression="Status">
                                <ItemTemplate>
                                    <%# Convert.ToInt32(Eval("P_state"))==0 ? "开启" : "关闭"%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">启用</asp:ListItem>
                                        <asp:ListItem Value="1">禁用</asp:ListItem>
                                    </asp:RadioButtonList>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序">
                                <ItemTemplate>
                                    <%# Eval("P_Sort")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_sort" Width="10px" runat="server" Text='<%# Eval("P_Sort") %>' onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="5%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                        </Columns>
                        <PagerStyle CssClass="GridView_Pager" />
                        <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                        <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        <RowStyle CssClass="GridView_Row" />
                        <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                        <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" />
                    </td>
                            <td style="height: 31px">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                                    LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                    PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                    CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                                    CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="25%"
                                    CustomInfoTextAlign="Center">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
