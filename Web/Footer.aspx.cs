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
    public partial class Footer : System.Web.UI.Page
    {
        public string strFooter = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strId = Input.FilterAll(Request["id"]);
                if (!OperateText.IsNumber(strId) || int.Parse(strId) !=1)
                {
                    strId = "1";
                }
                Pbzx.BLL.PBnet_PulbicContent MyBll = new Pbzx.BLL.PBnet_PulbicContent();
                Pbzx.Model.PBnet_PulbicContent MyModel;

                if (strId != null && strId != "")
                {
                    MyModel = MyBll.GetModel(int.Parse(strId.ToString()));

                    strFooter = MyModel.NteContent;
                }
            }

        }
    }
}
