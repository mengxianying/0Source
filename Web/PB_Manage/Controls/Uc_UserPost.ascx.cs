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
using System.Text;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class Uc_UserPost : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet dsBoard = DbHelperSQLBBS.Query("select boardid,BoardType from Dv_Board ");
                //this.ddlBoard.DataSource = dsBoard;
                //this.ddlBoard.DataTextField = "BoardType";
                //this.ddlBoard.DataValueField = "boardid";
                //this.ddlBoard.DataBind();
                foreach(DataRow row in dsBoard.Tables[0].Rows)
                {
                    this.ddlBoard.Items.Add(new ListItem(Input.FilterHTML(row["BoardType"].ToString()), row["boardid"].ToString()));
                }
                this.ddlBoard.Items.Insert(0,new ListItem("Ыљга",""));
                this.ddlBoard.Items[0].Selected = true;
                

                Method.BindText(txtParentID, "ParentID", true);
                Method.BindText(txtAnnounceID, "AnnounceID", true); 
                Method.BindDdlOrRadio(this.ddlBoard, "boardid", true);

                Method.BindText(txtPostTable, "PostTable", true);
                Method.BindDdlOrRadio(this.ddlisbest, "isbest", true);
                Method.BindDdlOrRadio(this.ddllocktopic, "locktopic", true);
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bbs_Userpost.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();

            bu1.Append(Method.BindText(txtParentID, "ParentID", false));
            bu1.Append(Method.BindText(txtAnnounceID, "AnnounceID", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlBoard, "boardid", false));


            bu1.Append(Method.BindText(txtPostTable, "PostTable", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlisbest, "isbest", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddllocktopic, "locktopic", false));

            Response.Redirect("Bbs_Userpost.aspx?" + bu1.ToString());
        }
    }
}