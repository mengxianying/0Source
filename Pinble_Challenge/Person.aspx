<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="Pinble_Challenge.Person" %>

<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register src="Contorls/adv.ascx" tagname="adv" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>����ͳ�� - ƴ����̨ - ƴ�����߲���ͨ���</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/Rel.js" charset="gb2312"></script>
    <script type="text/javascript" src="js/btnSwitch.js" charset="gb2312"></script>
    <script type="text/javascript">
        function tran(obj) {
            if (obj == 3) {
                $("#s").addClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");

                $("#Li3").addClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
                $("#Li9999").removeClass("tabs-nav chartTab_on");

            }
            if (obj == 1) {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").addClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");

                $("#Li3").removeClass("tabs-nav chartTab_on");
                $("#Li1").addClass("tabs-nav chartTab_on");
                $("#Li9999").removeClass("tabs-nav chartTab_on");
            }
            if (obj == 9999) {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").addClass("tabs-nav chartTab_on");

                $("#Li3").removeClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
                $("#Li9999").addClass("tabs-nav chartTab_on");
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
        <uc1:logion1 ID="logion11" runat="server" />
    </div>
<%--    <div class="zanneiy_top_B">
        
        <uc4:adv ID="adv1" runat="server" />
        
    </div>--%>
    <div class="zanneiy_top_C">
        <uc2:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj">
                    <!--�м��滻����������-->
                    <div class="all">
                        <!--���Ĳ���-->
                        <div class="boxL">
                            <div class="face">
                                <img alt="" src="images/img.jpg" width="130" height="130" /></div>
                            <p class="name">
                                <strong>
                                    <%=name %></strong></p>
                            <div class="btnBox">
                                <p>
                                    <a href="HisAchi.aspx?name=<%= name %>" target="_blank">��ʷ�ɼ�</a> <a href="CompOF.aspx" target="_blank">
                                        �ɼ��Ա�</a><br />
                                    <a href="PRanking.aspx" target="_blank">�ɼ�����</a> 
                                  <%-- <a href="PRanking.aspx" target="_blank">
                                        ��������</a>--%>
                                </p>
                            </div>
                            <ul class="info hO">
                                <li class="infoO">
                                    <a href="challenge/UserIntegral.aspx?name=<%= Pbzx.Common.Input.URLEncode(name) %>" target="_blank">�鿴��Ա�������</a>
                                    </li>
                                <%-- <li class="infoT">�ʶ����£�<span class="cB">47 </span>ƪ</li>
                                <li class="infoTh">������£�377 ƪ</li>--%>
                            </ul>
                            <div class="line">
                            </div>
                            <ul class="info hT">
                                <%--<li class="infoF">��ʷ���ʣ�17967��</li>--%>
                                <li class="infoFi">�� ע ����<asp:Label ID="lab_payAtt" runat="server"></asp:Label>��</li>
                            </ul>
                            <div class="line">
                            </div>
                            <p class="intro">
                                <strong>���˼�飺</strong>�����н�������ĵ��¡�</p>
                            <div class="line">
                            </div>
                            <div class="shareBox">
                                <div class="abtned">
                                    <span><a href="javascript:void(0)" class="cr" id="delTo">ȡ����ע</a></span>
                                </div>
                                <input id="addTo" class="abtn" type="button" />

                                <!-- Baidu Button BEGIN -->
<%--                                <div class="bdshare_t bds_tools get-codes-bdshare">
                                    <span class="bds_more" style="height: 16px; line-height: 16px; color: #0E51EB;">����</span>
                                </div>--%>
                                <!-- Baidu Button END -->
<%--                                <p>
                                    <a href="#" class="color-red">�Ƽ�������</a></p>--%>
                            </div>
                        </div>
                        <!--���Ĳ��ֽ���-->
                        <!--�Ҳ�Ĳ��ֿ�ʼ-->
                        <div class="boxR">
                            <div class="chartTitle">
                                <h2 class="fl" style="color: #FF0000">
                                    <%=name %>
                                    ���ڳɼ�</h2>
                                <%--<ul class="chartTab fl">
                                    <li id="ssq" class="tabs-nav chartTab_on"><a href="javascript:void(0)" onclick="perTableS('s')">
                                        ˫ɫ��</a></li>
                                    <li id="fd" class="tabs-nav "><a href="javascript:void(0)" onclick="perTableS('d')">
                                        ����3D</a></li>
                                    <li id="pl" class="tabs-nav "><a href="javascript:void(0)" onclick="perTableS('p')">
                                        ������</a></li>
                                </ul>--%>  
                                 <ul class="chartTab fl">
                                    <li id="Li3" class="tabs-nav chartTab_on"><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=3">
                                        ˫ɫ��</a> </li>
                                    <li id="Li1" class="tabs-nav "><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=1">����3D</a></li>
                                    <li id="Li9999" class="tabs-nav "><a href="Person.aspx?name=<%= Server.UrlEncode(name) %>&lottN=9999">������</a></li>
                                </ul>                              
                                <div class="expert-article-choose fl">
                                    ����
                                    <select id="sel_issN" name="qishu" class="qishu" >
                                        <option value="7">7</option>
                                        <option value="15" selected="selected">15</option>
                                        <option value="30">30</option>
                                    </select>
                                    <asp:DropDownList ID="ddl_issN" runat="server">
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="15" Selected="True">15</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div id="div_Stati1" class="tabs-main" runat="server">
                                <table width="710px">
                                    <tbody>
                                        <tr>
                                        <td></td>
                                        <td>����3��</td>
                                        <td>����6��</td>
                                        <td>ɱ3����</td>
                                        <td>ɱ6����</td>
                                        <td>����1��</td>
                                        <td>����3��</td>
                                        <td>ɱ3����</td>
                                        <td>ɱ6����</td>
                                        <td>12��+3��</td>
                                        <td>9��+2��</td>

                                        </tr>
                                    </tbody>
                                 </table>
                            </div>
                            <div class="details">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="chartTitle">
                                <h2 class="fl" style="color: #005399">
                                    <%=name %>
                                    ��������</h2>
                                <ul class="chartTab fl">
                                    <li id="s" class="tabs-nav chartTab_on"><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=3">
                                        ˫ɫ��</a> </li>
                                    <li id="d" class="tabs-nav "><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=1">����3D</a></li>
                                    <li id="p" class="tabs-nav "><a href="Person.aspx?name=<%= Server.UrlEncode(name) %>&lottN=9999">������</a></li>
                                </ul>
                            </div>
                            <div class="boxB">
                                <%--<ul class="expertChoose">
                                    <li class="chooseunchk"><a href="#">��ʾȫ��</a></li>
                                    <li class="choosechk"><a href="#">���15��</a></li>
                                    <li class="choosechk"><a href="#">�ɼ�չʾ</a></li>
                                    <li class="choosechk"><a href="#">ר�ҹ���</a></li>
                                </ul>--%>
                                <div class="expert-article-text">
                                </div>
                                <div class="tabs-main" style=" width:100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <asp:Repeater ID="rep_data" runat="server" OnItemDataBound="rep_data_ItemDataBound">
                                            <HeaderTemplate>
                                                <tr class="expert-chart-main-top td_white">
                                                    <td>
                                                        ���
                                                    </td>
                                                    <td>
                                                        �ں�
                                                    </td>
                                                    <td>
                                                        ��������
                                                    </td>
                                                    <td>
                                                        ��������
                                                    </td>
                                                    <td>
                                                        �Ƿ��н�
                                                    </td>
                                                    <td>
                                                        �н�����
                                                    </td>
                                                    <td>
                                                        ��������
                                                    </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="td_blue">
                                                    <td>
                                                        <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("C_issue")%>
                                                    </td>
                                                    <td>
                                                        <a href="/Person.aspx?ts=<%# Eval("T_id") %>&name=<%= Server.UrlEncode(name) %>&lottN=<%# Eval("C_lottID") %>"><%# Eval("T_cond") %></a>
                                                    </td>
                                                    <td>
                                                       
                                                        <asp:Label ID="lab_cNum" runat="server" ></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_win" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_num" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="labONum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                
                                <!--��ҳ��Ϣ����-->
                                <div class="pageNav">
                                 <table width="100%">
                                    <tr>
                                        <td>
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" OnPageChanged="AspNetPager1_PageChanged"
                                                PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                CustomInfoSectionWidth="50%" HorizontalAlign="Center" PageSize="6">
                                            </webdiyer:AspNetPager>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </div>
                            <div class="details">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="chartTitle">
<%--                            <h2 class="fl" style="color: #005399">
                                    �ҵĹ�ע</h2>--%>
                                    <ul class="chartTab fl">
                                    <li id="Li2" class="tabs-nav chartTab_on"><a href="javascript:void(0)">�ҹ�ע����</a> </li>
                                    <li id="Li3" class="tabs-nav "><a href="javascript:void(0)">��ע�ҵ���</a></li>
                                </ul>
                            </div>
                            <div class="boxB">
                                <div class="expert-article-text">
                                </div>
                                <div class="tabs-main" style="width: 100%" id="PayAttTable">
                                   <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <asp:Repeater ID="rep_payatt" runat="server">
                                       <HeaderTemplate>
                                        <tr>
                                            <td>
                                                ���
                                            </td>
                                            <td>
                                                ��Ա��
                                            </td>
                                            <td>
                                                ��עʱ��
                                            </td>
                                            <td>
                                                ����
                                            </td>
                                        </tr>
                                       </HeaderTemplate>
                                       <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# (Container.ItemIndex + 1) %>
                                            </td>
                                            <td>
                                                <a href='Person.aspx?name=<%# Server.UrlEncode(Eval("Pa_Idol").ToString()) %>' target="_blank"> <%# Eval("Pa_Idol")%></a>
                                            </td>
                                            <td>
                                                <%# Eval("Pa_time")%>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" onclick="CancelPayAtt('<%# Server.UrlEncode(Eval("Pa_Idol").ToString()) %>')">ȡ����ע</a>
                                            </td>
                                        </tr>
                                       </ItemTemplate>
                                       <FooterTemplate>
                                       </FooterTemplate>
                                       </asp:Repeater>
                                </table>
                                </div>

                                <div class="pageNav">
                                </div>
                            </div>

                        </div>
                    </div>
                    <!--�м��滻�������������-->
                </div>
            </div>
<%--            <div class="yny_neirong_C">
            </div>--%>
        </div>
       
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
        <div class="footer" style="clear: both;">
            <uc3:Footer ID="Footer1" runat="server" />
        </div>
    </div>
    </div>

    
    <input id="uname" type="hidden" value="<%=name %>" />
    <!---�û���--->

    </form>
</body>
</html>
