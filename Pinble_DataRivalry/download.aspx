<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="Pinble_DataRivalry.download1" %>

<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="keywords" content='彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码' />
    <meta name="description" content='拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。' />
    <meta name="author" content='拼搏在线彩神通软件 www.pinble.com' />
    <meta name="robots" content="all" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <title>大底比拼 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <style type="text/css">
        .ball-0
        {
            height: 20px;
            width: 20px;
            cursor: pointer;
        }
        .ball-0 span
        {
            float: left;
            width: 24px;
            height: 24px;
            line-height: 19px;
            margin: 3px 4px 3px 4px;
            text-align: center;
            font-size: 10px;
            cursor: pointer;
        }
        .rb
        {
            background: url(../images/ball-area.gif) -80px 0 no-repeat;
            color: #fff;
            font-weight: bold;
        }
        .fun
        {
            background: url(../images/ball-area.gif) -80px 0 no-repeat;
            color: #fff;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
        <uc1:logion1 ID="logion11" runat="server" />
    </div>
    <%--    <div class="zanneiy_top_B">
        
        <uc4:adv ID="adv1" runat="server" />
        
    </div>--%>
    <div class="zanneiy_top_C">
        <uc3:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj">
                    <div class="all">
                        <div class="tabtype" style="margin-top: 10px;">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lbtn_dx" runat="server" PostBackUrl="~/download.aspx?id=dx">3D单选</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_zx" runat="server" PostBackUrl="~/download.aspx?id=zx">3D组选</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_p" runat="server" PostBackUrl="~/download.aspx?id=p">排三单选</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_pz" runat="server" PostBackUrl="~/download.aspx?id=pz">排三组选</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="ssq-expert-title">
                            <p class="title-text title-text-l">
                                <asp:Label ID="lab_lname" runat="server" Text="Label">大底</asp:Label>汇总</p>
                            <div class="ssq-check" style="float: right; margin-right: 20px;">
                             <div id="Radio" runat="server" style="float:left">
                                <asp:Button ID="Button1" runat="server" CssClass="seach-button" Width="60px" Text="850-899注" 
                                    onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" 
                                    runat="server" CssClass="seach-button" Width="60px" Text="600-800注" 
                                    onclick="Button2_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" 
                                    runat="server" CssClass="seach-button" Width="60px" Text="200-600注" 
                                    onclick="Button3_Click" />&nbsp;&nbsp;&nbsp;
                            </div>
                            <div id="Group" runat="server" style="float:left" >
                                <asp:Button ID="Button4" runat="server" CssClass="seach-button" Width="60px" Text="90-110注" 
                                    onclick="Button4_Click" />&nbsp;&nbsp;&nbsp;
                            </div>     
                            <asp:Button ID="btn_new" runat="server" Text="最新期" CssClass="seach-button" 
                                    onclick="btn_new_Click" />
                             &nbsp;&nbsp;&nbsp;
                               <%-- 第
                                <asp:DropDownList ID="ddl_issue" runat="server" AppendDataBoundItems="True" 
                                    onselectedindexchanged="ddl_issue_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                期--%>
                                最小 : <asp:TextBox ID="txt_Least" runat="server" Width="45px" BorderColor="Black"></asp:TextBox> 注 -- 最大 : <asp:TextBox ID="txt_max"
                                    runat="server" Width="45px" BorderColor="Black"></asp:TextBox> 注&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="txt_issue" style="border: 1px solid; height: 20px" type="text" title="请输入期号或是会员名" runat="server" />
                                    
                                    <asp:Button ID="Search" runat="server" CssClass="seach-button" Text="搜索" 
                                        onclick="Search_Click" />
                            </div>
                        </div>
                        <div id="d_tab">
                            <table class="ssq-expert-charts">
                                <asp:Repeater ID="rep_download" runat="server">
                                    <HeaderTemplate>
                                        <tr class="back-color color-blue">
                                            <td>
                                                序号
                                            </td>
                                            <td>
                                                会员名
                                            </td>
                                            <td>
                                                彩种
                                            </td>
                                            <td>
                                                期号
                                            </td>
                                            <td>
                                                大底名称
                                            </td>
                                            <td>
                                                大底注数
                                            </td>
                                            <td>
                                                大底类型
                                            </td>
                                            <td>
                                                中单
                                            </td>
                                            <td>
                                                中组
                                            </td>
                                            <td>
                                                中2位
                                            </td>
                                            <td>
                                                中1位
                                            </td>
                                            <td>
                                                中0位
                                            </td>
                                            <td>
                                                下载
                                            </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                            </td>
                                            <td>
                                                <a href="download.aspx?para=<%# Eval("F_username")%>">
                                                    <%# Eval("F_username")%></a>
                                            </td>
                                            <td>
                                                
                                                    <%# Convert.ToInt32(Eval("F_lottery")) == 1 ? "3D" : "P3"%>
                                            </td>
                                            <td>
                                                <a href="download.aspx?para=<%# Eval("F_Period")%>">
                                                    <%# Eval("F_Period")%></a>
                                            </td>
                                            <td>
                                                <%# Eval("F_FileName").ToString()+".txt"%>
                                            </td>
                                            <td>
                                                
                                                    <%# Eval("F_FileNum") %>
                                            </td>
                                            <td>
                                                
                                                    <%# Convert.ToInt32(Eval("F_SingleGroup"))==1 ? "单选" : "组选" %>
                                            </td>
                                            <td>
                                                <%# Eval("Rt_Single")%>
                                            </td>
                                            <td>
                                                <%# Eval("Rt_Group")%>
                                            </td>
                                            <td>
                                                <%# Eval("Rt_two") %>
                                            </td>
                                            <td>
                                                <%# Eval("Rt_one") %>
                                            </td>
                                            <td>
                                                <%# Eval("Rt_zero") %>
                                            </td>
                                            <td>
<%--                                                <asp:LinkButton ID="lb_download" runat="server" CommandArgument='<%# Eval("F_drID") %>'
                                                    OnCommand="lb_download_Command" OnClientClick="return confirm('是否下载会员大底？')">下载</asp:LinkButton>--%>
                                                   <asp:LinkButton ID="lb_download" runat="server" PostBackUrl='<%# "PageDownLoad.aspx?id="+Eval("F_drID") %>' OnClientClick="return confirm('是否下载会员大底？')">下载</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <!--分页信息部分-->
                        <div class="pageNav">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                            CustomInfoSectionWidth="50%" HorizontalAlign="Center">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="yny_neirong_C">
            </div>
        </div>
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
            <div class="footer" style="clear: both;">
                <uc2:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
