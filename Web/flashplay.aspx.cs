using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web
{
    public partial class flashplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]) && !string.IsNullOrEmpty(Request["type"]))
                {
                    try
                    {
                        string id = Input.FilterAll(Server.UrlDecode(Request["id"]));
                        string strType = Input.FilterAll(Server.UrlDecode(Request["type"]));
                        string strTitle = Input.FilterAll(Server.UrlDecode(Request["title"]));
                        string strpg = Input.FilterAll(Server.UrlDecode(Request["pg"]));
                        string strFlashurl = Input.FilterAll(Server.UrlDecode(Request["Flashurl"]));

                        if (strType == "source")
                        {
                            Pbzx.BLL.PBnet_Soft MyBLL = new Pbzx.BLL.PBnet_Soft();
                            Pbzx.Model.PBnet_Soft MyModel = MyBLL.GetModel(Convert.ToInt32(id));
                            if (MyModel == null)
                            {
                                Response.Redirect("PageNoFound.htm");
                                return;
                            }
                            //绑定视频列表
                            if (MyModel.Video.Trim() != "" && MyModel.Video != null)
                            {
                                MyModel.Video = MyModel.Video.Replace("\r\n", "");
                                if (MyModel.Video.Trim().Substring(MyModel.Video.Length - 2) == "||")
                                {
                                    MyModel.Video = MyModel.Video.Trim().Substring(0, MyModel.Video.Length - 2);
                                }
                                string[] spts = MyModel.Video.Replace("\r\n", "").Replace("||", "^").Split('^');


                                StringBuilder but = new StringBuilder();
                                but.Append("<div class='content MT' id='Div1'>");
                                but.Append(" <table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                                but.Append("<tr>");

                                but.Append("<td width='35%' height='26' background='Images/Web/R_lbg2.jpg' class='R_r2_title'>");
                                but.Append(" <strong><span style='font-size: 10pt'>在线播放列表</span> </strong>");
                                but.Append("</td>");

                                but.Append("<td width='65%' background='Images/Web/R_lbg2.jpg'>");

                                but.Append(" <span style='font-size: 10pt;color: #009900;'  align='left'> 当前播放：</span>");
                                if (strTitle != null)
                                {
                                    but.Append(strTitle);
                                }
                                else
                                {
                                    but.Append(spts[0].Split('|')[0]);
                                }

                                but.Append(" </td>");

                                but.Append("</tr>");
                                but.Append("</table>");

                                but.Append("<table width='100%' border='0' align='center' cellpadding='12' cellspacing='0' bgcolor='#FFFFFF'>");

                                but.Append(" <tr>");
                                but.Append("<td align='left'>");

                                for (int i = 0; i < spts.Length; i++)
                                {

                                    string[] spt = spts[i].Split('|');
                                    if (spt[0].Length > 25)
                                    {
                                        but.Append("<a href='flashplay.aspx?ID=" + id + "&pg=" + i + "&flashurl=" + spt[1] + "&type=source&title=" + spt[0] + "' title='" + spt[0] + "'>" + spt[0].Substring(0, 25) + "</a><br/><br/>");
                                    }
                                    else
                                    {
                                        but.Append("<a href='flashplay.aspx?ID=" + id + "&pg=" + i + "&flashurl=" + spt[1] + "&type=source&title=" + spt[0] + "' title='" + spt[0] + "'>" + spt[0] + "</a><br/><br/>");
                                    }
                                }

                                string[] a = null;
                                string[] b = null;
                                string pnumber = "0";
                                ///找到当前页的索引
                                if (strpg != null)
                                {
                                    for (int i = 0; i < spts.Length; i++)
                                    {
                                        string[] spt = spts[i].Split('|');
                                        if (i.ToString() == strpg)
                                        {
                                            if (i > 0)
                                            {
                                                a = spts[i - 1].Split('|');
                                                if (i == spts.Length - 1)
                                                {

                                                }
                                                else
                                                {
                                                    b = spts[i + 1].Split('|');
                                                }
                                            }
                                            else if (i == 0)
                                            {
                                                if (spts.Length > 1)
                                                {
                                                    b = spts[i + 1].Split('|');
                                                }
                                            }
                                            pnumber = i.ToString();
                                        }

                                    }
                                }
                                else
                                {
                                    if (spts.Length > 1)
                                    {
                                        b = spts[1].Split('|');
                                        pnumber = "1";
                                    }
                                }
                                //绑定分页视频
                                bindFY(a, b, pnumber);



                                but.Append(" </td>");

                                but.Append("<td align='center'>");


                                #region 视频绑定
                                if (!string.IsNullOrEmpty(strFlashurl))
                                {
                                    if (strFlashurl.Substring(strFlashurl.Length - 3) == "swf")
                                    {
                                        //swf,flw
                                        but.Append("<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' width='558px' height='450px'");
                                        but.Append("class='' type='application/x-shockwave-flash'>");
                                        but.Append("  <param name='movie' value='qplayer.swf' />");
                                        but.Append("<param name='quality' value='High' />");
                                        but.Append("<param name='FlashVars' value='isShowRelatedVideo=false&showAd=0&show_pre=1&show_next=1&AutoPlay=0&IsAutoPlay=0&isDebug=false&UserID=&winType=interior&playMovie=true&MMControl=false&MMout=false&RecordCode=1001,1002,1003,1004,1005,1006,2001,3001,3002,3003,3004,3005,3007,3008,9999' />");




                                        if (!string.IsNullOrEmpty(strFlashurl))
                                        {
                                            but.Append("  <param name='src' value='" + strFlashurl + "' /> </object>");

                                        }
                                        else
                                        {
                                            string[] spt = spts[0].Split('|');
                                            but.Append("  <param name='src' value='" + spt[1] + "' /> </object>");
                                        }
                                    }
                                    else
                                    {
                                        //  but.Append(strFlashurl);

                                        BindPlary(but, strFlashurl);
                                    }
                                }
                                else
                                {
                                    //当为第一次进来
                                    string[] spt = spts[0].Split('|');
                                    if (spt[1].Substring(spt[1].Length - 3) == "swf")
                                    {
                                        //swf,flw
                                        but.Append("<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' width='558px' height='450px'");
                                        but.Append("class='' type='application/x-shockwave-flash'>");
                                        but.Append("  <param name='movie' value='qplayer.swf' />");
                                        but.Append("<param name='quality' value='High' />");
                                        but.Append("<param name='FlashVars' value='isShowRelatedVideo=false&showAd=0&show_pre=1&show_next=1&AutoPlay=0&IsAutoPlay=0&isDebug=false&UserID=&winType=interior&playMovie=true&MMControl=false&MMout=false&RecordCode=1001,1002,1003,1004,1005,1006,2001,3001,3002,3003,3004,3005,3007,3008,9999' />");
                                        but.Append("  <param name='src' value='" + spt[1] + "' /> </object>");

                                    }
                                    else
                                    {
                                        // but.Append(spt[1]);
                                        BindPlary(but, spt[1]);

                                    }

                                }


                                #endregion
                                but.Append("</p><font align='center'style='color:red;'>提示：双击录像全屏观看</font>");

                                but.Append("</td>");
                                but.Append(" </tr>");

                                but.Append("  </table>");
                                but.Append(" </div>");

                                lxlb.InnerHtml = but.ToString();
                            }
                        }
                        else
                        {
                            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
                            Pbzx.Model.PBnet_Product MyModel = MyBLL.GetModel(Convert.ToInt32(id));
                            if (MyModel == null)
                            {
                                Response.Redirect("PageNoFound.htm");
                                return;
                            }
                            //绑定视频列表
                            if (MyModel.Video.Trim() != "" && MyModel.Video != null)
                            {
                                MyModel.Video = MyModel.Video.Replace("\r\n", "");
                                if (MyModel.Video.Trim().Substring(MyModel.Video.Length - 2) == "||")
                                {
                                    MyModel.Video = MyModel.Video.Trim().Substring(0, MyModel.Video.Length - 2);
                                }
                                string[] spts = MyModel.Video.Replace("\r\n", "").Replace("||", "^").Split('^');

                                StringBuilder but = new StringBuilder();
                                but.Append("<div class='content MT' id='Div1'>");
                                but.Append(" <table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                                but.Append("<tr>");
                                but.Append("<td width='35%' height='26' background='Images/Web/R_lbg2.jpg' class='R_r2_title'>");
                                but.Append(" <strong><span style='font-size: 10pt'>在线播放列表</span> </strong>");
                                but.Append("</td>");
                                but.Append("<td width='65%' background='Images/Web/R_lbg2.jpg'>");

                                but.Append(" <span style='font-size: 10pt;color: #009900;'> 当前播放：</span>");
                                if (strTitle != null)
                                {
                                    but.Append(strTitle);
                                }
                                else
                                {
                                    but.Append(spts[0].Split('|')[0]);
                                }

                                but.Append(" </td>");
                                but.Append("</tr>");
                                but.Append("</table>");
                                but.Append("<table width='100%' border='0' align='center' cellpadding='12' cellspacing='0' bgcolor='#FFFFFF'>");
                                but.Append(" <tr>");
                                but.Append("<td align='left'>");


                                for (int i = 0; i < spts.Length; i++)
                                {

                                    string[] spt = spts[i].Split('|');
                                    if (spt.Length > 0)
                                    {
                                        if (spt[0].Length > 25)
                                        {
                                            but.Append("<a href='flashplay.aspx?ID=" + id + "&flashurl=" + spt[1] + "&type=soft&title=" + spt[0] + "' title='" + spt[0] + "'>" + spt[0].Substring(0, 25) + "</a><br/><br/>");
                                        }
                                        else
                                        {
                                            but.Append("<a href='flashplay.aspx?ID=" + id + "&flashurl=" + spt[1] + "&type=soft&title=" + spt[0] + "' title='" + spt[0] + "'>" + spt[0] + "</a><br/><br/>");
                                        }
                                    }


                                }
                                string[] a = null;
                                string[] b = null;
                                string pnumber = "0";
                                ///找到当前页的索引
                                if (strpg != null)
                                {
                                    for (int i = 0; i < spts.Length; i++)
                                    {
                                        string[] spt = spts[i].Split('|');
                                        if (i.ToString() == strpg)
                                        {
                                            if (i > 0)
                                            {
                                                a = spts[i - 1].Split('|');
                                                if (i == spts.Length - 1)
                                                {

                                                }
                                                else
                                                {
                                                    b = spts[i + 1].Split('|');
                                                }
                                            }
                                            else if (i == 0)
                                            {
                                                if (spts.Length > 1)
                                                {
                                                    b = spts[i + 1].Split('|');
                                                }
                                            }
                                            pnumber = i.ToString();
                                        }

                                    }
                                }
                                else
                                {
                                    if (spts.Length > 1)
                                    {
                                        b = spts[1].Split('|');
                                        pnumber = "1";
                                    }
                                }
                                //绑定分页视频
                                bindFY(a, b, pnumber);

                                but.Append(" </td>");
                                but.Append("<td align='center'>");

                                if (!string.IsNullOrEmpty(strFlashurl))
                                {
                                    if (strFlashurl.Substring(strFlashurl.Length - 3) == "swf")
                                    {
                                        //swf,flw
                                        but.Append("<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' width='558px' height='450px'");
                                        but.Append("class='' type='application/x-shockwave-flash'>");
                                        but.Append("  <param name='movie' value='qplayer.swf' />");
                                        but.Append("<param name='quality' value='High' />");
                                        but.Append("<param name='FlashVars' value='isShowRelatedVideo=false&showAd=0&show_pre=1&show_next=1&AutoPlay=0&IsAutoPlay=0&isDebug=false&UserID=&winType=interior&playMovie=true&MMControl=false&MMout=false&RecordCode=1001,1002,1003,1004,1005,1006,2001,3001,3002,3003,3004,3005,3007,3008,9999' />");




                                        if (!string.IsNullOrEmpty(strFlashurl))
                                        {
                                            but.Append("  <param name='src' value='" + strFlashurl + "' /> </object>");

                                        }
                                        else
                                        {
                                            string[] spt = spts[0].Split('|');
                                            but.Append("  <param name='src' value='" + spt[1] + "' /> </object>");
                                        }
                                    }
                                    else
                                    {
                                        //  but.Append(strFlashurl);
                                        BindPlary(but, strFlashurl);
                                    }
                                }
                                else
                                {
                                    //当为第一次进来
                                    string[] spt = spts[0].Split('|');
                                    if (spt[1].Substring(spt[1].Length - 3) == "swf")
                                    {
                                        //swf,flw
                                        but.Append("<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' width='558px' height='450px'");
                                        but.Append("class='' type='application/x-shockwave-flash'>");
                                        but.Append("  <param name='movie' value='qplayer.swf' />");
                                        but.Append("<param name='quality' value='High' />");
                                        but.Append("<param name='FlashVars' value='isShowRelatedVideo=false&showAd=0&show_pre=1&show_next=1&AutoPlay=0&IsAutoPlay=0&isDebug=false&UserID=&winType=interior&playMovie=true&MMControl=false&MMout=false&RecordCode=1001,1002,1003,1004,1005,1006,2001,3001,3002,3003,3004,3005,3007,3008,9999' />");
                                        but.Append("  <param name='src' value='" + spt[1] + "' /> </object>");

                                    }
                                    else
                                    {
                                        //  but.Append(spt[1]);

                                        BindPlary(but, spt);
                                    }

                                }


                                but.Append("</p><font align='center'style='color:red;'>提示：双击录像全屏观看</font>");


                                but.Append("</td>");

                                but.Append(" </tr>");

                                //but.Append("<tr>");

                                //but.Append("<td>");
                                //but.Append("</td>");



                                //but.Append("<td align='center'style='color:red;'>");
                                //but.Append("提示：双击录像全屏观看");
                                //but.Append("</td>");

                                //but.Append(" </tr>");
                                but.Append("  </table>");
                                but.Append(" </div>");

                                lxlb.InnerHtml = but.ToString();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("PageNoFound.htm");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("PageNoFound.htm");
                    return;
                }
            }
        }

        private static void BindPlary(StringBuilder but, string[] spt)
        {
            but.Append("<object type='application/x-shockwave-flash' data='PbPlayer.swf' width='500' height='400' id='PbPlayer'>");
            but.Append("<param name='movie' value='PbPlayer.swf'/> ");
            but.Append("<param name='allowFullScreen' value='true' />");

            but.Append("<param name='IsAutoPlay' value='0' />");
            but.Append("<param name='AutoPlay' value='0' />");
            but.Append("<param name='Play' value='0' />");



            but.Append("<param name='FlashVars' value='xml=");
            but.Append("<vcastr>");
            but.Append("<channel>");
            but.Append("<item>");
            but.Append("<source>");
            but.Append(spt[1]);
            but.Append("</source>");
            but.Append("<duration></duration>");
            but.Append("<title>pinble.com</title>");
            but.Append("</item>");
            but.Append("</channel>");
            but.Append("<config>");
            but.Append(" <buffertime>5</buffertime>");
            but.Append("<contralpanelalpha>0.75</contralpanelalpha>");
            but.Append("<controlpanelbgcolor>0xff6600</controlpanelbgcolor>");
            but.Append("<controlpanelbtncolor>0xffffff</controlpanelbtncolor>");
            but.Append("<contralpanelbtnglowcolro>0xffff00</contralpanelbtnglowcolro>");
            but.Append("<controlpanelmode>float</controlpanelmode>");
            but.Append(" <defautvolume>0.8</defautvolume>");
            but.Append("<IsAutoPlay>0</IsAutoPlay>");
            but.Append("<AutoPlay>0</AutoPlay>");
            but.Append("<Play>0</Play>");
            but.Append("<isloadbegin>false</isloadbegin>");
            but.Append("<isshowabout>false</isshowabout>");
            but.Append("<scalemode>noScale</scalemode>");
            but.Append("</config>");
            but.Append("<plugIns></plugIns>");
            but.Append("</vcastr> '/>");
            but.Append("</object>");


        }
        private static void BindPlary(StringBuilder but, string spt)
        {
            but.Append("<object type='application/x-shockwave-flash' data='PbPlayer.swf' width='500' height='400' id='PbPlayer'>");
            but.Append("<param name='movie' value='PbPlayer.swf'/> ");
            but.Append("<param name='allowFullScreen' value='true' />");

            but.Append("<param name='IsAutoPlay' value='0' />");
            but.Append("<param name='AutoPlay' value='0' />");
            but.Append("<param name='Play' value='0' />");

            but.Append("<param name='FlashVars' value='xml=");
            but.Append("<vcastr>");
            but.Append("<channel>");
            but.Append("<item>");
            but.Append("<source>");
            but.Append(spt);
            but.Append("</source>");
            but.Append("<duration></duration>");
            but.Append("<title>pinble.com</title>");
            but.Append("</item>");
            but.Append("</channel>");
            but.Append("<config>");
            but.Append(" <buffertime>5</buffertime>");
            but.Append("<contralpanelalpha>0.75</contralpanelalpha>");
            but.Append("<controlpanelbgcolor>0xff6600</controlpanelbgcolor>");
            but.Append("<controlpanelbtncolor>0xffffff</controlpanelbtncolor>");
            but.Append("<contralpanelbtnglowcolro>0xffff00</contralpanelbtnglowcolro>");
            but.Append("<controlpanelmode>float</controlpanelmode>");
            but.Append(" <defautvolume>0.8</defautvolume>");
            but.Append("<IsAutoPlay>0</IsAutoPlay>");
            but.Append("<AutoPlay>0</AutoPlay>");
            but.Append("<Play>0</Play>");
            but.Append("<isloadbegin>false</isloadbegin>");
            but.Append("<isshowabout>false</isshowabout>");
            but.Append("<scalemode>noScale</scalemode>");
            but.Append("</config>");
            but.Append("<plugIns></plugIns>");
            but.Append("</vcastr> '/>");
            but.Append("</object>");
        }

        public void bindFY(string[] a, string[] b, string pnumber)
        {

            StringBuilder but = new StringBuilder();

            string id = Input.FilterAll(Request["id"]);
            string strType = Input.FilterAll(Request["type"]);
            but.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            but.Append(" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            but.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;上一个： ");
            if (a != null)
            {
                but.Append("<a href='flashplay.aspx?ID=" + id + "&pg=" + (Convert.ToInt32(pnumber) - 1) + "&flashurl=" + a[1] + "&type=" + strType + "&title=" + a[0] + "' title='" + a[0] + "'>" + a[0] + "</a>");
            }
            else
            {
                but.Append("没有了");
            }
            but.Append("  <br /> <br />");



            but.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            but.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            but.Append(" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;下一个：");
            if (b != null)
            {
                but.Append("<a href='flashplay.aspx?ID=" + id + "&pg=" + (Convert.ToInt32(pnumber) + 1) + "&flashurl=" + b[1] + "&type=" + strType + "&title=" + b[0] + "' title='" + b[0] + "'>" + b[0] + "</a>");
            }
            else
            {
                but.Append("没有了");
            }
            //  fyeid.InnerHtml = but.ToString();

        }
    }
}
