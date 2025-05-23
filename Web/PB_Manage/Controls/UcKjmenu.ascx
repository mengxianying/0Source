<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcKjmenu.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcKjmenu" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Pbzx.Common" %>
    <link type="text/css" rel="stylesheet" href="../stylecss/Admin-darkgreen.css" /><%--stylecss/Admin-darkgreen.css--%>

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>
    
     <table width="98%" align="center" cellpadding="2" cellspacing="1" style="border: 1 solid #808080">
                <tr>
                    <th height="25px">
                        <div style="width: 460px; height: 6px; float: left; margin-top: 0px; margin-bottom: 0px;
                            text-align: right">
                            <a href="../KJInfo_Manage.aspx"><font color="">管理首页</font></a> |<font color=""><asp:LinkButton
                                ID="lbtnUpdateIndex" runat="server">更新首页数据</asp:LinkButton></font></div>
                        <div id="jnkcsh" style="width: 250px; height: 6px; float: right; margin-top: 0px;
                            margin-bottom: 0px;">
                        </div>

                        <script type="text/javascript">setInterval("jnkcsh.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
                        </script>

                    </th>
                </tr>
                <tr>
                    <td valign="top" class="forumRow">
                        <asp:Repeater ID="rptCpBigSort" runat="server" OnItemCreated="rptCpBigSort_ItemCreated">
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 10%" align="left">
                                            <asp:Label ID="lblClass" runat="server" Text='<%# Eval("NvarClass") %>'></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td style="width: 90%">
                                            <% 
                               Pbzx.BLL.PBnet_LotteryMenu lotteryBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                               DataSet ds = lotteryBLL.GetList(" NvarClass='" + Eval("NvarClass") + "' order by NvarOrderId ");
                               CpSort mycpsort = new CpSort();
                               foreach (DataRow row in ds.Tables[0].Rows)
                               {
                                   string s_font1 = "";
                                   string s_font2 = "";
                                   string s_lottdate = "";
                                   string app_name = row["NvarApp_name"].ToString();
                                   if (string.IsNullOrEmpty(app_name))
                                   {
                                       app_name = "";
                                   }
                                   string lott_date = row["NvarLott_date"].ToString();
                                   if (string.IsNullOrEmpty(lott_date))
                                   {
                                       lott_date = "";
                                   }


                                   if (app_name.Length != 0 && string.IsNullOrEmpty(mycpsort[app_name].value))
                                   {
                                       s_font1 = "<font color='#009900'>";
                                       s_font2 = "</font>";
                                   }
                                   else if (app_name == "FC3D")
                                   {
                                       DateTime dtNow = DateTime.Now;
                                       DateTime dt3DTest = DateTime.Parse(mycpsort["FC_3DTest"].value);
                                       DateTime dt3D = DateTime.Parse(mycpsort["FC3D"].value);
                                       DateTime dt3DTestVerify = DateTime.Parse(mycpsort["FC_3DTestVerify"].value);
                                       DateTime dt3DMoney = DateTime.Parse(mycpsort["FC_3DMoney"].value);
                                       TimeSpan ts3DTest = dtNow - dt3DTest;
                                       TimeSpan ts3D = dtNow - dt3D;
                                       TimeSpan ts3DTestVerify = dtNow - dt3DTestVerify;
                                       TimeSpan ts3DMoney = dtNow - dt3DMoney;
                                       if ((ts3DTest.Hours > 22 && dtNow.Hour == 18 && dtNow.Minute >= 24) || (ts3D.Hours >= 2 && dtNow.Hour == 20 && dtNow.Minute >= 26))
                                       {
                                           s_font1 = "<font color='#ff0000'>";
                                           s_font2 = "</font>";
                                       }
                                       else if ((ts3DTestVerify.Hours > 22 && dtNow.Hour == 18 && dtNow.Minute >= 24) || (ts3DMoney.Hours > 23 && dtNow.Hour >= 21 && dtNow.Minute >= 25))
                                       {
                                           s_font1 = "<font color='#9900ff'>";
                                           s_font2 = "</font>";
                                       }
                                       else if ((ts3DTestVerify.Hours <= 1 && dtNow.Hour == 18 && dtNow.Minute >= 24) || (ts3D.Hours <= 1 && dtNow.Hour == 20 && dtNow.Minute >= 32))
                                       {
                                           s_font1 = "<font color='#0000ff'>";
                                           s_font2 = "</font>";
                                       }
                                   }
                                   else if (app_name.Length != 0 && app_name != "" && mycpsort[app_name].value != "")
                                   {

                                       string s_date = lott_date.Substring(lott_date.Length - 1);
                                       int s_len = lott_date.Length;
                                       lott_date = lott_date.Substring(0, lott_date.Length - 1);
                                       DateTime dtNow = DateTime.Now;
                                       DateTime dtApp = DateTime.Parse(mycpsort[app_name].value);
                                       DateTime dtSSC_JiangX = DateTime.Parse(mycpsort["FCSSC_JiangX"].value);
                                       TimeSpan tsApp = dtNow - dtApp;
                                       TimeSpan tsSSC_JiangX = dtNow - dtSSC_JiangX;
                                Response.Write(lott_date);
                                Response.End();
                                break;
                                       if (s_date == "D" && lott_date == "0")
                                       {
                                           if (tsApp.Hours > 23)
                                           {
                                               s_font1 = "<font color='#ff0000'>";
                                               s_font2 = "</font>";
                                           }
                                           else if (tsApp.Hours <= 1)
                                           {
                                               s_font1 = "<font color='#0000ff'>";
                                               s_font2 = "</font>";
                                           }
                                       }
                                       else if (s_date == "D" && s_len > 1)
                                       {
                                           //  dtApp.DayOfWeek
                                           int s_hour = 0;
                                           int s_number = lott_date.IndexOf(((int)dtApp.DayOfWeek).ToString());
                                           if (s_number == lott_date.Length)
                                           {                                  
                                              s_hour = ((int.Parse(lott_date.Substring(0, 1))) + 7 - int.Parse((lott_date.Substring(lott_date.Length - 1)))) * 24 - 1;
                                           }
                                           else
                                           {
                                               s_hour = ((int.Parse(lott_date.Substring(s_number + 1, 1))) - (int.Parse(lott_date.Substring(s_number, 1)))) * 24 - 1;
                                           }
                                           if (tsApp.Hours > s_hour)
                                           {
                                               s_font1 = "<font color='#ff0000'>";
                                               s_font2 = "</font>";
                                           }
                                           else if (tsApp.Hours <= 1)
                                           {
                                               s_font1 = "<font color='#0000ff'>";
                                               s_font2 = "</font>";
                                           }
                                           s_lottdate = "&lottdate=" + lott_date;
                                       }
                                       else if (s_date == "M" && s_len > 0 && ((app_name != "FCSSC_XinJ" && dtNow.Hour >= 9 && dtNow.Hour < 22) || (app_name == "FCSSC_XinJ" && (dtNow.Hour >= 14 || dtNow.Hour < 2)) || (app_name == "FCSSC_JiangX" && (dtNow.Hour >= 9 && dtNow.Hour < 23))))
                                       {
                                           if ((app_name != "FCSSC_JiangX" && dtApp.Minute > (int.Parse(lott_date)) * 1.4) || (app_name == "FCSSC_JiangX" && tsSSC_JiangX.Hours - dtNow.Hour >= 6))
                                           {
                                               s_font1 = "<font color='#ff0000'>";
                                               s_font2 = "</font>";
                                           }
                                           else if (tsApp.Hours <= 1)
                                           {
                                               s_font1 = "<font color='#0000ff'>";
                                               s_font2 = "</font>";
                                           }
                                       }

                                   } %>                                                                        
                                            <a href="?cpid=<%=row["IntCase"]%>&cityName=<%=row["NvarName"]%><%=s_lottdate%>">
                                                <%=s_font1%>
                                                <%=row["NvarName"]%>
                                                <%=s_font2%>
                                            </a>|
                                            <% } %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>