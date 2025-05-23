<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="displayData.aspx.cs" Inherits="Pinble_DataRivalry.displayData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>大底号码 - 大底比拼 - 拼搏在线彩神通软件<</title>
        <script type="text/javascript">
            $(document).ready(function () {

                $("#c1").click(function () {
                    $.XYTipsWindow.removeBox();
                });

            });
            function copyText(obj) {
                var rng = document.body.createTextRange();
                rng.moveToElementText(obj);
                rng.scrollIntoView();
                rng.select();
                rng.execCommand("Copy");
                rng.collapse(false);
                alert("复制成功!");
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font: 14px 'Microsoft Yahei',arial,SimSun,sans-serif;margin: 0 auto;padding: 0px;text-align: center;color: #555;background: #fff; ">
        
            <button id="c1" class="seach-button">
            关闭</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<a href="#" onclick="copyText(tbid)"><font color="blue">复制号码</font></a>]
            <br />
            <h3>
            <asp:Label ID="tbid" runat="server" Text="Label"></asp:Label>
            
         </h3>
    </div>
    </form>
</body>
</html>
