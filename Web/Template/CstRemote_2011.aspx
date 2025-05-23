<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CstRemote_2011.aspx.cs"
    Inherits="Pbzx.Web.Template.CstRemote1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>彩神通软件消息_拼搏在线彩神通软件 </title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <style type="text/css">
<!--
a:link { font-size: 9pt;text-decoration:none;color:#000000}
a:hover {font-size: 9pt;text-decoration:none; color: #ff0000}
a:visited {font-size: 9pt;text-decoration:none;color:#000000}
a:active   {font-size: 9pt;text-decoration:none;}

.dh:link { font-size: 12px;text-decoration:none;color:#FFFFFF} 
.dh:hover {font-size: 12px;text-decoration:none; color: #ff0000}
.dh:visited {font-size: 12px;text-decoration:none;color:#FFFFFF}
.dh:active  {font-size: 12px;text-decoration:none;}

.tt {color: #CC3333}
.newsmsg {
	font-size: 12px;
	font-weight: bold;
}
.new2 {font-size: 12px; font-weight: bold; color: #CC3333; }
.style2 {font-size: 12px;}
.style5 {font-size: 12px}
.style7 {font-size: 12px; color: #0062C4; }

-->
    </style>

    <script type="text/javascript" language="JavaScript">
document.oncontextmenu=new Function("event.returnValue=false;");
document.onselectstart=new Function("event.returnValue=false;");
    </script>

</head>
<!-- style="margin: 0px;overflow:hidden" scroll="no" -->
<body scroll="no" style="margin: 0px; overflow-y: hidden; overflow-x: hidden;">
    <form id="form1" runat="server">
        <div style="width: 594px;">
            <table width="594" border="0" cellspacing="0" cellpadding="0">
                <tr style="background-image: url(Images/Web/soft/Yelobg.png); background-repeat: repeat-x">
                    <td align="center" style="font-size: 12px; width: 737px; height: 28px;">
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Default.htm" target="_blank" class="dh">首页</a><font style="color: #6C6C6C"> |</font> 
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Bulletin.htm" target="_blank" class="dh">公告</a> <font style="color: #6C6C6C">|</font>
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>News.htm" target="_blank" class="dh">资讯</a> <font style="color: #6C6C6C">|</font> 
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Soft.aspx" target="_blank" class="dh">商城</a> <font style="color: #6C6C6C">| </font>
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Source.aspx" target="_blank" class="dh">资源</a> <font style="color: #6C6C6C">| </font>
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Lottery.htm" target="_blank" class="dh">开奖</a> <font style="color: #6C6C6C">| </font>
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>graph.htm" target="_blank" class="dh">图表</a> <font style="color: #6C6C6C">| </font>
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>School.htm" target="_blank" class="dh">学院</a> <font style="color: #6C6C6C">| </font>
                        <a href="<%=Pbzx.Common.WebInit.ask.WebUrl%>Default.aspx" target="_blank" class="dh">拼搏吧</a> <font style="color: #6C6C6C">| </font>
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Broker.aspx" target="_blank" class="dh">经纪人</a> <font style="color: #6C6C6C">| </font>
<!--
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.ChatUrl %>Default.aspx" target="_blank" class="dh">聊 彩</a> <font style="color: #6C6C6C">| </font>
-->
                        <a href="http://bbs.pinble.com/index.asp" target="_blank" class="dh">论 坛</a>
                    </td>
                </tr>
            </table>
            <table width="594px" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right" style="background-image: url(Images/Web/soft/bgLift.png); background-repeat: no-repeat;
                        width: 297px;">
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Soft.aspx" target="_blank">更多&gt;&gt;</a>&nbsp;&nbsp;</td>
                    <td align="right" style="width: 297px; height: 28px; background-image: url(Images/Web/soft/bgright.jpg)">
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Bulletin.htm" target="_blank">
                            更多>></a> &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" style="height: 19px" colspan="2">
                        <div id="NewSoft" runat="server">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <%--   注释--%>
</body>
</html>
