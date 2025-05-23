<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProductDeleted.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.ProductDeleted" %>

<%@ Register Src="Controls/UcProductSearch.ascx" TagName="UcProductSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head id="Head1" runat="server">
    <title>商品回收站管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
      
       function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere)
        {
            var   aa   ='';   
            var result =  window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height=800, width=800, top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;'                        
            if(aa == 'yes')
            {
               location.reload();    
            }
        }

    </script>

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
                                                当前位置：商品回收站管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="Product_Manage.aspx">商品管理首页</a>&nbsp; | <a href="#" onclick="OpenEdite('PBnet_Product','pb_SoftID','pb_SoftName','pb_SoftVersion','countid','')">
                                        商品显示排序</a> | <a href="ProductDeleted.aspx">商品回收站管理首页</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="pb_SoftID" OnRowDeleting="MyGridView_RowDeleting"
                            CssClass="GridView_Table" PageSize="20" OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="全选">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="sel" value="<%#Eval("pb_SoftID") %>" /></ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序" SortExpression="pb_SoftID">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("pb_SoftID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemStyle Width="4%" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("pb_SoftID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="商品名称及版本" SortExpression="pb_SoftName">
                                    <ItemTemplate>
                                        <a href='product_manage.aspx?softName=<%#Eval("pb_SoftName") %>' title='软件名称：<%#Eval("pb_SoftName") %>&#13;软件版本：<%#Eval("pb_SoftVersion") %>&#13;软件作者：<%#Eval("pb_Author") %>&#13;更新时间：<%#Eval("pb_UpdateTime") %>&#13;下载次数：<%#Eval("pb_Hits") %>&#13;关 键 字：<%#Eval("pb_Keyword") %>&#13;推荐等级:<%#Eval("pb_Stars") %>星&#13;下载等级：<%# Method.GetDownLoadLeval(Eval("pb_SoftLevel")) %>&#13;阅读点数：<%#Eval("pb_SoftPoint") %>'>
                                            <%# Eval("pb_SoftName")%>
                                            &nbsp;</a> <a href='product_manage.aspx?pb_SoftVersion=<%#Eval("pb_SoftVersion") %>'>
                                                <%# Eval("pb_SoftVersion")%>
                                            </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属类别" SortExpression="pb_ClassID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Text='<%# Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(Eval("pb_ClassID").ToString()))   %>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件大小" SortExpression="pb_SoftSize">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("pb_SoftSize")+"KB" %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日/周/月/总" SortExpression="pb_Hits">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("pb_DayHits")+"/"+ Eval("pb_WeekHits")+"/"+ Eval("pb_MonthHits")+"/"+Eval("pb_Hits") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="11%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="属性" SortExpression="IntAddPurview">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# GetFlag(Eval("pb_DayHits").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否发布">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnAduting" runat="server" CommandArgument='<%# Eval("pb_SoftID") %>'
                                            OnCommand="lbtnAduting_Command"><%# Convert.ToBoolean(Eval("pb_Passed")) ? "<font color=green>已发布</font>" : "<font color=red>未发布</font>" %></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("pb_SoftID") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                            runat="server" OnCommand="lbtnDel_Command">彻底删除</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="lbtnPb_Elite" CommandArgument='<%# Eval("pb_SoftID") %>' runat="server"
                                            OnCommand="lbtnPb_Elite_Command">还原</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="18%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        </asp:GridView>
                        <table cellpadding="6" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <b>数据批量操作：</b></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnManySH" runat="server" Text="还原选中商品" OnClientClick="return CheckBatchUpdate('还原')"
                                        OnClick="btnManySH_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnGD" runat="server" Text="还原所有商品" OnClientClick="return CheckBatchUpdate('还原所有')"
                                        OnClick="btnGD_Click" />
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnTJ" runat="server" Text="彻底删除选中商品" OnClientClick="return CheckBatchUpdate('彻底删除')"
                                        OnClick="btnTJ_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnNotIndex" runat="server" Text="清空回收站" OnClientClick="return CheckBatchUpdate('清空')"
                                        OnClick="btnNotIndex_Click" />&nbsp;
                                </td>
                                <td>
                                </td>
                                <td style="width: 15px;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 32px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" NumericButtonCount="3" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="30%"
                            CustomInfoTextAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
