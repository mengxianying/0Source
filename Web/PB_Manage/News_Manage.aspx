<%@ Page Language="C#" AutoEventWireup="true" Codebehind="News_Manage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.News_Manage"  %>

<%@ Register Src="Controls/UcNewsSearch.ascx" TagName="UcNewsSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>新闻资讯管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
            <tr>
                <td bgcolor="#F3F3F3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td width="91%" align="left">
                                            当前位置：<%--<asp:Label ID="labAction" runat="server" />--%>新闻管理</td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td align="CENTER" style="height: 26px">
                                <a href="News_Manage.aspx">新闻管理</a> |&nbsp;
                                <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加新闻</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton
                                    ID="lblCreateIndex" runat="server" OnClick="lblCreateIndex_Click" Text="更新首页和新闻资讯页"></asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
<%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                    class="MT">
                    <tr>
                        <td bgcolor="#F7FBFF" align="left">
                            <uc1:UcNewsSearch ID="UcNewsSearch1" runat="server"></uc1:UcNewsSearch>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    class="MT">
                    <tr bgcolor="#ffffff">
                        <td>
                            <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="IntID,NvarTitle"
                                CssClass="GridView_Table" OnRowDeleting="MyGridView_RowDeleting" OnRowDataBound="MyGridView_RowDataBound">
                                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                <FooterStyle CssClass="GridView_Footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="全选">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input type="checkbox" name="sel" value="<%#Eval("IntID") %>" /></ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                        <asp:BoundField HeaderText="序号" DataField="IntID"  ItemStyle-Width="4%"/>                                  
                                    <asp:TemplateField HeaderText="新闻标题">
                                        <ItemStyle HorizontalAlign="Left" Width="32%" />
                                        <ItemTemplate>
                                            <%# GetTitle(Eval("NvarTitle"), Eval("IsStatic"), Eval("SavePath"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属分类">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnIntShowType" runat="server"><%# GetTypeNameByID(Eval("IntShowType"))%></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="13%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="时间">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <%#Eval("DatDateAndTime","{0:yy-MM-dd HH:mm:ss}")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="内嵌">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnIsTop" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                                OnCommand="lbtnIsTop_Command"> <%#Convert.ToBoolean(Eval("ShowInSoft")) ? "<font color='red'>是</font>" : "<font color='black'>否</font>"%> </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="首页">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnShow" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                                OnCommand="lbtnShow_Command"><%# Convert.ToBoolean(Eval("ShowIndex")) ? "显示" : "<font color=red>不显</font>"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="固顶">
                                        <ItemTemplate>
                                            <%#GetIsTop(Eval("BitIsTop"))%>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发布">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnIsPass" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                                OnCommand="lbtnIsPass_Command">  <%#Convert.ToBoolean(Eval("BitIsPass")) ? "<font color='blue'>发布</font>" : "<font color='red'>不发布</font>"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="生成">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("IntID") %>'
                                                OnCommand="LinkButton1_Command">生成</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="编辑">
                                        <ItemTemplate>
                                          <a href='News_Editor.aspx?ID=<%#Eval("IntID") %>'>编辑</a>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    
                                                                                                            
                                    <asp:TemplateField HeaderText="热门" Visible="False">
                                        <ItemTemplate>
                                            <%#Convert.ToBoolean(Eval("BitIsHot")) ? "<font color='red'>热门</font>" : "<font color='blue'>冷</font>"%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IntOrderID" HeaderText="排序" Visible="False" />

                                    
                                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;">
                                        <ItemStyle Width="4%" />
                                    </asp:CommandField>
                                </Columns>
                                <RowStyle CssClass="GridView_Row" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <PagerStyle CssClass="GridView_Pager" />
                                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            </asp:GridView>                            
                        </td>
                    </tr>
                </table>
                <table cellpadding="4" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <b>数据批量操作：</b></td>
                        <td colspan="4">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnManySH" runat="server" Text="发布" OnClientClick="return CheckBatchUpdate('发布')"
                                            OnClick="btnManySH_Click" Width="50px" Height="26px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnNoFB" runat="server" Text="不发布" OnClientClick="return CheckBatchUpdate('设置不发布')"
                                            OnClick="btnNoFB_Click" Width="60px" Height="26px" /></td>
                                    <td>
                                        <asp:Button ID="btnShouG" runat="server" Text="首固" Width="50px" Height="26px" OnClick="btnShouG_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnCiG" runat="server" Text="次固" Width="50px" Height="26px" OnClick="btnCiG_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnBuG" runat="server" Text="不固" Width="50px" Height="26px" OnClick="btnBuG_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnSC" runat="server" Text="批量删除" OnClientClick="return CheckBatchUpdate('删除')"
                                            OnClick="btnSC_Click" Width="60px" Height="26px" /></td>
                                    <td>
                                        <asp:Button ID="btnCreate" runat="server" Text="批量生成" OnClientClick="return CheckBatchUpdate('批量生成')"
                                            OnClick="btnCreate_Click" Width="60px" Height="26px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAllCreate" runat="server" Text="全部生成" OnClientClick="return CheckBatchUpdate('全部生成')"
                                            OnClick="btnAllCreate_Click" Width="60px" Height="26px" />
                                    </td>
                                        <td>
                                        <asp:Button ID="btnSChtml" runat="server" Text="批量删除HTML" OnClientClick="return CheckBatchUpdate('删除HTML')"
                                            OnClick="btnSChtml_Click" Width="98px" Height="26px" /></td>

                                    <td width="6%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 10px;">
                        </td>
                    </tr>
                </table>
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
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
        
        
        <%--        <asp:ObjectDataSource ID="MyODS" runat="server" DeleteMethod="Delete" SelectMethod="GetArticleList" TypeName="RM.BLL.Article">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClass" DefaultValue="0" Name="ClassID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>
    </form>
</body>
</html>
