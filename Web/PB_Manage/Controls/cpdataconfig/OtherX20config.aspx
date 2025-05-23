<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OtherX20config.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.cpdataconfig.OtherX20config" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/StyleCss.css" />

    <script type="text/javascript" language="javascript" src="../../JScript/javascript.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div style="width: 100%;">
              <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                align='center'>
                <tr bgcolor="#F3F3F3">
                    <td height='22' align='center'>
                            <asp:Label ID="lblLinkAdd" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="Right_bg2">
                            <table width="95%" border="0" cellspacing="2" cellpadding="0" align="center">
                                <tr>
                                   
                                    <td align="left">
                                        <asp:Button ID="btnDivAdd" runat="server" Text="添加新的开奖信息" OnClick="btnDivAdd_Click" />
                                    </td>                                    
                                    <td align="right">
                                        <asp:Button ID="btnDel" runat="server" Text="删除最近开奖日期" OnClick="btnDel_Click"  OnClientClick="return confirm('你确定要删除吗?');"/>
                                    </td>
                                     <td align="right">
                                        <%--<asp:Button ID="btnList" runat="server" Text="返回" OnClick="btnList_Click" />--%>
                                        期号：<asp:TextBox ID="txt_Condition" runat="server" Width="100px"></asp:TextBox>&nbsp;

                                        <asp:Button ID="Search" runat="server" Text="搜索" onclick="Search_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div runat="server" id="divList" visible="true" style="position:absolute; width:100%; height:398px; overflow-y:scroll">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr bgcolor="#F3F3F3">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="100%"  CssClass="GridView_Table"
                                    CellPadding="0">
                                    <Columns>
                                        <asp:TemplateField HeaderText="开奖日期" SortExpression="date">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                 <%# Eval("date", "{0:yyyy-MM-dd}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开奖期号" SortExpression="issue">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("issue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开奖号码" SortExpression="redcode">
                                            <ItemStyle Width="17%" />
                                            <ItemTemplate>
                                                <font color="#FF0000">
                                                    <%#Method.FormartCode(Eval("code").ToString()," ")%>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="最近修改时间" SortExpression="LastModifyTime">
                                            <ItemStyle Width="16%" />
                                            <ItemTemplate>
                                                <%# Eval("LastModifyTime", "{0:yyyy-MM-dd HH:mm:ss}")%> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员IP" SortExpression="OpIp">
                                            <ItemStyle Width="13%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("OpIp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员" SortExpression="OpName">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("OpName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnUpdate" runat="server" OnClientClick="changeTab(1)" CommandArgument='<%# Eval("issue") %>'
                                                    OnCommand="LinkButton1_Command">修改</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="GridView_Row" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divAdd" runat="server" visible="false">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr>
                            <td bgcolor="#F3F3F3">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="Right_bg2" id="jnkc" align="center">

                                            <script type="text/javascript">                                                setInterval("jnkc.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
                                            </script>

                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold" width="25%">
                                            开奖期号:
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="txtIssue" MaxLength="8" runat="server"></asp:TextBox>
                                            （<asp:Label ID="lblIssue" runat="server"></asp:Label>）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖日期:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" MaxLength="19"></asp:TextBox>（格式：2004-10-8
                                            ）
                                        </td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖号码:</td>
                                           <td class="forumRow">
                                        <asp:TextBox ID="txtCode1" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode2")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode2" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode3")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode3" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode4")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode4" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode5")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode5" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode6")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode6" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode7")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode7" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode8")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode8" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode9")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode9" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode10")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode10" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode11")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode11" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode12")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode12" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode13")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode13" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode14")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode14" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode15")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode15" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode16")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode16" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode17")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode17" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode18")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode18" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode19")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode19" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"txtCode20")' onfocus="javascript:this.select()" ></asp:TextBox>
                                        <asp:TextBox ID="txtCode20" runat="server" Width="26px" MaxLength="2" onkeyup='CheckCode(this,"btnSave")' onfocus="javascript:this.select()" ></asp:TextBox>
                                           <asp:Label ID="lblFW" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td>
                                        </td>
                                        <td class="forumRow">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSave" runat="server" Text="添加" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnClear" runat="server" Text="返回" OnClick="btnClear_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="forumRow" colspan="2">
                                            临时剪贴编辑器（<font color="#ff0000">注意：本窗口的内容仅做临时剪贴使用，信息不保存）</font></td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="forumRow" colspan="2">
                                            <asp:TextBox ID="TextBox2" runat="server" Height="260px" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            <asp:RangeValidator ID="rvd1" runat="server" ControlToValidate="txtCode1" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="validatorCalloutHighlight"
                TargetControlID="rvd1">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd2" runat="server" ControlToValidate="txtCode2" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="validatorCalloutHighlight"
                TargetControlID="rvd2">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd3" runat="server" ControlToValidate="txtCode3" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rvd3">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd4" runat="server" ControlToValidate="txtCode4" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rvd4">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd5" runat="server" ControlToValidate="txtCode5" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="rvd5">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd6" runat="server" ControlToValidate="txtCode6" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rvd6">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd7" runat="server" ControlToValidate="txtCode7" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rvd7">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd8" runat="server" ControlToValidate="txtCode8" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="rvd8">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd9" runat="server" ControlToValidate="txtCode9" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="rvd9">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd10" runat="server" ControlToValidate="txtCode10" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="rvd10">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd11" runat="server" ControlToValidate="txtCode11" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="rvd11">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd12" runat="server" ControlToValidate="txtCode12" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="rvd12">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd13" runat="server" ControlToValidate="txtCode13" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="rvd13">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd14" runat="server" ControlToValidate="txtCode14" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="rvd14">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd15" runat="server" ControlToValidate="txtCode15" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="rvd15">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd16" runat="server" ControlToValidate="txtCode16" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="rvd16">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd17" runat="server" ControlToValidate="txtCode17" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" TargetControlID="rvd17">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd18" runat="server" ControlToValidate="txtCode18" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" TargetControlID="rvd18">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd19" runat="server" ControlToValidate="txtCode19" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" TargetControlID="rvd19">
            </cc1:ValidatorCalloutExtender>
            <asp:RangeValidator ID="rvd20" runat="server" ControlToValidate="txtCode20" MaximumValue="100"
                MinimumValue="01" Type="Integer" ErrorMessage="" Display="None"></asp:RangeValidator>
            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" TargetControlID="rvd20">
            </cc1:ValidatorCalloutExtender>
            <br />
            <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtCode1"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb2" runat="server" TargetControlID="txtCode2"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb3" runat="server" TargetControlID="txtCode3"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb4" runat="server" TargetControlID="txtCode4"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb5" runat="server" TargetControlID="txtCode5"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb6" runat="server" TargetControlID="txtCode6"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb7" runat="server" TargetControlID="txtCode7"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb8" runat="server" TargetControlID="txtCode8"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb9" runat="server" TargetControlID="txtCode9"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb10" runat="server" TargetControlID="txtCode10"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb11" runat="server" TargetControlID="txtCode11"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb12" runat="server" TargetControlID="txtCode12"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb13" runat="server" TargetControlID="txtCode13"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb14" runat="server" TargetControlID="txtCode14"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb15" runat="server" TargetControlID="txtCode15"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb16" runat="server" TargetControlID="txtCode16"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb17" runat="server" TargetControlID="txtCode17"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb18" runat="server" TargetControlID="txtCode18"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb19" runat="server" TargetControlID="txtCode19"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="ftb20" runat="server" TargetControlID="txtCode20"
                FilterType="Numbers">
            </cc1:FilteredTextBoxExtender>
             
            </div>
            <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>

