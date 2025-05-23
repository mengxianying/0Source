<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ask_Attach.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ask_Attach" %>

<%@ Register Src="Controls/Uc_Ask_Attach.ascx" TagName="Uc_Ask_Attach" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>上传文件管理</title>
      <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
       <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
    <div>
       <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：上传文件管理</td>
                                            <td width="9%" align="right">
                                               <%-- <asp:Button ID="Button2" runat="server" Text=">>返回" OnClientClick="history.back();return false;" />--%></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left"> 
                        <uc1:Uc_Ask_Attach id="Uc_Ask_Attach1" runat="server">
                        </uc1:Uc_Ask_Attach></td>
                </tr>
            </table>
              <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="Solid" DataKeyNames="Id" Width="100%" CellPadding="0" CssClass="GridView_Table" OnRowDeleting="MyGridView_RowDeleting" OnRowDataBound="MyGridView_RowDataBound" OnSorting="MyGridView_Sorting">
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="序号" >
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                    <ItemTemplate>
                                      <%#Eval("UserName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="文件地址" SortExpression="OriginalFile">
                                   <ItemTemplate>
                                  &nbsp;<%#Eval("OriginalFile")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="22%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="问题ID" SortExpression="QuestionId">
                                  <ItemTemplate>
                                      <%#Eval("QuestionId")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="文件大小" SortExpression="FileSize">
                                  <ItemTemplate>
                                      <%#Eval("FileSize")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回复ID" SortExpression="ReplayId">
                                  <ItemTemplate>
                                      <%#Eval("ReplayId")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="上传时间" SortExpression="Addtime">
                                  <ItemTemplate>
                                      <%#Eval("Addtime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" />
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="删除" InsertVisible="False" ShowCancelButton="False"
                                    ShowDeleteButton="True"  DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;" >
                                    <ItemStyle Width="8%" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                <tr>
                    
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="3" CustomInfoStyle='vertical-align:middle;'
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
