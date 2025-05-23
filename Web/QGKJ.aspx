<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QGKJ.aspx.cs" Inherits="Pbzx.Web.QGKJ"
    EnableViewState="false" %>

<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全国开奖_拼搏在线彩神通软件</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta name="keywords" content="开奖信息,试机号,体彩,福彩,福利彩票,体育彩票" />
    <meta name="description" content="" />
    <link href="/css/kaijiang.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="javascript/soft.js"></script>

    <link href="/css/soft.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="JavaScript">
        function f_frameStyleResize(targObj){

         var targWin = targObj.parent.document.all[targObj.name];

         if(targWin != null) {

          var HeightValue = targObj.document.body.scrollHeight

          if(HeightValue < 420){HeightValue = 420} 

          targWin.style.pixelHeight = HeightValue;

         }
        }

        function f_iframeResize(){
         bLoadComplete = true; f_frameStyleResize(self);

        }
        var bLoadComplete = false;
        window.onload = f_iframeResize;

    </script>

</head>
<body>
    <form runat="server" id="form1" style="height: 100%">
        <div class="D_Award box2">
            <div class="title">
                <p>
                    <a href="QGKJ.aspx" title="刷新最新开奖信息" class="kai more">刷新最新开奖信息</a><span>最新开奖</span></p>
            </div>
            <div>
                <table width="100%" border="0" cellpadding="1" cellspacing="0" class="MT3">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=FC3D" target="_blank"
                                class="bluelink">
                                <asp:Label ID="lbl3DIssue" runat="server" Text=""></asp:Label>期福彩3D</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lbl3dTime" runat="server" Text=""></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;试机号：[<asp:Label ID="lblTestCode" runat="server"></asp:Label>]<br />
                <asp:Label ID="lblMachine" runat="server" Visible="false" Text=""></asp:Label><%--机--%>
                <asp:Label ID="lblBall" runat="server" Visible="false" Text=""></asp:Label><%--球--%>
                <asp:Label ID="lblTestCodeDY" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;<a href="/pb_cst.htm" target="_blank">彩神通关注码</a>：<asp:Label ID="lblCstHL1_2"
                    runat="server" Text=""></asp:Label>&nbsp;金码：<asp:Label ID="lblJin" runat="server"
                        Text=""></asp:Label><br />
                <asp:Label ID="lblCode" runat="server"></asp:Label>
                <!--排列3-->
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" alt="" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("TCPL35Data") %>&lx=pls"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lblTcpl3Issue" runat="server"></asp:Label>期体彩排列三</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lblPl3Time" runat="server" Text=""></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;开奖号：[<asp:Label ID="lblTcpl3Code" runat="server" Text=""></asp:Label>]<br />
                <!--end-->
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" alt="" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("TCPL35Data") %>"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lblTcpl5Issue" runat="server"></asp:Label>期体彩排列五</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lblPl5Time" runat="server" Text=""></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;开奖号：[<asp:Label ID="lblTcpl5Code" runat="server" Text=""></asp:Label>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" alt="" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("TC7XCData_New") %>"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lbl7xcIssue" runat="server"></asp:Label>期体彩七星彩</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lbl7xTime" runat="server"></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;开奖号：[<asp:Label ID="lbl7xcCode" runat="server" Text=""></asp:Label>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("FC7LC") %>"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lbl7lcIssue" runat="server" Text=""></asp:Label>期福彩七乐彩</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lbl7lTime" runat="server"></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<asp:Label ID="lbl7lcCode" runat="server" Text=""></asp:Label>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("FCSSData") %>"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lblSsqIssue" runat="server"></asp:Label>期福彩双色球</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lblSsqTime" runat="server"></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<asp:Label ID="lblSsqCode" runat="server" Text=""></asp:Label>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" valign="top" class="D_Award1">
                            <img src="/Images/Web/D_Awardli.gif" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("TCDLTData") %>"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lblDltIssue" runat="server" Text=""></asp:Label>期体彩大乐透</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lblDltTime" runat="server"></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<asp:Label ID="lblDltCode" runat="server" Text=""></asp:Label>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="7%" class="D_Award2">
                            <img src="/Images/Web/D_Awardli.gif" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("TC22X5Data") %>"
                                target="_blank" class="bluelink">
                                <asp:Label ID="lbl22x5Issue" runat="server" Text=""></asp:Label>期体彩22选5</a>&nbsp;
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lbl22x5Time" runat="server"></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<asp:Label ID="lbl22x5Code" runat="server" Text=""></asp:Label>]
                <%--  <table width="100%" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td width="7%" valign="top" class="D_Award1">
                            <img src="/Images/Web/D_Awardli.gif" width="4" height="11" class="img_boder" /></td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <a  href="<%=WebInit.webBaseConfig.WebUrl %>Lottery.htm?myUrl=<%=GetPar("TC31X7Data") %>" target="_blank"
                                class="bluelink">
                                <asp:Label ID="lbl31x7Issue" runat="server" Text=""></asp:Label>期体彩31选7</a>
                        </td>
                        <td width="33%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lbl31x7Time" runat="server"></asp:Label></span>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<asp:Label ID="lbl31x7Code" runat="server" Text=""></asp:Label>]--%>
            </div>
        </div>
    </form>
</body>
</html>
