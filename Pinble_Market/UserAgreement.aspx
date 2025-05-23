<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserAgreement.aspx.cs"
    Inherits="Pinble_Market.UserAgreement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>彩票超市协议书</title>
    <style type="text/css">
        BODY {
	PADDING-BOTTOM: 0px; BORDER-RIGHT-WIDTH: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; PADDING-TOP: 0px
}
BODY {
	WIDTH: 100%; BACKGROUND: url(/images/signup/bg.gif) #dfebf5 repeat-x left top; FONT-SIZE: 12px
}
#wrap {
	WIDTH: 100%; BACKGROUND: url(../X_images/xybghead.jpg) repeat-x center top; HEIGHT: 400px
}
.xyhead {
	MARGIN: 0px auto; WIDTH: 781px
}
.xylogo {
	WIDTH: 142px;
	FLOAT: left;
	HEIGHT:57px;
    background-image: url(../X_images/sprite.png);
	background-repeat: no-repeat;
	margin-top: 13px;
	margin-right: 0px;
	margin-bottom: 10px;
	margin-left: 5px;
}
.xylogotxt {
	MARGIN: 50px 0px 0px 10px; FLOAT: left;font-family: "微软雅黑";
}
.xyheadlink {
	TEXT-ALIGN: right; MARGIN: 58px 8px 0px 0px; WIDTH: 400px; FLOAT: right; COLOR: #fff
}
.xyheadlink A {
	COLOR: #fff; TEXT-DECORATION: none
}
.xyheadlink A:link {
	COLOR: #fff; TEXT-DECORATION: none
}
.xyheadlink A:visited {
	COLOR: #fff; TEXT-DECORATION: none
}
.xyheadlink A:hover {
	COLOR: #fff; TEXT-DECORATION: underline
}
.xyclearit {
	CLEAR: both
}
.xymain {
	POSITION: relative; MARGIN: 0px auto; WIDTH: 781px; CLEAR: both
}
.xymain_top {
	MIN-HEIGHT: 70px; WIDTH: 781px; BACKGROUND: url(../X_images/xybghead_top.gif) #fff no-repeat; HEIGHT: auto; OVERFLOW: visible; _height: 70px
}
.xytitle_top1 {
	TEXT-ALIGN: center; LINE-HEIGHT: 35px; MARGIN: 29px auto 0px; WIDTH: 670px; HEIGHT: 35px; COLOR: #333; CLEAR: both; FONT-SIZE: 16px;font-family: "微软雅黑"; FONT-WEIGHT: bold
}
.xymain_cen {
	BORDER-LEFT: #86adc6 1px solid; PADDING-BOTTOM: 50px; MIN-HEIGHT: 200px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND: #fff; HEIGHT: auto; BORDER-RIGHT: #86adc6 1px solid; PADDING-TOP: 10px; _height: 200px
}
.xytitle {
	PADDING-BOTTOM: 0px; LINE-HEIGHT: 35px; MARGIN: 0px auto; PADDING-LEFT: 15px; WIDTH: 670px; PADDING-RIGHT: 15px; BACKGROUND: url(../X_images/xybtn.gif) repeat-x 0px -370px; HEIGHT: 35px; COLOR: #333; CLEAR: both; FONT-SIZE: 14px; BORDER-TOP: #cad6df 1px solid; FONT-WEIGHT: bold; PADDING-TOP: 0px
}
.xyservice {
	PADDING-BOTTOM: 10px;
	LINE-HEIGHT: 2em;
	OVERFLOW-Y: scroll;
	MARGIN: 0px auto;
	PADDING-LEFT: 30px;
	WIDTH: 635px;
	PADDING-RIGHT: 30px;
	HEIGHT: 435px;
	PADDING-TOP: 10px;
	font-family: "微软雅黑";
	font-size: 13px;
}
.xytitle_bottom {
	BORDER-BOTTOM: #cad6df 1px solid; PADDING-BOTTOM: 0px; LINE-HEIGHT: 34px; MARGIN: 0px auto; PADDING-LEFT: 15px; WIDTH: 670px; PADDING-RIGHT: 15px; BACKGROUND: url(../X_images/xybtn.gif) repeat-x 0px -412px; HEIGHT: 34px; COLOR: #333; CLEAR: both; FONT-SIZE: 14px; FONT-WEIGHT: bold; PADDING-TOP: 0px
}
.btn_s_c A {
	TEXT-ALIGN: center; LINE-HEIGHT: 28px; MARGIN: 20px auto; WIDTH: 95px; DISPLAY: block; BACKGROUND: url(../X_images/xybtn.gif) no-repeat 0px -82px; HEIGHT: 28px; COLOR: #fff; FONT-SIZE: 14px; FONT-WEIGHT: bold; TEXT-DECORATION: none
}
.btn_s_c A:link {
	TEXT-ALIGN: center; LINE-HEIGHT: 28px; MARGIN: 20px auto; WIDTH: 95px; DISPLAY: block; BACKGROUND: url(../X_images/xybtn.gif) no-repeat 0px -82px; HEIGHT: 28px; COLOR: #fff; FONT-SIZE: 14px; FONT-WEIGHT: bold; TEXT-DECORATION: none
}
.btn_s_c A:visited {
	TEXT-ALIGN: center; LINE-HEIGHT: 28px; MARGIN: 20px auto; WIDTH: 95px; DISPLAY: block; BACKGROUND: url(../X_images/xybtn.gif) no-repeat 0px -82px; HEIGHT: 28px; COLOR: #fff; FONT-SIZE: 14px; FONT-WEIGHT: bold; TEXT-DECORATION: none
}
.xymain_bottom {
	WIDTH: 781px; BACKGROUND: url(../X_images/xybghead_bottom.gif) no-repeat; HEIGHT: 5px; OVERFLOW: hidden
}
.xyFooter {
	TEXT-ALIGN: center; LINE-HEIGHT: 25px; MARGIN-TOP: 10px; FONT-FAMILY: Arial,"微软雅黑"; CLEAR: both
}
    </style>
