<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_fukuan.aspx.cs" Inherits="Pbzx.Web.Buy_fukuan" %>

<%@ Register Src="../Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>

<%@ Register Src="../Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���ʽ_ƴ�����߲���ͨ���</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/buy.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />  
    <link href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <!--���岿��--->
            <div id="soft" class="bodyw MT">
                <!--���--->
                <div id="Y_lw1">
                    <uc3:Buy_left ID="Buy_left1" runat="server" />
                </div>
                <!--�ұ�--->
                <div id="Y_rw1">
                    <div class="Y_wei">
                        ��ǰλ�ã�<a href="/">ƴ�����߲���ͨ���</a> >> <a href="/SoftwarePrices.htm">ע�Ṻ��</a> >> ���ʽ
                    </div>
                    <div class="Y_box Y_r1 MT">
                        <div class="title">
                            <p>
                                <a href="#"><span>���ʽ</span></a></p>
                        </div>
                        <div class="content">
                            <div>
                                <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="30" align="center" valign="bottom" class="Y_xia">
                                            ���ʽ</td>
                                    </tr>
                                    <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" align="center" cellpadding="12" cellspacing="1" bgcolor="#ECECEC">
                                    <tr>
                                        <td align="left" bgcolor="#FCFCFC">
                                            <strong>(һ)����֧��</strong><br />
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
<%--                                                        &nbsp;&nbsp;&nbsp;&nbsp;����Ϊ���ṩ���п�����֧�����������С�ũҵ���С��������С��������С���ͨ���С�������������������ߡ���Ǯ��֧�������Ƹ�ͨ��֧����ʽ�� --%>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;����Ϊ���ṩ���п�����֧�����������С�ũҵ���С��������С��������С���ͨ���С������������֧������֧����ʽ��
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong>1.���п�����֧����֧�ֵĿ����У�</strong></td>
                                                </tr>
                                            </table>
                                            <table width="70%" border="0" cellpadding="4" cellspacing="1" bgcolor="#666666">
                                                <tr>
                                                    <td width="39%" align="center" bgcolor="#E1E1E1">
                                                        <strong>��������</strong></td>
                                                    <td width="61%" align="center" bgcolor="#E1E1E1">
                                                        <strong>֧������֧�������п�����</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_zhaos.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        һ��ͨ</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_gongs.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        ��ǿ�</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_jians.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        �������</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_nongy.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        ��ǿ�</td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
                                                        <strong>2.����֧��ƽ̨��֧�ֵ����п����У�</strong></td>
                                                </tr>
                                            </table>
                                            <table width="70%" border="0" cellpadding="4" cellspacing="1" bgcolor="#666666">
                                                <tr>
                                                    <td colspan="2" align="center" bgcolor="#E1E1E1">
                                                        <strong>֧��ƽ̨����</strong></td>
                                                    <td width="31%" align="center" bgcolor="#E1E1E1">
                                                        <strong>֧�����п���</strong></td>
                                                </tr>
                                                <%--<tr>
                                                    <td width="32%" align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/yunwang.jpg" /></td>
                                                    <td width="37%" align="center" bgcolor="#FFFFFF">
                                                        ����֧��</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://www.cncard.net/bank/sustain.asp" target="_blank"><strong>����鿴</strong></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/wangyin.jpg" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        ��������</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://www.chinabank.com.cn/gateway/china/cardtype.shtml" target="_blank"><strong>����鿴</strong></a></td>
                                                </tr>
                                                <tr>
                                                    <td  align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/kuaiqian.jpg" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        ��Ǯ֧��</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://help.99bill.com/viewthread.php?tid=44547&amp;extra=page%3D1%26amp%3Bfilter%3Dtype%26amp%3Btypeid%3D41"
                                                            target="_blank"><strong>����鿴</strong></a></td>
                                                </tr>
                                                --%>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/Pay_treasure.jpg" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        ֧����</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://help.alipay.com/lab/help_detail.htm?help_id=1193" target="_blank"><strong>����鿴</strong></a></td>
                                                </tr>
                                               <%-- <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/y_cft.gif" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        �Ƹ�ͨ��ѡ������֧����</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="https://www.tenpay.com/" target="_blank"><strong>����鿴</strong></a></td>
                                                </tr> --%>
                                            </table>
                                            <%--  <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                <tr>
                                                    <td>
                                                        <table width="80%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    <span class="red">��ܰ��ʾ��</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="height: 24px">
                                                                    ��1��Ŀǰʹ�ÿ�Ǯ����֧������֧�������߿ɴﵽ1��Ԫ����ͬ������֧���Ľ�ͬ����</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    ��2����Ǯ���ϴ��֧��֧�ֵ������У��������С�ũҵ���С��������к��������еȡ�</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            --%>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
                                                        <strong>3.�����ж�����֧���Ƿ�ɹ���</strong></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    ��1�����������������֧�����̺�ϵͳӦ��ʾ֧���ɹ������ϵͳû����ʾ֧��ʧ�ܻ�ɹ�������ͨ���绰��ATM ����̨���¼�������еȸ��ַ�ʽ��ѯ���п�����������ѱ��۳���˵������֧���ɹ���</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="height: 24px">
                                                                    ��2��������ִ������㡢������ߵȵ���֧�����ɹ���������ƴ�����߲���ͨ����ġ��û����ġ����ҵ��ñ�δ֧���ɹ��Ķ������������֧����</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
                                                        <strong>4.��ɡ�֧�����ܾ�����ԭ������Щ��</strong></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                <tr>
                                                    <td>
                                                        <table width="80%" cellpadding="2" cellspacing="0">
                                                            <tr>
                                                                <td width="49%" height="24" align="left">
                                                                    ��1���������п���δ��ͨ��������֧�����ܣ�</td>
                                                                <td width="51%" align="left">
                                                                    ��2���������п��ѹ��ڡ����ϡ���ʧ��</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    ��3���������п������㣻
                                                                </td>
                                                                <td align="left">
                                                                    ��4���������п����Ż����벻����</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    ��5������֤���Ų�����
                                                                </td>
                                                                <td align="left">
                                                                    ��6������ϵͳ���ݴ�������쳣��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    ��7�������жϡ�</td>
                                                                <td align="left">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" align="center" cellpadding="12" cellspacing="1" bgcolor="#ECECEC">
                                    <tr>
                                        <td align="left" bgcolor="#FCFCFC">
                                            <strong>(��)����ת��</strong><br />
                                            <span class="red">ע�����л��ʱ��ü���һ����ͷ�Ա�ȷ�ϣ�����380.06�����û�п�ͨ������������ת�˹��ܣ�Ҳ����ֱ�ӵ����й�̨����ת�ʻ�������֤�������ǻ���˺���Ϣ�������뼰ʱ��������ϵ����ע�ᣬ�����
                                                <a href="/ArtificialBuy.htm" class="red">ע�Ṻ��˵��</a>��</span><br />
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="http://www.bj.cmbchina.com/"><font color="#0000ff">��������</font></a><br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>6225 8801 0299 0190</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �촺��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ������</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �������к���������·֧��</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ���������������רҵ���ͨ����������ת�ˡ�</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://mybank.icbc.com.cn/icbc/perbank/index.jsp"><font color="#0000ff">��������</font></a><br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>9558 8002 0020 3039892</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �촺��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ������</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �������к�����������Ŷ�������</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �������еġ�ֱͨ�����ǳ���ݣ�ֻҪ��֪�����˺ź��������ԡ�ֱͨ���� ��ʽ�����������ˡ�������֤��ĵ����ͨ��Ҳ��������������ת�ˡ�</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://ibsbjstar.ccb.com.cn/index.html"><font color="#0000ff">��������</font></a><br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>4367 4200 1315 0118 036</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �촺��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ������</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �������б����з�����ͷ��֧��˫��·������<span lang="EN-US" style="font-size: 9pt; color: #336699; font-family: ����">
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ���������������רҵ���ͨ����������ת�ˡ�</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://www.95559.com.cn/personbank/servlet/com.bocom.eb.cs.html.EBEstablishSessionServlet?module=card">
                                                            <font color="#0000ff">��ͨ����</font></a><br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>4055 1225 9195 70709</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �촺��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ������</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �������к�����������֧��</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ���������������רҵ���ͨ����������ת�ˡ�</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://www.95599bj.com.cn/Rbank/login.htm"><font color="#0000ff">ũҵ����</font></a><br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>95599 8001 43116 58117</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �촺��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ������</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ����ũ�к���������·֧������·����</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ���л������������֤��</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        ��������<br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    �� &nbsp; &nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>6221501000004372504</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    <span style="background-color: #f4f7f7">�촺��</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ������</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    �����к���������·֧��
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ���������������רҵ���ͨ����������ת�ˡ�
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        ֧����<br />
                                                        ����ʱ���ʣ�</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    �� &nbsp; &nbsp;��</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>alipay@pinble.com</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    �տ���</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    <span style="background-color: #f4f7f7">�촺��</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;ע</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    ֻ�����߷�ʽ�²���Ҫ��֧�����˺�ת�ˣ����߷�ʽ��ֱ�Ӹ���󼴿̿�ͨ��
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
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
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
