<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAddOrder.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcAddOrder" %>

<script type="text/javascript" src="/UserCenter/js/advance.js"></script>

<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"
    class="MT">
    <tr>
        <td height="20" colspan="4" align="left" background="/Images/Web/shop_serve.jpg">
            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <strong>ʹ������Ϣ</strong>&nbsp;&nbsp;���������ʵ��д���Ա��Ժ��������ʱ�˶�����ע����Ϣ��</td>
                    <td align="right">
                        <span class="shop_red">��*Ϊ������</span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td width="11%" align="right">
            ������</td>
        <td width="22%" align="left">
            <asp:TextBox ID="txtReceiverName" runat="server" Width="100px" MaxLength="16"></asp:TextBox>&nbsp;<span
                class="shop_red">*</span><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReceiverName"
                ErrorMessage="�������ܿգ�" Display="Dynamic"></asp:RequiredFieldValidator></td>
        <td width="13%" align="right">
            �绰��</td>
        <td width="54%" align="left">
            <asp:TextBox ID="txtReceiverPhone" runat="server" Width="200px" MaxLength="16"></asp:TextBox>&nbsp;<span
                class="shop_red">*</span><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReceiverPhone"
                ErrorMessage="�绰���ܿգ�" Display="Dynamic"></asp:RequiredFieldValidator>
                <iframe style="display:none" src="/BoilingSoft/getm.aspx?act=getm&returnobjid=AddOrder1_txtReceiverPhone"></iframe>
                </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td align="right">
            �ʱࣺ</td>
        <td align="left">
            <asp:TextBox ID="txtReceiverPostalCode" runat="server" Width="100px" MaxLength="6"></asp:TextBox>
            <br />
        </td>
        <td align="right">
            Email��</td>
        <td align="left">
            <asp:TextBox ID="txtReceiverEmail" runat="server" Width="200px" MaxLength="32"></asp:TextBox>
            <br />
            </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td align="right">
            ��ϸ��ַ��</td>
        <td colspan="3" align="left">
            <asp:TextBox ID="txtReceiverAddress" runat="server" Width="300px" MaxLength="32"></asp:TextBox>&nbsp;<span
                class="shop_red">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReceiverAddress"
                ErrorMessage="��ַ���ܿգ�" Display="Dynamic"></asp:RequiredFieldValidator><br />
            (�����ѡ����[�����������]��ʽ��������������д��ϸ׼ȷ�ĵ�ַ����ȷ�����յ������)</td>
    </tr>
</table>
<asp:Panel runat="server" ID="tbPortType" Width="100%">
    <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"
        class="MT">
        <tr>
            <td height="20" bgcolor="#FFF4DD" align="left" 
                background="/Images/Web/shop_serve.jpg">
                &nbsp;<b class="bTitle">������Ϣ</b></td>
        </tr>
        <tr bgcolor="#ffffff">
            <td align="left" style="padding-top: 7px; padding-left: 8px;" valign="top">
                <%--<asp:RadioButtonList ID="rblPortType" runat="server" DataSourceID="objectDSPortType"
                DataTextField="PortTypeName" DataValueField="PortTypeID" RepeatLayout="Flow">
            </asp:RadioButtonList>--%>
                <asp:Label ID="lblJSXX" runat="server"></asp:Label><%--<asp:Repeater ID="repPortType" runat="server" DataSourceID="objectDSPortType">
                <ItemTemplate>
                    �˷ѣ�<%# Eval("PortPrice","{0:C2}") %><br />
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="objectDSPortType" runat="server" SelectMethod="GetAllList"
                TypeName="Pbzx.BLL.PBnet_PortType"></asp:ObjectDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblPortType"
                EnableViewState="False" ErrorMessage="���䷽ʽδѡ��" Display="Dynamic"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr bgcolor="#ffffff">
            <td align="right" style="padding-top: 7px" valign="top">
                <asp:Label ID="lblYFJE" runat="server"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>
