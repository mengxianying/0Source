<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcShuang.ascx.cs" Inherits="Pbzx.Web.Contorls.UcShuang" %>
<%@ Register Src="TempletShuangHaoIssue.ascx" TagName="TempletShuangHaoIssue" TagPrefix="uc1" %>
<%@ Register Src="TempletShuangHaoCode.ascx" TagName="TempletShuangHaoCode" TagPrefix="uc2" %>
<%@ Register Src="TempletShuangHaoTCode.ascx" TagName="TempletShuangHaoTCode" TagPrefix="uc3" %>
<table border="0" cellpadding="0" cellspacing="0" >
    <tr>
        <td style="height: 19px;" id="tdIssue" runat="server">
            <uc1:TempletShuangHaoIssue ID="TempletShuangHaoIssue1"  runat="server" AddCode="true"
                AddXuHao="true" />
        </td>
        <td style="height: 19px;" id="tdCode" runat="server" align="left">
            <uc2:TempletShuangHaoCode ID="TempletShuangHaoCode1" runat="server" WeiShu="3" />
        </td>
        <td style="height: 19px;" ID="Hua" runat="server">
            <uc3:TempletShuangHaoTCode ID="TempletShuangHaoTCode1" runat="server" WeiShu="2" />
        </td>
    </tr>
</table>
