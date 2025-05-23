<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Pinble_Ask.User" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人中心_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function qiehuan(obj, intIndex, total) {
            for (var i = 1; i <= total; i++) {
                var objHide = document.getElementById(obj + i);
                if (i == intIndex) {
                    objHide.style.display = "";
                }
                else {
                    objHide.style.display = "none";
                }
            }

            var myTitle = document.getElementById("tdTitle");
            switch (intIndex) {
                case 1:
                    myTitle.innerHTML = "我的资料"
                    break
                case 2:
                    myTitle.innerHTML = "查看积分"
                    break
                case 1:
                    myTitle.innerHTML = "我的提问"
                    break
                case 1:
                    myTitle.innerHTML = "我的回答"
                    break
                default:
                    myTitle.innerHTML = "我的资料"
                    break
            }
        }
    </script>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UcAskHead ID="UcAskHead1" runat="server" />
        <table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="180" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="user_xia">
                        <tr>
                            <td height="26" bgcolor="#1E9FDD" class="u12white">
                                <%=Method.Get_UserName%>
                                的拼搏吧
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#B7B7B7">
                        <tr>
                            <td align="center" bgcolor="#F0F8FF">
                                <a href="User.aspx?disp=1" style="cursor: pointer;">
                                    <div style="cursor: pointer;" class="umenu">
                                        我的资料<br />
                                    </div>
                                </a><a href="User.aspx?disp=2" style="cursor: pointer;">
                                    <div class="umenu" style="cursor: pointer;">
                                        查看积分<br />
                                    </div>
                                </a><a href="User.aspx?disp=3" style="cursor: pointer;">
                                    <div class="umenu" style="cursor: pointer;">
                                        我的提问<br />
                                    </div>
                                </a><a href="User.aspx?disp=4" style="cursor: pointer;">
                                    <div class="umenu" style="cursor: pointer;">
                                        我的回答<br />
                                    </div>
                                </a>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="user_xia MT">
                        <tr>
                            <td height="26" bgcolor="#1E9FDD" class="u12white">
                                新手入门
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#B7B7B7">
                        <tr>
                            <td align="left" bgcolor="#F0F8FF" style="padding-left: 6px;">
                                ·<a href="Help.aspx#ask">如何提问 </a>
                                <br />
                                ·<a href="Help.aspx#ans">如何回答</a><br />
                                ·<a href="Help.aspx#chu">如何处理问题</a><br />
                                ·<a href="Help.aspx#pass">如何处理过期问题</a><br />
                                ·<a href="Help.aspx#colse">问题为何被关闭</a><br />
                                ·<a href="Help.aspx#point">如何获得积分</a><br />
                                ·<a href="Help.aspx#titlr">关于头衔</a><br />
                                ·<a href="Help.aspx#cannl">如何避免问答被删</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20px">
                    &nbsp;
                </td>
                <td width="770" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#1E9FDD">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="user_xia2">
                                    <tr>
                                        <td bgcolor="#3EAFE6" class="u12white" id="tdTitle">
                                            <asp:Label ID="lblTitle" runat="server" Text="我的资料"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#FFFFFF" id="tdMain" runat="server">
                                <asp:Panel runat="server" ID="pnl1" Width="100%">
                                    <table width="96%" border="0" align="center" cellpadding="6" cellspacing="1" bgcolor="#E3E3E3"
                                        style="margin-top: 12px;">
                                        <tr>
                                            <td width="17%" align="right" bgcolor="#FFFFFF">
                                                用户名：
                                            </td>
                                            <td width="30%" align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblUName" runat="server" Text="未知"></asp:Label>
                                            </td>
                                            <td width="13%" align="right" bgcolor="#FFFFFF">
                                                真实姓名：
                                            </td>
                                            <td width="40%" align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblRealName" runat="server">未知</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                生日：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblBirthDay" runat="server" Text="未知"></asp:Label>
                                            </td>
                                            <td align="right" bgcolor="#FFFFFF">
                                                性别：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblSex" runat="server" Text="未知"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                邮箱：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblEmail" runat="server" Text="未知" ToolTip="未知"></asp:Label>
                                            </td>
                                            <td align="right" bgcolor="#FFFFFF">
                                                QQ：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblQq" runat="server" Text="未知"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                所在地：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblAddress" runat="server" Text="未知"></asp:Label>
                                            </td>
                                            <td align="right" bgcolor="#FFFFFF">
                                                MSN：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblMSN" runat="server" Text="未知"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                注册时间：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblRegTime" runat="server" Text="未知"></asp:Label>
                                            </td>
                                            <td align="right" bgcolor="#FFFFFF">
                                                登录次数：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <asp:Label ID="lblLoginCount" runat="server" Text="未知"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF" style="height: 32px">
                                                最后登录：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF" style="height: 32px">
                                                <asp:Label ID="lblLastLogin" runat="server" Text="未知"></asp:Label>
                                            </td>
                                            <td align="right" bgcolor="#FFFFFF" style="height: 32px">
                                                等级：&nbsp;
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF" style="height: 32px">
                                                &nbsp;<asp:Label ID="lblGrade" runat="server" Text="未知"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="96%" border="0" align="center" cellpadding="6" cellspacing="0">
                                        <tr>
                                            <td align="center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl2" Width="100%" Visible="false">
                                    <table width="97%" border="0" align="center" cellpadding="2" cellspacing="0" style="margin-top: 8px;">
                                        <tr>
                                            <td align="left" colspan="4">
                                                &nbsp;<strong>积分明细：</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                总分
                                            </td>
                                            <td>
                                                奖励得分
                                            </td>
                                            <td>
                                                历史付出
                                            </td>
                                            <td>
                                                处罚
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTotalPoint" runat="server">0</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAnswerPoint" runat="server">0</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblXSPoint" runat="server">0</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOtherPointpenalty" runat="server">0</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="97%" align="center" style="margin-top: 15px;">
                                        <tr>
                                            <td align="left" colspan="5">
                                                &nbsp;<strong>问答明细：</strong>
                                            </td>
                                            <td align="left" colspan="1">
                                            </td>
                                            <td align="left" colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                回答总数
                                            </td>
                                            <td>
                                                回答被采纳
                                            </td>
                                            <td>
                                                回答被采纳率
                                            </td>
                                            <td>
                                                提问数
                                            </td>
                                            <td>
                                                已经解决
                                            </td>
                                            <td>
                                                解决中
                                            </td>
                                            <td>
                                                已关闭
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAnswerCount" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBestAnswer" runat="server">0</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRat" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAskCount" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHasAnwer" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInAnswer" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblClose" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl3" Width="100%" Visible="false">
                                    <table border="0" cellpadding="2" cellspacing="0" width="95%" align="center" style="margin-top: 6px;">
                                        <tr>
                                            <td>
                                                <div class="Listl">
                                                    <div class="As_list_qiebg">
                                                        <%=myChange[0]%>
                                                        <%=myChange[1]%>
                                                        <%=myChange[2]%>
                                                    </div>
                                                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="95%"
                                                        CssClass="mMT" HorizontalAlign="Center" BorderWidth="0px" GridLines="None" EnableModelValidation="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="&amp;nbsp;标题">
                                                                <ItemTemplate>
                                                                    <span class="f14black">·</span><a href='Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>'
                                                                        target="_blank" class="Linl14" title='<%#Eval("Title") %>'>
                                                                        <%# Convert.ToBoolean(Eval("IsCommend")) ? "<font color='red'>[精]</font>" : "" %>
                                                                        <%#StrFormat.CutStringByNum(Eval("Title"),30*2)%>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="50%" Height="22px" BorderWidth="0px" />
                                                                <ControlStyle CssClass="f14black list_xia2" />
                                                                <HeaderStyle BorderWidth="0px" CssClass="list_xia2" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="回答数">
                                                                <ItemTemplate>
                                                                    <%#Eval("Replys")%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="11%" HorizontalAlign="Center" CssClass="list_xia2" BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle BorderWidth="0px" CssClass="list_xia2" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="审核状态">
                                                                <ItemTemplate>
                                                                    <%# shzt(Eval("Auditing"))%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" Font-Bold="True"
                                                                    BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle BorderWidth="0px" CssClass="list_xia2" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="状态">
                                                                <ItemTemplate>
                                                                    <img src='images/State_<%#Eval("State") %>.gif' width="16" height="16" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" Font-Bold="True"
                                                                    BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle BorderWidth="0px" CssClass="list_xia2" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="提问时间">
                                                                <ItemTemplate>
                                                                    <%# Eval("AskTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="19%" CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle BorderWidth="0px" CssClass="list_xia2" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="litContent" runat="server"></asp:Label>
                                                    <table width="98%" border="0" align="center" cellpadding="1" cellspacing="0">
                                                        <tr>
                                                            <td style="height: 1px">
                                                                <!--  #83B5E2 -->
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                                                    ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center" CssClass="Link_Xia">
                                                                </webdiyer:AspNetPager>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl4" Width="100%" Visible="false">
                                    <table border="0" cellpadding="2" cellspacing="0" width="95%" align="center" style="margin-top: 6px;">
                                        <tr>
                                            <td>
                                                <div class="Listl">
                                                    <div class="As_list_qiebg">
                                                        <%=myChange1[0]%>
                                                        <%=myChange1[1]%>
                                                    </div>
                                                    <asp:GridView ID="MyGridView1" runat="server" AutoGenerateColumns="False" Width="95%"
                                                        CssClass="mMT" HorizontalAlign="Center" BorderWidth="0px" GridLines="None">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="&amp;nbsp;标题">
                                                                <ItemTemplate>
                                                                    <span class="f14black">·</span><a href='Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>'
                                                                        target="_blank" class="Linl14" title='<%#Eval("Title") %>'>
                                                                        <%# Convert.ToBoolean(Eval("IsCommend")) ? "<font color='red'>[精]</font>" : "" %>
                                                                        <%#StrFormat.CutStringByNum(Eval("Title"),30*2)%>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="50%" Height="22px" BorderWidth="0px" />
                                                                <ControlStyle CssClass="f14black list_xia2" />
                                                                <HeaderStyle CssClass="list_xia2" BorderWidth="0px" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="回答数">
                                                                <ItemTemplate>
                                                                    <%#Eval("Replys")%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="11%" HorizontalAlign="Center" CssClass="list_xia2" BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="审核状态">
                                                                <ItemTemplate>
                                                                    <%# shzt(Eval("Auditing"))%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" Font-Bold="True"
                                                                    BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle BorderWidth="0px" CssClass="list_xia2" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="状态">
                                                                <ItemTemplate>
                                                                    <img src='images/State_<%#Eval("State") %>.gif' width="16" height="16" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" Font-Bold="True"
                                                                    BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="提问时间">
                                                                <ItemTemplate>
                                                                    <%# Eval("AskTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="19%" CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                                <ControlStyle CssClass="list_xia2" />
                                                                <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="litContent1" runat="server"></asp:Label>
                                                    <table width="98%" border="0" align="center" cellpadding="1" cellspacing="0">
                                                        <tr>
                                                            <td bgcolor="" style="height: 1px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                                                    ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center" CssClass="Link_Xia">
                                                                </webdiyer:AspNetPager>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <uc2:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
