<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ParticiPation.aspx.cs"
    Inherits="Pinble_Chipped.ParticiPation" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>��������</title>
<%--    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
    <meta name="author" content="" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="Css/detail.css" rel="stylesheet" type="text/css" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="loginCss/css.css" rel="stylesheet" />
    <link href="Css/footer.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.tablepanl{
border:1px solid #b4d8fc;
border-top:none;
text-align:center;
}
.tablepanl td{height:30px; border:0}
</style>

       <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
     <script type="text/javascript" src="js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" charset="gb2312" src="js/login.js?date=new date().gettime()"></script>

    <script type="text/javascript" src="js/SearchAjax.js"></script>
    <script type="text/javascript" charset="gb2312" src="js/Apply.js"></script>

    <script type="text/javascript">
    function display()
    {
        var hidden=document.getElementById("hidden");
        //ѭ�����
    }
    function money() {

        //���������=ʣ�����
        if (parseInt($("#setbeishu").val()) >parseInt($("#lab_surplusNum").text())) {
            alert('���������� ' + $("#lab_surplusNum").text() + " ��");
            $("#setbeishu").attr("value", $("#lab_surplusNum").text());
        }

        $("#permoney").html(Math.round(($("#setbeishu").val() * $("#shareMoney").val()) * 100) / 100);
    }
    //��ȡurl��ַ����ֵ
    function GetRequest()   
    {   
        var url = location.search; //��ȡurl��"?"������ִ�   
        var theRequest = new Object();   
        if(url.indexOf("?") != -1)   
        {   
          var str = url.substr(1);   
            var strs = str.split("&");   
          for(var i = 0; i < strs.length; i ++)   
            {   
             theRequest[strs[i].split("=")[0]]=unescape(strs[i].split("=")[1]);   
            }   
        }   
        return theRequest;   
    }
    //��ʾ��� user_balance
    function disM() {
        $("#balance").html($("#user_balance").val());
    }

    $(document).ready(function () {
        money();
        //��ȡurl�е� lottery����
        var Request = new Object();
        Request = GetRequest();
        var lottery = Request['lottery'];
        //�жϲ���
        if (lottery == 1) {
            //3D
            $("#lottery").css("background-position", "0 -450px");
            $("#lotteryName").html("����3D");
        }
        if (lottery == 3) {
            //˫ɫ��
            $("#lottery").css("background-position", "0 -1px");
            $("#lotteryName").html("˫ɫ��");
        }
        //���ֲ�
        if (lottery == 2) {
            $("#lottery").css("background-position", "0 -900px");
            $("#lotteryName").html("���ֲ�");
        }
        //����5
        if (lottery == 4) {
            $("#lottery").css("background-position", "0 -600px");
            $("#lotteryName").html("������");
        }
        //���ǲ�
        if (lottery == 5) {
            $("#lottery").css("background-position", "0 -975px");
            $("#lotteryName").html("���ǲ�");
        }
        //����͸
        if (lottery == 6) {
            $("#lottery").css("background-position", "0 -225px");
            $("#lotteryName").html("����͸");
        }
        //        //22ѡ5
        //        if (lottery == 6) {
        //            $("#lottery").css("background-position", "0 -225px");
        //            $("#lotteryName").html("22ѡ5");
        //        }
        $("#permoney").html(Math.round(($("#setbeishu").val() * $("#shareMoney").val()) * 100) / 100);
        //�ж��Ƿ��¼
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/username",
            data: "{}",
            dataType: "json",
            complete: function (result) {
                if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                    //$("#userMoneyInfo").html("����δ��¼������<span id='aloginShow' style=\"cursor: pointer; color: #003399;\"><a href=\"#\">��¼</a>&nbsp;</span> <span id=\"spUser\"></span>   <a href=\"<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx\" id='aNewUserReg' target=\"_blank\">&nbsp;�û�ע��</a><a href=\"#\" id='aLoginOut' style=\"display: none;\">&nbsp;�˳�</a>��");
                }
                else {
                    $("#userMoneyInfo").html("�û�<font color='red'> " + result.responseText.split('"')[1].split('"')[0] + "</font>�ѵ�¼  �����˻����Ϊ��<span id='balance'>******</span>Ԫ<a id='ckmoney' onclick='disM()' href='javascript:void(0)'>   ��ʾ���</a>");
                }
            }
        });

        //����
        $("#submitCaseBtn3").click(function () {
            //�ж��Ƿ��¼
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../WebChipped.asmx/username",
                data: "{}",
                dataType: "json",
                complete: function (result) {
                    if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                        alert('��û�е�¼�����ȵ�½');
                        return false;
                    }
                    else {
                        //����ķ����Ƿ�Ϸ�
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "WebChipped.asmx/shareNum",
                            data: "{num:'" + $("#setbeishu").val() + "',Qnum:'" + $("#Number").val() + "'}",
                            dataType: "json",
                            complete: function (result) {
                                if (result.responseText == 1) {

                                    alert('����������ϣ�');
                                    return false;
                                    //
                                }
                                if (result.responseText == 2) {
                                    alert('ʣ���������');
                                    history.go(0);
                                    return false;
                                }
                                if (result.responseText == 3) {
                                    //����
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json",
                                        url: "WebChipped.asmx/ChippedAdd",
                                        data: "{Qnum:'" + $("#Number").val() + "',share:'" + $("#setbeishu").val() + "'}",
                                        dataType: "json",
                                        complete: function (result) {
                                            if (result.responseText == 0) {
                                                alert('�µ�ʧ��');
                                                return false;
                                            }
                                            if (result.responseText == 1) {
                                                alert('�µ��ɹ�');
                                                parent.$.XYTipsWindow.removeBox();
                                                history.go(0);
                                                return false;
                                            }
                                            if (result.responseText == 2) {
                                                alert('��������֧�����ι�������ȳ�ֵ');
                                                return false;
                                            }
                                            if (result.responseText == 3) {
                                                alert('�µ��ɹ�');
                                                $.ajax({
                                                    type: "POST",
                                                    contentType: "application/json",
                                                    url: "../WebChipped.asmx/selectDrawer",
                                                    data: "{Qnum:'" + $("#Qnum").val() + "'}",
                                                    dataType: 'json',
                                                    complete: function (result) {
                                                    }
                                                });
                                                parent.$.XYTipsWindow.removeBox();
                                                history.go(0);
                                                return false;
                                            }
                                        }
                                    });
                                }
                            }
                        });

                    }
                }
            });
        });

    });
    function switching(obj)
    {
        if(obj=='joinCount')
        {
            document.getElementById("joinCount").className="an_cur";
            document.getElementById("show_list_div").style.display="block";
            document.getElementById("meyBuy").className="";
            document.getElementById("IBuy").style.display="none";
        }
        if(obj=='meyBuy')
        {
         //�ж��Ƿ��¼
            $.ajax({
                type:"POST",
                contentType: "application/json",
                url:"../WebChipped.asmx/username",
                data:"{}",
                dataType:"json",
                complete:function(result){
                    if(result.responseText.split('"')[1].split('"')[0]==0 || result.responseText=="" || result.responseText==null)
                    {
                        alert('��û�е�¼�����ȵ�½');
                        return false;
                    }
                    else
                    {
                        document.getElementById("joinCount").className="";
                        document.getElementById("show_list_div").style.display="none";
                        document.getElementById("meyBuy").className="an_cur";
                        document.getElementById("IBuy").style.display="block";
                    }
                }
            });
            
        }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="divLogin" style="display: none; cursor: default;">
                <table width="350" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="40" style="background: url(image/login1.jpg)">
                            <table width="98%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%">
                                    </td>
                                    <td width="5%">
                                        <img style="cursor: pointer;" src="image/close.gif" width="15" height="15" id="btnCancelMeng"
                                            alt="" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="160" valign="middle" style="background: url(image/login2.jpg)">
                            <table width="85%" border="0" align="center" cellpadding="4" cellspacing="0" height="145">
                                <tr>
                                    <td colspan="2" height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="23%" align="right">
                                        �û�����</td>
                                    <td width="77%" align="left">
                                        <input type="text" id="txtUsername" maxlength="12" style="width: 150px;" />&nbsp;<a
                                            style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx"
                                            tabindex='-1'>���ע��</a></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        �� &nbsp;�룺</td>
                                    <td align="left">
                                        <input id="txtPassword" type="password" maxlength="16" style="width: 150px;" />&nbsp;<a
                                            style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx" target="_blank" tabindex='-2'>�����һ�</a></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        ��֤�룺</td>
                                    <td align="left">
                                        <input type="text" id="txtCode" maxlength="4" style="width: 50px;" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
                                        <img src="/publicPage/VerifyCode.aspx" align="top" alt="�����壿��������������ִ�Сд��" id="imgVerify"
                                            onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: hand;" />
                                        <img alt="��ȷ" src="image/note_ok.gif" id="imgOKH" style="display: none;" />
                                        <img alt="����" src="image/note_error.gif" id="imgErrorH" style="display: none;" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;&nbsp;&nbsp;
                                        <input type="button" id="btnLogin" class="HeadLogin" />
                                        &nbsp;
                                        <input type="button" id="imgReset" class="HeadReset" />
                                        &nbsp;&nbsp;<input type="checkbox" id="cbState" title="�����ҵĵ�¼״̬" />�����¼״̬
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../image/login3.jpg" width="350" height="13" alt="" /></td>
                    </tr>
                </table>
            </div>
        <div id="doc" class="cp_3d">
            <div class="b-top">
                <div class="b-top-inner">
                    <h2 id="lottery">
                     </h2>
                    <div class="b-top-info">
                        <a href="javascript:void(0)" title="" class="on">��ǰ<%=ExpectNum%>��</a><span>�̶������淨�򵥣�ÿ��20��30������
                        </span>
                    </div>
                    <dl class="b-top-nav">
                        <dt><span id="lotteryName"></span>&nbsp;&nbsp;&nbsp;&nbsp;��<span id="ExpectNum" style="color:Black"><%=ExpectNum%></span>  �� ���򷽰� </dt>
                        <dd id="playTabsDd">
                            <a href="avascript:void(0);" title="" class="on"><em>����������Ϣ</em></a></dd>
                    </dl>
                    <div class="b-top-tips">
                        <div class="b-top-ql">
                            .
                        </div>
                        <div class="b-top-time">
                            ��ֹʱ�䣺 <span id="endtimeSpan"><%=endTime %></span> <span id="countDownSpan">��ʣ
                                <span id="_lefttime" style="color: Red"></span></span>

                            <script type="text/javascript">
                                function _fresh()
                                {
                                    //����ʱ��ȡ�����ļ��е�����                                    
                                    var endtime = new Date("<%=endTime %>".replace(/-/g, "/")); 
                                    
                                    var nowtime = new Date();
                                    var leftsecond=parseInt((endtime.getTime()-nowtime.getTime())/1000);
                                    if(leftsecond<0){leftsecond=0;}
                                    __d=parseInt(leftsecond/3600/24);
                                    __h=parseInt((leftsecond/3600)%24);
                                    __m=parseInt((leftsecond/60)%24);
                                    __s=parseInt(leftsecond%60);
                                    __all = __d+"��"+__h+"Сʱ"+__m+"��"+__s+"��";
                                    document.getElementById("_lefttime").innerHTML=__all;
                                    
                                }
                                    _fresh()
                                    setInterval(_fresh,1000);
                            </script>

                        </div>
                    </div>
                </div>
            </div>
            <div id="main">
                <div class="box_top">
                    <div class="box_top_l">
                    </div>
                </div>
                <div class="box_m">
                    <div id="xx1">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="buy_table">
                            <tr>
                                <td class="td_title2">
                                    ��������Ϣ</td>
                                <td class="con_content">
                                    <div class="detail_d">
                                        <p>
                                            <span class="m_r50 record"><a href="#">
                                                <asp:Label ID="lab_name" runat="server"></asp:Label></a></span> <span class="m_r50">
                                                    <a href="#">�鿴���������к����¼</a></span><span class="m_r50"><a href="javascript:void(0)" onclick="attention()">��ע������</a> </span>
                                        </p>
                                        <%--                                    <p class="gray">
                                        <span id="zjinfo">���н�������<span class="black"><span id="cnt">34783</span>��</span><br />
                                            ���н���<span class="red eng" id="after_bonus">23423423</span>Ԫ
                                            <br />
                                        </span>
                                    </p>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title2">
                                    ������Ϣ</td>
                                <td class="con_content">
                                    <div id="fanandiv" class="tdbback" style="width: 625px;">
                                        <table cellspacing="0" cellpadding="0" border="0" width="100%" class="tablelay eng">
                                            <asp:Repeater ID="myRep_info" runat="server" OnItemDataBound="myRep_info_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <th>
                                                            �ܽ��</th>
                                                        <th>
                                                            ����</th>
                                                        <th>
                                                            ����</th>
                                                        <th>
                                                            ÿ��</th>
                                                        <th>
                                                            ���������</th>
                                                        <th>
                                                            ����</th>
                                                        <th class="last_th">
                                                            �������</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="last_tr">
                                                        <td>
                                                            <span class="red eng">��<%# Eval("AtotalMoney")%></span>Ԫ</td>
                                                        <td>
                                                            <%# Eval("doubles")%>
                                                            ��</td>
                                                        <td>
                                                            <%# Eval("Share")%>
                                                            ��</td>
                                                        <td>
                                                           <font color="red"> ��<%# (Convert.ToDecimal(Eval("AtotalMoney")) / Convert.ToInt32(Eval("Share"))).ToString("0.##")%> </font>Ԫ</td>
                                                        <td>
                                                            <span class="red eng">
                                                                <%# Eval("commission") %>
                                                                %</span></td>
                                                        <td>
                                                            <%# Convert.ToInt32(Eval("Protect")) %> ��</td>
                                                        <td class="last_td">
                                                            <span class="red eng">
                                                                <asp:Label ID="lab_jindu" runat="server"></asp:Label>%</span>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title2 p_tb8">
                                    ��������</td>
                                <td class="con_content p_tb8">
                                    <p>
                                        <asp:Label ID="lab_display" runat="server"></asp:Label><a href="javascript:display();"><label
                                            id="displayHidden" runat="server" class="dis">��ʾȫ��</label>
                                        </a>
                                        <div id="hidden" style="display: none">
                                            <asp:Label ID="lab_hidden" runat="server"></asp:Label>
                                        </div>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title2">
                                    ��Ҫ�Ϲ�</td>
                                <td class="con_content">
                                    <div class="buy_btn">
                                        <input id="submitCaseBtn3" type="button" class="btn_buy_m" />
                                    </div>
                                    <div id="userMoneyInfo">
                                    ����δ��¼������<span id='aloginShow' style="cursor: pointer; color: #003399;"><a href="#">��¼</a>&nbsp;</span>
                            <span id="spUser"></span>   <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx" id='aNewUserReg' target="_blank">
                            &nbsp;�û�ע��</a>  <a href="#" id='aLoginOut' style="display: none;">&nbsp;�˳�</a>
                                    </div>
                                    �������Ϲ� <span class="red eng">
                                        <asp:Label ID="lab_surplusNum" runat="server"></asp:Label></span> �ݣ���Ҫ�Ϲ�
                                    <input type="text" size="5" name="setbeishu" id="setbeishu" onkeyup="this.value=this.value.replace(/[^\d]/g,'');money();" onbeforepaste="BeforePaste();"
                                        value="1" />
                                    �� �ܽ��<span class="red eng">��</span><span class="red eng" id="permoney"></span>Ԫ
                                    <p class="read">
                                        <span class="hide_sp">
                                            <input type="checkbox" checked="checked" id="agreement" value="1" /></span>�����Ķ���ͬ�⡶<a
                                                href="Agreement.aspx" target="_blank">�û��������Э��</a>��</p>
                                    <input type="hidden" value="1" id="agreement2" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="xx2">
                        <div class="det_g_t">
                            ����������Ϣ</div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="buy_table">
                            <tr>
                                <td class="td_title2">
                                    ��������</td>
                                <td class="con_content">
                                    <div class="detail_d clearfix">
                                        <%--                                    <div class="copy_link">
                                        <a href="javascript:void(0);" onclick="copyurl('www.pinble.com')" class="public_Lblue"
                                            id="copystr"><b>������Ʒ�����ַ</b></a></div>--%>
                                        <p class="gray">
                                            �������⣺<asp:Label ID="lab_title" runat="server"></asp:Label><br />
                                            
                                        </p>
                                        <p class="gray">
                                            ����������<asp:Label ID="lab_say" runat="server"></asp:Label><br />
                                        </p>
                                        <%--                                    <div class="add_div">
                                        <span class="shouc_box"><span class="ttitle">��������</span></span>
                                        <div class="C-shareUrl">
                                            <a id="C_share_tao" href="#" target="_blank" title="�����Խ���">
                                                <img src="images/x6.png" />
                                                �Խ���</a> <a id="C_share_sina" href="#" target="_blank" title="��������΢��">
                                                    <img src="images/x5.gif" />
                                                    ����΢��</a> <a id="C_share_tc" href="#" target="_blank" title="������Ѷ΢��">
                                                        <img src="images/x7.png" />
                                                        ��Ѷ΢��</a> <a id="C_share_qzone" href="#" target="_blank" title="����QQ�ռ�">
                                                            <img src="images/x2.gif" />
                                                            QQ�ռ�</a> <a id="C_share_douban" href="#" target="_blank" title="��������">
                                                                <img src="images/x1.png" />
                                                                ����</a> <a id="C_share_ren" href="#" target="_blank" title="����������">
                                                                    <img src="images/x4.gif" />
                                                                    ������</a> <a id="C_share_kai" href="#" target="_blank" title="����������">
                                                                        <img src="images/x3.gif" />
                                                                        ������</a></div>
                                    </div>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr class="last_tr">
                                <td class="td_title2">
                                    �����û�</td>
                                <td class="con_content">
                                    <p style="word-wrap: break-word; width: 500px; overflow: hidden;">
                                        <asp:Label ID="lab_open" runat="server"></asp:Label></p>
                                    <div class="yh_tab">
                                        <ul class="clearfix" id="My_buy">
                                            <li id="joinCount" class="an_cur"><a href="javascript:void(0)" onclick="switching('joinCount')">�ܲ�������</a>  </li>
                                            <li id="meyBuy" class=""><a href="javascript:void(0)" onclick="switching('meyBuy')">�����Ϲ���¼</a></li>
                                        </ul>
                                    </div>
                                    <div id="show_list_div">
                                        <table width="100%" border="0" class="tablepanl">
                                            <asp:Repeater ID="myRep_Chipped" runat="server" OnItemDataBound="myRep_Chipped_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr style="height: 33px; line-height: 33px; color: #4f5152; font-weight: normal;
                                                        background: url(images/hm_th_bg1.png) repeat-x;">
                                                        <td>
                                                            �û���
                                                        </td>
                                                        <td>
                                                            �Ϲ�����
                                                        </td>
                                                        <td>
                                                            �Ϲ����
                                                        </td>
                                                        <td>
                                                            ����ʱ��
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#dff0f4"%>'>
                                                        <td>
                                                            <%# Eval("ChippedName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedShare") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_money" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedTime") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <asp:Label ID="litContent" runat="server"></asp:Label><td colspan="4">
                                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" OnPageChanged="AspNetPager1_PageChanged"
                                                        PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="IBuy" style=" display:none;">
                                         <table width="100%" border="0" class="tablepanl">
                                            <asp:Repeater ID="rep_IBuy" runat="server" OnItemDataBound="rep_IBuy_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr style="height: 33px; line-height: 33px; color: #4f5152; font-weight: normal;
                                                        background: url(images/hm_th_bg1.png) repeat-x;">
                                                        <td>
                                                            �û���
                                                        </td>
                                                        <td>
                                                            �Ϲ�����
                                                        </td>
                                                        <td>
                                                            �Ϲ����
                                                        </td>
                                                        <td>
                                                            ����ʱ��
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#dff0f4"%>'>
                                                        <td>
                                                            <%# Eval("ChippedName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedShare") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_BuyMoney" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedTime") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <asp:Label ID="litContentBuy" runat="server"></asp:Label><td colspan="4">
                                                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" OnPageChanged="AspNetPager2_PageChanged"
                                                        PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
        <%--ÿ�ݵļ۸�--%>
        <input id="shareMoney" type="hidden" value="<%=shareMoney %>" />
        <%--��ˮ��--%>
        <input id="Number" type="hidden" value="<%= Qnumber %>" />
        <%--��ע��Ա--%>
         <input id="Aname" type="hidden" value="<%=name%>" />


        <input id="user_balance" type="hidden" value="<%=user_balance %>" />
        
         
    </form>
</body>
</html>
