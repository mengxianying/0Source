<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseManage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Platform.num.ReleaseManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户发布管理</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/css.css" />
    <script language="javascript" src="../../JScript/javascript.js" type="text/javascript"></script>
        <script language="javascript" type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script language="javascript" type="text/javascript" src="js/JScript1.js"></script>
    <script language="javascript" type="text/javascript" src="js/jquery.XYTipsWindow.2.7.js"></script>
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <script type="text/javascript">
        window.onload = function () {
            GridViewColor();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Right_bg1">
                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <td width="91%" align="left">
                            发布管理
                        </td>
                        <td width="9%" align="right">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel runat="server">
    <contenttemplate>
             <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                        class="MT">
        <tr>
            <td bgcolor="#F7FBFF" align="left">
                <table width="80%" border="0" cellspacing="0" cellpadding="1">
                    <tr>
                        <td>
                            会员名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="125"></asp:TextBox></td>
                            <td>
                               大底名称：</td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" Width="125"></asp:TextBox></td>
                            <td align="right">
                                期号：
                            </td>
                            <td>
                              <asp:TextBox ID="txtIssue" runat="server"></asp:TextBox>
                               
                               </td>
                            <td>
                            <%--文件名称：--%>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>--%>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            大底个数：
                        </td>
                        <td>
                            最小<asp:TextBox ID="txtSmall" runat="server" Width="50px"></asp:TextBox>---
                            最大<asp:TextBox ID="txtBig" runat="server" Width="50px"></asp:TextBox>
                            
                            </td>
                            <td>
                               <asp:Button ID="btnOK" runat="server" Text="查找" onclick="btnOK_Click" />&nbsp;<asp:Button 
                                    ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" /></td>
                            <td>
                                &nbsp;
                                
                                </td>
                            <td>
                                &nbsp;
                                 
                            </td>
                            <td>
                            &nbsp;
                               </td>
                            <td>
                           
                            </td>
                            <td>
                                &nbsp;
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
        class="MT">
        <tr bgcolor="#ffffff">
            <td>
                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    Width="100%" EnableModelValidation="True" GridLines="Vertical" OnRowCreated="MyGridView_RowCreated"
                    OnRowDeleting="MyGridView_RowDeleting" CssClass="GridView_Table" 
                    OnRowDataBound="MyGridView_RowDataBound" onrowediting="MyGridView_RowEditing">
                    <FooterStyle CssClass="GridView_Footer" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cb" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="序号" />
                        <asp:TemplateField HeaderText="期号">
                            <ItemTemplate>
                                <%# Eval("F_Period")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发布会员">
                            <ItemTemplate>
                                <%# Eval("F_UserName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="文件名">
                            <ItemTemplate>
                                <%# Eval("F_FileName") %>
                                .txt
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="大底个数">
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
                        <asp:TemplateField HeaderText="号码">
                            <ItemTemplate>
                                <a href="javascript:void(0)" onclick="SelectNum('<%# Eval("Ct_Num") %>',<%# Eval("F_Period") %>,<%# Eval("F_lottery") %>)">
                                    查看号码</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="GridView_Pager" />
                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                    <RowStyle CssClass="GridView_Row" />
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT2">
        <tr>
            <td align="left">
                <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" Style="height: 21px" />
            </td>
            <td height="32px">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                    Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                    CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
