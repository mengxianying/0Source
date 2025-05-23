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
using Maticsoft.DBUtility;

namespace Pinble_Ask
{
    public partial class TopScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData(); 
            }
        }

        private void BindData()
        {
            DataSet dsUsers = DbHelperSQL.Query("select Top 100 ID,UserName,Point,Pointpenalty,OtherPointpenalty,Score from PBnet_ask_User where State=0 order by (Score - Pointpenalty-otherPointpenalty) DESC,OpenTime asc ");
            this.MyGridView.DataSource = dsUsers;
            this.MyGridView.DataBind();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        /// <summary>
        /// 根据用户ID得到用户头衔
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserTitle(object userID)
        {
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            if (string.IsNullOrEmpty(userID.ToString()))
            {
                return "";
            }
            return userBLL.GetTitleByID((int)userID);
        }
    }
}
