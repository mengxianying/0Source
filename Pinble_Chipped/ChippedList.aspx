<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChippedList.aspx.cs" Inherits="Pinble_Chipped.ChippedList" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>合买列表页</title>
    <meta name="Keywords" content="" />
 <meta name="Description" content="" />
 <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
 <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
 <script type="text/javascript">
    $(document).ready(function(){
        $("#btn_cy").click(function(){
		$.XYTipsWindow({
			___title: "参与合买",    //窗口标题文字
	        ___content: "iframe:Agreement.aspx",    //内容{text|id|img|url|iframe}
	        ___width: "540",            //窗口宽度
	        ___height: "400",          //窗口离度
	        ___titleClass: "boxTitle",	//窗口标题样式名称
	        ___closeID:"",		//关闭窗口ID
	        ___time:"",		    //自动关闭等待时间
	        ___drag:"___boxTitle",		    //拖动手柄ID
	        ___showbg:true,		//是否显示遮罩层
	        ___offsets:{left:"auto",top:"auto"},//设定弹出层位置,默认居中
	        ___fns:function(){}//关闭窗口后执行的函数

		});
	});
    });
 </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
            <table width="100%" border="0" >
                <asp:Repeater ID="rep_list" runat="server" OnItemDataBound="rep_list_ItemDataBound">
                    <HeaderTemplate>
                        <tr>
                            <td>
                                序号
                            </td>
                            <td>
                                发起人
                            </td>
                            <td>
                                战绩
                            </td>
                            <td>
                                方案金额
                            </td>
                            <td>
                                每份金额
                            </td>
                            <td>
                                方案内容
                            </td>
                            <td>
                                方案进度
                            </td>
                            <td>
                                剩余份数
                            </td>
                            <td>
                                认购份数
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                            <td>
                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                            </td>
                            <td>
                                <%# Eval("UserName") %>
                            </td>
                            <td>
                                战绩
                            </td>
                            <td>
                                <%# Eval("AtotalMoney") %>
                            </td>
                            <td>
                                <asp:Label ID="lab_Each" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lab_Content" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lab_progress" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lab_surplus" runat="server"></asp:Label>份
                            </td>
                            <td>
                                <input id="txt_num" type="text" size="3" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" />
                            </td>
                            <td>
                                <input id="btn_cy" type="button" class="btn_cy" value="参与" />
                                <a href="ParticiPation.aspx?num=<%# Eval("QNumber") %>" target="_blank">详情</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label ID="litContent" runat="server"></asp:Label><tr>
                    <td colspan="9" style="background-color: #FFFFFF;">
                        <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" custominfotextalign="Center"
                            firstpagetext="第一页" lastpagetext="最后一页" nextpagetext="下一页" onpagechanged="AspNetPager1_PageChanged"
                            prevpagetext="上一页" showcustominfosection="Right" showinputbox="Always" shownavigationtooltip="True"
                            width="100%" backcolor="Transparent" custominfostyle='vertical-align:middle;'
                            custominfosectionwidth="35%" horizontalalign="Center">
                            </webdiyer:aspnetpager>
                    </td>
                </tr>
            </table>
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
        
    </form>
</body>
</html>
