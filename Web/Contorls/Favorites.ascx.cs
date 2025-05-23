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

namespace Pbzx.Web.Contorls
{
    public partial class Favorites : System.Web.UI.UserControl
    {
        public event EventHandler Favorites_RowDeleting;
        public string FavoritesID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string backUrl = Input.FilterAll(Request["BackUrl"]);

                if (string.IsNullOrEmpty(backUrl))
                {
                   hyperGoBack.Visible = false;
                }
                else
                {
                  hyperGoBack.NavigateUrl = backUrl;
                }              
            }
        }

        public void BindFavorites(int userID)
        {
            DataSet ds = new Pbzx.BLL.PBnet_FavoritesBll().SelectFavoritesByUserID(userID);
            gvFavorites.DataSource = ds;
            gvFavorites.DataBind();

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                lblMsg.Text = "�����ղص������";
            }
            else
            {
                lblMsg.Text = "�ղص������¼��<font color='red'>" + ds.Tables[0].Rows.Count + "</font> ��";
            }
        }

        #region ɾ��
        protected void gvFavorites_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FavoritesID = gvFavorites.DataKeys[e.RowIndex].Value.ToString();            
            Favorites_RowDeleting(this, e);
        }
        #endregion
    }
}