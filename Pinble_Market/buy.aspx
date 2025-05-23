<%@ Page Language="C#" AutoEventWireup="true" Codebehind="buy.aspx.cs" Inherits="Pinble_Market.buy" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>��Ʊ���й���</title>
    <meta http-equiv="pragma"  content="no-cache">  
    <meta http-equiv="Cache-Control"  content="no-cache,  must-revalidate">  
    <meta http-equiv="expires" content="0"> 
    <link href="Css/independent.css" rel="stylesheet" type="text/css" />
<style type="text/css">
body {
	color: #484848;
	padding:0;
	background-color: #E3F4F9;	
	font-size: 12px;
	margin-top: 0;
	margin-right: auto;
	margin-bottom: 0;
	margin-left: auto;
}
.HeadLogin{
	background-image: url(../image/login_Bt1.jpg);
	background-repeat: repeat-x;
	height: 23px;
	width: 55px;
	background-color: #FFF686;
	border:0px;
	cursor:pointer
}

.HeadReset{
	background-image: url(../image/login_Bt2.jpg);
	background-repeat: repeat-x;
	height: 23px;
	width: 55px;
	background-color: #FFF686;
	border:0px;
	cursor:pointer
}

</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="wrap">
    <div class="top">
        <ul class="topNav">
            <li class="nav1"><a href="http://market.pinble2.com">��ҳ</a></li>
            <li class="nav2"><a href="#">��ӭע��</a></li>
            <li class="nav2"><a href="#">��������</a></li>
        </ul>
        <h1 class="logo">
            <img src="image/sprite.png" /></h1>
        <h1 class="icon">
            <img src="image/sprite1.png" width="696" height="57" border="0" usemap="#Map" />
            <map name="Map" id="Map">
                <area shape="rect" coords="8,3,47,58" href="http://www.pinble.com" target="_blank" />
                <area shape="rect" coords="76,5,131,59" href="#" target="_blank" />
                <area shape="rect" coords="156,4,213,58" href="#" />
                <area shape="rect" coords="245,5,293,61" href="#" target="_blank" />
                <area shape="rect" coords="335,3,371,62" href="http://bar.pinble.com/" target="_blank" />
                <area shape="rect" coords="403,4,462,61" href="#" />
                <area shape="rect" coords="490,3,542,61" href="http://market.pinble.com" />
                <area shape="rect" coords="568,4,617,60" href="#" />
                <area shape="rect" coords="646,5,694,62" href="#" />
            </map>
        </h1>
    </div>
    <div class="clear">
    </div>

    <div class="main">
