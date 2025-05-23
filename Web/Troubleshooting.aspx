<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Troubleshooting.aspx.cs" Inherits="Pbzx.Web.Troubleshooting"
    EnableViewState="false" %>

<%@ Register Src="Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>疑难解答_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/buy.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
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
                    当前位置：<a href="/">拼搏在线彩神通软件</a> >> <a href="/SoftwarePrices.htm">注册购买</a> >> 疑难解答
                </div>
                <div class="Y_box Y_r1 MT">
                    <div class="title">
                        <p>
                            <a href=""><span>疑难解答</span></a></p>
                    </div>
                    <div class="content">
                        <div>
                            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="30" align="center" valign="bottom" class="Y_xia">
                                        疑难解答</td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                            </table>
                            <table width="96%" border="0" align="center" cellpadding="15" cellspacing="1" bgcolor="#ECECEC">
                                <tr>
                                    <td align="left" bgcolor="#FCFCFC">
                                        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" />
                                        <div class="demoarea">
                                            <b>&nbsp; 一、软件的购买与注册</b>
                                            <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                                                FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None"
                                                RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                                                <Panes>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                                        <Header>
                                                            <a href="">1.『彩神通』软件的注册方式有几种?它们有什么区别?</a></Header>
                                                        <Content>
                                                            答:『彩神通』软件的注册方式目前有三种方式。<br />
                                                            1)、网络方式——适合于经常能上网而又没有固定电脑使用软件的用户。优点:只要能上网即可在任何地方的电脑上使用软件;与使用的电脑无关。缺点:不能上网则不能使用软件，暂不支持代理上网。
                                                            <br />
                                                            2)、单机方式——适合于具有固定电脑使用软件的用户。优点:上网和不上网均可以使用软件。缺点:只能在这台电脑上使用软件,不能更换电脑(包括更换硬盘等硬件),更换电脑等导致认证码发生变化就需要重新购买软件。
                                                            <br />
                                                            3)、软件狗方式——适合于经常变换电脑使用软件的用户。优点:只要带上软件狗,即可在任何地方的电脑上使用;上网和不上网均可以使用软件;与使用的电脑无关。软件狗坏了可以更换(在寄回软件狗的情况下,半年之内免费更换,用户负责快递费;半年之后坏了只付软件狗的费用和快递费。不需要重新购买软件)。缺点:必须要插上软件狗才能使用。一旦软件狗丢失,则必须重新购买软件。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                                        <Header>
                                                            <a href="">2. 我想购买『彩神通』软件,请问应如何办理？</a></Header>
                                                        <Content>
                                                            答:彩神通软件提供两种购买方式，分别为：在线购买和汇款购买。<br />
                                                            <b>在线购买：</b>先去网站注册用户名，在软件产品页面选择需要的彩神通软件产品，点击“购买”进入购物车，提供软件注册所需信息，点击“结算”即可选择相应的付款方式支付。<br />
                                                            <b>汇款购买：</b>请汇款后打电话010-62132803或发电子邮件至sale@pinble.com ,注册时需请您提供把款汇到哪个银行、具体金额、软件品种、认证码或用户名、姓名、电话、地址等相关的注册信息。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                                                        <Header>
                                                            <a href="">3.在线购买时软件狗类型应如何选择？</a></Header>
                                                        <Content>
                                                            答:1) 软件狗方式(用以前软件狗)：已购买过软件狗的用户请选择此方式，需要您提供插入软件狗后读取到的认证码。<br />
                                                            2)软件狗方式(购买新软件狗)：如果您还没有软件狗，请选择此方式，公司将为您邮寄新软件狗。<br />
                                                            3)软件狗方式(绑定新软件狗)：如果您还没有软件狗，并且准备一次购买多款软件但只需注册到一个软件狗时，可以只将第一款软件选择购买新软件狗，后面的软件选择绑定新软件狗即可。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                                                        <Header>
                                                            <a href="">4.汇款购买用户通过电话或邮件联系注册时需要提供哪些信息？</a></Header>
                                                        <Content>
                                                            答:1)单机绑定方式注册用户请提供软件认证码和您的姓名、电话、所在城市;<br />
                                                            2)软件狗方式注册用户请提供您的姓名、电话和详细地址。我们将为您邮寄软件狗，请一定要把邮寄地址留全,否则无法保证您及时准确地收到软件狗;在软件狗邮寄期间如需使用临时软件，还请提供您的网站用户名。<br />
                                                            3)网络方式注册用户请提供您在拼搏在线彩神通软件网站注册的用户名及您的真实姓名、电话、所在城市。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane32" runat="server">
                                                        <Header>
                                                            <a href="">5. 需要注册时如遇到晚上或双休日、节假日怎么办？</a></Header>
                                                        <Content>
                                                            答:汇款购买用户可发电子邮件至sale@pinble.com,申请注册时需请您提供把款汇到哪个银行、具体金额、认证码、姓名、电话、地址、邮编等相关的注册信息,并确认是否需要购买软件狗,否则无法给您注册。
                                                            在线购买用户支付成功后，客服将在2个工作日内（如遇双休日、节假日将顺延）确认您的汇款并为您开通软件权限。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPaneb" runat="server">
                                                        <Header>
                                                            <b>二、关于软件的使用问题</b></Header>
                                                        <Content>
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                                                        <Header>
                                                            <a href="">1.如何成为“认证用户”? </a>
                                                        </Header>
                                                        <Content>
                                                            答:可通过论坛短信形式将软件的认证码和论坛ID发送到“蓉儿”的短信箱或将软件的认证码和论坛ID发到sale@pinble.com。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                                                        <Header>
                                                            <a href="">2.成为“认证用户”后有什么用?</a></Header>
                                                        <Content>
                                                            答:成为“认证用户”后可进入论坛的软件注册用户专区,此版面是3D『彩神通』软件注册用户讨论交流的版面,属于高级用户区,里面会有一些相应的增值服务,免费预测信息。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane7" runat="server">
                                                        <Header>
                                                            <a href="">3.『彩神通』软件是否提供试用?</a></Header>
                                                        <Content>
                                                            答:所有的『彩神通』付费软件都有一个星期的免费试用,但必须要连上互联网才能使用。还可以下载相应的『彩神通』免费版软件进行了解,或到软件下载专区下载相关的演示录像进行观看。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane8" runat="server">
                                                        <Header>
                                                            <a href="">4.如何下载演示录像?</a></Header>
                                                        <Content>
                                                            答:点击<a href='/Source.aspx'>资源下载</a>下载与软件对应的演示录像
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane9" runat="server">
                                                        <Header>
                                                            <a href="">5.如果我的电脑在安装完软件后需要重装系统怎么办?</a></Header>
                                                        <Content>
                                                            答:对于电脑重装系统,软件的认证码是不会发生改变的,您重装完系统后只需重新下载安装软件即可,然后打电话或发邮件至公司查询注册码。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane10" runat="server">
                                                        <Header>
                                                            <a href="">6.我的电脑更换了硬件或更换电脑导致软件认证码发生变化了怎么办?</a></Header>
                                                        <Content>
                                                            答:对于单机绑定方式注册的用户本公司只提供一次注册码,也就是说在软件的正常使用期间内,如果发生更换了硬件或更换电脑导致软件认证码发生变化,也就是说只要软件认证码发生变化,都需要按本网站最新公布的售价重新购买软件。但对于软件狗方式注册的用户就不存在这个问题了,您只需重新下载安装即可。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane13" runat="server">
                                                        <Header>
                                                            <a href="">7.如果我已购买了3D『彩神通』2005专业珍藏版软件,想转成数字三『彩神通』专业版的用户,是否补差价就可以了?</a></Header>
                                                        <Content>
                                                            答:可以,但只能补差价更换成专业版终身用户,而且必须用同一台电脑注册或购买软件狗,不能补差价换成专业版一年期限。对于按单机方式注册的用户必须是在同一台电脑上换,如果换了电脑就得重新购买。当然,在换成专业版时您也可以选择按软件狗方式注册。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane14" runat="server">
                                                        <Header>
                                                            <a href="">8.数字三『彩神通』标准版和数字三『彩神通』专业版有什么区别?</a></Header>
                                                        <Content>
                                                            答:数字三『彩神通』标准版与数字三『彩神通』专业版的区别主要体现在以下几个方面: <strong>(一)用户定位不同</strong><br>
                                                            1)、数字三『彩神通』标准版是专门为广大初、中级彩民开发的一款好用而不贵的彩票软件。定位于对图表分析和指标参数有初步了解,并刚刚学习使用软件的初、中级的彩民朋友;<br />
                                                            2)、数字三『彩神通』专业版是专门为技术分析型彩民朋友开发的一款具有很高技术含量的彩票软件,定位于有一定技术分析经验的技术型彩民朋友,是一款更适合技术型彩民使用的好软件。<br />
                                                            <strong>(二)功能上的区别</strong><br>
                                                            1)、数字三『彩神通』标准版主要有图表(11大类70余种,无自定义图表)、预测行分析、缩水(条件24大类)、数据统计(单选遗漏、组选遗漏、遗漏列表等3种,无自定义功能)、数据分析(号码查询1种)、辅助工具(投注指南、集合工具、大方案统计、号码组统计、号码统计、计算器等6种)等主要功能;<br />
                                                            2)、数字三『彩神通』专业版主要有(13大类120余种,有自定义图表)、预测行分析、缩水(条件35大类)、数据统计(单选遗漏、组选遗漏、遗漏列表、遗漏分布、直落统计等5种,有自定义功能)、数据分析(号码状态表、号码查询、偏态搜索等3种)、智能选号(邻孤传选号、复隔中选号、热温冷选号、金字塔选号、跟随选号、魔数选号、单选定位选号等6种)、辅助工具(投注指南、集合工具、大方案统计、号码组统计、号码统计、计算器等6种)等主要功能;<br />
                                                            <strong>(三)软件界面基本相同</strong><br>
                                                            1)、数字三『彩神通』标准版与数字三『彩神通』专业版的软件操作界面、图表样式、功能按纽布局等基本相同;<br />
                                                            2)、数字三『彩神通』标准版与数字三『彩神通』专业版对电脑的配置要求相同;<br />
                                                            3)、数字三『彩神通』标准版与数字三『彩神通』专业版的注册方式一样,在购买软件时均可以选择软件狗注册方式或单机绑定注册式中的一种进行注册。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane15" runat="server">
                                                        <Header>
                                                            <a href="">9.数字三『彩神通』标准版与3D『彩神通』标准版、排列三『彩神通』标准版有什么区别?</a></Header>
                                                        <Content>
                                                            答:数字三『彩神通』标准版里包括福彩和体彩两部分,使用时可相互切换。3D『彩神通』标准版里不包括体彩的相关数据,排列三『彩神通』标准版里也不包括福彩的相关数据。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane16" runat="server">
                                                        <Header>
                                                            <a href="">10.『彩神通』免费版与『彩神通』专业版有什么区别?</a></Header>
                                                        <Content>
                                                            答:『彩神通』免费版与『彩神通』专业版的界面完全一样,只不过『彩神通』免费版有很多的功能不能使用,只能看见界面。需要了解『彩神通』专业版的功能,可以下载『彩神通』免费版进行查看,也可以下载『彩神通』专业版进行免费试用。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane17" runat="server">
                                                        <Header>
                                                            <a href="">11.如果我已购买了3D『彩神通』标准版或排列三『彩神通』标准版,想换成数字三『彩神通』标准版是否可以补差价?</a></Header>
                                                        <Content>
                                                            答:不可以,必须重新购买。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane18" runat="server">
                                                        <Header>
                                                            <a href="">12.如果购买了标准版的软件,是否可以补差价换成专业版?</a></Header>
                                                        <Content>
                                                            答:不可以,必须重新购买。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane19" runat="server">
                                                        <Header>
                                                            <a href="">13.为什么不能在线下载数据,也不能在线升级了?</a></Header>
                                                        <Content>
                                                            答:这跟您电脑的防火墙设置有关,请修改您的防火墙设置,允许软件访问网络。如果软件确实不能在线升级了,请到“软件下载”区重新下载软件安装包后,先把老版本卸载,然后安装即可。防火墙具体操作为:(1)双击防火墙图标;(2)点“设置”中的“详细设置”;(3)选择“访问规则”;(4)允许『彩神通』程序访问网络。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane20" runat="server">
                                                        <Header>
                                                            <a href="">14.下载数据时为什么提示下载数据次数过多,不能下载数据了?</a></Header>
                                                        <Content>
                                                            答:软件每天下载数据的次数是有限制的,一天之内不能反复多次下载数据;尤其是使用3D『彩神通』软件的用户,在试机号还没有出来之前,请勿连续下载数据;否则一旦下载次数达到上限,当天就不能再下载数据了,必须要等到晚上0点以后才能下载数据。要想验证条件,请使用数据范围设置或者使用缩水软件中的“验证”功能。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane21" runat="server">
                                                        <Header>
                                                            <a href="">15.如果我购买了一套软件,可否在家里的电脑和办公室的电脑上同时安装?</a></Header>
                                                        <Content>
                                                            答:如果您购买的是不带软件狗的软件,那么一套软件只能装在一台电脑上使用。如果购买的是带软件狗的软件,则可在多台电脑上使用(必须在使用的电脑上插上软件狗)。如果购买的软件是网络方式注册的,也可以在不同的电脑上使用,但不能同时使用。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPanec" runat="server">
                                                        <Header>
                                                            <b>三、关于软件狗</b></Header>
                                                        <Content>
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane22" runat="server">
                                                        <Header>
                                                            <a href="">1.什么是软件狗?</a></Header>
                                                        <Content>
                                                            答:软件狗是一个有USB接口的硬件,比U盘稍小一点,是用来辨别所使用的软件是否合法的凭证。只要您的计算机有USB接口,就可以使用软件狗。运行软件时,必须保证计算机上已经插入该软件狗,同样的,只要计算机上插上了该软件狗,就能正常使用该软件。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane23" runat="server">
                                                        <Header>
                                                            <a href="">2.软件狗有什么好处?</a></Header>
                                                        <Content>
                                                            答:(1)只要插上软件狗就可以在不同计算机上使用『彩神通』软件,比如,您的家里和公司都有计算机,只要您购买了一套带软件狗的『彩神通』软件,就可以在这两台机器上使用,不需要另外购买一套。<br />
                                                            (2)软件狗是与计算机硬件无关的一个设备,所以即使您的计算机配置发生了变化,或您重新换了一台计算机,也不影响软件的正常使用。<br />
                                                            (3)一只软件狗中可以注册任意8种类型的『彩神通』软件(如数字三『彩神通』专业版,双色球『彩神通』专业版,排列五『彩神通』标准版等),用户只要购买一只软件狗即可,而不必购买一套软件就购买一只软件狗(除非用户自己需要特意分开使用)。也就是说,一个软件狗可以作为任意类型的『彩神通』软件的合法凭证。<br />
                                                            (4)购买带软件狗的『彩神通』软件,只需要进行一次注册,以后无论重装系统还是更换机器,都可以直接使用而无需重新注册和输入注册码。<br />
                                                            (5)带软件狗的『彩神通』软件的所有功能和不带软件狗的『彩神通』软件一样,也支持软件升级。<br />
                                                            (6)如果半年内软件狗非人为损坏,并且外观上无损坏痕迹,在用户寄回原软件狗的情况下可以免费更换,由用户负担运费。同时,在软件狗中的软件注册记录将继续有效。如果超出半年后软件狗损坏或半年内软件狗外观损坏,在用户寄回原软件狗的情况下更换新软件狗,收取软件狗的成本费,由用户承担运费,同时软件的注册记录继续有效。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane24" runat="server">
                                                        <Header>
                                                            <a href="">3.购买什么版本的软件都可以注册成软件狗方式吗?费用是多少?</a></Header>
                                                        <Content>
                                                            答:是的,专业版一年期限的用户也可以购买软件狗;带软件狗的『彩神通』软件的售价为:该『彩神通』软件的使用费用 + 软件狗相关费用(包括软件狗成本费100元、快递费20元)。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane25" runat="server">
                                                        <Header>
                                                            <a href="">4.如果软件狗丢了怎么办?</a></Header>
                                                        <Content>
                                                            答:使用软件狗的用户购买软件时,公司只负责提供一次软件狗和该软件狗中注册的软件,如果用户丢失了软件狗，须按本网站最新公布的软件售价重新购买，不再提供软件狗的补发和软件的重新注册。所以请妥善保管好自己的软件狗，以免造成不必要的损失。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane26" runat="server">
                                                        <Header>
                                                            <a href="">5.我现在不是软件狗注册方式,如果想改成软件狗注册方式怎么办?</a></Header>
                                                        <Content>
                                                            答:对于已经注册成单机绑定的注册用户想更换为软件狗注册方式，须按本网站最新公布的软件售价重新购买，不提供该方式的更换。所以注册时请慎重选择注册方式。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane28" runat="server">
                                                        <Header>
                                                            <a href="">6.是不是在所有的电脑上都可以使用软件狗?</a></Header>
                                                        <Content>
                                                            答:是的。但如果计算机没有USB接口,将无法使用软件狗。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane29" runat="server">
                                                        <Header>
                                                            <a href="">7.第一次使用软件狗应如何操作?</a></Header>
                                                        <Content>
                                                            答:1)、首先请不要插入软件狗,如果已经插入,请先拔出;<br>
                                                            2)、在安装新版本的彩神通软件以后,运行彩神通主程序,会弹出注册方式选择对话框,请选择“软件狗注册方式”; 如果系统没有安装过软件狗的驱动,软件上会出现“安装驱动”的按钮;如果系统以前安装过软件狗的驱动,则不会提示而直接进入第6步;<br />
                                                            <img src="/Images/UploadFiles/buy/buy_flow1.gif" border="0" hspace="5" vspace="5" /><br />
                                                            3)、点击“安装驱动”,这时软件会提示您确认软件狗没有插入;<br />
                                                            <img src="/Images/UploadFiles/buy/buy_flow2.gif" border="0" hspace="5" vspace="5" /><br />
                                                            4)、点击“确定”,系统就会自动安装软件狗的驱动程序并提示您插入软件狗;<br />
                                                            <img src="/Images/UploadFiles/buy/buy_flow3.gif" border="0" hspace="5" vspace="5" /><br />
                                                            5)、点击“确定”,系统自动安装成功后会出现“获取信息”按钮;<br />
                                                            <img src="/Images/UploadFiles/buy/buy_flow4.gif" border="0" hspace="5" vspace="5" /><br />
                                                            6)、点击“获取信息”即可读取到认证码及软件使用期限信息,点“确定”即可进入软件。<br />
                                                            <img src="/Images/UploadFiles/buy/buy_flow5.gif" border="0" hspace="5" vspace="5" /><br />
                                                            注:1)、由于有时USB接口接触不好会导致系统检测错误,即使已经插入软件狗也可能提示没有插入,这时请拨出以后重新插入或换一个USB接口再试。<br />
                                                            2)、如果以上步骤不能顺利进行,请到网站下载软件狗驱动程序进行安装,然后再按上述的步骤操作。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane30" runat="server">
                                                        <Header>
                                                            <a href="">8.如果软件狗坏了怎么办?</a></Header>
                                                        <Content>
                                                            答:从设计上讲,软件狗可以拔插10万次无故障,即正常使用5到10年一般不会损坏。自购买之日起,如果半年内非人为损坏（外观无破损）,在用户寄回原软件狗的情况下可以免费更换,由用户负担运费，软件狗中的软件注册记录继续有效。如果超过半年或半年内人为损坏（外观破损）,在用户寄回原软件狗的情况下更换新软件狗,收取软件狗的成本费及运费，软件狗中原有的注册记录继续有效。
                                                        </Content>
                                                    </ajaxToolkit:AccordionPane>
                                                    <ajaxToolkit:AccordionPane ID="AccordionPane31" runat="server">
                                                        <Header>
                                                            <a href="">9.我已经购买过带软件狗的软件,现在再想购买其它『彩神通』软件,是否需要把软件狗邮寄回公司注册?</a></Header>
                                                        <Content>
                                                            答:不需要。已经购买过软件狗的用户,如果现在再想购买其它『彩神通』软件并需要写进软件狗,是不需要把软件狗邮寄回公司注册的;除非购买的软件需要与以前购买的软件狗分开,否则也不需要重新购买另一个软件狗。只需要把购买软件的钱汇给公司,然后下载购买的软件安装,启动后按软件狗方式注册,插入软件狗后系统会自动显示带软件狗的认证码,通过电话或Email把相关的注册信息(姓名、电话、地址、软件狗的认证码、汇款银行、汇款金额等)告诉公司即可得到注册码,把注册码输入进去,点“注册”即可注册成功。</Content>
                                                    </ajaxToolkit:AccordionPane>
                                                </Panes>
                                            </ajaxToolkit:Accordion>
                                            <%--  Fade Transitions:
                                            <input id="fade" type="checkbox" onclick="toggleFade();" value="false" /><br />
                                            AutoSize:
                                            <select id="autosize" onchange="changeAutoSize();">
                                                <option selected="selected">None</option>
                                                <option>Limit</option>
                                                <option>Fill</option>
                                            </select>

                                            <script language="javascript" type="text/javascript">
            function toggleFade() {
                var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
                if (behavior) {
                    behavior.set_FadeTransitions(!behavior.get_FadeTransitions());
                }
            }
            function changeAutoSize() {
                var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
                var ctrl = $get('autosize');
                if (behavior) {
                    var size = 'None';
                    switch (ctrl.selectedIndex) {
                        case 0 :
                            behavior.get_element().style.height = 'auto';
                            size = AjaxControlToolkit.AutoSize.None;
                            break;
                        case 1 :
                            behavior.get_element().style.height = '400px';
                            size = AjaxControlToolkit.AutoSize.Limit;
                            break;
                        case 2 :
                            behavior.get_element().style.height = '400px';
                            size = AjaxControlToolkit.AutoSize.Fill;
                            break;
                    }
                    behavior.set_AutoSize(size);
                }
                if (document.focus) {
                    document.focus();
                }
            }
                                            </script>--%>
                                            <%--<br />
                                            <span class="bulebiaoti">注册联系方式:</span><br />
                                            E-MAIL:<a href="mailto:sale@pinble.com">sale@pinble.com</a>
                                            <br />
                                            公司电话:010-68002247,68002248,68002963
                                            <br />
                                            (非上班时间注册请发邮件至:<a href="mailto:sale@pinble.com">sale@pinble.com</a>)<br />
                                            汇款后请及时与我们联系进行注册,具体注册方法见 <a href="Buy_lianxzhc.aspx" class="red">注册说明</a>--%>
                                        </div>
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
