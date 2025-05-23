<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pinble_Chat._Default" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc5" %>
<%@ Register Src="Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc3" %>

<%@ Register Src="Contorls/Head_Chat.ascx" TagName="Head_Chat" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>������Ƶ�Ĳ���_ƴ�����߲���ͨ���</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/chat.css" rel="stylesheet" type="text/css" />
    <link href="/css/blue/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/XYTipsWindow.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <script language="javascript" src="/javascript/public.js" type="text/javascript"></script>
    <script language="javascript" src="/javascript/Prototype.js" type="text/javascript"></script>




    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<script language="javascript" type="text/javascript">
    function OnFindUser() // ��ʾ�����û����б�
    {
        var strUserName = prompt("��������Ҫ���ҵ��û���?", "��˭?");
        if (strUserName == null || strUserName == "��˭?" || strUserName.length < 1) return;
        window.open("http://chat.pinble.com:8888//finduser.htm?FindUser=" + strUserName, "_FindUser", "toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,resizable=yes");
    }
    /*�ű��������*/
    //-->
</script>
      
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <uc2:Head_Chat ID="Head_Chat1" runat="server"></uc2:Head_Chat>
            <div class="bodyw MT">
                <!--���--->
                <div class="ct_l1" style="float: left; width:206px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="24" background="/images/web/CT_lbg1.jpg" class="ct_title1">
                                �û�ָ��
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#55A3EF">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="75%" border="0" align="center" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx" class="ct_biao"
                                                target="_blank">�û�ע��</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/userguide.htm" class="ct_biao" target="_blank">
                                                ����˵��</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://download2.pinble.com/softdown/MeChatUser8.exe" class="ct_biao">�ؼ�����</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/allusers.htm" class="ct_biao" target="_blank">�����û�</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="javascript:OnFindUser();" class="ct_biao">���Ѳ�Ѱ</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/top.htm" class="ct_biao" target="_blank">�����</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>RecoverPasswd1.aspx" class="ct_biao"
                                                target="_blank">�����һ�</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/userhelp.htm" class="ct_biao" target="_blank">��������</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <uc1:UcPicAds ID="UcPicAds1" runat="server" PlaceType="�Ĳ�����һ" />
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td background="/images/web/CT_lbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 2px;">
                                    <tr>
                                        <td height="22" class="ct_title2">
                                            ���¹���
                                        </td>
                                        <td valign="bottom" align="right">
                                            <a href="Chat_Bulletin_list.aspx" target="_self">>>����</a>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9ACAFA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <uc3:Bulletin_r ID="Bulletin_r1" runat="server" Count="8" IntChannelID="10" TitleLength="30">
                                            </uc3:Bulletin_r>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td background="/images/web/CT_lbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 2px;">
                                    <tr>
                                        <td height="22" class="ct_title2">
                                            ���߿ͷ�
                                        </td>
                                        <td valign="bottom" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9ACAFA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <uc5:UC_QQ ID="UC_QQ1" runat="server"></uc5:UC_QQ>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--�м�--->
                <div class="ct_r1" style="float: right;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                        <tr>
                            <td height="28" background="/images/Web/ct_cbg1.jpg" align="center">
                                <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left">
                                            <div id="Login" runat="server">
                                                &nbsp;�û�����<asp:TextBox ID="txtName" runat="server" Width="110px" Style="margin-top: 2px;
                                                    margin-bottom: 2px;" MaxLength="12"></asp:TextBox>&nbsp; ��&nbsp;�룺<asp:TextBox ID="txtPWD"
                                                        runat="server" MaxLength="16" Width="110px" Style="margin-top: 2px; margin-bottom: 2px;"
                                                        TextMode="Password"></asp:TextBox>&nbsp; ��֤�룺<asp:TextBox ID="txtCode" MaxLength="4"
                                                            onkeyup="CheckYZM(this.value,'1','','imgOKH','imgErrorH')" runat="server" Width="46px"></asp:TextBox>
                                                <img src="/publicPage/VerifyCode.aspx" alt="�����壿�������" name="imgVerify" align="top"
                                                    id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" /><img
                                                        alt="��ȷ" src="/Images/Web/note_ok.gif" id="imgOKH" style="display: none;" />
                                                <img alt="����" src="/Images/Web/note_error.gif" id="imgErrorH" style="display: none;" />&nbsp;&nbsp;<asp:CheckBox
                                                    ID="chbState" runat="server" Text="�����ҵĵ�¼״̬" />&nbsp;
                                                <asp:ImageButton ID="ibtnLogin" runat="server" AlternateText="��¼ƴ��" OnClick="ibtnLogin_Click"
                                                    ImageUrl="~/Images/Web/Lo.jpg" align="absmiddle" CausesValidation="False" />
                                            </div>
                                            <div id="hasLogin" runat="server" visible="false">
                                                ��ӭ�� <font color="blue">
                                                    <asp:Label ID="lblUName" runat="server" Text=""></asp:Label></font> &nbsp;<asp:Label
                                                        ID="lblMessage" runat="server" Text="Label"></asp:Label>
                                                <%--�ǳƣ�<font color="blue"><asp:Label ID="lblAlias" runat="server" Text=""></asp:Label></font>--%>
                                                &nbsp;&nbsp;ͷ�Σ�<font color="blue"><asp:Label ID="lblAge" runat="server" Text=""></asp:Label></font>
                                                &nbsp;&nbsp;����<font color="blue"><asp:Label ID="lblGrade" runat="server" Text=""></asp:Label></font>
                                                &nbsp;&nbsp;��һ�ε�¼ʱ�䣺<font color="blue"><asp:Label ID="lblLogoutTime" runat="server"
                                                    Text=""></asp:Label></font> &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/User_Center.aspx"
                                                        target="_blank"><img src="/images/web/user_center.jpg" border="0" id="IMG1" align="middle" /></a>&nbsp;<asp:ImageButton
                                                            ID="ibtnLoginOut" runat="server" AlternateText="�˳���¼" ImageUrl="~/Images/Web/LoginOut.jpg"
                                                            align="middle" CausesValidation="False" OnClick="ibtnLoginOut_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <span id="address"></span>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td height="28" background="/images/Web/ct_cbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="12%" class="ct_title2">
                                            �Ĳ���
                                        </td>
                                        <td width="88%" align="left" valign="bottom">
                                            <font color="blue">��ʾ������ƴ��������̳�û��������룬��¼�����������Ƽ��ɽ����Ĳ��ҡ�</font>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#4E9EEB">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <iframe runat="server" name="chatmain" id="chatmain" frameborder="0" scrolling="no"
                                    style="overflow: visible; width: 740px; height: 272px; background-color: #f7f7f7;"
                                    src="http://chat.pinble.com:8888/index.htm"></iframe>
                            </td>
                        </tr>
                    </table>
                    <uc1:UcPicAds ID="UcPicAds2" runat="server" PlaceType="�Ĳ�����һ" />
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT">
                        <tr>
                            <td width="550" valign="top">
                                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#4E9EEB">
                                    <tr bgcolor="#ffffff">
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="26" align="left" background="/images/Web/ct_cbg3.jpg">
                                                        &nbsp;&nbsp;<strong>ע�����</strong>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="98%" border="0" align="center" cellpadding="8" cellspacing="0">
                                                <tr>
                                                    <td align="left" height="56">
                                                        1�������������Ļ��������϶������ģ����˳��Ĳ��Һ�[����]����װ�������������<br />
                                                        2���Ĳ����ڲ���̸���뱾�����޹صĻ��⣬�Ͻ�����棬�����Ĳ��ҵĸ���涨��
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="10">
                            </td>
                            <td width="210" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" background="/images/web/CT_Rbg1.jpg" class="ct_title2">
                                            ��������
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#4E9EEB">
                                    <tr>
                                        <td bgcolor="#FFFFFF">
                                            <table width="98%" border="0" align="center" cellpadding="4" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="http://download2.pinble.com/softdown/MeChatUser8.exe">��������Ƶ�ؼ�����</a><br />
                                                        <a href="http://chat.pinble.com:8888/userhelp.htm#f1">����ν���������Ƶ�Ĳ���</a><br />
                                                        <a href="http://www.pinble.com/Source_explain.aspx?ID=10209B5254442924" target="_blank">
                                                            �������Ĳ��Ҳ���ָ��¼��</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <uc1:UcPicAds ID="UcPicAds3" runat="server" Direction="1" PlaceType="�Ĳ����ж�" />
                    <%--              <div id="Synchronous" style="display: none; width:480px; height:360px;">
                    <table id="TongBu" runat="server">
                        <tr>
                            <td>
                                <table style="width: 100%; margin: 5px auto;" border="0" align="center" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td align="center" class="red">
                                            �Ĳ���ͬ������</td>
                                    </tr>
                                    <tr>
                                        <td class="blue">
                                            &nbsp; һ��ΪʲôҪͬ����<br />
                                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; ������վ������Ϊ�˽���û���������������Լ���ķ��գ���ϵͳ���������û�������ͳһ������ֻҪע��һ�Σ���ϵͳ����ƽ̨������������ע�ᣬΪ�˱���ԭ�Ĳ����û��ļ����Ȩ�޵����ϣ���Ҫ�����ε�¼���Ĳ��Һ�ͬ��һ�Ρ�<br />
                                            &nbsp;����ע������<br />
                                            &nbsp;1��ͬ����������ʹ����̳�û����������¼��ԭ�Ĳ����û������������ϣ�ÿ���û�ֻ��ͬ��һ�Ρ�һ�κ󱾹�����ʧ��<br />
                                            &nbsp;2���������ԭ�Ĳ����û����������Ϻ�㡰ͬ������ť������������û�����������ԭ�Ĳ����û��������룬��ֱ�ӵ�������û�����ť��<br />
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="blue">
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <table style="width: 100%; height: 106px;" border="0" align="center" cellpadding="0"
                                    cellspacing="0" class="kuang_line">
                                    <tr>
                                        <td valign="top">
                                            <form id="form2" name="form1" method="post" action="chat_user.asp">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="blue">
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            �Ĳ���ͬ��</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="47%">
                                                            ��̳�û�����</td>
                                                        <td width="53%">
                                                            <asp:TextBox ID="txtBbsName" runat="server" Width="140px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            ��̳�����룺</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsPWD" runat="server" TextMode="Password" Width="140px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            ԭ�Ĳ����û�����</td>
                                                        <td>
                                                            <asp:TextBox ID="txtLcsName" runat="server" Width="140px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            ԭ�Ĳ������룺</td>
                                                        <td>
                                                            <asp:TextBox ID="txtLcsPWD" runat="server" Width="140px" MaxLength="20" TextMode="Password"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            ��֤�룺</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCode" MaxLength="4" onKeyDown="{if (event.keyCode==13) return chk_userfrm();}"
                                                                runat="server" Width="50px"></asp:TextBox>
                                                            <img src="/publicPage/VerifyCode.aspx" alt="�����壿�������" name="imgVerify" align="absmiddle"
                                                                id="imgVerify" onclick="this.src=this.src+'?'" style="width: 80px; height: 25px" />
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="2">
                                                        <table style="width:100%">
                                                            <tr>
                                                                <td>
                                                                     <asp:Button ID="btnTB" runat="server" Text="ͬ  ��" OnClick="btnTB_Click" />
                                                                </td>
                                                                <td>
                                                                 <asp:Button ID="btnNew" runat="server" Text="���û�" OnClick="btnNew_Click" />
                                                                </td>
                                                                <td>
                                                                 <input ID="btncannel"  type="button" value="ȡ��" />
                                                                </td>
                                                            </tr>
                                                        
                                                        </table>
                                                           
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </form>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>--%>
                </div>
        </div>
        <uc4:Footer ID="Footer1" runat="server"></uc4:Footer>
    </div>
    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="/javascript/jquery.XYTipsWindow.2.7.js" ></script>
        <script type="text/javascript">
            //��ʾ
            function cue(name) {
                $.ajax({
                    type: 'POST',
                    url: '/Reg.aspx',
                    data: 'cueName=' + escape(name),
                    cache: false,
                    complete: function (msgcue, textStatus1) {
                        // unblock when remote call returns 
                        if (msgcue.responsetext == "true") {
                            var txt = "<div style=\"font-size:14px; width:500px; text-align:left; margin-top:10px\">1�����������һ�����Ϊ�գ�һ�������������޷��һ����롣<br/><br/>2������<a href=\"http://www.pinble.com/UserCenter/User_Center.aspx\" target=\"_blank\">�û�����</a>�ҵ�����ѡ���޸ĵ�¼�ܱ�����ʱ�����������һ�����ʹ𰸡�<br/><br/>3�������һ�����ʹ�����һ������Ҳ��Ҫ����վ�û���һ����<br/><br/>4�������һش�����̫�򵥣�Ҳ��Ҫ̫���ױ��²⣬��������ױ��Ƿ���Աͨ�������һع�������ȡ������վ�û������롣<br/><br/>5�������һ����������ɣ������ĳ����أ��������������գ������������ӵ����֣����ȵȣ������һش�Ӧ�����óɱ��˸�����������²ⲻ�����Ĵ𰸡�<br/></div>";
                            $.XYTipsWindow({
                                ___title: "<div style=\"border:0px solid #ccc; height:25px; line-height:25px;\"><font color='red'>�������ѣ�����������ʾ����ʹ𰸴��ڷ��գ�</font></div>",    //���ڱ�������
                                ___content: "text:" + txt,    //����{text|id|img|url|iframe}
                                ___width: "515",            //���ڿ��
                                ___height: "300",          //�������
                                ___drag: "___boxTitle", 	    //�϶��ֱ�ID
                                ___showbg: true		//�Ƿ���ʾ���ֲ�
                            });
                        }
                    }
                });
            }
    </script>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
