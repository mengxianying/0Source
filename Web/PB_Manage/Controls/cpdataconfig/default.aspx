<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.cpdataconfig._default" %>

<html>
<head runat="server">
    <title>开奖数据首页</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/StyleCss.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
 <%--           <table width='100%' border="0" cellpadding="0" cellspacing="0" align="center">
                <tr bgcolor="#F1F3F5">
                    <td height="27" align="center" class="forumRow">
                        请点击上面菜单中的彩票名称，选择你所要管理的彩票。彩票名称颜色含义：<font color="#ff0000">红色</font>—未录入 <font color="#0000ff">
                            蓝色</font>—刚录入 黑色—已录入</td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="1" cellpadding="0" width="100%" align="center" bgcolor="#b6d9ff"
                            border="0">
                            <tr>
                                <td headers="20" background="http://www.pinble.com/pbman/images/cpdata_bt.gif" bgcolor="#ffffff"
                                    colspan="2">
                                    <table height="20" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="center">
                                                <span class="STYLE25 STYLE49 STYLE51"><strong>各类彩票的开奖日期</strong></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table cellspacing="1" cellpadding="0" width="100%" bgcolor="#999999" border="0">
                                        <tr>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期一</b>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期二</b>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期三</b>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期四</b>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期五</b>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期六</b>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE" align="center">
                                                <b>星期日</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">福彩3D</font></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">双色球</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">双色球</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">双色球</font></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">七乐彩</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">七乐彩</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">七乐彩</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">排列三/五</font></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">七星彩</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">七星彩</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">七星彩</font></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">超级大乐透</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#dddddd"></font>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">超级大乐透</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#dddddd"></font>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#dddddd"></font>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">超级大乐透</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#dddddd"></font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#ffffff">
                                                <div class="STYLE1" align="center">
                                                    <font color="#0000ff">体彩22选5</font></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">体彩29选7</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">体彩29选7</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div class="STYLE1" align="center">
                                                    <font color="#cc33cc">体彩29选7</font></div>
                                            </td>
                                            <td width="14%" bgcolor="#EEEEEE">
                                                <div align="center">
                                                    <span class="STYLE25"><span class="STYLE39"></span></span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="border: solid 3px #FF6666; border-top: solid 5px #FF6666;
                                    padding: 0px 0px 0px 0px">
                                    <div style="padding-top: 6px; height: 28px;" align="center">
                                        <span class="fs14 b"><strong>各类彩票开奖信息发布渠道及发布时间</strong> </span>
                                    </div>
                                    <table cellspacing="1" cellpadding="0" width="95%" align="center" bgcolor="#999999"
                                        border="0">
                                        <tbody>
                                            <tr align="middle" bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#eeeeee">
                                                    <strong>开 奖 彩 票</strong></td>
                                                <td width="37%" height="20" bgcolor="#eeeeee">
                                                    <strong>媒 体 及 发 布 渠 道</strong></td>
                                                <td width="43%" bgcolor="#eeeeee">
                                                    <strong>发 布 时 间</strong></td>
                                            </tr>
                                            <tr bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#FFFFFF">
                                                    七乐彩</td>
                                                <td width="37%" bgcolor="#FFFFFF">
                                                    中国教育电视台一套</td>
                                                <td width="43%" bgcolor="#FFFFFF">
                                                    每周一、三、五晚上20：45直播</td>
                                            </tr>
                                            <tr bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#EEEEEE">
                                                    双色球</td>
                                                <td width="37%" bgcolor="#EEEEEE">
                                                    中国教育电视台一套</td>
                                                <td width="43%" bgcolor="#EEEEEE">
                                                    每周二、四、日晚上20：45直播</td>
                                            </tr>
                                            <tr bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#FFFFFF">
                                                    3D试机号</td>
                                                <td width="37%" bgcolor="#FFFFFF">
                                                    北京福彩论坛 <a href="http://bbs.bwlc.net/" target="_blank">http://bbs.bwlc.net/</a><br>
                                                    中国福利彩票3D <a href="http://www.3dlotto.net/" target="_blank">http://www.3dlotto.net/</a></td>
                                                <td width="43%" bgcolor="#FFFFFF">
                                                    每天晚上18：26</td>
                                            </tr>
                                            <tr bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#EEEEEE">
                                                    3D开奖号</td>
                                                <td width="37%" bgcolor="#EEEEEE">
                                                    中央人民广播电台一套</td>
                                                <td width="43%" bgcolor="#EEEEEE">
                                                    每天晚上20：30-20：33向全国直播</td>
                                            </tr>
                                            <tr bgcolor="#EEEEEE">
                                                <td width="20%" bgcolor="#FFFFFF">
                                                    P3P5</td>
                                                <td width="37%" bgcolor="#FFFFFF">
                                                    中国体彩网 <a href="http://www.lottery.gov.cn/" target="_blank">http://www.lottery.gov.cn/</a><br>
                                                    湖南体彩网 <a href="http://www.hnticai.com/" target="_blank">http://www.hnticai.com/</a><br>
                                                    <a href="http://bbs.hnticai.com/forumdisplay.php?fid=6" target="_blank">http://bbs.hnticai.com/forumdisplay.php?fid=6</a></td>
                                                <td width="43%" bgcolor="#FFFFFF">
                                                    中国体彩网 中央人民广播电台一套21:00</td>
                                            </tr>
                                            <tr bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#EEEEEE">
                                                    七星彩</td>
                                                <td width="37%" bgcolor="#EEEEEE">
                                                    中国体彩网 <a href="http://www.lottery.gov.cn/" target="_blank">http://www.lottery.gov.cn/</a></td>
                                                <td width="43%" bgcolor="#EEEEEE">
                                                    中国体彩网</td>
                                            </tr>
                                            <tr bgcolor="#EEEEEE">
                                                <td width="20%" bgcolor="#FFFFFF">
                                                    超级大乐透</td>
                                                <td width="37%" bgcolor="#FFFFFF">
                                                    中国体彩网 <a href="http://www.lottery.gov.cn/" target="_blank">http://www.lottery.gov.cn/</a></td>
                                                <td width="43%" bgcolor="#FFFFFF">
                                                    中国体彩网</td>
                                            </tr>
                                            <tr bgcolor="#fff7ec">
                                                <td width="20%" bgcolor="#EEEEEE">
                                                    体彩22选5</td>
                                                <td width="37%" bgcolor="#EEEEEE">
                                                    中国体彩网 <a href="http://www.lottery.gov.cn/" target="_blank">http://www.lottery.gov.cn/</a></td>
                                                <td width="43%" bgcolor="#EEEEEE">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#EEEEEE">
                                                <td width="20%" bgcolor="#FFFFFF">
                                                    体彩29选7</td>
                                                <td width="37%" bgcolor="#FFFFFF">
                                                    中国体彩网 <a href="http://www.lottery.gov.cn/" target="_blank">http://www.lottery.gov.cn/</a></td>
                                                <td width="43%" bgcolor="#FFFFFF">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div style="padding-top: 3px; height: 20px;" align="right">
                                        更新日期：2006年9月11日</div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>--%>
        </div>
    </form>
</body>
</html>
