<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Pinble_Ask.Default" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc9" %>
<%@ Register Src="Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc7" %>
<%@ Register Src="Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc8" %>
<%@ Register Src="Contorls/UcType.ascx" TagName="UcType" TagPrefix="uc6" %>
<%@ Register Src="Contorls/UcQuestionR.ascx" TagName="UcQuestionR" TagPrefix="uc5" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc4" %>
<%@ Register Src="Contorls/UcQuestion.ascx" TagName="UcQuestion" TagPrefix="uc3" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>拼搏吧 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="拼搏吧 福利彩票 体育彩票 彩票技巧 福彩 体彩" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:UcAskHead ID="UcAskHead1" runat="server"></uc1:UcAskHead>
            <div class="main">
                <div class="ml">
                    <uc6:UcType ID="UcType1" runat="server"></uc6:UcType>
                    <uc7:UcPicAds ID="UcPicAds1" runat="server" PlaceType="拼搏吧左一"></uc7:UcPicAds>
                    <uc8:UcJsADs ID="UcJsADs1" runat="server" PlaceType="拼搏吧左一JS"></uc8:UcJsADs>
                    <div class="mlbox1">
                        <div class="mlbox1_title">
                            在线客服
                        </div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <uc9:UC_QQ ID="UC_QQ1" runat="server"></uc9:UC_QQ>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="mc">
                    <div class="mcbox1">
                        <div class="mcbox1_title">
                            <p>
                                <a href="/QuestionListOne.aspx?strSate=0" class="more" title="点击查看本栏更多内容" target="_blank">
                                    更多>></a><span><a href="/QuestionListOne.aspx?strSate=0" title="点击查看本栏更多内容" target="_blank">
                                        待解决问题</a></span></p>
                        </div>
                        <div class="mcbox1_content">
                            <uc3:UcQuestion ID="UcQuestion1" runat="server" TitleLength="35" State="0" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAds2" runat="server" PlaceType="拼搏吧中一" />
                    <uc8:UcJsADs ID="UcJsADs2" runat="server" PlaceType="拼搏吧中一JS" />
                    <div class="mcbox1 mMT">
                        <div class="mcbox1_title">
                            <p>
                                <a href="/QuestionListOne.aspx?strTag=Hot" class="more" title="点击查看本栏更多内容" target="_blank">
                                    更多>></a><span> <a href="/QuestionListOne.aspx?strTag=Hot" title="点击查看本栏更多内容" target="_blank">
                                        近期热点</a></span></p>
                        </div>
                        <div class="mcbox1_content">
                            <uc3:UcQuestion ID="UcQuestion2" runat="server" IsHot="1" TitleLength="35" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAds3" runat="server" PlaceType="拼搏吧中二" />
                    <uc8:UcJsADs ID="UcJsADs3" runat="server" PlaceType="拼搏吧中二JS" />
                    <div class="mcbox1 mMT">
                        <div class="mcbox1_title">
                            <p>
                                <a href="/QuestionListOne.aspx?strTag=High" class="more" title="点击查看本栏更多内容" target="_blank">
                                    更多>></a><span><a href="/QuestionListOne.aspx?strTag=High" title="点击查看本栏更多内容" target="_blank">悬赏分问题</a></span></p>
                        </div>
                        <div class="mcbox1_content">
                            <uc3:UcQuestion ID="UcQuestion3" runat="server" IsHighLargessPoint="1" TitleLength="35" />
                        </div>
                    </div>
                </div>
                <div class="mr">
                    <div class="mrbox1">
                        <div class="mrbox1_title">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        &nbsp;<a href="/Bulletin_Ask.aspx" target="_blank"><font color="#E57B01">最新公告</font></a>
                                    </td>
                                    <td align="right" valign="middle">
                                        <a href="/Bulletin_Ask.aspx" target="_blank"><font color="#E57B01" style="font-weight:normal;">更多>></a>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="mrbox1_content">
                            <uc4:Bulletin_r ID="Bulletin_r1" runat="server" ClassCss="Linl12Green" TitleLength="18"
                                IntChannelID="13" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAds4" runat="server" PlaceType="拼搏吧右一" />
                    <uc8:UcJsADs ID="UcJsADs4" runat="server" PlaceType="拼搏吧右一JS" />
                    <div class="mrbox2 mMT">
                        <div class="mrbox2_title">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        &nbsp;<a href="/QuestionListOne.aspx?strTag=Commend">精华推荐</a>
                                    </td>
                                    <td align="right" valign="middle">
                                        <a href="/QuestionListOne.aspx?strTag=Commend" class="more" style="font-weight:normal;" title="点击查看本栏更多内容" target="_blank">
                                            更多>></a>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="mrbox1_content">
                            <uc5:UcQuestionR ID="UcQuestionR1" runat="server" TitleLength="16" IsCommend="1"></uc5:UcQuestionR>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAds5" runat="server" PlaceType="拼搏吧右二" />
                    <uc8:UcJsADs ID="UcJsADs5" runat="server" PlaceType="拼搏吧右二JS" />
                    <div class="mrbox2 mMT">
                        <div class="mrbox2_title">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        &nbsp;<a href="/QuestionListOne.aspx?strSate=1">新解决的问题</a>
                                    </td>
                                    <td align="right" valign="middle">
                                        <a href="/QuestionListOne.aspx?strSate=1" style="font-weight:normal;">更多>></a>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="mrbox1_content">
                            <uc5:UcQuestionR ID="UcQuestionR2" runat="server" State="1" TitleLength="16" />
                        </div>
                    </div>
                </div>
            </div>
            <uc2:UcAskFoot ID="UcAskFoot1" runat="server"></uc2:UcAskFoot>
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
