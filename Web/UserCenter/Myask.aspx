<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Myask.aspx.cs" Inherits="Pbzx.Web.UserCenter.Myask" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拼搏吧</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="805" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFCB99" align="center"
                class="uc_MT10">
                <tr>
                    <td bgcolor="#FFF8EE" class="uc_font_black">
                        <span>&nbsp;拼搏吧：</span><span class="uc_font_redB"><asp:Label ID="lbName" runat="server"></asp:Label></span>&nbsp;头衔：<span
                            class="uc_font_redB"><asp:Label ID="lbtitle" runat="server"></asp:Label></span>&nbsp;积分：<span
                                class="uc_font_redB"><asp:Label ID="lbScore" runat="server"></asp:Label></span>&nbsp;<asp:LinkButton
                                    ID="lbjf" runat="server" OnClick="lbjf_Click">查看积分</asp:LinkButton>
                        |
                        <asp:LinkButton ID="lbask" runat="server" OnClick="lbask_Click">我的提问</asp:LinkButton>
                        |
                        <asp:LinkButton ID="lbanswer" runat="server" OnClick="lbanswer_Click">我的回答</asp:LinkButton></td>
                </tr>
            </table>
            <asp:Panel runat="server" ID="pnl2" Width="100%" Visible="true">
                <table width="805" cellpadding="2" cellspacing="0" border="0" align="center" class="uc_MT10">
                    <tr>
                        <td align="left" colspan="5" class="uc_font_blue14">
                            积分明细
                        </td>
                    </tr>
                </table>
                <table width="805" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#dddddd">
                    <tr bgcolor="#f6f6f6">
                        <td class="uc_12bold" align="center">
                            总分</td>
                        <td class="uc_12bold" align="center">
                            奖励得分</td>
                        <td class="uc_12bold" align="center">
                            历史付出</td>
                        <td class="uc_12bold" align="center">
                            处罚</td>
                    </tr>
                    <tr bgcolor="#ffffff">
                        <td align="center">
                            <asp:Label ID="lblTotalPoint" runat="server">0</asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblAnswerPoint" runat="server">0</asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblXSPoint" runat="server">0</asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblOtherPointpenalty" runat="server">0</asp:Label></td>
                    </tr>
                </table>
                <table width="805" cellpadding="2" cellspacing="0" border="0" align="center" class="uc_MT10">
                    <tr>
                        <td align="left" colspan="5" class="uc_font_blue14">
                            问答明细
                        </td>
                    </tr>
                </table>
                <table width="805" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#dddddd">
                    <tr bgcolor="#f6f6f6">
                        <td class="uc_12bold" align="center">
                            回答总数</td>
                        <td class="uc_12bold" align="center">
                            回答被采纳</td>
                        <td class="uc_12bold" align="center">
                            回答被采纳率</td>
                        <td class="uc_12bold" align="center">
                            提问数</td>
                        <td class="uc_12bold" align="center">
                            已经解决</td>
                        <td class="uc_12bold" align="center">
                            解决中</td>
                        <td class="uc_12bold" align="center">
                            已关闭</td>
                    </tr>
                    <tr bgcolor="#ffffff">
                        <td align="center">
                            <asp:Label ID="lblAnswerCount" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblBestAnswer" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblRat" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblAskCount" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblHasAnwer" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblInAnswer" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblClose" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnl3" Width="100%" Visible="false">
                <div class="uc_MT10">
                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="805px"
                        CssClass="GridViewStyle" HorizontalAlign="Center" DataKeyNames="Id" CellPadding="0"
                        AllowPaging="True" PageSize="20">
                        <Columns>
                            <asp:TemplateField HeaderText="标题">
                                <ItemTemplate>
                                 &nbsp;· <a href='<%=WebInit.ask.WebUrl %>Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>'
                                        target="_blank" class="Linl14"><%#StrFormat.CutStringByNum(Eval("Title"),33*2)%>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle Width="60%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="回答数">
                                <ItemTemplate>
                                    <%#Eval("Replys")%>
                                </ItemTemplate>
                                <ItemStyle Width="11%" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <img src='../images/web/State_<%#Eval("State") %>.gif' width="16" height="16" />
                                </ItemTemplate>
                                <ItemStyle Width="9%" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="提问时间">
                                <ItemTemplate>
                                    <%# Eval("AskTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                </ItemTemplate>
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="RowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                    </asp:GridView>
                    <asp:Label ID="litContent" runat="server"></asp:Label>
                    <table width="98%" border="0" align="center" cellpadding="1" cellspacing="0">
                        <tr>
                            <td bgcolor="" style="height: 1px">
                                <!--  #83B5E2 -->
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="5"
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                    ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center" CssClass="Link_Xia">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnl4" Width="100%" Visible="false">
                <div class="uc_MT10">
                    <asp:GridView ID="MyGridView1" runat="server" AutoGenerateColumns="False" Width="805"
                        CssClass="GridViewStyle" HorizontalAlign="Center" BorderColor="#E0E0E0" BorderStyle="Solid"
                        BorderWidth="1px">
                        <Columns>
                            <asp:TemplateField HeaderText="标题">
                                <ItemTemplate>
                                  &nbsp;· <a href='<%=WebInit.ask.WebUrl %>Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>'
                                        target="_blank" class="Linl14"><%#StrFormat.CutStringByNum(Eval("Title"),33*2)%>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle Width="51%" />
                                <HeaderStyle CssClass="list_xia2" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="回答数">
                                <ItemTemplate>
                                    <%#Eval("Replys")%>
                                </ItemTemplate>
                                <ItemStyle Width="11%" HorizontalAlign="Center" />
                                <ControlStyle CssClass="list_xia2" />
                                <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <img src='../images/web/State_<%#Eval("State") %>.gif' width="16" height="16" />
                                </ItemTemplate>
                                <ItemStyle Width="9%" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="提问时间">
                                <ItemTemplate>
                                    <%# Eval("AskTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                </ItemTemplate>
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                                <ControlStyle CssClass="list_xia2" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="RowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                    </asp:GridView>
                    <asp:Label ID="litContent1" runat="server"></asp:Label>
                    <table width="98%" border="0" align="center" cellpadding="1" cellspacing="0">
                        <tr>
                            <td bgcolor="" style="height: 1px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="5"
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                    ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center" CssClass="Link_Xia">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
