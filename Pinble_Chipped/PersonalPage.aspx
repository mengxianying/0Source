<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PersonalPage.aspx.cs" Inherits="Pinble_Chipped.PersonalPage" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register src="Contorls/login.ascx" tagname="login" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />--%>
    <title>�ޱ����ĵ�</title>
    <link href="Css/Pgrenr.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="loginCss/css.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="Css/footer.css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" charset="gb2312" src="js/login.js?date=new date().gettime()"></script>

    <script type="text/javascript" src="js/SearchAjax.js"></script>

    <script type="text/javascript">
        /*iframe�������Ӧ*/
        function TuneHeight(fm_name, fm_id) {
            var frm = document.getElementById(fm_id);
            var subWeb = document.frames ? document.frames[fm_name].document : frm.contentDocument;
            if (frm != null && subWeb != null) {
                frm.style.height = subWeb.documentElement.scrollHeight+130 + "px";
                //��������Ӧ���,ȥ�����еġ�//��ע�ͼ��� 
                frm.style.width = subWeb.documentElement.scrollWidth + "px";
            }
        }
        function switching(obj)
        {
             $("#ul1 > li").each(function(){
                if($(this).attr("id")==obj)
                {
                    $("#"+$(this).attr("id")).addClass("cur");
                }
                else
                {
                    $("#"+$(this).attr("id")).removeClass("cur");
                }
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!--header����-->
        <div class="header">
            <div class="login_info">
                        <uc2:login ID="login1" runat="server" />
            </div>
            <ul class="link1" id="ul1">
                <li class="cur" id="l1"><a href='Personal.aspx?name=<%=Request["name"].ToString() %>'
                    target="mainPage" onclick="switching('l1')">�ҵ���ҳ</a></li>
                <li id="l2"><a href="Attention.aspx?name=<%=pageName %>" target="mainPage" onclick="switching('l2')">
                    ����ע����</a></li>
                <%--<li id="l3"><a href="" target="mainPage" onclick="switching('l3')">�н����а�</a></li>--%>
                <li id="l4"><a href="Tark.aspx?name=<%=pageName %>" target="mainPage" onclick="switching('l4')">
                    ���Ƹ���</a></li>
            </ul>
            
        </div>
        <!--main����-->
        <div class="user_main">
            <div style="float: left; width:790px;">
                <iframe id="mainPage" name="mainPage" width="100%" runat="server" marginheight="0" frameborder="0" scrolling="no" ></iframe>
            </div>
            <!--�Ҳಿ�ֿ�ʼ-->
            <div class="userm_right">
                <!--�ղ� �༭-->
                <!--�ղ� �༭-->
                <div class="foldbox">
                    <div class="fold_top">
                        <em></em>
                    </div>
                    <div class="fold_center tip_po">
                        <div class="box1 storeup">
                            <div class="title">
                                <b>���Ƹ���</b> <a href="#" class="edit_txt">����</a></div>
                            <table width="100%" border="0" class="tabled">
                                <tr>
                                    <td>
                                        <span class="red">˫ɫ��</span>
                                    </td>
                                    <td width="15%">
                                        <a href="Tracking.aspx?name=<%=pageName %>">����</a>
                                    </td>
                                </tr>
                                <asp:Repeater ID="rep_Made" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <span class="red">��������͸</span>
                                            </td>
                                            <td width="15%">
                                                <a href="#">����</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <div class="clearit">
                            </div>
                        </div>
                    </div>
                    <div class="fold_bottom">
                        <em></em>
                    </div>
                </div>
                <div class="foldbox">
                    <div class="fold_top">
                        <em></em>
                    </div>
                    <div class="fold_center tip_po">
                        <div class="box1 storeup">
                            <div class="title">
                                <b>����ע����</b> <a href="#" class="edit_txt">����</a></div>
                            <table width="100%" border="0" class="tabled">
                                <tr>
                                    <td style="border-bottom: 1px dashed #ccc">
                                        <table width="100%" border="0">
                                            <asp:Repeater ID="rep_Attention" runat="server" 
                                                onitemdatabound="rep_Attention_ItemDataBound">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td rowspan="2" width="30%">
                                                            <img src="images/s_level3.jpg" class="imgs" /></td>
                                                        <td>
                                                            <%# Eval("AName")%>
                                                            &nbsp;&nbsp;<a href="#">��ע��</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lab_prix" runat="server"></asp:Label>����󽱵���</td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="clearit">
                            </div>
                        </div>
                    </div>
                    <div class="fold_bottom">
                        <em></em>
                    </div>
                </div>
            </div>
            <!--�Ҳಿ�ֽ���-->
        </div>
        <div>
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
