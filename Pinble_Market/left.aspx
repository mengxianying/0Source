<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Pinble_Market.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>������</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache,  must-revalidate" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="Content-Type" content="text/html; charSet=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            padding-top: 10px;
            font-size: 12px;
            background-color: #d0e0f0;
            background-image: url(../Images/t_img_01.gif);
            background-repeat: repeat-x;
        }
        html
        {
            scrollbar-face-color: #97CBFF;
            scrollbar-highlight-color: #D2E9FF;
            scrollbar-shadow-color: #D2E9FF;
            scrollbar-3dlight-color: #D2E9FF;
            scrollbar-arrow-color: #D2E9FF;
            scrollbar-track-color: #D2E9FF;
            scrollbar-darkshadow-color: #C4E1FF;
        }
        a:link, a:visited
        {
            color: #0f3f94;
        }
        a:hover, a:active
        {
            color: #ff3300;
            text-decoration: underline;
        }
        td
        {
            font-size: 12px;
        }
        ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        .left
        {
            float: left;
            margin-left: 5px;
            width: 31px;
            _margin-left: 2px;
            margin-right: -5px;
            position: relative;
            z-index: 100000;
        }
        .leftbar1
        {
            width: 31px;
            height: 11px;
            background: url(../../Images/t_leftbar1.gif);
            font-size: 1px;
        }
        .leftbar2
        {
            width: 31px;
            background: url(../../Images/t_leftbar2.gif);
        }
        .leftbar3
        {
            width: 31px;
            height: 11px;
            background: url(../../Images/t_leftbar3.gif);
            font-size: 1px;
        }
        .leftbar2 a:link, .leftbar2 a:visited
        {
            font-size: 14px;
            text-decoration: none;
        }
        .leftbar2 li
        {
            width: 31px;
            height: 104px;
        }
        .leftbar2 li span
        {
            position: relative;
            top: 17px;
            left: 9px;
        }
        .leftbar2 .tab1
        {
            background: url(../../Images/t_tab1.gif);
        }
        .leftbar2 .tab1 a:link, .leftbar2 .tab1 a:visited
        {
            color: #fff;
            font-weight: bold;
        }
        .leftbar2 .tab1 a:hover, .leftbar2 .tab1 a:active
        {
            color: #FFFF00;
        }
        .leftbar2 .tab2
        {
            background: url(../../Images/t_tab2.gif) no-repeat 0 95px;
        }
        .right
        {
            float: left;
            width: 148px;
        }
        .right1
        {
            width: 148px;
            height: 5px;
            background: url(../../Images/t_right1.gif);
            font-size: 1px;
        }
        .right2
        {
            width: 142px;
            padding-left: 6px;
            background: #fafbfd url(../../Images/t_right2.gif);
            padding-top: 2px;
            min-height: 660px;
            _height: 660px;
        }
        .right3
        {
            width: 148px;
            height: 5px;
            background: url(../../Images/t_right3.gif);
            font-size: 1px;
            margin-bottom: 10px;
        }
        .tree li
        {
            background: url(../../Images/t_img_05d.gif);
            width: 137px;
            line-height: 24px;
            color: #0f3f94;
            cursor: pointer;
        }
        .tree .tab_o
        {
            background: #73b7e4;
            width: 137px;
            line-height: 24px;
        }
        .tree a:link, .tree a:visited
        {
            color: #0f3f94;
            text-decoration: none;
        }
        .tree a:hover, .tree a:active
        {
            color: #FF0000;
        }
        .tree1
        {
            background: url(../../Images/t_tree1.gif) no-repeat 5px 5px;
            text-indent: 25px;
            font-size: 14px;
        }
        .tree1 img
        {
            margin: 5px 0 10px 0;
        }
        .tree1b
        {
            background: url(../../Images/t_tree2.gif) no-repeat 5px 5px;
            text-indent: 25px;
            font-weight: bold;
            font-size: 14px;
        }
        .tree1b img
        {
            margin: 5px 0 10px 0;
        }
        .tree2
        {
            background: url(../../Images/t_tree1.gif) no-repeat 17px 5px;
            text-indent: 37px;
        }
        .tree2b
        {
            background: url(../../Images/t_tree2.gif) no-repeat 17px 5px;
            text-indent: 37px;
            font-weight: bold;
        }
        .tree3
        {
            text-indent: 37px;
            background: url(../../Images/t_tree5.gif) no-repeat 17px 5px;
        }
        .tree4
        {
            text-indent: 37px;
            background: url(../../Images/t_tree4.gif) no-repeat 17px 5px;
        }
        .tree5
        {
            text-indent: 25px;
            background: url(../../Images/t_tree4.gif) no-repeat 5px 5px;
        }
        .tree5 a:link, .tree5 a:visited
        {
            color: #0f3f94;
        }
        .tree5 a:hover, .tree5 a:active
        {
            color: #FF0000;
        }
        .tree100
        {
            background: url(../../Images/t_tree3.gif) no-repeat 5px 5px;
            text-indent: 25px;
            font-size: 14px;
        }
        .tree100 img
        {
            margin: 5px 0 10px 0;
        }
        .tree100 img.rx
        {
            margin: 5px 0 5px 5px;
            vertical-align: middle;
            _vertical-align: -3px;
        }
        .t_cz
        {
            padding-bottom: 5px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function ShowOrHideMenu(obj) {
            var id = obj.getAttribute('levelOneId');
            var nodes = document.links;
            for (var i = 0; i < nodes.length; i++) {
                var node1 = nodes[i];
                if (node1.getAttribute('name') != 'menu_top') { continue } // if not is menu_top
                var levelOneId = node1.getAttribute('levelOneId');
                var node2 = document.getElementById(levelOneId);
                if (!node2) { continue; } // if not found
                if (node2.id == id) {
                    node1.parentNode.parentNode.className = "tab1";
                    node2.style.display = "block";
                } else {
                    node1.parentNode.parentNode.className = "tab2";
                    node2.style.display = "none";
                }
            }
        }
        function getlisturl(lotid) {
            var lotid = arguments[0] ? arguments[0] : 0;
            var urlstr = "";
            switch (lotid) {
                case 3000:  //˫ɫ��
                    urlstr = "Default.aspx?lotid=9&playid=34";
                    break;
                case 101: //�ղ���Ŀ
                    urlstr = "admin/Collection_item.aspx";
                    break;
            }
            return urlstr;
        }
        //function getlisturlByPlay(lotid,playid,expect){
        //	var lotid=arguments[0]?arguments[0]:0;
        //	var playid=arguments[1]?arguments[1]:0;
        //	var expect=arguments[2]?arguments[2]:0;
        //	var urlstr="/pages/trade/main.php";
        //	
        //	return urlstr;
        //}
        function ShowOrHideSub(obj, id, lotid, playid, expect) {
            var lotid = arguments[2] ? arguments[2] : 0;
            var playid = arguments[3] ? arguments[3] : 0;
            var expect = arguments[4] ? arguments[4] : 0;
            if (obj.className == "tree1") {	//�㿪
                obj.className = "tree1b";
                document.getElementById("sub_" + id).style.display = "";
                if (lotid == 101) {
                    //        parent.mainFrame.location.href="http://www.pinble.com"+getlisturl(lotid);

                } else {
                    //����ڵ���ڿ����չ����ҳ��·��
                    //        parent.mainFrame.location.href="http://localhost:48795/"+getlisturl(lotid);
                }
            } else if (obj.className == "tree1b") { //����
                obj.className = "tree1";
                document.getElementById("sub_" + id).style.display = "none";
            } else if (obj.className == "tree2") {  //�ӵ㿪
                obj.className = "tree2b";
                document.getElementById("sub_" + id).style.display = "";
                if (lotid == 9) {
                    //        parent.mainFrame.location.href="http://www.pinble.com"+getlisturlByPlay(lotid,playid);
                } else if (lotid == 10000 || lotid == 1 || lotid == 15 || lotid == 17) {
                    //        parent.mainFrame.location.href="http://www.pinble.com"+getlisturlByPlay(lotid,playid,expect);	
                }
            } else if (obj.className == "tree2b") { //������
                obj.className = "tree2";
                document.getElementById("sub_" + id).style.display = "none";
            }
            else if (obj.className == "tree3") {
                if (lotid == 101) {
                    parent.mainFrame.location.href = "http://localhost:48795/" + getlisturl(lotid);
                }
            }
        }

        function prev(x) {
            x = document.getElementById(x);
            var y = x.previousSibling;
            while (y && y.nodeType != 1) { y = y.previousSibling };
            return y;
        }
    </script>
</head>
<body>
    <!--��ಿ�ֿ�ʼ-->
    <div class="left">
        <div class="leftbar1">
        </div>
        <div class="leftbar2">
            <ul>
                <li class="tab1"><span><a href="/rightFrom.aspx" onclick="ShowOrHideMenu(this)" leveloneid="level_one_2"
                    name="menu_top" id="my_lottery" target="mainFrame">��<br />
                    Ʊ<br />
                    ��<br />
                    ��</a></span></li>
                <li class="tab2"><span><a href="http://num.pinble.com" target="_top" onclick="ShowOrHideMenu(this)"
                    leveloneid="level_one_3" name="menu_top" id="my_order">��<br />
                    ��<br />
                    ��<br />
                    ƴ</a></span></li>
                <li class="tab2"><span><a href="http://match.pinble.com" target="_top" onclick="ShowOrHideMenu(this)"
                    leveloneid="level_one_4" name="menu_top" id="my_account">ƴ<br />
                    ��<br />
                    ��<br />
                    ̨</a></span></li>
                <li class="tab2"><span><a href="http://tobuy.pinble.com" target="_top" leveloneid="level_one_5"
                    name="menu_top" id="my_hmdg">��<br />
                    ��<br />
                    ��<br />
                    ��</a></span></li>
                <li class="tab2"><span><a href="http://sms.pinble.com" target="_top" onclick="ShowOrHideMenu(this)"
                    leveloneid="level_one_6" name="menu_top" id="my_dxpt">��<br />
                    ��<br />
                    ƽ<br />
                    ̨</a></span></li>
                <li class="tab2"><span><a href="http://www.pinble.com/UserCenter/User_Center.aspx"
                    target="_top" id="my_useraccount">��<br />
                    ��<br />
                    ��<br />
                    ��</a></span></li>
            </ul>
        </div>
        <div class="leftbar3">
        </div>
    </div>
    <!--��ಿ�ֽ���-->
    <!--�Ҳಿ�ֿ�ʼ-->
    <div class="right">
        <div class="right1">
        </div>
        <div class="right2">
            <ul class="t_cz" id="level_one_1" style="display: none">
                <li>
                    <img src="../../Images/t_img_001.png" />
                    <ul class="tree">
                        <li>
                            <ul id="sub_user_info" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/Money_Log.aspx"
                                            target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">��ֵ/ȡ��</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/MyTradeInfo.aspx"
                                            target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">�ҵĽ��׼�¼</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/LyBookDisp.aspx"
                                            target="mainFrame" class="uc_lmu" style="cursor: pointer;">�ҵ�����&nbsp;</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <img src="../../Images/t_img_08.png" />
                    <ul class="tree">
                        <li>
                            <ul id="sub_user_touzhu" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/UsersMs.aspx" target="mainFrame"
                                            class="uc_linkBlack" style="cursor: pointer;">������</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/UsersMsSend.aspx?isSend=0"
                                            target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">�ݸ���</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/UsersMsSend.aspx?isSend=1"
                                            target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">�ѷ�����Ϣ</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/UsersMsDel.aspx"
                                            target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">������</a></div>
                                    <div class="tree3">
                                        <a href="#" class="uc_linkBlack" onclick="window.showModalDialog('MsgDetail.aspx?action=new','','dialogHeight:500px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:no;status:no;toolbar:no;menubar:no;location:no;');"
                                            style="cursor: pointer;">׫д����Ϣ</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <img src="../../Images/t_img_09.png" />
                    <ul class="tree">
                        <li>
                            <ul id="Ul1" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/ChangePWD.aspx"
                                            target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">�޸ĵ�¼����</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/PWD_Ask.aspx" target="mainFrame"
                                            class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                            <%=lblText%>
                                            ��¼�ܱ�</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/User_Info.aspx"
                                            target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">��ʵ��Ϣ����</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/Bank_Info.aspx"
                                            target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">�����˺Ź���</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/ChangePWD_buy.aspx"
                                            target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">�޸Ľ�������</a></div>
                                    <div class="tree3">
                                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/PWD_BuyAsk.aspx"
                                            target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">�޸Ľ����ܱ�</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <img src="../../Images/t_img_10.png" />
                    <ul class="tree">
                        <li>
                            <ul id="Ul2" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="/Myask.aspx" target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">
                                            ƴ �� ��</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
            <ul class="t_cz" id="level_one_2" style="display: block">
                <li>
                    <ul class="tree">
                        <li>
                            <div class="tree100">
                                <a href="rightFrom.aspx" target="mainFrame" class="uc_linkBlack" onclick="" style="cursor: pointer;">
                                    ��Ʊ������ҳ</a></div>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree100">
                                <a href="WholeCondition.aspx" target="mainFrame" class="uc_linkBlack" onclick=""
                                    style="cursor: pointer;">ȫ������</a></div>
                        </li>
                    </ul>
                    <img src="../../Images/t_img_11.png" />
                    <ul class="tree">
                        <li>
                            <ul id="Ul3" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="/admin/ItemEnactment.aspx?rom=<%=new Random().Next() %>" target="mainFrame"
                                            class="uc_linkBlack" onclick="" style="cursor: pointer;">�����趨</a></div>
                                    <div class="tree3">
                                        <a href='/admin/Market_Itemissuance.aspx?rom=<%=new Random().Next() %>' target="mainFrame"
                                            class="uc_linkBlack" onclick="" style="cursor: pointer;">��������</a></div>
                                    <div class="tree3">
                                        <a href="/admin/Market_ItemManage.aspx?rom=<%=new Random().Next() %>" target="mainFrame"
                                            class="uc_linkBlack" onclick="" style="cursor: pointer;">������������</a></div>
                                    <div class="tree3">
                                        <a href="/admin/BuyItemList.aspx" target="mainFrame" class="uc_linkBlack" onclick=""
                                            style="cursor: pointer;">�����¼</a></div>
                                    <div class="tree3">
                                        <a href="/admin/attermItem.aspx?rom=<%=new Random().Next() %>" target="mainFrame"
                                            class="uc_linkBlack" onclick="" style="cursor: pointer;">���ڵ���Ŀ</a></div>
                                    <div class="tree3">
                                        <a href="/admin/Stat.aspx?rom=<%=new Random().Next() %>" target="mainFrame" class="uc_linkBlack"
                                            onclick="" style="cursor: pointer;">�ҵĳ���ͳ��</a></div>
                                    <div class="tree3">
                                        <a href="/admin/BuyLog.aspx?rom=<%=new Random().Next() %>" target="mainFrame" class="uc_linkBlack"
                                            onclick="" style="cursor: pointer;">�ҵ����ۼ�¼</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <img src="../Images/t_img_03.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_3',3)">
                                ˫ɫ��<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_3" style="display: none">
                                <asp:Repeater ID="rep_FcSeq" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%--<a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("˫ɫ��") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("˫ɫ��") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_7',7)">
                                ����3D
                                <img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_7" style="display: none">
                                <asp:Repeater ID="rep_Fc3D" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%-- <a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("3D") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("3D") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_11',11)">
                                ���ֲ�<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_11" style="display: none">
                                <asp:Repeater ID="rep_FcQlc" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%-- <a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("���ֲ�") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("���ֲ�") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <img src="../Images/t_img_13.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_24',24)">
                                ����͸<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_24" style="display: none">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%--<a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("����͸") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("����͸") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_5',5)">
                                ������<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_5" style="display: none">
                                <asp:Repeater ID="rep_pl3" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%-- <a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("����3") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("������") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_10001',10001)">
                                ������<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_10001" style="display: none">
                                <asp:Repeater ID="rep_pl5" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%--<a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("����5") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("������") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_4',4)">
                                ���ǲ�
                                <img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_4" style="display: none">
                                <asp:Repeater ID="rep_Qxc" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%--<a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("���ǲ�") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("���ǲ�") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_8',8)">
                                22ѡ5<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_8" style="display: none">
                                <asp:Repeater ID="rep_22x5" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="tree3">
                                                <%--<a href='/Condition.aspx?name=<%#Pbzx.Common.Input.Encrypt("22ѡ5") %>&type=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName") %>
                                                </a>--%>
                                                <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("22ѡ5") %>'
                                                    target="mainFrame">
                                                    <%# Eval("TypeName")%>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <img src="Images/t_img_12.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_22',22)">
                                �ҵ��ղ�<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_22" style="display: none">
                                <li>
                                    <div class="tree3" onclick="ShowOrHideSub(this,'trade_lot_101',101)">
                                        <a href="/admin/Collection_item.aspx" target="mainFrame">��Ŀ</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="tree3">
                                        <a href="/admin/Collention_user.aspx" target="mainFrame">�̻�</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_23',23)">
                                �ҵĹ�ע<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_23" style="display: none">
                                <li>
                                    <div class="tree3">
                                        <a href="/admin/Attention.aspx" target="mainFrame">��Ŀ</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="tree3">
                                        <a href="/admin/Attention_User.aspx" target="mainFrame">�̻�</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
            <ul class="t_cz" id="level_one_3" style="display: none">
                <li>
                    <img src="../Images/t_img_03.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_201',201)">
                                ��ױ�ƴ<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_201" style="display: none">
                                <li>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8034/Default.aspx" target="mainFrame">��ױ�ƴ</a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <img src="../../Images/t_img_11.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree3">
                                <a href="http://192.168.1.121:8034/UpLoad.aspx" target="mainFrame" class="uc_linkBlack"
                                    onclick="" style="cursor: pointer;">�������</a></div>
                            <div class="tree3">
                                <a href="http://192.168.1.121:8034/admin/ReleaseManage.aspx" target="mainFrame" class="uc_linkBlack"
                                    onclick="" style="cursor: pointer;">������</a></div>
                            <%--                            <div class="tree3">
                                <a href="http://192.168.1.121:8034/" target="mainFrame" class="uc_linkBlack" onclick=""
                                    style="cursor: pointer;">�ҵĹ�ע</a></div>--%>
                            <div class="tree3">
                                <a href="http://192.168.1.121:8034/admin/UserWinningRecords.aspx" target="mainFrame"
                                    class="uc_linkBlack" onclick="" style="cursor: pointer;">�鿴�н�</a></div>
                        </li>
                    </ul>
                </li>
            </ul>
            <ul class="t_cz" id="level_one_4" style="display: none">
                <li>
                    <img src="../Images/t_img_03.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_205',205)">
                                ƴ����̨<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_205" style="display: none">
                                <li>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8099/index.aspx" target="mainFrame">ƴ����̨</a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <img src="../../Images/t_img_11.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree3">
                                <a href="http://192.168.1.121:8099/challenge/WebForm1.aspx" target="mainFrame" class="uc_linkBlack"
                                    style="cursor: pointer;">������Ϣ</a></div>
                            <div class="tree3">
                                <a href='http://192.168.1.121:8099/challenge/userManage.aspx' target="mainFrame"
                                    class="uc_linkBlack" style="cursor: pointer;">������Ϣ</a></div>
                            <div class="tree3">
                                <a href="http://192.168.1.121:8099/challenge/attention.aspx" target="mainFrame" class="uc_linkBlack"
                                    style="cursor: pointer;">�ҵĹ�ע</a></div>
                        </li>
                    </ul>
                </li>
            </ul>
            <ul class="t_cz" id="level_one_5" style="display: none">
                <li>
                    <img src="../Images/t_img_03.png" />
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_202',202)">
                                ˫ɫ��<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_202" style="display: none">
                                <li>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8033/Chipped.aspx" target="mainFrame">�������</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="tree5">
                                        �淨����
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_203',203)">
                                ����3D
                                <img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_203" style="display: none">
                                <li>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8033/ChippedSD.aspx" target="mainFrame">�������</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="tree5">
                                        �淨����
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="tree">
                        <li>
                            <div class="tree1" onclick="ShowOrHideSub(this,'trade_lot_204',204)">
                                ���ֲ�<img src="../Images/s1.gif" width="1" height="9" align="absmiddle" /></div>
                            <ul id="sub_trade_lot_204" style="display: none">
                                <li>
                                    <div class="tree3">
                                        <a href="#" target="mainFrame">�������</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="tree5">
                                        �淨����
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <img src="../../Images/t_img_11.png" />
                    <ul class="tree">
                        <li>
                            <ul id="Ul4" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8033/admin/BuyRecord.aspx" target="mainFrame" class="uc_linkBlack"
                                            style="cursor: pointer;">���ʼ�¼</a></div>
                                    <%-- <div class="tree3">
                                        <a href='http://192.168.1.121:8033/admin/TrackingRecord.aspx' target="mainFrame"
                                            class="uc_linkBlack" style="cursor: pointer;">׷�ż�¼</a></div>--%>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8033/admin/TrackingList.aspx" target="mainFrame" class="uc_linkBlack"
                                            style="cursor: pointer;">���Ƹ���</a></div>
                                    <div class="tree3">
                                        <a href="http://192.168.1.121:8033/admin/MyAttention.aspx" target="mainFrame" class="uc_linkBlack"
                                            style="cursor: pointer;">�ҵĹ�ע</a></div>
                                    <%--<div class="tree3">
                                        <a href="#" target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">������ϸ</a></div>--%>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
            <ul class="t_cz" id="level_one_6" style="display: none">
                <li>
                    <img src="../../Images/t_img_11.png" />
                    <ul class="tree">
                        <li>
                            <ul id="Ul9" style="display: block">
                                <li>
                                    <div class="tree3">
                                        <a href="Note/Note_ShoppingList.aspx" target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">
                                            ���Ŷ����б�</a></div>
                                    <div class="tree3">
                                        <a href='Note/Note_Manager.aspx' target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">
                                            �ҵĶ���</a></div>
                                    <div class="tree3">
                                        <a href='admin/Note/SMSStart.aspx' target="mainFrame" class="uc_linkBlack" style="cursor: pointer;">
                                            ���ŷ��Ͳ���</a></div>
                                    <div class="tree3">
                                        <a href='admin/Note/Note_LotteryTypeList.aspx' target="mainFrame" class="uc_linkBlack"
                                            style="cursor: pointer;">�����б����</a></div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
        <div class="right3">
        </div>
    </div>
</body>
</html>
