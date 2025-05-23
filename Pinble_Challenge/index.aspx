<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pinble_Challenge.index" EnableEventValidation="false" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Src="Contorls/adv.ascx" TagName="adv" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="keywords" content='����ͨ ƴ������ ��Ʊ��� 3D P3 ������ ������ ���ֲ� ˫ɫ�� ����8 ���ǲ� ��������͸ ��� ���� ������Ʊ ������Ʊ ͼ�� ����ͼ ѡ�� ������� �淨���� ������Ϣ �Ի��� ��ע��' />
    <meta name="description" content='ƴ�����߲���ͨ�����վ�ǹ��������רҵ��Ʊ�����վ�����µĲ���ͨϵ�в�Ʊ������ȫ������������к񰮣�ƴ������ʼ��һ������Ƴ���Ϊ����Ĳ�Ʊ�������ȫ���������ֵ����Ϊ�������ṩ��õĲ�Ʊ����������߼���Ʊ����ƽ̨��' />
    <meta name="author" content='ƴ�����߲���ͨ��� www.pinble.com' />
    <meta name="robots" content="all" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />

    <title>ƴ����̨ - ƴ�����߲���ͨ���</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/btnSwitch.js"></script>
    <script type="text/javascript" src="js/Rel.js?ver=1"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/exporting.js"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <style type="text/css">
        .ball-0
        {
            height: 20px;
            width: 20px;
            cursor: pointer;
        }
        .ball-0 span
        {
            float: left;
            width: 24px;
            height: 24px;
            line-height: 19px;
            margin: 3px 4px 3px 4px;
            text-align: center;
            font-size: 10px;
            cursor: pointer;
        }
        .rb
        {
            background: url(../images/ball-area.gif) -80px 0 no-repeat;
            color: #fff;
            font-weight: bold;
        }
        .fun
        {
            background: url(../images/ball-area.gif) -80px 0 no-repeat;
            color: #fff;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
        <uc2:logion1 ID="logion11" runat="server" />
    </div>
    <%--    <div class="zanneiy_top_B">
        
        <uc4:adv ID="adv1" runat="server" />
        
    </div>--%>
    <div class="zanneiy_top_C">
        <uc3:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
    
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj">
                    <div class="all">
                        <div class="tabtype" style="margin-top: 10px;">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lbtn_s" runat="server" PostBackUrl="~/index.aspx?id=s">˫ɫ��</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_d" runat="server" PostBackUrl="~/index.aspx?id=d">����3D</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_p" runat="server" PostBackUrl="~/index.aspx?id=p">������</asp:LinkButton>
                                </li>
                            </ul>
                           <span id="openN" class="right-type">��<%=issueN%>�� <asp:Label ID="lab_lott" runat="server" Text="˫ɫ��"></asp:Label>�������룺<font color="red"><asp:Label
                               ID="lab_num" runat="server" Text="���޿�������"></asp:Label></font>��</span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="ssq-expert-title">
                            <p class="title-text title-text-l">
                                <asp:Label ID="lab_lname" runat="server" Text="Label">˫ɫ��</asp:Label>Ԥ�����</p>
                            <%--                                                        <div class="btn_sf on_btn">

                                </div>--%>
                            <%--<div class="btn_sf">
                                <a class="btn_link" href="#">ר��</a></div>--%>
                            <div class="ssq-check" style="float: right; margin-right: 20px;">
                                <%--                                <asp:TextBox ID="tb_search" runat="server" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="seach-button"
                                    runat="server" Text="����" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                <asp:Button ID="Newest" runat="server" CssClass="seach-button" Text="������" />
                                <%--<input id="Newest" type="button" value="������" class="seach-button" />--%>
                                <input id="theLast" type="button" value="ǰһ��" class="seach-button" />
                                ��
                                <asp:DropDownList ID="ddl_issue" runat="server" AppendDataBoundItems="True">
                                </asp:DropDownList>
                                ��
                                <input id="next" type="button" value="��һ��" class="seach-button" />
                                <input id="txt_issue" style="border: 1px solid; height: 20px" type="text" />
                                <input id="Search" type="button" class="seach-button" value="����" />
                                <span class="color-blue2"><a href='http://www.pinble.com/Lottery.htm' target='_blank'>
                                    <asp:Label ID="lab_win" runat="server">˫ɫ��</asp:Label>�����գ�<asp:Label ID="labtime"
                                        runat="server" Text="Label"> ÿ�ܶ� �� ��</asp:Label></a></span>


                            </div>
                        </div>
                        <div id="ssq_content" runat="server">
                            <table class="ssq-expert-charts">
                                <asp:Repeater ID="rep_conD" runat="server" OnItemDataBound="rep_conD_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr height="30px" class="back-color color-blue">
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                �ں�
                                            </td>
                                            <td>
                                                ��Ա
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=hq3d&n=s" target="_blank" class="color-blue">����3��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=hq6d&n=s" target="_blank" class="color-blue">����6��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s3hq&n=s" target="_blank" class="color-blue">ɱ3����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s6hq&n=s" target="_blank" class="color-blue">ɱ6����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=lq1d&n=s" target="_blank" class="color-blue">����1��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=lq3d&n=s" target="_blank" class="color-blue">����3��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s3lq&n=s" target="_blank" class="color-blue">ɱ3����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s6lq&n=s" target="_blank" class="color-blue">ɱ6����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=h3l&n=s" target="_blank" class="color-blue">12��+3��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=h2l&n=s" target="_blank" class="color-blue">9��+2��</a>
                                            </td>
                                        </tr>
                                        <tbody id="info">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%--<tr style='background-color: <%#(Container.ItemIndex%2==0) ? "":"#0068ae"%>'>--%>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex + 1%>
                                            </td>
                                            <td>
                                                <%# Eval("C_issue").ToString() == "" ? "---" : Eval("C_issue").ToString()%>
                                            </td>
                                            <td>
                                                <a href='Person.aspx?name=<%#Server.UrlEncode(Eval("C_name").ToString()) %>'
                                                    target="_blank">
                                                    <%# Eval("C_name")%></a>
                                                <%--<asp:HyperLink ID="hlShow" NavigateUrl='<%#"~/Person.aspx?name="+Eval("C_name") %>' runat="server"> <%# Eval("C_name")%></asp:HyperLink>--%>
                                            </td>
                                            <td>
                                                <%# Eval("hq3d").ToString() == "" ? "---" : Eval("hq3d").ToString()%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_hq6d" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("s3hq").ToString() == "" ? "---" : Eval("s3hq").ToString()%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_s6hq" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("lq1d").ToString() == "" ? "---" : Eval("lq1d").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("lq3d").ToString() == "" ? "---" : Eval("lq3d").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("s3lq").ToString() == "" ? "---" : Eval("s3lq").ToString()%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_s6lq" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_h3l" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_h2l" runat="server" Text="Label"></asp:Label>
                                                <%--<%# Eval("h2l").ToString() == "" ? "---" : Eval("h2l").ToString()%>--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr height="30px" class="back-color color-blue">
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                �ں�
                                            </td>
                                            <td>
                                                ��Ա
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=hq3d&n=s" target="_blank" class="color-blue">����3��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=hq6d&n=s" target="_blank" class="color-blue">����6��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s3hq&n=s" target="_blank" class="color-blue">ɱ3����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s6hq&n=s" target="_blank" class="color-blue">ɱ6����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=lq1d&n=s" target="_blank" class="color-blue">����1��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=lq3d&n=s" target="_blank" class="color-blue">����3��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s3lq&n=s" target="_blank" class="color-blue">ɱ3����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s6lq&n=s" target="_blank" class="color-blue">ɱ6����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=h3l&n=s" target="_blank" class="color-blue">12��+3��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=h2l&n=s" target="_blank" class="color-blue">9��+2��</a>
                                            </td>
                                        </tr>
                                        </tbody></FooterTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <div id="D_content" runat="server">
                            <table class="ssq-expert-charts">
                                <asp:Repeater ID="rep_dd" runat="server" OnItemDataBound="rep_dd_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr height="30px" class="back-color color-blue">
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                �ں�
                                            </td>
                                            <td>
                                                ��Ա
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=dd&n=d" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=sd&n=d" target="_blank" class="color-blue">˫��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=zx1z&n=d" target="_blank" class="color-blue">��ѡһע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s1m&n=d" target="_blank" class="color-blue">ɱһ��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s2m&n=d" target="_blank" class="color-blue">ɱ����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=dk&n=d" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=dh&n=d" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s1h&n=d" target="_blank" class="color-blue">ɱ1��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=5dw&n=d" target="_blank" class="color-blue">5*5*5��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=3dw&n=d" target="_blank" class="color-blue">3*3*3��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=zx&n=d" target="_blank" class="color-blue">ֱѡ1ע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=m&n=d" target="_blank" class="color-blue">5��</a>
                                            </td>
                                        </tr>
                                        <tbody id="info">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex + 1%>
                                            </td>
                                            <td>
                                                <%# Eval("C_issue").ToString() == "" ? "---" : Eval("C_issue").ToString()%>
                                            </td>
                                            <td>
                                                <a href=' Person.aspx?name=<%# Server.UrlEncode(Eval("C_name").ToString())%>'+
                                                    target="_blank">
                                                    <%# Eval("C_name")%></a>
                                            </td>
                                            <td>
                                                <%# Eval("dd").ToString() == "" ? "---" : Eval("dd").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("sd").ToString() == "" ? "---" : Eval("sd").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("zx1z").ToString() == "" ? "---" : Eval("zx1z").ToString().Replace(",", "")%>
                                            </td>
                                            <td>
                                                <%# Eval("s1m").ToString() == "" ? "---" : Eval("s1m").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("s2m").ToString() == "" ? "---" : Eval("s2m").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("dk").ToString() == "" ? "---" : Eval("dk").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("dh").ToString() == "" ? "---" : Eval("dh").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("s1h").ToString() == "" ? "---" : Eval("s1h").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("5dw").ToString() == "" ? "---" : Eval("5dw").ToString().Replace(",","/")%>
                                                <%--<asp:Label ID="lab_5dw" runat="server" Text="Label"></asp:Label>--%>
                                            </td>
                                            <td>
                                                <%# Eval("3dw").ToString() == "" ? "---" : Eval("3dw").ToString().Replace(",", "/")%>
                                            </td>
                                            <td>
                                                <%# Eval("zx").ToString() == "" ? "---" : Eval("zx").ToString().Replace(",", "")%>
                                            </td>
                                            <td>
                                                <%# Eval("m").ToString() == "" ? "---" : Eval("m").ToString()%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr height="30px" class="back-color color-blue">
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                �ں�
                                            </td>
                                            <td>
                                                ��Ա
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=dd&n=d" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=sd&n=d" target="_blank" class="color-blue">˫��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=zx1z&n=d" target="_blank" class="color-blue">��ѡһע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s1m&n=d" target="_blank" class="color-blue">ɱһ��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s2m&n=d" target="_blank" class="color-blue">ɱ����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=dk&n=d" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=dh&n=d" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=s1h&n=d" target="_blank" class="color-blue">ɱ1��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=5dw&n=d" target="_blank" class="color-blue">5*5*5��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=3dw&n=d" target="_blank" class="color-blue">3*3*3��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=zx&n=d" target="_blank" class="color-blue">ֱѡ1ע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=m&n=d" target="_blank" class="color-blue">5��</a>
                                            </td>
                                        </tr>
                                        </tbody></FooterTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <div id="P_content" runat="server">
                            <table class="ssq-expert-charts">
                                <asp:Repeater ID="rep_pls" runat="server">
                                    <HeaderTemplate>
                                        <tr height="30" class="back-color color-blue">
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                �ں�
                                            </td>
                                            <td>
                                                ��Ա
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pdd&n=p" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=psd&n=p" target="_blank" class="color-blue">˫��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pzx1z&n=p" target="_blank" class="color-blue">��ѡһע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=ps1m&n=p" target="_blank" class="color-blue">ɱһ��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=ps2m&n=p" target="_blank" class="color-blue">ɱ����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pdk&n=p" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pdh&n=p" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=ps1h&n=p" target="_blank" class="color-blue">ɱ1��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=p5dw&n=p" target="_blank" class="color-blue">5*5*5��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=p3dw&n=p" target="_blank" class="color-blue">3*3*3��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pzx&n=p" target="_blank" class="color-blue">ֱѡ1ע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=p5m&n=p" target="_blank" class="color-blue">5��</a>
                                            </td>
                                        </tr>
                                        <tbody id="info">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex + 1%>
                                            </td>
                                            <td>
                                                <%# Eval("C_issue").ToString() == "" ? "---" : Eval("C_issue").ToString()%>
                                            </td>
                                            <td>
                                                <a href=' Person.aspx?name=<%# Server.UrlEncode(Eval("C_name").ToString())%>'
                                                    target="_blank">
                                                    <%# Eval("C_name")%></a>
                                            </td>
                                            <td>
                                                <%# Eval("pdd").ToString() == "" ? "---" : Eval("pdd").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("psd").ToString() == "" ? "---" : Eval("psd").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("pzx1z").ToString() == "" ? "---" : Eval("pzx1z").ToString().Replace(",", "")%>
                                            </td>
                                            <td>
                                                <%# Eval("ps1m").ToString() == "" ? "---" : Eval("ps1m").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("ps2m").ToString() == "" ? "---" : Eval("ps2m").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("pdk").ToString() == "" ? "---" : Eval("pdk").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("pdh").ToString() == "" ? "---" : Eval("pdh").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("ps1h").ToString() == "" ? "---" : Eval("ps1h").ToString()%>
                                            </td>
                                            <td>
                                                <%# Eval("p5dw").ToString() == "" ? "---" : Eval("p5dw").ToString().Replace(",", "/")%>
                                            </td>
                                            <td>
                                                <%# Eval("p3dw").ToString() == "" ? "---" : Eval("p3dw").ToString().Replace(",", "/")%>
                                            </td>
                                            <td>
                                                <%# Eval("pzx").ToString() == "" ? "---" : Eval("pzx").ToString().Replace(",", "")%>
                                            </td>
                                            <td>
                                                <%# Eval("p5m").ToString() == "" ? "---" : Eval("p5m").ToString()%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr height="30" class="back-color color-blue">
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                �ں�
                                            </td>
                                            <td>
                                                ��Ա
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pdd&n=p" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=psd&n=p" target="_blank" class="color-blue">˫��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pzx1z&n=p" target="_blank" class="color-blue">��ѡһע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=ps1m&n=p" target="_blank" class="color-blue">ɱһ��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=ps2m&n=p" target="_blank" class="color-blue">ɱ����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pdk&n=p" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pdh&n=p" target="_blank" class="color-blue">����</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=ps1h&n=p" target="_blank" class="color-blue">ɱ1��</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=p5dw&n=p" target="_blank" class="color-blue">5*5*5��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=p3dw&n=p" target="_blank" class="color-blue">3*3*3��λ</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=pzx&n=p" target="_blank" class="color-blue">ֱѡ1ע</a>
                                            </td>
                                            <td>
                                                <a href="contrast.aspx?Ind=p5m&n=p" target="_blank" class="color-blue">5��</a>
                                            </td>
                                        </tr>
                                        </tbody></FooterTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <div style="margin-top: 10px">
                            ѡ�������鿴ʵʱͳ�ƣ�
                            <asp:DropDownList ID="ddl_cond" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
                            <div id="container" style="min-width: 400px; height: 200px; margin: 0 auto; margin-top: 20px">
                            </div>
                            <div id="containerB" style="min-width: 400px; height: 200px; margin: 0 auto; margin-top: 20px;
                                display: none">
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="yny_neirong_C">
            </div>
        </div>
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
            <div class="footer" style="clear: both;">
                <uc1:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>
    <input id="issue" type="hidden" value="<%=issNum %>" />
    </form>
</body>
</html>
