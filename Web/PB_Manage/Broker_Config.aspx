<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Broker_Config.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Broker_Config" %>
<html>
<head runat="server">
    <title>经纪人折扣设置</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div id="divOperator" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btn_gl_Click" Font-Bold="True" ForeColor="White">管理折扣设置</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btn_add_Click" Font-Bold="True" ForeColor="White">添加折扣设置</asp:LinkButton>
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
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>折扣设置</td>
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
                                    折扣等级:</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtgrade" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                               <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    等级昵称:</td>
                                <td>
                                    <asp:TextBox ID="txtgradeName" runat="server"></asp:TextBox>
                                </td>
                            </tr>    <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    折扣:</td>
                                <td>
                                    <asp:TextBox ID="txtrate" runat="server" Width="50" MaxLength="2"></asp:TextBox>百分比的分子，比如75表示百分之75
                                </td>
                            </tr>    <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    最低交易金额:</td>
                                <td>
                                    <asp:TextBox ID="txttradeMoney" runat="server"></asp:TextBox>达到该折扣的最低交易金额
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <%--<asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />--%>
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
                                                当前位置：折扣设置管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="center">
                                    &nbsp;<asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加折扣设置</asp:LinkButton></td>
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
                            CellPadding="0" Width="100%" DataSourceID="odsMaster" DataKeyNames="ID"
                            OnRowCreated="MyGridView_RowCreated" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="折扣等级">
                                    <ItemTemplate>
                                        <div align="left" style="padding-left: 5px;">
                                            <%# Eval("Discount_grade")%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="等级昵称">
                                    <ItemTemplate>                                      
                                            <%# Eval("Discount_gradeName")%>                                  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                         <asp:TemplateField HeaderText="折扣">
                                    <ItemTemplate>                                      
                                            <%# Eval("Discount_rate")%>%                                 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                         <asp:TemplateField HeaderText="最低交易金额">
                                    <ItemTemplate>                                      
                                            <%# Eval("Min_tradeMoney", "{0:f2}")%>                                  
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                              <asp:TemplateField HeaderText="编辑">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("id") %>' >编辑</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LinkButton2_Command">删除</asp:LinkButton>
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
            <asp:ObjectDataSource ID="odsMaster" runat="server" SelectMethod="GetAllList"
                TypeName="Pbzx.BLL.PBnet_broker_Config"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
