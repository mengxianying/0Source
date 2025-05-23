<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Product_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Product_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<html>
<head id="Head1" runat="server">
    <title>商品信息编辑</title>
<link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>


    <script language="javascript" type="text/javascript">
        function ParentChange(sender){            
//            if(sender.value == "0"){                
//                document.getElementById("txtUrl").disabled = true;
//            }
//            else{
//                document.getElementById("txtUrl").disabled = false;
//            }
        }
        function getDate()
        {
          var d,s,t;
          d=new Date();
          s=d.getFullYear().toString(10)+"-";
          t=d.getMonth()+1;
          s+=(t>9?"":"0")+t+"-";
          t=d.getDate();
          s+=(t>9?"":"0")+t+" ";
          t=d.getHours();
          s+=(t>9?"":"0")+t+":";
          t=d.getMinutes();
          s+=(t>9?"":"0")+t+":";
          t=d.getSeconds();
          s+=(t>9?"":"0")+t;
          return s;
        }
        function getnowtime()
        {
            document.getElementById('<%=txtUpdateTime.ClientID%>').value=getDate();              
        }
        function ToSystem(vText)
        {
            document.getElementById('<%=txtSystem.ClientID%>').value += vText; 
        } 
         function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere)
        {
            var   aa   ='';   
            var result =  window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height=800, width=800, top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;'                        
            if(aa == 'yes')
            {
               location.reload();    
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="CENTER">
                                <a href="Product_Manage.aspx" class="zilan">商品管理首页</a> | <a href="Product_Editor.aspx"
                                    class="zilan">添加商品信息</a> | <a href="#" onclick="OpenEdite('PBnet_Product','pb_SoftID','pb_SoftName','pb_SoftVersion','countid','')"
                                        class="zilan">商品显示排序</a> | <a href="ProductDeleted.aspx" class="zilan">商品回收站</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr>
                <td bgcolor="#F3F3F3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td width="91%" align="left">
                                            当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>商品信息</td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                        <tr bgcolor="#F2F8FB">
                            <td class="bold" width="15%">
                                商品类别：</td>
                            <td align="left" width="85%">
                                <asp:DropDownList ID="ddlSoftClass" runat="server" Width="180">
                                </asp:DropDownList></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                商品名称：</td>
                            <td align="left">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td width="44%">
                                            <asp:TextBox runat="server" ID="txtSoftName" MaxLength="255" Width="269px"></asp:TextBox><font
                                                color="#FF0000">*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSoftName"
                                                    ErrorMessage="请填写软件名称" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                        <td width="25%" class="bold">
                                            关联cst库软件名称：
                                        </td>
                                        <td width="31%" align="left">
                                            <asp:DropDownList ID="ddlCstID" runat="server" Width="128px">
                                            </asp:DropDownList>
                                            <span style="color: #ff0000">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                版本：
                            </td>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr bgcolor="#F2F8FB">
                                        <td width="20%" align="left">
                                            <asp:DropDownList ID="ddlSoftVersion" runat="server" Width="110px" OnSelectedIndexChanged="ddlSoftVersion_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font>
                                        </td>
                                        <td width="14%" class="bold">
                                            版本号：
                                        </td>
                                        <td width="24%" align="left">
                                            <asp:TextBox runat="server" ID="txtSoftVersion3" MaxLength="100" Width="100"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoftName"
                                                ErrorMessage="请填写版本号" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                        <td width="11%" class="bold">
                                            授权形式：</td>
                                        <td width="31%" align="left">
                                            <asp:DropDownList ID="ddlCopyrightType" runat="server" Width="100px">
                                                <asp:ListItem Value="1">免费版</asp:ListItem>
                                                <asp:ListItem Value="2">共享版</asp:ListItem>
                                                <asp:ListItem Value="3">试用版</asp:ListItem>
                                                <asp:ListItem Value="4">演示版</asp:ListItem>
                                                <asp:ListItem Value="5" Selected="True">注册版</asp:ListItem>
                                                <asp:ListItem Value="6">破解版</asp:ListItem>
                                                <asp:ListItem Value="7">零售版</asp:ListItem>
                                                <asp:ListItem Value="8">OEM版</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                商品种类：</td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="44%">
                                            <asp:DropDownList ID="ddlSoftType" runat="server" Width="110px">
                                                <asp:ListItem Selected="True" Value="1">国产软件</asp:ListItem>
                                                <asp:ListItem Value="2">国外软件</asp:ListItem>
                                                <asp:ListItem Value="3">汉化补丁</asp:ListItem>
                                                <asp:ListItem Value="4">程序源码</asp:ListItem>
                                                <asp:ListItem Value="5">电影下载</asp:ListItem>
                                                <asp:ListItem Value="6">FLASH动画</asp:ListItem>
                                                <asp:ListItem Value="7">其他</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font></td>
                                        <td width="25%" class="bold">
                                            语言：</td>
                                        <td width="31%" align="left">
                                            <asp:DropDownList ID="ddlSoftLanguage" runat="server" Width="100">
                                                <asp:ListItem Value="1">英文</asp:ListItem>
                                                <asp:ListItem Value="2" Selected="True">简体中文</asp:ListItem>
                                                <asp:ListItem Value="3">繁体中文</asp:ListItem>
                                                <asp:ListItem Value="4">简繁中文</asp:ListItem>
                                                <asp:ListItem Value="5">多国语言</asp:ListItem>
                                                <asp:ListItem Value="6">其他语言</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                运行环境：</td>
                            <td>
                                <asp:TextBox ID="txtSystem" runat="server" Width="380px">Win9x/NT/2000/XP/2003/Vista/Win7/</asp:TextBox><br />
                                <font color="#808080">平台选择：<a href='javascript:ToSystem("Linux/")'>Linux</a>/<a href='javascript:ToSystem("DOS/")'>DOS</a>/<a
                                    href='javascript:ToSystem("9x/")'>9x</a>/<a href='javascript:ToSystem("95/")'>95</a>/<a
                                        href='javascript:ToSystem("98/")'>98</a>/<a href='javascript:ToSystem("Me/")'>Me</a>/<a
                                            href='javascript:ToSystem("NT/")'>NT</a>/<a href='javascript:ToSystem("2000/")'>2000</a>/<a
                                                href='javascript:ToSystem("XP/")'>XP</a>/<a href='javascript:ToSystem("2003/")'>2003</a>/<a
                                                    href='javascript:ToSystem("Vista/")'>Vista</a>/<a href='javascript:ToSystem(".Net/")'>.NET</a>/<a
                                                        href='javascript:ToSystem("Win7/")'>Win7</a>/</font>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                备注说明：</td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3" align="left">
                                            <asp:TextBox ID="txtAuthor" runat="server" MaxLength="100" Width="520px"></asp:TextBox>
                                            </td>
                                        <%-- <td width="15%" class="bold">
                                            信箱：</td>
                                        <td width="28%" align="left">
                                            <asp:TextBox ID="txtAuthorEmail" runat="server" MaxLength="100" Width="130px"></asp:TextBox></td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                网络注册价格：</td>
                            <td>
                                <asp:TextBox ID="txtUseTime" runat="server" Width="350px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                单机注册价格：</td>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr bgcolor="#F2F8FB">
                                        <td width="6%" align="right" bgcolor="#F2F8FB" style="height: 26px">
                                            一年：</td>
                                        <td align="left" style="height: 26px; width: 25%;">
                                            <asp:TextBox ID="txtDemoUrl" Width="100px" runat="server"></asp:TextBox><br />
                                            专业版格式：128元/年<br />
                                            免费版格式：免费<br />
                                            胆杀版格式：500元/套<br />
                                            出票系统：1288元/单线</td>
                                        <td width="6%" align="right" bgcolor="#F2F8FB" style="height: 26px">
                                            终身：</td>
                                        <td width="67%" align="left" style="height: 26px">
                                            <asp:TextBox ID="txtRegUrl" Width="100px" runat="server"></asp:TextBox>
                                            <br />
                                            专业版格式：800元/套<br />
                                            免费版格式：免费<br />
                                            胆杀版格式：500元/套<br />
                                            出票系统：1888元/双线</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                演示地址：</td>
                            <td align="left">
                                <asp:TextBox ID="txtSoftdemo" runat="server" MaxLength="255" Width="350px"></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                说明书地址：</td>
                            <td align="left">
                                <asp:TextBox ID="txtilluminate" runat="server" MaxLength="255" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                图片：</td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="14%" align="right">
                                            上传软件图片：</td>
                                        <td width="41%" align="left">
                                            <div style="position: relative; z-index: 99">
                                                <span onmouseover="javascript:ShowDivPic(this,document.form1.txtLogo.value,'.jpg',1);"
                                                    onmouseout="javascript:hiddDivPic();" style="cursor: pointer;">
                                                    <asp:TextBox ID="txtLogo" runat="server" Width="400px"></asp:TextBox></span></div>
                                        </td>
                                        <td width="10%" align="left">
                                            <div style="width: 80px; overflow: hidden;">
                                                <div style="width: 50px; padding-left: 5px;">
                                                    <div style="margin-left: -8px;">
                                                        <%--  <span id="ThumbImageState" class="Upload_Selected">已选择 <a onclick="Upload_Clear(this,'FileUploadThumb','txtLogo');">
                                                            清除</a></span>--%>
                                                        &nbsp;&nbsp;<img src="/Images/Web/s.gif" alt="选择已有图片" border="0" style="cursor: pointer;"
                                                            onclick="selectFile('pic',document.form1.txtLogo,480,600);document.form1.txtLogo.focus();" />
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td width="15%">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td class="bold">
                                录像视频：</td>
                            <td>
                                <asp:TextBox ID="txtvideocount" runat="server" Height="168px" TextMode="MultiLine"
                                    Width="848px"></asp:TextBox>
                                     <br />  (<span style="color: #ff0000">*注</span>：必须按照要求格式来填写，如：标题1|视频链接1||标题2|视频链接2||)
                                    &nbsp; 推荐：(可支持<span
                                          style="color: #ff0000">flash</span>地址和<span style="color: #00cc00">HTML</span>地址)
                                    </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold" valign="top">
                                <font color="#FF0000">*</font>简要说明：<br />
                                支持各种UBB代码<br />
                                （注：简要说明里面不要放图片）</td>
                            <td>
                                <FCKeditorV2:FCKeditor ID="weSoftIntro" runat="server" Width="90%" Height="350">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold" valign="top">
                                <font color="#FF0000">*</font>详细说明：</td>
                            <td>
                                <FCKeditorV2:FCKeditor ID="weSoftContent" runat="server" Height="400px" Width="90%">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td valign="top" class="bold">
                                关键字：</td>
                            <td align="left">
                                <asp:TextBox ID="txtKeyword" runat="server" Width="430px"></asp:TextBox>
                                <br />
                                <font color="#0000FF">用来查找相关软件，可输入多个关键字，中间用<font color="#FF0000">“|”</font>隔开。不能出现&quot;&quot;'*?,.()等字符。</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                软件属性：</td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="14%" align="left">
                                            <asp:CheckBox ID="chkOnTop" runat="server" />
                                            固顶</td>
                                        <td align="left" width="14%">
                                            <asp:CheckBox ID="chkElite" runat="server" />推荐</td>
                                        <td width="19%" class="bold">
                                            软件评分等级：</td>
                                        <td width="40%" align="left">
                                            <strong>
                                                <asp:DropDownList ID="ddlStars" runat="server">
                                                    <asp:ListItem Value="5">★★★★★</asp:ListItem>
                                                    <asp:ListItem Value="4">★★★★</asp:ListItem>
                                                    <asp:ListItem Value="3">★★★</asp:ListItem>
                                                    <asp:ListItem Value="2">★★</asp:ListItem>
                                                    <asp:ListItem Value="1">★</asp:ListItem>
                                                    <asp:ListItem Value="0">无</asp:ListItem>
                                                </asp:DropDownList>
                                            </strong><font color="#FF0000">*</font></td>
                                        <td width="18%">
                                            &nbsp;
                                        </td>
                                        <td width="9%" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载次数：</td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="18%" align="left">
                                            本日：
                                            <asp:TextBox ID="txtDayHits" runat="server" MaxLength="8" Width="70px">0</asp:TextBox></td>
                                        <td width="18%" align="left">
                                            本周：
                                            <asp:TextBox ID="txtWeekHits" runat="server" MaxLength="10" Width="70px">0</asp:TextBox></td>
                                        <td width="18%" align="left">
                                            本月：
                                            <asp:TextBox ID="txtMonthHits" runat="server" Width="70px">0</asp:TextBox></td>
                                        <td width="29%" align="left">
                                            总计：
                                            <asp:TextBox ID="txtHits" runat="server" MaxLength="10" Width="101px">0</asp:TextBox></td>
                                        <td width="17%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载等级：</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSoftLevel" runat="server" Width="100px">
                                    <asp:ListItem Value="9999">游客</asp:ListItem>
                                    <asp:ListItem Value="999">注册用户</asp:ListItem>
                                    <asp:ListItem Value="99">收费用户</asp:ListItem>
                                    <asp:ListItem Value="9">VIP用户</asp:ListItem>
                                    <asp:ListItem Value="5">管理员</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;<font color="#0000FF">只有具有相应权限的人才能下载此软件。</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载点数：</td>
                            <td align="left">
                                <asp:TextBox ID="txtSoftPoint" runat="server" MaxLength="8" Width="100px">0</asp:TextBox>&nbsp;
                                <font color="#0000FF">如果大于0，则用户下载此软件时将消耗相应点数。（对游客和管理员无效）</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                解压密码：</td>
                            <td align="left">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="21%" align="left">
                                            <asp:TextBox ID="txtDecompressPassword" runat="server" Width="150px"></asp:TextBox></td>
                                        <td width="21%" class="bold">
                                            软件大小：</td>
                                        <td width="40%" align="left">
                                            <strong>
                                                <asp:TextBox ID="txtSoftSize" runat="server" Width="95px"></asp:TextBox>
                                                <strong>K</strong></strong></td>
                                        <td width="15%">
                                            &nbsp;
                                        </td>
                                        <td width="3%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载地址1：</td>
                            <td align="left">
                                <asp:TextBox ID="txtDownloadUrl1" runat="server" MaxLength="200" Width="354px"></asp:TextBox>
                                <font color="#FF0000">*
                                    <%-- <input type="button" name="Button22" value="从已上传软件中选择" onclick="javascript:window.open('pb_Admin_PhotoSelect.asp?PhotoUrlID=1000', 'selupfile', 'width=800, height=600, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=yes');">--%>
                                </font>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载地址2：</td>
                            <td align="left">
                                <asp:TextBox ID="txtDownloadUrl2" runat="server" MaxLength="200" Width="351px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载地址3：</td>
                            <td align="left">
                                <asp:TextBox ID="txtDownloadUrl3" runat="server" MaxLength="200" Width="351px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                下载地址4：</td>
                            <td align="left">
                                <asp:TextBox ID="txtDownloadUrl4" runat="server" MaxLength="200" Width="351px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                更新时间：</td>
                            <td align="left">
                                <asp:TextBox ID="txtUpdateTime" runat="server"></asp:TextBox>&nbsp;
                                <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" />
                                时间格式为“年-月-日 时:分:秒”，如：<font color="#0000FF">2003-5-12 12:32:47</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td align="right">
                                <strong>是否内嵌：</strong></td>
                            <td colspan="3" align="left">
                                <asp:CheckBox ID="ckPb_softshow" Checked="true" runat="server" />
                                是<font color="#0000FF">（如果选中的话将在资源内嵌页面显示。）</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                暂停销售：</td>
                            <td align="left">
                                <asp:CheckBox ID="ckfreeshow" runat="server" />
                                是<font color="#0000FF">（如果选中的话将暂停销售。）</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                首页显示：</td>
                            <td align="left">
                                <asp:CheckBox ID="ckIndexshow" runat="server" Checked="True" />
                                是<font color="#0000FF">（如果选中的话将在首页显示。）</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                立即发布：</td>
                            <td align="left">
                                <asp:CheckBox ID="ckPassed" runat="server" Checked="True" />
                                是<font color="#0000FF">（如果选中的话将直接发布，否则审核后才能发布。）</font></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td align="right" class="forumRow">
                                &nbsp;
                            </td>
                            <td colspan="3" class="forumRow" align="left">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                &nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btClose" runat="server" Text="取消" OnClick="btClose_Click" />
                                <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
