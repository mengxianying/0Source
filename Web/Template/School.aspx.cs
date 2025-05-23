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
using Common;
using System.Collections.Generic;


namespace Pbzx.Web
{
    public partial class School : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SoftTitle_school1.Count = int.Parse(WebInit.pageConfig.Scholsoft);
                SourceTitle_school1.Count = int.Parse(WebInit.pageConfig.Scholsoure);
                Pbzx.BLL.PBnet_SchoolType TypeBll = new Pbzx.BLL.PBnet_SchoolType();
                Pbzx.Model.PBnet_SchoolType TypeModelRight1 = TypeBll.GetModelName("右一");
                if (TypeModelRight1 != null)
                {
                    this.lblRight1.Text = GetLikeName(TypeModelRight1.VarTypeName, "title2", TypeModelRight1.IntNewsTypeID);                                        
                    SchoolOneTitleByTypeRight1.TypeName = TypeModelRight1.VarTypeName;
                    SchoolOneTitleByTypeRight1.Count = TypeModelRight1.DisCount;
                }
                else
                {
                    this.divRight1.Visible = false;
                }

                Pbzx.Model.PBnet_SchoolType TypeModelRight2 = TypeBll.GetModelName("右二");
                if (TypeModelRight2 != null)
                {
                    this.lblRight2.Text = GetLikeName(TypeModelRight2.VarTypeName, "title2", TypeModelRight2.IntNewsTypeID);
                    SchoolOneTitleByTypeRight2.TypeName = TypeModelRight2.VarTypeName;
                    SchoolOneTitleByTypeRight2.Count = TypeModelRight2.DisCount;
                }
                else
                {
                    this.divRight2.Visible = false;
                }

                Pbzx.Model.PBnet_SchoolType TypeModelRight3 = TypeBll.GetModelName("右三");
                if (TypeModelRight3 != null)
                {
                    this.lblRight3.Text = GetLikeName(TypeModelRight3.VarTypeName, "title2", TypeModelRight3.IntNewsTypeID);
                    SchoolOneTitleByTypeRight3.TypeName = TypeModelRight3.VarTypeName;
                    SchoolOneTitleByTypeRight3.Count = TypeModelRight3.DisCount;
                }
                else
                {
                    this.divRight3.Visible = false;
                }
            }
        }

        public static string GetLikeName(object objstr, object strcss, object IntNewsTypeID)
        {
            string strName = objstr.ToString();
            return "<a href='#' onclick=\"GetThisSrc('" + IntNewsTypeID + "')\" class='more'>更多>></a><span><a href='#' onclick=\"GetThisSrc('" + IntNewsTypeID + "')\"><span class=" + strcss + ">" + strName + "</span></a></span>";
        }
  
    }
}
