<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LyTypeManage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.LyTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>资讯类别管理信息</title>
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
        <div id="divOperator" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btn_gl_Click" Font-Bold="True"
                                        ForeColor="White">管理留言类别</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btn_add_Click" Font-Bold="True"
                                        ForeColor="White">添加留言类别</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>留言类别</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#A4D5EE">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" width="25%">
                                    留言类别名称：</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 24px">
                                    是否启用：</td>
                                <td align="left" style="height: 24px">
                                    <asp:CheckBox ID="cbMenu" runat="server" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 24px">
                                    排序编号：</td>
                                <td align="left" style="height: 24px">
                                    <asp:TextBox ID="txtSortID" runat="server" MaxLength="3" Width="50px">0</asp:TextBox><span
                                        style="color: #ff0000">*</span>（注：数字越小越靠前）</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />
                                    <asp:HiddenField ID="hfID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divList" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1" style="height: 26px">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：留言类别管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER">
                                    <asp:LinkButton ID="btn_gl" runat="server" OnClick="btn_gl_Click">管理留言类别</asp:LinkButton>&nbsp;
                                    |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加留言类别</asp:LinkButton>
                                    &nbsp;|&nbsp; <a href="#" onclick="OpenEdite('PBnet_LyType','ID','TypeName','IsAuditing','OrderID','','800','600')">
                                        留言类别显示排序</a>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" DataKeyNames="ID"
                            CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类别名称">
                                    <ItemTemplate>
                                        <div align="left" style="padding-left: 5px;">
                                            <%#Eval("TypeName")%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否启用" SortExpression="IsAuditing">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnIsAuditing" runat="server" CommandArgument='<%# Eval("ID") %>'
                                            OnCommand="lbtnIsAuditing_Command"><%# Convert.ToBoolean(Eval("IsAuditing")) ? "已启用" : "<font color=red>未启用</font>"%></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编辑">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                                            OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
            <asp:ObjectDataSource ID="odsMaster" runat="server" SelectMethod="GetListBySort"
                TypeName="Pbzx.BLL.PBnet_LyType"></asp:ObjectDataSource>
            <%-- </ContentTemplate> </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
