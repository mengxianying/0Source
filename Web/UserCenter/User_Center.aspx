<%@ Page Language="C#" AutoEventWireup="true" Codebehind="User_Center.aspx.cs" Inherits="Pbzx.Web.User_Center" %>

<%@ Register Src="../Contorls/Uc_shopping.ascx" TagName="Uc_shopping" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户资料中心_拼搏在线彩神通软件 </title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>
    <script language="JavaScript" type="text/javascript"> 
        /*iframe宽高自适应*/
    function TuneHeight(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  
        var subWeb=document.frames?document.frames[fm_name].document:frm.contentDocument;  
        if(frm != null && subWeb != null)
        { 
         frm.style.height = (parseInt(window.screen.availHeight)-90)+"px";
            // subWeb.documentElement.scrollHeight = frm.style.height +"px"; 
            //如需自适应宽高,去除下行的“//”注释即可 
         frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
        }  
    }    

    function showmenu(strID){ 
        var i; 
        for(i=0;i<=1;i++){ 
            var lay; 
            lay = eval('lay' + i); 
            if (lay.style.display=="block" && lay!=eval(strID)){ 
                lay.style.display = "none"; 
            } 
        } 
        if (strID.style.display=="none"){ 
            strID.style.display = "block"; 
        }else{ 
            strID.style.display = "none"; 
        } 
    } 
    function getParameter(param)
    {
        var query = window.location.search;
        var iLen = param.length;
        var iStart = query.indexOf(param);
        if (iStart == -1)
        {
          return "";
        }
        else
        {
            iStart += iLen + 1;
            var iEnd = query.indexOf("&", iStart);
            if (iEnd == -1)
            {
                return query.substring(iStart);
            }
            else
            {
                return query.substring(iStart, iEnd);
            }
        }
    }
    function GetThisSrc()
     {
        var temp = getParameter("myUrl");
        if(temp == "")
        {
            document.getElementById("US_fram").src = "userManage.aspx"; 
        }
        else
        {
             document.getElementById("US_fram").src = temp;
        }
     }
    </script>

