<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AdPlaceSum.aspx.cs" Inherits="Pbzx.Web.PB_Manage.AdPlaceSum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加广告个数</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript">
    function open()
    {
       var result =   window.showModalDialog("Charge_value.aspx","","help: No; resizable: No; status: No;scrollbars:No;scroll:yes;center:yes;dialogWidth:650px;dialogHeight:450px;");
       if(result =="1")
       {
        window.reload();
       }
    }
    </script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="AdvPlace_Manage.aspx" class="zilan">广告位列表</a> | <a href="Ad_Manage.aspx" class="zilan">广告管理</a> | <a href="Ad_Edit.aspx" class="zilan">
                                        添加广告信息</a>
                                    | <asp:LinkButton ID="lbtnUpdateIndex" runat="server" CssClass="zilan" Text="更新首页" OnClick="lbtnUpdateIndex_Click"></asp:LinkButton>
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
                                                当前位置：广告位管理&gt;&gt;广告位类别管理</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="divAdd" runat="server" visible="false">
                            <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        编号</td>
                                    <td>
                                        <asp:TextBox ID="txtNewID" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F8FB" class="bold">
                                    <td>
                                        广告位类别名：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNewName" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        所属频道</td>
                                    <td>
                                        <asp:DropDownList ID="ddlNewChannel" runat="server" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F8FB" class="bold">
                                    <td>
                                        行列数：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRowAndCol" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB" class="bold">
                                    <td>
                                        单个广告位宽度：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNewWidth" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB" class="bold">
                                    <td>
                                        单个广告位高度：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNewHeight" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        所属类别</td>
                                    <td>
                                        <asp:DropDownList ID="ddlNewType" runat="server" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        是否开启</td>
                                    <td>
                                        <asp:RadioButtonList ID="rblNewOpen" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                            <asp:ListItem Value="0">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td colspan="2" align="center" style="height: 30px">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="添加" OnClick="btn_Save_Click" />
                                        &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button"
                                            Text="取消" OnClick="btnCancel_Click" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:HiddenField ID="hfID"
                                            runat="server" Value="0" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divList" runat="server">
                            <table width="100%" cellpadding="2" cellspacing="1">
                                <tr bgcolor="#f2f8fb">
                                    <td>
                                        <asp:GridView ID="MyGridView" runat="server" Width="100%" AutoGenerateColumns="False"
                                            OnRowEditing="MyGridView_RowEditing" OnRowCancelingEdit="MyGridView_RowCancelingEdit"
                                            OnRowUpdating="MyGridView_RowUpdating" DataKeyNames="Id">
                                            <Columns>
                                                <asp:TemplateField HeaderText="编号" SortExpression="Id">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtId" Width="30" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="广告位类别名" SortExpression="Name">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtName" Width="180" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="所属频道" SortExpression="Channel">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="行列数" SortExpression="RowAndCol">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtRow" Width="30" runat="server" Text='<%# Bind("RowAndCol") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("RowAndCol") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="单个广告位宽度" SortExpression="PlaceWidth">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPlaceWidth" Width="30" runat="server" Text='<%# Bind("PlaceWidth") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <%# Eval("PlaceWidth") %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="单个广告位高度" SortExpression="PlaceHeight">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPlaceHeight" Width="30" runat="server" Text='<%# Bind("PlaceHeight") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <%# Eval("PlaceHeight") %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="所属类别" SortExpression="TypeID">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlType" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="是否开启">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rblIsOpen" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                                            <asp:ListItem Value="0">否</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:CommandField HeaderText="操作" ShowEditButton="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:CommandField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="GridView_Pager" />
                                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btmAdd" runat="server" OnClick="btmAdd_Click" Text="添加一行" />
                                        &nbsp;&nbsp; &nbsp;<asp:Button ID="btnAdPlaces" runat="server" Text="生成广告位" OnClick="btnAdPlaces_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <%--                                  <asp:Button ID="btnInit" runat="server" Text="初始化数据" OnClick="btnInit_Click" />（请慎用）--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
