<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BankTransfer.aspx.cs" Inherits="Pbzx.Web.UserCenter.BankTransfer" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>�����ύ�ɹ�ҳ_ƴ�����߲���ͨ���</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT"  runat="server" visible="true" id="tbZF" >
            <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%">                            
                                <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" /></td>
                            <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                                ���������������Ϣ</td>
                            <td width="1%">
                                <img src="/Images/Web/order_bg1c.jpg" width="10" height="44" border="0" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="10" background="/Images/Web/order_bg2a.jpg">
                    &nbsp;
                </td>
                <td width="970" align="center" bgcolor="#FFFFFF">
                    <br />
                    <table width="95%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7%" align="center">
                                <img src="../Images/Web/order_bankli.jpg" width="38" height="35"></td>
                            <td width="93%" align="left" class="order_18black">
                                ���Ķ���<span color="red"><%=c_order %></span> �Ѿ��ύ������Ҫ֧����<span class="order_14red"><%=c_orderamount.ToString("0.00")%>Ԫ
                                    </span>��<br/>������ѻ����� ��<a href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx" target="_blank" style="font-size:18px;">�ҵĶ���</a>�����л��ȷ�ϡ�</td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                            <td align="left">
                                �����ƴ�����߲���ͨ����ʻ������ǽ���Ϊ����ͨ������ʼ����������������������û������ڡ�<a href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx" target="_blank">�ҵĶ���</a>���е�������Ŵ򿪶�����ϸҳ�棬Ȼ��������ͨ��ʱʹ�á���ť������ѻ����ʱ�����ʹ�á�</td>
                        </tr>
                    </table>
                    <table width="90%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="12">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" cellpadding="0" cellspacing="0" bgcolor="#81BBF5">
                        <tr>
                            <td height="1">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" cellpadding="18" cellspacing="1" bgcolor="#81BBF5">
                        <tr>
                            <td bgcolor="#ECF1FF">
                                <table width="100%" border="0" cellpadding="5" cellspacing="0" bgcolor="#FFFFFF">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <b>�������������ʻ���</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <font color="red">ע:</font>���л��ʱ��ü���һ����ͷ�Ա�ȷ�ϣ�����
                                                        <asp:Label ID="lblMoney" runat="server" Text=""></asp:Label>
                                                        �����û�����п�Ҳ����ֱ�ӵ�����������ת�ʻ���˵��ӻ��,������֤��������ڵ�㵥����;����ע�������ţ�</td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellpadding="4" cellspacing="0">
                                                <tr>
                                                    <td width="46%" valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://ibsbjstar.ccb.com.cn/index.html" target="_blank">
                                                                                    <img src="/Images/Web/bank_jians.jpg" border="0" align="absmiddle"></a>(��ʱ����)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �����У��������б����з�����ͷ��֧��˫��·������<span lang="EN-US" style="font-size: 9pt; color: #336699;
                                                                                    font-family: ����"> </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;�ţ�4367 4200 1315 0118 036</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;ע�����������������רҵ���ͨ����������ת��</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="46%" valign="top">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="http://www.bj.cmbchina.com/" target="_blank">
                                                                                    <img src="/Images/Web/bank_zhaos.jpg" border="0" align="absmiddle"></a>(��ʱ����)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �����У��������к���������·֧��</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;�ţ�6225 8801 0299 0190</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;ע�����������������רҵ���ͨ����������ת��</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="8%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://mybank.icbc.com.cn/icbc/perbank/index.jsp" target="_blank">
                                                                                    <img src="/Images/Web/bank_gongs.jpg" border="0" align="absmiddle"></a>(��ʱ����)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �����У��������к�����������Ŷ�������</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;�ţ�9558 8002 0020 3039892</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;ע���������еġ�ֱͨ�����ǳ���ݣ�ֻҪ��֪�����˺ź��������ԡ�ֱͨ���� ��ʽ�����������ˡ�������֤��ĵ����ͨ��Ҳ��������������ת�ˡ�</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://www.95559.com.cn/personbank/servlet/com.bocom.eb.cs.html.EBEstablishSessionServlet?module=card"
                                                                                    target="_blank">
                                                                                    <img src="/Images/Web/bank_jiaot.jpg" border="0" align="absmiddle"></a>(��ʱ����)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �����У��������к�����������֧��</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;�ţ�405512 2591 9570709</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;ע�����������������רҵ���ͨ����������ת��</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://www.95599bj.com.cn/Rbank/login.htm" target="_blank">
                                                                                    <img src="/Images/Web/bank_nongy.jpg" border="0" align="absmiddle"></a>(��ʱ����)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �����У�����ũ�к���������·֧������·����</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;�ţ�95599 8001 43116 58117</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;ע�����л������������֤��</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <img src="/Images/Web/bank_post.jpg" border="0" align="absmiddle">(��ʱ����)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �����У������к�����ɳ���ʵ���</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;�ţ�95510 01000 01091 2584</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                ��&nbsp;&nbsp;ע�����������������רҵ���ͨ����������ת��</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <img src="/Images/Web/y_cft.gif" border="0" align="absmiddle"></td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �տ��ˣ��촺��
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                �Ƹ�ͨ�˺ţ�tenpay@pinble.com</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                    <tr>
                                        <td align="left">
                                            <strong>��ʾ��</strong></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="font-size:12px; color:Red">
                                            * ����������Ϻ���Ҫ�ڡ�<a href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx" target="_blank">�ҵĶ���</a>����ѡ�����Ķ�����Ȼ���������Ŷ����Ķ�����������<br />                                   
                                            * �����Ķ���ͨ������Ա���֮�����ǻ����һ��ע���룬���¼��<a href="/UserCenter/User_Center.aspx" target="_blank">�û�����</a>�����ڡ�<a
                                                href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx" target="_blank">�ҵĶ���</a>���в鿴ע����Ϣ
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
<%--                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="imgNoPay" ImageUrl="/Images/Web/orderz_btnContinue.gif" runat="server"
                                    AlternateText="������������" OnClick="img_Click" align="absmiddle" /></td>
                        </tr>
                    </table>--%>
                    <table width="90%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td class="order_xia">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10" background="/Images/Web/order_bg2c.jpg">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 4px">
                    <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" /></td>
                <td background="/Images/Web/order_bg3b.jpg" style="height: 4px">
                </td>
                <td style="height: 4px">
                    <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" /></td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
