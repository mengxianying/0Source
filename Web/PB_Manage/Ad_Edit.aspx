<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ad_Edit.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ad_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ӱ༭���</title>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" src="../javascript/rcolor.gbk.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script  type="text/javascript"> 
//��״̬�ı��ʱ��ִ�еĺ��� 
//function handle() 
//{ 
//    document.getElementById('<%=txtSiteName.ClientID%>').value = "<font color='" + document.getElementById('hdColor').value +"'></font>" 
//} 
//if(/msie/i.test(navigator.userAgent)) //ie����� 
//{ 
//document.getElementById('<%=txtSiteName.ClientID%>').onpropertychange = handle; 
//} 
//else 
//{//��ie�����������Firefox 
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
                                    <a href="Ad_Manage.aspx" class="zilan">������</a> | <a href="Ad_Edit.aspx" class="zilan">
                                        ��ӹ����Ϣ</a> | <a href="AdvPlace_Manage.aspx" class="zilan">���λ�б�</a> | <a href="AdvPlace_Edit.aspx"
                                            class="zilan">��ӹ��λ</a></td>
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
                                                ��ǰλ�ã������Ϣ����&gt;&gt;��ӹ����Ϣ</td>
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
                                    <strong>������ͣ�</strong></td>
                                <td align="left" colspan="3">
                                    <asp:RadioButtonList ID="rbtTypeID" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                        OnSelectedIndexChanged="rbtTypeID_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td align="right" style="width: 103px">
                                    <strong>�Ƿ���ʾ��</strong></td>
                                <td align="left" colspan="3">
                                    <asp:CheckBox ID="IsSelected" runat="server" Text="��Ϊ���¹��" Checked="True" />
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>����Ƶ����</strong></td>
                                <%--<asp:DropDownList ID="ddlChannel" runat="server" Width="150px">
                                    </asp:DropDownList>--%>
                                <td width="142" align="left">
                                    <asp:ListBox ID="Channel" runat="server" Style="width: 140px" Height="150px" AutoPostBack="True"
                                        OnSelectedIndexChanged="Channel_SelectedIndexChanged"></asp:ListBox>
                                </td>
                                <td width="58">
                                    <strong>��λ�ã�</strong>
                                </td>
                                <td>
                                    <asp:ListBox ID="PlaceName" runat="server" Style="width: 420px" Height="150px"></asp:ListBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>������ã�</strong></td>
                                <td colspan="3" align="left">
                                    ��<asp:TextBox ID="txtpopleft" runat="server" Width="60px"></asp:TextBox>�ϣ�<asp:TextBox
                                        ID="txtpoptop2" runat="server" Width="60px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>��վ���ƣ�</strong></td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtSiteName" runat="server" Width="350px"></asp:TextBox>
                                    <input type="hidden" id="hdColor" />
                                    <span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>��վ��ַ��</strong></td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtSiteUrl" runat="server" Width="350px">http://</asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>��վ��飺</strong></td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtSiteIntro" runat="server" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>ͼƬ�ϴ���</strong></td>
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
                                                        <%--  <span id="ThumbImageState" class="Upload_Selected">��ѡ�� <a onclick="Upload_Clear(this,'FileUploadThumb','txtThumb');">
                                                            ���</a></span>--%>
                                                        &nbsp;&nbsp;<img src="/Images/Web/s.gif" alt="ѡ������ͼƬ" border="0" style="cursor: pointer;"
                                                            onclick="selectFile('pic',document.form1.txtThumb,480,600);document.form1.txtThumb.focus();" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="left">
                                                ע������Ҫ�ϴ�ͼƬ���뽫ͼƬ�ϴ�����AD��Ŀ¼�� ��
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>ͼƬ��С��</strong></td>
                                <td colspan="3" align="left">
                                    ��<asp:TextBox ID="txtImgWidth" runat="server" Width="50px">0</asp:TextBox>����&nbsp;&nbsp;&nbsp;&nbsp;�ߣ�<asp:TextBox
                                        ID="txtImgHeight" runat="server" Width="50px">0</asp:TextBox>����&nbsp;&nbsp;
                                    <font color="blue">�������ͼƬ��С��������<span style="color: #ff0000">*</span></font></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>�Ƿ�FLASH��</strong></td>
                                <td colspan="3" align="left">
                                    <asp:RadioButtonList ID="IsFlash" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">��</asp:ListItem>
                                        <asp:ListItem Value="1">��</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>����ʱ�䣺</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="txtStartTime" runat="server" Width="120px" onfocus="calendar();">
                                    </asp:TextBox><span style="color: #ff0000">*</span></td>
                                <td align="right">
                                    <strong>����ʱ�䣺</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtEndTime" runat="server" Width="120px" onfocus="calendar();">
                                    </asp:TextBox><span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>��ֵ��Χ��</strong></td>
                                <td align="left">
                                    �ӣ�<asp:TextBox ID="txtpb_PeakC1" runat="server" Width="50px" Text="20"></asp:TextBox>����<asp:TextBox
                                        ID="txtpb_PeakC2" runat="server" Width="50px" Text="50"></asp:TextBox></td>
                                <td align="right">
                                    <strong>ͬһIP���ƣ�</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtpb_SameIP" runat="server" Width="50px" Text="10">
                                    </asp:TextBox>��</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>��ǰ��ֵ��</strong></td>
                                <td align="left">
                                    <asp:Label ID="pb_PeakCount" runat="server"></asp:Label></td>
                                <td align="right">
                                    <strong>��ֵ����ֵ��</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtpb_sPeakNum" runat="server" Width="50px" Text="20">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>���ȼ���</strong></td>
                                <td align="left">
                                </td>
                                <td align="right">
                                    <strong>�Ƿ�վ���棺</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:RadioButtonList ID="pb_ADBSType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">վ����</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">վ�ڹ��</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>����ͳ��ֵ��</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="txtpb_TDCount" runat="server" Width="50px" Text="20">
                                    </asp:TextBox></td>
                                <td align="right">
                                    <strong>��ͳ��ֵ��</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:TextBox ID="txtpb_ALLCount" runat="server" Width="50px" Text="20">
                                    </asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right" style="width: 103px">
                                    <strong>������������</strong></td>
                                <td align="left">
                                    <asp:Label ID="pbs_TDCount" runat="server"></asp:Label></td>
                                <td align="right">
                                    <strong>����������</strong></td>
                                <td align="left" style="width: 249px">
                                    <asp:Label ID="pbs_ALLCount" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="�� ��" OnClick="btnAdd_Click" /></td>
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
                        <strong>���λ��С˵��(��ҳ)</strong>���λ�Ŀ��һ�����߶ȿ��Ը�����Ŀ��ʾ�Ƿ���������΢�ĵ���һ��</td>
                </tr>
                <tr>
                    <td width="25%" align="right" bgcolor="#AFDAF0">
                        ��ҳͷ��ͼƬ�����(�ƽ���)</td>
                    <td width="25%" bgcolor="#AFDAF0">
                        245*36</td>
                    <td width="25%" align="right" bgcolor="#AFDAF0">
                        ��ҳ�м䲢���������</td>
                    <td width="25%" bgcolor="#AFDAF0">
                        ��460*55 &nbsp;�ң�280*55</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        ��ҳ�м�ͨ�����</td>
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
                        <strong>(����)</strong></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        ����ͨ�����
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
                        ������ҳ��һ</td>
                    <td bgcolor="#AFDAF0">
                        230*60</td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#A8D6EE">
                        <strong>(����)</strong></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        ������ҳ��һ</td>
                    <td bgcolor="#AFDAF0">
                        210*55</td>
                    <td align="right" bgcolor="#AFDAF0">
                        ������ҳ��һ</td>
                    <td bgcolor="#AFDAF0">
                        240*65</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        ������ҳ���</td>
                    <td bgcolor="#AFDAF0">
                        210*65</td>
                    <td align="right" bgcolor="#AFDAF0">
                        &nbsp;</td>
                    <td bgcolor="#AFDAF0">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#A8D6EE">
                        <strong>(ѧԺ)</strong></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#AFDAF0">
                        ���ѧԺ��ҳ��һ</td>
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
