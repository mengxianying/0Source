<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSort.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcSort" %>

&nbsp; &nbsp;
<asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="去除重复" />

<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2" >
    <tr bgcolor="#F7FBFF">
        <td>
            <asp:GridView ID="MyGridView" Width="100%" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="MyGridView_RowDataBound" CssClass="GridView_Table">
                <Columns>
                    <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称">
                        <ItemTemplate>
                            <%#Eval(ViewState["ColName"].ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="列名二">
                        <ItemTemplate>
                            <%#Eval(ViewState["ColName2"].ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="排序编号">
                        <ItemTemplate>
                            <%#Eval(ViewState["SortID"].ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上移">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlUP" runat="server" Width="80px" OnSelectedIndexChanged="ddlUP_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下移">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlDown" runat="server" Width="80px" OnSelectedIndexChanged="ddlDown_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="GridView_Pager" />
                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                <RowStyle CssClass="GridView_Row" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
