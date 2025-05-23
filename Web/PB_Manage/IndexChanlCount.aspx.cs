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

namespace Pbzx.Web.PB_Manage
{
    public partial class IndexChanlCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPageConfig();
            }
        }

        private void BindPageConfig()
        {

            PageConfig pageConfig = WebInit.pageConfig;
            //首页设置
            txtNews.Text = pageConfig.IndexNewsCount;
            txtBulletin.Text = pageConfig.IndexBulletinCount;
            txtUpdateProduct.Text = pageConfig.IndexNewUpdateProduct;
            txtUpdateSoft.Text = pageConfig.IndexNewUpdateSoft;

            txtSoft.Text = pageConfig.IndexSoft;
            txtSchool.Text = pageConfig.IndexSchool;
            txtBar.Text = pageConfig.IndexBar;
            txtBbs.Text = pageConfig.IndexBbs;

            txtLinkCount.Text = pageConfig.IndexLinkCount;
            LinkCountPic.Text = pageConfig.IndexLinkCountPic;

            //公告设置

            txtBType.Text = pageConfig.BulletinTypeCount;
            txtBUpdate.Text = pageConfig.BulletinNewUpdateCount;
            txtBNewHot.Text = pageConfig.BulletinNewHotCount;

            //资讯设置

            txtNType.Text = pageConfig.NewsTypeCount;
            txtNUpdate.Text = pageConfig.NewsNewUpdateCount;
            txtNNewHot.Text = pageConfig.NewsNewHotCount;

            //软件学院设置

            txtShoolType.Text = pageConfig.ScholTypeCount;
            txtScholCenterList.Text = pageConfig.ScholCenterList;
            txtScholHot.Text = pageConfig.ScholHotCount;
            txtScholsoft.Text = pageConfig.Scholsoft;
            txtScholsoure.Text = pageConfig.Scholsoure;

            //频道公告条数设置


            txtBrokerBulletin.Text = pageConfig.BrokerBulletin;

            //软件内嵌设置

            txtSoftLength.Text = pageConfig.SoftLength;
            txtSoftCount.Text = pageConfig.SoftCount;
            txtCstLength.Text = pageConfig.CstLength;
            txtCstCount.Text = pageConfig.CstCount;


            Sourcelegth.Text = pageConfig.Sourcelegth;
            Sourcelie.Text = pageConfig.Sourcelie;
            Sourcecountlegth.Text = pageConfig.Sourcecountlegth;
            Sourcecountlie.Text = pageConfig.Sourcecountlie;
            SourceMlegth.Text = pageConfig.SourceMlegth;
            SourceMlie.Text = pageConfig.SourceMlie;


            Softlength.Text = pageConfig.Softlength;
            Softlie.Text = pageConfig.Softlie;

            Softxzlength.Text = pageConfig.Softxzlength;
            Softxzlie.Text = pageConfig.Softxzlie;

            SoftMlength.Text = pageConfig.SoftMlength;
            SoftMlie.Text = pageConfig.SoftMlie;

            WebFunc.GetModules();

        }

        protected void btnIndex_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            int intWebPageNum = 20;
            if (!int.TryParse(this.txtNews.Text, out intWebPageNum))
            {
                errMsg += "新闻资讯条数应该为整数！";
            }
            if (!int.TryParse(this.txtBulletin.Text, out intWebPageNum))
            {
                errMsg += "网站公告条数应该为整数！";
            }
            if (!int.TryParse(this.txtUpdateProduct.Text, out intWebPageNum))
            {
                errMsg += "更新商品条数应该为整数！";
            }
            if (!int.TryParse(this.txtUpdateSoft.Text, out intWebPageNum))
            {
                errMsg += "更新资源条数应该为整数！";
            }
            if (!int.TryParse(this.txtSoft.Text, out intWebPageNum))
            {
                errMsg += "资源下载条数应该为整数！";
            }
            if (!int.TryParse(this.txtSchool.Text, out intWebPageNum))
            {
                errMsg += "软件学院条数应该为整数！";

            }
            if (!int.TryParse(this.txtBar.Text, out intWebPageNum))
            {
                errMsg += "拼搏吧条数应该为整数！";
            }
            if (!int.TryParse(this.txtBbs.Text, out intWebPageNum))
            {
                errMsg += "热点论坛条数应该为整数！";
            }
            if (!int.TryParse(this.txtLinkCount.Text, out intWebPageNum))
            {
                errMsg += "文字链接条数应该为整数！";
            }
            if (!int.TryParse(this.LinkCountPic.Text, out intWebPageNum))
            {
                errMsg += "图片链接条数应该为整数！";
            }
            ///公告

            if (!int.TryParse(this.txtBType.Text, out intWebPageNum))
            {
                errMsg += "公告类别条数应该为整数！";
            }
            if (!int.TryParse(this.txtBUpdate.Text, out intWebPageNum))
            {
                errMsg += "最新公告条数应该为整数！";
            }
            if (!int.TryParse(this.txtBNewHot.Text, out intWebPageNum))
            {
                errMsg += "热点公告条数应该为整数！";
            }

            ///资讯
            if (!int.TryParse(this.txtNType.Text, out intWebPageNum))
            {
                errMsg += "资讯类别条数应该为整数！";
            }
            if (!int.TryParse(this.txtNUpdate.Text, out intWebPageNum))
            {
                errMsg += "最新资讯条数应该为整数！";
            }
            if (!int.TryParse(this.txtNNewHot.Text, out intWebPageNum))
            {
                errMsg += "热点资讯条数应该为整数！";
            }

            ///学院

            if (!int.TryParse(this.txtShoolType.Text, out intWebPageNum))
            {
                errMsg += "软件学院类别条数应该为整数！";
            }
            if (!int.TryParse(this.txtScholCenterList.Text, out intWebPageNum))
            {
                errMsg += "软件学院列表条数应该为整数！";
            }
            if (!int.TryParse(this.txtScholHot.Text, out intWebPageNum))
            {
                errMsg += "最新热点条数应该为整数！";
            }
            if (!int.TryParse(this.txtScholsoft.Text, out intWebPageNum))
            {
                errMsg += "最新商品条数应该为整数！";
            }
            if (!int.TryParse(this.txtScholsoure.Text, out intWebPageNum))
            {
                errMsg += "最新资源条数应该为整数！";
            }


            if (!int.TryParse(this.txtBrokerBulletin.Text, out intWebPageNum))
            {
                errMsg += "经纪人公告条数应该为整数！";
            }

            //软件内嵌
            if (!int.TryParse(this.txtSoftLength.Text, out intWebPageNum))
            {
                errMsg += "软件内嵌显示字数应该为整数！";
            }

            if (!int.TryParse(this.txtSoftCount.Text, out intWebPageNum))
            {
                errMsg += "软件内嵌显示条数应该为整数！";
            }

            if (!int.TryParse(this.txtCstLength.Text, out intWebPageNum))
            {
                errMsg += "公告显示字数应该为整数！";
            }

            if (!int.TryParse(this.txtCstCount.Text, out intWebPageNum))
            {
                errMsg += "公告显示条数应该为整数！";
            }

            if (!int.TryParse(this.Softlength.Text, out intWebPageNum))
            {
                errMsg += "最新商品下载长度应该为整数！";
            }
            if (!int.TryParse(this.Softlie.Text, out intWebPageNum))
            {
                errMsg += "最新商品下载列应该为整数！";
            }

            if (!int.TryParse(this.Softxzlength.Text, out intWebPageNum))
            {
                errMsg += "最新商品下载长度应该为整数！";
            }
            if (!int.TryParse(this.Softxzlie.Text, out intWebPageNum))
            {
                errMsg += "最新商品下载列应该为整数！";
            }
            if (!int.TryParse(this.SoftMlength.Text, out intWebPageNum))
            {
                errMsg += "本月商品下载长度应该为整数！";
            }
            if (!int.TryParse(this.SoftMlie.Text, out intWebPageNum))
            {
                errMsg += "本月商品下载列应该为整数！";
            }

            if (!int.TryParse(this.Sourcelegth.Text, out intWebPageNum))
            {
                errMsg += "最新软件下载长度应该为整数！";
            }
            if (!int.TryParse(this.Sourcelie.Text, out intWebPageNum))
            {
                errMsg += "最新软件下载列应该为整数！";
            }


            if (!int.TryParse(this.Sourcecountlegth.Text, out intWebPageNum))
            {
                errMsg += "总软件下载长度应该为整数！";
            }
            if (!int.TryParse(this.Sourcecountlie.Text, out intWebPageNum))
            {
                errMsg += "总软件下载列应该为整数！";
            }

            if (!int.TryParse(this.SourceMlegth.Text, out intWebPageNum))
            {
                errMsg += "每月软件下载长度应该为整数！";
            }
            if (!int.TryParse(this.SourceMlie.Text, out intWebPageNum))
            {
                errMsg += "每月软件下载列应该为整数！";
            }




            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("错误", JS.Alert("您提交的信息有以下错误，请修改后提交！\\r\\n" + errMsg));
                return;
            }

            PageConfig pageConfig = new PageConfig();

            pageConfig.IndexNewsCount = txtNews.Text;
            pageConfig.IndexBulletinCount = txtBulletin.Text;
            pageConfig.IndexNewUpdateProduct = txtUpdateProduct.Text;
            pageConfig.IndexNewUpdateSoft = txtUpdateSoft.Text;

            pageConfig.IndexSoft = txtSoft.Text;
            pageConfig.IndexSchool = txtSchool.Text;
            pageConfig.IndexBar = txtBar.Text;
            pageConfig.IndexBbs = txtBbs.Text;

            pageConfig.IndexLinkCount = txtLinkCount.Text;
            pageConfig.IndexLinkCountPic = LinkCountPic.Text;

            ///公告
            pageConfig.BulletinTypeCount = txtBType.Text;
            pageConfig.BulletinNewUpdateCount = txtBUpdate.Text;
            pageConfig.BulletinNewHotCount = txtBNewHot.Text;

            ///资讯
            pageConfig.NewsTypeCount = txtNType.Text;
            pageConfig.NewsNewUpdateCount = txtNUpdate.Text;
            pageConfig.NewsNewHotCount = txtNNewHot.Text;

            ///学院
            pageConfig.ScholTypeCount = txtShoolType.Text;
            pageConfig.ScholCenterList = txtScholCenterList.Text;
            pageConfig.ScholHotCount = txtScholHot.Text;
            pageConfig.Scholsoft = txtScholsoft.Text;
            pageConfig.Scholsoure = txtScholsoure.Text;

            //频道公告条数设置

            pageConfig.BrokerBulletin = txtBrokerBulletin.Text;

            //软件内嵌设置修改
            pageConfig.SoftLength = txtSoftLength.Text;
            pageConfig.SoftCount = txtSoftCount.Text;
            pageConfig.CstLength = txtCstLength.Text;
            pageConfig.CstCount = txtCstCount.Text;



            pageConfig.Softlength = Softlength.Text;
            pageConfig.Softlie = Softlie.Text;
            pageConfig.Softxzlength = Softxzlength.Text;
            pageConfig.Softxzlie = Softxzlie.Text;
            pageConfig.SoftMlength = SoftMlength.Text;
            pageConfig.SoftMlie = SoftMlie.Text;


            pageConfig.Sourcelegth = Sourcelegth.Text;
            pageConfig.Sourcelie = Sourcelie.Text;

            pageConfig.Sourcecountlegth = Sourcecountlegth.Text;
            pageConfig.Sourcecountlie = Sourcecountlie.Text;

            pageConfig.SourceMlegth = SourceMlegth.Text;
            pageConfig.SourceMlie = SourceMlie.Text;



            WebInit.pageConfig = pageConfig;
            BindPageConfig();
        }


    }
}
