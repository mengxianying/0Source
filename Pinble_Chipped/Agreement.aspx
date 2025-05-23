<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Agreement.aspx.cs" Inherits="Pinble_Chipped.Agreement" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>彩票超市协议书</title>
    <style type="text/css">
        BODY {
	PADDING-BOTTOM: 0px; BORDER-RIGHT-WIDTH: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; PADDING-TOP: 0px
}
BODY {
	WIDTH: 100%; #dfebf5 repeat-x left top; FONT-SIZE: 12px
}
#wrap {
	WIDTH: 100%; BACKGROUND: url(../image/xybghead.jpg) repeat-x center top; HEIGHT: 400px
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
	MIN-HEIGHT: 70px; WIDTH: 781px; BACKGROUND: url(../image/xybghead_top.gif) #fff no-repeat; HEIGHT: auto; OVERFLOW: visible; _height: 70px
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
	BORDER-BOTTOM: #cad6df 1px solid; PADDING-BOTTOM: 0px; LINE-HEIGHT: 34px; MARGIN: 0px auto; PADDING-LEFT: 15px; WIDTH: 670px; PADDING-RIGHT: 15px; BACKGROUND: url(../image/xybtn.gif) repeat-x 0px -412px; HEIGHT: 34px; COLOR: #333; CLEAR: both; FONT-SIZE: 14px; FONT-WEIGHT: bold; PADDING-TOP: 0px
}
.btn_s_c A {
	TEXT-ALIGN: center; LINE-HEIGHT: 28px; MARGIN: 20px auto; WIDTH: 95px; DISPLAY: block; BACKGROUND: url(../image/xybtn.gif) no-repeat 0px -82px; HEIGHT: 28px; COLOR: #fff; FONT-SIZE: 14px; FONT-WEIGHT: bold; TEXT-DECORATION: none
}
.btn_s_c A:link {
	TEXT-ALIGN: center; LINE-HEIGHT: 28px; MARGIN: 20px auto; WIDTH: 95px; DISPLAY: block; BACKGROUND: url(../image/xybtn.gif) no-repeat 0px -82px; HEIGHT: 28px; COLOR: #fff; FONT-SIZE: 14px; FONT-WEIGHT: bold; TEXT-DECORATION: none
}
.btn_s_c A:visited {
	TEXT-ALIGN: center; LINE-HEIGHT: 28px; MARGIN: 20px auto; WIDTH: 95px; DISPLAY: block; BACKGROUND: url(../image/xybtn.gif) no-repeat 0px -82px; HEIGHT: 28px; COLOR: #fff; FONT-SIZE: 14px; FONT-WEIGHT: bold; TEXT-DECORATION: none
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
            合买代购协议书</div>
            <div class="xyheadlink">
                关于我们 | 友情链接 | 广告服务 | 用户协议</div>
            <div class="xyclearit">
            </div>
        </div>
        <div class="xymain">
            <div class="xymain_top">
                <p class="xytitle_top1">
                    &lt;&lt;合买代购详细协议&gt;&gt;</p>
            </div>
            <div class="xymain_cen">
                <p class="xytitle">
                </p>
                <div class="xyservice">
                    <strong>1. 特别提示</strong><br />
                    
                    1、 本网站立足于服务彩民，所有用户发起、认购彩票方案，网站均不收取任何手续费<br />
                    2、 网站用户须同意本网站代理购买、保管彩票、领取奖金和派发奖金的有关事宜。<br />
                    3、 双色球发起人可自行设置税后奖金盈利部分0%-10%做为方案提成，网站保留提成比例调整的权利。<br />
                    4、 用户有权自由发起方案，代购方案不限制，合买方案每人每期限发100个合买方案，每期最多5个未满员方案同时存在。<br />
                    5、 为保证方案发起的严肃性，方案最低发起金额为2元，合买方案发起人须先购买至少5%。<br />
                    6、 为确保方案正常出票，19:00以后单式方案单倍金额上限为20,000元。<br />
                    7、 方案进度（含保底）超过50%的发起人、认购人均不能撤单均不能撤单。当期彩票截止后，未合买成功方案系统将进行撤单返款处理。<br />
                    8、 奖金分配：代购方案所中取的奖金，均属于此方案发起人所有。合买方案中奖后，发起人按照事先约定的方式、比例进行提成，其余奖金按照此方案各用户认购比例进行分配，除不尽的部分归方案发起人所有。<br />
                    9、 彩票开奖后，网站将代为办理兑奖、派奖事宜，并在一个工作日内把税后奖金添入中奖用户之预付款帐户。<br />
                    10、 如因彩票中心网络异常、赛事提前截止、停电、网站网络中断、出票服务器维护等特殊原因，网站有随时调整截止时间的权利。如因上述意外因素导致本站未能够出票完毕，本站将在开奖前对未出票方案做撤单返款处理，并发公告通知网友。除此之外，本站不再承担其他责任。<br />
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
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
    </div>
</body>
</html>
