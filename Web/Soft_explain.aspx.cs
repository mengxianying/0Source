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

namespace Pbzx.Web
{
    public partial class Soft_explain : System.Web.UI.Page
    {
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
        private string _ClassID;
        public string SoftID = "";
        public string Copyright = "";
        public string Operating = "";
        public string Author = "";
        public string TypeName = "";

        public string wtDown = "";
        public string dxDown = "";
        public string Down3a = "";
        public string Down4a = "";
        public string SinaWiki = "";
        //帮助
        public string Abouturl = "";

        public int pb_Hits = 0;

        public bool pb_freeshow = false;

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

        public string  DowloadTips = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    try
                    {
                        string id = Input.FilterAll(Input.Decrypt(Request["id"]));
                        Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
                        Pbzx.Model.PBnet_Product MyModel = MyBLL.GetModel(Convert.ToInt32(id));
                        if (MyModel == null || MyModel.pb_Passed == false)
                        {
                            Response.Redirect("PageNoFound.htm");
                            return;
                        }
                        wtDown = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + id + "&reUrl=1";
                        dxDown = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + id + "&reUrl=2";
                        Down3a = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + id + "&reUrl=3";
                        Down4a = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + id + "&reUrl=4";
                        ShowNews(int.Parse(id));
                        this.Title = SoftName + "_拼搏在线彩神通软件";
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
                if (Request.QueryString["vef"] != null)
                {
                    this.N1.Visible = false;
                    this.N2.Visible = true;
                }
                else
                {
                    this.N2.Visible = false;
                    this.N1.Visible = true;
                }


            }
        }
        private void ShowNews(int id)
        {

            Pbzx.BLL.PBnet_ProductPrice PriceBll = new Pbzx.BLL.PBnet_ProductPrice();

            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            Pbzx.Model.PBnet_Product MyModel = MyBLL.GetModel(id);

            ////绑定视频列表
            if (MyModel.Video.Trim() != "" && MyModel.Video != null)
            {
                string height = "505";
                if (MyModel.Video.Substring(MyModel.Video.Length - 2) == "||")
                {
                    MyModel.Video = MyModel.Video.Trim().Substring(0, MyModel.Video.Length - 2);
                }
                string[] len = MyModel.Video.Replace("||", "$").Split('$');
                if (len.Length >= 15)
                {
                    height = Convert.ToString(Convert.ToInt32(height) + 40 + ((len.Length - 15) * 32));
                }
                framid.Visible = true;
                framid.InnerHtml = " <iframe  scrolling='no' frameborder='0' width='745' height='" + height + "' src='flashplay.aspx?id=" + id + "&type=soft'></iframe>";
            }
            pb_Hits = MyModel.pb_Hits;

            SoftID = MyModel.pb_SoftID.ToString();
            SoftName = MyModel.pb_SoftName;
            SoftVersion = MyModel.pb_SoftVersion;
            ClassID = MyModel.pb_ClassID.ToString();
            OperatingSyste = MyModel.pb_OperatingSystem;
            SoftSize = MyModel.pb_SoftSize.ToString();
            Stars = MyModel.pb_Stars.ToString();
            UpdateTime = MyModel.pb_UpdateTime.ToLongDateString();
            RegUrl = MyModel.pb_RegUrl;
            SoftIntro = MyModel.pb_SoftIntro;
            DemoUrl = MyModel.pb_DemoUrl.ToString();
//            RegUrl = MyModel.pb_RegUrl.ToString();
// 屏蔽终身版本价格
            RegUrl = "";
            softContent = MyModel.pb_softContent;
            PicUrl = MyModel.pb_SoftPicUrl;
            Abouturl = MyModel.pb_illuminate;

            pb_freeshow = MyModel.pb_freeshow;

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
            string[] down1SZ = WebFunc.GetDownInfo("1", "1");
            string[] down2SZ = WebFunc.GetDownInfo("1", "2");
            string[] down3SZ = WebFunc.GetDownInfo("1", "3");
            string[] down4SZ = WebFunc.GetDownInfo("1", "4");
            if (down1SZ[2] == "0" && down2SZ[2] == "0" && down3SZ[2] == "0" && down4SZ[2] == "0")
            {
                this.xiazai1.Visible = false;
            }
            else
            {
                xiazai1.Visible = true;

                //有的话出现down1--start
                if (down1SZ[2] == "0")
                {
                    this.tdDown1.Visible = false;
                }
                else
                {
                    this.tdDown1.Visible = true;
                    lblDown1.Text = down1SZ[3];
                }
                //有的话出现down1---end


                //有的话出现down2--start
                if (string.IsNullOrEmpty(Down2) || down2SZ[2] == "0")
                {
                    this.tdDown2.Visible = false;
                }
                else
                {
                    this.tdDown2.Visible = true;
                    lblDown2.Text = down2SZ[3];
                }
                //有的话出现down2--end

                //有的话出现down3--start
                if (string.IsNullOrEmpty(Down3) || down3SZ[2] == "0")
                {
                    this.tdDown3.Visible = false;
                }
                else
                {
                    this.tdDown3.Visible = true;
                    lblDown3.Text = down3SZ[3];
                }
                //有的话出现down3--end

                //有的话出现down4--start
                if (string.IsNullOrEmpty(Down4) || down4SZ[2] == "0")
                {
                    this.tdDown4.Visible = false;
                }
                else
                {
                    this.tdDown4.Visible = true;
                    lblDown4.Text = down4SZ[3];
                }
                //有的话出现down4--end
            }


            Copyright = GetType(MyModel.pb_CopyrightType.ToString());
            Operating = MyModel.pb_OperatingSystem.ToString();
            Author = MyModel.pb_Author.ToString();
            //  lblWLPrice.Text = PriceBll.GetSoftTime(MyModel.pb_TypeName.ToString());
            string[] prices = PriceBll.GetModelTime(MyModel.pb_TypeName.ToString());

            if (pb_freeshow)
            {
                lblSoftDog.Text = "";
                lblWLPrice.Text = "";
            }
            else
            {
                if (prices == null)
                {
                    lblWLPrice.Text = "";
                }
                else
                {
                    if (MyModel.pb_TypeName == "珍藏版" || MyModel.pb_TypeName == "免费版" || MyModel.pb_TypeName == "出票系统")
                    {
                        if (MyModel.pb_TypeName == "珍藏版" || MyModel.pb_TypeName == "免费版")
                        {
                            DemoUrl = "免费";
                            RegUrl = "";
                        }
                        this.lblSoftDog.Text = "";
                        lblWLPrice.Text = "无";
                    }
                    else
                    {
                        this.lblSoftDog.Text = "软件狗：" + WebInit.webBaseConfig.SoftdogPrice.ToString() + "元/个";
                        lblWLPrice.Text = prices[0] + "&nbsp;" + prices[1] + "&nbsp;" + prices[2] + "&nbsp;" + prices[3].Substring(0, prices[3].Length - 3) + "&nbsp;";
                    }


                }
            }
            if (MyModel.pb_TypeName == "免费版" || MyModel.pb_TypeName == "珍藏版")
            {
                this.buyimg.Visible = false;
            }
        }

        public static string GetType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 1:
                    type = "免费版";
                    break;
                case 2:
                    type = "共享版";
                    break;
                case 3:
                    type = "试用版";
                    break;
                case 4:
                    type = "演示版";
                    break;
                case 5:
                    type = "注册版";
                    break;
                case 6:
                    type = "破解版";
                    break;
                case 7:
                    type = "零售版";
                    break;
                case 8:
                    type = "OEM版";
                    break;
                default:
                    type = "未知";
                    break;
            }
            return type;
        }

        public string GetAbout()
        {
            if (Abouturl != "")
            {
                return "<a href='" + Abouturl + "'><img style='border: 0px;' src='Images/Web/Aboutbox.gif' /></a>";
            }
            return "";
        }
    }
}

