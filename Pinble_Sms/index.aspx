<%@ Page Language="C#" AutoEventWireup="true" Codebehind="index.aspx.cs" Inherits="Pinble_DataRivalry.index" %>

<%@ Register Src="Contorls/logion.ascx" TagName="logion" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ƴ�����߲�Ʊƽ̨����ױ�ƴ</title>
    <meta http-equiv="pragma"  content="no-cache">  
    <meta http-equiv="Cache-Control"  content="no-cache,  must-revalidate">  
    <meta http-equiv="expires" content="0"> 
</head>
<frameset cols="200,*" framespacing="0" frameborder="no" border="0" id="leftFrameSet">
	<frameset rows="94,*" frameborder="no" border="0" framespacing="0" id="leftFrames" id="forumframeSet">
		<frame src="Images/LOGONew.swf" name="leftFrame" scrolling="no" noresize="noresize" id="leftFrame" />
		<frame src="left.aspx" name="left" id="left" scrolling="yes">
	</frameset>
	<frameset cols="6,*" framespacing="0" frameborder="no" border="0" >
		<frame src="shrink.aspx" name="cortrolFrame" scrolling="No" noresize="noresize" id="cortrolFrame" />
		<frame src="/Note/Note_ShoppingList.aspx" name="mainFrame" scrolling="yes" id="mainFrame" title="mainFrame" />
	</frameset>
</frameset>
<noframes>
	<body>
	</body>
</noframes>
</html>
