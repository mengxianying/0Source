<%@ Page Language="C#" AutoEventWireup="true" Codebehind="School_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.School_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加编辑软件学院信息</title>
    <!-- stylecss/admin.css -->
    <link href="/sysImages/blue/css/css.css" rel="stylesheet" type="text/css" />

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
            document.getElementById('<%=txtCreateTime.ClientID%>').value=getDate();              
        }
    </script>

    <link href="StyleCss/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="News_Manage.aspx" class="zilan">管理软件学院信息</a> |&nbsp; <a href="News_Editor.aspx"
                                        class="zilan">添加软件学院信息</a>
                                </td>
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
                                                当前位置：软件学院信息管理&gt;&gt;<asp:Label ID="lblAction" runat="server"></asp:Label>软件学院信息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpSchool" runat="server">
                            <ContentTemplate>
                                <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                    <tr bgcolor="#f2f8fb">
                                        <td class="bold" width="15%">
                                            所属频道:</td>
                                        <td width="85%">
                                            <asp:DropDownList ID="ddlChannel" runat="server" Width="168px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlChannel_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            所属分类:</td>
                                        <td>
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="168px">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB" width="15%">
                                <td class="bold">
                                    标题:</td>
                                <td width="85%">
                                    <asp:TextBox ID="txtTitle" runat="server" Width="475px" MaxLength="200">
                                    </asp:TextBox><span style="color: #ff0000">*</span>(100字以内)<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="标题不能为空"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    短标题:</td>
                                <td>
                                    <asp:TextBox ID="txtShortTitle" runat="server" Width="200px" MaxLength="30"></asp:TextBox><span
                                        style="color: #ff0000">*</span>(15字以内)</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    网页关键字:</td>
                                <td>
                                    <asp:TextBox ID="txtKey" runat="server" MaxLength="200" Width="475px" TextMode="MultiLine">
                                    </asp:TextBox>(200字以内)</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    网页内容描述:</td>
                                <td>
                                    <asp:TextBox ID="txtMetadesc" runat="server" MaxLength="200" Width="475px" TextMode="MultiLine">
                                    </asp:TextBox>(200字以内)</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    作者:</td>
                                <td>
                                    <asp:TextBox ID="txtAuthor" runat="server">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    文章来源:</td>
                                <td>
                                    <asp:TextBox ID="txtSource" runat="server" Width="341px">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    来源地址:</td>
                                <td>
                                    <asp:TextBox ID="txtSourceUrl" runat="server" Width="341px">
                                    </asp:TextBox></td>
                            </tr>
                            <%-- <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    图片地址:
                                </td>
                               <td style="height: 58px">
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
                                                <div style="width: 200px; padding-left: 5px;">
                                                    <div style="margin-left: -8px;">
                                                        &nbsp;&nbsp;<img src="/Images/Web/s.gif" alt="选择已有图片" border="0" style="cursor: pointer;"
                                                            onclick="selectFile('pic',document.form1.txtThumb,480,600);document.form1.txtThumb.focus();" />
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    (备注：如果上传图片，请将图片上传到UploadFiles文件夹下的School文件夹中)</td>
                            </tr>--%>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    微博图片地址:</td>
                                <td>
                                    <asp:TextBox ID="txtVarPicUrl" runat="server" Width="341px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    内容:</td>
                                <td class="Manage_Header">
                                    &nbsp;<FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="500px" Width="98%">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server" bgcolor="#F1F1F1">
                                <td class="bold">
                                    点击次数:</td>
                                <td>
                                    <asp:TextBox ID="txtHits" runat="server" Width="60px" Text="0">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    添加(修改)时间:</td>
                                <td>
                                    <asp:TextBox ID="txtCreateTime" runat="server">
                                    </asp:TextBox>
                                    <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" />
                                    时间格式为“年-月-日 时:分:秒”，如：<font color="#0000FF">2003-5-12 12:32:47</font> <span style="color: #ff0000">
                                        *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCreateTime"
                                            ErrorMessage="添加时间不能为空"></asp:RequiredFieldValidator></span></td>
                            </tr>
                            <%--<tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    归档时间:</td>
                                <td>
                                    <asp:TextBox ID="txtEffectDate" runat="server"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCreateTime"
                                        ErrorMessage="归档时间不能为空"></asp:RequiredFieldValidator></span></td>
                            </tr>--%>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    其它属性:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsRecommand" runat="server" Text="发布" Checked="True" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkIsTop" runat="server" Text="置顶" />
                                    &nbsp;&nbsp;
                                    <%--  <asp:CheckBox ID="chkIsHot" runat="server" Text="热门新闻" />--%>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    是否首页显示:</td>
                                <td>
                                    <asp:CheckBox ID="chbShowIndex" runat="server" Checked="True" Text="是" />
                                    <font color="#0000ff">（如果选中的话将在首页显示。）</font>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />
                                    <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
                                    &nbsp;
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
