<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Help.aspx.cs" Inherits="Pinble_Help.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>软件帮助中心_拼搏在线彩神通软件</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <style type="text/css">
    html,body{ margin:0;height:100%;overflow:hidden; }
body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,form,fieldset,input,textarea,p,blockquote,th,td{padding:0;margin:0;}
body,fieldset,th,td,select,input,textarea {font-size:12px;font-family: Arial, sans-serif}
fieldset,img{border:0;}
table{border-collapse:collapse;border-spacing:0;}
ol,ul{list-style:none;}
address,caption,cite,code,dfn,em,strong,th,var{font-weight:normal;font-style:normal;}
caption,th{text-align:left;}
h1,h2,h3,h4,h5,h6{font-weight:normal;font-size:100%;}
a:hover{color:#0066CC;text-decoration:underline;}
a:visited{color:#00538A; }

.top1{ width:100%; height:85px; background:#FFFFFF;border-bottom:3px solid #1385c3; min-width:800px;}
.main1{ width:100%; margin-top:1px;overflow:hidden;background:#deeff6;}
.left1{ width:20%;  float:left;overflow-x:hidden;overflow-y:scroll;background:#deeff6;}

.right1{ width:79%; float:right;overflow-x:hidden;overflow-y:scroll;}

.right2{width:99%; float:right; overflow-x:hidden;overflow-y:scroll;}

.center1{
	width:8px;
	margin-bottom:-3000px;
	padding-bottom:3000px;
	border-left:1px solid #a5b4bb;border-right:1px solid #a5b4bb;

	float:left; background:#dcedfd;
}


.header{
	height:85px;
	margin:0 auto;
	position:relative;
	background-image: url(image/topbg.jpg);
	background-repeat: repeat-y;
}


.header .logo{background:url('image/logo.png') no-repeat;width:200px;height:62px;display:inline-block;margin-top:14px;margin-left:25px;}
.nav1{
	clear:both;
	height:25px;
	line-height:25px;
	position:absolute;
	top:20px;
	left:0;
	right:50px;
	padding-left:260px;font:bold 18px/22px arial;
	color:#1975c3;
}


.nav{clear:both;width:100%;height:20px;line-height:20px;position:absolute; z-index:1000;top:57px;left:0; right:50;padding-left:260px;}
#nav, #nav ul{
margin:0;
padding:0;
list-style-type:none;
list-style-position:outside;
position:relative;
line-height:1.5em; 
}

#nav a{
display:block;
color:#fff;
text-decoration:none;background:url(image/b-sprit1.png) no-repeat -200em -200em;

width:92px;height:20px;padding-top:8px;margin-right:5px;text-align:center;font:bold 14px/14px arial;font-family:"微软雅黑";color:#0477b3;background-position:left -29px;text-decoration:none;

}

#nav a:hover{
text-decoration:none;color:#fff;background-position:left top;
}

#nav li{
float:left;
position:relative;
}
/*二级导航栏样式*/
#nav ul a{background:#fff; border:1px solid #0477b3; border-top:none; color:#1F6FAF;font: 12px arial;}


#nav ul {
display:none;
width:92px; 
  border:1px solid #0477b3;
}

#nav ul a:hover{
text-decoration:none;color:#1F6FAF; background:#B8E3F8; border:1px solid #0477b3;
}




#nav ul ul{
top:auto;
} 

#nav li ul ul {
left:12em;
margin:0px 0 0 10px;
}

#nav li:hover ul ul, #nav li:hover ul ul ul, #nav li:hover ul ul ul ul{
display:none;
}
#nav li:hover ul, #nav li li:hover ul, #nav li li li:hover ul, #nav li li li li:hover ul{
display:block;
}
</style>

    <script type="text/javascript" src="script/jquery-1.3.2.js"></script>

    <script type="text/javascript" charset="gb2312" src="script/help.js?date=new date().gettime()"></script>

</head>
<body onload="checkfenbian()" onresize="checkfenbian()">
    <form id="Form1" runat="server">
        <div class="top1">
            <div class="header">
                <div class="logo">
                </div>
                <div class="nav1" id="titleName">
                </div>
                <div class="nav" style="width: 80%; min-width:800px;">
                    <ul id="nav">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href="javascript:void(0)">
                                    <%--<%#DataBinder.Eval(Container.DataItem, "SoftwareType") %>--%>
                                    <asp:Label ID="lab_name" runat="server"></asp:Label>
                                </a>
                                    <ul id="nas">
                                        <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HyperLink ID="lb_Path"  runat="server"><%# Eval("CstName") %></asp:HyperLink>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--main部分-->
        </div>
        <div class="main1">
            
            <div class="left1" id="leftTree">
                <iframe src="" name="FM_Name" id="FM_Id" width="100%" marginwidth="0" height="100%"
                    marginheight="0" frameborder="0" scrolling="no" onload="TuneHeightLeft('FM_Name','FM_Id')">
                </iframe>
            </div>
            <div class="center1"><img src="image/la1.png" id="aa" /></div>
            <div class="right1" id="RightTree">
            
                <iframe src="" frameborder="0" scrolling="yes" noresize="noresize" name="left" id="left"
                    title="left" width="100%" height="100%" onload="{TuneHeightRight('left','left')}">
                </iframe>
            </div>
        </div>
        <input id="hidden" type="hidden" value="0" />
        <%--<input id="down" type="hidden" value="<%=n_download %>" />--%>
    </form>

</body>
</html>
