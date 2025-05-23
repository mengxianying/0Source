<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelUpload.aspx.cs" Inherits="Pinble_DataRivalry.RelUpload"   validateRequest="false" %>

<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Assembly="eHtmlInputFile" Namespace="JiangLiang.MyControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <title>上传大底 - 大底比拼 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/MethodJs.js"></script>
    <style type="text/css">
        .style1
        {
            width: 480px;
        }
    </style>
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
                    <!--中间替换的内容区域-->
                    <div class="all">
                        <!--头部导航开始-->
                        <!--头部导航结束-->
                        <div class="member-body">
                            <div class="member-body-l">
                                <div class="member_left_top">
                                </div>
                                <div class="member-left">
                                    <!--菜单项-->
                                    <div>
                                        <div class="gr-box">
                                            <div class="gr-top">
                                                <div class="gr-left">
                                                </div>
                                                <div class="gr-right">
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="gr-main">
                                                <dl class="left-list">
                                                    <dt class="left-list-title"><a href="#" class="color-blue ">
                                                        <img class="img_2" src="images/member-left-ico11.gif">发布预测</a> </dt>
                                                    <dd class="left_icon">
                                                        <a href="RelUpload.aspx?ln=dzx" class='yuce-a'>
                                                            <img src="images/member-left-triangle.gif">3D单选</a></dd>
                                                    <dd class="left_icon">
                                                        <a href="RelUpload.aspx?ln=dzux" class='yuce-a'>
                                                            <img src="images/member-left-triangle.gif">3D组选</a></dd>
                                                    <dd class="left_icon">
                                                        <a href="RelUpload.aspx?ln=pd" class='yuce-a'>
                                                            <img src="images/member-left-triangle.gif">排三单选</a></dd>
                                                    <dd class="left_icon">
                                                        <a href="RelUpload.aspx?ln=pzd">
                                                            <img src="images/member-left-triangle.gif">排三组选</a></dd>
                                                    <%--                                                    <dt class="left-list-title"><a href="#" class="color-blue ">
                                                        <img class="img_2" src="images/member-left-ico15.gif">账户中心</a></dt>--%>
                                                </dl>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </div>
                                <div class="member_left_bottom">
                                </div>
                            </div>
                            <div class="member-body-r">
                                <div class="main-body">
                                    <div class="listMain ha">
                                        <p class="fs14">
                                            <span style="padding-top: 2px;">
                                                <asp:Label ID="lab_issue" runat="server"></asp:Label>期 <font color="#080ef7" size="3px">
                                                    <span id="lname">
                                                        <asp:Label ID="lab_lottName" runat="server">3D单选</asp:Label></span></font>上传&nbsp;&nbsp;&nbsp;
                                                <font color="#080ef7"><span id="uName">您没有登录</span></font></span> <span id="endTime"
                                                    style="margin-left: 50px">大底上传截止时间：<asp:Label ID="lab_endTime" runat="server" Text="Label"></asp:Label></span></p>
                                    </div>
                                    <div class="listTab" style="display: none;">
                                        <p class="fl listNubT fontW">
                                            添加内容</p>
                                    </div>
                                    <div class="listTab">
                                        <p class="fl listNubT fontW">
                                            上传大底</p>
                                        <p class="fl listNubT fontW">
                                            <span style="margin-left: 20px; color: #080ef7">期待你的神机妙算 </span>
                                        </p>
                                    </div>
                                    <div id="show-hide-area">
                                        <div class="ball-area">
                                            <div class="ball-area-content-27">
                                                <div class="ball-area-l-27">
                                                    <cc1:HtmlInputFiles ID="HtmlInputFiles1" runat="server" FileFilter=".TxT" MaxCount="9"
                                                        RecordCount="9" AddButtonVisible="False" ReduceButtonVisible="False" />
                                                </div>
                                                <div class="ball-area-r-27">
                                                    说明：<br />
                                                    1、只允许上传txt文件<br />
                                                    2、上传的大底每注号码必须是3位<br />
                                                    3、上传中请勿重复点击上传按钮。<br />
                                                    4、上传中请勿关闭当前页面。<br />
                                                    5、单选大底上传文件的大底注数200-900注。<br />
                                                    6、组选大底上传文件的大底注数30-120注。<br />
                                                </div>
                                                <br />
                                                <span class="quick-sub">
                                                    <asp:Button ID="BtnUpfile" runat="server" OnClick="BtnUpfile_Click" CssClass="submit-btn" />
                                                    <%-- <asp:Button ID="Cancel" runat="server" Text="取消发布" OnClick="Cancel_Click" />--%>
                                                </span>
                                            </div>
                                        </div>
                                        <!--显示列表-->
                                        <div class="show">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                    <div class="listTab">
                                                        <p class="fl listNubT fontW">
                                                            手工输入区:</p>
                                                        <p class="fl listNubT fontW">
                                                            <span style="margin-left: 20px; color: #080ef7">（可以粘贴大底） </span>
                                                        </p>
                                                    </div>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1" rowspan="2">
                                                        <asp:TextBox ID="txt_n" runat="server" Height="170px" TextMode="MultiLine" Width="478px"
                                                            BorderWidth="1"></asp:TextBox>
                                                    </td>
                                                    <td align="left">

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="bottom">
                                                      <span class="quick-sub">
                                                            <asp:Button ID="btn_handup" runat="server" CssClass="submit-btn" 
                                                            onclick="btn_handup_Click" />
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <!--编辑器-->
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--中间替换的内容区域结束-->
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
    </form>
</body>
</html>
