<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInterval.aspx.cs" Inherits="Pinble_DataRivalry.Rivalry.AddInterval" %>

<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加大底对应范围</title>
    <link type="text/css" rel="stylesheet" href="../css/footer.css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <table>
        <tr>
            <td>
                选择注数：
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                <asp:ListItem Value="100">100</asp:ListItem>
                <asp:ListItem Value="300">300</asp:ListItem>
                <asp:ListItem Value="600">600</asp:ListItem>
                <asp:ListItem Value="800">800</asp:ListItem>
                <asp:ListItem Value="1000">1000</asp:ListItem>
                <asp:ListItem Value="3000">3000</asp:ListItem>
                <asp:ListItem Value="100000">3000以上</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                对应范围：
            </td>
            <td>
                <asp:TextBox ID="txt_BenginRang" runat="server"></asp:TextBox>---<asp:TextBox ID="txt_EndRang"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_Add" runat="server" Text="添加" OnClick="btn_Add_Click" />    
                <asp:Button ID="btn_cnacel" runat="server" Text="取消" OnClick="btn_cnacel_Click" />        
            </td>
        </tr>
    </table>
    </div>
        <uc1:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
