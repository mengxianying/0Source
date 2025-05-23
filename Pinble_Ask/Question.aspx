<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Question.aspx.cs" Inherits="Pinble_Ask.Question"
    EnableEventValidation="false" %>

<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc4" %>
<%@ Register Src="Contorls/UcMark.ascx" TagName="UcMark" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ƴ���� - ƴ�����߲���ͨ���</title>
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
                <div class="class_title">
                    <asp:Literal ID="litState" runat="server"></asp:Literal>
                </div>
                <div class="class_content">
                    <table width="96%" border="0" cellpadding="1" cellspacing="0" align="center">
                        <tr>
                            <td colspan="2" class="f14blackB" style="height: 19px">
                                <asp:Label ID="lbltitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 25px">
                                <img src="images/A_money.jpg" width="16" height="16" hspace="2" vspace="0" /><span
                                    class="f12yel">���ͻ��֣�<asp:Label ID="lbllargessPoint" runat="server"></asp:Label>
                                </span><span class="f12gray">
                                    <asp:Label ID="lblTime" runat="server"></asp:Label>&nbsp;�����<asp:Label ID="lblviewCount"
                                        runat="server"></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="f14black">
                                <asp:Label ID="lblcontent" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="17%" height="22" valign="bottom">
                            </td>
                            <td align="right" valign="top" class="f12gray" style="width: 116%">
                                �����ߣ�<asp:Label ID="lblaskUser" runat="server"></asp:Label><p />
                                <a href="javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','','','','utf-8'));">
                                    <img src='/Images/Web/SinaWiki.jpg' border='0'>����������΢��</a>
                            </td>
                        </tr>
                        <tr id="reply" runat="server" visible="false">
                            <td height="30" valign="bottom" width="17%">
                                <img src="images/huida.jpg" width="90" height="26" />
                            </td>
                            <td align="right" class="f12gray" valign="top" style="width: 116%">
                            </td>
                        </tr>
                        <tr id="trSet" runat="server" visible="false">
                            <td align="left" class="f12gray" colspan="2" valign="top">
                                <h3>
                                    ��������</h3>
                                <div class="f14">
                                    ����ѻ������Ļش��뼰ʱ���ɣ���л�ش��ߡ�����û������Ļش𣬿��Գ������²�����</div>
                                <dl id="methodList">
                                    <dt id="supdetailLink"><a href="#" onclick="document.getElementById('supdetailPanel').style.display=document.getElementById('supdetailPanel').style.display=='none'?'':'none';">
                                        <span style="color: #0000ff; text-decoration: underline">��������</span></a><span class="gray">
                                            &nbsp;��������ϸ�ڣ��Եõ���׼ȷ�Ĵ�;</span> </dt>
                                    <dd id="supdetailPanel" name="dealPanel" style="display: none">
                                        <div class="box-out">
                                        </div>
                                        <div class="box-in">
                                        </div>
                                        <div class="box-inner">
                                            <asp:TextBox ID="txtRelay" runat="server" Height="102px" TextMode="MultiLine" MaxLength="800"
                                                Width="600px"></asp:TextBox>
                                            <div class="input_num" style="width: 100%">
                                                <p id="suplyco_numError" class="num_error">
                                                    �����������Ϊ800��</p>
                                            </div>
                                            <div id="supdetailInfo" class="alert" style="display: none">
                                            </div>
                                            <div>
                                                <asp:Button ID="btnRelayAdd" runat="server" Text="ȷ��" OnClick="btnRelayAdd_Click" />
                                                <input onclick="document.getElementById('supdetailPanel').style.display='none';"
                                                    type="button" value="ȡ ��" />
                                            </div>
                                        </div>
                                        <div class="box-in">
                                        </div>
                                        <div class="box-out">
                                        </div>
                                    </dd>
                                    <dt id="addscoreLink"><a href="#" onclick="document.getElementById('addscorePanel').style.display=document.getElementById('addscorePanel').style.display=='none'?'':'none';">
                                        <span style="color: #0000ff; text-decoration: underline">�������</span></a><span class="gray">
                                            &nbsp;������ͣ����������Ĺ�ע��;</span> </dt>
                                    <dd id="addscorePanel" name="dealPanel" style="display: none">
                                        <div class="box-out">
                                        </div>
                                        <div class="box-in">
                                        </div>
                                        <div class="box-inner">
                                            <%--�������ڣ�����׷������<strong>2</strong>�Ρ�
                                            <br />
                                            ����һ�����͵ķ�������<strong>20</strong>��ʱ�������⽫��ͬ������������⣬����������������б�����ʾΪ���¡�
                                            <br />--%>
                                            ׷������
                                            <asp:DropDownList ID="ddlAdd" runat="server">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                            </asp:DropDownList>
                                            ��&nbsp;<br />
                                            <asp:Button ID="btnAddScore" runat="server" Text="ȷ��" OnClick="btnAddScore_Click" />
                                            <input onclick="document.getElementById('addscorePanel').style.display='none';" type="button"
                                                value="ȡ ��" />
                                            <div>
                                            </div>
                                        </div>
                                        <div class="box-in">
                                        </div>
                                        <div class="box-out">
                                        </div>
                                    </dd>
                                    <dt id="noanswerLink"><span style="color: #0000ff; text-decoration: underline">
                                        <asp:LinkButton ID="lbtnClose" runat="server" Text="������𰸣��ر�����" OnClick="lbtnClose_Click"></asp:LinkButton></span>
                                        <span class="gray">&nbsp;û������Ļش� ������ֱ�ӽ������ʣ��ر�����;</span> </dt>
                                </dl>
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server" visible="false">
                            <td align="left" class="f12gray" colspan="2" valign="top">
                            </td>
                        </tr>
                    </table>
                </div>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <img src="images/A_list_classbg3.jpg" width="730" height="7" /></td>
                    </tr>
                </table>
                <div id="divBestAnswer" runat="server" visible="false">
                    <div class="class_title2 mMT">
                        <img src="images/icn_best.gif" hspace="0" vspace="0" align="texttop" />&nbsp;��Ѵ�<strong
                            class="f12gray"><%-- �� ��--%></strong></div>
                    <div class="class_content2">
                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">
                                    <asp:Literal ID="litBestAnswer" runat="server"></asp:Literal></td>
                            </tr>
                        </table>
                    </div>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="images/A_list_classbg3z.jpg" width="730" height="7" /></td>
                        </tr>
                    </table>
                </div>
                <div id="divClose" runat="server" style="background-color: gainsboro; height: 28px;
                    width: 100%" visible="false">
                    <strong>�������Ѿ��ر�</strong>
                </div>
                <div class="class_title mMT">
                    <img src="images/A_ans.jpg" width="16" height="16" hspace="0" vspace="0" align="texttop" />&nbsp;������<strong
                        class="f12gray"><%-- �� ��--%></strong></div>
                <div class="class_content">
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <asp:GridView ID="MyGridView" runat="server" Width="96%" AutoGenerateColumns="False"
                                    DataKeyNames="ID,Replyer,QuestionId" OnRowCreated="MyGridView_RowCreated" CellPadding="0"
                                    ShowHeader="False" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                    <tr>
                                                        <td class="f14black" align="left">
                                                            <%#Eval("Content")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="f14black" align="left">
                                                            <%# AddReferenceBook(Eval("ReferenceBook"))%>
                                                        </td>
                                                    </tr>
                                                    <tr style="line-height: 28px">
                                                        <td align="right">
                                                            <div style="margin-top: 28px;">
                                                                �ش��ߣ�<a target='_blank' href='UserShow.aspx?name=<%# Input.Encrypt(Eval("ReplyerId").ToString())%>'><%#Eval("Replyer") %>
                                                                </a>- <a href='Help.aspx#n5' target='_blank'>
                                                                    <%#GetUserTitle(Eval("ReplyerId"))%>
                                                                </a>&nbsp;<%#Eval("ReplyTime")%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table width="96%" border="0" cellpadding="0" cellspacing="0" align="center">
                        <tr>
                            <td bgcolor="#83B5E2" style="height: 2px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="27" valign="bottom">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" NumericButtonCount="3"
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="��һҳ" ShowCustomInfoSection="Right"
                                    ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                                    CustomInfoStyle='vertical-align:middle;' CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="litContent" runat="server"></asp:Label>
                </div>
                <table width="100%" cellpadding="0" cellspacing="0" id="tbOther" runat="server">
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="images/A_list_classbg3.jpg" width="730" height="7" /></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="HasLogin" runat="server"
                                visible="false" class="MT">
                                <tr>
                                    <td style="width: 731px; height: 7px;">
                                        <img src="images/A_List_bg2.jpg" width="730" height="7" /></td>
                                </tr>
                                <tr>
                                    <td background="images/A_list_classbg2.jpg" style="width: 731px">
                                        <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0" id="tbMyAnswerInsert"
                                            runat="server" visible="false">
                                            <tr>
                                                <td width="11%" align="right" valign="top" class="f14black">
                                                    <asp:Label ID="lblInsert" runat="server" Text="�����ش�"></asp:Label>
                                                </td>
                                                <td width="89%">
                                                    <asp:TextBox ID="txtMyReplay" runat="server" Columns="66" Rows="8" TextMode="MultiLine"
                                                        MaxLength="9999"></asp:TextBox><br />
                                                    �ش�����9999��������</td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td align="right" class="f14black" valign="top" width="11%">
                                                    �ο����ϣ�</td>
                                                <td width="89%">
                                                    <asp:TextBox ID="txtReferenceBook" runat="server" Columns="66" Rows="8" Width="477px"
                                                        MaxLength="200"></asp:TextBox><br />
                                                    <div id="m_reply_sn_info">
                                                        ������Ļش��Ǵ������ط����ã������������</div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="f14black" style="height: 28px">
                                                    ��֤�룺</td>
                                                <td style="height: 28px">
                                                    &nbsp;<asp:TextBox ID="txtCode" runat="server" Width="85px" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>&nbsp;
                                                    <img src="/publicPage/VerifyCode.aspx" title="�����壿�������" alt="�����壿�������" name="imgVerify"
                                                        align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px;
                                                        height: 23px; cursor: pointer;" />
                                                    <img alt="��ȷ" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                    <img alt="����" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                                    &nbsp; &nbsp; &nbsp;
                                                    <asp:Button ID="btnMyAnswer" runat="server" Text="�ύ�ش�" OnClick="btnMyAnswer_Click" /></td>
                                            </tr>
                                        </table>
                                        <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0" id="tbMyAnswerUpdate"
                                            runat="server" visible="false">
                                            <tr id="Tr2" runat="server">
                                                <td align="right" class="f14black" valign="top" width="11%">
                                                    �޸Ĵ𸴣�</td>
                                                <td width="89%">
                                                    <%=Method.Get_UserName %>
                                                    ����Ҫ�޸ĵô����£�
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="11%" align="right" valign="top" class="f14black">
                                                    &nbsp;</td>
                                                <td width="89%">
                                                    <asp:TextBox ID="txtUContent" runat="server" Columns="66" Rows="8" TextMode="MultiLine"
                                                        MaxLength="9999"></asp:TextBox><br />
                                                    �ش�����9999��������</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="f14black" valign="top" width="11%" style="height: 30px">
                                                    �ο����ϣ�</td>
                                                <td width="89%">
                                                    <asp:TextBox ID="txtUReferenceBook" runat="server" Columns="66" Rows="8" Width="477px"
                                                        MaxLength="200"></asp:TextBox><br />
                                                    <div id="Div1">
                                                        ������Ļش��Ǵ������ط����ã������������</div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="f14black">
                                                    ��֤�룺</td>
                                                <td>
                                                    <asp:TextBox ID="txtUCode" runat="server" Width="85px" MaxLength="4" onkeyup="CheckYZM(this.value,'2','','imgOKU','imgErrorU')"></asp:TextBox>&nbsp;
                                                    <img src="/publicPage/Code.aspx" title="�����壿�������" alt="�����壿�������" name="imgVerify"
                                                        align="absmiddle" id="img1" onclick="this.src=this.src+'?'" style="width: 62px;
                                                        height: 23px; cursor: pointer;" />
                                                    <img alt="��ȷ" src="/Images/Web/note_ok.gif" id="imgOKU" style="display: none;" />
                                                    <img alt="����" src="/Images/Web/note_error.gif" id="imgErrorU" style="display: none;" />
                                                    &nbsp;
                                                    <asp:Button ID="btnUMyAnswer" runat="server" Text="�޸Ļش�" OnClick="btnUMyAnswer_Click" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="images/A_list_classbg3.jpg" width="730" height="7" /></td>
                                </tr>
                            </table>
                            <table width="100%" id="Login" runat="server">
                                <tr>
                                    <td>
                                        <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" class="mMT">
                                            <tr>
                                                <td style="height: 23px; width: 3%;">
                                                    <img src="images/A_user.jpg" width="16" height="16" /></td>
                                                <td width="97%" class="f14blackB" style="height: 23px">
                                                    ��¼����ܻش�����</td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 731px">
                                                    <img src="images/A_List_bg2.jpg" width="730" height="7" /></td>
                                            </tr>
                                            <tr>
                                                <td background="images/A_list_classbg2.jpg" style="width: 731px">
                                                    <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td width="11%" align="right" valign="top" class="f14black">
                                                                &nbsp;</td>
                                                            <td class="f12gray">
                                                                ��¼��ش���Ի�û��ֽ����������Բ鿴�͹������Ļش�&nbsp;<asp:LinkButton ID="lbtnLogin" runat="server" Text="��¼"
                                                                    OnClick="lbtnLogin_Click"></asp:LinkButton>
                                                                |
                                                                <asp:LinkButton ID="lbtnReg" runat="server" Text="ע��" OnClick="lbtnReg_Click"></asp:LinkButton></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 731px; height: 7px;">
                                                    <img src="images/A_list_classbg3.jpg" width="730" height="7" /></td>
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
                    <table width="93%" cellpadding="0" cellspacing="0" border="0" align="center">
                        <tr>
                            <td width="40%">
                                &nbsp;<font color="#E57B01"><b>���¹���</b></font>
                            </td>
                            <td width="53%" align="right">
                                <a href="/Bulletin_Ask.aspx" target="_blank"><font color="#E57B01">����>></font></a>&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Listr_content">
                    <uc2:Bulletin_r ID="Bulletin_r1" runat="server" TitleLength="18" ClassCss="Linl12Green"
                        IntChannelID="13" />
                </div>
                <div>
                    <img src="images/A_list_rbg3.jpg" /></div>
                <div class="Listr2_title mMT">
                    <table width="93%" cellpadding="0" cellspacing="0" border="0" align="center">
                        <tr>
                            <td width="40%">
                                <font color="#003399"><b>�������а�</b></font>
                            </td>
                            <td width="53%" align="right">
                                <a href="TopScore.aspx" target="_blank">����>></a>&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Listr2_content">
                    <uc3:UcMark ID="UcMark1" runat="server"></uc3:UcMark>
                </div>
                <div>
                    <img src="images/A_list_rbg6.jpg" border="0" /></div>
            </div>
        </div>
        <uc4:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
