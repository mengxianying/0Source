<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftMessage_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SoftMessage_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>
<head id="Head1" runat="server">
    <title>软件消息</title>
   <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
    <!-- stylecss/admin.css-->

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" src="../../javascript/calendar.js" type="text/javascript"></script>

    <script language="javascript" src="../../javascript/public.js" type="text/javascript"></script>

    <script language="javascript" src="../../javascript/Prototype.js" type="text/javascript"></script>

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
            document.getElementById('<%=txtMsgTime.ClientID%>').value=getDate();              
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="SoftMessage_Manage.aspx" class="zilan">软件消息管理</a> |&nbsp; <a href="SoftMessage_Editor.aspx"
                                        class="zilan">添加软件消息</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：<asp:Label ID="Label1" runat="server"></asp:Label>软件消息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="2" cellspacing="1" width="100%" bgcolor="#CED7F7">
                            <%--                            <tr bgcolor="#F2F8FB">
                                <td width="17%" class="bold">
                                    软件消息:</td>
                                <td width="83%" valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 15%;" valign="top">
                                                <asp:ListBox ID="lsbSoftType" runat="server" Height="150px" Width="120px"></asp:ListBox>
                                            </td>
                                            <td style="width: 85%;" valign="top">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <span id="adress"></span>您选择了：</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="DivContentText" style="width: 100%">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>--%>
                            <tr bgcolor="#F2F8FB">
                                <td>
                                    软件消息:
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpSoftType" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged"
                                                Width="80">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlInstallType" runat="server" Width="80">
                                                <asp:ListItem Value="">所有</asp:ListItem>
                                            </asp:DropDownList>
                                            版本：<asp:TextBox ID="txtMsgPV" runat="server" Text="所有" Width="80px"></asp:TextBox>
                                          
                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <%--                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册类型：</td>
                                <td>
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="33px" RepeatDirection="Horizontal"
                                        Width="258px">
                                        <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                                        <asp:ListItem Value="1">单机</asp:ListItem>
                                        <asp:ListItem Value="2">软件狗</asp:ListItem>
                                        <asp:ListItem Value="3">网络</asp:ListItem>
                                    </asp:CheckBoxList></td>
                            </tr>--%>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    消息等级:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgLevel" runat="server" Height="18px" RepeatDirection="Horizontal"
                                        Width="170px">
                                        <asp:ListItem Value="0" Selected="True">一般消息</asp:ListItem>
                                        <asp:ListItem Value="1">紧急消息</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    发布时间:</td>
                                <td>
                                    <asp:TextBox ID="txtMsgTime" runat="server" Width="170px"></asp:TextBox>
                                    <span style="color: #ff0000">* </span>
                                    <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" id="Button1" /></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    发布者:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgSender" runat="server" Height="18px" RepeatDirection="Horizontal"
                                        Width="174px">
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    标题:</td>
                                <td>
                                    <asp:TextBox ID="txtMsgTitle" runat="server" Width="450px"></asp:TextBox><span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    消息类型:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgType" runat="server" Height="18px" RepeatDirection="Horizontal"
                                        Width="113px">
                                        <asp:ListItem Value="0" Selected="True">html</asp:ListItem>
                                        <asp:ListItem Value="1">url</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    消息类别:</td>
                                <td>
                                    <asp:DropDownList ID="ddlMsgCategory1" runat="server" Width="124px">
                                        <asp:ListItem Value="系统消息">系统消息</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlMsgCategory2" runat="server" Width="124px">
                                        <asp:ListItem Value="网站公告">网站公告</asp:ListItem>
                                        <asp:ListItem>彩市资讯</asp:ListItem>
                                        <asp:ListItem>培训讲座</asp:ListItem>
                                        <asp:ListItem>软件发布</asp:ListItem>
                                        <asp:ListItem>软件升级</asp:ListItem>
                                        <asp:ListItem>软件技巧</asp:ListItem>
                                        <asp:ListItem>彩票预测</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" valign="top">
                                    消息内容<span class="Manage_Title">:</span></td>
                                <td class="Manage_Header">
                                    <FCKeditorV2:FCKeditor ID="txtMsgContent" runat="server" Width="95%" Height="380">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    时限:</td>
                                <td>
                                    从
                                    <asp:TextBox ID="txtPostTime1" runat="server" Width="125px"></asp:TextBox>
                                    至
                                    <asp:TextBox ID="txtPostTime2" runat="server" Width="125px"></asp:TextBox>
                                    <span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr id="Tr2" runat="server" bgcolor="#F1F1F1">
                                <td class="bold">
                                    消息状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgSend" runat="server" RepeatDirection="Horizontal"
                                        Width="128px">
                                        <asp:ListItem Value="1" Selected="True">发布</asp:ListItem>
                                        <asp:ListItem Value="0">不发布</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    访问统计:</td>
                                <td>
                                    今日访问：<asp:Label ID="lblToday" runat="server">0</asp:Label>
                                    次&nbsp;&nbsp; 总计访问：<asp:Label ID="lblTotal" runat="server">0</asp:Label>
                                    次</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px;">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btClose" runat="server" Text="取消" OnClick="btClose_Click" />
                                    <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
