<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shrink.aspx.cs" Inherits="Pinble_Market.shrink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�ָ���</title>
<style type="text/css">
html { height:100%}
body { margin:0; padding:0; height:100%}
body,td { font-size:12px;}
body { background:url(../images/control_bg.jpg) repeat-y;cursor:pointer }
.cortrol1 { background:url(../images/control_btn.gif); height:44px; margin-top:230px; cursor:hand; }
.cortrol2 {
background:url(../images/control_btn.gif) -6px 0; height:44px; margin-top:230px; cursor:hand; }
</style>
<SCRIPT type="text/javascript">
	<!--
	var HideStatus=false;
	function PicOver()
	{
		if (!HideStatus)
		{
			PicArrow.className="cortrol1";
		}
		else
		{
			PicArrow.className="cortrol2";
		}
	}

	function PicOut()
	{
		if (!HideStatus)
		{
			PicArrow.className="cortrol1";
		}
		else
		{
			PicArrow.className="cortrol2";
		}
	}

	function HideMenu()
	{
		if (!HideStatus)
		{
			//parent.leftFrameSet.cols="0,*";
			parent.document.getElementById('leftFrameSet').cols = "0,*";			
			document.getElementById("bodyy").title="չ�������";
			HideStatus=true;
			PicOut();
		}
		else
		{
			//parent.leftFrameSet.cols="200,*";
			parent.document.getElementById('leftFrameSet').cols = "200,*";
			document.getElementById("bodyy").title="���������";
			HideStatus=false;
			PicOver();
		}
		try
		{
		    if(parent.mainFrame.islogin==1)
		    {
		       // alert(parent.mainFrame.aa());
		        parent.mainFrame.ShowLoginDialog();
		    }
		}
		catch(err)
		{
		   //alert(err);
		}
	}

	function HideMenuShowArticle()
	{
		if (!HideStatus)
		{
			parent.leftFrameSet.cols="0,*";
			PicArrow.title="չ�������";
			HideStatus=true;
			PicOut();
		}
	}

	//-->
	</SCRIPT>
</head>
<body oncontextmenu="return true;" onclick="HideMenu();" id="bodyy">
<img src="image/control_pic_top.jpg" alt="" style="height: 90px" />
<div class="cortrol1"  onmouseover="PicOver();" onmouseout="PicOut();" id="PicArrow" alt="���������"> </div>
<script type="text/javascript">if (!document.all)PicArrow=document.getElementById("PicArrow");</script>
</body>
</html>
