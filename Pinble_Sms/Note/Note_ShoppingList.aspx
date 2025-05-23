<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Note_ShoppingList.aspx.cs"
    Inherits="Pinble_Sms.Note.Note_ShoppingList" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <title>短信定制</title>
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
    <uc1:head ID="Head1" runat="server" />
    <form id="form1" runat="server">
        <div id="mainLayM" runat="server">
        </div>
    </form>
    <uc2:MakFooter ID="MakFooter1" runat="server" />
</body>
</html>