</head>
<body onload="GetThisSrc();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="19%" height="74" background="../images/web/UC_topbg.jpg">
                        <img src="../images/web/UC_log.jpg" width="280" height="74" /></td>
                    <td width="81%" valign="top" background="../images/web/UC_topbg.jpg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                            <tr>
                                <td align="right" valign="bottom" class="uc_topmenuz">
                                    <a href="/." class="uc_topmenu" target="_blank">首页</a>│<a href="/Bulletin.htm" class="uc_topmenu"
                                        target="_blank">网站公告</a>│<a href="/News.htm" class="uc_topmenu" target="_blank">新闻资讯</a>│<a
                                            href="/Soft.aspx" class="uc_topmenu" target="_blank">软件商城</a>│<a href="/SoftwarePrices.htm"
                                                class="uc_topmenu" target="_blank">注册购买</a>│<a href="/Source.aspx" class="uc_topmenu"
                                                    target="_blank">资源下载</a>│<a href="/Lottery.htm" class="uc_topmenu" target="_blank">开奖信息</a>│<a
                                                        href="/graph.htm" class="uc_topmenu" target="_blank">数据图表</a>│<a href="/School.htm"
                                                            class="uc_topmenu" target="_blank">软件学院</a>│ <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>"
                                                                id="a_Ask" class="uc_topmenu" target="_blank">拼搏吧</a>
                                    │ <a href="/Broker.aspx" id="a1" class="uc_topmenu" target="_blank">经纪人</a>│<a href="http://bbs.pinble.com/" class="uc_topmenu"
                                            target="_blank">拼搏论坛</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 50%;" background="../images/web/UC_loginbg.jpg" height="30">
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td width="4%" align="right" style="height: 20px">
                                    <img src="../images/web/UC_loginli.gif" width="18" height="20" /></td>
                                <td width="96%" class="uc_topmenuz" style="font-weight: bold;">
                                    &nbsp;用户名：<asp:Label ID="lblUName" runat="server" Text=""></asp:Label>
                                    &nbsp;帐户余额：<asp:Label ID="lbpinble" runat="server"></asp:Label>
                                    元 &nbsp;<%--金币：<asp:Label ID="lbjinbi" runat="server"></asp:Label>金币--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" background="../images/web/UC_loginbg.jpg">
                        <uc1:Uc_shopping ID="Uc_shopping1" runat="server" />
                    </td>
                    <td width="45%" background="../images/web/UC_loginbg.jpg" class="uc_topmenuz" align="right">
                        <asp:ImageButton ID="aLoginOut" runat="server" ImageUrl="~/images/web/UC_bt1.gif"
                            OnClick="aLoginOut_Click" ImageAlign="AbsBottom" />│服务热线:010-62132803&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" id="tdM">
                        <table width="1002" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="18%" valign="top" class="uc_lbg" height="438">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="27" align="center" background="../images/web/UC_buyBG.jpg">
                                                <a href="User_Deposit.aspx" target="US_fram" class="uc_linkBlack" onclick="">
                                                    <img src="../Images/Web/UC_bt2.png" align="middle" border="0" /></a>&nbsp;<font size="-2"
                                                        color="#333333">│</font>&nbsp;<a href="Withdraw.aspx" class="uc_linkBlack" target="US_fram"><img
                                                            src="../Images/Web/UC_bt3.png" align="middle" border="0" /></a></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <a href="userManage.aspx" target="US_fram" style="cursor: pointer;" class="uc_lmu">我的首页&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center" style="height: 19px">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink" style="height: 19px">
                                                            <a href="javascript:showmenu(lay1)" class="uc_lmu" style="cursor: pointer;">我的参与&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay1' style="display: none;">
                                        <tr>
                                            <td>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="Myask.aspx" target="US_fram" class="uc_linkBlack" style="cursor: pointer;">
                                                                拼 搏 吧</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay0' style="display: none;">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="MyBroker" runat="server"
                                        visible="false">
                                        <tr>
                                            <td background="../images/web/UC_Lbg.jpg" style="height: 30px">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <a href="My_broker.aspx" target="US_fram" class="uc_lmu" style="cursor: pointer;">我的经纪</a>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="MyDaili" runat="server"
                                        visible="false">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <a href="javascript:showmenu(lay3)" class="uc_lmu" style="cursor: pointer;">我的代理&nbsp;</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay3' style="display: none;">
                                        <tr>
                                            <td>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <%--<tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="Delegate.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                管理代理交易</a>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="Delegate_change.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                修改代理信息</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbQQManager" runat="server">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center" style="height: 19px">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink" style="height: 19px">
                                                            <a href="QQ_RecordManager.aspx" target="US_fram" class="uc_lmu" style="cursor: pointer;">
                                                                QQ管理&nbsp; </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center" style="height: 19px">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink" style="height: 19px">
                                                            <a href="OrderList.aspx" target="US_fram" class="uc_lmu" style="cursor: pointer;">我的订单&nbsp;
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <%--<a href="Money_Log.aspx" style="cursor: pointer;" target="US_fram" class="uc_lmu">--%>
                                                            <a href="javascript:showmenu(lay5)" class="uc_lmu" style="cursor: pointer;">我的账户&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay5' style="display: none;">
                                        <tr>
                                            <td>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="Money_Log.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                充值/取款</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="MyTradeInfo.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                我的交易记录</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <a href="LyBookDisp.aspx" target="US_fram" class="uc_lmu" style="cursor: pointer;">我的留言&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <%--<a href="Money_Log.aspx" style="cursor: pointer;" target="US_fram" class="uc_lmu">--%>
                                                            <a href="javascript:showmenu(lay6)" class="uc_lmu" style="cursor: pointer;">我的消息&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay6' style="display: none;">
                                        <tr>
                                            <td>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="UsersMs.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                收信箱</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="UsersMsSend.aspx?isSend=0" target="US_fram" class="uc_linkBlack" onclick=""
                                                                style="cursor: pointer;">草稿箱</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="UsersMsSend.aspx?isSend=1" target="US_fram" class="uc_linkBlack" onclick=""
                                                                style="cursor: pointer;">已发送消息</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="UsersMsDel.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                废信箱</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="#" class="uc_linkBlack" onclick="window.open('MsgDetail.aspx?action=new', '', 'height:550px,width:600px,left:400px,top:300px,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');"
                                                                style="cursor: pointer;">撰写短消息</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <a href="javascript:showmenu(lay2)" class="uc_lmu" style="cursor: pointer;">我的资料&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay2' style="display: none;">
                                        <tr>
                                            <td>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="ChangePWD.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                修改登录密码</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="PWD_Ask.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                <%=lblText.Trim()%>登录密保</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="User_Info.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                真实信息管理</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="Bank_Info.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                银行账号管理</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="ChangePWD_buy.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                修改交易密码</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="PWD_BuyAsk.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                修改交易密保</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                   <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="30" background="../images/web/UC_Lbg.jpg">
                                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="13%" align="center">
                                                            <img src="../images/web/UC_lli1.jpg" width="9" height="9" /></td>
                                                        <td width="87%" class="uc_lmulink">
                                                            <a href="javascript:showmenu(lay7)" class="uc_lmu" style="cursor: pointer;">彩票超市&nbsp;</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" border="0" cellspacing="0" bgcolor="#E7F4FF"
                                        id='lay7' style="display: none;">
                                        <tr>
                                            <td>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="<%=Pbzx.Common.WebInit.market.WebUrl %>admin/ItemEnactment.aspx" target="US_fram" class="uc_linkBlack"
                                                                onclick="" style="cursor: pointer;">项目设定</a></td>
                                                    </tr>
                                                </table>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="<%=Pbzx.Common.WebInit.market.WebUrl %>admin/Market_Itemissuance.aspx" target="US_fram" class="uc_linkBlack"
                                                                onclick="" style="cursor: pointer;">单期内容发布</a></td>
                                                    </tr>
                                                </table>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="<%=Pbzx.Common.WebInit.market.WebUrl %>admin/" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                项目类别申请</a></td>
                                                    </tr>
                                                </table>
                                                 <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="<%=Pbzx.Common.WebInit.market.WebUrl %>admin/Market_ItemManage.aspx" target="US_fram" class="uc_linkBlack"
                                                                onclick="" style="cursor: pointer;">项目管理</a></td>
                                                    </tr>
                                                </table>
                                                <table width="150" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr>
                                                        <td class="uc_menu_pd">
                                                            <a href="<%=Pbzx.Common.WebInit.market.WebUrl %>admin/BuyItemList.aspx" target="US_fram" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                                                购买记录</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>--%>
                                    
                                    <table width="92%" border="0" align="center" cellpadding="4" cellspacing="0" class="uc_MT">
                                        <tr>
                                            <td style="height: 32px">
                                                <img src="../images/web/UC_help.jpg" width="89" height="22" /></td>
                                        </tr>
                                    </table>
                                    <table width="159" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MB">
                                        <tr>
                                            <td>
                                                <img src="../images/web/UC_helpbg1.jpg" width="159" height="5" /></td>
                                        </tr>
                                        <tr>
                                            <td background="../images/web/UC_helpbg2.jpg">
                                                <table width="95%" border="0" align="right" cellpadding="1" cellspacing="0">
                                                    <tr>
                                                        <td align="left">
                                                            客服电话：
                                                            <br />
                                                            010-62132803<br />
                                                            客服及保障邮箱：<br />
                                                            service@pinble.com<br />
                                                            意见及投诉邮箱：<br />
                                                            webmaster@pinble.com</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images/web/UC_helpbg3.jpg" width="159" height="5" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="82%" valign="top">
                                    <iframe src="userManage.aspx" onload="TuneHeight('US_fram','US_fram')" name="US_fram"
                                        id="US_fram" width="100%" marginwidth="0" marginheight="0" frameborder="0" scrolling="no">
                                    </iframe>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="uc_MT">
                <tr>
                    <td height="33" align="center" background="../images/web/UC_btmbg.jpg" class="uc_topmenuz">
                        拼搏在线（北京）科技发展有限公司 版权所有@2004-<%=DateTime.Now.Year.ToString()%>
                        京ICP证050806号</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
