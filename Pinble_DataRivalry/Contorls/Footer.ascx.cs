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

namespace Pinble_DataRivalry.Contorls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.PBnet_PulbicContent MyBll = new Pbzx.BLL.PBnet_PulbicContent();
                Pbzx.Model.PBnet_PulbicContent MyModel = MyBll.GetModelName("Õ¯’æ∞Ê»®");
                if (MyModel != null)
                {
                    ViewState["srfooter"] = MyModel.NteContent;
                }
            }
        }
    }
}