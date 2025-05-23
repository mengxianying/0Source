<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Admin_WebConfig.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Admin_WebConfig" %>

<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<link type="text/css" rel="stylesheet" href="stylecss/css.css" />--%>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        }  
    </script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
