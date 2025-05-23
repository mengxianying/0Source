<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Note_Manager_Edit.aspx.cs"
    Inherits="Pinble_Sms.Note.Note_Manager_Edit" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>短信定制管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <style type="text/css">
        body, td
        {
            margin: 0 0 0 0;
            font-size: 12px;
            color: #000;
            text-align: center;
        }
        
        #mainLayM
        {
            overflow: auto;
            height: auto;
            margin: auto;
            width: 423px !important;
            width: 423px;
            border-bottom: 1px solid #A5C2E4;
            border-right: 1px solid #A5C2E4;
            border-left: 1px solid #A5C2E4;
            border-top: 1px solid #A5C2E4;
        }
    </style>
</head>
<body>
    <uc1:head ID="head" runat="server" />
    <form id="form1" runat="server">
    <div id="mainLayM" style="width: 423px;" runat="server">
        <table>
            <tr>
                <td>
                    订购类型名称：
                </td>
                <td>
                    <asp:Label ID="lblottoryType" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    申请时间：
                </td>
                <td>
                    <asp:Label ID="labbegintime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    过期时间：
                </td>
                <td style="height: 20px">
                    <asp:Label ID="labendtime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    缴费方式：
                </td>
                <td style="height: 21px">
                    <asp:RadioButtonList ID="rdbutjF" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True">手动续费</asp:ListItem>
                        <asp:ListItem Value="1">自动续费</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    接收状态：
                </td>
                <td style="height: 21px">
                    <asp:RadioButtonList ID="rdbutstatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">接收短消息</asp:ListItem>
                        <asp:ListItem Value="0">不接收短消息</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    手机号码：
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="11" Width="109px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <asp:Button ID="btnregist" runat="server" OnClick="btnregist_Click" Text="返回管理列表" />
                </td>
                <td style="height: 26px">
                    <asp:Button ID="btnOK" runat="server" Text="修改" OnClick="btnOK_Click" Width="71px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <uc2:MakFooter ID="MakFooter" runat="server" />
</body>
</html>
