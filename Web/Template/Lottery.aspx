<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Lottery.aspx.cs" Inherits="Pbzx.Web.Lottery" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>开奖信息_拼搏在线彩神通软件</title>
    <meta name="keywords" content="开奖信息,福利彩票,体育彩票,体彩,福彩" />
    <meta name="description" content="" />
    <meta name="robots" content="none" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/lottery.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        function getDate()
        {
          var d,s,t;
          d=new Date();
          s=d.getFullYear().toString(10)+"-";
          t=d.getMonth()+1;
          s+=(t>9?"":"0")+t+"-";
        t=d.getDate();
         s+=(t>9?"":"0")+t+" ";
          return s;
        }
	    function LotteryQiehuan(id,obj,intIndex,total){
	    for(var i=1;i<=total;i++)
	    {
		    var objHide=document.getElementById(obj+i);		
		    var objA = document.getElementById(id+i); 
		    if(i==intIndex)
		    {			       
		        objA.className = "kai_menubg_open";	    
			    objHide.style.display="";	
		    }
		    else
		    {
		        objA.className = "kai_menubg";
			    objHide.style.display="none";
		    }
	    }
	}

    function TuneHeight(fm_name,fm_id){          
        var frm=document.getElementById(fm_id);  
        var subWeb=document.frames?document.frames[fm_name].document:frm.contentDocument;  
        if(frm != null && subWeb != null)
        { 
        
            frm.style.height =  subWeb.documentElement.scrollHeight+"px"; 
            //如需自适应宽高，去除下行的“//”注释即可 
         frm.style.width = "800px";
        }  
    }	
    
    function getParameter(param)
    {
        var query = window.location.search;
        var iLen = param.length;
        var iStart = query.indexOf(param);
        if (iStart == -1)
        {
          return "";
        }
        else
        {
            iStart += iLen + 1;
            var iEnd = query.indexOf("&", iStart);
            if (iEnd == -1)
            {
                return query.substring(iStart);
            }
            else
            {
                return query.substring(iStart, iEnd);
            }
        }
    }

     function GetThisSrc()
     {
        var str_type = getParameter("myUrl");
        var str_lx=getParameter("lx");
        var str_class = getParameter("class");
        var str_name = getParameter("name");
        if (str_type == "")
        {
            document.getElementById("FM_Id").src = "/LotteryList.aspx"; 
        }
        else if (str_type == "FC3D")
        {
          document.getElementById("FM_Id").src = "/LotteryOneList3D.aspx?name=3D";
        }
        else
        {
            if (str_lx == "") 
            {
//                document.getElementById("FM_Id").src = "/LotteryOneList.aspx?type=" + str_type + "&class=" + str_class + "&name=" + str_name;
                document.getElementById("FM_Id").src = "/LotteryOneList.aspx?type=" + str_type;
            }
            else
            {
//            document.getElementById("FM_Id").src = "/LotteryOneList.aspx?type=" + str_type + "&lx=pls&class=" + str_class + "&name=" + str_name;
                document.getElementById("FM_Id").src = "/LotteryOneList.aspx?type=" + str_type + "&lx=pls";
            }
        }
    }
    
// window.setInterval("TuneHeight('FM_Id','FM_Id');", 50);	
    </script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GetThisSrc();">
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
                    <a onclick="LotteryQiehuan('aa','LM',1,5);" href='/LotteryList.aspx?type=<%=Input.Encrypt("全国开奖") %>'
                        style="cursor: pointer;" target="FM_Id" class="kai_menubg_zy">
                        <div class="kai_menubg_open" id="aa1">
                            全国开奖
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM1" runat="server">
                    </div>
                    <a onclick="LotteryQiehuan('aa','LM',2,5);" href='/LotteryList.aspx?type=<%=Input.Encrypt("各省福彩") %>'
                        style="cursor: pointer;" target="FM_Id" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa2">
                            各省福彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM2" runat="server" style="display: none;">
                    </div>
                    <a onclick="LotteryQiehuan('aa','LM',3,5);" href='/LotteryList.aspx?type=<%=Input.Encrypt("各省体彩") %>'
                        style="cursor: pointer;" target="FM_Id" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa3">
                            各省体彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM3" runat="server" style="display: none;">
                    </div>
                    <a onclick="LotteryQiehuan('aa','LM',4,5);" href='/LotteryList.aspx?type=<%=Input.Encrypt("高频福彩") %>'
                        style="cursor: pointer;" target="FM_Id" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa4">
                            高频福彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM4" runat="server" style="display: none;">
                    </div>
                    <a onclick="LotteryQiehuan('aa','LM',5,5);" href='/LotteryList.aspx?type=<%=Input.Encrypt("高频体彩") %>'
                        style="cursor: pointer;" target="FM_Id" class="kai_menubg_zy">
                        <div class="kai_menubg" id="aa5">
                            高频体彩
                        </div>
                    </a>
                    <div class="kai_menu_pd" id="LM5" runat="server" style="display: none;">
                    </div>
                </div>
            </div>
            <!---右边开奖部分--->
            <div class="kai_rw">
                <iframe onload="TuneHeight('FM_Id','FM_Id')" name="FM_Id" id="FM_Id" width="100%"
                    marginwidth="0" marginheight="0" frameborder="0" scrolling="no"></iframe>
            </div>
        </div>
        <uc1:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
