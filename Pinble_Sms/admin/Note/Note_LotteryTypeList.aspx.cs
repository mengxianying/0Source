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
using Pbzx.BLL;
using Maticsoft.DBUtility;

namespace Pinble_Market.admin.Note
{
    public partial class Note_LotteryTypeList : System.Web.UI.Page
    {

        Note_Customize notebll = new Note_Customize();
        Note_LotteryType typebll = new Note_LotteryType();

        Pbzx.BLL.Note_LotteryIssue lotteryIssbll = new Note_LotteryIssue();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindList();

            }
        }

        private void BindList()
        {
            GridView1.DataSource = typebll.GetLists();
            GridView1.DataBind();
        }

        public string Ren(object obj)
        {

            if (obj.ToString() != "")
            {

                DataSet ds = notebll.GetList("SID=" + obj.ToString());
                if (ds != null)
                {
                    return ds.Tables[0].Rows.Count.ToString();
                }
            }
            return "0";
        }

        public string ISGK(object obj)
        {
            if ((bool)obj)
            {
                return "��";
            }
            return "��";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //�޸�
            if (e.CommandName == "Up")
            {
                Response.Redirect("Note_LotteryTypeEdit.aspx?sid=" + e.CommandArgument);
            }
            else if (e.CommandName == "De")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('ִ��ɾ����');", true);
            }
            else if (e.CommandName == "xx")
            {
                Response.Redirect("Note_Admin_ManagerList.aspx?Sid=" + e.CommandArgument);
            }
        }

        /// <summary>
        /// �����а��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbt = e.Row.FindControl("linkbutdelete") as LinkButton;
                lbt.Attributes.Add("onclick", "return confirm('���Ҫɾ����');");
            }

        }

        /// <summary>
        /// ��Ϣ¼��״̬
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string MsgStatus(object obj)
        {
            //�жϽ����Ƿ񷢲���Ϣ��
            DataSet ds = DbHelperSQL.Query("SELECT TOP 1 BeginTime FROM Note_LotteryIssue WHERE (SID = " + obj.ToString() + ") ORDER BY BeginTime DESC");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime td = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"]);
                if (td.Year == DateTime.Now.Year && td.Month == DateTime.Now.Month && td.Day == DateTime.Now.Day)
                {
                    return "<a href='Note_LotteryIssueList.aspx?SID=" + obj.ToString() + "'>�����ѷ���</a>";
                }
            }
            return "<a href='Note_LotteryIssueList.aspx?SID=" + obj.ToString() + "'>����δ����</a>";



        }

        /// <summary>
        /// �������·���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnfw_Click(object sender, EventArgs e)
        {
            Response.Redirect("Note_LotteryTypeEdit.aspx");
        }
    }
}
