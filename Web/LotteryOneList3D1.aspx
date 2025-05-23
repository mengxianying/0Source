<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LotteryOneList3D1.aspx.cs"
    Inherits="Pbzx.Web.LotteryOneList3D1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>开奖详细信息_拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩票开奖详细信息" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/lottery.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
body {
	background-color: #FFFFFF;
	background-image: url(images/Web/bai_bg.jpg);
}
-->
</style>

    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>

  <script type="text/javascript">
 $(document).ready(function(){
 
     $("#ceshitext").click(function(){
       $.ajax({
                    type:"POST",
                    contentType:"application/json",
                   url:"Template/WebService1.asmx/PresentList",
                   data:"{type:'高频体彩'}",
                  
//                   url:"Template/WebService1.asmx/Present3DList",
//                   data:"{pageindex:'1',lottory: 'TC11X5Data_ShanD',pl3: '',name : '3D'}",
                    dataType:"json",
                    success:function(data){ 
                        $("#rather").html(HtmlDecode(data));
                    }
                });
     });
 });
 
         //html解码
    	function HtmlDecode(text) 
        { 
            return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>'); 
        }
    </script>

</head>
<body>
    <form id="form1">
        <input type="button" value="3D" id="ceshitext" />
        <div id='rather'>
        </div>
    </form>
</body>
</html>
