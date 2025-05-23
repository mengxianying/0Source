<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker_Info.aspx.cs" Inherits="Pbzx.Web.Broker_Info" %>

<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Broker.ascx" TagName="Broker" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请经纪人 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="经纪人 软件代理 软件经销商 软件推广 软件销售 中国福利彩票 福利彩票 体育彩票 双色球 快乐8 3D彩票 3D试机号 七乐彩 乐透彩票 排列三 排列五 七星彩 超级大乐透 福彩 体彩 开奖 走势图 资讯 社区" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩神通软件www.pinble.com" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/broker.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <div class="bodyw MT">
                <!---左边--->
                <div class="br_l">
                    <uc3:Broker ID="Broker1" runat="server" />
                </div>
                <!---右边--->
                <div class="br_r">
                    <%--   <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><img src="images/web/br_banner.jpg" width="770" height="88" /></td>
    </tr>
  </table>--%>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td background="/Images/Web/br_rbg.jpg" height="27" class="br_rZ">
                                            彩神通经纪人详细介绍
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="4%" align="center" class="br_xia">
                                            <img src="/Images/Web/br_biao.jpg" border="0" vspace="4" /></td>
                                        <td width="96%" align="left" class="br_biao br_xia" valign="bottom">
                                            什么是『彩神通』经纪人？<a name="mao1" id="mao1"></a></td>
                                    </tr>
                                </table>
                                <table width="97%" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;&nbsp;1、中华人民共和国《经纪人管理办法》对经纪人的解释：在经济活动中，为促成他人交易而从事居间、行纪或者代理等经纪行为的公民、法人和其他经济组织。经纪人从事经纪活动所得佣金是合法收入。经纪人完成经纪活动后，有权按照合同约定收取佣金。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2、『彩神通』经纪人是指用户自己通过对『彩神通』系列产品切身运用、实践后的公正评价和良好口碑，自愿从事居间经纪活动，把『彩神通』系列产品推广或引荐给他人，并相应取得合理合法酬劳（“佣金”）的行为。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;3、为了便于体现『彩神通』经纪人的经纪活动价值，『彩神通』经纪人共分八个等级，不同的『彩神通』经纪人等级享受不同的佣金奖励标准。依次是一级经纪人、二级经纪人、三级经纪人、四级经纪人、五级经纪人、六级经纪人、七级经纪人、八级经纪人。
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="4%" align="center" class="br_xia">
                                            <img src="/Images/Web/br_biao.jpg" border="0" vspace="4" /></td>
                                        <td width="96%" align="left" class="br_biao br_xia" valign="bottom">
                                            如何成为『彩神通』经纪人？ <a name="mao2" id="mao2"></a>
                                        </td>
                                    </tr>
                                </table>
                                <table width="97%" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <b>申请条件: </b>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;1、中国境内正规合法的法人或自然人都可以成为『彩神通』经纪人。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2、拼搏在线彩票论坛在任版主、聊管和贵宾等，优先享受直接成为『彩神通』经纪人权利。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;3、拼搏在线的战略合作伙伴用户，请提交申请，经资质确认后享受直接成为『彩神通』经纪人权利。包括国内知名的彩票专家、网站管理员、报社编辑等。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;4、符合以下条件者，可申请加入『彩神通』经纪人。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您已购买了『彩神通』软件专业版的终身用户可申请。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您已购买了『彩神通』软件金额满RMB：1000元的用户可申请。<br />
                                            <b>经纪活动流程：</b><br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;注册网站会员—>提交真实资料—>等待资质审核—>成为『彩神通』经纪人—>用户中心查看我的经纪—>开展软件经纪活动—>获得佣金
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="4%" align="center" class="br_xia">
                                            <img src="/Images/Web/br_biao.jpg" border="0" vspace="4" /></td>
                                        <td width="96%" align="left" class="br_biao br_xia" valign="bottom">
                                            成为『彩神通』经纪人有何好处？<a name="mao3" id="mao3"></a>
                                        </td>
                                    </tr>
                                </table>
                                <table width="97%" border="0" align="center" cellpadding="6" cellspacing="0"  >
                                    <tr>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;&nbsp;1、您可以为用户节省5%软件购买款。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2、您可以至少获得软件购买款的5%佣金奖励，您的经纪级别越高，佣金奖励标准越高。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;3、拼搏在线隆重推出的“软件商城”模式，大量节省您的时间和精力。自助购买方式和系统结算佣金的人性化模式让您在从事经纪活动中的操作更加简单、方便、快捷。
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="4%" align="center" class="br_xia">
                                            <img src="/Images/Web/br_biao.jpg" border="0" vspace="4" /></td>
                                        <td width="96%" align="left" class="br_biao br_xia" valign="bottom">
                                            经纪人购买说明和佣金结算? <a name="mao4" id="A4"></a>
                                        </td>
                                    </tr>
                                </table>
                                <table width="97%" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;&nbsp;一、用户购买软件时，请直接登录“软件商城”在线购买，并注意填写您的『彩神通』经纪推荐人“会员名”。如没有，则不享受优惠。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;二、『彩神通』经纪人购买软件时，请注意在收货人资料中填写用户资料。公司在处理注册软件时将参照此资料注册或邮寄。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;三、『彩神通』经纪人只适用于拼搏在线彩神通软件“软件商城”在线注册购买方式。用户或经纪人直接致电公司购买，不享受任何优惠。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;四、『彩神通』经纪人只适用于“软件商城”在线注册购买方式。用户或经纪人在购买软件时均需全额支付软件价款。应由用户享受的5%优惠，系统会在交易成功后自动返点到“软件商城”登录购买者的帐户里；『彩神通』经纪人代用户购买软件，此优惠将返给经纪人，由经纪人支付给用户，或由经纪人与用户自己协商解决。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;五、佣金结算和考核标准 『彩神通』经纪人的经纪等级和佣金奖励说明（单位：元）<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1、一级经纪人：当您经过申请--审核--成为『彩神通』经纪人后，您已经开始享受“一级经纪人”权利，现在您的佣金奖励标准为软件销售款的5%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2、二级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满2000元后，系统自动默认您成为二级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的7%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3、三级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满5000元者，系统自动默认您成为三级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的10%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4、四级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满7000元者，系统自动默认您成为四级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的12%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5、五级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满10000元者，系统自动默认您成为五级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的15%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6、六级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满15000元者，系统自动默认您成为六级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的20%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7、七级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满18000元者，系统自动默认您成为七级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的25%。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;8、八级经纪人：当您推广『彩神通』彩票系列软件按当时市场价格满22000元者，系统自动默认您成为八级经纪人。从您下一次经纪活动开始，佣金奖励标准为软件款的30%。<br />
                                            <b>注意事项：</b><br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;1、为了提高『彩神通』经纪人的从事经纪活动积极性，在您资格从一级经纪人升为二级经纪人或更高级的经纪人后，您的佣金奖励标准将实行公平公正的年度考核办法。此处所列的“年度”是指：资格确认后当日始、于次年当日止，考核时间指系统将默认为您的经纪活动年度最后一天。
                                            具体指本年度您的『彩神通』经纪人佣金奖励标准可以延续享受到次年（即第二年度），但第二年度的推广业绩需要重新计算，第三年度的佣金奖励标准参考第二年度的推广业绩相对应的『彩神通』经纪人佣金奖励标准执行；同样，在第四年度的佣金奖励标准参考第三年度的推广业绩相对应的『彩神通』经纪人佣金奖励标准执行；以此类推。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2、购买软件时，软件狗和运费等其它费用不计入软件购买款价格。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;3、其它购买事宜，请查看拼搏在线彩神通软件“注册购买”介绍。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;4、请您及时关注网站公告，以上信息如有更改，将以拼搏在线网站最新公告执行。
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        
                                            <td height="41" align="center" valign="top">
                                                <a href="Broker_Agrt.aspx">
                                                    <asp:ImageButton ID="ibtnApply1" runat="server" ImageUrl="/images/web/br_sq.gif"
                                                        Width="209" Height="32" border="0" AlternateText="申请成为彩神通经纪人" OnClick="ibtnApply1_Click" /></a>
                                            </td>
                                        </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<link href="/javascript/kf/qq.css" type='text/css' rel='stylesheet' />
</html>
