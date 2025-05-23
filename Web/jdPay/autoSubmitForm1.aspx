<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autoSubmitForm1.aspx.cs" Inherits="jdPay.autoSubmitForm1" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="hidden/html; charset=utf-8"/>
    <title>"京东支付</title>
</head>
<body  onload="autosubmit()">
    <form id="batchForm" method="post" runat="server">
        <!--  -->
        <input type="hidden" name="version" id="version" runat="server" value=""/><br/>
		<input type="hidden" name="merchant" id="merchant" runat="server" value=""/><br/>
		<input type="hidden" name="device" id="device" runat="server" value=""/><br/>
		<input type="hidden" name="tradeNum" id="tradeNum" runat="server" value=""/><br/>
		<input type="hidden" name="tradeName" id="tradeName" runat="server" value=""/><br/>
		<input type="hidden" name="tradeDesc" id="tradeDesc" runat="server" value=""/><br/>
		<input type="hidden" name="tradeTime" id="tradeTime" runat="server" value=""/><br/>
		<input type="hidden" name="amount" id="amount" runat="server" value=""/><br/>
		<input type="hidden" name="currency" id="currency" runat="server" value=""/><br/>
		<input type="hidden" name="note" id="note" runat="server" value=""/><br/>
		<input type="hidden" name="callbackUrl" id="callbackUrl" runat="server" value=""/><br/>
		<input type="hidden" name="notifyUrl" id="notifyUrl" runat="server" value=""/><br/>
		<input type="hidden" name="ip" id="ip" runat="server" value=""/><br/>
		<input type="hidden" name="userType" id="userType" runat="server" value=""/><br/>
		<input type="hidden" name="userId" id="userId" runat="server" value=""/><br/>
		<input type="hidden" name="expireTime" id="expireTime" runat="server" value=""/><br/>
		<input type="hidden" name="orderType" id="orderType" runat="server" value=""/><br/>
		<input type="hidden" name="industryCategoryCode" id="industryCategoryCode" runat="server" value=""><br/>
		<input type="hidden" name="specCardNo" id="specCardNo" runat="server" value=""/><br/>
		<input type="hidden" name="specId" id="specId" runat="server" value=""/><br/>
		<input type="hidden" name="specName" id="specName" runat="server" value=""/><br/>
		<input type="hidden" name="sign" id="sign" runat="server" value=""/><br/>
    </form>
    <script>
	    function autosubmit(){
		    document.getElementById("batchForm").submit();
	    }	
	</script>
</body>
</html>
