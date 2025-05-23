<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QQ_RecordEdite.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.QQ_RecordEdite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QQ号修改</title>
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <script type="text/javascript" language="javascript">
        function getDate()
        {
          var d,s,t;
          d=new Date();
          s=d.getFullYear().toString(10)+"-";
          t=d.getMonth()+1;
          s+=(t>9?"":"0")+t+"-";
          t=d.getDate();
          s+=(t>9?"":"0")+t+" ";
          t=d.getHours();
          s+=(t>9?"":"0")+t+":";
          t=d.getMinutes();
          s+=(t>9?"":"0")+t+":";
          t=d.getSeconds();
          s+=(t>9?"":"0")+t;
          return s;
        }
        function getnowtime()
        {
            document.getElementById('<%=txtAddTime.ClientID%>').value=getDate();              
        }        
        function getnowtime1()
        {
            document.getElementById('<%=txtKickOffTime.ClientID%>').value=getDate();              
        }               
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div>
                <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT2">
                    <tr>
                        <td width="20" class="uc_xia" height="25">
                            <img src="../images/web/Uc_li.gif" alt="" /></td>
                        <td width="680" class="uc_xia" valign="bottom">
                            <span class="uc_font_blue14">
                                <asp:Label ID="lblAction" runat="server" Text=""></asp:Label></span>
                        </td>
                        <td width="680" class="uc_xia" valign="bottom" align="right">
                        </td>
                    </tr>
                </table>
            </div>
            <table runat="server" id="tbEdite" border="0" cellspacing="1" bgcolor="#DDDDDD" align="center"
                cellpadding="3" width="800">
                <tr>
                    <td width="25%" align="right" bgcolor="#F6F6F6">
                        所属QQ群：
                    </td>
                    <td width="75%" align="left" bgcolor="#FFFFFF">
                        <asp:DropDownList ID="ddlQQ_GropID" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        QQ号：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtQQ_ID" runat="server" MaxLength="40"></asp:TextBox><font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        用户名：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="25" onblur="CheckUserInput(this.value,'mySpUname');"></asp:TextBox>&nbsp;
                        <img src="../Images/Web/note_ok.gif" id="imgOK" style="display: none;" />
                        <img src="../Images/Web/note_error.gif" id="imgError" style="display: none;" />
                        <span id="mySpUname"></span>&nbsp;<asp:CheckBox ID="chbIsLock" runat="server" Text="锁定" />&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        在线状态：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:RadioButtonList ID="rblOnlineState" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">在线</asp:ListItem>
                            <asp:ListItem Value="1">退出</asp:ListItem>
                            <asp:ListItem Value="2">被踢</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        加入时间：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtAddTime" runat="server" MaxLength="100" Width="180px"></asp:TextBox>
                        <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" />
                        时间格式为：<font color="#0000FF">2003-5-12 12:32:47</font>
                        <%--&nbsp;<asp:ListBox ID="lsbAdmin" runat="server"></asp:ListBox>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        退出时间：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtKickOffTime" runat="server" MaxLength="100" Width="180px"></asp:TextBox>
                        <input type="button" value="获取当前时间" onclick="javascript:getnowtime1()" style="width: 101px" />
                        时间格式为：<font color="#0000FF">2003-5-12 12:32:47</font>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#f6f6f6">
                        添加人员：</td>
                    <td align="left" bgcolor="#ffffff">
                        <asp:TextBox ID="txtaddren" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#f6f6f6">
                        修改人员：</td>
                    <td align="left" bgcolor="#ffffff">
                        <asp:TextBox ID="txtupdateren" runat="server" Height="73px" TextMode="MultiLine"
                            Width="447px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        说明：<br />
                        (进群申请或被踢原因)
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtQQ_Detail" runat="server" MaxLength="1000" TextMode="MultiLine"
                            Width="450px" Height="150px"></asp:TextBox>(注：最多1000字)</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        <asp:HiddenField ID="hfID" runat="server" />
                    </td>
                    <td align="center" bgcolor="#F6F6F6">
                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack1_Click" /></td>
                    <td>
                    </td>
                </tr>
            </table>
            <table id="tbSee" runat="server" border="0" cellspacing="1" bgcolor="#DDDDDD" align="center"
                cellpadding="3" width="800">
                <tr>
                    <td width="25%" align="right" bgcolor="#F6F6F6">
                        所属QQ群：
                    </td>
                    <td width="75%" align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblQQ_GropID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        QQ号：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblQQ_ID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        用户名：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        在线状态：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblOnlineState" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" style="height: 11px">
                        加入时间：
                    </td>
                    <td align="left" bgcolor="#FFFFFF" style="height: 11px">
                        <asp:Label ID="lblAddTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        退出时间：
                    </td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblKickOffTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        说明(被踢记录原因等等)：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblQQ_Detail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        &nbsp;</td>
                    <td align="left" bgcolor="#FFFFFF">
                        &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnBack1" runat="server" Text="返回" OnClick="btnBack1_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
