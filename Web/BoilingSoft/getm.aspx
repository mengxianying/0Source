<%@ Page Language="C#" AutoEventWireup="true" Codebehind="getm.aspx.cs" Inherits="getm" %> 
<%
    if (Request.Params["returnobjid"]!=null)
    {
%>
<script>
parent.document.getElementById("<%=Request.Params["returnobjid"]%>").value = "<%=MOBILE%>";
<%
if(MOBILE.Length>9)
{
%>
//parent.document.getElementById("<%=Request.Params["returnobjid"]%>").readOnly = true;
//parent.document.getElementById("<%=Request.Params["returnobjid"]%>").style.backgroundColor="#cccccc";
<%
}
%>
</script>
<%    
    }
%>