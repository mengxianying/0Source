<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminConfig.aspx.cs" Inherits="Pinble_Chipped.admin.AdminConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    双色球配置：
                </td>
            </tr>
            <tr>
                <td>
                    期号：
                    <asp:TextBox ID="fcssqissue" runat="server"></asp:TextBox>
                </td>
                <td>
                    截止时间：
                    <asp:TextBox ID="fcssqendtime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    福彩3D配置
                </td>
            </tr>
            <tr>
                <td>
                    期号：
                    <asp:TextBox ID="FC3DData_Issue" runat="server"></asp:TextBox>
                </td>
                <td>
                    截止时间：
                    <asp:TextBox ID="FC3DData_EndTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    排列3五配置
                </td>
            </tr>
            <tr>
                <td>
                    期号：
                    <asp:TextBox ID="plswissue" runat="server"></asp:TextBox>
                </td>
                <td>
                    截止时间：
                    <asp:TextBox ID="plswendtime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    七星彩配置
                </td>
            </tr>
            <tr>
                <td>
                    期号：
                    <asp:TextBox ID="qxcissue" runat="server"></asp:TextBox>
                </td>
                <td>
                    截止时间：
                    <asp:TextBox ID="qxcendtime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    七乐彩配置
                </td>
            </tr>
            <tr>
                <td>
                    期号：
                    <asp:TextBox ID="qlcissue" runat="server"></asp:TextBox>
                </td>
                <td>
                    截止时间：
                    <asp:TextBox ID="qlcendtime" runat="server"></asp:TextBox>
                </td>
            </tr>

                <tr>
                <td colspan="2">
                    大乐透配置
                </td>
            </tr>
            <tr>
                <td>
                    期号：
                    <asp:TextBox ID="dltissue" runat="server"></asp:TextBox>
                </td>
                <td>
                    截止时间：
                    <asp:TextBox ID="dltendtime" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
