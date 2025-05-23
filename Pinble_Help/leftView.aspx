<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftView.aspx.cs" Inherits="Pinble_Help.leftView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>帮助列表</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <style type="text/css">
body {
	margin:0;
	padding:0;
	font-size:12px;
}
.wrap{ width:100%;background:#deeff6;}
.left { float:left; width:100%;}
</style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <div class="left">
                <asp:TreeView ID="TreeView1" runat="server" EnableClientScript="False" ShowLines="True" >
                </asp:TreeView>
                
            </div>
        </div>
    </form>
</body>
</html>