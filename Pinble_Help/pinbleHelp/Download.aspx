<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="Pinble_Help.pinbleHelp.Download" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" Width="70%"
            EnableModelValidation="True" OnRowCreated="myGridView_RowCreated" OnRowEditing="myGridView_RowEditing"
            OnRowCancelingEdit="myGridView_RowCancelingEdit" OnRowUpdating="myGridView_RowUpdating"
            OnRowDataBound="myGridView_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <%# Eval("CstName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="下载地址">
                    <ItemTemplate>
                        <asp:Label ID="lab_dowload" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_down" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>
                <asp:CommandField HeaderText="更新地址" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
