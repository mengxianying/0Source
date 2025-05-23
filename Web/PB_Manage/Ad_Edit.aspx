<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ad_Edit.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ad_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加编辑广告</title>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" src="../javascript/rcolor.gbk.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script  type="text/javascript"> 
//当状态改变的时候执行的函数 
//function handle() 
//{ 
//    document.getElementById('<%=txtSiteName.ClientID%>').value = "<font color='" + document.getElementById('hdColor').value +"'></font>" 
//} 
//if(/msie/i.test(navigator.userAgent)) //ie浏览器 
//{ 
//document.getElementById('<%=txtSiteName.ClientID%>').onpropertychange = handle; 
//} 
//else 
//{//非ie浏览器，比如Firefox 
//document.getElementById('txt').addEventListener("input", handle, false); 
//document.getElementById('txt').watch('a', fn); 
//} 
    </script>

</head>
<body  onUnload="window.opener.location.reload();window.opener.focus();window.close();" >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="Ad_Manage.aspx" class="zilan">广告管理</a> | <a href="Ad_Edit.aspx" class="zilan">
                                        添加广告信息</a> | <a href="AdvPlace_Manage.aspx" class="zilan">广告位列表</a> | <a href="AdvPlace_Edit.aspx"
                                            class="zilan">添加广告位</a></td>
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
                                                当前位置：广告信息管理&gt;&gt;添加广告信息</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
 --%>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#f2f8fb">
                                <td align="right" style="width: 103px">
                                    <strong>广告类型：</strong></td>
                                <td align="left" colspan="3">
                                    <asp:RadioButtonList ID="rbtTypeID" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                        OnSelectedIndexChanged="rbtTypeID_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td align="right" style="width: 103px">
                                    <strong>是否显示：</strong></td>
                                <td align="left" colspan="3">
                                    <asp:CheckBox ID="IsSelected" runat="server" Text="设为最新广告" Checked="True" />
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>所属频道：</strong></td>
                                <%--<asp:DropDownList ID="ddlChannel" runat="server" Width="150px">
                                    </asp:DropDownList>--%>
                                <td width="142" align="left">
                                    <asp:ListBox ID="Channel" runat="server" Style="width: 140px" Height="150px" AutoPostBack="True"
                                        OnSelectedIndexChanged="Channel_SelectedIndexChanged"></asp:ListBox>
                                </td>
                                <td width="58">
                                    <strong>→位置：</strong>
                                </td>
                                <td>
                                    <asp:ListBox ID="PlaceName" runat="server" Style="width: 420px" Height="150px"></asp:ListBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>广告设置：</strong></td>
                                <td colspan="3" align="left">
                                    左：<asp:TextBox ID="txtpopleft" runat="server" Width="60px"></asp:TextBox>上：<asp:TextBox
                                        ID="txtpoptop2" runat="server" Width="60px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>网站名称：</strong></td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtSiteName" runat="server" Width="350px"></asp:TextBox>
                                    <input type="hidden" id="hdColor" />
                                    <span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>网站地址：</strong></td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtSiteUrl" runat="server" Width="350px">http://</asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>网站简介：</strong></td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtSiteIntro" runat="server" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>图片上传：</strong></td>
                                <td colspan="3" align="left">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr bgcolor="#F2F8FB">
                                            <td>
                                                <span onmouseover="javascript:ShowDivPic(this,document.form1.txtThumb.value,'.jpg',1);"
                                                    onmouseout="javascript:hiddDivPic();" style="cursor: pointer;">
                                                    <asp:TextBox ID="txtThumb" runat="server" Width="268px">
                                                    </asp:TextBox>
                                                </span>
                                            </td>
                                            <td>
                                                <div style="width: 50px; padding-left: 5px;">
                                                    <div style="margin-left: -8px;">
                                                        <%--  <asp:FileUpload ID="FileUploadThumb" runat="server" Width="0px" />--%>
                                                        <%--  <span id="ThumbImageState" class="Upload_Selected">已选择 <a onclick="Upload_Clear(this,'FileUploadThumb','txtThumb');">
                                                            清除</a></span>--%>
                                                        &nbsp;&nbsp;<img src="/Images/Web/s.gif" alt="选择已有图片" border="0" style="cursor: pointer;"
                                                            onclick="selectFile('pic',document.form1.txtThumb,480,600);document.form1.txtThumb.focus();" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="left">
                                                注：（若要上传图片，请将图片上传到‘AD’目录下 ）
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>图片大小：</strong></td>
                                <td colspan="3" align="left">
                                    宽：<asp:TextBox ID="txtImgWidth" runat="server" Width="50px">0</asp:TextBox>像素&nbsp;&nbsp;&nbsp;&nbsp;高：<asp:TextBox
                                        ID="txtImgHeight" runat="server" Width="50px">0</asp:TextBox>像素&nbsp;&nbsp;
                                    <font color="blue">弹出广告图片大小不能留空<span style="color: #ff0000">*</span></font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>是否FLASH：</strong></td>
                                <td colspan="3" align="left">
                                    <asp:RadioButtonList ID="IsFlash" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">是</asp:ListItem>
                                        <asp:ListItem Value="1">否</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>加入时间：</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="txtStartTime" runat="server" Width="120px" onfocus="calendar();">
                                    </asp:TextBox><span style="color: #ff0000">*</span></td>
                                <td align="right">
                                    <strong>结束时间：</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtEndTime" runat="server" Width="120px" onfocus="calendar();">
                                    </asp:TextBox><span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>峰值范围：</strong></td>
                                <td align="left">
                                    从：<asp:TextBox ID="txtpb_PeakC1" runat="server" Width="50px" Text="20"></asp:TextBox>到：<asp:TextBox
                                        ID="txtpb_PeakC2" runat="server" Width="50px" Text="50"></asp:TextBox></td>
                                <td align="right">
                                    <strong>同一IP限制：</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtpb_SameIP" runat="server" Width="50px" Text="10">
                                    </asp:TextBox>次</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>当前峰值：</strong></td>
                                <td align="left">
                                    <asp:Label ID="pb_PeakCount" runat="server"></asp:Label></td>
                                <td align="right">
                                    <strong>峰值递增值：</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtpb_sPeakNum" runat="server" Width="50px" Text="20">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>优先级：</strong></td>
                                <td align="left">
                                </td>
                                <td align="right">
                                    <strong>是否站外广告：</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:RadioButtonList ID="pb_ADBSType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">站外广告</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">站内广告</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>当日统计值：</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="txtpb_TDCount" runat="server" Width="50px" Text="20">
                                    </asp:TextBox></td>
                                <td align="right">
                                    <strong>总统计值：</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtpb_ALLCount" runat="server" Width="50px" Text="20">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>当日软件点击：</strong></td>
                                <td align="left">
                                    <asp:Label ID="pbs_TDCount" runat="server"></asp:Label></td>
                                <td align="right">
                                    <strong>总软件点击：</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:Label ID="pbs_ALLCount" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="保 存" OnClick="btnAdd_Click" /></td>
                            </tr>
                        </table>
                        <%--                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
            </table>
            <br />
            <table width="98%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#68B8E3">
                <tr>
                    <td height="22" colspan="4" bgcolor="#A8D6EE" class="title">
                        <strong>广告位大小说明(首页)</strong>广告位的宽度一定，高度可以根据栏目显示是否对齐可以稍微的调整一下</td>
                </tr>
                <tr>
                    <td width="25%" align="right" bgcolor="#AFDAF0">
                        首页头部图片广告区(黄金广告)</td>
                    <td width="25%" bgcolor="#AFDAF0">
                        245*36</td>
                    <td width="25%" align="right" bgcolor="#AFDAF0">
                        首页中间并排两个广告</td>
                    <td width="25%" bgcolor="#AFDAF0">
                        左：460*55 &nbsp;右：280*55</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        首页中间通栏广告</td>
                    <td bgcolor="#AFDAF0">
                        750*80
                    </td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#A8D6EE">
                        <strong>(公告)</strong></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        公告通栏广告
                    </td>
                    <td bgcolor="#AFDAF0">
                        990*80</td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        公告首页左一</td>
                    <td bgcolor="#AFDAF0">
                        230*60</td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#A8D6EE">
                        <strong>(新闻)</strong></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        新闻首页左一</td>
                    <td bgcolor="#AFDAF0">
                        210*55</td>
                    <td align="right" bgcolor="#AFDAF0">
                        新闻首页右一</td>
                    <td bgcolor="#AFDAF0">
                        240*65</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        新闻首页左二</td>
                    <td bgcolor="#AFDAF0">
                        210*65</td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#A8D6EE">
                        <strong>(学院)</strong></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        软件学院首页右一</td>
                    <td bgcolor="#AFDAF0">
                        230*70</td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
