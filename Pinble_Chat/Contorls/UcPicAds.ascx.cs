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
using Pbzx.Common;

namespace Pbzx.Web.Contorls
{
    public partial class UcPicAds : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData();
            }
        }

        private string _direction = "0";

        private int _cellSpace = 5;

        public int CellSpace
        {
            get
            {
                return _cellSpace;
            }
            set 
            {
                _cellSpace = value;
                this.dlJsADs.CellSpacing = _cellSpace;                
            }
        }
        public string Direction
        {
            get 
            {
                if (this.dlJsADs.RepeatDirection == RepeatDirection.Horizontal)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
             }
            set 
            {
                if(value == "0")
                {
                    this.dlJsADs.RepeatDirection = RepeatDirection.Vertical;
                }
                else if (value == "1")
                {
                    this.dlJsADs.RepeatDirection = RepeatDirection.Horizontal; 
                }
            }
        }

        private string _placeType = "";
        //private int _intWidth;

        //public int IntWidth
        //{
        //    get { return _intWidth; }
        //    set { _intWidth = value; }
        //}
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
            //Pbzx.BLL.PBnet_Adv advBll = new Pbzx.BLL.PBnet_Adv();
            //List<Pbzx.Model.PBnet_Adv> ls = advBll.GetModelListByPlaceType(PlaceType, (int)Pbzx.Common.EadClass.Í¼Æ¬¹ã¸æ);
            //this.dlJsADs.DataSource = ls;
            //this.dlJsADs.DataBind();

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
                    gold += "<a href='" + AdModel.pb_SiteUrl + "' title='" + AdModel.pb_SiteName + "' target='_blank'>";
                    gold += "<img border='0' src='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "" + AdModel.pb_ImgUrl + "' width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "'>";
                    gold += "</a>";
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