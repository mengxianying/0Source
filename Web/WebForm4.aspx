<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Pbzx.Web.WebForm4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <%--    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="javascript/effects-20090707.js"></script>
    <link href="css/common.css" type="text/css" rel="stylesheet" />
    <link href="css/home2010.css" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvMeng').bind("mouseleave", function () {
                ////		        $this.animate({ 
                ////			        width: opts.orgw,
                ////			        height: opts.orgh,
                ////	                borderWidth: "1"
                ////	              }, 600 );
                ////        	      
                ////	            $open.fadeIn();
                ////        		
                ////		        $wrap.animate({ 
                ////	                width: opts.wrapw,
                ////			        height: opts.wraph
                ////		              }, 600 );
                ////        		
                ////			        $img.animate({   
                ////				        marginTop: "-50px",
                ////				        marginLeft: "-50px"
                ////			        }, 600 );

                ////		        $(".info_area",$this).fadeOut();
                ////		        return false;
                ////	        });
                //           $("#info").fadeOut();  
                ////                $(this).stop();
                //            //$("#dvTest").hide()
                //          //$("#dvTest").dequeue();

                //            
                //$("#dvTest").slideUp("slow");
            });

            $('#dvMeng').bind("mouseenter", function () {


                // $("#dvTest").fadeIn(); 



                //$("#dvTest").show();
            });

        });
    
    


    
    
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <form id="form1" runat="server">
    <div id="MyCart">
    </div>
    <div class="Tip360" id="My_Cart_Tip">
    </div>
    <div class="Tip360 w260" id="Collect_Tip">
    </div>
    <div class="Tip360" id="Fqfk_Tip">
    </div>
    ///////////////////////////////////////////////////////////////////////////////////////////////<br />
    <span onmouseover="javascript:ShowDiv( $('#txtThumb'),$('#dvTest').html());" onmouseout="javascript:hiddDivPic();"
        style="cursor: pointer;">
        <asp:TextBox ID="txtThumb" runat="server" Width="268px"></asp:TextBox>
    </span>
    <p />
    <p />
    <p />
    <p />
    ////////////////////////////////////////////////////////////////////////////////////////////////<p />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return check()"
            OnClick="Button1_Click" /></div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    <br />
    ////////////////////////测试弹出层效果///////////////////////////////////////////////////////////////////////////////////<br />
    <br />
    &nbsp;
    <div id="dvMeng" style="background-color: Olive;">
        <asp:Label ID="Label1" runat="server" Text="弹出..." Width="180px"></asp:Label><br />
        <div id="dvTest" style="display: none; width: 500px; background-color: Gray; z-index: 20000;
            position: absolute;">
            蒙蒙<br />
            kkkkk<br />
            卡迪斯风口浪尖埃斯克罗地分艰苦拉萨地方 奥兰多开始放假拉喀什等级分类口径埃里克森的风景，<br />
            拉克丝的解放路咖啡机德鲁克撒娇的法律卡上决定离开房间啊老师打分<br />
            啊是浪费空间拉考试等级分类口径爱上的路口附近绿卡上的纠纷<br />
            卡迪斯风口浪尖埃斯克罗地分艰苦拉萨地方 奥兰多开始放假拉喀什等级分类口径埃里克森的风景，<br />
            拉克丝的解放路咖啡机德鲁克撒娇的法律卡上决定离开房间啊老师打分<br />
            啊是浪费空间拉考试等级分类口径爱上的路口附近绿卡上的纠纷
            <br />
        </div>
    </div>
    ///////////////////////////////////////////////////////
    <div>
        aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasdfkajsldkfjlk
    </div>
    <div id="info" style="display: none; width: 250px; z-index: 2; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);
        font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
        <div id="btnCloseParent" style="float: right; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);">
            <asp:LinkButton ID="btnClose" runat="server" OnClientClick="$('#info').fadeOut();  "
                Text="X" ToolTip="Close" Style="background-color: #666666; color: #FFFFFF; text-align: center;
                font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
        </div>
        <div>
            <p>
                Once you get the general idea of the animation's markup, you'll want to play a bit.
                All of the animations are created from simple, reusable building blocks that you
                can compose together. Before long you'll be creating dazzling visuals. By grouping
                steps together and specifying them to be run either in sequence or in parallel,
                you'll achieve almost anything you can imagine, without writing a single line of
                code!
            </p>
            <br />
            <p>
                The XML defining the animations is very easy to learn and write, such as this example's
                <asp:LinkButton ID="lnkShow" OnClientClick="return false;" runat="server">show</asp:LinkButton>
                and
                <asp:LinkButton OnClientClick="return false;" ID="lnkClose" runat="server">close</asp:LinkButton>
                markup.
            </p>
        </div>
    </div>
    
    </form>--%>
    <%--    <script>
       if(document.getElementById("QYKF_COPYRIGHT_70718ca91d55dcb82b8020add3fc54fa"))
       document.getElementById("QYKF_COPYRIGHT_70718ca91d55dcb82b8020add3fc54fa").style.display = "none";
       _QYTool_Options = 
       {"Version":"v1.0.1.1547","SKIN":"default","ListSkin":"default","IPAddress":"123.120.21.151",
       "KFURL":"http:\/\/13279.kf.qycn.com\/vclient\/","ShowOtherIM":1,
       "qyWebSiteClerkServerURL":"http:\/\/kfrpc4.qycn.com\/cgi-bin\/qywebsiteclerkserver",
       "qyOnlineClerkCGI":"http:\/\/kfrpc4.qycn.com\/cgi-bin\/qyonlineclerkcgi",
       "ChatURL":"http:\/\/13279.kf.qycn.com\/vclient\/chat\/",
       "ImageURL":"http:\/\/13279.kf.qycn.com\/vclient\/themes","YQKWaitTime":1,"YQKManualLimitTimes":10,
       "YQKAutoLimitTimes":1,"YQKManual":1,"YQKAuto":0,"YQKAutoInvite":0,"YQKInterval":5,"YQKNoClerkShow":1,"Title":"",
       "Location":"","Referrer":"","OffsetX":0,"OffsetY":0,"PageWidth":0,"ThemeType":2,
       "ThemeURL":"http:\/\/13279.kf.qycn.com\/","SWFType":3,"IconType":1,
       "SWFTitle":"\u62fc\u640f\u5728\u7ebf\u5ba2\u670d","SWFFile":"clientlist.swf",
       "WebId":13279,"SWFPOS":"rt","AREA1":"\u5317\u4eac\u5e02","AREA2":"\u5317\u4eac",
       "ClientUrl":"http:\/\/www.pinble.com",
       "template":"<div style=\"-moz-user-select:none;height:137px;width:378px;background:url(http:\/\/13279.kf.qycn.com\/vclient\/themes\/default\/bg.gif) no-repeat;margin:0;padding:0\" onselectstart=\"javascript:return false;\" id=\"QYKFYQKC\">\n    <h3 id=\"QYKFYQKT\" style=\"display:block; height:30px; padding:0 ;padding-left:10px;margin:0; line-height:31px; overflow:hidden; text-align:left; font-weight:bold; color:#FFF; font-size:12px;background:none;\"><\/h3> \n    <p style=\"display:block; height:50px;padding:0; margin:13px 30px 5px 30px; color:#fff; line-height:20px; text-align:left; font-size:13px;background:none\">\u60a8\u597d\uff01\u6b22\u8fce\u60a8\u8bbf\u95ee\u62fc\u640f\u5728\u7ebf\u5f69\u7968\u7f51\uff0c\u8bf7\u95ee\u6709\u4ec0\u4e48\u53ef\u4ee5\u5e2e\u5230\u60a8\u5417\uff1f<\/p> \n    <div style=\"margin:0;padding:0;text-align:center; margin-right:15px;background:none\">\n        <span onmousedown=\"javascript:_QYTool.client.refuse();return false;\" style=\"display:inline-block; width:65px; height:27px; margin:0;padding:0;margin-left:15px; background:url(http:\/\/13279.kf.qycn.com\/vclient\/themes\/default\/bg.gif) no-repeat left -150px; cursor:pointer;\"><\/span>\n        <span onclick=\"javascript:_QYTool.client.agree();return false;\" style=\"display:inline-block; width:65px; height:27px; margin:0;padding:0;margin-left:15px; background:url(http:\/\/13279.kf.qycn.com\/vclient\/themes\/default\/bg.gif) no-repeat -72px -150px; cursor:pointer;\"><\/span>\n    <\/div>\n<\/div>"};document.writeln("<script src=\"http://13279.kf.qycn.com/vclient/QYTool_min.js?v1.0.1.1547\" language=\"javascript\" type=\"text/javascript\"></script>
    "); </script>--%>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="Button" />
    </form>
</body>
</html>
