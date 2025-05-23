<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FrmSoftClassInfo.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.PopFram.FrmSoftClassInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>安装类型选择</title>
    <script language="javascript" src="../../javascript/public.js" type="text/javascript"></script>
    <script language="javascript" src="../../javascript/Prototype.js" type="text/javascript"></script>
    <script language="javascript" src="" type="text/javascript"></script>
    
    <link href="../StyleCss/css.css"rel="stylesheet" type="text/css" />  
</head>
<body>
 <form id="ListLabel" runat="server">  
    <div>
        <table width="100%">
            <tr>
                <td>
                 请选择安装类型：
                </td>
            </tr>
            <tr>
                <td>
                 <asp:CheckBoxList ID='cblClass' runat='server' RepeatColumns='3' RepeatDirection='Horizontal' >
                 </asp:CheckBoxList> 
                </td>
            </tr>
            <tr>
                <td>
                    <input class="form" type="button" value=" 确 定 " onclick="javascript:ReturnDivValue();" />&nbsp;<input
                        class="form" type="button" value=" 关 闭 " onclick="javascript:CloseDiv();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
function ReturnDivValue()
{
    var rvalue="";
    var chkObject = document.getElementById('<%=cblClass.ClientID%>'); 
    var chkInput =chkObject.getElementsByTagName("input"); 
    
    for(var i=0;i <chkInput.length;i++) 
    { 
        if(chkInput[i].checked) 
        { 
            var labels = document.getElementsByTagName("label"); 
            for (var j = 0; j < labels.length; j++) 
            { 
                if (labels[j].htmlFor == chkInput[i].id) 
                { 
                    rvalue += labels[j].innerHTML+"&"; 
                }  
            }  
            
        } 
    }     
	parent.getValue(rvalue);
}

function CloseDiv()
{
    parent.document.getElementById("LabelDivid").style.display="none";
}


</script>

