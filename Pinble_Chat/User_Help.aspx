<%@ Page Language="C#" AutoEventWireup="true" Codebehind="User_Help.aspx.cs" Inherits="Pinble_Chat.User_Help" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Head_Chat2.ascx" TagName="Head_Chat2" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>帮助中心 - 语音视频聊彩室 - 拼搏在线彩神通软件</title>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/chat.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">     

    function TuneHeight(fm_name,fm_id){          
        var frm=document.getElementById(fm_id);  
        var subWeb=document.frames?document.frames[fm_name].document:frm.contentDocument;  
        if(frm != null && subWeb != null)
        { 
        
            frm.style.height =  subWeb.documentElement.scrollHeight+"px"; 
            //如需自适应宽高，去除下行的“//”注释即可 
        // frm.style.width = "800px";
        }  
    }	
    
    function getParameter(param)
    {
        var query = window.location.search;
        var iLen = param.length;
        var iStart = query.indexOf(param);
        if (iStart == -1)
        {
          return "";
        }
        else
        {
            iStart += iLen + 1;
            var iEnd = query.indexOf("&", iStart);
            if (iEnd == -1)
            {
                return query.substring(iStart);
            }
            else
            {
                return query.substring(iStart, iEnd);
            }
        }
    }
    

     function GetThisSrc()
     {
        var temp = getParameter("myUrl");
        if(temp == "function")
        {
            document.getElementById("FM_Id").src = "http://chat.pinble.com:8888/userguide.htm"; 
          
            
        }
        else if(temp == "user")
        {
           document.getElementById("FM_Id").src = "http://chat.pinble.com:8888/allusers.htm";
        }
        else if(temp == "model")
        {
              document.getElementById("FM_Id").src = "http://chat.pinble.com:8888/top.htm";
        }
         else if(temp == "help")
        {
           document.getElementById("FM_Id").src = "http://chat.pinble.com:8888/userhelp.htm";
        }
        else
        {
              document.getElementById("FM_Id").src = "http://chat.pinble.com:8888/userhelp.htm";
        }
    }
    
// window.setInterval("TuneHeight('FM_Id','FM_Id');", 50);	
    </script>

</head>
<body onload="GetThisSrc();">
    <form id="form1" runat="server">
        <uc1:Head_Chat2 ID="Head_Chat2_1" runat="server"></uc1:Head_Chat2>
        <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <iframe height="100%" onload="this.height=document.body.clientHeight+600" name="FM_Id" id="FM_Id" width="100%"
                        marginwidth="0" marginheight="0" frameborder="0" scrolling="no" src="http://chat.pinble.com:8888/userhelp.htm"></iframe>
                </td>
            </tr>
        </table>
         <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
        <uc2:Footer ID="Footer1" runat="server" />
        </td>
            </tr>
        </table>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
