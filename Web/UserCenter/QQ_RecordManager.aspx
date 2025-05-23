<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QQ_RecordManager.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.QQ_RecordManager" %>

<%@ Register Src="Contorls/UcRecordSearch.ascx" TagName="UcRecordSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcOrder.ascx" TagName="UcOrder" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>QQ号管理_拼搏在线彩神通软件</title>
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
                        <a href="QQ_RecordManager.aspx"><span class="uc_font_blue14">
                            <asp:Label ID="lblGroup" runat="server" Text=""></asp:Label>
                            QQ号管理</span></a> &nbsp;&nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblQQGroupLink" runat="server" Text=""></asp:Label>
                        <%--（点击订单号可以查看订单详情！）--%>
                    </td>
                    <td width="680" class="uc_xia" valign="bottom" align="right">
                        <%--<font color="#FF0000">（如果订单还未付款您可以点击'取消'按钮,取消该订单。）</font>--%>
                        <a href="QQ_RecordEdite.aspx">添加QQ号</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#FFCB99">
                <tr>
                    <td bgcolor="#FFF8EE" align="left">
                        <uc1:UcRecordSearch ID="UcRecordSearch1" runat="server"></uc1:UcRecordSearch>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellspacing="0" align="center" cellpadding="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="gvOrderList" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" PageSize="20"
                            CssClass="GridViewStyle" OnRowDataBound="gvOrderList_RowDataBound" DataKeyNames="ID,QQ_GropID,QQ_ID,UserName,OnlineState"
                            OnSorting="gvOrderList_Sorting">
                            <Columns>
                                <asp:BoundField HeaderText="序号">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="QQ号" SortExpression="QQ_ID">
                                    <ItemTemplate>
                                        <a href="QQ_RecordEdite.aspx?ID=<%#Eval("ID")%>">
                                            <%#Eval("QQ_ID")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属QQ群" SortExpression="QQ_GropID">
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_RecordManager.aspx?GropID=<%#Eval("QQ_GropID") %>">
                                            <%# Pbzx.Web.WebFunc.GetGroupByID(Eval("QQ_GropID")).QQ_GroupName%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="论坛名">
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_RecordManager.aspx?UserName=<%#Eval("UserName") %>">
                                            <%#Eval("UserName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemStyle CssClass="msg" HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <a href="/UserCenter/QQ_RecordManager.aspx?OnlineState=<%#Eval("OnlineState") %>">
                                            <%# Pbzx.Web.WebFunc.GetQQOnlieState(Eval("OnlineState"))%>
                                        </a>
                                        <%# Convert.ToBoolean(Eval("IsLock")) ? "(锁)" : "" %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="加入时间" SortExpression="AddTime">
                                    <ItemTemplate>
                                        <%# Eval("AddTime","{0:yyyy-MM-dd}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="退出时间" SortExpression="KickOffTime">
                                    <ItemTemplate>
                                        <%# Eval("KickOffTime","{0:yyyy-MM-dd}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href="QQ_RecordEdite.aspx?ID=<%#Eval("ID")%>">查看/修改</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
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
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20"
                            SubmitButtonClass="page_go">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
