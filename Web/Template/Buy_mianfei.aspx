<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_mianfei.aspx.cs" Inherits="Pbzx.Web.Buy_mianfei" %>

<%@ Register Src="../Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���ʹ��_ƴ�����߲���ͨ���</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/buy.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                    ��ǰλ�ã�<a href="/">ƴ�����߲���ͨ���</a> >> <a href="/SoftwarePrices.htm">ע�Ṻ��</a> >> ���ʹ��
                </div>
                <div class="Y_box Y_r1 MT">
                    <div class="title">
                        <p>
                            <a href="#"><span>���ʹ��</span></a></p>
                    </div>
                    <div class="content">
                        <div>
                            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="30" align="center" valign="bottom" class="Y_xia">
                                        ���ʹ��</td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                            </table>
                            <table width="96%" border="0" align="center" cellpadding="15" cellspacing="1" bgcolor="#ECECEC">
                                <tr>
                                    <td align="left" bgcolor="#FCFCFC">
                                        &nbsp;&nbsp;&nbsp;&nbsp;1����һ��ʹ�á�����ͨ������������ܹ���������ѡ��������á������������������һ��ʱ�䣨����һ�������գ�������Ҫ������̳�������뼴��ʹ�á���������⡱ʱʹ�ù�������ͨ��������û�������ѡ������ע�ᡱ��ʽ��¼��ֱ��ѡ��������á����ɡ�<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;2���ڡ�������á���ʼ�󣬶���û����<a href="http://bbs.pinble.com/" target="_blank">ƴ�����߲�Ʊ��̳</a>ע����̳���ֵ��û�����������̳ע��һ���û������ڱ����ڣ�����һ�������գ����������������ͷ�������������ͬʱ�������桰������׼�����û������������ܣ�����һ�������գ��������ʹ�á�����ͨ�����������������õ��ں�ֻ�ܹ���������ܼ���ʹ�������<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;3����������á����ں�ֻҪ���ܣ�����һ�������գ��ķ��������������ͷ���������������ָ��ﵽҪ�󣬿���ѡ������ע�ᡱ��ʽ��¼��������̳�û��������뼴��ʹ����������κ�ʱ��ֻҪ���������Ҫ�󣬶�����ͨ�����������ʹ�á�����ͨ�������<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;4�����������͸�������˵�����£�<br />
                                        <span class="red"><b>����ͨ�û���������Ϣ˵��</b></span>
                                        <asp:Repeater ID="rptPUt" runat="server">
                                            <HeaderTemplate>
                                                <table width="99%" border="1" height="53" cellspacing="0" style="border-collapse: collapse;
                                                    margin-bottom: 0pt;" bordercolor="#C0C0C0" cellpadding="0">
                                                    <tr bgcolor="#0000ff">
                                                        <th width="157" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            �������
                                                        </th>
                                                        <th width="147" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            ��̳��������</th>
                                                        <th width="99" height="21" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            ������</th>
                                                        <th width="89" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            ������</th>
                                                        <th width="98" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            ��������</th>
                                                        <th width="128" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            ������������</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="MsoNormal">
                                                    <td width="157" height="22" align="center">
                                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                                    </td>
                                                    <td class="blue">
                                                        &nbsp;<%# showBoards(Eval("Boards"))%></td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinTopics"),7)%>��/��</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinAnncounts"),7)%>��/��</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinBests"),7)%>��/��</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinDays"),7)%>��/��</td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table></FooterTemplate>
                                        </asp:Repeater>
                                        <br />
                                        <span class="red"><b>������û���������Ϣ˵��</b></span>
                                        <asp:Repeater ID="rptGuiB" runat="server">
                                            <HeaderTemplate>
                                                <table width="99%" border="1" height="53" cellspacing="0" style="border-collapse: collapse;
                                                    margin-bottom: 0pt;" bordercolor="#C0C0C0" cellpadding="0">
                                                    <tr bgcolor="#0000ff">
                                                        <th width="157" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            �������
                                                        </th>
                                                        <th width="147" height="21" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            ��̳��������</th>
                                                        <th width="99" height="21" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            ������</th>
                                                        <th width="89" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            ������</th>
                                                        <th width="98" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1" class="black_bold"
                                                            scope="col">
                                                            ��������</th>
                                                        <th width="128" align="center" background="/images/men_bg.gif" bgcolor="#D7E1E1"
                                                            class="black_bold" scope="col">
                                                            ������������</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="MsoNormal">
                                                    <td width="157" height="22" align="center">
                                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                                    </td>
                                                    <td class="blue">
                                                        &nbsp;<%# showBoards(Eval("Boards"))%></td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinTopics"),4)%>��/��</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinAnncounts"),4)%>��/��</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinBests"),4)%>��/��</td>
                                                    <td height="22" align="center" class="black">
                                                        <%#GetTies(Eval("MinDays"),4)%>��/��</td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table></FooterTemplate>
                                        </asp:Repeater>
                                        <span class="red">��ע��</span><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;1��������̳������������ҷ���ˮ�����ҷ���Ԥ���޹ص����ӣ�����ÿ��ɾ��1������������2����������ÿ��ɾ��1������������3����������
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;2��ÿ��þ�������1�ν�����2����������ÿ��þ�������1�ν�����3����������
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;3���������������������������ͷ�����������������ͬʱ���㡰������׼����Ҫ���κ�һ��ָ��ﲻ��Ҫ�󶼽����ܼ���ʹ�������
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;4�������͸������ڱ������ٷֲ�������ָ���ġ������������������ϣ����һ�ܣ�����һ�������գ��ķ����͸������ڷֲ�������ָ���ġ������������������£���ʹ������������Ҫ�����ܣ�����һ�������գ�Ҳ�����ܼ���ʹ�������
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;5����������������ָ�����з����͸����ķֲ�����������ָ�ĵ����ķ������������������
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;6��һ����̳�û���ֻ��һ����ʹ�ã��û������������Լ����Ʊ��ܺã��������̳�û�����������������ˣ�������˲�����һ�к���ɸ���̳�û��������˸���
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;7�������͸�������ÿ��ϵͳ�Զ�ͳ��һ�Σ�ÿ�ܣ�����һ�������գ����������������ͷ���������������Ӱ�쵽���ܣ�����һ�������գ��Ƿ�������ʹ�������
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;8����������õ�������׼���Ժ��ʵ��ִ�й����п��ܻ��б��������վ���¹���������Ϊ׼��
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;9��������ص�˵���뿴������˵�� ע��˵�� ���ѽ�� ������ѯ��
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
