<%@ Page Language="C#" AutoEventWireup="true" Codebehind="School.aspx.cs" Inherits="Pbzx.Web.School" %>

<%@ Register Src="../Contorls/SchoolOneTitleByType.ascx" TagName="SchoolOneTitleByType"
    TagPrefix="uc8" %>
<%@ Register Src="../Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc7" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc6" %>
<%@ Register Src="../Contorls/SoftTitle_school.ascx" TagName="SoftTitle_school" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/SourceTitle_school.ascx" TagName="SourceTitle_school"
    TagPrefix="uc5" %>
<%@ Register Src="../Contorls/UcSchol_l.ascx" TagName="UcSchol_l" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���ѧԺ_ƴ�����߲���ͨ���</title>
    <meta name="keywords" content="" />
    <meta name="description" content="���ѧԺ" />
    <meta name="robots" content="all" />

    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"> </script>

    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/school.css" rel="stylesheet" type="text/css" />
</head>

<script type="text/javascript">
    /*iframe�������Ӧ*/
    function TuneHeight(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  
        var subWeb=document.frames?document.frames[fm_name].document:frm.contentDocument;  
        if(frm != null && subWeb != null)
        { 
            frm.style.height = subWeb.documentElement.scrollHeight+"px"; 
            //��������Ӧ���,ȥ�����еġ�//��ע�ͼ��� 
         frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
        }  
    }
     function GetThisSrc(temp)
     {
        if(temp == "")
        {
            document.getElementById("FM_Id_school").src = "/School_List.aspx"; 
        }
        else
        {
             document.getElementById("FM_Id_school").src = "/School_List.aspx?type="+temp;
        }
    }
      
</script>

<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <!--���岿��--->
            <div id="news" class="bodyw MT">
                <!--���--->
                <div id="C_lw1">
                    <uc3:UcSchol_l ID="UcSchol_l1" runat="server" SchoolTypeChannel="9" />
                </div>
                <!--�м�--->
                <div id="C_cw1">
                    <iframe src="/School_List.aspx" onload="{TuneHeight('FM_Id_school','FM_Id_school');}"
                        name="FM_Id_school" id="FM_Id_school" width="100%" marginwidth="0" marginheight="0"
                        frameborder="0" scrolling="no"></iframe>
                </div>
                <!--�ұ�--->
                <div id="C_rw1">
                    <div class="C_box  C_r1">
                        <div class="title">
                            <p>
                                <span>&nbsp;���ѧԺ����</span></p>
                        </div>
                        <div class="content">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <input type="text" id="txtShool" onfocus='this.value=""' maxlength="80" value="������ؼ���"
                                                style="width: 150px" class="input_border" />&nbsp;<input type="button" id="btnSearch"
                                                    value="����" onclick="schoolSearch();" class="input_btnsearch" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="C_box  C_r1 MT">
                        <div class="title">
                            <p>
                                <a href="/Soft.aspx" class="more">����>></a><span><a href="/Soft.aspx">&nbsp;�������</a></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:SoftTitle_school ID="SoftTitle_school1" runat="server" TilteLength="17"></uc4:SoftTitle_school>
                            </div>
                        </div>
                    </div>
                    <uc6:UcPicAds ID="UcPicAds1" runat="server" PlaceType="���ѧԺ" />
                    <div class="C_box  C_r1 MT">
                        <div class="title">
                            <p>
                                <a href="/Source.aspx" class="more">����>></a><span><a href="/Source.aspx">&nbsp;������Դ</a></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc5:SourceTitle_school ID="SourceTitle_school1" runat="server" TilteLength="17"></uc5:SourceTitle_school>
                            </div>
                        </div>
                    </div>
                    <uc6:UcPicAds ID="UcPicAdsRight1" runat="server" PlaceType="���ѧԺ��ҳ��һ"></uc6:UcPicAds>
                    <uc7:UcJsADs ID="UcJsADsRight1" runat="server" PlaceType="���ѧԺ��ҳ��һJS"></uc7:UcJsADs>
                    <div class="C_box  C_r1 MT" runat="server" id="divRight1">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight1" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <uc8:SchoolOneTitleByType ID="SchoolOneTitleByTypeRight1" IsHot="0" TitleLength="17"
                                runat="server"></uc8:SchoolOneTitleByType>
                        </div>
                    </div>
                    <uc6:UcPicAds ID="UcPicAdsRight2" runat="server" PlaceType="���ѧԺ��ҳ�Ҷ�"></uc6:UcPicAds>
                    <uc7:UcJsADs ID="UcJsADsRight2" runat="server" PlaceType="���ѧԺ��ҳ�Ҷ�JS"></uc7:UcJsADs>
                    <div class="C_box  C_r1 MT" runat="server" id="divRight2">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight2" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <uc8:SchoolOneTitleByType ID="SchoolOneTitleByTypeRight2" IsHot="0" TitleLength="17"
                                runat="server"></uc8:SchoolOneTitleByType>
                        </div>
                    </div>
                    <uc6:UcPicAds ID="UcPicAdsRight3" runat="server" PlaceType="���ѧԺ��ҳ����"></uc6:UcPicAds>
                    <uc7:UcJsADs ID="UcJsADsRight3" runat="server" PlaceType="���ѧԺ��ҳ����JS"></uc7:UcJsADs>
                    <div class="C_box  C_r1 MT" runat="server" id="divRight3">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight3" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <uc8:SchoolOneTitleByType ID="SchoolOneTitleByTypeRight3" IsHot="0" TitleLength="17"
                                runat="server"></uc8:SchoolOneTitleByType>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
