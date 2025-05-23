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
    public partial class UcJsADs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData(); 
            }
        }

        private string _placeType;
        public string PlaceType
        {
            get { return _placeType; }
            set { _placeType = value; }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Adv advBll = new Pbzx.BLL.PBnet_Adv();
            List<Pbzx.Model.PBnet_Adv> ls = advBll.GetModelListByPlaceType(PlaceType, (int)Pbzx.Common.EadClass.JS¹ã¸æ);
            this.dlJsADs.DataSource = ls;
            this.dlJsADs.DataBind();
        }
    }
}