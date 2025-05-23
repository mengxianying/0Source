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
using System.Collections.Generic;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcADwei : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.Common.Method.BindAdChanl(this.ddlChannel);
                Pbzx.Common.Method.BindAdClass(this.ddlADType);

                Pbzx.BLL.SaveAdPlaceType saveBll = new Pbzx.BLL.SaveAdPlaceType();
                List<Pbzx.Model.ObjAdPlace> ls = saveBll.GetAllList();
                foreach(Pbzx.Model.ObjAdPlace model in ls)
                {
                    this.ddlPlaceType.Items.Add(new ListItem(model.Name,model.Name));
                }
                //Pbzx.Common.Method.BindAdPlace(this.ddlPlaceType);

                Method.BindDdlOrRadio(this.ddlChannel, "Channel", true);
                Method.BindDdlOrRadio(this.ddlADType, "ADType", true);
                Method.BindDdlOrRadio(this.ddlPlaceType, "PlaceType", true);
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindDdlOrRadio(this.ddlChannel, "Channel", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlADType, "ADType", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlPlaceType, "PlaceType", false));

           Response.Redirect("AdvPlace_Manage.aspx?" + bu1.ToString());

       }
       protected void btnReset_Click(object sender, EventArgs e)
       {
           Response.Redirect("AdvPlace_Manage.aspx");

       }
    }
}