</head>
<body>
    <div id="wrap">
        <div class="xyhead">
            <div class="xylogo">
            </div>
            <div class="xylogotxt fb">
                - 彩票超市购买协议书</div>
            <div class="xyheadlink">
                关于我们 | 友情链接 | 广告服务 | 用户协议</div>
            <div class="xyclearit">
            </div>
        </div>
        <div class="xymain">
            <div class="xymain_top">
                <p class="xytitle_top1">
                    &lt;&lt;彩票超市购买协议书条款&gt;&gt;</p>
            </div>
            <div class="xymain_cen">
                <p class="xytitle">
                </p>
                <div class="xyservice">
                    <strong>1. 特别提示</strong><br/>
                    在申请注册『拼搏在线』“彩票超市”客户之前请您仔细阅读本协议。如果您同意并申请注册使用了“彩票超市”客户的有偿服务，（则）即表示您完全同意遵守所有这些条款。如果您不同意接受这些条款，可以选择离开。
                    <br/>
                    <br/>
                    <strong>2. 注意事项</strong><br/>
                    注册成为『拼搏在线』“彩票超市”客户时，需按要求填写真实详细的个人身份资料、姓名、住址、联系电话、电子邮箱等相关资料。注册成功后，请妥善保管好您的用户名和密码，并要对您的用户名和密码安全，以及以该用户名进行的所有活动和事件负全责。您可以随时根据需要来（修改更新）改变您的密码。<br/>
                    <br/>
                    <strong>3. 服务项目</strong><br/>
                    1、向客户提供网站空间，开设彩票信息有偿类服务项目，并按客户自愿选择的商户产品网上实际标价收取相关费用；<br/>
                    2、提供网站后台维护，定时更新商户中奖（比如商户排名、预测信息成功率等）信息内容；<br/>
                    3、提供必要的售前、售中、售后服务保证，受理投诉、咨询等信息服务方面问题；承诺除遇不可抗拒因素外，在客户定制“彩票超市”彩票信息服务期间，提供良好的网站技术保障，并满足商户合理要求；<br/>
                    4、听取客户意见，满足客户合理需求，及时调整、优化信息方案；<br/>
                    5、保证网站发（公）布信息的真实性，但不做必中承诺，在此提示您彩市有风险，投资需谨慎。<br/>
                    <br/>
                    <strong>4. 客户的权利和义务</strong><br/>
                    1、保证个人ID账户在起动定制服务信息前有足够的相应服务项目起订资金；<br/>
                    2、自愿选择和确定“彩票超市”现有商户及彩票信息种类，享受有偿信息定制成功后对相应信息的浏览权；<br/>
                    3、客观务实，公正评价并合理选择网站发布的信息服务内容，善意提出合理化意见及建议；<br/>
                    4、不得发表任何非法的、骚扰性的、中伤他人的、辱骂性的、恐吓性的、伤害性的、庸俗的，淫秽的等信息内容，一经发现，网站有权单方中止该客户ID一切交易及其它活动，情形恶劣者将冻结货币、金币及积分等网站资产；<br/>
                    5、保证在「拼搏在线」“彩票超市”获取的信息内容的独享性，不转载、不传播，自担个人用户名进行的所有活动和事件任何问题与后果。
                    <br/>
                    <br/>
                    <strong>5. 服务终止</strong><br/>
                    本协议按最短时间“一个月”起订有效，另有“三个月”、“六个月”、“一年（最长时间为一年，如涉及优惠问题参考商家自定内容）”供客户自愿选择，有效期自“公司确认开通客户资格”起始之日算起，期满可续签。但由于商户本身的原因，比如商户自行中止相关预测信息并关闭“彩票超市”网店，网站除积极配合按客户要求转订、停订或及时结算以及涉及清退客户个人资金余额外，其余不担责。
                    <br/>
                    <br/>
                    <strong>6. 本协议未尽事宜协商解决。</strong>
                    <p>
                    </p>
                </div>
                <p class="xytitle_bottom">
                </p>
                <div class="btn_s_c">
                    <a href="javascript:window.close(this)">关闭本页</a></div>
            </div>
            <div class="xymain_bottom">
            </div>
        </div>
        <div class="xyFooter">
            Copyright &copy; 1996-2011 pinble Corporation, All Rights Reserved 拼搏在线公司 版权所有
        </div>
    </div>
</body>
</html>
