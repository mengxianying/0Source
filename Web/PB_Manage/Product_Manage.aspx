<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Product_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Product_Manage" EnableEventValidation="false" %>

<%@ Register Src="Controls/UcProductSearch.ascx" TagName="UcProductSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head id="Head1" runat="server">
    <title>软件商城管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
      
       function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere)
        {
            var   aa   ='';   
            var result =  window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height=800, width=800, top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;'                        
            if(aa == 'yes')
            {
               location.reload();    
            }
        }        
        function tan(myType)
        {
            if(myType != "")
            {
                OpenEdite('PBnet_Product','pb_SoftID','pb_SoftName','pb_SoftVersion','icountid','and pb_TypeName=\''+myType+'\'');
            }            
        }
    </script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                                当前位置：商品管理首页</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="center">
                                    <a href="Product_Manage.aspx">商品管理首页</a> | <a href="Product_Editor.aspx">添加商品信息</a>&nbsp;
                                    | <a href="#" onclick="OpenEdite('PBnet_Product','pb_SoftID','pb_SoftName','pb_SoftVersion','icountid','')">前台显示排序</a> | <a href="#" onclick="OpenEdite('PBnet_Product','pb_SoftID','pb_SoftName','pb_SoftVersion','countid','')">后台显示排序</a>
                                    | <a href="ProductDeleted.aspx">商品回收站</a>&nbsp;|&nbsp;<asp:LinkButton ID="lbtnCreate"
                                        runat="server" Text="更新首页商品" OnClick="lbtnCreate_Click"></asp:LinkButton>
                                    &nbsp;| &nbsp;<select onchange="tan(this.options[this.options.selectedIndex].value)">
                                        <option selected="selected" value="">请选择排序商品版本类别</option>
                                        <option value="专业版">专业版</option>
                                        <option value="胆杀版">胆杀版</option>
                                        <option value="标准版">标准版 </option>
                                        <option value="免费版">免费版 </option>
                                    </select>
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
                        <uc1:UcProductSearch ID="UcProductSearch1" runat="server" Url="Product_Manage.aspx">
                        </uc1:UcProductSearch>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="pb_SoftID" OnRowDeleting="MyGridView_RowDeleting"
                                    CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
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
                                        <asp:BoundField DataField="pb_SoftID" HeaderText="序" ItemStyle-Width="3%" />
                                        <asp:TemplateField HeaderText="商品名称及版本" SortExpression="pb_SoftName">
                                            <ItemTemplate>
                                                <a href='product_manage.aspx?softClass=<%#Eval("pb_ClassID") %>'>[<%# Pbzx.Web.WebFunc.GetSoftClassNameById(Eval("pb_ClassID"))%>]</a><a
                                                    href='Product_Editor.aspx?id=<%#Eval("pb_SoftID") %>' title='软件名称：<%#Eval("pb_SoftName") %>&#13;软件版本：<%#Eval("pb_SoftVersion") %>&#13;软件作者：<%#Eval("pb_Author") %>&#13;更新时间：<%#Eval("pb_UpdateTime") %>&#13;下载次数：<%#Eval("pb_Hits") %>&#13;关 键 字：<%#Eval("pb_Keyword") %>&#13;推荐等级:<%#Eval("pb_Stars") %>星&#13;下载等级：<%# Method.GetDownLoadLeval(Eval("pb_SoftLevel")) %>&#13;阅读点数：<%#Eval("pb_SoftPoint") %>'>
                                                    <%# Eval("pb_SoftName")%>
                                                    &nbsp;
                                                    <%# Eval("pb_SoftVersion")%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="34%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="软件大小" SortExpression="pb_SoftSize">
                                            <ItemTemplate>
                                                <%# Eval("pb_SoftSize")+"KB" %>
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="推荐" SortExpression="pb_ClassID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnfreeshow" runat="server" CommandArgument='<%# Eval("pb_SoftID") %>'
                                                    OnCommand="lbtnfreeshow_Command"><%# Convert.ToBoolean(Eval("pb_Elite")) ? "<font color=blue>是</font>" : "否"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="日/周/月/总" SortExpression="pb_Hits">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("pb_DayHits")+"/"+ Eval("pb_WeekHits")+"/"+ Eval("pb_MonthHits")+"/"+Eval("pb_Hits") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnAduting" runat="server" CommandArgument='<%# Eval("pb_SoftID") %>'
                                                    OnCommand="lbtnAduting_Command"><%# Convert.ToBoolean(Eval("pb_Passed")) ? "<font color=blue>已发布</font>" : "<font color=red>未发布</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="固顶">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnPb_OnTop" CommandArgument='<%# Eval("pb_SoftID") %>' runat="server"
                                                    OnCommand="lbtnPb_OnTop_Command"><%# Convert.ToBoolean(Eval("pb_OnTop")) ? "<font color='blue'>已固顶</font>" : "<font color='black'>未固顶</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="内嵌">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnSoftshow" CommandArgument='<%# Eval("pb_SoftID") %>' runat="server"
                                                    OnCommand="lbtnSoftshow_Command"><%# Convert.ToBoolean(Eval("PBnet_Softshow")) ? "<font color='blue'>是</font>" : "<font color='black'>否</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="首页">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnPb_Elite" CommandArgument='<%# Eval("pb_SoftID") %>' runat="server"
                                                    OnCommand="lbtnPb_Elite_Command"><%# Convert.ToBoolean(Eval("pb_indexshow")) ? "<font color='blue'>显示</font>" : "<font color='black'>不显</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <a href="Product_Editor.aspx?id=<%#Eval("pb_SoftID") %>">编辑</a>&nbsp;
                                                <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("pb_SoftID") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                                    runat="server" OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" />
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                </asp:GridView>
                                <table cellpadding="4" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <b>数据批量操作：</b></td>
                                        <td>
                                            <asp:Button ID="btnManySH" runat="server" Text="发布" OnClientClick="return CheckBatchUpdate('批量发布')"
                                                OnClick="btnManySH_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnGD" runat="server" Text="不发布" OnClientClick="return CheckBatchUpdate('批量不发布')"
                                                OnClick="btnGD_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnTJ" runat="server" Text="首页显示" OnClientClick="return CheckBatchUpdate('批量首页显示')"
                                                OnClick="btnTJ_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNotIndex" runat="server" Text="首页不显示" OnClientClick="return CheckBatchUpdate('批量首页不显示')"
                                                OnClick="btnNotIndex_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnOnTop" runat="server" Text="固定" OnClientClick="return CheckBatchUpdate('批量固顶')"
                                                OnClick="btnOnTop_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNotOnTop" runat="server" Text="不固定" OnClientClick="return CheckBatchUpdate('批量不固顶')"
                                                OnClick="btnNotOnTop_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnFree" runat="server" Text="免费" OnClientClick="return CheckBatchUpdate('批量免费')"
                                                OnClick="btnFree_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNotbtnFree" runat="server" Text="不免费" OnClientClick="return CheckBatchUpdate('批量不免费')"
                                                OnClick="btnNotbtnFree_Click" />
                                        </td>
                                        <td>
                                        </td>
                                        <td style="width: 80px;">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 32px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
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
