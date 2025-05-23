<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QQ_Manage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.QQ_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link type="text/css" rel="stylesheet" href="stylecss/css.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线客服</title>

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
    </script>
    <script language="javascript" type="text/javascript">
        function ParentChange(sender){            
//            if(sender.value == "0"){                
//                document.getElementById("txtUrl").disabled = true;
//            }
//            else{
//                document.getElementById("txtUrl").disabled = false;
//            }
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
                                                    当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>添加和修改QQ信息</td>
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
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">管理QQ信息</asp:LinkButton>
                                        |&nbsp;
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">添加QQ信息</asp:LinkButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#A4D5EE"
                    class="MT">
                    <tr bgcolor="#F2F8FB">
                        <td align="right" bgcolor="#F1F1F1" style="width: 25%">
                            部门名称：</td>
                        <td align="left">
                            &nbsp;<asp:TextBox ID="txtTeam" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%">
                            部门联系电话：</td>
                        <td align="left">
                            &nbsp;<asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%">
                            QQ号码：</td>
                        <td align="left">
                            &nbsp;<asp:TextBox ID="txtQQ" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%; height: 26px;">
                            排序编号：</td>
                        <td align="left" style="height: 26px">
                            &nbsp;<asp:DropDownList ID="ddlIntOrderID" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%">
                            显示位置：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDisplay" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%">
                            是否审核：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="chAuditing" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">审核</asp:ListItem>
                                <asp:ListItem Value="1">未审核</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%">
                            QQ人备注：</td>
                        <td align="left">
                            &nbsp;<asp:TextBox ID="txtVarName" runat="server" Rows="1"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#F2F8FB">
                        <td align="right" style="width: 25%; height: 29px;">
                        </td>
                        <td align="left" style="height: 29px">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button>&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click"></asp:Button>&nbsp;
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
                                                    当前位置：QQ信息管理</td>
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
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click">管理QQ信息</asp:LinkButton>
                                        |&nbsp;
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton2_Click">添加QQ信息</asp:LinkButton> &nbsp;|&nbsp; <a href="#" onclick="OpenEdite('PBnet_QQ','IntId','Team','VarQQNumber','IntOrderID','','800','600')">QQ显示排序</a></td>
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
                                CellPadding="0" Width="100%" DataKeyNames="IntId" OnRowCreated="MyGridView_RowCreated"
                                CssClass="GridView_Table" Font-Size="Small" OnRowDataBound="MyGridView_RowDataBound">
                                <FooterStyle CssClass="GridView_Footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="序号">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IntId") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("IntId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="部门名称">
                                        <ItemTemplate>
                                            <div align="left" style="padding-left: 5px;">
                                                <%# Eval("Team")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="VarQQNumber" HeaderText="QQ号码" />
                                    <asp:TemplateField HeaderText="频道">
                                        <ItemTemplate>
                                         <%#GetChannlType(Eval("IntDisplayPosition"))%>                                        
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="是否审核" SortExpression="BitIsAuditing">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#   Convert.ToBoolean(Eval("BitIsAuditing").ToString()) ? "<font color=green>已审核</font>" : "<font color=red>未审核</font>" %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="部门电话">
                                        <ItemTemplate>
                                            <%# Eval("Tel")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QQ备注">
                                        <ItemTemplate>
                                            <div align="left" style="padding-left: 5px;">
                                                <%# Eval("VarName")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="编辑">
                                        <ItemTemplate>
                                            <a href="qq_manage.aspx?id=<%# Eval("IntId") %>">编辑</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="删除">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                                OnCommand="LinkButton2_Command">删除</asp:LinkButton>
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
            </div>        
        </div>
    </form>
</body>
</html>
