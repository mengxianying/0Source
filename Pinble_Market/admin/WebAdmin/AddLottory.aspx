<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLottory.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.AddLottory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加编辑</title>
    <style type="text/css">
   table{
    font-size:12px;
   }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 87px; height: 21px">
        彩种名称：</td>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 87px">
                    编号：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtnumber" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 87px">
                    项目名称：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 87px; height: 23px;">
                </td>
                <td style="width: 100px; height: 23px;">
                    <asp:Button ID="btnok" runat="server" OnClick="btnok_Click" Text="提 交" Width="69px" />
                    &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:LinkButton ID="linkbutresult" runat="server" OnClick="linkbutresult_Click">返回列表页</asp:LinkButton></td>
                <td style="width: 100px; height: 23px;">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
