<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attention.aspx.cs" Inherits="Pinble_Chipped.Attention" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ޱ����ĵ�</title>
    <link href="css/geren.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <!--main����-->
    <div class="user_main">
        <!--��ಿ��-->
        <div class="userm_left">
            <!--�Ϲ��ĺ��򷽰�-->
            <div class="foldbox ">
                <div class="fold_top">
                    <em></em>
                </div>
                <div class="fold_center1">
                    <div class="j-wgt-body">
                        <div class="z_box bm10">
                            <div class="rebox01">
                                <div class="fmnav">
                                    <ul>
                                        <li class="fmcs2"><a onfocus="this.blur()" href="Attention.aspx?att=1">
                                            ����ע����</a></li>
                                        <li class="fmcs1"><a onfocus="this.blur()" href="Attention.aspx?att=2">
                                            ��ע������</a></li>
                                        <li class="fmcs2"><a onfocus="this.blur()" href="Attention.aspx?att=3">
                                            ��ע������</a></li>
                                    </ul>
                                </div>
                                <div>
                                    <div class="reply_type_002">
                                        ���ڹ�ע����<asp:Label ID="lab_UserNum" runat="server"></asp:Label>����</div>
                                    <!--����ע�б�ʼ-->
                                    <div id="MycareDiv">
                                        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablebig">
                                            <asp:Repeater ID="Repeater_My" runat="server" OnItemDataBound="Repeater_My_ItemDataBound">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="font-weight: normal; border-bottom: 1px #cee9f4 dashed;">
                                                            <table width="100%" border="0" class="tableguan">
                                                                <tr>
                                                                    <td rowspan="2" width="15%">
                                                                        <img src="images/avatar-60.png" class="imgs" />
                                                                    </td>
                                                                    <td>
                                                                        <a href="#">
                                                                            <%# Eval("Attention") %>
                                                                        </a><span class="red">��<asp:Label ID="lab_award" runat="server"></asp:Label>�� </span>
                                                                    </td>
                                                                    <td style="border-bottom: 1px dashed #ccc; width: 13%">
                                                                        �鿴ս��
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <span class="gray">
                                                                            <asp:Label ID="lab_lottery" runat="server"></asp:Label>
                                                                            ��<asp:Label ID="lab_ExpectNum" runat="server"></asp:Label>�ڣ� �����ˣ�<font color="red">
                                                                                <asp:Label ID="lab_money" runat="server"></asp:Label></font>Ԫ�ķ�����</span>
                                                                    </td>
                                                                    <td style="border-bottom: 1px dashed #ccc">
                                                                        ��ǰͶע<br />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                    <!--����ע�б����-->
                                    <!--��ע���б�ʼ-->
                                    <div id="careMyDiv" style="display: none;">
                                    </div>
                                    <!--��ע���б����-->
                                    <!--���������б�ʼ-->
                                    <div id="careListDiv" style="display: none;">
                                    </div>
                                    <!--���������б����-->
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="pagelist">
                        <asp:Label ID="litContent" runat="server"></asp:Label>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
                <div class="fold_bottom">
                    <em></em>
                </div>
            </div>
            <!--���¶�̬-->
        </div>
        <!--��ಿ�ֽ���-->
    </div>
    </form>
</body>
</html>
