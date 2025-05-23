<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Market_Itemissuance.aspx.cs"
    Inherits="Pinble_Market.Market_Itemissuance" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>条件发布</title>
    <meta http-equiv="pragma"  content="no-cache">  
    <meta http-equiv="Cache-Control"  content="no-cache,  must-revalidate">  
    <meta http-equiv="expires" content="0"> 

    <script language="javascript" type="text/javascript" src="../JS/jquery-1.3.2.js"></script>
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
    <link href="../Css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" charset="gb2312" src="javascript/issue.js?date=new date().gettime()"></script>

</head>
<body style="color: #484848; background:#F1F9FB url(../image/top_bg2.gif) repeat-x; margin:0; padding:0;">
 <uc1:head ID="Head1" runat="server" />

    <form id="form1" runat="server">
        <input id="lotteryType" type="hidden" />
        <input id="userName" type="hidden" value="<%=Pbzx.Common.Method.Get_UserName %>" />
        <div class="img" style="text-align: left;">
            <img src="../image/s_img_logo1.png" alt=""/> 选择自己设定的条件，发布符合条件的号码。同一个条件连续发布10期，此条件就可收费。
            </div>
            <div id="wrap">
        <div style="margin-top: 10px; margin-bottom: 10px;" class="main" >
        <div class="s_box1" >
            <table border="0" width="99%" cellpadding="0" cellspacing="8" class="table_s_all">
                <tr>
                    <td align="right" width="100px">
                        彩 种：
                    </td>
                    <td align="left" colspan="2">
                        <asp:DropDownList ID="ddlLottery" runat="server" Width="150px" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>

                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" rowspan="6">
                        条 件：</td>
                    <td align="left" rowspan="2" style="height: 58px" colspan="2">
                        <asp:DropDownList ID="ddlitemName" runat="server" Width="150px" AppendDataBoundItems="True">
                            <asp:ListItem Value='10000'>--请选择条件--</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp; 
                            点击这里去设置条件：<asp:LinkButton ID="LinkButton1"
                                runat="server" OnClick="LinkButton1_Click"><font color='red'>设定条件>>>></font></asp:LinkButton>
                        <div id="money">设置金额：<input id="txt_money" class="asptext" style="width: 53px" type="text" />/月<font color='red'>(提示：包月收费、设置金额后网友可购买此条件，条件出售后不可无故停止发布内容。每期必须按时发布。如果违规则扣除保证金。)</font></div>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td align="left" rowspan="2" colspan="2">
                        <input id="rad_courageNum" type="radio" name="courage" checked="CHECKED" value="0" />定
                        <input id="rad_NoCourageNum" type="radio" name="courage" value="1" />杀&nbsp;&nbsp;&nbsp;&nbsp;<font
                            color="red">定</font>：中出的号码 <font color="red">杀</font>：去除的号码
                    </td>
                </tr>
                <tr>
                    </tr>
                <tr>
                    <td align="left" rowspan="1" colspan="2">
                         <div id="Condition_Rad" style="width: 100%;">
                        </div></td>
                </tr>
                <tr>
                    <td align="left" rowspan="1" colspan="2">
                        <div id="Condition_ck" style="width: 100%;">
                        </div></td>
                </tr>
                <tr>
                    <td align="right">
                        期 号：</td>
                    <td colspan="2" align="left">
                        <input id="txt_time" class="asptext" type="text" disabled="disabled" readonly="readOnly" />
                        &nbsp;&nbsp;&nbsp;(和实际彩票期号同步，自动生成)
                    </td>
                </tr>
                <%--<asp:Literal ID="ltxt_condition" runat="server"></asp:Literal>--%>
                <tr>
                    <td align="right">
                        发布设置：</td>
                    <td align="left" colspan="2">
                        <asp:RadioButtonList ID="rdbtfabu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdbtfabu_SelectedIndexChanged"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">立即发布</asp:ListItem>
                            <%-- <asp:ListItem Value="1">设置时间</asp:ListItem>--%>
                        </asp:RadioButtonList>
                        <%-- <div id="txtDate" runat="server" visible="false">
                        &nbsp;
                        <asp:DropDownList ID="ddlDateH" runat="server">
                        </asp:DropDownList>年&nbsp;
                        <asp:DropDownList ID="ddlDateY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDateY_SelectedIndexChanged">
                        </asp:DropDownList>月
                        <asp:DropDownList ID="ddlDateR" runat="server">
                        </asp:DropDownList>日
                        <asp:DropDownList ID="ddlDateS" runat="server">
                        </asp:DropDownList>时
                        <asp:DropDownList ID="ddlDateF" runat="server">
                        </asp:DropDownList>分
                    </div>--%>
                    </td>
                </tr>
                <tr id="gut">
                    <td align="right">
                        发布内容：</td>
                    <td align="left">
                        <textarea id="selecttags" name="m_tagsname" class="multieditbox" style="height:80px; width:260px" cols="20" rows="2"></textarea>
                        
                     <%--选择号码功能--%><%--<input id="Button3" type="button" value="button" />
                    <div id="m_tagsItem" style="display:none">
                      <div id="tagClose">关闭</div>
                      <p><a href="javascript:void(0)" onClick="checktag(this)">1</a><a href="javascript:void(0)" onClick="checktag(this)">2</a><a href="javascript:void(0)" onClick="checktag(this)">3</a><a href="javascript:void(0)" onClick="checktag(this)">4</a><a href="javascript:void(0)" onClick="checktag(this)">5</a><a href="javascript:void(0)" onClick="checktag(this)">6</a><a href="javascript:void(0)" onClick="checktag(this)">7</a><a href="javascript:void(0)" onClick="checktag(this)">8</a><a href="javascript:void(0)" onClick="checktag(this)">9</a></p>
                    </div>--%><%--  选择号码功能--%></td>
                    <td align="left">
                        注意事项：<br />
                        1、数字型彩票（例如3D、排列3、排列5、等等）胆码输入格式（号码,号码、或者 号码 号码）<br />输入0-9之间的号码。
                  <br />2、福彩型彩票（例如双色球、等等） 胆码输入格式（号码,号码、或者 号码 号码） <br />单个号码直接输入。(例如：9代表号码是09)。
                  <br />3、组合条件：发布同一期不同的单个彩种条件就是 组合条件。（只适用于数字型彩票）。
                    </td>
                </tr>
                <tr id="gut_1" style="display: none;">
                    <td align="right">
                        条件内容：</td>
                    <td colspan="2" align="left">
                        第一位<input id="txt_one" class="asptext" type="text" style="width: 447px;" /><br />
                        第二位<input id="txt_two" class="asptext" type="text" style="width: 447px;" /><br />
                        第三位<input id="txt_three" class="asptext" type="text" style="width: 447px;" /><br />
                        （输入条件号码！<font color='red'>注意：使用英文输入法</font>）</td>
                </tr>
                <tr id="gut_7xc" style="display: none;">
                    <td align="right">
                        发布内容：</td>
                    <td colspan="2" align="left">
                        第一位<input id="Text1" class="asptext" type="text" /><br />
                        第二位<input id="Text2" class="asptext" type="text" /><br />
                        第三位<input id="Text3" class="asptext" type="text" /><br />
                        第四位<input id="Text4" class="asptext" type="text" /><br />
                        第五位<input id="Text5" class="asptext" type="text" /><br />
                        第六位<input id="Text6" class="asptext" type="text" /><br />
                        第七位<input id="Text7" class="asptext" type="text" /><br />
                        第八位<input id="Text8" class="asptext" type="text" /><br />
                        （输入条件号码！<font color='red'>注意：使用英文输入法</font>）</td>
                </tr>
                <tr id="gut_pl5" style="display: none;">
                    <td align="right">
                        发布内容：</td>
                    <td colspan="2" align="left">
                        第一位<input id="pl1" class="asptext" type="text" /><br />
                        第二位<input id="pl2" class="asptext" type="text" /><br />
                        第三位<input id="pl3" class="asptext" type="text" /><br />
                        第四位<input id="pl4" class="asptext" type="text" /><br />
                        第五位<input id="pl5" class="asptext" type="text" /><br />
                        （输入条件号码！<font color='red'>注意：使用英文输入法</font>）</td>
                </tr>
                <tr id="gut_colligate_3D" style="display:none;">
                    <td align="right">发布内容：</td>
                    <td colspan="2" align="left">
                    胆码：<input id="txt_dm" type="text" /><br />
                        和值：<input id="txt_hz" type="text" /><br />
