<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Default" %>

<html>
<head id="Head1" runat="server">
    <title>拼搏在线后台管理中心</title>
<%-- <link type="text/css" rel="stylesheet" href="stylecss/css_l.css" />--%>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <!---->
<%--    <script language="Javascript" type="text/javascript">
    if(self.location != top.location)
    {
        top.location.replace(self.location);
    }
    var menu, titles, submenus;   
    if(document.all){
        window.attachEvent('onresize',winResize);
    }
    else{
        window.addEventListener('resize',winResize,false);
    }
 //   window.onload = init;
    </script>--%>
<%--    <script type="text/javascript" language="javascript">
	function showsubmenu(sid){
		var idcount=document.getElementById('idcount').value;
		for(var i=0;i<idcount;i++){
			eval("submenu" + i + ".style.display=\"none\";");
		}
		whichEl = eval("submenu" + sid);
		if (whichEl.style.display == "none"){
			eval("submenu" + sid + ".style.display=\"\";");
		}else{
			eval("submenu" + sid + ".style.display=\"none\";");
		}
		
	}
    </script>--%>



</head>
    <frameset cols="187,*" frameborder="NO" border="0" framespacing="0" rows="*" >
     <frame id="leftFrame"  src="Left.aspx" marginwidth="0" marginheight="0" scrolling="AUTO" noresize="noresize">
     </frame>
       <frame frameborder="0"  scrolling="AUTO" noresize="noresize" src="index.htm" id="ShowPage" name="ShowPage" 
                   marginwidth="10" marginheight="10" border="No">             
       </frame>
</frameset>
    <%--    <div id="MainTable">

        
        
        <div id="RightDiv">
            <div id="divFrame"style="background-color:#AFDAF0">
              
            </div>
        </div>
        
        
    </div>--%>
    <noframes>
    <body style="overflow: scroll; overflow-x: hidden;">
</body>
</noframes>
</html>
