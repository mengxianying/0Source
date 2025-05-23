<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ShoppingCart.ascx.cs"
    Inherits="Pbzx.Web.Contorls.ShoppingCart" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<script type="text/javascript" language="javascript">
    function isnum()
    {
        if(event.keyCode<45||event.keyCode>57)
        {
        event.keyCode=0;
        }
    }   
    
    function Del(obj)
    {                
       $(obj).parent().parent().remove();
    }                
            
       function deleteRecord() 
       {
            var str="";
            var items = document.getElementsByName("chbProducts");  
            for(var i = 0 ;i<items.length;i++)
             {
                  if(items[i].checked)
                  {
                        str+=items[i].value+",";
                  }
             }              
            $.ajax({ 
                type:'POST',
                url: '/reg.aspx', 
                data:'quickAddProduct='+escape(str),
                cache: false, 
                complete: function(msg,textStatus) { 
                    if(msg.responsetext == "true")
                    {
                        $("input[name=chbProducts]").each(function(){ $(this).attr("checked",false);})                                                  
                    }
                    setTimeout($.unblockUI, 100);
                    location.reload();                                                   
                } 
            });  
       }  
                              
</script>

<div id="ShoppingCart" style="width: 100%;">
    <div class="Module" style="width: 100%">
        <asp:UpdatePanel ID="UpShoppingCart" runat="server">
            <ContentTemplate>
                <div id="divProductList" style="display: none; cursor: default;">
                    <table width="510" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="5%">
                                            <img src="/Images/Web/order_class1.gif" border="0" /></td>
                                        <td background="/Images/Web/order_class1bg.gif" width="85%" align="left">
                                            <span style="color: White; cursor:pointer;">����ѡ�����</span>
                                        </td>
                                        <td align="center" background="/Images/Web/order_class1bg.gif" width="10%">
                                            <a href="#" onclick="setTimeout($.unblockUI, 100);"><span style="color: White;cursor:pointer;">[�ر�]</span>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="8" background="/Images/Web/order_class1xbg.gif">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Repeater ID="rptTypes" runat="server">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="1" cellspacing="1" border="0" bgcolor="#F6F6F6">
                                            <tr>
                                                <td style="width: 21%" align="left" class="bold" valign="top">
                                                    <span class="blue"><b>&nbsp;<%# getChild(Eval("pb_TypeName"))%>�� </b></span>
                                                </td>
                                                <td style="width: 79%" align="left">
                                                    <asp:DataList ID="dlChild" DataSource="<%# Dview %>" runat="server" RepeatColumns="2"
                                                        ItemStyle-HorizontalAlign="Left" RepeatDirection="Horizontal">
                                                        <ItemTemplate>
                                                            <div class="Module_Right">
                                                                <%# showRights(Eval("pb_SoftID"), Eval("pb_SoftName"))%>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                            <tr>
                                                <td style="width: 21%" align="left" class="bold" valign="top">
                                                    <span class="blue"><b>&nbsp;<%# getChild(Eval("pb_TypeName"))%>�� </b></span>
                                                </td>
                                                <td style="width: 79%" align="left">
                                                    <asp:DataList ID="dlChild" DataSource="<%# Dview %>" runat="server" RepeatColumns="2"
                                                        ItemStyle-HorizontalAlign="Left" RepeatDirection="Horizontal">
                                                        <ItemTemplate>
                                                            <div class="Module_Right">
                                                                <%# showRights(Eval("pb_SoftID"), Eval("pb_SoftName"))%>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                                <table width="55%" cellpadding="2" cellspacing="0" border="0" align="center">
                                    <tr>
                                        <%--                                        <td style="width:17%">
                                            <input id="btnall" onclick='$("input[name=chbProducts]").each(function(){ $(this).attr("checked",true);})'
                                                type="button" value="ȫѡ" class="order_classbtn" />
                                        </td>--%>
                                        <%--                                        <td style="width:17%">
                                            <input id="antiAll" onclick='$("input[name=chbProducts]").each(function(){ $(this).attr("checked",!this.checked);})'
                                                type="button" value="��ѡ" class="order_classbtn" /></td>--%>
                                        <td style="width: 30%">
                                            <input id="inputadd" onclick="deleteRecord();" class="order_classbtn" value="ȷ��" />
                                        </td>
                                        <td style="width: 40%">
                                            &nbsp;
                                        </td>
                                        <td style="width: 30%">
                                            <input id="delAll" onclick='$("input[name=chbProducts]").each(function(){ $(this).attr("checked",false);})'
                                                type="button" value="���" class="order_classbtn" />
                                            <asp:HiddenField ID="hfCategoryId" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="4">
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#4F9CEC" height="4">
                            </td>
                        </tr>
                    </table>
                </div>
                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="MT3">
                    <tr>
                        <td width="4%" align="left">
                            <img src="/Images/Web/shop.jpg" border="0" alt="" width="27" height="19" />
                        </td>
                        <td align="left" width="96%">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 50%" align="left">
                                        <span class="shop14">�ҵĹ��ﳵ</span>
                                    </td>
                                    <td>
                                        <div id="" style="width: 80px; cursor: pointer;">
                                        &nbsp;</td>
                                    <td style="width: 50%" align="right">
                                        <span style="float: right;">
                                            <input type="button" name="button" value="����ѡ�����" class="order_myCenterbtn" onclick="$.blockUI({ message: $('#divProductList'), css: {width: '510px',top:($(window).height() - 500) /2 + 'px' } });" />
                                            <input type="button" name="button" value="�ҵĶ���" onclick="window.top.location.href='/UserCenter/User_Center.aspx?myUrl=OrderList.aspx'"
                                                class="order_mymoreProductbtn"></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                    BackColor="#80BFF7" CssClass="GridView_Table1" HorizontalAlign="Center" BorderWidth="0px"
                    OnRowCreated="MyGridView_RowCreated" DataKeyNames="CartID,ProductID,pb_SoftName,RegType,Quatity,pb_TypeName,pb_DemoUrl,pb_RegUrl"
                    OnRowDataBound="MyGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                                <a href="Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                    title='<%#Eval("pb_SoftName")%>' class="S_title1">&nbsp;<%# Eval("pb_softname")%></a>
                            </ItemTemplate>
                            <ItemStyle Width="20%" HorizontalAlign="Left" BackColor="#E3F8FD" />
                            <HeaderStyle BackColor="#98E2F5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ע�᷽ʽ">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlRegType" runat="server" OnSelectedIndexChanged="ddlRegType_SelectedIndexChanged"
                                    AutoPostBack="True" Width="175px">
                                    <asp:ListItem Value="-1">��ѡ��</asp:ListItem>
                                    <asp:ListItem Text="����ע�᷽ʽ" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="�����󶨷�ʽ" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="�������ʽ(����ǰ�����)" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="�������ʽ(�����������)" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="�������ʽ(���������)" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Panel ID="pnlUserName" runat="server" Visible="false">
                                    ʹ�����û�����<asp:TextBox ID="txtUserName" onfocus="this.select()" CssClass="shop_intput_border"
                                        MaxLength="12" runat="server" OnTextChanged="txtUserName_TextChanged" Width="120px"
                                        AutoPostBack="True"></asp:TextBox>
                                </asp:Panel>
                                <asp:Panel ID="pnlRZM" runat="server" Visible="false">
                                    ��֤�룺<asp:TextBox ID="txtRZM" onfocus="this.select()" CssClass="shop_intput_border"
                                        runat="server" MaxLength="16" OnTextChanged="txtRZM_TextChanged" Width="120px"
                                        AutoPostBack="True"></asp:TextBox>
                                </asp:Panel>
                            </ItemTemplate>
                            <ItemStyle Width="22%" HorizontalAlign="Left" BackColor="#E3F8FD" />
                            <HeaderStyle BackColor="#98E2F5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                                <asp:Panel runat="server" ID='showprice_0' Style="text-align: left;">
                                    <%--Visible="false"--%>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="radio_8" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                    RepeatLayout="Flow" OnSelectedIndexChanged="radio_8_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:Panel runat="server" ID='pnlDays' Visible="false" Style="text-align: left;">
                                                    ������
                                                    <asp:TextBox ID="txtDays" runat="server" onfocus="this.select()" onkeypress="isnum()"
                                                        Style="width: 30px;" CssClass="shop_intput_border" Text='50' MaxLength="4" AutoPostBack="True"
                                                        OnTextChanged="txtDays_TextChanged"></asp:TextBox>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat="server" ID='showprice_1' Style="text-align: left;">
                                    <asp:RadioButtonList ID="radio_1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" OnSelectedIndexChanged="radio_1_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </asp:Panel>
                                <asp:Panel runat="server" ID='showprice_2' Style="text-align: left;">
                                    <asp:RadioButtonList ID="radio_9" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" OnSelectedIndexChanged="radio_1_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </asp:Panel>
                                <asp:Panel runat="server" ID='showprice_3' Style="text-align: left;">
                                    <asp:RadioButtonList ID="radio_7" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" OnSelectedIndexChanged="radio_1_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </asp:Panel>
                                <asp:Panel runat="server" ID='showprice_4' Style="text-align: left;">
                                    <asp:RadioButtonList ID="radio_6" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" OnSelectedIndexChanged="radio_1_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </asp:Panel>
                            </ItemTemplate>
                            <ItemStyle Width="43%" HorizontalAlign="Center" BackColor="#E3F8FD" />
                            <HeaderStyle BackColor="#98E2F5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�۸�">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# GetOneProductPrice(Eval("CartID"), Eval("RegType").ToString()) %>'
                                    ForeColor="Red"></asp:Label>Ԫ
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" BackColor="#E3F8FD" />
                            <HeaderStyle HorizontalAlign="Center" BackColor="#98E2F5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDel" runat="server" Text="ɾ��" OnClientClick="return confirm('��ȷ��ɾ���������')"
                                    CommandArgument='<%# Eval("CartID") %>' OnCommand="lbtnDel_Command"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" BackColor="#E3F8FD" />
                            <HeaderStyle HorizontalAlign="Center" BackColor="#98E2F5" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="GridView_Pager1" />
                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header1" />
                    <AlternatingRowStyle CssClass="GridView_AlternatingRow1" />
                    <RowStyle CssClass="GridView_Row1" />
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    <EmptyDataTemplate>
                        <div style="width: 90%; text-align: center;">
                            ����û��ѡ���κ����������<a onclick="$.blockUI({ message: $('#divProductList'), css: { width: '510px',top:($(window).height() - 500) /2 + 'px' } });"
                                href="#">����ѡ�����</a> �����ߵ�� <a href="/Soft.aspx">����ѡ�����</a>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <table width="100%" cellpadding="2" cellspacing="0" border="0" height="40">
                    <tr>
                        <td width="32%">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            <asp:ImageButton ID="btnClearShoppingCart" runat="server" OnClick="btnClearShoppingCart_Click"
                                ImageUrl="/Images/Web/shop_flush.jpg" align="middle" CssClass="order_Cursor" />
                            <a href="/Soft.aspx">
                                <img src="/Images/Web/shop_go.jpg" border="0" align="middle" /></a>
                        </td>
                        <td width="33%">
                        </td>
                        <td width="35%">
                            <span class="shop14black">�ܼ۸񣨲����˷ѣ���<span runat="server" class="shop14red" id="lblSumPrice">0.00</span>Ԫ</span>
                            <asp:ImageButton ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" ImageUrl="~/Images/Web/shop_cast.jpg"
                               CssClass="order_Cursor"   align="middle" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <b class="RoundBottom"><b class="lr4"></b><b class="lr3"></b><b class="lr2"></b><b
            class="lr1"></b></b>
    </div>
</div>
