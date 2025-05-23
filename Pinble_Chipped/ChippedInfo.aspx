<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChippedInfo.aspx.cs" Inherits="Pinble_Chipped.ChippedInfo" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>合买信息</title>

    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //点击确定提交数据
            $("#btn_true").click(function () {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/ChippedAdd",
                    data: "{Qnum:'" + $("#Qnum").val() + "',share:'" + $("#share").val() + "'}",
                    dataType: 'json',
                    complete: function (result) {
                        if (result.responseText == 0) {
                            alert('下单失败');
                            return false;
                        }
                        if (result.responseText == 1) {
                            alert('下单成功\r\n \r\n请到购彩记录中查询详细信息！');
                            parent.$.XYTipsWindow.removeBox();
                            history.go(0);
                            return false;
                        }
                        if (result.responseText == 2) {
                            alert('您的余额不够支付本次购买金额，请先充值');
                            return false;
                        }
                        if (result.responseText == 3) {
                            alert('下单成功\r\n \r\n请到购彩记录中查询详细信息！');
                            $.ajax({
                                type: "POST",
                                contentType: "application/json",
                                url: "../WebChipped.asmx/selectDrawer",
                                data: "{Qnum:'" + $("#Qnum").val() + "'}",
                                dataType: 'json',
                                complete: function (result) {
                                }
                            });
                            parent.$.XYTipsWindow.removeBox();
                            history.go(0);
                            return false;
                        }
                    }
                });
            });

            //关闭页面
            $("#btn_close").click(function () {
                parent.$.XYTipsWindow.removeBox();
            });
        });
    
    </script>

    <style type="text/css">
body{ margin:0; padding:0; }
body, td {font:12px/1.5 '宋体',tahoma;}  
a {color:#0F3F94; text-decoration:none;}
a:hover {color:#F30; text-decoration:underline;}
table{border-collapse:collapse;}
td{empty-cells:show;}
.red{ color:#FF0000;}
.tips_b{
	background-color: #A5BBD3;
}
.tips_box{background:#fff; overflow:hidden; border:1px solid #5e85b2 ; zoom:1; position:relative;}
.tips_title{height:28px; padding-left:10px; padding-right:6px; border-bottom:1px solid #87b0de; background:#b6d0eb url(images/tips_ico.png) repeat-x;overflow:hidden;}
.close{ background:url(images/tips_ico.png) no-repeat; background-position:0px -30px; float:right; width:23px; height:22px; margin-top:3px; text-indent:-99999em; overflow:hidden;}
.close a:hover{background-position:0 -54px;} 
.tips_box h2{
	float:left;
	font-family: simsun;
	font-size: 14px;
	line-height: 28px;
	font-weight: bold;
	color: #00557D;
}

.tips_info{ padding:0px; zoom:1;}
.Ttable th { font-weight:normal; color:#999; background:#f5f5f5; width:100px; border-bottom:#e0e2e1 solid 1px; border-right:#e0e2e1 solid 1px;}
.Ttable td { border-bottom:#e0e2e1 solid 1px;}
.Ttable td td{border:0; text-align:center; border-right:#fff solid 1px; background:#f5f5f5; padding:8px 5px;}
.Ttable .tr1 td { border-bottom:#e0e2e1 solid 1px;}
.Ttable .t1 { padding:10px;}
.Ttable .t2 { padding:15px;}
.TContent { padding:5px; height:86px; overflow:hidden;}


.tips_btn{padding:15px 0; text-align:center;background:#F8F8FA;}
.tips_btn input{vertical-align:middle; margin-right:30PX;}
.btn_Dora_b,a.btn_Dora_b,.btn_Lora_b,a.btn_Lora_b,{ background:url(images/sprite_btn.png) no-repeat; overflow:hidden; text-align:center; display:inline-block; font-size:12px; text-decoration:none; cursor:pointer; border:0; vertical-align:middle; }
.btn_Dora_b,a.btn_Dora_b,a.btn_Dora_b:hover { background-position:-220px -64px; width:100px; height:30px; line-height:32px; color:#fff; font-size:14px; font-weight:bold; text-decoration:none;}
.btn_Lora_b,a.btn_Lora_b,a.btn_Lora_b:hover { background-position:-330px -64px; width:100px; height:30px; line-height:32px; color:#da4901; font-size:14px; font-weight:bold; text-decoration:none;}

</style>
</head>
<body oncontextmenu="self.event.returnValue=false">
    <form id="form1" runat="server">
        <div class="tips_b">
            <div class="tips_box">
                <div class="tips_info">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="Ttable">
                        <tr>
                            <th>
                                方案信息</th>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <asp:Repeater ID="rep_ProjectInfo" runat="server" OnItemDataBound="rep_ProjectInfo_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr class="tr1">
                                                <td>
                                                    彩种</td>
                                                <td>
                                                    注数</td>
                                                <td>
                                                    倍数</td>
                                                <td>
                                                    总金额</td>
                                                <td>
                                                    每份</td>
                                                <td>
                                                    保底</td>
                                                <td>
                                                    提成</td>
                                                <td>
                                                    保密类型</td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lab_lottery" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lab_num" runat="server"></asp:Label></td>
                                                <td>
                                                    <%# Eval("doubles") %>倍</td>
                                                <td>
                                                    ￥<%# Eval("AtotalMoney")%>元</td>
                                                <td>
                                                    ￥<asp:Label ID="lab_SingleMoney" runat="server" Text="Label"></asp:Label>元</td>
                                                <td>
                                                    <%# Eval("Protect") %> 份（<span class='font5'><asp:Label ID="lab_percent" runat="server"></asp:Label>%</span>）</td>
                                                <td>
                                                    <%# Eval("commission")%>%</td>
                                                <td>
                                                    <asp:Label ID="lab_secretType" runat="server"></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                投注内容
                            </th>
                            <td class="t2">
                                <div class="TContent" style=" height:200;overflow:auto">
                                    <asp:Label ID="lab_number" runat="server">
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                认购信息</th>
                            <td class="t2">
                                您本次购买<strong class="red"><asp:Label id="buyShare" runat="server" Text="0"></asp:Label></strong>份，需消费<strong class="red">￥<asp:Label
                            ID="lab_money" runat="server"></asp:Label></strong>元</td>
                        </tr>
                    </table>
                </div>
                <div class="tips_btn">
                    <p align="center" style="padding-left: 24px">
                        <input type="button" id="btn_true" value="确定购买" />
                        <input type="button" id="btn_close" value="关闭页面" />
                        </p>
                </div>
            </div>
<%--            <uc1:Footer ID="Footer1" runat="server" />--%>
        </div>
        <%--流水号--%>
        <input id="Qnum" type="hidden" value="<%=number %>" />
        <%--购买的份数--%>
        <input id="share" type="hidden" value="<%=share %>" />

    </form>
</body>
</html>
