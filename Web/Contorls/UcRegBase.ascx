<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcRegBase.ascx.cs" Inherits="Pbzx.Web.Contorls.UcRegBase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript" src="/javascript/SearchAjax.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<script type="text/javascript">
    function pro_change(type) {
        Open_yzm(type);
    }
</script>
<style>
    .registration-card
    {
        max-width: 600px;
        margin: 2rem auto;
        box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        border-radius: 8px;
    }
    .form-input
    {
        border: 1px solid #e0e0e0;
        transition: border-color 0.3s ease;
    }
    .form-input:focus
    {
        border-color: #007bff;
        box-shadow: none;
    }
    .btn-action
    {
        min-width: 120px;
        letter-spacing: 0.8px;
    }
    .step-title
    {
        color: #2c3e50;
        font-weight: 600;
        margin-bottom: 1.5rem;
    }
</style>
<asp:Panel ID="p3" runat="server" Width="100%" Visible="true">
    <!-- Register.aspx -->
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <!-- ��һ�����˻���Ϣ -->
        <asp:View ID="View1" runat="server">
            <h3>
                ����1/4 - �˻���Ϣ</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td width="21%" height="42" align="right" valign="top">
                        �û�����
                    </td>
                    <td width="79%" align="left" valign="top">
                        <asp:TextBox ID="txtUserName" runat="server" ValidationGroup="baseinfo" onblur="CheckUser5(this.value,'mySpUname');"
                            Width="210px" MaxLength="12"></asp:TextBox>&nbsp;<font color="red">*</font>&nbsp;<span
                                class="font_gray">�������ڱ���վ��Ψһ��ʶ,�û���Ϊ3-12λ����ĸ�����֡�������ɡ�</span><br />
                        <span id="mySpUname"></span>
                        <iframe id="zz" src="about:blank" style="display: none;"></iframe>
                        <script>
                            function CheckUser5(aa, bb) {
                                document.getElementById("zz").src = "/reg.aspx?checkUserName=" + escape(aa);
                            }
                        </script>
                        <%--                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                        <%--                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    ���ڼ����...........
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        ���õ�¼���룺
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPassWord" runat="server" ValidationGroup="baseinfo" TextMode="Password"
                            Width="210px" MaxLength="16"></asp:TextBox>&nbsp;<font color="red">*</font>&nbsp;<span
                                class="font_gray">�������������룬�����������ĸ�����ֵ���ϣ�ȷ��������Ϣ��ȫ</span><br />
                        <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtPassWord"
                            ErrorMessage="���������6-16λ����ĸ������" ValidationExpression="^[a-zA-Z0-9_]{6,18}$" ValidationGroup="baseinfo"
                            SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        ȷ�ϵ�¼���룺
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtRePassWord" runat="server" ValidationGroup="baseinfo" TextMode="Password"
                            Width="210px" MaxLength="16"></asp:TextBox>&nbsp;<font color="red">*</font>&nbsp;<span
                                class="font_gray">���ٴ������¼����</span><br />
                        <asp:CompareValidator ID="crepassword" runat="server" ErrorMessage="������������벻һ��" ControlToCompare="txtPassWord"
                            ControlToValidate="txtRePassWord" ValidationGroup="baseinfo" SetFocusOnError="True"
                            Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr height="42" align="left" valign="top">
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnNext1" runat="server" Text="��һ��" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnNext_Click" CommandArgument="1" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <!-- �ڶ�����������֤ -->
        <asp:View ID="View2" runat="server">
            <h3>
                ����2/4 - ������֤</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        �����һ�Email��
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtEmail" onblur="CheckEmail6(this.value,'mySpUserEmail');" runat="server"
                            ValidationGroup="baseinfo" Width="210px" MaxLength="50"></asp:TextBox>&nbsp;<font
                                color="red">*</font> <span class="font_gray">����������õ�Email��ַ����������ʱ�����ø������һ�����</span><br />
                        <span id="mySpUserEmail"></span>
                        <iframe id="eee" src="about:blank" style="display: none;"></iframe>
                        <script>
                            function CheckEmail6(aa, bb) {
                                document.getElementById("eee").src = "/reg.aspx?CheckUserEmail=" + escape(aa);
                            }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        Email��֤�룺
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtEmailCode" runat="server" Width="210px" MaxLength="6"></asp:TextBox>&nbsp;<font
                            color="red">*</font>
                        <input type="button" value="������֤��" onclick="javascript:tosendEmail();" id="emailButton1">
                        <span class="font_gray" id="Span1"></span>
                        <br />
                        <script type="text/javascript">
                            var daojishi = 0;
                            function tosendEmail() {
                                // ����Ƿ�Ϊ360���������ģʽ
                                if (navigator.userAgent.indexOf('MSIE') !== -1 ||
			    navigator.userAgent.indexOf('Trident') !== -1 ||
			    (navigator.userAgent.indexOf('360EE') !== -1 && document.documentMode)) {

                                    alert('���л�������ģʽ��ʹ��Chrome/Firefox���ִ������');
                                    // �����ṩ�л������ģʽ��ָ��
                                } else {



                                    var rs = pro_change("Email");
                                    xianshidaoshiji();
                                }
                            }
                            // ע��
                            function xianshidaoshiji() {
                                document.getElementById("emailButton1").disabled = true;
                                daojishi = 0;

                                setTimeout("sixth()", 1000);
                            }
                            function sixth() {
                                daojishi = daojishi + 1;

                                if (daojishi < 60) {
                                    var ksq = "��ʣ��" + (60 - daojishi) + "��";

                                    document.getElementById("emailButton1").value = ksq;
                                    setTimeout("sixth()", 1000);

                                }
                                else {
                                    document.getElementById("emailButton1").disabled = false;
                                    document.getElementById("emailButton1").value = "������֤��";
                                    document.getElementById("txtEmailCode").readonly = false;
                                }
                            }
                            
                        </script>
                    </td>
                </tr>
                <tr height="42" align="left" valign="top">
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnPrev2" runat="server" Text="��һ��" CssClass="btn btn-secondary btn-action rounded-pill"
                            OnClick="btnPrev_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNext2" runat="server" Text="��һ��" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnNext_Click" CommandArgument="2" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <!-- ���������ֻ���֤ -->
        <asp:View ID="View3" runat="server">
            <h3>
                ����3/4 - �ֻ���֤</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        �ֻ����룺
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtQQ" onblur="CheckMobile7(this.value,'mySpUserMobile');" runat="server"
                            ValidationGroup="baseinfo" Width="210px" MaxLength="11"></asp:TextBox>&nbsp;<font
                                color="red">*</font> <span class="font_gray">������11λ���ֻ�����</span><br />
                        <span id="mySpUserMobile"></span>
                        <iframe id="mmm" src="about:blank" style="display: none;"></iframe>
                        <script>
                            function CheckMobile7(aa, bb) {
                                document.getElementById("mmm").src = "/reg.aspx?CheckUserMobile=" + escape(aa);
                            }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        �ֻ���֤�룺
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPhoneCode" runat="server" Width="210px" MaxLength="4"></asp:TextBox>&nbsp;<font
                            color="red">*</font>
                        <input type="button" value="������֤��" onclick="javascript:tosendSms();" id="yanzhengmabutton">
                        <span class="font_gray" id="ktishi5">�����޷�3�Σ��ύ����ʱ��֤������ٴ�ʹ��</span><br />
                        <iframe name="Runwin" id="Runwin" style="display: none;"></iframe>
                        <script>
                            var daojishi = 0;
                            function tosendSms() {

                                // ����Ƿ�Ϊ360���������ģʽ
                                if (navigator.userAgent.indexOf('MSIE') !== -1 ||
			    navigator.userAgent.indexOf('Trident') !== -1 ||
			    (navigator.userAgent.indexOf('360EE') !== -1 && document.documentMode)) {

                                    alert('���л�������ģʽ��ʹ��Chrome/Firefox���ִ������');
                                    // �����ṩ�л������ģʽ��ָ��
                                } else {
                                    var rs = pro_change("Phone");
                                    //xianshidaoshiji();
                                }
                            }

                            function xianshidaoshiji() {
                                document.getElementById("yanzhengmabutton").disabled = true;
                                daojishi = 0;

                                setTimeout("sixth()", 1000);
                            }

                            function sixth() {
                                daojishi = daojishi + 1;

                                if (daojishi < 60) {
                                    var ksq = "��ʣ��" + (60 - daojishi) + "��";

                                    document.getElementById("yanzhengmabutton").value = ksq;
                                    setTimeout("sixth()", 1000);

                                }
                                else {
                                    document.getElementById("yanzhengmabutton").disabled = false;
                                    document.getElementById("yanzhengmabutton").value = "������֤��";
                                    document.getElementById("UcRegBase1_txtQQ").readonly = false;
                                }
                            }
                        </script>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        ����ֻ����ղ������ţ����ϰ�ʱ���µ�010-62132803�ҿͷ����
                    </td>
                </tr>
                <tr align="left" height="42" valign="top">
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnPrev3" runat="server" CssClass="btn btn-secondary btn-action rounded-pill"
                            OnClick="btnPrev_Click" Text="��һ��" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNext3" runat="server" CommandArgument="3" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnNext_Click" Text="��һ��" />
                    </td>
            </table>
        </asp:View>
        <!-- ���Ĳ�����ȫ���� -->
        <asp:View ID="View4" runat="server">
            <h3>
                ����4/4 - ���뱣��</h3>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        ������ʾ���⣺
                    </td>
                    <td align="left" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="35%">
                                    <asp:UpdatePanel ID="UpPWD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtQuestion" runat="server" Width="210px" Visible="false" MaxLength="100"></asp:TextBox>
                                            <asp:DropDownList ID="ddlPassWordQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPassWordQuestion_SelectedIndexChanged"
                                                Width="217px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 10px">
                                    <font color="red">&nbsp;*</font>
                                </td>
                                <td width="65%" align="left">
                                    <span class="font_gray" id="spQuestionTS" runat="server">&nbsp;��ѡ�������õ��������⣬�Ա���������������������ȡ������
                                    </span>
                                </td>
                            </tr>
                        </table>
                        <%--                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            
                        <asp:TextBox ID="txtQuestion" runat="server" MaxLength="40" Visible="false" onblur="if(this.value==''){document.getElementById('spQuestion').innerHTML='������������ʾ����'};" Width="210px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                        <br />
                        <span id="spQuestion" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="right" valign="top">
                        ��������𰸣�
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPassWordAnswer" runat="server" ValidationGroup="baseinfo" Width="210px"
                            MaxLength="100"></asp:TextBox>&nbsp;<font color="red">*</font><asp:RequiredFieldValidator
                                ID="vPasswordanswer" runat="server" ControlToValidate="txtPassWordAnswer" ValidationGroup="baseinfo"
                                SetFocusOnError="True"></asp:RequiredFieldValidator><span class="font_gray">���������������</span><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassWordAnswer"
                            ErrorMessage="����𰸲���Ϊ��"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr height="42" align="left" valign="top">
                    <td>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnPrev4" runat="server" Text="��һ��" CssClass="btn btn-secondary btn-action rounded-pill"
                            OnClick="btnPrev_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSubmit" Visible="false" runat="server" Text="���ע��" CssClass="btn btn-primary btn-action rounded-pill"
                            OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/Web/U_btn1.jpg" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false" />
    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="1" bgcolor="#ffccff">
            </td>
        </tr>
    </table>
    <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" valign="middle" align="left" class="title1">
                �û�ע��Э��
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
                <asp:TextBox ID="RegeditAgreement" runat="server" Height="200px" TextMode="MultiLine"
                    Width="820" ReadOnly="True" BackColor="White" CssClass="xieyi"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="bottom" align="center" style="height: 50px">
                <!-- OnClick="btnSave_Click"-->
                &nbsp; &nbsp;<asp:ImageButton runat="server" Visible="false" ID="btnDisagree" OnClick="btnDisagree_Click"
                    ImageUrl="~/Images/Web/U_btn2.jpg" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pgaoji" runat="server" Width="100%" Visible="False">
    <table width="962" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin: 13px;
        border: 1px solid #D0E3F9;">
        <tr>
            <td align="center">
                <table width="70%" border="0" cellpadding="2" cellspacing="0" class="MT5">
                    <tr>
                        <td width="7%">
                            <img src="/Images/Web/user_go_li.gif" width="33" height="33" />
                        </td>
                        <td width="93%" class="user_go_zi16">
                            <asp:Label ID="lblNmaeT" runat="server"></asp:Label>
                            ע��ɹ��������ѵ�¼��վ��
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="8%">
                            &nbsp;
                        </td>
                        <td width="92%" align="left">
                            �����û�����<asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            ���ĵ������䣺<asp:Label ID="lblUserEmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            ����Ϊ�߼���Ա���������ܸ����ƴ������ǿ�ҽ���������Ϊ�߼���Ա��
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="15">
                    <tr>
                        <td width="52%">
                            &nbsp;<asp:ImageButton ID="imbbtn" runat="server" ImageUrl="~/Images/Web/user_go_btn.gif"
                                OnClick="imbbtn_Click" />
                        </td>
                        <td width="48%">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="7%">
                        </td>
                        <td width="93%" align="left">
                            <strong>��ʱ�������߼���Ա��ҳ����ת����</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/UserCenter/User_Center.aspx">�����Ա����</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                href="/">�ص�ƴ����ҳ</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://bbs.pinble.com/">ȥƴ����̳</a>
                        </td>
                    </tr>
                </table>
                <table width="70%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="7%">
                        </td>
                        <td width="93%" align="left">
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Panel>
<%--<asp:Panel ID="p5" runat="server" Width="100%" Visible="False">
    <table style="width: 100%">
        <tr>
            <td style="height: 21px">
                <table cellpadding="3" cellspacing="1" align="center" class="tableborder1">
                    <tr>
                        <td height="24">
                            ע��ɹ���ƴ�����߲���ͨ��� ��ӭ���ĵ���!</td>
                    </tr>
                    <tr>
                        <td style="height: 24px">
                            <div>
                                <span id="spTime">3</span><a href="javascript:countDown(3)"></a>����Զ���ת��
                            </div>
                            <div>
                                ��û����ת,���ֶ����<a href="Default.aspx">��ҳ</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>

<script type="text/javascript">
function countDown(secs){ 
 var sp_Time = document.getElementById("spTime");
 sp_Time.innerText=secs; 
    if(--secs>0){
     setTimeout("countDown("+secs+")",3000); 
     }
     else
     {
     location.href="Default.aspx"
     }
 } 
</script>
--%>
