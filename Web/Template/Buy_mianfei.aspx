<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_mianfei.aspx.cs" Inherits="Pbzx.Web.Buy_mianfei" %>

<%@ Register Src="../Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>免费使用_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/buy.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <!--主体部分--->
        <div id="soft" class="bodyw MT">
            <!--左边--->
            <div id="Y_lw1">
                <uc3:Buy_left ID="Buy_left1" runat="server" />
            </div>
            <!--右边--->
            <div id="Y_rw1">
                <div class="Y_wei">
                    当前位置：<a href="/">拼搏在线彩神通软件</a> >> <a href="/SoftwarePrices.htm">注册购买</a> >> 免费使用
                </div>
                <div class="Y_box Y_r1 MT">
                    <div class="title">
                        <p>
                            <a href="#"><span>免费使用</span></a></p>
                    </div>
                    <div class="content">
                        <div>
                            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="30" align="center" valign="bottom" class="Y_xia">
                                        免费使用</td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                            </table>
                            <table width="96%" border="0" align="center" cellpadding="15" cellspacing="1" bgcolor="#ECECEC">
                                <tr>
                                    <td align="left" bgcolor="#FCFCFC">
                                        &nbsp;&nbsp;&nbsp;&nbsp;1、第一次使用『彩神通』软件（必须能够上网），选择“免费试用”可以免费试用完整的一周时间（星期一至星期日）。不需要输入论坛名、密码即可使用。如果“公测”时使用过『彩神通』软件的用户，不能选择“网络注册”方式登录，直接选择“免费试用”即可。<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;2、在“免费试用”开始后，对于没有在<a href="http://bbs.pinble.com/" target="_blank">拼搏在线彩票论坛</a>注册论坛名字的用户，首先在论坛注册一个用户名，在本周内（星期一至星期日）发贴、跟贴数量和发贴、跟贴天数同时满足下面“发贴标准”的用户，才能在下周（星期一至星期日）继续免费使用『彩神通』软件，否则免费试用到期后只能购买软件才能继续使用软件。<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;3、“免费试用”到期后，只要上周（星期一至星期日）的发贴、跟贴数量和发贴、跟贴天数等指标达到要求，可以选择“网络注册”方式登录，输入论坛用户名和密码即可使用软件。即任何时候只要符合下面的要求，都可以通过发贴来免费使用『彩神通』软件。<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;4、发贴数量和跟贴数量说明如下：<br />
                                        <span class="red"><b>【普通用户】发贴信息说明</b></span>
                                        <asp:Repeater ID="rptPUt" runat="server">
                                            <HeaderTemplate>
                                                <table width="99%" border="1" height="53" cellspacing="0" style="border-collapse: collapse;
                                                    margin-bottom: 0pt;" bordercolor="#C0C0C0" cellpadding="0">
                                                    <tr bgcolor="#0000ff">
                                                        <th width="157" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            软件名称
                                                        </th>
                                                        <th width="147" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            论坛发贴版面</th>
                                                        <th width="99" height="21" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            发贴数</th>
                                                        <th width="89" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            跟贴数</th>
                                                        <th width="98" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            精华贴数</th>
                                                        <th width="128" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            发贴跟贴天数</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="MsoNormal">
                                                    <td width="157" height="22" align="center">
                                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                                    </td>
                                                    <td class="blue">
                                                        &nbsp;<%# showBoards(Eval("Boards"))%></td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinTopics"),7)%>贴/周</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinAnncounts"),7)%>贴/周</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinBests"),7)%>贴/周</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinDays"),7)%>天/周</td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table></FooterTemplate>
                                        </asp:Repeater>
                                        <br />
                                        <span class="red"><b>【贵宾用户】发贴信息说明</b></span>
                                        <asp:Repeater ID="rptGuiB" runat="server">
                                            <HeaderTemplate>
                                                <table width="99%" border="1" height="53" cellspacing="0" style="border-collapse: collapse;
                                                    margin-bottom: 0pt;" bordercolor="#C0C0C0" cellpadding="0">
                                                    <tr bgcolor="#0000ff">
                                                        <th width="157" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            软件名称
                                                        </th>
                                                        <th width="147" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            论坛发贴版面</th>
                                                        <th width="99" height="21" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            发贴数</th>
                                                        <th width="89" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            跟贴数</th>
                                                        <th width="98" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            精华贴数</th>
                                                        <th width="128" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            发贴跟贴天数</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="MsoNormal">
                                                    <td width="157" height="22" align="center">
                                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                                    </td>
                                                    <td class="blue">
                                                        &nbsp;<%# showBoards(Eval("Boards"))%></td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinTopics"),4)%>贴/周</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinAnncounts"),4)%>贴/周</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinBests"),4)%>贴/周</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinDays"),4)%>天/周</td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table></FooterTemplate>
                                        </asp:Repeater>
                                        <span class="red">备注：</span><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;1、遵守论坛版面规则，请勿乱发灌水贴及乱发与预测无关的帖子，否则每被删除1个主贴将被扣2个主贴数；每被删除1个跟贴将被扣3个跟贴数。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;2、每获得精华主贴1次将增加2个主贴数；每获得精华跟贴1次将增加3个跟贴数。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;3、发贴、跟贴数量、精华贴数和发贴、跟贴天数必须同时满足“发贴标准”的要求，任何一个指标达不到要求都将不能继续使用软件。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;4、发贴和跟帖日期必须至少分布在上面指定的“发贴跟贴天数”以上，如果一周（星期一至星期日）的发贴和跟贴日期分布在上面指定的“发贴跟贴天数”以下，即使帖子数量符合要求，下周（星期一至星期日）也将不能继续使用软件。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;5、发贴跟贴天数是指的所有发贴和跟贴的分布天数，不是指的单独的发贴天数或跟贴天数。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;6、一个论坛用户名只能一个人使用，用户名的密码请自己妥善保管好，请勿把论坛用户名和密码告诉其他人，否则因此产生的一切后果由该论坛用户名持有人负责。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;7、发帖和跟帖数量每周系统自动统计一次，每周（星期一至星期日）发帖、跟帖数量和发贴跟贴天数都将影响到下周（星期一至星期日）是否能正常使用软件。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;8、表格中设置的数量标准在以后的实际执行过程中可能会有变更，以网站最新公布的数据为准。
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;9、其他相关的说明请看：购买说明 注册说明 疑难解答 发贴查询。
                                    </td>
                                </tr>
                            </table>
                            <uc4:Uc_BuyHmenn ID="Uc_BuyHmenn1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
