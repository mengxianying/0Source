<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserAgreement.aspx.cs"
    Inherits="Pinble_Market.UserAgreement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>��Ʊ����Э����</title>
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
	MARGIN: 50px 0px 0px 10px; FLOAT: left;font-family: "΢���ź�";
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
	TEXT-ALIGN: center; LINE-HEIGHT: 35px; MARGIN: 29px auto 0px; WIDTH: 670px; HEIGHT: 35px; COLOR: #333; CLEAR: both; FONT-SIZE: 16px;font-family: "΢���ź�"; FONT-WEIGHT: bold
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
	font-family: "΢���ź�";
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
	TEXT-ALIGN: center; LINE-HEIGHT: 25px; MARGIN-TOP: 10px; FONT-FAMILY: Arial,"΢���ź�"; CLEAR: both
}
    </style>
</head>
<body>
    <div id="wrap">
        <div class="xyhead">
            <div class="xylogo">
            </div>
            <div class="xylogotxt fb">
                - ��Ʊ���й���Э����</div>
            <div class="xyheadlink">
                �������� | �������� | ������ | �û�Э��</div>
            <div class="xyclearit">
            </div>
        </div>
        <div class="xymain">
            <div class="xymain_top">
                <p class="xytitle_top1">
                    &lt;&lt;��Ʊ���й���Э��������&gt;&gt;</p>
            </div>
            <div class="xymain_cen">
                <p class="xytitle">
                </p>
                <div class="xyservice">
                    <strong>1. �ر���ʾ</strong><br/>
                    ������ע�᡺ƴ�����ߡ�����Ʊ���С��ͻ�֮ǰ������ϸ�Ķ���Э�顣�����ͬ�Ⲣ����ע��ʹ���ˡ���Ʊ���С��ͻ����г����񣬣��򣩼���ʾ����ȫͬ������������Щ����������ͬ�������Щ�������ѡ���뿪��
                    <br/>
                    <br/>
                    <strong>2. ע������</strong><br/>
                    ע���Ϊ��ƴ�����ߡ�����Ʊ���С��ͻ�ʱ���谴Ҫ����д��ʵ��ϸ�ĸ���������ϡ�������סַ����ϵ�绰�����������������ϡ�ע��ɹ��������Ʊ��ܺ������û��������룬��Ҫ�������û��������밲ȫ���Լ��Ը��û������е����л���¼���ȫ����������ʱ������Ҫ�����޸ĸ��£��ı��������롣<br/>
                    <br/>
                    <strong>3. ������Ŀ</strong><br/>
                    1����ͻ��ṩ��վ�ռ䣬�����Ʊ��Ϣ�г��������Ŀ�������ͻ���Ըѡ����̻���Ʒ����ʵ�ʱ����ȡ��ط��ã�<br/>
                    2���ṩ��վ��̨ά������ʱ�����̻��н��������̻�������Ԥ����Ϣ�ɹ��ʵȣ���Ϣ���ݣ�<br/>
                    3���ṩ��Ҫ����ǰ�����С��ۺ����֤������Ͷ�ߡ���ѯ����Ϣ���������⣻��ŵ�������ɿ��������⣬�ڿͻ����ơ���Ʊ���С���Ʊ��Ϣ�����ڼ䣬�ṩ���õ���վ�������ϣ��������̻�����Ҫ��<br/>
                    4����ȡ�ͻ����������ͻ��������󣬼�ʱ�������Ż���Ϣ������<br/>
                    5����֤��վ������������Ϣ����ʵ�ԣ����������г�ŵ���ڴ���ʾ�������з��գ�Ͷ���������<br/>
                    <br/>
                    <strong>4. �ͻ���Ȩ��������</strong><br/>
                    1����֤����ID�˻����𶯶��Ʒ�����Ϣǰ���㹻����Ӧ������Ŀ���ʽ�<br/>
                    2����Ըѡ���ȷ������Ʊ���С������̻�����Ʊ��Ϣ���࣬�����г���Ϣ���Ƴɹ������Ӧ��Ϣ�����Ȩ��<br/>
                    3���͹���ʵ���������۲�����ѡ����վ��������Ϣ�������ݣ��������������������飻<br/>
                    4�����÷����κηǷ��ġ�ɧ���Եġ��������˵ġ������Եġ������Եġ��˺��Եġ�ӹ�׵ģ�����ĵ���Ϣ���ݣ�һ�����֣���վ��Ȩ������ֹ�ÿͻ�IDһ�н��׼�����������ζ����߽�������ҡ���Ҽ����ֵ���վ�ʲ���<br/>
                    5����֤�ڡ�ƴ�����ߡ�����Ʊ���С���ȡ����Ϣ���ݵĶ����ԣ���ת�ء����������Ե������û������е����л���¼��κ�����������
                    <br/>
                    <br/>
                    <strong>5. ������ֹ</strong><br/>
                    ��Э�鰴���ʱ�䡰һ���¡�����Ч�����С������¡����������¡�����һ�꣨�ʱ��Ϊһ�꣬���漰�Ż�����ο��̼��Զ����ݣ������ͻ���Ըѡ����Ч���ԡ���˾ȷ�Ͽ�ͨ�ͻ��ʸ���ʼ֮��������������ǩ���������̻������ԭ�򣬱����̻�������ֹ���Ԥ����Ϣ���رա���Ʊ���С����꣬��վ��������ϰ��ͻ�Ҫ��ת����ͣ����ʱ�����Լ��漰���˿ͻ������ʽ�����⣬���಻����
                    <br/>
                    <br/>
                    <strong>6. ��Э��δ������Э�̽����</strong>
                    <p>
                    </p>
                </div>
                <p class="xytitle_bottom">
                </p>
                <div class="btn_s_c">
                    <a href="javascript:window.close(this)">�رձ�ҳ</a></div>
            </div>
            <div class="xymain_bottom">
            </div>
        </div>
        <div class="xyFooter">
            Copyright &copy; 1996-2011 pinble Corporation, All Rights Reserved ƴ�����߹�˾ ��Ȩ����
        </div>
    </div>
</body>
</html>
