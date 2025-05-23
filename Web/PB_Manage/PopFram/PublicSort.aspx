<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicSort.aspx.cs" Inherits="Pbzx.Web.PB_Manage.PopFram.PublicSort" %>

<%@ Register Src="../Controls/UcSort.ascx" TagName="UcSort" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>页面排序</title>
       <link href="../StyleCss/css.css"rel="stylesheet" type="text/css" />  
</head>
<body onunload="window.returnValue ='yes';"  >
    <form id="form1" runat="server">
    <div>
    <table style="width:100%">
        <tr>
            <td>
                 <uc1:UcSort ID="UcSort1" runat="server" />    
            </td>
        </tr>
        <tr>
            <td align="center">
                <input type="button" style="width:80px; height:30px;" value="关闭" onclick="window.opener.aa='yes';window.close();" />
            </td>            
        </tr>
    </table>
       
    </div>
    </form>
</body>
</html>
