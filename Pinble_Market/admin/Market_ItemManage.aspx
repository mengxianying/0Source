<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Codebehind="Market_ItemManage.aspx.cs"
    Inherits="Pinble_Market.admin.Market_ItemManage" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%--<%@ OutputCache Duration="5" VaryByParam="none" %> --%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目设定管理</title>
    <link href="../Css/input.css" rel="stylesheet" type="text/css" />
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/jquery-1.3.2.js"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <uc1:head ID="Head1" runat="server" />
        <div id="wrap" style="margin-bottom: 10px; margin-top: 10px;">
        <div class="Title">
                <div class="return_title">
                    项目条件管理</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <table width="99%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 10px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                <asp:LinkButton ID="lbtn_speakfor" runat="server" OnClick="lbtn_speakfor_Click">收费条件</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtn_free" runat="server" OnClick="lbtn_free_Click">免费条件</asp:LinkButton>
                                &nbsp; &nbsp;
                                <asp:LinkButton ID="lbtn_open" runat="server" OnClick="lbtn_open_Click">开放</asp:LinkButton>
                                &nbsp; &nbsp;&nbsp;
                                <asp:LinkButton ID="lbtn_close" runat="server" OnClick="lbtn_close_Click">关闭</asp:LinkButton>
                                &nbsp; &nbsp;&nbsp;
                                <asp:LinkButton ID="lbtn_resetTool" runat="server" OnClick="lbtn_resetTool_Click">重置</asp:LinkButton>
                            </div>
                            <div class="keyword">
                                <img src="../image/hot.gif" width="22" height="10" />
                                <span id="super_list" style="color: #FF0000">提示：取消和删除条件，先要锁定条件（锁定后前台不显示条件），所有的客户订制到时后。此项目才可删除。否则不能删除</span></div>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
                BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%" AllowPaging="True"
                OnRowCommand="Gvidlist_RowCommand" OnRowDataBound="Gvidlist_RowDataBound" OnRowDeleting="Gvidlist_RowDeleting"
                OnRowCreated="Gvidlist_RowCreated">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <FooterStyle CssClass="GridView_Footer" />
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号">
                        <ItemStyle Width="4%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="彩种">
                        <ItemStyle Width="5%" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NvarName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="条件名称">
                        <EditItemTemplate>
                            &nbsp;
                        </EditItemTemplate>
                        <ItemStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("TypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="收费类型">
                        <ItemStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# BindSF(Eval("Charge")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出售价格">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="8%" />
                        <ItemTemplate>
                            ￥<asp:Label ID="Label6" runat="server" Text='<%# Convert.ToInt32(Eval("Price")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="折扣">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Agio") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Convert.ToInt32(Eval("Agio")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="4%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IssueTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# string.Format("{0:u}", Eval("IssueTime")).Substring(0, 10) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="8%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="条件说明">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" title='<%# Eval("Say") %>' Text='<%#  TextFormat(Eval("Say"),20) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemStyle Width="5%" />
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# BindZT(Eval("[On_off]")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="最新内容">
                        <ItemStyle Width="13%" />
                        <ItemTemplate>
                            <%# BindNR(Eval("NvarName"), Eval("appendID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="查看">
                        <ItemTemplate>
                            <a href='Market_issuanceManage.aspx?id=<%# Pbzx.Common.Input.Encrypt(Eval("appendId").ToString()) %>&time=<%# Pbzx.Common.Input.Encrypt(Eval("IssueTime").ToString()) %>'
                                target="_blank">查看</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkbut1" runat="server" CommandArgument='<%# Eval("appendId") %>'
                                CommandName="KF">开放</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="linkbut2" runat="server" Visible="false" CommandArgument='<%# Eval("appendId") %>'
                                CommandName="SD">锁定</asp:LinkButton>
                            <asp:LinkButton ID="linkbut3" runat="server" CommandArgument='<%# Eval("appendId") %>'
                                CommandName="GB">关闭</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="linkbutDelete" runat="server" CommandArgument='<%# Eval("appendId") %>'
                                CommandName="Delete">删除</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# zu(Eval("appendId"),Eval("IntId"),Eval("Id")) %>'
                                CommandName="URL">修改</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Bold="True" CssClass="form" />
            </asp:GridView>
            <table cellpadding="0" cellspacing="0" border="0" width="98%" style="margin-top: 8px;">
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" /></td>
                    <td align="right">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20"
                            InputBoxClass="asptext" SubmitButtonClass="buttoncss" SubmitButtonStyle="" TextAfterInputBox="    ">
                        </webdiyer:AspNetPager>
                        </td>
                </tr>
            </table>
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
