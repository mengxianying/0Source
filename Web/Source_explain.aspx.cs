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
using Pbzx.Common;
using System.Text;

namespace Pbzx.Web
{
    public partial class Source_explain : System.Web.UI.Page
    {
        public int? pb_Hits = 0;
        public string SoftName = "";
        public string SoftVersion = "";
        public string DemoUrl = "";
        public string RegUrl = "";
        public string OperatingSyste = "";
        public string SoftSize = "";
        public string Stars = "";
        public string UpdateTime = "";
        public string SoftIntro = "";
        public string softContent = "";
        public string PicUrl = "";
        public string Down1 = "";
        public string Down2 = "";
        public string Down3 = "";
        public string Down4 = "";
        public string YXSystem = "";
        private string _ClassID;
        public string wtDown = "";
        public string dxDown = "";
        public string Down3a = "";
        public string Down4a = "";
        public string SinaWiki = "";

        public string ClassID
        {

            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(_ClassID));
                }
                else
                {
                    Response.Redirect("PageNoFound.htm");
                    return "---";
                }
            }
            set { _ClassID = value; }
        }

        public string DowloadTips = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    try
                    {
                        string id = Input.FilterAll(Input.Decrypt(Request["id"]));
                        Pbzx.BLL.PBnet_Soft MyBLL = new Pbzx.BLL.PBnet_Soft();
                        Pbzx.Model.PBnet_Soft MyModel = MyBLL.GetModel(Convert.ToInt32(id));
                        if (MyModel == null || MyModel.pb_Passed == false)
                        {
                            Response.Redirect("PageNoFound.htm");
                            return;
                        }
                        wtDown = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "SoftDownLoad.aspx?id=" + id + "&reUrl=1";
                        dxDown = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "SoftDownLoad.aspx?id=" + id + "&reUrl=2";
                        Down3a = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "SoftDownLoad.aspx?id=" + id + "&reUrl=3";

                        Down4a = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "SoftDownLoad.aspx?id=" + id + "&reUrl=4";
                        ShowNews(int.Parse(id));
                        this.Title = SoftName + "_资源下载_拼搏在线彩神通软件";
                        DowloadTips = Pbzx.Common.WebInit.webBaseConfig.DowloadTips;


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
        private void ShowNews(int id)
        {
            Pbzx.BLL.PBnet_Soft MyBLL = new Pbzx.BLL.PBnet_Soft();
            Pbzx.Model.PBnet_Soft MyModel = MyBLL.GetModel(id);

            ////绑定视频列表
            if (MyModel.Video.Trim() != "" && MyModel.Video != null)
            {
                string height = "505";
                if (MyModel.Video.Substring(MyModel.Video.Length - 2) == "||")
                {
                    MyModel.Video = MyModel.Video.Trim().Substring(0, MyModel.Video.Length - 2);
                }
                string[] len = MyModel.Video.Replace("||", "$").Split('$');
                if (len.Length > 15)
                {
                    height = Convert.ToString(Convert.ToInt32(height) + 40 + ((len.Length - 15) * 32));
                }
                framid.Visible = true;
                framid.InnerHtml = " <iframe scrolling='no' frameborder='0' width='758' height='" + height + "' src='flashplay.aspx?id=" + id + "&type=source'></iframe>";
            }

            pb_Hits = MyModel.pb_Hits;

            SoftName = MyModel.PBnet_SoftName;
            SoftVersion = MyModel.PBnet_SoftVersion;
            ClassID = MyModel.pb_ClassID.ToString();
            OperatingSyste = MyModel.pb_OperatingSystem;
            SoftSize = MyModel.PBnet_SoftSize.ToString();
            Stars = MyModel.pb_Stars.ToString();
            UpdateTime = ((DateTime)MyModel.pb_UpdateTime).ToString("yyyy-MM-dd HH:mm:ss");

            SoftIntro = MyModel.PBnet_SoftIntro;
            DemoUrl = MyModel.pb_DemoUrl.ToString();
            RegUrl = MyModel.pb_RegUrl.ToString();
            YXSystem = MyModel.pb_OperatingSystem;
            PicUrl = MyModel.PBnet_SoftPicUrl;
            string tempUrl = WebInit.webBaseConfig.WebUrl;

            //if (PicUrl != null && PicUrl != "" && PicUrl.Trim().Length > 0)
            //{
            //    SinaWiki = "<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + tempUrl.Substring(0, tempUrl.Length - 1) + PicUrl + "','','','utf-8'));\"><img src='/Images/Web/SinaWiki.jpg' border='0' >分享至新浪微博</a> ";
            //}
            //else
            //{
//            SinaWiki = "<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"] + "','','','utf-8'));\"><img src='/Images/Web/SinaWiki.jpg' border='0' >分享至新浪微博</a> ";
            //   }
            Down1 = MyModel.pb_DownloadUrl1.ToString();
            Down2 = MyModel.pb_DownloadUrl2.ToString();
            Down3 = MyModel.pb_DownloadUrl3.ToString();
            Down4 = MyModel.pb_DownloadUrl4.ToString();
            string[] down1SZ = WebFunc.GetDownInfo("2", "1");
            string[] down2SZ = WebFunc.GetDownInfo("2", "2");
            string[] down3SZ = WebFunc.GetDownInfo("2", "3");

            string[] down4SZ = WebFunc.GetDownInfo("2", "4");
            if (down1SZ[2] == "0" && down2SZ[2] == "0" && down3SZ[2] == "0" && down4SZ[2] == "0")
            {
                this.xiazai1.Visible = false;
            }
            else
            {
                xiazai1.Visible = true;
                if (down1SZ[2] == "0")
                {
                    this.tdDown1.Visible = false;
                }
                else
                {
                    this.tdDown1.Visible = true;
                    lblDown1.Text = down1SZ[3];
                }
                if (string.IsNullOrEmpty(Down2) || down2SZ[2] == "0")
                {
                    this.tdDown2.Visible = false;
                }
                else
                {
                    this.tdDown2.Visible = true;
                    lblDown2.Text = down2SZ[3];
                }

                if (string.IsNullOrEmpty(Down3) || down3SZ[2] == "0")
                {
                    this.tdDown3.Visible = false;
                }
                else
                {
                    this.tdDown3.Visible = true;
                    lblDown3.Text = down3SZ[3];
                }

                if (string.IsNullOrEmpty(Down4) || down4SZ[2] == "0")
                {
                    this.tdDown4.Visible = false;
                }
                else
                {
                    this.tdDown4.Visible = true;
                    lblDown4.Text = down4SZ[3];
                }

            }
        }
    }
}
