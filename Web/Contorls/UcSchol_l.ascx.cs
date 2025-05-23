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
using Maticsoft.DBUtility;

namespace Pbzx.Web.Contorls
{
    public partial class UcSchol_l : System.Web.UI.UserControl
    {
        private string _schoolTypeChannel = "";
      //  public string lblLeft2ID = "";

        public string SchoolTypeChannel
        {
            get { return _schoolTypeChannel; }
            set { _schoolTypeChannel = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClass();            

                UcSchoolHot1.Count = int.Parse(WebInit.pageConfig.ScholHotCount);

                Pbzx.BLL.PBnet_SchoolType TypeBll = new Pbzx.BLL.PBnet_SchoolType();
                Pbzx.Model.PBnet_SchoolType TypeModelLeft1 = TypeBll.GetModelName("左一");
                if (TypeModelLeft1 != null)
                {
                    this.lblLeft1.Text = GetLikeName(TypeModelLeft1.VarTypeName, "title2", TypeModelLeft1.IntNewsTypeID);
                    SchoolOneTitleByTypeLeft1.TypeName = TypeModelLeft1.VarTypeName;
                    SchoolOneTitleByTypeLeft1.Count = TypeModelLeft1.DisCount;
                }
                else
                {
                    this.divLeft1.Visible = false;
                }

                Pbzx.Model.PBnet_SchoolType TypeModelLeft2 = TypeBll.GetModelName("左二");
                if (TypeModelLeft2 != null)
                {
                    this.lblLeft2.Text = GetLikeName(TypeModelLeft2.VarTypeName, "title2", TypeModelLeft2.IntNewsTypeID);
                    //lblLeft2ID.Text = TypeModelLeft2.IntNewsTypeID;
                    SchoolOneTitleByTypeLeft2.TypeName = TypeModelLeft2.VarTypeName;
                    SchoolOneTitleByTypeLeft2.Count = TypeModelLeft2.DisCount;
                }
                else
                {
                    this.divLeft2.Visible = false;
                }

                Pbzx.Model.PBnet_SchoolType TypeModelLeft3 = TypeBll.GetModelName("左三");
                if (TypeModelLeft3 != null)
                {
                    this.lblLeft3.Text = GetLikeName(TypeModelLeft3.VarTypeName, "title2", TypeModelLeft3.IntNewsTypeID);
                    SchoolOneTitleByTypeLeft3.TypeName = TypeModelLeft3.VarTypeName;
                    SchoolOneTitleByTypeLeft3.Count = TypeModelLeft3.DisCount;
                }
                else
                {
                    this.divLeft3.Visible = false;
                }

            }
        }
        private void BindClass()
        {
            StringBuilder sbWhere = new StringBuilder(" 1=1 ");
            Pbzx.BLL.PBnet_SchoolType MyBLL = new Pbzx.BLL.PBnet_SchoolType();
            DataSet ds = null;
            if (!string.IsNullOrEmpty(_schoolTypeChannel))
            {
                ds = DbHelperSQL.Query("select top " + WebInit.pageConfig.ScholTypeCount + " * from PBnet_SchoolType where  BitIsAuditing=1 and IntTypeLevel='" + _schoolTypeChannel + "' order by IntSortID  ");
            }
            else
            {
                ds = DbHelperSQL.Query("select top " + WebInit.pageConfig.ScholTypeCount + "  * from PBnet_SchoolType where  BitIsAuditing=1  order by IntSortID  ");
                // top " + WebInit.pageConfig.NewsTypeCount + " 
            }
            this.dtType.DataSource = ds;
            this.dtType.DataBind();
        }
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    StringBuilder bu = new StringBuilder("");
        //    bu.Append(Method.BindText(txtSearch, "strSearch", false));

        //    Response.Redirect("School.htm?" + bu.ToString());
        //}


        public static string GetLikeName(object objstr, object strcss, object IntNewsTypeID)
        {
            string strName = objstr.ToString();
            return "<a href='#' onclick=\"GetThisSrc('" + IntNewsTypeID + "')\" class='more'>更多>></a><span><a href='#' onclick=\"GetThisSrc('" + IntNewsTypeID + "')\"><span class=" + strcss + ">" + strName + "</span></a></span>";
        }
    }
}