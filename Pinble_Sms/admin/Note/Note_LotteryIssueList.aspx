<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Note_LotteryIssueList.aspx.cs"
    Inherits="Pinble_Market.admin.Note.Note_LotteryIssueList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <title>发布消息详细列表</title>
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
	width:876px!important;width:878px;
	border-bottom:1px solid #A5C2E4;
	border-right:1px solid #A5C2E4;
	border-left:1px solid #A5C2E4;
	border-top:1px solid #A5C2E4;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainLayM" style="width: 775px">
            <table border="0" style="height: 66px">
                <tr>
                    <td style="height: 26px">
                        期号：</td>
                    <td style="width: 88px; height: 26px; text-align: left">
                        <asp:TextBox ID="txtQNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 26px">
                        内容：</td>
                    <td style="width: 88px; height: 26px">
                        <asp:TextBox ID="txtContent" runat="server" Height="130px" TextMode="MultiLine" 
                            Width="400px" MaxLength="70"></asp:TextBox>
                   <nobr> （短信内容70字）</nobr></td>
                </tr>
                <tr>
                    <td style="height: 26px">
                    </td>
                    <td style="width: 88px; height: 26px">
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="返回列表" />
                        <asp:Button ID="btnok" runat="server" OnClick="btnok_Click" Text="发布" Width="89px" /></td>
                </tr>
            </table>
            <div id="mainLay" runat="server">
            </div>
        </div>
    </form>
</body>
</html>
