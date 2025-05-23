<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pinble_Chipped.Default" %>

<%@ Register Src="Contorls/login.ascx" TagName="login" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>合买代购</title>
    <link rel="stylesheet" type="text/css" href="Css/global.css" />
    <link rel="stylesheet" type="text/css" href="Css/delault.css" />
    <link type="text/css" rel="Stylesheet" href="Css/Title.css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../WebChipped.asmx/HRanking",
                data: "{LName:'3'}",
                dataType: "json",
                success: function (data) {
                    //获取的表格                         
                    $("#tab").html(HtmlDecode(data));
                }
            });
        });
        //html解码
        function HtmlDecode(text) {
            return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="doc1" class="cp_3d">
        <!--头部开始-->
        <div class="header">
            <div class="logo">
            </div>
            <div class="login_info">
                <uc1:login ID="Login1" runat="server" />
            </div>
            <div class="nav">
                <dl class="b-top-nav">
                </dl>
            </div>
        </div>
        <!--二级目录部分-->
        <!--二级目录结束部分-->
        <div class="i_main">
            <div class="main_left">
                <div class="m-box by-today">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <h2>
                                彩种截止时间</h2>
                        </div>
                    </div>
                    <div class="bd">
                        <div class="by-top">
                            <span class="by-t-n">彩种</span><span class="by-t-d">距离投注截止还有</span></div>
                        <ul class="by-list">
                            <li>
                                <dl class="sfc">
                                    <dt><a class="cpHref" href="#" target="_blank"></a>
                                        <asp:Label ID="Label1" runat="server" Text="双色球"></asp:Label>
                                    </dt>
                                    <dd>
                                        单注最高奖金 500万元</dd>
                                </dl>
                                <span class="by-time by-now"><i class="m-mkt m-mkt-tm"></i><span id="_lefttime" style="color: Red">
                                </span></span>
                                <script type="text/javascript">
                                    function _fresh() {

                                        //结束时间取配置文件中的数据                                    
                                        var endtime = new Date("<%=Pbzx.Common.Method.GetSSQDateTime.ToString() %>".replace(/-/g, "/"));

                                        var nowtime = new Date();
                                        var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                        if (leftsecond < 0) { leftsecond = 0; }
                                        __d = parseInt(leftsecond / 3600 / 24);
                                        __h = parseInt((leftsecond / 3600) % 24);
                                        __m = parseInt((leftsecond / 60) % 24);
                                        __s = parseInt(leftsecond % 60);
                                        __all = __d + "天" + __h + "小时" + __m + "分" + __s + "秒";
                                        document.getElementById("_lefttime").innerHTML = __all;

                                    }
                                    _fresh()
                                    setInterval(_fresh, 1000);
                                </script>
                            </li>
                            <li>
                                <dl class="sfc">
                                    <dt><a class="cpHref" href="#" target="_blank"></a>
                                        <asp:Label ID="Label2" runat="server" Text="3D"></asp:Label></dt>
                                    <dd>
                                        单注最高奖金 1000元</dd>
                                </dl>
                                <span class="by-time by-now"><i class="m-mkt m-mkt-tm"></i><span id="_lefttime1"
                                    style="color: Red"></span></span>
                                <%--倒计时器--%>
                                <script type="text/javascript">
                                    function _fresh() {
                                        //结束时间取配置文件中的数据                                    
                                        var endtime = new Date("<%=Pbzx.Common.Method.GetFCDateTime.ToString() %>".replace(/-/g, "/"));

                                        var nowtime = new Date();
                                        var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                        if (leftsecond < 0) { leftsecond = 0; }
                                        __d = parseInt(leftsecond / 3600 / 24);
                                        __h = parseInt((leftsecond / 3600) % 24);
                                        __m = parseInt((leftsecond / 60) % 24);
                                        __s = parseInt(leftsecond % 60);
                                        __all = __d + "天" + __h + "小时" + __m + "分" + __s + "秒";
                                        document.getElementById("_lefttime1").innerHTML = __all;
                                    }
                                    _fresh()
                                    setInterval(_fresh, 1000);
                                </script>
                            </li>
                            <li>
                                <dl class="sfc">
                                    <dt><a class="cpHref" href="#" target="_blank"></a>
                                        <asp:Label ID="Label3" runat="server" Text="大乐透"></asp:Label></dt>
                                    <dd>
                                        单注最高奖金 500万元</dd>
                                </dl>
                                <span class="by-time by-now"><i class="m-mkt m-mkt-tm"></i><span id="_lefttime2"
                                    style="color: Red"></span></span>
                                <script type="text/javascript">
                                    function _fresh() {

                                        //结束时间取配置文件中的数据                                    
                                        var endtime = new Date("<%=Pbzx.Common.Method.GetTCDLTDateTime.ToString() %>".replace(/-/g, "/"));

                                        var nowtime = new Date();
                                        var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                        if (leftsecond < 0) { leftsecond = 0; }
                                        __d = parseInt(leftsecond / 3600 / 24);
                                        __h = parseInt((leftsecond / 3600) % 24);
                                        __m = parseInt((leftsecond / 60) % 24);
                                        __s = parseInt(leftsecond % 60);
                                        __all = __d + "天" + __h + "小时" + __m + "分" + __s + "秒";
                                        document.getElementById("_lefttime2").innerHTML = __all;

                                    }
                                    _fresh()
                                    setInterval(_fresh, 1000);
                                </script>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="gd-plan">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <a href="#" title="" id="a1">今日截止方案</a><a href="#" title="" id="a2" class="an_cur">人气合买方案</a></div>
                    </div>
                    <div class="bd">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                            <colgroup>
                                <col width="8%" />
                                <col width="12%" />
                                <col width="15%" />
                                <col width="17%" />
                                <col width="15%" />
                                <col width="20%" />
                                <col width="13%" />
                            </colgroup>
                            <tbody>
                                <asp:Repeater ID="rep_chipped" runat="server" OnItemDataBound="rep_chipped_ItemDataBound1">
                                    <HeaderTemplate>
                                        <tr class="">
                                            <th>
                                                排序
                                            </th>
                                            <th>
                                                发起人
                                            </th>
                                            <th>
                                                彩种
                                            </th>
                                            <th>
                                                跟单人数
                                            </th>
                                            <th>
                                                方案金额
                                            </th>
                                            <th>
                                                方案进度
                                            </th>
                                            <th>
                                                操作
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                            </td>
                                            <td>
                                                <span class="blue">
                                                    <%# Eval("UserName") %></span>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_lottery" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_documentary" runat="server"></asp:Label>人
                                            </td>
                                            <td>
                                                <%# Eval("AtotalMoney")%>元
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_progress" runat="server"></asp:Label><span class="red">(保)</span>
                                            </td>
                                            <td>
                                                <span class="c-f-ok"><a href="#" title="" class="public_Dblue"><b>参与</b></a></span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <tr class="">
                                    <td colspan="7">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="main_right">
                <div class="m-box luck">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <h2>
                                我们的赢家</h2>
                        </div>
                    </div>
                    <div class="bd">
                        <div class="l-win">
                            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="zj_table">
                                <colgroup>
                                    <col width="50%" />
                                    <col width="20%" />
                                    <col width="30%" />
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th colspan="3">
                                            <span>他们正在中奖</span>
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                            <div style="height: 158px; overflow: hidden">
                                <table width="100%" border="0" class="tabled">
                                    <asp:Repeater ID="rep_winning" runat="server">
                                        <HeaderTemplate>
                                            <colgroup>
                                                <col width="40%" />
                                                <col width="30%" />
                                                <col width="30%" />
                                            </colgroup>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <span class="blue"><%# Eval("") %></span>
                                                </td>
                                                <td>
                                                    一天前
                                                </td>
                                                <td>
                                                    <%# Eval("") %>元
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="m-box top-bonus">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <h2>
                                大奖排行</h2>
                            <a href="#" title="大奖排行" class="more" target="_blank">更多</a></div>
                    </div>
                    <div class="bd">
                        <div class="t-b-tabs" id="dj_list_tabs">
                            <a href="#" title="" id="e1" class="tab_cur">胜负彩</a><a href="#" title="" id="e2">双色球</a><a
                                href="#" title="" id="e3">大乐透</a></div>
                        <div class="t-b-con">
                            <div id="r1">
                                <span style="color: #ccc">
                                    <table width="100%" border="0" class="tabled">
                                        <colgroup>
                                            <col width="60%" />
                                            <col width="40%" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                <span class="blue">奥大师的</span>
                                            </td>
                                            <td>
                                                <span class="red">4312312元</span>
                                            </td>
                                        </tr>
                                    </table>
                                </span>
                            </div>
                            <div id="r2" style="display: none;">
                            </div>
                            <div id="r3" style="display: none;">
                                <span style="color: #ccc">正在加载...</span></div>
                            <div id="r4" style="display: none;">
                                <span style="color: #ccc">正在加载...</span></div>
                        </div>
                    </div>
                </div>
                <div class="service kefuPic">
                    <img src="images/121212.png" alt="" title="" /></div>
            </div>
        </div>
        <div id="ft">
        </div>
    </div>
    </form>
</body>
</html>
