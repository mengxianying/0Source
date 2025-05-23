<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="Pinble_Chipped.Tracking" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="Contorls/login.ascx" tagname="login" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>���Ƹ���</title>
    <link rel="stylesheet" type="text/css" href="Css/Title.css" />
    <link type="text/css" rel="Stylesheet" href="Css/footer.css" />

    <link href="Css/geren.css" rel="stylesheet" type="text/css" />

    <link href="Css/style.css" rel="stylesheet" type="text/css" />


    
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script type="text/javascript" charset="gb2312" src="js/public.js?date=new date().gettime()"></script>
</head>
<body>
    <form id="form1" runat="server">
          <div class="header">
            <div class="logo">
            </div>
            <div class="login_info">
              <uc2:login ID="login1" runat="server" />
            </div>
        </div>

    <!--��ಿ��-->
    <div class="userm_left">
        <!--������򷽰�-->
        <div class="foldbox ">
            <div class="fold_top">
               
            </div>
            <div class="fold_center1">
                <div class="title">
                    <em><b>&nbsp;&nbsp;&nbsp;&nbsp;<%=name %>���Ա����ƵĲ���</b></em></div>
                <div class="j-wgt-body" id="tab_list">
                    <table class="custom-table" cellpadding="0" cellspacing="0">
                        <asp:Repeater ID="rep_tracking" runat="server" OnItemDataBound="rep_tracking_ItemDataBound">
                            <HeaderTemplate>
                                <tr>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        ����
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        ս��
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        �ۼ��н�
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        �Ѷ���/�ɶ���
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        ���Ƹ���
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="sfc">
                                    <td>
                                        <span>
                                            <asp:Label ID="lab_lotteryName" runat="server"></asp:Label></span>
                                    </td>
                                    <td class="count record">
                                        *****
                                    </td>
                                    <td class="rate">
                                        <span><strong>
                                            <asp:Label ID="lab_allMoney" runat="server"></asp:Label>Ԫ</strong></span>
                                    </td>
                                    <td class="total">
                                        <asp:Label ID="lab_trackingNum" runat="server"></asp:Label>/1000
                                    </td>
                                    <td class="operation">
                                        <a href="javascript:void(0)" class="J_CustomBtn toggle" id="cSfc_1" onclick="Display_tarcking(<%# Eval("cfg_state") %>,<%# Container.ItemIndex + 1 %>,<%= g_num %>)">
                                            ���Ƹ���</a>
                                        <asp:Label ID="lab_Customized" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <div id="div_<%# Container.ItemIndex+1 %>" style="display: none;">
                                            <div class="custom-area">
                                                <table class="form-table" cellpadding="0" cellspacing="0">
                                                    <tr class="tr1">
                                                        <th>
                                                            <label>
                                                                ����˵����</label>
                                                        </th>
                                                        <td>
                                                            <p class="tip">
                                                                1�����趨��ÿ���Ϲ��������������ݷ����˷���ʱ�����������ι���<br />
                                                                2��ϵͳ����ÿ���Ϲ���������Զ��Ϲ������˷���������Ӧ���������Ϲ��������С��ÿ�ݽ�����޷��Ϲ��÷�����<br />
                                                                ����ÿ���Ϲ����10Ԫ�����򷽰�ÿ��3Ԫ�����Զ��Ϲ����ķݶ�Ϊ3�ݡ��Դ����ơ�<br />
                                                                3���û�����Ԥ�����Ƹ�����ֻ���˻��������ÿ���Ϲ����ɳɹ����ơ�<br />
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr class="tr3">
                                                        <th>
                                                            <label>
                                                                ÿ���Ϲ���</label>
                                                        </th>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                            <input type="text" maxlength="5" id="tbMoney_<%# Container.ItemIndex+1 %>" class="txt" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" />Ԫ�����<span>1</span>Ԫ��
                                                        </td>
                                                    </tr>
                                                    <tr class="tr2">
                                                        <th>
                                                            <label>
                                                                ���ƴ�����</label>
                                                        </th>
                                                        <td>
                                                            ��
                                                            <input type="text" maxlength="5" class="txt" id="txtNum_<%# Container.ItemIndex+1 %>" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'');Range(this)" />��������1����
                                                        </td>
                                                    </tr>
                                                    
<%--                                                    <tr class="tr4" style="">
                                                        <th>
                                                            <label>
                                                                �ֻ����ŷ���</label>
                                                        </th>
                                                        <td class="waitd2">
                                                            <input name="" type="checkbox" value="begin" />�������������ʾ<br />
                                                            <input name="" type="checkbox" value="end" />�������������ʾ��
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="2" style="border: none;">
                                                            <div class="fgline">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align:center">
                                                            <input id="determined" type="button" value="��������" onclick="Frozen('<%# Eval("cfg_state") %>','<%= name %>','<%# Container.ItemIndex+1 %>')" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Label ID="lab_Info" runat="server"></asp:Label></table>
                </div>
    <!--��ಿ�ֽ���-->
    <%--�����˵��û���--%>
    <input id="name" type="hidden" value="<%= name %>" />
    <uc1:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
