<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Soft_Editor.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Soft_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<html>
<head id="Head1" runat="server">
    <title>资源下载编辑</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

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
            document.getElementById('<%=txtOperatingSystem.ClientID%>').value += vText; 
        } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="Soft_Manage.aspx" class="zilan">资源下载管理</a> |&nbsp; <a href="Soft_Editor.aspx"
                                        class="zilan">添加下载资源</a></td>
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
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>资源信息>><asp:Label ID="Label1"
                                                    runat="server"></asp:Label>资源信息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" border="0" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td width="144" align="right">
                                    <strong>资源类别：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:DropDownList ID="ddlSoftClass" runat="server" Width="240px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>资源名称：</strong></td>
                                <td colspan="2" align="left">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="51%" align="left">
                                                <asp:TextBox runat="server" ID="txtSoftName" MaxLength="255" Width="280px"></asp:TextBox>
                                                <font color="#FF0000">*</font></td>
                                            <td width="17%" align="right">
                                                <strong>资源类型：</strong></td>
                                            <td width="32%" align="left">
                                                <asp:TextBox runat="server" ID="txtSoftVersion3" MaxLength="100" Width="110px"></asp:TextBox>
                                                <font color="#FF0000">*</font>(例：录音)</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>资源种类：</strong></td>
                                <td colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="23%" align="left">
                                                <asp:DropDownList ID="ddlSoftType" runat="server" Width="110px">
                                                    <asp:ListItem Selected="True" Value="1">国产资源</asp:ListItem>
                                                    <asp:ListItem Value="2">国外资源</asp:ListItem>
                                                    <asp:ListItem Value="3">汉化补丁</asp:ListItem>
                                                    <asp:ListItem Value="4">程序源码</asp:ListItem>
                                                    <asp:ListItem Value="5">电影下载</asp:ListItem>
                                                    <asp:ListItem Value="6">FLASH动画</asp:ListItem>
                                                    <asp:ListItem Value="7">其他</asp:ListItem>
                                                </asp:DropDownList>
                                                <font color="#FF0000">*</font></td>
                                            <td width="11%" align="right">
                                                <strong>资源语言：</strong></td>
                                            <td width="20%" align="left">
                                                <asp:DropDownList ID="ddlSoftLanguage" runat="server" Width="110px">
                                                    <asp:ListItem Value="1">英文</asp:ListItem>
                                                    <asp:ListItem Value="2" Selected="True">简体中文</asp:ListItem>
                                                    <asp:ListItem Value="3">繁体中文</asp:ListItem>
                                                    <asp:ListItem Value="4">简繁中文</asp:ListItem>
                                                    <asp:ListItem Value="5">多国语言</asp:ListItem>
                                                    <asp:ListItem Value="6">其他语言</asp:ListItem>
                                                </asp:DropDownList>
                                                <font color="#FF0000">*</font></td>
                                            <td width="14%" align="right">
                                                <strong>授权形式：</strong></td>
                                            <td width="32%" align="left">
                                                <asp:DropDownList ID="ddlCopyrightType" runat="server" Width="110px">
                                                    <asp:ListItem Value="1" Selected="True">免费版</asp:ListItem>
                                                    <asp:ListItem Value="2">共享版</asp:ListItem>
                                                    <asp:ListItem Value="3">试用版</asp:ListItem>
                                                    <asp:ListItem Value="4">演示版</asp:ListItem>
                                                    <asp:ListItem Value="5">注册版</asp:ListItem>
                                                    <asp:ListItem Value="6">破解版</asp:ListItem>
                                                    <asp:ListItem Value="7">零售版</asp:ListItem>
                                                    <asp:ListItem Value="8">OEM版</asp:ListItem>
                                                </asp:DropDownList>
                                                <font color="#FF0000">*</font></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>信&nbsp;&nbsp;&nbsp;&nbsp;箱：</strong></td>
                                <td colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="46%" align="left">
                                                <asp:TextBox ID="txtAuthorEmail" runat="server" MaxLength="100" Width="160px">sale@pinble.com</asp:TextBox></td>
                                            <td width="22%" align="right">
                                                <strong><strong><strong>主 &nbsp; &nbsp;页</strong>：</strong></strong></td>
                                            <td width="32%" align="left">
                                                <strong>
                                                    <asp:TextBox ID="txtAuthorHomepage" runat="server" MaxLength="100" Width="160px">http://www.pinble.com/</asp:TextBox>
                                                </strong>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>资源平台：</strong></td>
                                <td colspan="2" align="left">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtOperatingSystem" runat="server" Width="380px">Win9x/NT/2000/XP/2003/Vista/Win7/</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <font color="#808080">平台选择：<a href='javascript:ToSystem("Linux/")'>Linux</a>/<a href='javascript:ToSystem("DOS/")'>DOS</a>/<a
                                                    href='javascript:ToSystem("9x/")'>9x</a>/<a href='javascript:ToSystem("95/")'>95</a>/<a
                                                        href='javascript:ToSystem("98/")'>98</a>/<a href='javascript:ToSystem("Me/")'>Me</a>/<a
                                                            href='javascript:ToSystem("NT/")'>NT</a>/<a href='javascript:ToSystem("2000/")'>2000</a>/<a
                                                                href='javascript:ToSystem("XP/")'>XP</a>/<a href='javascript:ToSystem("2003/")'>2003</a>/<a
                                                                    href='javascript:ToSystem("Vista/")'>Vista</a>/<a href='javascript:ToSystem(".Net/")'>.NET</a>/<a
                                                                        href='javascript:ToSystem("Win7/")'>Win7</a>/</font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>作者/开发商：</strong></td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtAuthor" runat="server" MaxLength="100" Width="240px">拼搏在线（北京）科技发展有限公司</asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>备注说明：</strong></td>
                                <td colspan="2" align="left">
                                    &nbsp;<asp:TextBox ID="txtRegUrl" runat="server" MaxLength="200" Width="350px">彩票资源</asp:TextBox>(例：取胆的7种方法、试机号的运用)</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="height: 92px">
                                    <strong>资源图片：</strong></td>
                                <td colspan="2" style="height: 92px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="14%" align="right">
                                                上传资源图片：</td>
                                            <td width="41%" align="left">
                                                <div style="position: relative; z-index: 99">
                                                    <span onmouseover="javascript:ShowDivPic(this,document.form1.txtLogo.value,'.jpg',1);"
                                                        onmouseout="javascript:hiddDivPic();" style="cursor: pointer;">
                                                        <asp:TextBox ID="txtLogo" runat="server" Width="260px"></asp:TextBox></span></div>
                                            </td>
                                            <td width="10%" align="left">
                                                <div style="width: 80px; overflow: hidden;">
                                                    <div style="width: 200px; padding-left: 5px;">
                                                        <div style="margin-left: -8px;">
                                                            <%--  <span id="ThumbImageState" class="Upload_Selected">已选择 <a onclick="Upload_Clear(this,'FileUploadThumb','txtLogo');">
                                                            清除</a></span>--%>
                                                            &nbsp;<font color="#FF0000">*</font><img src="/Images/Web/s.gif" alt="选择已有图片" border="0"
                                                                style="cursor: pointer;" onclick="selectFile('pic',document.form1.txtLogo,480,600);document.form1.txtLogo.focus();" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td width="32%">
                                                &nbsp;
                                            </td>
                                            <td width="3%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td align="right" style="height: 33px">
                                    <strong>录像视频：</strong></td>
                                <td colspan="2" style="height: 33px">
                                    &nbsp;<asp:TextBox ID="txtvideocount" runat="server" Height="168px" TextMode="MultiLine"
                                        Width="848px"></asp:TextBox>
                                      <br />  (<span style="color: #ff0000">*注</span>：必须按照要求格式来填写，如：标题1|视频链接1||标题2|视频链接2||)
                                    &nbsp; 推荐：(可支持<span
                                          style="color: #ff0000">flash</span>地址和<span style="color: #00cc00">HTML</span>地址)
                                        </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" valign="top">
                                    <strong><font color="#FF0000">*</font>详细说明</strong><strong>：</strong><br />
                                </td>
                                <td colspan="2">
                                    <FCKeditorV2:FCKeditor ID="weSoftIntro" runat="server" Height="350px" Width="95%">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>关键字：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtKeyword" runat="server" Width="430px">彩票资源</asp:TextBox>
                                    <br>
                                    <font color="#0000FF">用来查找相关资源，可输入多个关键字，中间用<font color="#FF0000">“|”</font>隔开。不能出现&quot;&quot;'*?,.()等字符。</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>资源属性：</strong></td>
                                <td width="468">
                                    <asp:CheckBox ID="chkOnTop" runat="server" />
                                    固顶&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkElite" runat="server" />推荐下载</td>
                                <td width="325">
                                    <strong>资源评分等级：
                                        <asp:DropDownList ID="ddlStars" runat="server">
                                            <asp:ListItem Value="5">★★★★★</asp:ListItem>
                                            <asp:ListItem Value="4">★★★★</asp:ListItem>
                                            <asp:ListItem Value="3">★★★</asp:ListItem>
                                            <asp:ListItem Value="2">★★</asp:ListItem>
                                            <asp:ListItem Value="1">★</asp:ListItem>
                                            <asp:ListItem Value="0">无</asp:ListItem>
                                        </asp:DropDownList></strong> <font color="#FF0000">*</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载次数：</strong></td>
                                <td colspan="2">
                                    本日：
                                    <asp:TextBox ID="txtDayHits" runat="server" MaxLength="8" Width="70px">0</asp:TextBox>&nbsp;&nbsp;&nbsp;本周：
                                    <asp:TextBox ID="txtWeekHits" runat="server" MaxLength="10" Width="70px">0</asp:TextBox>&nbsp;&nbsp;&nbsp;本月：<asp:TextBox
                                        ID="txtMonthHits" runat="server" Width="70px">0</asp:TextBox>&nbsp;&nbsp;&nbsp;总计：
                                    <asp:TextBox ID="txtHits" runat="server" MaxLength="10" Width="101px">0</asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载等级：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:DropDownList ID="ddlSoftLevel" runat="server" Width="151px">
                                        <asp:ListItem Value="9999">游客</asp:ListItem>
                                        <asp:ListItem Value="999">注册用户</asp:ListItem>
                                        <asp:ListItem Value="99">收费用户</asp:ListItem>
                                        <asp:ListItem Value="9">VIP用户</asp:ListItem>
                                        <asp:ListItem Value="5">管理员</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<font color="#0000FF">只有具有相应权限的人才能下载此资源。</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载点数：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtSoftPoint" runat="server" MaxLength="8" Width="143px">0</asp:TextBox>&nbsp;
                                    <font color="#0000FF">如果大于0，则用户下载此资源时将消耗相应点数。（对游客和管理员无效）</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>解压密码：</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="txtDecompressPassword" runat="server" Width="210px"></asp:TextBox></td>
                                <td>
                                    <strong>资源大小：
                                        <asp:TextBox ID="txtSoftSize" runat="server" Width="95px" Text="0"></asp:TextBox>
                                        KB</strong></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载地址1：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtDownloadUrl1" runat="server" MaxLength="200" Width="354px"></asp:TextBox>
                                    <font color="#FF0000">*
                                        <%-- <input type="button" name="Button22" value="从已上传资源中选择" onclick="javascript:window.open('pb_Admin_PhotoSelect.asp?PhotoUrlID=1000', 'selupfile', 'width=800, height=600, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=yes');">--%>
                                    </font>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载地址2：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtDownloadUrl2" runat="server" MaxLength="200" Width="351px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载地址3：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtDownloadUrl3" runat="server" MaxLength="200" Width="351px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>下载地址4：</strong></td>
                                <td colspan="2" align="left" style="height: 20px">
                                    <asp:TextBox ID="txtDownloadUrl4" runat="server" MaxLength="200" Width="351px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>更新时间：</strong></td>
                                <td colspan="2" align="left" style="height: 29px">
                                    <asp:TextBox ID="txtUpdateTime" runat="server"></asp:TextBox>&nbsp;
                                    <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px">
                                    时间格式为“年-月-日 时:分:秒”，如：<font color="#0000FF">2003-5-12 12:32:47</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>是否资源内嵌：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:CheckBox ID="ckPb_softshow" Checked="true" runat="server" />
                                    是<font color="#0000FF">（如果选中的话将在资源内嵌页面显示。）</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" bgcolor="#F2F8FB">
                                    <strong>是否首页显示：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:CheckBox ID="ckIndexshow" runat="server" />
                                    是<font color="#0000FF">（如果选中的话将在首页显示。）</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>立即发布：</strong></td>
                                <td colspan="2" align="left">
                                    <asp:CheckBox ID="ckPassed" runat="server" Checked="True" />
                                    是<font color="#0000FF">（如果选中的话将直接发布，否则审核后才能发布。）</font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    &nbsp;&nbsp;
                                </td>
                                <td colspan="2" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btClose" runat="server" Text="取消" OnClick="btClose_Click" />
                                    <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
