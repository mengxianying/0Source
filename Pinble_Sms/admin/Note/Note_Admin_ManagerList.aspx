<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Note_Admin_ManagerList.aspx.cs"
    Inherits="Pinble_Market.admin.Note.Note_Admin_ManagerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <title>短信定制管理</title>
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
        <div id="mainLayM">
            <table>
                <tr>
                    <td style="height: 26px">
                        用户名：
                    </td>
                    <td style="height: 26px">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 48px; height: 26px">
                        <asp:Button ID="btnok" runat="server" Text="查询" Width="79px" OnClick="btnok_Click1" />
                    </td>
                </tr>
            </table>
            
            <div id="mainLay" runat="server">
            </div>
        </div>
    </form>
</body>
</html>
