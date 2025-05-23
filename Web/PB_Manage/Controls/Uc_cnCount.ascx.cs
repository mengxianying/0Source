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
using Pbzx.Common;
using System.Text;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class Uc_cnCount : System.Web.UI.UserControl
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
                foreach (DataRow row in dsBoard.Tables[0].Rows)
                {
                    this.ddlBoard.Items.Add(new ListItem(Input.FilterHTML(row["BoardType"].ToString()), row["boardid"].ToString()));
                }
                this.ddlBoard.Items.Insert(0, new ListItem("Ыљга", ""));
                this.ddlBoard.Items[0].Selected = true;


                Method.BindText(txtUserName, "UserName", true);

                Method.BindText(txtNormalTopicCount, "NormalTopicCount", true);

                Method.BindText(txtBestTopicCount, "BestTopicCount", true);


                Method.BindText(txtNormalAnnounceCount, "NormalAnnounceCount", true);

                Method.BindText(txtBestAnnounceCount, "BestAnnounceCount", true);



                Method.BindText(txtDelTopicCount, "DelTopicCount", true);

                Method.BindText(txtDelAnnounceCount, "DelAnnounceCount", true);

                Method.BindText(txtDelAnnounceCount, "TotalTopicCount", true);

                Method.BindText(txtTotalAnnounceCount, "TotalAnnounceCount", true);

                //
                Method.BindDdlOrRadio(this.ddlBoard, "BoardID", true);
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("US_cn_count.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {


            StringBuilder bu1 = new StringBuilder();



            bu1.Append(Method.BindText(txtUserName, "UserName", true));

            bu1.Append(Method.BindText(txtNormalTopicCount, "NormalTopicCount", true));

            bu1.Append(Method.BindText(txtBestTopicCount, "BestTopicCount", true));


            bu1.Append(Method.BindText(txtNormalAnnounceCount, "NormalAnnounceCount", true));

            bu1.Append(Method.BindText(txtBestAnnounceCount, "BestAnnounceCount", true));



           bu1.Append(Method.BindText(txtDelTopicCount, "DelTopicCount", true));

           bu1.Append(Method.BindText(txtDelAnnounceCount, "DelAnnounceCount", true));

           bu1.Append(Method.BindText(txtDelAnnounceCount, "TotalTopicCount", true));

           bu1.Append(Method.BindText(txtTotalAnnounceCount, "TotalAnnounceCount", true));

            //
           bu1.Append(Method.BindDdlOrRadio(this.ddlBoard, "BoardID", true));


           Response.Redirect("US_cn_count.aspx?" + bu1.ToString());
        }
    }
}