<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Codebehind="flashplay.aspx.cs"
    Inherits="Pbzx.Web.flashplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>录像播放</title>

    <script language="JavaScript" type="text/javascript"> 
function killErrors() { 
return true; 
} 
window.onerror = killErrors; 
    </script>

    <style type="text/css">
body,td,th {
	font-size: 12px;
}
a:link {
	text-decoration: none;
}
a:visited {
	text-decoration: none;
}
a:hover {
	text-decoration: none;
	color: #F00;
}
a:active {
	text-decoration: none;
}
</style>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
        <div id="lxlb" runat="server">
            <!-- 录像列表-->
            <%--<div class="content MT" id="Div1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="78%" height="26" background="Images/Web/R_lbg2.jpg" class="R_r2_title">
                                        <strong><span style="font-size: 10pt">
                                        录像列表</span></strong></td>
                                    <td width="22%" background="Images/Web/R_lbg2.jpg">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" align="center" cellpadding="12" cellspacing="0" bgcolor="#FFFFFF">
                                <tr>
                                    <td align="left" style="height: 45px">
                                        <a href="#" title="录像一">录像一</a>&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>--%>
        </div>
       <%-- <div>
            <table width='100%' border='0' align='center' cellpadding='12' cellspacing='0' bgcolor='#FFFFFF'>
                <tr>
                    <td align='left' style='height: 45px'>
                        <div id="fyeid" runat="server" visible="false">
                            <!--分页-->
                        </div>
                    </td>
                </tr>
            </table>
        </div>--%>
    </form>
</body>
</html>