<%--                        跨度：<input id="txt_kd" type="text" /><br />
                        奇偶：<input id="rad_q" type="radio" name="qo" value="奇数" />奇 <input id="rad_o" type="radio" name="qo" value="偶数" />偶<br />--%>
                        号码组：<input id="txt_hmz" type="text" />
                    </td>
                </tr>
                <tr id="gut_seq" style="display:none;">
                    <td align="right">发布内容 </td>
                    <td colspan="2" align="left">
                        红球胆码：<input id="txt_hqdm" type="text" class="asptext" /><br />
                        蓝球胆码：<input id="txt_lqdm" type="text" class="asptext" /><br />
                        复式推荐：<input id="txt_fstj" type="text" class="asptext" /><font color='red'>(复式格式：01,02,03,04,05,06+01,02,03)</font><br />
                        单式推荐：<input id="txt_ds" type="text" class="asptext" /><font color='red'>(复式格式：01,02,03,04,05,06+01)</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        服务设置：</td>
                    <td colspan="2" align="left">
                        <input id="rad_yse" type="radio" value="1" name="yn" />推荐
                        <input id="rad_no" type="radio" value="0" name="yn" checked="CHECKED" />不推荐
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <font color="#006699">注意：介绍中不要带有：%、-&quot;等半角下的字符，号码间可用 ，号、 空格、隔开。</font>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <input id="Button2" type="button"  style="width:82px;" class="buttonok" value="发布期数" />
                    </td>
                </tr>
            </table>
            </div>
        </div>
        </div>
    </form>
  
    <uc2:MakFooter ID="MakFooter1" runat="server" />
</body>
</html>