<%--        <div class="z_title">
            <h2>
                3D������</h2>
        </div>--%>
       
        <div class="infojiezhi">
            ��Ŀ������<asp:Label ID="lan_NvarName" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">�۸� <asp:Label
                ID="lab_price" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
            ����ʱ�䣺<asp:Label ID="lab_time" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            ������Ա��<asp:Label ID="lab_user" runat="server"></asp:Label>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotable">
            <tr>
                <td class="tdl">
                    ��Ա��Ϣ</td>
                <td class="tdr">
                    <span class="blue2 bold">�н�����<img src="image/gold.gif" border="0" /> 37%
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </span><span class="gz_detail"><span class="blue2 bold">��ע������<asp:Label ID="lab_attention"
                        runat="server"></asp:Label>��</span><span class="blue2 bold">&nbsp;&nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton
                            ID="lbtn_attention" runat="server" OnClick="lbtn_attention_Click">��ע�����Ŀ</asp:LinkButton></span>
                        <!--<span id="zjinfo" style="display:none;">-->
                        <span class="getmoney"><span class="blue2 bold">���н�������</span><span id="cnt"></span><span
                            class="red" id="after_bonus">10��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span><span
                                class="getmoney"><span class="gray">�Ѿ����� <font color="green"><asp:Label ID="lab_num" runat="server"></asp:Label></font> ��</span><span class="gray"></span>&nbsp;&nbsp;
          &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<a href='History.aspx?lottery=<%=NvarName %>&name=<%=TypeName %>&user=<%= userId%>' target="_blank"><span class="red"
                                        id="Span1">�鿴����</span></a>(��ʾ�����鲻��ʾ��ǰ��һ�ڡ�ֻ��һ�ڵ���Ŀ����������û����) </span>
                </td>
            </tr>
            <tr>
                <td class="tdl">
                    ������Ϣ</td>
                <td height="30" class="tdr">
                    <span class="getmoney"><span class="gray">�����ںţ�</span><span class="gray"><asp:Label
                        ID="lab_upNum" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span class="gray">�����ںţ�</span><asp:Label
                            ID="lab_NewNum" runat="server"></asp:Label></span>
                        <span class="getmoney"><span class="gray">�������ݣ�<asp:Label ID="lab_NumGut" runat="server"></asp:Label> </span><span class="getmoney"><span
                            class="gray">�������ݽ��ܣ�<asp:Label ID="lab_say" runat="server"></asp:Label> </span><span class="gray"></span>&nbsp;</span>
                </td>
            </tr>
            <tr>
                <td class="tdl">
                    ��Ҫ����</td>
                <td class="tdr">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <div style="margin-top: 5px; margin-bottom:15px ">
                                    <div id="showUserInfo" class="tishi">
                                        <strong><asp:Label ID="lab_name" runat="server"></asp:Label></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                            ID="lbtn_login" runat="server">ע���Ϊ�߼��û�</asp:LinkButton> 
                                        <asp:Label ID="lab_buyHistory" runat="server"></asp:Label></div>
                                </div>
                                <span class="blue2 bold">ѡ�񶩹�ʱ�䣺<asp:DropDownList ID="Cob_time" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Cob_time_SelectedIndexChanged">
                                <asp:ListItem Value="0">--��ѡ��--</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                                </span><span class="blue2 bold">&nbsp;&nbsp;��ʼʱ�䣺<asp:Label ID="lab_beginTime" runat="server"></asp:Label></span> <span class="blue2 bold">
                                    &nbsp;&nbsp;&nbsp;����ʱ�䣺<asp:Label ID="lab_endTime" runat="server"></asp:Label></span> <span class="getmoney"><span class="blue2 bold">
                                        �������ã�
                                        <input type="radio" name="radiobutton" value="0" />
                                        �Զ�����
                                        <input type="radio" name="radiobutton" value="1" checked="CHECKED" />
                                        �ֶ�����</span></span> <span class="quedingr">
                                            <div style="line-height: 30px">
                                                <%--<input id="agreement" type="checkbox" value="1" checked="checked" />--%>
                                                <asp:CheckBox ID="agreement" runat="server" Checked="True" />
                                                �����Ķ���<a href="UserAgreement.aspx" target="_blank">���û�����Э�顷</a>��ͬ���������</div>
                                        </span>
                            </td>
                            <td width="1" align="right" style="padding: 0 40px 0 20px; height: 134px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/btn_queding2.bmp" OnClick="ImageButton1_Click" />
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="tdl">
                    ������ʷ</td>
                <td class="td_fangan">
                    <table width="100%" border="0" align="center" cellspacing="1" class="fangan_table">
                                <asp:Repeater ID="Tab_BuyInfo" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                                            <td >
                                                ���</td>
                                            <td >
                                                ���</td>
                                            <td >
                                                ��ʼʱ��</td>
                                            <td >
                                                ����ʱ��</td>
                                            <td >
                                                ����ʱ��</td>
                                            <td >
                                                �۸�</td>
                                            <td >
                                                ����</td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                            <td >
                                               <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                            </td>
                                            <td >
                                            <asp:Label ID="Lab_username" runat="server"></asp:Label><%# Eval("buyuserid") %></td>
                                            <td >
                                                <%# string.Format("{0:u}", Eval("BeginTime")).Substring(0, 10) %>
                                            </td>
                                            <td >
                                                <%# string.Format("{0:u}", Eval("EndTime")).Substring(0, 10)  %>
                                            </td>
                                            <td >
                                                <%# Eval("Term") %>����
                                            </td>
                                            <td >
                                                <%# Eval("Price") %>Ԫ/��
                                            </td>
                                            <td >
                                                ��������ÿ�ζ����ջ�
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="litContent" runat="server"></asp:Label><tr>
                                    <td colspan="9" style="background-color: #FFFFFF;">
                                        <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" custominfotextalign="Center"
                                            firstpagetext="��һҳ" lastpagetext="���һҳ" nextpagetext="��һҳ" onpagechanged="AspNetPager1_PageChanged"
                                            prevpagetext="��һҳ" showcustominfosection="Right" showinputbox="Always" shownavigationtooltip="True"
                                            width="100%" backcolor="Transparent" custominfostyle='vertical-align:middle;'
                                            custominfosectionwidth="35%" horizontalalign="Center">
                            </webdiyer:aspnetpager>
                                    </td>
                                </tr>
                            </table>
                </td>
            </tr>
        </table>
    </div>
     
    <div class="footbg">
        <div class="wrap_footer">
            <div class="kong10">
            </div>
            <div class="footer_nav01">
                �������� | ƴ������ | �û�ע�� | ��ϵ���� | ��վ����</div>
            <div class="footer_nav02">
                <strong>�ȵ㵼����</strong>��Ʊ | �����Ʊ | ������Ϣ | ��ʱ�ȷ� | ʤ���� | ����� | ˫ɫ�� | ���ǲ� | ����3 | ����5
                | ����3D | 22ѡ5 | 29ѡ7 | ����͸ | ʱʱ�� | ʱʱ��</div>
            <div class="copy_new">
                ��Ȩ���У�ƴ�����ߣ��������Ƽ���չ���޹�˾ ��Ȩ����2004-2010 ��ICP��05051578�� ��ICP֤050806��<br />
                <font color="#ff0000">������������</font>�Ǳ�վ�ڲ��������ϸ�����α����վ���е���Ǳ�վ�������������κ���ʧ���κη������Ρ�
                <div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
