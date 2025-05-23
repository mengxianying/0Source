<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tark.aspx.cs" Inherits="Pinble_Chipped.Tark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>定制跟单</title>
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
    <!--左侧部分-->
    <div class="userm_left">
        <!--发起合买方案-->
        <div class="foldbox ">
            <div class="fold_center1">
                <div class="title">
                    <em><b>&nbsp;&nbsp;&nbsp;&nbsp;<%=name %>可以被定制的彩种</b></em></div>
                <div class="j-wgt-body" id="tab_list">
                    <table class="custom-table" cellpadding="0" cellspacing="0">
                        <asp:Repeater ID="rep_tracking" runat="server" OnItemDataBound="rep_tracking_ItemDataBound">
                            <HeaderTemplate>
                                <tr>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        彩种
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        战绩
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        累计中奖
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        已定制/可定制
                                    </td>
                                    <td style="background: url(images/index_th_bg.png) repeat-x bottom; height: 30px;
                                        font-weight: normal; border-bottom: 1px solid #cee9f4; color: #333;">
                                        定制跟单
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
                                            <asp:Label ID="lab_allMoney" runat="server"></asp:Label>元</strong></span>
                                    </td>
                                    <td class="total">
                                        <asp:Label ID="lab_trackingNum" runat="server"></asp:Label>/1000
                                    </td>
                                    <td class="operation">
                                        <a href="javascript:void(0)" class="J_CustomBtn toggle" id="cSfc_1" onclick="Display_tarcking(<%# Eval("cfg_state") %>,<%# Container.ItemIndex + 1 %>,<%= g_num %>)">
                                            定制跟单</a>
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
                                                                定制说明：</label>
                                                        </th>
                                                        <td>
                                                            <p class="tip">
                                                                1、您设定的每期认购方案个数将根据发起人发单时间来进行依次购买。<br />
                                                                2、系统根据每次认购方案金额自动认购发起人发起合买的相应份数，若认购方案金额小于每份金额则无法认购该方案。<br />
                                                                例：每次认购金额10元，合买方案每份3元，则自动认购最大的份额为3份。以此类推。<br />
                                                                3、用户不用预付定制跟单金额，只需账户余额满足每次认购金额即可成功定制。<br />
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr class="tr3">
                                                        <th>
                                                            <label>
                                                                每次认购金额：</label>
                                                        </th>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                            <input type="text" maxlength="5" id="tbMoney_<%# Container.ItemIndex+1 %>" class="txt" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" />元（最低<span>1</span>元）
                                                        </td>
                                                    </tr>
                                                    <tr class="tr2">
                                                        <th>
                                                            <label>
                                                                定制次数：</label>
                                                        </th>
                                                        <td>
                                                            ≤
                                                            <input type="text" maxlength="5" class="txt" id="txtNum_<%# Container.ItemIndex+1 %>" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'');Range(this)" />个（至少1个）
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="border: none;">
                                                            <div class="fgline">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align:center">
                                                            <input id="determined" type="button" value="立即定制" onclick="Frozen('<%# Eval("cfg_state") %>','<%= name %>','<%# Container.ItemIndex+1 %>')" />
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
    <!--左侧部分结束-->
    <%--发单人的用户名--%>
    <input id="name" type="hidden" value="<%= name %>" />
    </form>
</body>
</html>
