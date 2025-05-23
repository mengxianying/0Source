<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Help.aspx.cs" Inherits="Pinble_Ask.Help" %>

<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>帮助中心_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="132" align="right">
                        <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="158" height="72" align="center">
                                    <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="100">
                        <a href="<%=Pbzx.Common.WebInit.ask.WebUrl%>">
                            <img src="/images/A_Logo.jpg" width="120" height="58" border="0" /></a></td>
                    <td width="745" style="padding-top: 18px;">
                        <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#E5ECF9">
                            <tr>
                                <td width="94%" align="left" class="f14blackB">
                                    &nbsp;帮助中心</td>
                                <td width="6%">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="8">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <a href="#ask" class="Linl14B">如何提问</a> <a href="#ans" class="Linl14B">如何回答</a>
                        <a href="#chu" class="Linl14B">如何处理问题</a> <a href="#pass" class="Linl14B">如何处理过期问题</a>
                        <a href="#colse" class="Linl14B">问题为何被关闭</a> <a href="#point" class="Linl14B">如何获得积分</a>
                        <a href="#title" class="Linl14B">关于头衔</a> <a href="#cannl" class="Linl14B">如何避免问答被删</a></td>
                </tr>
                <tr>
                    <td height="12">
                    </td>
                </tr>
                <tr>
                    <td height="1" bgcolor="#CCCCCC">
                    </td>
                </tr>
                <tr>
                    <td height="5">
                    </td>
                </tr>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tr>
                    <td width="750" align="left" bgcolor="#e5ecf9" class="f14blackB">
                        如何使用拼搏吧</td>
                </tr>
                <tr>
                    <td align="left" class="f14black3">
                        <br />
                        我们提醒您注意：您需要注册并登录，才能享受拼搏吧的完整服务，否则您只有搜索和浏览的权限。注册成为会员，是完全免费的。</td>
                </tr>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;如何提问<a name="ask" id="ask"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="left" valign="top" class="f14black3">
                                            <br />
                                            <b>在输入框输入提问</b><br />
                                            每个页面的顶端都可以看到“我要提问”的提问输入框，在提问输入框中输入您的问题。<br />
                                            例如输入“我能不能将以前买的数字三『彩神通』专业版软件改成带软件狗使用方式的？”，并点击“我要提问”。<br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <img src="images/help1.jpg" width="660" height="150" /></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="1" bgcolor="#dddddd">
                                    </td>
                                </tr>
                            </table>
                            <p class="f14black">
                                <b>填写提问细节并悬赏</b></p>
                            <p>
                                接下来，您进入到一个提问细节处理页面，在这里您可以进一步对您的提问进行细节处理：
                            </p>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="f14B" valign="top" width="12">
                                            <b>A:</b></td>
                                        <td width="594" align="left" class="f14black3">
                                            <strong>详细说明问题：</strong><br />
                                            您可以详细描述您所遇到的难题，以得到网友最好最有针对性的回答。<br />
                                            例如“例如“我以前买的数字三『彩神通』专业版软件是单版的，现在我家里有两台电脑，能不能改成软件狗的？”。<br />
                                            <br />
                                        </td>
                                        <td class="f14" valign="top" align="middle" width="350" rowspan="6">
                                            <img height="270" src="images/help2.jpg" width="350" /></td>
                                    </tr>
                                    <tr>
                                        <td class="f14B" valign="top">
                                            <b>B:</b></td>
                                        <td align="left" class="f14black3">
                                            <strong>设置问题分类</strong><br />
                                            请为您的问题选择一个最恰当的分类，因为只有这样，您的问题才能在第一时间内得到更专业的互动解答。<span class="p2"><br />
                                            </span>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="f14B" valign="top">
                                            <b>C:</b></td>
                                        <td align="left" class="f14black3">
                                            <strong>设置悬赏积分</strong><br />
                                            设置悬赏积分，可以让您的问题得到更多的关注，当然悬赏积分越高，受到的关注度也越高。<br />
                                            请您注意：设置了悬赏积分，悬赏积分便将从您的积分中扣除，并在您选择了最佳答案后，赠送给最佳答案的回答者；未在规定的时间内处理，此积分将由系统没收。
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="f14B" valign="top">
                                            <b>D:</b></td>
                                        <td align="left" class="f14black3">
                                            <strong>设定匿名</strong><br />
                                            当某些提问属于您的个人隐私，您可以设定匿名提问，这样，您的用户名便不会出现在问题页面上，取而代之的将会是“匿名”二字，设置匿名提问将付出相应的积分。 <span
                                                class="padd10">
                                                <br />
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="f14B" valign="top">
                                            <b>E:</b></td>
                                        <td align="left" class="f14black3">
                                            点击页面底端的“提交问题”按钮并确认，ok，您的问题便提交成功。</td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <span class="p2">请注意您的提问不要违背“<a href="#gui">拼搏吧相关规定</a>”的内容，否则提问将被管理员删除，并扣除<%=wenkf%>积分，情节严重者，</span><span
                                class="f14">“拼搏在线”有权对其做出关闭部分权限、暂停直至删除其帐号等处罚。</span>
                            <br />
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="1" bgcolor="#dddddd">
                                    </td>
                                </tr>
                            </table>
                            <p>
                                <strong>等待答复</strong>（剩下的，就等着热心网友来解答您的问题吧。）<br />
                                <br />
                                查看您的提问，可以有以下途径：<br />
                                1. 到“我的拼搏吧”或“用户中心”的“我的提问”进行查看，这是比较方便快捷的方法；<br />
                                2. 到您的提问所在的分类浏览查找；<br />
                                3. 在页面顶端的搜索框内输入您的提问标题或关键字，进行搜索。<br />
                            </p>
                            <div align="right">
                                <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;如何回答<a name="ans" id="ans"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table4">
                                <tbody>
                                    <tr>
                                        <td align="left" class="f14black3">
                                            <table align="right" border="0" id="table5">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table6">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="center">
                                                                                <img height="247" src="images/zhidao2.gif" width="340"></div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <p>
                                                A: 浏览问题页面时，您可以直接进行回答； 对一个问题，您只能回答一次；在问题转入已解决状态前，您可以修改您的回答。<br />
                                                <br>
                                                B: 如果您的回答内容参照了其他书籍, 网页等他人文章,请务必标明出处；如有知识产权等纠纷, 需回答者本人承担相应法律责任。<br />
                                                <br>
                                                <strong>查看您的回答，有如下途径：</strong><br>
                                                <span class="p2">1. </span>到“我的拼搏吧”或“用户中心”的“我的回答”进行查看，这是比较方便快捷的方法；<br>
                                                <span class="p2">2. </span>到您回答的问题所在的分类浏览查找；<br>
                                                <span class="p2">3. </span>在页面顶端的搜索框内输入您回答的问题的标题或关键字，进行搜索</p>
                                            <p class="f14">
                                                <span class="p2">请注意您回答不要违背“<a href="#gui">拼搏吧相关规定</a>”的内容，否则回答将被编辑删除，并扣除<%=dakf%>分，情节严重者，
                                                    “拼搏吧”有权对其做出关闭部分权限、暂停直至删除其帐号等处罚。</span>
                                                <div align="right">
                                                    <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                                                </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;如何处理问题<a name="chu" id="chu"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            提问后，请您切记在<%=Overdue%>天内处理您的问题，否则将辜负回答您问题的热心网友，作为惩罚，我们会扣除您<%=gqkf%>积分，您可以有如下选择：<br>
                            <br>
                            1.<strong>采纳答案：</strong>选择一个您最满意的回答为最佳答案，结束提问；<br>
                            &nbsp;&nbsp;&nbsp;1）被采纳的回答就被您选为问题的答案；这时问题的状态变为“已解决”；<br>
                            &nbsp;&nbsp;&nbsp;2）回答被提问者采纳为最佳答案，回答者可获得系统自动赠送的<%=dajiadf%>分＋提问者设置的悬赏积分。<br />
                            &nbsp;<br>
                            2.<strong>问题补充：</strong>可以对您的提问补充细节，以得到更准确的答案；<br>
                            <br>
                            3.<strong>提高悬赏：</strong>提高悬赏积分，以提高问题的关注度，此时：<br>
                            &nbsp;&nbsp;&nbsp;1）当您提高悬赏积分后，系统将立即从您的积分中扣除您选择的分值，同时该问题的悬赏分相应增加您选择的分值<br />
                            &nbsp; &nbsp;2）提高悬赏积分能提高该问题的关注程度。
                            <br />
                            <br>
                            4.<strong>无满意回答：</strong>当您觉得没有满意的回答，还可直接结束提问，关闭问题。<br>
                            &nbsp;&nbsp;&nbsp;<a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;问题为何被关闭<a name="colse" id="colse"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <br />
                            1. 如果提问者在<%=Overdue%>天内没有处理问题,则问题会过期并被系统自动关闭.。<br>
                            2. 如果提问者对某问题选择无满意答案，则该问题被系统自动关闭。
                            <div align="right">
                                <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;过期问题<a name="pass" id="pass"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <br />
                            1. 如果提问者在<%=Overdue%>天内没有处理问题,则问题会过期并被系统自动关闭.。<br />
                            <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;如何获得积分<a name="point" id="points"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <p>
                                “拼搏吧”里的积分就像游戏里的积分，您会付出积分，也会获得积分。积分可以在提问时用来悬赏，您也会随着积分增加而晋级并获得更高的头衔。</p>
                            <p>
                                “拼搏吧”的具体积分得失规则如下：</p>
                            <p>
                                <strong>积分增加:</strong></p>
                            <center>
                                <table width="80%" border="0" align="center" cellpadding="3" cellspacing="1" bgcolor="#e1e1e1">
                                    <tbody>
                                        <tr bgcolor="#fdfadf">
                                            <td width="18%" height="19" align="left" bgcolor="#fdfadf">
                                                <strong>操作</strong></td>
                                            <td width="18%" height="19" align="left">
                                                <strong>获得积分数</strong></td>
                                            <td width="64%" height="19" align="left" bgcolor="#fdfadf">
                                                <strong>说明</strong></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td height="30" colspan="3" align="left">
                                                <strong>日常操作</strong></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="left">
                                                <span>新用户首次登录</span></td>
                                            <td align="left">
                                                <span>＋<%=regf%></span></td>
                                            <td align="left" valign="top">
                                                <span>完成帐户的激活</span></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td height="30" colspan="3" align="left">
                                                <strong>回答</strong></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="left">
                                                <span>提交回答</span></td>
                                            <td align="left">
                                                <span>＋<%=dadf%></span></td>
                                            <td align="left" valign="top">
                                            </td>
                                        </tr>
                                        <tr valign="top" bgcolor="#ffffff">
                                            <td align="left">
                                                <span>回答被采纳为最佳答案</span></td>
                                            <td align="left">
                                                <span>＋<%=dajiadf%><br>
                                                    ＋悬赏积分</span></td>
                                            <td align="left">
                                                <span>回答被提问者采纳为最佳答案，回答者可获得系统自动赠送的<%=dajiadf%>分＋提问者设置的悬赏积分</span></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td height="30" colspan="3" align="left">
                                                <strong>奖励</strong></td>
                                        </tr>
                                        <tr valign="top" bgcolor="#ffffff">
                                            <td align="left">
                                                <span>问题被选为精华推荐</span></td>
                                            <td align="left">
                                                <span>提问者：＋<%=tjwendf%><br>
                                                    最佳回答者：＋<%=tjdadf%><br>
                                                </span>
                                            </td>
                                            <td align="left">
                                                <span>当一个问题提问和回答都足够精彩，会被编辑推荐到首页的精华推荐，届时会给予提问者和最佳回答者积分奖励</span></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </center>
                            <p>
                                <strong>积分降低:</strong></p>
                            <center>
                                <table width="80%" border="0" align="center" cellpadding="3" cellspacing="1" bgcolor="#e1e1e1">
                                    <tbody>
                                        <tr bgcolor="#fdfadf">
                                            <td width="18%" align="left" bgcolor="#fdfadf">
                                                <strong>操作</strong></td>
                                            <td width="18%" align="left" bgcolor="#fdfadf">
                                                <strong>降低积分数</strong></td>
                                            <td width="64%" align="left" bgcolor="#fdfadf">
                                                <strong>说明</strong></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td colspan="3" align="left">
                                                <strong>提问</strong></td>
                                        </tr>
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                悬赏付出</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                悬赏积分</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                提问用户在设置悬赏或追加悬赏后，系统将扣除相应积分。
                                            </td>
                                        </tr>
                                        <tr valign="top" bgcolor="#ffffff">
                                            <td align="left">
                                                匿名提问</td>
                                            <td align="left">
                                                －<%=mdf%></td>
                                            <td align="left">
                                                提问用户采用匿名方式提交问题，扣除<%=mdf%>分悬赏</td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td colspan="3" align="left">
                                                <strong>处罚</strong></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="left">
                                                提问上线后被删除</td>
                                            <td align="left">
                                                －<%=wenkf%></td>
                                            <td align="left" valign="top">
                                                提问上线后，被管理员删除，扣除提问用户<%=wenkf%>分，答复者不扣</td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="left">
                                                回答上线后被删除</td>
                                            <td align="left">
                                                －<%=dakf%></td>
                                            <td align="left" valign="top">
                                                回答上线后，被管理员删除，扣除回答用户<%=dakf%>分</td>
                                        </tr>
                                        <tr valign="top" bgcolor="#ffffff">
                                            <td align="left">
                                                问题<%=Overdue%>天内不处理</td>
                                            <td align="left">
                                                －<%=gqkf%></td>
                                            <td align="left">
                                                问题到期，提问用户不作处理（不做最佳答案判断、不关闭问题），扣除提问用户<%=gqkf%>分</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </center>
                            <br>
                            <div align="right">
                                <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            <a name="n5" id="n5"></a>&nbsp;关于头衔<a name="title" id="title"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <br>
                            每个用户都会有自己的积分、等级和头衔。您可以通过问答等操作不断增加积分，同时您的等级和头衔也会随积分不断晋升。
                            <p>
                            </p>
                            <p>
                                <strong>拼搏吧的头衔设置 </strong>
                            </p>
                            <center>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <table cellspacing="1" cellpadding="5" width="80%" bgcolor="#e1e1e1" border="0">
                                            <tr bgcolor="#fdfadf">
                                                <td width="19%" bgcolor="#fdfadf">
                                                    <strong>等级</strong></td>
                                                <td width="38%" bgcolor="#fdfadf">
                                                    <strong>积分</strong></td>
                                                <td width="43%" bgcolor="#fdfadf">
                                                    <strong>头衔</strong></td>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr bgcolor="#ffffff">
                                            <td>
                                                (<%# Container.ItemIndex + 1%>)
                                            </td>
                                            <td>
                                                <%#Eval("MinPoint")%>
                                                －<%#Eval("MaxPoint")%></td>
                                            <td>
                                                <%#Eval("GradeName")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table></FooterTemplate>
                                </asp:Repeater>
                            </center>
                            <p class="f14">
                                <div align="right">
                                    <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                                </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;如何避免问答被删<a name="cannl" id="cannl"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <br>
                            要避免问答、评论被删除，请注意您的提问、回答或评论不违反“<a href="#gui">拼搏吧相关规定</a>”，凡文章出现以下情况之一，“拼搏吧”管理人员有权不提前通知用户直接删除，并依照有关规定作相应处罚，情节严重者，“拼搏吧”有权对其做出关闭部分权限、暂停直至删除其帐号的处罚。<br>
                            <div align="right">
                                <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="left" bgcolor="#e5ecf9" class="f14blackB">
                            &nbsp;拼搏吧相关规定<a name="gui" id="gui"></a></td>
                    </tr>
                    <tr>
                        <td align="left" class="f14black3">
                            <br>
                            欢迎光临<%=WebTitle%>，请您仔细阅读以下条款，如果您对本协议的任何条款表示异议，您可以选择不进入<%=WebTitle%>，您进入<%=WebTitle%>，则意味着您将自愿遵守以下规则，并完全服从于的统一管理。
                            <p>
                                <strong>一 “拼搏吧”礼仪</strong></p>
                            <span class="p2">
                                <lu>
                            </span>
                            <ol>
                                <li>标题要正确<br>
                                    在提问或答复的时候不要写无意义或模糊的题目，为了别人解答时理解的方便请正确书写标题。
                                    <li>对问题进行具体的说明<br>
                                        在提问或答复的时候，内容要具体详细地书写，问题内容越详细别人的答复也就越正确，答复越详细也就越让人容易理解。
                                        <li>检查问题是否重复<br>
                                            在提问之前，请先对问题进行搜索，或者在提问的时候，先关注一下提问页面右侧的“相关问题”列表，其中是否已经有过得到解决的类似问题，在确认没有令您满意的答案后再提问。
                                            <li>检查问题的分类是否正确<br>
                                                提交问题之前请确认问题的分类是否正确，提问的正确归类可以让您更快地得到满意的回答。
                                                <li>及时处理问题<br>
                                                    在提问后的<%=Overdue%>天之内，如果有满意的答复一定要作出选择，以免伤害热心回答的网友；如果有答案而过期不对问题进行处理，我们将扣除您分的积分以示惩戒。具体方法参见<a
                                                        href="#chu" class="Link_Xia">如何处理问题</a>。</li>
                                                <li>互相尊重<br>
                                                    提问者提问时的语气请尽量友好，避免给他人以责问、逼问的不良感受。回答者在答复时候也不要小看或嘲笑提问者，要有诚意地解答，正确地书写。
                                                    <br>
                                                    在我们的共同努力下，“拼搏吧”一定能成为充满温馨和智慧的拼搏知识社区！ </li>
                            </ol>
                            <p>
                                <strong>二 审核与处罚</strong></p>
                            <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td class="f14black3">
                                            <strong>1&nbsp;&nbsp;&nbsp;作弊行为与处罚方法</strong><br>
                                            1）作弊的定义<br>
                                            通过非公平不正当途径获取积分。对于作弊行为的判断，拼搏在线保留最终解释权<br>
                                            2) 作弊的处罚
                                            <br>
                                            ·作弊行为一经确认，涉及该作弊行为的所有相关用户的登录帐号将被酌情扣分和有限期封禁，情节严重者会被永久封禁。
                                            <br>
                                            ·涉及作弊行为的提问者的所有提问将被严肃处理，情节严重者会被删除提问。
                                            <p>
                                                <strong>2&nbsp;&nbsp;&nbsp;问答、评论删除原则与处罚方法</strong></p>
                                            1）问题、回答和评论的删除原则
                                            <br>
                                            凡符合下列任何情况的提问、回答或评论，都将被删除<br>
                                            A．具有广告性质<br>
                                            ·为了增加流量而故意引导他人到某个网站或论坛<br>
                                            ·为某盈利性的组织或个人广告
                                            <br>
                                            ·从事任何物品（包括虚拟物品，如虚拟货币等）的交易<br>
                                            ·宣传、发展传销活动<br>
                                            ·提供符合上述特点的链接<br>
                                            <br>
                                            B．含有反动内容<br>
                                            ·恶意评价国家现行制度<br>
                                            ·破坏社会公共秩序<br>
                                            ·挑起民族、种族、宗教、地域等争端<br>
                                            ·恶意攻击政府机构与政府官员<br>
                                            ·宣传政治<br>
                                            ·提供符合上述特点的链接<br>
                                            <br>
                                            C．含有人身攻击内容<br>
                                            ·诽谤他人，散布虚假信息<br>
                                            ·侵犯他人肖像权、隐私权等其他合法权益<br>
                                            ·用粗言秽语侮辱他人，造成身心伤害
                                            <br>
                                            ·损害社会团体或组织的名誉<br>
                                            ·提供符合上述特点的链接<br>
                                            <br>
                                            D．含有违背伦理道德内容<br>
                                            ·包含违反社会公共道德的内容<br>
                                            ·宣扬颓废、消极的人生观<br>
                                            ·劝诱自杀，描写自杀方法和过程<br>
                                            ·歧视和贬低弱势群体，如残疾、老龄和经济状况较差等<br>
                                            ·教授侵犯他人权益的方法，如黑客、诈骗等
                                            <br>
                                            ·宣传或劝诱师生恋、外遇等违反伦常的行为<br>
                                            ·包含其他可能导致他人反感或不快内容的<br>
                                            ·提供符合上述特点的链接<br>
                                            <br>
                                            E．具有恶意、无聊和灌水性质<br>
                                            ·出现真实姓名（非公众人物）和提供电话号码的提问和回答<br>
                                            ·具有聊天、寻人、征友等特点的提问<br>
                                            ·直接索取作文、论文或作业答案的提问<br>
                                            ·标题和补充中提供的信息不足以构成一个问题的提问<br>
                                            ·问答或评论内容包含有严重影响网友浏览的内容或格式<br>
                                            ·短时间内多次重复的提问<br>
                                            ·同一内容被用作多个提问的答复，且完全不针对提问<br>
                                            ·没有任何意义的提问和回答<br>
                                            ·其他可判断为灌水的无价值内容<br>
                                            <br>
                                            F. 涉及违法犯罪的内容 ·宣扬刑事犯罪<br>
                                            ·引诱或召集聚众赌博<br>
                                            ·宣扬行贿受贿<br>
                                            ·行骗欺诈<br>
                                            ·其他违反我国法律法规的行为<br>
                                            ·提供符合上述特点的链接
                                            <br>
                                            <br>
                                            G．其他拼搏在线认为不恰当的情况<br>
                                            <br>
                                            2）相应处罚方法<br>
                                            ·问题被删除后，提问者的积分将被扣除<%=wenkf%>分。<br>
                                            ·回复被删除后，回答者的积分将被扣除<%=dakf%>分。<br>
                                            ·由于问题被删除而导致的回复删除不单独扣分。<br>
                                            ·情节严重者，将酌情对其进行加倍扣分、有限期封禁和永久封禁等处罚。<br>
                                            <br>
                                            3&nbsp;&nbsp;&nbsp;对帐号的管理原则<br>
                                            凡含有下列行为之一者，“拼搏吧”有权删除其相应帐号，情节严重者，将酌情封禁对应IP<br>
                                            ·模仿拼搏吧管理人员ID，用以假冒管理人员或破坏管理人员形象<br>
                                            ·模仿或盗用他人ID<br>
                                            ·个人签名包含有严重影响网友浏览的内容或格式<br>
                                            ·其他拼搏在线认为不恰当的情况
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <p>
                                <strong>三 对“拼搏吧”用户和第三方的知识产权的保护</strong></p>
                            <p>
                                一、用户不能侵犯包括他人的著作权在内的知识产权以及其他权利。一旦由于用户的相关发布内容而产生知识产权问题，其责任在于用户本人。</p>
                            <p>
                                1、未得到著作者的同意对他人的著作物进行全部或部分的复制，传播，拷贝，有可能侵害到他人的著作权时，不要把相关内容复制刊登上来。</p>
                            <p>
                                2、用户可以对著作物进行报道，批评，教育，研究，在正当的范围内可以对其引用，但是一定要标明其出处。但是在引用的时候不允许侵犯著作者的人格，这种情况即使标明出处也看作是侵犯著作权。</p>
                            <p>
                                二、用户的言论侵犯了第三方的著作权或其他权利，第三方提出异议的时候，有权删除相关的内容，提出异议者和帖子发表者之间结束解决了诉讼、协议等相关法律问题后，以此为依据，在得到有关申请后可以恢复被删除的内容。</p>
                            <p>
                                三、用户发布的信息在没有得到事先许可的情况下，个人或提供给第三方利用复制、发送、传播等手段用于盈利目的时，将追究相关当事人的法律责任。</p>
                            <p>
                                四、当第三方要使用用户的提问、回答或评论的时候一定要事先从相关用户那里得到同意后才能使用。</p>
                            <p>
                                五、不能对用户发表的回答或评论的正确性进行保证。</p>
                            <p>
                                六、其它不符合法律法规的不能发表。</p>
                            <p>
                                七、其它不符合拼搏在线相关规定的不能发表。</p>
                            <strong>四 拼搏在线对原则内容拥有最终解释权</strong>
                            <div align="right">
                                <a href="#Top" class="Linl14 Link_Xia">返回顶端</a>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <uc1:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
