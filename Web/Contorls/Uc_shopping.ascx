<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_shopping.ascx.cs"
    Inherits="Pbzx.Web.Contorls.Uc_shopping" %>

<script type="text/javascript" language="javascript">
      $(document).ready(function(){
            $('#dvMeng').bind("mouseleave",function(){ 
               setTimeout("document.getElementById('dvTest').style.display='none'",100);
            });
            
            $('#dvMeng').bind("mouseenter",function(){
            //document.getElementById("<%=btnMengRef.ClientID %>").click();
            setTimeout("document.getElementById('dvTest').style.display=''",100);
            });
      });
      
//      function  CartDisplay()
//      {
//         document.getElementById("<%=btnMengRef.ClientID %>").click();
//         document.getElementById("dvTest").style.display=""; 
//      }
//      function CartHid()
//      {
//            document.getElementById("dvTest").style.display="none";
//      }

    function Del(obj)
    {                
       $(obj).parent().parent().remove();
    }                
            
       function deleteRecord(CartID,myObj) 
       {           
            $.ajax({ 
                type:'POST',
                url: '/reg.aspx', 
                data:'delCart='+CartID,
                cache: false, 
                complete: function(msg,textStatus) { 
                var tempSZ = msg.responsetext.split('|');
                    if(tempSZ.length == 2 && tempSZ[1] !="")
                    {                                                                                             
                          $("#<%=lblCount.ClientID %>").html(tempSZ[1]);                          
                          $("#<%=lblSumPrice.ClientID %>").html(tempSZ[0]);                                                                     
                         Del(myObj);                                            
                    }                                               
                } 
            });  
       } 
       
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <input type="button" id="btnMengRef" runat="server" onserverclick="btnMengRef_ServerClick"
            style="display: none; width: 0px;" />
        <table width="360" border="0" cellspacing="0" cellpadding="0" style="">
            <tr>
                <td>
                    <img src="/Images/Web/shopp_l.png" />
                </td>
                <td width="354" background="/Images/Web/shopp_bg.jpg">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td id="dvMeng" align="left">
                                <div style="width: 100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="middle">
                                                <img src="/Images/Web/shopp_che.jpg" hspace="3" vspace="1" />
                                            </td>
                                            <td>
                                                <a href="/ShowShoppingCart.aspx">购物车有 <font class="shop_count">
                                                    <asp:Label ID="lblCount" runat="server" Text=""></asp:Label></font> 件软件<img src="/Images/Web/shopp_btn.jpg"
                                                        border="0" hspace="5" align="absmiddle" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="dvTest" style="display: none; width: 340px; background-color: Gray; z-index: 20000;
                                    position: absolute; background-color: White; border: 2px solid #FDD826; padding-left: 6px;
                                    padding-top: 6px; padding-right: 5px; margin-top: 2px;">
                                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="CartID,ProductID,RegType"
                                        OnRowDataBound="GridView1_RowDataBound" GridLines="None" ShowHeader="False" CssClass="GridView_Table3">
                                        <Columns>
                                            <asp:TemplateField HeaderText="软件名称">
                                                <ItemTemplate>
                                                    <a href="Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                        title='<%#Eval("pb_SoftName")%>' class="shop_countlink">
                                                        <%# Eval("pb_softname")%>
                                                    </a>
                                                </ItemTemplate>
                                                <ItemStyle Width="187px" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="注册方式">
                                                <ItemTemplate>
                                                    <%# Pbzx.Web.WebFunc.GetShortRegType(Eval("RegType"))%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="left" Width="55px" />
                                                <ItemStyle HorizontalAlign="left" Width="55px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="价格" HtmlEncode="False">
                                                <HeaderStyle HorizontalAlign="left" Width="60px" />
                                                <ItemStyle HorizontalAlign="left" Width="60px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="操作">
                                                <ItemTemplate>
                                                    <a href="#" onclick="deleteRecord('<%#Eval("CartID") %>',this)">删除</a>
                                                </ItemTemplate>
                                                <ItemStyle Width="40px" HorizontalAlign="center" />
                                                <HeaderStyle HorizontalAlign="center" Width="40px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="GridView_Table3" />
                                        <EmptyDataTemplate>
                                            <div style="width: 324px; text-align: center;">
                                                您的购物车暂无软件， 赶快选择心爱的软件吧！
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <table width="100%" cellpadding="2" cellspacing="0" border="0" height="40">
                                        <tr>
                                            <td width="100%" align="center">
                                                <span id="spPrice" runat="server"><span class="shop14black">总价格（不含运费）：<span runat="server"
                                                    class="shop14red" id="lblSumPrice">0.00</span>元</span>
                                                    <br />
                                                    <a href="/ShowShoppingCart.aspx">
                                                        <img src="/Images/Web/shop_buybtn.jpg" alt="查看购物车" border="0" /></a> </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td width="3%" align="center">
                                <img src="/Images/Web/shopp_li.jpg" /></td>
                            <td width="26%">
                                <a href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx">我的订单<asp:Label ID="lblOrderCount"
                                    runat="server" Text=""></asp:Label></a></td>
                            <td width="3%" align="center">
                                <img src="/Images/Web/shopp_li.jpg" /></td>
                            <td width="18%">
                                <a href="/UserCenter/User_Center.aspx?myUrl=Favorites.aspx">我的收藏</a></td>
                        </tr>
                    </table>
                </td>
                <td width="0" background="/Images/Web/shopp_bg.jpg">
                    <img src="/Images/Web/shopp_r.png" border="0" height="22" width="6" /></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