<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"
    class="MT">
    <tr>
        <td height="20" bgcolor="#FFF4DD" align="left" background="/Images/Web/shop_serve.jpg">
            &nbsp;<b class="bTitle">֧����ʽ</b></td>
    </tr>
    <tr bgcolor="#ffffff">
        <td align="left" style="padding-top: 7px;">
                    <asp:UpdatePanel ID="UpFKFS" runat="server">
                <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="left">
                        <table style="width: 100%; border-right: #99ccff 1px dashed; border-top: #99ccff 1px dashed; border-left: #99ccff 1px dashed; border-bottom: #99ccff 1px dashed;"  >
                            <tr>
                                <td style="width: 100px" valign="top">
                                    <asp:RadioButton ID="rblOnline" runat="server" GroupName="PayTypes" Text="����֧��" Checked="true"
                                        AutoPostBack="True" OnCheckedChanged="rblOnline_CheckedChanged" Font-Bold="True" ForeColor="Black" />
                                </td>
                                <td align="right">
                                    <table id="tbOnline" runat="server" style="color:Black;">
                                        <tr>
                                            <td style="width: 50px" valign="top" align="left">
                                               ˵����</td>
                                            <td align="left">
                                               1��ȫ�Զ������ע�Ṻ��ʽ������֧���ɹ���ϵͳ��ʵʱ�Զ���ͨ��ע���������������ʹ�á� ���ڡ��û�����-�ҵĶ������鿴���Ĺ�����Ϣ����������������û���ע��������Ŀ�ݣ�                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px">
                                            </td>
                                            <td align="left">
                                                2��֧�����߸����ƽ̨�У��������ߡ���Ǯ��֧������(��ʱ���ʣ�֧�־���������н�ǿ������ÿ���׼ȷ��ݣ��Ƽ���ʹ�ô�֧����ʽ��
                                                <a href='/Payment.htm' target='_blank'>�鿴���м��޶�</a>) 
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trOnlinePay" runat="server" visible="True">
                                <td colspan="2" align="center" >
                                    <table width="96%" runat="server" style="color:Black;" id="tbOnline2">
                                        <tr>                                        
                                            <td colspan="4" align="left">
                                             <table width="100%">
                                                <tr>
                                                    <td style="width:70px">
                                                    
                                                    </td>
                                                    <td>
                                                       ֧��ƽ̨����<font color="red">����ƽ̨��֧�ֹ������С��������С��������С���ͨ���С�ũҵ���С��й����е���������֧��</font>��
                                                    </td>
                                                </tr>
                                             </table>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                               <%-- &nbsp;<img alt="����֧��" src="/Images/Web/yunwang.jpg" />--%></td>
                                            <td align="center">
                                               <%-- &nbsp;<img src="/Images/Web/jdzf.png" width="111" height="44" alt="" border="0" />--%></td>
                                            <td align="center">
                                                </td>
                                            <td align="center">
                                                &nbsp;<img alt="֧����֧��" src="/Images/Web/Pay_treasure.jpg" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table style="width: 100%; border-right: #99ccff 1px dashed; border-top: #99ccff 1px dashed; border-left: #99ccff 1px dashed; border-bottom: #99ccff 1px dashed;"  >
                            <tr>
                                <td style="width: 100px" valign="top">
                                    <asp:RadioButton ID="rblBank" runat="server" GroupName="PayTypes" Text="����֧��" OnCheckedChanged="rblBank_CheckedChanged" AutoPostBack="True" Font-Bold="True" ForeColor="Black" />
                                </td>
                                <td align="left">
                                    <table >
                                        <tr>
                                            <td style="width: 50px" valign="top" align="left">
                                               ˵����</td>
                                            <td align="left">
                                                ����֧��(�����Ƹ�֧ͨ����ʽ������ָ���������¶�����Ȼ��ȥ���л��ڡ��û�����-�ҵĶ��������ȷ���ѻ���˾���ڲ鵽�����ʵ������1-3����������Ϊ����ͨ�����
                                                    <a href='/Payment.htm' target='_blank'>�鿴�����ʺ�</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table style="width: 100%; border-right: #99ccff 1px dashed; border-top: #99ccff 1px dashed; border-left: #99ccff 1px dashed; border-bottom: #99ccff 1px dashed;" >
                            <tr>
                                <td style="width: 100px;" valign="top">
                                    <asp:RadioButton ID="rblBalancePay" runat="server" GroupName="PayTypes" Text="���֧��" OnCheckedChanged="rblBalancePay_CheckedChanged" AutoPostBack="True" Font-Bold="True" ForeColor="Black" />
                                </td>
                                <td align="left" valign="top">
                                    <table >
                                        <tr>
                                            <td style="width: 50px" valign="top" align="left">
                                                ˵����</td>
                                            <td style="text-align: left;">
                                                ȫ�Զ������ע�Ṻ��ʽ�����֧���ɹ���ϵͳ��ʵʱ�Զ���ͨ��ע���������������ʹ�á����ڡ��û�����-�ҵĶ������鿴���Ĺ�����Ϣ����������������û���ע��������Ŀ�ݣ�
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td align="left" valign="top">
                                   <asp:Panel ID="pnlYEZF" runat="server"  Visible="false">
                                        Ӧ���ܶ<asp:Label ID="lblSumPrice" runat="server" Text=""></asp:Label>
                                        <asp:Panel ID="pnlNoMoney" runat="server" Visible="true">
                                            ������<asp:Label ID="lblCurrentMoney" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label
                                                ID="lblAlert" runat="server" Text="" Visible="false"></asp:Label>
                                            <a href="/UserCenter/User_Center.aspx?myUrl=User_Deposit.aspx" class="uc_linkBlack"
                                                onclick="">
                                                <asp:Image ID="imgCZ" runat="server" border="0" AlternateText="��ֵ" ImageUrl="/Images/Web/UC_bt2.png"
                                                    Visible="false" /></a>
                                        </asp:Panel>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                    </td>
                </tr>
            </table>

                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="hdPortPrice" runat="server" />
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="4">
    <tr>
        <td align="center">
            <asp:Button ID="btnAddOrders" runat="server" Text="�ύ����" CssClass="shop_Button" 
                OnCommand="btnAddOrders_Command" />
            &nbsp;<asp:Button ID="btnModifyOrders" runat="server" OnClick="btnModifyOrders_Click"
                Text="�޸Ķ���" CssClass="shop_Button" /><br />
            <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label></td>
    </tr>
</table>
