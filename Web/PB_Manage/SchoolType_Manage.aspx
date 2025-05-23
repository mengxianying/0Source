<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SchoolType_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SchoolType_Manage" %>

<html>
<head id="Head1" runat="server">
    <title>软件学院类别管理信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function ParentChange(sender){            
            if(sender.value == "0"){                
                document.getElementById("txtUrl").disabled = true;
            }
            else{
                document.getElementById("txtUrl").disabled = false;
            }
        }
        
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
            <div id="divOperator" runat="server" visible="false">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                    <tr>
                        <td bgcolor="#F3F3F3">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="Right_bg1">
                                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                            <tr>
                                                <td width="91%" align="left">
                                                    当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>添加和修改软件学院类别</td>
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
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">管理软件学院类别</asp:LinkButton>
                                        |&nbsp;
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">添加软件学院类别</asp:LinkButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#A4D5EE"
                    class="MT">
                    <tr bgcolor="#F2F8FB">
                        <td class="bold" bgcolor="#F1F1F1" style="width: 25%">
                            软件学院类别名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td class="bold">
                            根类别：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlParent" runat="server" DataTextField="VarTypeName" DataValueField="IntNewsTypeID">
                            </asp:DropDownList></td>
                    </tr>
                    <tr bgcolor="#f2f8fb">
                        <td class="bold">
                            所属频道：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlChannel" runat="server" Width="151px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr bgcolor="#f2f8fb">
                        <td class="bold">
                            显示条数：</td>
                        <td align="left">
                            <asp:TextBox ID="txtDisCount" runat="server" MaxLength="3" Width="50px">8</asp:TextBox><span
                                style="color: #ff0000">*</span></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td class="bold" style="height: 24px">
                            是否启用：</td>
                        <td align="left" style="height: 24px">
                            <asp:CheckBox ID="cbMenu" runat="server" /></td>
                    </tr>
                    <tr bgcolor="#f2f8fb">
                        <td class="bold" style="height: 24px">
                            是否显示：</td>
                        <td align="left" style="height: 24px">
                            <asp:CheckBox ID="chbDisplay" runat="server" /></td>
                    </tr>
                    <tr bgcolor="#f2f8fb">
                        <td class="bold" style="height: 24px">
                            排序编号：</td>
                        <td align="left" style="height: 24px">
                            <asp:TextBox ID="txtSortID" runat="server" MaxLength="3" Width="50px">0</asp:TextBox><span
                                style="color: #ff0000">*</span>（注：数字越小越靠前）</td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td class="bold">
                            页面栏目位置：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlIntOrderID" runat="server" Width="70px">
                                <asp:ListItem Value="左一">左一</asp:ListItem>
                                <asp:ListItem Value="左二">左二</asp:ListItem>
                                <asp:ListItem Value="左三">左三</asp:ListItem>
                                <asp:ListItem Value="右一">右一</asp:ListItem>
                                <asp:ListItem Value="右二">右二</asp:ListItem>
                                <asp:ListItem Value="右三">右三</asp:ListItem>
                                <asp:ListItem Value="其它">其它</asp:ListItem>
                            </asp:DropDownList>
                            当那个类别的位置已经存在的时候，请选择其他类别，要是不想在公告首页显示类别下边的信息，请选择其他。
                        </td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%">
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button
                                ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"></asp:Button>
                            <asp:HiddenField ID="hfID" runat="server" Value="0" />
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
                                    <td class="Right_bg1">
                                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                            <tr>
                                                <td width="91%" align="left">
                                                    当前位置：软件学院类别管理</td>
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
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click">管理软件学院类别</asp:LinkButton>&nbsp;
                                        |&nbsp;
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton2_Click">添加软件学院类别</asp:LinkButton>&nbsp;|
                                        &nbsp; <a href="#" onclick="OpenEdite('PBnet_SchoolType','IntNewsTypeID','VarTypeName','IntOrderID','IntSortID','','800','600')">
                                            软件学院类别显示排序</a>&nbsp; |&nbsp;
                                        <asp:LinkButton ID="lbtnUpdateNews" runat="server" OnClick="lbtnUpdateNews_Click">更新软件学院首页</asp:LinkButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                            class="MT">
                            <tr bgcolor="#ffffff">
                                <td>
                                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                        CellPadding="0" Width="100%" DataKeyNames="IntNewsTypeID" OnRowCreated="MyGridView_RowCreated"
                                        CssClass="GridView_Table" Font-Size="Small" OnRowDataBound="MyGridView_RowDataBound">
                                        <FooterStyle CssClass="GridView_Footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="序号">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IntNewsTypeID") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("IntNewsTypeID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="类别名称">
                                                <ItemTemplate>
                                                    <div align="left" style="padding-left: 5px;">
                                                        <%# showModule(Eval("VarTypeName"), Eval("Depth"))%>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RootID" HeaderText="根ID" />
                                            <asp:BoundField DataField="IntOrderID" HeaderText="栏目位置" />
                                            <asp:TemplateField HeaderText="是否启用" SortExpression="BitIsAuditing">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnIsAuditing" runat="server" CommandArgument='<%# Eval("IntNewsTypeID") %>'
                                                        OnCommand="lbtnIsAuditing_Command"><%# Convert.ToBoolean(Eval("BitIsAuditing")) ? "已启用" : "<font color=red>未启用</font>"%></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="是否显示" SortExpression="BitComment">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnBitComment" runat="server" CommandArgument='<%# Eval("IntNewsTypeID") %>'
                                                        OnCommand="lbtnBitComment_Command"><%# Convert.ToBoolean(Eval("BitComment")) ? "已显示" : "<font color=red>未显示</font>"%></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("IntNewsTypeID") %>' runat="server"
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
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
            <asp:ObjectDataSource ID="odsMaster" runat="server" SelectMethod="GetListBySort"
                TypeName="Pbzx.BLL.PBnet_SchoolType"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
