<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionUpdate.aspx.cs"
    Inherits="Pinble_Ask.QuestionUpdate" %>

<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc4" %>
<%@ Register Src="Contorls/UcMark.ascx" TagName="UcMark" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>修改答复_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
body {
	line-height: 200%;
}
.pd {
	margin-top: 1px;
	margin-bottom: 1px;
}
-->
</style>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:UcAskHead ID="UcAskHead1" runat="server" />
    <div class="main">
        <div align="left">
            <div class="Link_Xia">
                <asp:Label ID="lblLink" runat="server" Text=""></asp:Label></div>
        </div>
    </div>
    <div class="main">
        <div class="Listl">
            <table width="100%" cellpadding="0" cellspacing="0" id="tbOther" runat="server">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 7px">
                                    <img src="images/A_list_classbg3.jpg" width="730" height="7" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="HasLogin" runat="server"
                            visible="true" class="MT">
                            <tr>
                                <td style="width: 731px; height: 7px;">
                                    <img src="images/A_List_bg2.jpg" width="730" height="7" />
                                </td>
                            </tr>
                            <tr>
                                <td background="images/A_list_classbg2.jpg" style="width: 731px">
                                    <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0" id="tbMyAnswerInsert"
                                        runat="server" visible="false">
                                        <tr>
                                            <td width="11%" align="right" valign="top" class="f14black">
                                                <asp:Label ID="lblInsert" runat="server" Text="我来回答："></asp:Label>
                                            </td>
                                            <td width="89%">
                                                <asp:TextBox ID="txtMyReplay" runat="server" Text="回答被采纳则获得悬赏分以及奖励20分" Columns="66"
                                                    Rows="8" TextMode="MultiLine" onfocus="this.value=''" MaxLength="9999"></asp:TextBox><br />
                                                回答字数9999个字以内
                                            </td>
                                        </tr>
                                        <tr style="height: 30px;">
                                            <td align="right" class="f14black" valign="top" width="11%">
                                                参考资料：
                                            </td>
                                            <td width="89%">
                                                <asp:TextBox ID="txtReferenceBook" runat="server" Columns="66" Rows="8" Width="477px"
                                                    MaxLength="200"></asp:TextBox><br />
                                                <div id="m_reply_sn_info">
                                                    如果您的回答是从其他地方引用，请表明出处。</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="f14black" style="height: 28px">
                                                验证码：
                                            </td>
                                            <td style="height: 28px">
                                                &nbsp;<asp:TextBox ID="txtCode" runat="server" Width="85px" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>&nbsp;
                                                <img src="/publicPage/VerifyCode.aspx" title="看不清？点击更换" alt="看不清？点击更换" name="imgVerify"
                                                    align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px;
                                                    height: 23px; cursor: pointer;" />
                                                <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                                &nbsp; &nbsp; &nbsp;
                                                <asp:Button ID="btnMyAnswer" runat="server" Text="提交回答" OnClick="btnMyAnswer_Click" />
                                                <iframe id="eee" src="about:blank" style="display: none;"></iframe>
                                                <script>
                                                    function CheckYZM2(aaaaa) {
                                                        document.getElementById("eee").src = "/reg.aspx?keyUpCheckVerifyCode=" + aaaaa + "&type=3";
                                                    }
                                                    function yanzhengmacallback(r) {
                                                        if (r == "Y") {
                                                            document.getElementById("imgOKL").style.display = "inline";
                                                            document.getElementById("imgErrorL").style.display = "none";
                                                        }
                                                        if (r == "N") {
                                                            document.getElementById("imgOKL").style.display = "none";
                                                            document.getElementById("imgErrorL").style.display = "inline";
                                                        }
                                                        if (r == "P") {
                                                            alert("验证码已经失效！请点击验证码图片重新获取验证码");
                                                        }
                                                    }

                                                </script>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0" id="tbMyAnswerUpdate"
                                        runat="server" visible="false">
                                        <tr id="Tr2" runat="server">
                                            <td align="right" class="f14black" valign="top" width="11%">
                                                修改答复：
                                            </td>
                                            <td width="89%">
                                                <%=Method.Get_UserName %>
                                                ，您要修改得答复如下：
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="11%" align="right" valign="top" class="f14black">
                                                &nbsp;
                                            </td>
                                            <td width="89%">
                                                <asp:TextBox ID="txtUContent" runat="server" Columns="66" Rows="8" TextMode="MultiLine"
                                                    MaxLength="9999"></asp:TextBox><br />
                                                回答字数9999个字以内
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="f14black" valign="top" width="11%" style="height: 30px">
                                                参考资料：
                                            </td>
                                            <td width="89%">
                                                <asp:TextBox ID="txtUReferenceBook" runat="server" Columns="66" Rows="8" Width="477px"
                                                    MaxLength="200"></asp:TextBox><br />
                                                <div id="Div1">
                                                    如果您的回答是从其他地方引用，请表明出处。</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="f14black">
                                                验证码：
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUCode" runat="server" Width="85px" MaxLength="4" onkeyup="CheckYZM1(this.value,'1','','img2','img3')"></asp:TextBox>&nbsp;
                                                <img src="/publicPage/Code.aspx" title="看不清？点击更换" alt="看不清？点击更换" name="imgVerify"
                                                    align="absmiddle" id="img1" onclick="this.src=this.src+'?'" style="width: 62px;
                                                    height: 23px; cursor: pointer;" />&nbsp;
                                                <img alt="正确" src="/Images/Web/note_ok.gif" id="img2" style="display: none;" />
                                                <img alt="错误" src="/Images/Web/note_error.gif" id="img3" style="display: none;" />&nbsp;&nbsp;
                                                <asp:Button ID="btnUMyAnswer" runat="server" Text="修改回答" OnClick="btnUMyAnswer_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 731px; height: 7px;">
                                    <img src="images/A_list_classbg3.jpg" width="730" height="7" />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%" id="Login" runat="server">
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" class="mMT">
                                        <tr>
                                            <td style="height: 23px; width: 3%;">
                                                <img src="images/A_user.jpg" width="16" height="16" />
                                            </td>
                                            <td width="97%" class="f14blackB" style="height: 23px">
                                                登录后才能回答问题
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 731px">
                                                <img src="images/A_List_bg2.jpg" width="730" height="7" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td background="images/A_list_classbg2.jpg" style="width: 731px">
                                                <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0">
                                                    <tr>
                                                        <td width="11%" align="right" valign="top" class="f14black">
                                                            &nbsp;
                                                        </td>
                                                        <td class="f12gray">
                                                            登录后回答可以获得积分奖励，并可以查看和管理您的回答。&nbsp;<asp:LinkButton ID="lbtnLogin" runat="server" Text="登录"
                                                                OnClick="lbtnLogin_Click"></asp:LinkButton>
                                                            |
                                                            <asp:LinkButton ID="lbtnReg" runat="server" Text="注册" OnClick="lbtnReg_Click"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 731px; height: 7px;">
                                                <img src="images/A_list_classbg3.jpg" width="730" height="7" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <a name="ask3" id="ask3"></a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="mr">
            <div class="Listr_title">
                <table width="93%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="width: 40%">
                            &nbsp;<font color="#E57B01"><b>最新公告</b></font>
                        </td>
                        <td style="width: 60%" align="right">
                            <a href="/Bulletin_Ask.aspx" target="_blank"><font color="#E57B01">更多>></font></a>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="Listr_content">
                <uc2:Bulletin_r ID="Bulletin_r1" runat="server" Count="8" TitleLength="18" ClassCss="Linl12Green"
                    IntChannelID="13" />
            </div>
            <div>
                <img src="images/A_list_rbg3.jpg" /></div>
            <div class="Listr2_title mMT">
                <table width="93%" cellpadding="0" cellspacing="0" border="0" align="left">
                    <tr>
                        <td style="width: 40%">
                            <font color="#003399"><b>积分排行榜</b></font>
                        </td>
                        <td style="width: 60%" align="right">
                            <a href="TopScore.aspx" target="_blank">更多>></a>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="Listr2_content">
                <uc3:UcMark ID="UcMark1" runat="server"></uc3:UcMark>
            </div>
            <div>
                <img src="images/A_list_rbg6.jpg" /></div>
        </div>
    </div>
    <uc4:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
