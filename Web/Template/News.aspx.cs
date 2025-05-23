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
using Common;
using System.Collections.Generic;
using System.Text;
using Pbzx.Common;
namespace Pbzx.Web
{
    public partial class News : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {              
                BindBType();
                News_Hot1.Count = int.Parse(WebInit.pageConfig.NewsNewUpdateCount);
                News_Hot2.Count = int.Parse(WebInit.pageConfig.NewsNewHotCount);
            }
        }

        private void BindBType()
        {
            Pbzx.BLL.PBnet_NewsType TypeBll = new Pbzx.BLL.PBnet_NewsType();
            Pbzx.Model.PBnet_NewsType TypeModell1 = TypeBll.GetModelName("左一");
            if (TypeModell1 != null)
            {
                lblLeft1.Text = GetLikeName(TypeModell1.VarTypeName, "title2");
                NewsOneTitleByTypeLeft1.TypeName = TypeModell1.VarTypeName;
                NewsOneTitleByTypeLeft1.Count = TypeModell1.DisCount;
            }
            else
            {
                this.divLeft1.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModell2 = TypeBll.GetModelName("左二");
            if (TypeModell2 != null)
            {
                lblLeft2.Text = GetLikeName(TypeModell2.VarTypeName, "title2");
                NewsOneTitleByTypeLeft2.TypeName = TypeModell2.VarTypeName;
                NewsOneTitleByTypeLeft2.Count = TypeModell2.DisCount;
            }
            else
            {
                this.divLeft2.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModell3 = TypeBll.GetModelName("左三");
            if (TypeModell3 != null)
            {
                lblLeft3.Text = GetLikeName(TypeModell3.VarTypeName, "title2");
                NewsOneTitleByTypeLeft3.TypeName = TypeModell3.VarTypeName;
                NewsOneTitleByTypeLeft3.Count = TypeModell3.DisCount;
            }
            else
            {
                this.divLeft3.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModell4 = TypeBll.GetModelName("左四");
            if (TypeModell4 != null)
            {
                lblLeft4.Text = GetLikeName(TypeModell4.VarTypeName, "title2");
                NewsOneTitleByTypeLeft4.TypeName = TypeModell4.VarTypeName;
                NewsOneTitleByTypeLeft4.Count = TypeModell4.DisCount;
            }
            else
            {
                this.divLeft4.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModell5 = TypeBll.GetModelName("左五");
            if (TypeModell5 != null)
            {
                lblLeft5.Text = GetLikeName(TypeModell5.VarTypeName, "title2");
                NewsOneTitleByTypeLeft5.TypeName = TypeModell5.VarTypeName;
                NewsOneTitleByTypeLeft5.Count = TypeModell5.DisCount;
            }
            else
            {
                this.divLeft5.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModell6 = TypeBll.GetModelName("左六");
            if (TypeModell6 != null)
            {
                lblLeft6.Text = GetLikeName(TypeModell6.VarTypeName, "title2");
                NewsOneTitleByTypeLeft6.TypeName = TypeModell6.VarTypeName;
                NewsOneTitleByTypeLeft6.Count = TypeModell6.DisCount;
            }
            else
            {
                this.divLeft6.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModell7 = TypeBll.GetModelName("左七");
            if (TypeModell7 != null)
            {
                lblLeft7.Text = GetLikeName(TypeModell7.VarTypeName, "title2");
                NewsOneTitleByTypeLeft7.TypeName = TypeModell7.VarTypeName;
                NewsOneTitleByTypeLeft7.Count = TypeModell7.DisCount;
            }
            else
            {
                this.divLeft7.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModell8 = TypeBll.GetModelName("左八");
            if (TypeModell8 != null)
            {
                lblLeft8.Text = GetLikeName(TypeModell8.VarTypeName, "title2");
                NewsOneTitleByTypeLeft8.TypeName = TypeModell8.VarTypeName;
                NewsOneTitleByTypeLeft8.Count = TypeModell8.DisCount;
            }
            else
            {
                this.divLeft8.Visible = false;
            }



            Pbzx.Model.PBnet_NewsType TypeModelc1 = TypeBll.GetModelName("中一");
            if (TypeModelc1 != null)
            {
                NewsOneTableByTypeCenter1.Count = TypeModelc1.DisCount;
                lblCenter1.Text = GetLikeName(TypeModelc1.VarTypeName, "linkse");
                NewsOneTableByTypeCenter1.TypeName = TypeModelc1.VarTypeName;
            }
            else
            {
                this.divCenter1.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelc2 = TypeBll.GetModelName("中二");
            if (TypeModelc2 != null)
            {
                NewsOneTableByTypeCenter2.Count = TypeModelc2.DisCount;
                lblCenter2.Text = GetLikeName(TypeModelc2.VarTypeName, "linkse");
                NewsOneTableByTypeCenter2.TypeName = TypeModelc2.VarTypeName;
            }
            else
            {
                this.divCenter2.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModelc3 = TypeBll.GetModelName("中三");
            if (TypeModelc3 != null)
            {
                lblCenter3.Text = GetLikeName(TypeModelc3.VarTypeName, "linkse");
                NewsOneTableByTypeCenter3.TypeName = TypeModelc3.VarTypeName;
                NewsOneTableByTypeCenter3.Count = TypeModelc3.DisCount;
            }
            else
            {
                this.divCenter3.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModelc4 = TypeBll.GetModelName("中四");
            if (TypeModelc4 != null)
            {
                lblCenter4.Text = GetLikeName(TypeModelc4.VarTypeName, "linkse");
                NewsOneTableByTypeCenter4.TypeName = TypeModelc4.VarTypeName;
                NewsOneTableByTypeCenter4.Count = TypeModelc4.DisCount;
            }
            else
            {
                this.divCenter4.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModelc5 = TypeBll.GetModelName("中五");
            if (TypeModelc5 != null)
            {
                lblCenter5.Text = GetLikeName(TypeModelc5.VarTypeName, "linkse");
                NewsOneTableByTypeCenter5.TypeName = TypeModelc5.VarTypeName;
                NewsOneTableByTypeCenter5.Count = TypeModelc5.DisCount;
            }
            else
            {
                this.divCenter5.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModelc6 = TypeBll.GetModelName("中六");
            if (TypeModelc6 != null)
            {
                lblCenter6.Text = GetLikeName(TypeModelc6.VarTypeName, "linkse");
                NewsOneTableByTypeCenter6.TypeName = TypeModelc6.VarTypeName;
                NewsOneTableByTypeCenter6.Count = TypeModelc6.DisCount;
            }
            else
            {
                this.divCenter6.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModelc7 = TypeBll.GetModelName("中七");
            if (TypeModelc7 != null)
            {
                lblCenter7.Text = GetLikeName(TypeModelc7.VarTypeName, "linkse");
                NewsOneTableByTypeCenter7.TypeName = TypeModelc7.VarTypeName;
                NewsOneTableByTypeCenter7.Count = TypeModelc7.DisCount;
            }
            else
            {
                this.divCenter7.Visible = false;
            }

            Pbzx.Model.PBnet_NewsType TypeModelc8 = TypeBll.GetModelName("中八");
            if (TypeModelc8 != null)
            {
                lblCenter8.Text = GetLikeName(TypeModelc8.VarTypeName, "linkse");
                NewsOneTableByTypeCenter8.TypeName = TypeModelc8.VarTypeName;
                NewsOneTableByTypeCenter8.Count = TypeModelc8.DisCount;
            }
            else
            {
                this.divCenter8.Visible = false;
            }



            Pbzx.Model.PBnet_NewsType TypeModelr1 = TypeBll.GetModelName("右一");
            if (TypeModelr1 != null)
            {
                lblRight1.Text = GetLikeName(TypeModelr1.VarTypeName, "linkse");
                NewsOneTitleByTypeRight1.TypeName = TypeModelr1.VarTypeName;
                NewsOneTitleByTypeRight1.Count = TypeModelr1.DisCount;
            }
            else
            {
                this.divRight1.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr2 = TypeBll.GetModelName("右二");
            if (TypeModelr2 != null)
            {
                lblRight2.Text = GetLikeName(TypeModelr2.VarTypeName, "linkse");
                NewsOneTitleByTypeRight2.TypeName = TypeModelr2.VarTypeName;
                NewsOneTitleByTypeRight2.Count = TypeModelr2.DisCount;
            }
            else
            {
                this.divRight2.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr3 = TypeBll.GetModelName("右三");
            if (TypeModelr3 != null)
            {
                lblRight3.Text = GetLikeName(TypeModelr3.VarTypeName, "linkse");
                NewsOneTitleByTypeRight3.TypeName = TypeModelr3.VarTypeName;
                NewsOneTitleByTypeRight3.Count = TypeModelr3.DisCount;
            }
            else
            {
                this.divRight3.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr4 = TypeBll.GetModelName("右四");
            if (TypeModelr4 != null)
            {
                lblRight4.Text = GetLikeName(TypeModelr4.VarTypeName, "linkse");
                NewsOneTitleByTypeRight4.TypeName = TypeModelr4.VarTypeName;
                NewsOneTitleByTypeRight4.Count = TypeModelr4.DisCount;
            }
            else
            {
                this.divRight4.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr5 = TypeBll.GetModelName("右五");
            if (TypeModelr5 != null)
            {
                lblRight5.Text = GetLikeName(TypeModelr5.VarTypeName, "linkse");
                NewsOneTitleByTypeRight5.TypeName = TypeModelr5.VarTypeName;
                NewsOneTitleByTypeRight5.Count = TypeModelr5.DisCount;
            }
            else
            {
                this.divRight5.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr6 = TypeBll.GetModelName("右六");
            if (TypeModelr6 != null)
            {
                lblRight6.Text = GetLikeName(TypeModelr6.VarTypeName, "linkse");
                NewsOneTitleByTypeRight6.TypeName = TypeModelr6.VarTypeName;
                NewsOneTitleByTypeRight6.Count = TypeModelr6.DisCount;
            }
            else
            {
                this.divRight6.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr7 = TypeBll.GetModelName("右七");
            if (TypeModelr7 != null)
            {
                lblRight7.Text = GetLikeName(TypeModelr7.VarTypeName, "linkse");
                NewsOneTitleByTypeRight7.TypeName = TypeModelr7.VarTypeName;
                NewsOneTitleByTypeRight7.Count = TypeModelr7.DisCount;
            }
            else
            {
                this.divRight7.Visible = false;
            }


            Pbzx.Model.PBnet_NewsType TypeModelr8 = TypeBll.GetModelName("右八");
            if (TypeModelr8 != null)
            {
                lblRight8.Text = GetLikeName(TypeModelr8.VarTypeName, "linkse");
                NewsOneTitleByTypeRight8.TypeName = TypeModelr8.VarTypeName;
                NewsOneTitleByTypeRight8.Count = TypeModelr8.DisCount;
            }
            else
            {
                this.divRight8.Visible = false;
            }

            


        }

        public static string GetLikeName(object objstr, object strcss)
        {
          string strName=objstr.ToString();
          return "<a href='/News_list.aspx?NewsType=" + Pbzx.Common.Input.Encrypt(Pbzx.BLL.PBnet_NewsType.ReturnId(strName)) + "' class='more'>更多>></a><span><a href='/News_list.aspx?NewsType=" + Pbzx.Common.Input.Encrypt(Pbzx.BLL.PBnet_NewsType.ReturnId(strName)) + "'>" + strName + "</span></a>"; 
        }
       
    }
}
