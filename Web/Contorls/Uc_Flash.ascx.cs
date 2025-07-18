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
using System.Collections.Generic;

namespace Pbzx.Web.Contorls
{
    public partial class Uc_Flash : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private string _placeType = "";   

        public string PlaceType
        {
            get { return _placeType; }
            set { _placeType = value; }
        }

        private int _channelID = 0;

        public int ChannelID
        {
            get { return _channelID; }
            set { _channelID = value; }
        }
        private void BindData()
        {           
            Pbzx.BLL.PBnet_AdvPlace adBll = new Pbzx.BLL.PBnet_AdvPlace();
            this.dlJsADs.DataSource = adBll.GetList(" PlaceType='" + PlaceType + "'");
            this.dlJsADs.DataBind();

        }
        public string GetAdPic(object num)
        { 
         string gold = "";
            Pbzx.BLL.PBnet_Adv AdBll = new Pbzx.BLL.PBnet_Adv();
            if (num == null)
            {
                return "";
            }
            List<Pbzx.Model.PBnet_Adv> ls = AdBll.GetModelList(" PlaceName='" + num.ToString() + "' ");
            if (ls.Count > 0)
            {
                Pbzx.Model.PBnet_Adv AdModel = ls[0];
                if (AdModel.pb_ImgUrl != "" && (AdModel.pb_ENDTime > DateTime.Now.Date) && AdModel.pb_IsSelected)
                {
                    if (AdModel.pb_IsFlash)
                    {
                        gold += "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "'>";
                        gold += "<param name='movie' value='" + AdModel.pb_ImgUrl + "' />";
                        gold += "<param name='quality' value='high' />";
                        gold += " <param name='wmode' value='transparent' />";
                        gold += "<embed src='" + AdModel.pb_ImgUrl + "'  width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>";
                        gold += "</object>";

                    }
                    else
                    {
                        gold += "<a href='" + AdModel.pb_SiteUrl + "' title='" + AdModel.pb_SiteName + "' target='_blank'>";
                        gold += "<img border='0' src='" + AdModel.pb_ImgUrl + "' width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "'>";
                        gold += "</a>";
                    }
                }
                else
                {
                    this.dvImgAD.Visible = false;
                }
            }
            else
            {
                this.dvImgAD.Visible = false;
            }
            return gold.ToString();
        
        }
    }
}