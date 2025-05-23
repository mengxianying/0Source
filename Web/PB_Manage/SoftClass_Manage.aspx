<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftClass_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SoftClass_Manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>商品资源类别管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">


function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere,myWidth,myHeight) 
{
var aa =''; 
var result = window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height='+myHeight+', width='+myWidth+', top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
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
                                                当前位置：类别管理</td>
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
                                    <div id="chanID" runat="server" visible="false">
                                        <a href="SoftClass_Manage.aspx?classType=chan">商品类别管理</a> |&nbsp; <a href="SoftClass_Editor.aspx?strTyp=0">
                                            添加商品类别</a> &nbsp;|&nbsp; <a href="#" onclick="OpenEdite('PBnet_SoftClass','IntClassID','NvarClassName','IntDepth','IntOrderID',' and IntSetting=0 ','800','600')">
                                                商品类别显示排序</a></div>
                                    <div id="yuanID" runat="server" visible="false">
                                        <a href="SoftClass_Manage.aspx?classType=yuan">资源下载类别管理</a> |&nbsp; <a href="SoftClass_Editor.aspx?strTyp=1">
                                            添加资源下载类别</a>&nbsp; |&nbsp; <a href="#" onclick="OpenEdite('PBnet_SoftClass','IntClassID','NvarClassName','IntDepth','IntOrderID','and IntSetting=1 ','800','600')">
                                                资源类别显示排序</a></div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%--<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <table width="370" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="70">
                                    &nbsp;<b>筛选条件:</b></td>
                                <td width="300">
                                    <asp:RadioButtonList ID="rblIntSetting" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblIntSetting_SelectedIndexChanged"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="-1">全部</asp:ListItem>
                                        <asp:ListItem Value="0">软件产品</asp:ListItem>
                                        <asp:ListItem Value="1">下载软件</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="IntClassID,NvarClassName"
                                    OnRowDeleting="MyGridView_RowDeleting" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="序号" SortExpression="IntClassID">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("IntClassID") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("IntClassID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="类别名称">
                                            <ItemTemplate>
                                                <%#Eval("NvarClassName")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否启用" SortExpression="IntClassID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnIsAuditing" runat="server" CommandArgument='<%# Eval("IntClassID") %>'
                                                    OnCommand="lbtnIsAuditing_Command"><%# Convert.ToBoolean(Eval("BitIsElite")) ? "已启用" : "<font color=red>未启用</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否显示" SortExpression="IntClassID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnBitComment" runat="server" CommandArgument='<%# Eval("IntClassID") %>'
                                                    OnCommand="lbtnBitComment_Command"><%# Convert.ToBoolean(Eval("pb_ShowOnTop")) ? "已显示" : "<font color=red>未显示</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="浏览权限" SortExpression="IntBrowsePurview">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# GetBrowsePurview(Eval("IntBrowsePurview")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="添加权限" SortExpression="IntAddPurview">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# GetBrowsePurview(Eval("IntAddPurview")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemTemplate>
                                                <a href='SoftClass_Editor.aspx?id=<%#Eval("IntClassID") %>&strTyp=<%#Eval("IntSetting") %>'>
                                                    编辑</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('删除栏目将同时删除栏目中的所有软件，并且不能恢复！确定要删除此栏目吗？')&quot;&gt;删除&lt;/div&gt; "
                                            HeaderText="删除" ShowDeleteButton="True" />
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
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                    PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                    Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                                    HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
