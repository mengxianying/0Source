<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pinble_Chipped.Default" %>

<%@ Register Src="Contorls/login.ascx" TagName="login" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�������</title>
    <link rel="stylesheet" type="text/css" href="Css/global.css" />
    <link rel="stylesheet" type="text/css" href="Css/delault.css" />
    <link type="text/css" rel="Stylesheet" href="Css/Title.css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../WebChipped.asmx/HRanking",
                data: "{LName:'3'}",
                dataType: "json",
                success: function (data) {
                    //��ȡ�ı��                         
                    $("#tab").html(HtmlDecode(data));
                }
            });
        });
        //html����
        function HtmlDecode(text) {
            return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="doc1" class="cp_3d">
        <!--ͷ����ʼ-->
        <div class="header">
            <div class="logo">
            </div>
            <div class="login_info">
                <uc1:login ID="Login1" runat="server" />
            </div>
            <div class="nav">
                <dl class="b-top-nav">
                </dl>
            </div>
        </div>
        <!--����Ŀ¼����-->
        <!--����Ŀ¼��������-->
        <div class="i_main">
            <div class="main_left">
                <div class="m-box by-today">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <h2>
                                ���ֽ�ֹʱ��</h2>
                        </div>
                    </div>
                    <div class="bd">
                        <div class="by-top">
                            <span class="by-t-n">����</span><span class="by-t-d">����Ͷע��ֹ����</span></div>
                        <ul class="by-list">
                            <li>
                                <dl class="sfc">
                                    <dt><a class="cpHref" href="#" target="_blank"></a>
                                        <asp:Label ID="Label1" runat="server" Text="˫ɫ��"></asp:Label>
                                    </dt>
                                    <dd>
                                        ��ע��߽��� 500��Ԫ</dd>
                                </dl>
                                <span class="by-time by-now"><i class="m-mkt m-mkt-tm"></i><span id="_lefttime" style="color: Red">
                                </span></span>
                                <script type="text/javascript">
                                    function _fresh() {

                                        //����ʱ��ȡ�����ļ��е�����                                    
                                        var endtime = new Date("<%=Pbzx.Common.Method.GetSSQDateTime.ToString() %>".replace(/-/g, "/"));

                                        var nowtime = new Date();
                                        var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                        if (leftsecond < 0) { leftsecond = 0; }
                                        __d = parseInt(leftsecond / 3600 / 24);
                                        __h = parseInt((leftsecond / 3600) % 24);
                                        __m = parseInt((leftsecond / 60) % 24);
                                        __s = parseInt(leftsecond % 60);
                                        __all = __d + "��" + __h + "Сʱ" + __m + "��" + __s + "��";
                                        document.getElementById("_lefttime").innerHTML = __all;

                                    }
                                    _fresh()
                                    setInterval(_fresh, 1000);
                                </script>
                            </li>
                            <li>
                                <dl class="sfc">
                                    <dt><a class="cpHref" href="#" target="_blank"></a>
                                        <asp:Label ID="Label2" runat="server" Text="3D"></asp:Label></dt>
                                    <dd>
                                        ��ע��߽��� 1000Ԫ</dd>
                                </dl>
                                <span class="by-time by-now"><i class="m-mkt m-mkt-tm"></i><span id="_lefttime1"
                                    style="color: Red"></span></span>
                                <%--����ʱ��--%>
                                <script type="text/javascript">
                                    function _fresh() {
                                        //����ʱ��ȡ�����ļ��е�����                                    
                                        var endtime = new Date("<%=Pbzx.Common.Method.GetFCDateTime.ToString() %>".replace(/-/g, "/"));

                                        var nowtime = new Date();
                                        var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                        if (leftsecond < 0) { leftsecond = 0; }
                                        __d = parseInt(leftsecond / 3600 / 24);
                                        __h = parseInt((leftsecond / 3600) % 24);
                                        __m = parseInt((leftsecond / 60) % 24);
                                        __s = parseInt(leftsecond % 60);
                                        __all = __d + "��" + __h + "Сʱ" + __m + "��" + __s + "��";
                                        document.getElementById("_lefttime1").innerHTML = __all;
                                    }
                                    _fresh()
                                    setInterval(_fresh, 1000);
                                </script>
                            </li>
                            <li>
                                <dl class="sfc">
                                    <dt><a class="cpHref" href="#" target="_blank"></a>
                                        <asp:Label ID="Label3" runat="server" Text="����͸"></asp:Label></dt>
                                    <dd>
                                        ��ע��߽��� 500��Ԫ</dd>
                                </dl>
                                <span class="by-time by-now"><i class="m-mkt m-mkt-tm"></i><span id="_lefttime2"
                                    style="color: Red"></span></span>
                                <script type="text/javascript">
                                    function _fresh() {

                                        //����ʱ��ȡ�����ļ��е�����                                    
                                        var endtime = new Date("<%=Pbzx.Common.Method.GetTCDLTDateTime.ToString() %>".replace(/-/g, "/"));

                                        var nowtime = new Date();
                                        var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                        if (leftsecond < 0) { leftsecond = 0; }
                                        __d = parseInt(leftsecond / 3600 / 24);
                                        __h = parseInt((leftsecond / 3600) % 24);
                                        __m = parseInt((leftsecond / 60) % 24);
                                        __s = parseInt(leftsecond % 60);
                                        __all = __d + "��" + __h + "Сʱ" + __m + "��" + __s + "��";
                                        document.getElementById("_lefttime2").innerHTML = __all;

                                    }
                                    _fresh()
                                    setInterval(_fresh, 1000);
                                </script>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="gd-plan">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <a href="#" title="" id="a1">���ս�ֹ����</a><a href="#" title="" id="a2" class="an_cur">�������򷽰�</a></div>
                    </div>
                    <div class="bd">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                            <colgroup>
                                <col width="8%" />
                                <col width="12%" />
                                <col width="15%" />
                                <col width="17%" />
                                <col width="15%" />
                                <col width="20%" />
                                <col width="13%" />
                            </colgroup>
                            <tbody>
                                <asp:Repeater ID="rep_chipped" runat="server" OnItemDataBound="rep_chipped_ItemDataBound1">
                                    <HeaderTemplate>
                                        <tr class="">
                                            <th>
                                                ����
                                            </th>
                                            <th>
                                                ������
                                            </th>
                                            <th>
                                                ����
                                            </th>
                                            <th>
                                                ��������
                                            </th>
                                            <th>
                                                �������
                                            </th>
                                            <th>
                                                ��������
                                            </th>
                                            <th>
                                                ����
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                            </td>
                                            <td>
                                                <span class="blue">
                                                    <%# Eval("UserName") %></span>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_lottery" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_documentary" runat="server"></asp:Label>��
                                            </td>
                                            <td>
                                                <%# Eval("AtotalMoney")%>Ԫ
                                            </td>
                                            <td>
                                                <asp:Label ID="lab_progress" runat="server"></asp:Label><span class="red">(��)</span>
                                            </td>
                                            <td>
                                                <span class="c-f-ok"><a href="#" title="" class="public_Dblue"><b>����</b></a></span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <tr class="">
                                    <td colspan="7">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                            FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" OnPageChanged="AspNetPager1_PageChanged"
                                            PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="main_right">
                <div class="m-box luck">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <h2>
                                ���ǵ�Ӯ��</h2>
                        </div>
                    </div>
                    <div class="bd">
                        <div class="l-win">
                            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="zj_table">
                                <colgroup>
                                    <col width="50%" />
                                    <col width="20%" />
                                    <col width="30%" />
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th colspan="3">
                                            <span>���������н�</span>
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                            <div style="height: 158px; overflow: hidden">
                                <table width="100%" border="0" class="tabled">
                                    <asp:Repeater ID="rep_winning" runat="server">
                                        <HeaderTemplate>
                                            <colgroup>
                                                <col width="40%" />
                                                <col width="30%" />
                                                <col width="30%" />
                                            </colgroup>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <span class="blue"><%# Eval("") %></span>
                                                </td>
                                                <td>
                                                    һ��ǰ
                                                </td>
                                                <td>
                                                    <%# Eval("") %>Ԫ
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="m-box top-bonus">
                    <div class="hd">
                        <div class="top">
                            <i class="hd-a"></i><i class="hd-b"></i>
                        </div>
                        <div class="title">
                            <h2>
                                ������</h2>
                            <a href="#" title="������" class="more" target="_blank">����</a></div>
                    </div>
                    <div class="bd">
                        <div class="t-b-tabs" id="dj_list_tabs">
                            <a href="#" title="" id="e1" class="tab_cur">ʤ����</a><a href="#" title="" id="e2">˫ɫ��</a><a
                                href="#" title="" id="e3">����͸</a></div>
                        <div class="t-b-con">
                            <div id="r1">
                                <span style="color: #ccc">
                                    <table width="100%" border="0" class="tabled">
                                        <colgroup>
                                            <col width="60%" />
                                            <col width="40%" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                <span class="blue">�´�ʦ��</span>
                                            </td>
                                            <td>
                                                <span class="red">4312312Ԫ</span>
                                            </td>
                                        </tr>
                                    </table>
                                </span>
                            </div>
                            <div id="r2" style="display: none;">
                            </div>
                            <div id="r3" style="display: none;">
                                <span style="color: #ccc">���ڼ���...</span></div>
                            <div id="r4" style="display: none;">
                                <span style="color: #ccc">���ڼ���...</span></div>
                        </div>
                    </div>
                </div>
                <div class="service kefuPic">
                    <img src="images/121212.png" alt="" title="" /></div>
            </div>
        </div>
        <div id="ft">
        </div>
    </div>
    </form>
</body>
</html>
