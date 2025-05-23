<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Note_LotteryTypeEdit.aspx.cs"
    Inherits="Pinble_Market.admin.Note.Note_LotteryTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <style type="text/css">
    body,td{
	margin:0 0 0 0;
	font-size:12px;
	color:#000;
	text-align:center;
}

#mainLayM {
	overflow:auto;
	height:auto;
	margin:auto;
	width:673px!important;width:673px;
	border-bottom:1px solid #A5C2E4;
	border-right:1px solid #A5C2E4;
	border-left:1px solid #A5C2E4;
	border-top:1px solid #A5C2E4;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainLayM" style="width: 673px; height: 368px">
            <table border="0" style="width: 638px">
                <tr>
                    <td style="width: 167px; height: 50px; text-align: right">
                        服务名称：</td>
                    <td style="width: 114px; height: 50px; text-align: left">
                        <asp:TextBox ID="txtCName" runat="server" Width="293px"></asp:TextBox></td>
                    <td style="width: 157px; height: 50px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 167px; height: 44px; text-align: right">
                        价格：</td>
                    <td style="width: 114px; height: 44px; text-align: left">
                        <asp:TextBox ID="txtPriceContent" runat="server" Width="295px"></asp:TextBox></td>
                    <td style="width: 157px; height: 44px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 167px; height: 31px; text-align: right">
                        服务说明：</td>
                    <td style="width: 114px; height: 31px; text-align: left">
                        <asp:TextBox ID="txtExt" runat="server" Height="62px" TextMode="MultiLine" Width="297px"></asp:TextBox></td>
                    <td style="width: 157px; height: 31px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 167px; height: 31px; text-align: right">
                        信息发布星期：</td>
                    <td colspan="2" style="height: 31px; text-align: left">
                        <asp:CheckBoxList ID="checkisswrk" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">星期一</asp:ListItem>
                            <asp:ListItem Value="2">星期二</asp:ListItem>
                            <asp:ListItem Value="3">星期三</asp:ListItem>
                            <asp:ListItem Value="4">星期四</asp:ListItem>
                            <asp:ListItem Value="5">星期五</asp:ListItem>
                            <asp:ListItem Value="6">星期六</asp:ListItem>
                            <asp:ListItem Value="0">星期天</asp:ListItem>
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td style="width: 167px; height: 31px; text-align: right">
                        信息发布时间：</td>
                    <td colspan="2" style="height: 31px; text-align: left">
                        <asp:TextBox ID="txtisstime" runat="server" Width="77px"></asp:TextBox>（如：十点三十分&nbsp;
                        10:30 ）</td>
                </tr>
                <tr>
                    <td style="width: 167px; height: 31px; text-align: right">
                        是否公开：</td>
                    <td style="width: 114px; height: 31px; text-align: left">
                        <asp:RadioButtonList ID="radIspublic" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 157px; height: 31px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 167px; height: 31px; text-align: right">
                        <asp:Button ID="btnreselt" runat="server" OnClick="Button1_Click" Text="返回列表页" /></td>
                    <td style="width: 114px; height: 31px; text-align: left">
                        &nbsp;&nbsp;
                        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="添加" Width="91px" />&nbsp;
                    </td>
                    <td style="width: 157px; height: 31px">
                    </td>
                </tr>
            </table>
        
        </div>
    </form>
</body>
</html>
