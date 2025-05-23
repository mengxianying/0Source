<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSchol_list.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcSchol_list" %>
<%@ Register Src="UC_QQ2.ascx" TagName="UC_QQ2" TagPrefix="uc4" %>
<%@ Register Src="SchoolOneTitleByType.ascx" TagName="SchoolOneTitleByType" TagPrefix="uc3" %>
<%@ Register Src="UcSchoolHot.ascx" TagName="UcSchoolHot" TagPrefix="uc2" %>
<%@ Register Src="NewsOneTitleByType.ascx" TagName="NewsOneTitleByType" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc7" %>
<%@ Register Src="../Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc6" %>
<%@ Import Namespace="Pbzx.Common" %>
<div class="C_box  C_l1">
    <div class="title">
        <p>
            <span>&nbsp;软件学院类别</span></p>
    </div>
    <div class="content">
        <div>
            <asp:DataList ID="dtType" runat="server" CaptionAlign="Left" ShowFooter="False" ShowHeader="False"
                Width="95%">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    &nbsp;· <a href="/School_Coutent_List.aspx?NewsType=<%#Input.Encrypt(Eval("IntNewsTypeID").ToString()) %>"
                        target="_self">
                        <%#Eval("VarTypeName")%>
                    </a>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
                <AlternatingItemStyle BackColor="#F0F8FD" />
            </asp:DataList>
        </div>
    </div>
</div>
<div class="C_box  C_l1 MT">
     <div class="title">
        <p>
            <a href='/School_Coutent_List.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'
                class="more">更多>></a><span><a href='/School_Coutent_List.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'>&nbsp;热点推荐</a></span></p>
    </div>
    <div class="content">
        <uc2:UcSchoolHot ID="UcSchoolHot1" runat="server" IsHot="0" TitleLength="13"></uc2:UcSchoolHot>
    </div>
</div>
<uc7:UcPicAds ID="UcPicAdsLeft1" runat="server" PlaceType="软件学院首页左一" />
<uc6:UcJsADs ID="UcJsADsLeft1" runat="server" PlaceType="软件学院首页左一JS" />
<div class="C_box  C_l1 MT" runat="server" id="divLeft1">
    <div class="title">
        <p>
            <span>
                <asp:Label ID="lblLeft1" runat="server" Text=""></asp:Label></span></p>
    </div>
    <div class="content">
        <uc3:SchoolOneTitleByType ID="SchoolOneTitleByTypeLeft1" Count="8" IsHot="0" TitleLength="13"
            runat="server"></uc3:SchoolOneTitleByType>
    </div>
</div>
<uc7:UcPicAds ID="UcPicAdsLeft2" runat="server" PlaceType="软件学院首页左二" />
<uc6:UcJsADs ID="UcJsADsLeft2" runat="server" PlaceType="软件学院首页左二JS" />
<div class="C_box  C_l1 MT" runat="server" id="divLeft2">
    <div class="title">
        <p>
            <span>
                <asp:Label ID="lblLeft2" runat="server" Text=""></asp:Label></span></p>
    </div>
    <div class="content">
        <uc3:SchoolOneTitleByType ID="SchoolOneTitleByTypeLeft2" Count="8" IsHot="0" TitleLength="13"
            runat="server"></uc3:SchoolOneTitleByType>
    </div>
</div>
<uc7:UcPicAds ID="UcPicAdsLeft3" runat="server" PlaceType="软件学院首页左三" />
<uc6:UcJsADs ID="UcJsADsLeft3" runat="server" PlaceType="软件学院首页左三JS" />
<div class="C_box  C_l1 MT" runat="server" id="divLeft3">
    <div class="title">
        <p>
            <span>
                <asp:Label ID="lblLeft3" runat="server" Text=""></asp:Label></span></p>
    </div>
    <div class="content">
        <uc3:SchoolOneTitleByType ID="SchoolOneTitleByTypeLeft3" Count="8" IsHot="0" TitleLength="13"
            runat="server"></uc3:SchoolOneTitleByType>
    </div>
</div>
<!--在线联系--->
<div class="C_l2 MT">
    <div class="title">
        <p>
            <span>在线客服</span></p>
    </div>
    <div class="content">
            <uc4:UC_QQ2 ID="UC_QQ2_1" runat="server" />
    </div>
</div>
