<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftMessage_Editor_2011.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftMessage_Editor_2011" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
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
        function getnowDate() {
            //获取值
            var dateValue1 = document.getElementById("txtPostTime1").value;

            var dateValue2 = document.getElementById("txtPostTime2").value;

            //组合时间
            var valueDate =getDate().substr(0,getDate().indexOf(" "));  //获取当前日期

            var valueTime1 = dateValue1.substr(dateValue1.indexOf(" ")+1, dateValue1.length); //获取时间
            //开始时间
            var beginTime = valueDate.trim() + " " + valueTime1;
            document.getElementById('<%=txtPostTime1.ClientID%>').value = beginTime;

            //结束时间
            var valueTime2 = dateValue2.substr(dateValue2.indexOf(" ")+1, dateValue2.length); //获取时间
            var endTime = valueDate.trim() + " " + valueTime2;
            document.getElementById('<%=txtPostTime2.ClientID%>').value = endTime;
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
                                    <a href="SoftMessage_Manage_2011.aspx" class="zilan">软件消息管理</a> |&nbsp; <a href="SoftMessage_Editor_2011.aspx"
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
                                                当前位置：<asp:Label ID="Label1" runat="server"></asp:Label>软件消息添加修改</td>
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
                                <td style="width: 131px; text-align: right">
                                    <strong>软件限定信息:</strong></td>
                                <td>
                                    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged"
                                                            Width="80">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlInstallType" runat="server" Width="80">
                                                        </asp:DropDownList>
                                                        版本：<asp:TextBox ID="txtMsgPV" runat="server" Width="48px"></asp:TextBox>
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtMsgPV2" runat="server" Width="48px"></asp:TextBox>&nbsp; &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">>></asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 92px">
                                                        <asp:ListBox ID="Lists" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Lists_SelectedIndexChanged"
                                                            Width="308px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><<不限定>></asp:LinkButton><br />
                                                        <br />
                                                        <asp:LinkButton ID="linkBtnrem" runat="server" OnClick="linkBtnrem_Click"><<移除>></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td style="width: 131px; height: 32px; text-align: right">
                                    <strong>注册限定信息:</strong></td>
                                <td rowspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    <asp:CheckBoxList ID="checkBoxreg" runat="server" RepeatDirection="Horizontal" DataTextField="name"
                                        DataValueField="number" RepeatColumns="5" AutoPostBack="True" OnSelectedIndexChanged="checkBoxreg_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                
                                    <asp:CheckBoxList ID="CheckBoxUser" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                                        DataTextField="name" DataValueField="number" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxUser_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td style="width: 131px; height: 55px; text-align: right">
                                    <strong>用户限定信息:</strong></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td style="width: 131px; height: 36px; text-align: right">
                                    <strong>用户名限定:</strong></td>
                                <td rowspan="1" style="height: 36px">
                                    <asp:TextBox ID="txtusername" runat="server" TextMode="MultiLine" Width="306px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td style="width: 131px; height: 37px; text-align: right">
                                    <strong>认证码限定:</strong></td>
                                <td rowspan="1" style="height: 37px">
                                    <asp:TextBox ID="txtRzm" runat="server" TextMode="MultiLine" Width="306px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px">
                                    消息等级:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgLevel" runat="server" Height="18px" RepeatDirection="Horizontal"
                                        DataTextField="name" DataValueField="number" RepeatColumns="5" OnSelectedIndexChanged="rblMsgLevel_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px">
                                    发布时间:</td>
                                <td>
                                    <asp:TextBox ID="txtMsgTime" runat="server" Width="170px"></asp:TextBox>
                                    <span style="color: #ff0000">* </span>
                                    <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" id="Button1" /></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px">
                                    发布者:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgSender" runat="server" Height="18px" RepeatDirection="Horizontal"
                                        Width="174px">
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px; height: 28px;">
                                    标题:</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtMsgTitle" runat="server" Width="450px"></asp:TextBox><span style="color: #ff0000">*<br />
                                       </span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px">
                                    消息类型:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgType" runat="server" Height="18px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMsgType_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="0">html (使用内置模版编辑)</asp:ListItem>
                                        <asp:ListItem Value="1">url (使用其他Web页面，引用页标题必须包括“彩神通消息”)</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px">
                                    消息类别:</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlMsgCategory1" runat="server" Width="124px" AutoPostBack="True"
                                                DataTextField="name" DataValueField="number" OnSelectedIndexChanged="ddlMsgCategory1_SelectedIndexChanged">
                                                <asp:ListItem Value="系统消息">系统消息</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMsgCategory2" runat="server" Width="124px" DataTextField="name" DataValueField="name">
                                                <asp:ListItem Value="网站公告">网站公告</asp:ListItem>
                                                <asp:ListItem>彩市资讯</asp:ListItem>
                                                <asp:ListItem>培训讲座</asp:ListItem>
                                                <asp:ListItem>软件发布</asp:ListItem>
                                                <asp:ListItem>软件升级</asp:ListItem>
                                                <asp:ListItem>软件技巧</asp:ListItem>
                                                <asp:ListItem>彩票预测</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" valign="top" style="width: 131px">
                                    <asp:Label ID="lblcontent" runat="server" Text="消息内容"></asp:Label>
                                    <span class="Manage_Title">:</span></td>
                                <td class="Manage_Header">
                                    <div id="divcontent" runat="server">
                                        <asp:RadioButtonList ID="Rdbtn1" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">模版一(266*118)</asp:ListItem>
                                            <asp:ListItem Value="1">模版二(260*122)</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <FCKeditorV2:FCKeditor ID="txtMsgContent" runat="server" Width="95%" Height="380">
                                        </FCKeditorV2:FCKeditor>
                                        <asp:TextBox ID="txtMsgContent1" runat="server" Height="100px" TextMode="MultiLine"
                                            Width="455px"></asp:TextBox><br />
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">预览模版</asp:LinkButton>
                                    </div>
                                    <div id="Divurl" runat="server" visible="false">
                                    <asp:TextBox ID="txturl" runat="server" Visible="False" Width="447px"></asp:TextBox>
                                    宽：<asp:TextBox ID="txtwidth" runat="server" Width="30px" Text="0"></asp:TextBox> px 
                                    高：<asp:TextBox ID="txtheight" runat="server" Width="30px" Text="0"></asp:TextBox> px 
                                    </div></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                             <td class="bold" valign="top" style="width: 131px">标题内容URL链接：
                             </td>
                             <td class="Manage_Header">
                              <asp:TextBox ID="txttitleUrl" Width="450px" runat="server" Enabled="False"></asp:TextBox>(必须以http://开头,仅对网页消息类型有效！)
                             </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px;">
                                    时限:</td>
                                <td>
                                    从
                                    <asp:TextBox ID="txtPostTime1" runat="server" Width="130px"></asp:TextBox>
                                    至
                                    <asp:TextBox ID="txtPostTime2" runat="server" Width="130px"></asp:TextBox>
                                    <span style="color: #ff0000">*</span>
                                    <input type="button" value="获取当前日期" onclick="javascript:getnowDate()" style="width: 101px" id="Button2" />
                                    </td>
                            </tr>
                            <tr id="Tr2" runat="server" bgcolor="#F1F1F1">
                                <td class="bold" style="width: 131px">
                                    消息状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblMsgSend" runat="server" RepeatDirection="Horizontal"
                                        Width="128px" >
                                        <asp:ListItem Value="1" >发布</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">不发布</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 131px">
                                    访问统计:</td>
                                <td>
                                    今日访问：<asp:Label ID="lblToday" runat="server" Text="0"></asp:Label>
                                    次&nbsp;&nbsp; 总计访问：<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
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
