<%@ Page Language="C#" AutoEventWireup="true" Codebehind="About_Content.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.About_Content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公司信息管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

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
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />公司信息管理</td>
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
                                    <a href="About_Content.aspx">公司信息管理</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="OpenEdite('PBnet_About','ID','UsTitle','UsAddTime','UsOrder','','800','600')">
                                        公司内容排序</a> |&nbsp; <a href="About_Content_Edit.aspx">添加公司信息</a>
                                </td>
                            </tr>
                        </table>
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
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                                    PageSize="20" OnRowDataBound="MyGridView_RowDataBound" AllowSorting="True">
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                    <FooterStyle CssClass="GridView_Footer" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField HeaderText="序号" DataField="ID">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="标题">
                                            <ItemTemplate>
                                                <%#Eval("UsTitle")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnIsAuditing" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="lbtnIsAuditing_Command"><%# Convert.ToBoolean(Eval("UsState")) ? "已审核" : "<font color=red>未审核</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="底部显示">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnBtommShow" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="lbtnBtommShow_Command"><%# Convert.ToBoolean(Eval("UsIsBtommShow")) ? "显示" : "<font color=red>不显示</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="排序">
                                            <ItemTemplate>
                                                <%#Eval("UsOrder")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="About_Content_Edit.aspx?ID={0}"
                                            HeaderText="编辑" Text="编辑"></asp:HyperLinkField>
                                        <asp:TemplateField HeaderText="删除">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                                    runat="server" OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="GridView_Row" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                </asp:GridView>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
