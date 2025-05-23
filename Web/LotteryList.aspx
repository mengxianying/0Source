<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LotteryList.aspx.cs" Inherits="Pbzx.Web.LotteryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开奖信息_拼搏在线彩神通软件</title>
    <meta name="keywords" content="开奖信息,3D, P3,排列三,排列五,七乐彩,双色球,七星彩,超级大乐透,体彩,福彩,福利彩票,体育彩票" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
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
</head>
<body onload="parent.document.getElementById('FM_Id').height=document.body.scrollHeight">
    <form id="form1" runat="server">
        <div class="kai_rbg">
            <%=ClassName %>
            <span class="kai_rbgz">&nbsp;<%=DateTime.Now.ToShortDateString() %></span></div>
        <table width="100%" id="tb1" runat="server" border="0" align="center" cellpadding="0"
            cellspacing="1" bgcolor="#B6CBE8" class="MT">
            <tr>
                <td width="120px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    彩种</td>
                <td width="118px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    开奖时间</td>
                <td width="72px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    期号</td>
                <td width="270" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    开奖号码</td>
                <td width="60px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    历史</td>
                <td width="160px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    开奖周期</td>
            </tr>
        </table>
    </form>
</body>
</html>
