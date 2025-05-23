<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebForm2.aspx.cs" Inherits="Pbzx.Web.PB_Manage.WebForm2" %>

<%@ Register Src="Controls/UcSort.ascx" TagName="UcSort" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>测试</title>
    <script type="text/javascript" language="javascript">
        function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere)
        {
            var result =  window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height=800, width=800, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;'                        
            if(result == 'yes')
            {
               location.reload();    
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<asp:Button ID="Button1" runat="server" OnClientClick="OpenEdite('PBnet_NewsType','IntNewsTypeID','VarTypeName','IntOrderID','IntSortID','')" Text="Button" /></div>
    </form>
</body>
</html>
