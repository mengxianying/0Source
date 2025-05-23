<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CstRemote.aspx.cs" Inherits="Pbzx.Web.Template.CstRemote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>彩神通软件消息 - 拼搏在线彩神通软件 </title>
    <style type="text/css">
<!--
a:link { font-size: 9pt;text-decoration:none;color:#000000}
a:hover {font-size: 9pt;text-decoration:none; color: #ff0000}
a:visited {font-size: 9pt;text-decoration:none;color:#000000}
a:active   {font-size: 9pt;text-decoration:none;}

.dh:link { font-size: 12px;text-decoration:none;color:#215197} 
.dh:hover {font-size: 12px;text-decoration:none; color: #ff0000}
.dh:visited {font-size: 12px;text-decoration:none;color:#215197}
.dh:active  {font-size: 12px;text-decoration:none;}


.tt {color: #CC3333}
.newsmsg {
	font-size: 12px;
	font-weight: bold;
}
.new2 {font-size: 12px; font-weight: bold; color: #CC3333; }
.style2 {font-size: 12}
.style5 {font-size: 12px}
.style7 {font-size: 12px; color: #0062C4; }

-->
    </style>
    <script type="text/javascript" language="JavaScript">
document.oncontextmenu=new Function("event.returnValue=false;");
document.onselectstart=new Function("event.returnValue=false;");
    </script>

</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="32" align="center" bgcolor="E6ECFE" style="font-size: 12px; width: 737px;">
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Default.htm" target="_blank"
                            class="dh">首页</a>| <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Bulletin.htm"
                                target="_blank" class="dh">公告</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>News.htm"
                                    target="_blank" class="dh">资讯</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Soft.aspx"
                                        target="_blank" class="dh">商城</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Source.aspx"
                                            target="_blank" class="dh">资源</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Lottery.htm"
                                                target="_blank" class="dh">开奖</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>graph.htm"
                                                    target="_blank" class="dh">图表</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>School.htm"
                                                        target="_blank" class="dh">学院</a> | <a href="<%=Pbzx.Common.WebInit.ask.WebUrl%>Default.aspx"
                                                            target="_blank" class="dh">拼搏吧</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Broker.aspx"
                                                                target="_blank" class="dh">经纪人</a> | 
                        <a href="http://bbs.pinble.com/index.asp" target="_blank" class="dh">论坛</a>
                    </td>
                </tr>
            </table>
            <table width="100%" height="217" border="0" cellpadding="0" cellspacing="1" bgcolor="#0062C4">
                <tr>
                    <td width="211" height="219" align="center" valign="top" bgcolor="#FFFFFF">
                        <table width="201" height="128" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="3" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td width="70%" height="13" align="center" valign="baseline" bgcolor="#0062C4">
                                    <span class="newsmsg"><font color="#FFFFFF">最新软件信息</font></span></td>
                                <td width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr valign="top">
                                <td height="100" colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" height="5">
                                    </table>
                                    <div id="NewSoft" runat="server" style="width: 100%;">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="1051" align="center" valign="top" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="3">
                                </td>
                            </tr>
                        </table>
                        <table width="98%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="45%" align="center" valign="baseline" bgcolor="#0062C4">
                                    <strong class="newsmsg"><font color="#FFFFFF">最新公告</font></strong></td>
                                <td width="55%">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div id="NewNews" runat="server" style="width: 100%;">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
