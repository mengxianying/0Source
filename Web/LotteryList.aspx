<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LotteryList.aspx.cs" Inherits="Pbzx.Web.LotteryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>������Ϣ_ƴ�����߲���ͨ���</title>
    <meta name="keywords" content="������Ϣ,3D, P3,������,������,���ֲ�,˫ɫ��,���ǲ�,��������͸,���,����,������Ʊ,������Ʊ" />
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
                    ����</td>
                <td width="118px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    ����ʱ��</td>
                <td width="72px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    �ں�</td>
                <td width="270" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    ��������</td>
                <td width="60px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    ��ʷ</td>
                <td width="160px" bgcolor="#E9F3FE" class="L_zi1" style="height: 26px">
                    ��������</td>
            </tr>
        </table>
    </form>
</body>
</html>
