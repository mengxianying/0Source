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
    public partial class Bulletin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBType();

                Bulletin_news1.Count = int.Parse(WebInit.pageConfig.BulletinNewUpdateCount);
                Bulletin_Hot1.Count = int.Parse(WebInit.pageConfig.BulletinNewHotCount);
            }
        }
        private void BindBType()
        {
            //////////////////////左边部分///////////////////////////////////////////////////////////////////
            Pbzx.BLL.PBnet_BulletinType TypeBll = new Pbzx.BLL.PBnet_BulletinType();
            Pbzx.Model.PBnet_BulletinType TypeModelL1 = TypeBll.GetModelName("左一");
            if (TypeModelL1 != null)
            {
                lblLeft1.Text = GetLikeNameL(TypeModelL1.VarTypeName);
                Bulletin_l1.TypeName = TypeModelL1.VarTypeName;
                Bulletin_l1.Count = TypeModelL1.DisCount;
            }
            else
            {
               this.dvLeft1.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelL2 = TypeBll.GetModelName("左二");
            if (TypeModelL2 != null)
            {
                lblLeft2.Text = GetLikeNameL(TypeModelL2.VarTypeName);
                Bulletin_l2.TypeName = TypeModelL2.VarTypeName;
                Bulletin_l2.Count = TypeModelL2.DisCount;
            }
            else
            {
                this.dvLeft2.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelL3 = TypeBll.GetModelName("左三");
            if (TypeModelL3 != null)
            {
                lblLeft3.Text = GetLikeNameL(TypeModelL3.VarTypeName);
                Bulletin_l3.TypeName = TypeModelL3.VarTypeName;
                Bulletin_l3.Count = TypeModelL3.DisCount;
            }
            else
            {
                this.dvLeft3.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelL4 = TypeBll.GetModelName("左四");
            if (TypeModelL4 != null)
            {
                lblLeft4.Text = GetLikeNameL(TypeModelL4.VarTypeName);
                Bulletin_l4.TypeName = TypeModelL4.VarTypeName;
                Bulletin_l4.Count = TypeModelL4.DisCount;
            }
            else
            {
                this.dvLeft4.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelL5 = TypeBll.GetModelName("左五");
            if (TypeModelL5 != null)
            {
                lblLeft5.Text = GetLikeNameL(TypeModelL5.VarTypeName);
                Bulletin_l5.TypeName = TypeModelL5.VarTypeName;
                Bulletin_l5.Count = TypeModelL5.DisCount;
            }
            else
            {
                this.dvLeft5.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelL6 = TypeBll.GetModelName("左六");
            if (TypeModelL6 != null)
            {
                lblLeft6.Text = GetLikeNameL(TypeModelL6.VarTypeName);
                Bulletin_l6.TypeName = TypeModelL6.VarTypeName;
                Bulletin_l6.Count = TypeModelL6.DisCount;
            }
            else
            {
                this.dvLeft6.Visible = false;
            }



            Pbzx.Model.PBnet_BulletinType TypeModelL7 = TypeBll.GetModelName("左七");
            if (TypeModelL7 != null)
            {
                lblLeft7.Text = GetLikeNameL(TypeModelL7.VarTypeName);
                Bulletin_l7.TypeName = TypeModelL7.VarTypeName;
                Bulletin_l7.Count = TypeModelL7.DisCount;
            }
            else
            {
                this.dvLeft7.Visible = false;
            }

            
            Pbzx.Model.PBnet_BulletinType TypeModelL8 = TypeBll.GetModelName("左八");
            if (TypeModelL8 != null)
            {
                lblLeft8.Text = GetLikeNameL(TypeModelL8.VarTypeName);
                Bulletin_l8.TypeName = TypeModelL8.VarTypeName;
                Bulletin_l8.Count = TypeModelL8.DisCount;
            }
            else
            {
                this.dvLeft8.Visible = false;
            }
            
            //////////////////////中间部分///////////////////////////////////////////////////////////////////

            Pbzx.Model.PBnet_BulletinType TypeModelC1 = TypeBll.GetModelName("中一");
            if (TypeModelC1 != null)
            {
                lblCenter1.Text = GetLikeNameC(TypeModelC1.VarTypeName);
                Bulletin_c1.TypeName = TypeModelC1.VarTypeName;
                Bulletin_c1.Count = TypeModelC1.DisCount;
            }
            else
            {
                this.divCenter1.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelC2 = TypeBll.GetModelName("中二");
            if (TypeModelC2 != null)
            {
                lblCenter2.Text = GetLikeNameC(TypeModelC2.VarTypeName);
                Bulletin_c2.TypeName = TypeModelC2.VarTypeName;
                Bulletin_c2.Count = TypeModelC2.DisCount;
            }
            else
            {
                this.divCenter2.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelC3 = TypeBll.GetModelName("中三");
            if (TypeModelC3 != null)
            {
                lblCenter3.Text = GetLikeNameC(TypeModelC3.VarTypeName);
                Bulletin_c3.TypeName = TypeModelC3.VarTypeName;
                Bulletin_c3.Count = TypeModelC3.DisCount;
            }
            else
            {
                this.divCenter3.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelC4 = TypeBll.GetModelName("中四");
            if (TypeModelC4 != null)
            {
                lblCenter4.Text = GetLikeNameC(TypeModelC4.VarTypeName);
                Bulletin_c4.TypeName = TypeModelC4.VarTypeName;
                Bulletin_c4.Count = TypeModelC4.DisCount;
            }
            else
            {
                this.divCenter4.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelC5 = TypeBll.GetModelName("中五");
            if (TypeModelC5 != null)
            {
                lblCenter5.Text = GetLikeNameC(TypeModelC5.VarTypeName);
                Bulletin_c5.TypeName = TypeModelC5.VarTypeName;
                Bulletin_c5.Count = TypeModelC5.DisCount;
            }
            else
            {
                this.divCenter5.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelC6 = TypeBll.GetModelName("中六");
            if (TypeModelC6 != null)
            {
                lblCenter6.Text = GetLikeNameC(TypeModelC6.VarTypeName);
                Bulletin_c6.TypeName = TypeModelC6.VarTypeName;
                Bulletin_c6.Count = TypeModelC6.DisCount;
            }
            else
            {
                this.divCenter6.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelC7 = TypeBll.GetModelName("中七");
            if (TypeModelC7 != null)
            {
                lblCenter7.Text = GetLikeNameC(TypeModelC7.VarTypeName);
                Bulletin_c7.TypeName = TypeModelC7.VarTypeName;
                Bulletin_c7.Count = TypeModelC7.DisCount;
            }
            else
            {
                this.divCenter7.Visible = false;
            }

            Pbzx.Model.PBnet_BulletinType TypeModelC8 = TypeBll.GetModelName("中八");
            if (TypeModelC8 != null)
            {
                lblCenter8.Text = GetLikeNameC(TypeModelC8.VarTypeName);
                Bulletin_c8.TypeName = TypeModelC8.VarTypeName;
                Bulletin_c8.Count = TypeModelC8.DisCount;
            }
            else
            {
                this.divCenter8.Visible = false;
            }

            //////////////////////右边部分///////////////////////////////////////////////////////////////////

            Pbzx.Model.PBnet_BulletinType TypeModelR1 = TypeBll.GetModelName("右一");
            if (TypeModelR1 != null)
            {
                lblRight1.Text = GetLikeNameC(TypeModelR1.VarTypeName);
                Bulletin_r1.TypeName = TypeModelR1.VarTypeName;
                Bulletin_r1.Count = TypeModelR1.DisCount;
            }
            else
            {
                this.divRight1.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR2 = TypeBll.GetModelName("右二");
            if (TypeModelR2 != null)
            {
                lblRight2.Text = GetLikeNameC(TypeModelR2.VarTypeName);
                Bulletin_r2.TypeName = TypeModelR2.VarTypeName;
                Bulletin_r2.Count = TypeModelR2.DisCount;
            }
            else
            {
                this.divRight2.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR3 = TypeBll.GetModelName("右三");
            if (TypeModelR3 != null)
            {
                lblRight3.Text = GetLikeNameC(TypeModelR3.VarTypeName);
                Bulletin_r3.TypeName = TypeModelR3.VarTypeName;
                Bulletin_r3.Count = TypeModelR3.DisCount;
            }
            else
            {
                this.divRight3.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR4 = TypeBll.GetModelName("右四");
            if (TypeModelR4 != null)
            {
                lblRight4.Text = GetLikeNameC(TypeModelR4.VarTypeName);
                Bulletin_r4.TypeName = TypeModelR4.VarTypeName;
                Bulletin_r4.Count = TypeModelR4.DisCount;
            }
            else
            {
                this.divRight4.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR5 = TypeBll.GetModelName("右五");
            if (TypeModelR5 != null)
            {
                lblRight5.Text = GetLikeNameC(TypeModelR5.VarTypeName);
                Bulletin_r5.TypeName = TypeModelR5.VarTypeName;
                Bulletin_r5.Count = TypeModelR5.DisCount;
            }
            else
            {
                this.divRight5.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR6 = TypeBll.GetModelName("右六");
            if (TypeModelR6 != null)
            {
                lblRight6.Text = GetLikeNameC(TypeModelR6.VarTypeName);
                Bulletin_r6.TypeName = TypeModelR6.VarTypeName;
                Bulletin_r6.Count = TypeModelR6.DisCount;
            }
            else
            {
                this.divRight6.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR7 = TypeBll.GetModelName("右七");
            if (TypeModelR7 != null)
            {
                lblRight7.Text = GetLikeNameC(TypeModelR7.VarTypeName);
                Bulletin_r7.TypeName = TypeModelR7.VarTypeName;
                Bulletin_r7.Count = TypeModelR7.DisCount;
            }
            else
            {
                this.divRight7.Visible = false;
            }


            Pbzx.Model.PBnet_BulletinType TypeModelR8 = TypeBll.GetModelName("右八");
            if (TypeModelR8 != null)
            {
                lblRight8.Text = GetLikeNameC(TypeModelR8.VarTypeName);
                Bulletin_r8.TypeName = TypeModelR8.VarTypeName;
                Bulletin_r8.Count = TypeModelR8.DisCount;
            }
            else
            {
                this.divRight8.Visible = false;
            }

        }
        public static string GetLikeNameL(object objstr)
        {
            string str = objstr.ToString();

            return "<a href='/Bulletin_list.aspx?NewsType=" + Pbzx.Common.Input.Encrypt(Pbzx.BLL.PBnet_BulletinType.ReturnId(str)) + "' class='more'>更多>></a><span style='margin-left: -3px;'><a href='/Bulletin_list.aspx?NewsType=" + Pbzx.Common.Input.Encrypt(Pbzx.BLL.PBnet_BulletinType.ReturnId(str)) + "'>" + str + "</a> </span>";

        }
        public static string GetLikeNameC(object objstr)
        {
            string str = objstr.ToString();

            return "<a href='/Bulletin_list.aspx?NewsType=" + Pbzx.Common.Input.Encrypt(Pbzx.BLL.PBnet_BulletinType.ReturnId(str)) + "' class='more'>更多>></a><span><a href='/Bulletin_list.aspx?NewsType=" + Pbzx.Common.Input.Encrypt(Pbzx.BLL.PBnet_BulletinType.ReturnId(str)) + "'>" + str + "</a> </span>";

        }
    }
}









