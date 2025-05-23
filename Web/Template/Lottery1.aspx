<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lottery1.aspx.cs" Inherits="Pbzx.Web.Template.Lottery1" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>

<%@ Import Namespace="Pbzx.Common" %>

<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>开奖信息 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩神通软件www.pinble.com" />
    <meta name="robots" content="none" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/lottery.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" charset="gb2312" src="/javascript/rather.js"></script>



    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <uc2:Head ID="Head1" runat="server" />
        <div class="bodyw MT">
            <!----左边导航----->
            <div class="kai_lw">
                <div class="kai_lbg1">
                    <span class="kai_ltitle">彩票类别 </span><span class="kai_Time">
                      <script type="text/javascript">
     setInterval('dv.innerText=getDate()',1000)
                        </script>

                        <asp:Label ID="dv" runat="server"></asp:Label>
                        
                    </span>
                </div>
                <div class="kai_lbg2">
                        <a href="javascript:void(0)" onclick="PresentList('全国开奖');LotteryQiehuan('aa','LM',1,5);" style="cursor: pointer;" class="kai_menubg_zy">
                        <div class="kai_menubg_open" id="aa1">
                            全国开奖
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM1" runat="server">
                    </div>
                    <a href="javascript:void(0)" onclick="PresentList('各省福彩');LotteryQiehuan('aa','LM',2,5);" style="cursor: pointer;" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa2">
                            各省福彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM2" runat="server" style="display: none;">
                    </div>
                    <a href="javascript:void(0)" onclick="PresentList('各省体彩');LotteryQiehuan('aa','LM',3,5);" style="cursor: pointer;" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa3">
                            各省体彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM3" runat="server" style="display: none;">
                    </div>
                    <a href="javascript:void(0)" onclick="PresentList('高频福彩');LotteryQiehuan('aa','LM',4,5);" style="cursor: pointer;" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa4">
                            高频福彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM4" runat="server" style="display: none;">
                    </div>
                    <a href="javascript:void(0)" onclick="PresentList('高频体彩');LotteryQiehuan('aa','LM',5,5);" style="cursor: pointer;" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa5">
                            高频体彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM5" runat="server" style="display: none;">
                    </div>
                </div>
            </div>
            <!---右边开奖部分--->   
            <div class="kai_rw" id="rather">
                
            </div>
        </div>
        <uc1:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
