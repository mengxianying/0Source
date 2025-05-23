<%@ Page Language="C#" AutoEventWireup="true" Codebehind="graph.aspx.cs" Inherits="Pbzx.Web.graph" %>

<%@ Register Src="../Contorls/UcShuang.ascx" TagName="UcShuang" TagPrefix="uc4" %>

<%@ Register Src="../Contorls/TempletDanHao.ascx" TagName="TempletDanHao" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>3D数据图表_拼搏在线彩神通软件</title>
    <meta name="keywords" content="3D,福彩,福利彩票,图表,走势图" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/graph.css" rel="stylesheet" type="text/css" />
    <link href="/css/lottery.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
	    function graphQiehuan(id,intIndex,total,czName){
	        for(var i=1;i<=total;i++)
	        {
		        var objA = document.getElementById(id+i); 
		        if(i==intIndex)
		        {			       
		            objA.className = "nav_on";	    
		        }
		        else
		        {
		            objA.className = "nav_off";
		        }
	        }
	        top.document.title = czName+"数据图表";
	    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <!---图表显示--->
            <div class="bodyw">
                <table width="990" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#AABFD9"
                    class="MT8">
                    <tr>
                        <td bgcolor="#ffffff" class="l_menubg">
                            <table width="99%" border="0" align="center" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td align="left" class="L_color2">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="7%">
                                                    <strong>图表类别&gt;&gt;</strong>
                                                </td>
                                                <td width="93%" align="left" valign="middle">
                                                    <div id="menu" runat="server">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td background="/images/Web/G_soubg.gif">                                                
                              <iframe src="/ShuZiType.aspx" onload="this.height=FM_Id.document.body.scrollHeight+19"  name="FM_Id" id="FM_Id" width="990" marginwidth="0" marginheight="0" frameborder="0"  style="Z-INDEX: 2; VISIBILITY: inherit;"></iframe>                              
                        </td>
                    </tr>
                </table>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
