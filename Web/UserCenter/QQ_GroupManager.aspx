<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QQ_GroupManager.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.QQ_GroupManager" %>

<%@ Register Src="Contorls/UcGroupSearch.ascx" TagName="UcGroupSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcOrder.ascx" TagName="UcOrder" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QQ群管理 - 拼搏在线彩神通软件</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="680" class="uc_xia" valign="bottom">
                      <a href="QQ_GroupManager.aspx">  <span class="uc_font_blue14">QQ群管理</span></a>&nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;<a href="QQ_RecordManager.aspx">QQ号管理</a>
                        <%--（点击订单号可以查看订单详情！）--%></td>
                    <td width="680" class="uc_xia" valign="bottom" align="right">
                        <%--<font color="#FF0000">（如果订单还未付款您可以点击'取消'按钮,取消该订单。）</font>--%>
                        <a href="QQ_GroupEdite.aspx">添加QQ群</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#FFCB99">
                <tr>
                    <td bgcolor="#FFF8EE" align="left">
                        <uc1:UcGroupSearch ID="UcGroupSearch1" runat="server"></uc1:UcGroupSearch>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellspacing="0" align="center" cellpadding="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="gvOrderList" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" PageSize="20"
                            CssClass="GridViewStyle" OnRowDataBound="gvOrderList_RowDataBound"
                            OnSorting="gvOrderList_Sorting">
                            <Columns>
                                <asp:BoundField HeaderText="序号">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="QQ群号">
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_GroupEdite.aspx?GropID=<%#Eval("ID") %>">
                                            <%#Eval("QQ_GroupID")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="群名称" SortExpression="QQ_GroupName">
                                    <ItemTemplate>
                                        <%#Eval("QQ_GroupName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="25%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="群类型" SortExpression="QQ_GroupType">
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_GroupManager.aspx?QQ_GroupType=<%#Eval("QQ_GroupType") %>">
                                            <%# Pbzx.Web.WebFunc.GetQQGroupTypeName(Eval("QQ_GroupType"))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件用户群" Visible="False">
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_GroupManager.aspx?IsSoftGroup=<%#Eval("IsSoftGroup") %>">
                                            <%# Convert.ToBoolean(Eval("IsSoftGroup")) ? "是" : "否" %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="群管理员">
                                    <ItemStyle CssClass="msg" HorizontalAlign="Center" Width="38%" />
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_GroupManager.aspx?QQ_GroupAdmin=<%#Eval("QQ_GroupAdmin") %>">
                                            <%# Pbzx.Web.WebFunc.FormartQQGroupAdmin1(Eval("QQ_GroupAdmin"))%>
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QQ群备注" Visible="False">
                                    <ItemTemplate>
                                        <span title="<%#Eval("QQ_GroupDetails")%>">
                                            <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("QQ_GroupDetails"),20*2)%>
                                        </span>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="启用">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("IsEnable")) ? "是" : "<font color='red'>否</font>" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href="QQ_GroupEdite.aspx?GropID=<%#Eval("ID") %>">查看</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellspacing="0" align="center" cellpadding="4">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            CustomInfoStyle='vertical-align:middle;' class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center" PageSize="20" SubmitButtonClass="page_go">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
