<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LyBookDisp.aspx.cs" Inherits="Pbzx.Web.UserCenter.LyBookDisp" %>

<%@ Register Src="Contorls/UcLyBookDisp.ascx" TagName="UcLyBookDisp" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看留言回复</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
     function ShowLY()
     {
       var result = window.showModalDialog('LyBook.aspx','','dialogHeight:350px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:no;status:no;toolbar:no;menubar:no;location:no;');
       if(result!=null && result.length > 0)
       {
             window.location.reload();
       }
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <%--   <iframe   name=bbc2188   width=0   height=0   frameborder=0   style="display:   none"></iframe>  --%>
        <div style="height: 100%">
            <table width="800" border="0" align="center" cellpadding="2" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="690" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">我的留言</span></td>
                    <td valign="bottom" class="uc_xia" width="90" vspace="0">
                        <a href="#" onclick="ShowLY();">
                            <img src="/Images/Web/Ly_btn.gif" border="0" />
                            <%--  <span class="uc_font_red">我要留言</span>--%>
                        </a>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#FFCB99">
                <tr>
                    <td bgcolor="#FFF8EE">
                        <uc1:UcLyBookDisp ID="UcLyBookDisp1" runat="server"></uc1:UcLyBookDisp>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" Width="100%" CssClass="GridViewStyle"
                            AutoGenerateColumns="False" OnRowDataBound="MyGridView_RowDataBound" DataKeyNames="SystemNumber">
                            <Columns>
                                <asp:TemplateField HeaderText="序号" SortExpression="SystemNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("SystemNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" SortExpression="Ly_Email">
                                    <ItemTemplate>
                                        <%#Eval("Ly_Email")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="39%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="问题状态" SortExpression="LyState">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("LyState")) ? "<font color=green>已回复</font>" : "<font color=red>未回复</font>" %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="问题类型" SortExpression="LySort">
                                    <ItemTemplate>
                                        <%# Pbzx.Web.WebFunc.GetLyTypeByID(Eval("LySort"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="问题/回复">
                                    <ItemTemplate>
                                        <a href="#" onclick="window.showModalDialog('LyDetails.aspx?ID=<%#Eval("SystemNumber")%>','','dialogHeight:390px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:no;status:no;toolbar:no;menubar:no;location:no;');">
                                            详细信息</a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="16%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="提问时间" SortExpression="LyLogTime">
                                    <ItemTemplate>
                                        <%#Eval("LyLogTime","{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="19%" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EmptyDataTemplate>
                                <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#DCEDFC">
                                    <tr>
                                        <td width="7%" align="center">
                                            序号
                                        </td>
                                        <td width="35%" align="center">
                                            标题</td>
                                        <td width="12%" align="center">
                                            问题状态</td>
                                        <td width="12%" align="center">
                                            问题类型</td>
                                        <td width="15%" align="center">
                                            问题/回复</td>
                                        <td width="19%" align="center">
                                            提问时间</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="32px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" HorizontalAlign="Right" SubmitButtonClass="page_go" CustomInfoStyle='vertical-align:middle;'>
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
