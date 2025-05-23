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

namespace Pbzx.Web
{
    public partial class Buy_mianfei : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPUt();
                BindGuiB();
            }
        }
        private void BindPUt()
        {
            Pbzx.BLL.CN_Software softwareBll = new Pbzx.BLL.CN_Software();
            rptPUt.DataSource = softwareBll.GetList(" Flag=1 and Status=0");
            rptPUt.DataBind();
        
        }
        private void BindGuiB()
        {
            Pbzx.BLL.CN_Software softwareBll = new Pbzx.BLL.CN_Software();
            rptGuiB.DataSource = softwareBll.GetList(" Flag=1 and Status=0 and SUBSTRING(MinDays, 9, 1) <= '7'");
            rptGuiB.DataBind();

        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();


            string[] result = softBLL.Chksettype(num, st);
            return  result[0] + "(" + result[1] + ")";
        }
        protected string showBoards(object boards)
        {
            string result = "";
            string newboars = boards.ToString();
            string[] fbs = newboars.Split(new char[] { '|' });
            foreach (string str in fbs)
            {
                if (str != "")
                {
                    DataSet dsBoard = DbHelperSQLBBS.Query("select BoardType from Dv_Board where boardid='" + str + "'");

                    result += dsBoard.Tables[0].Rows[0]["BoardType"].ToString();
                 
                }
            }            
            return result;
        }
        protected string GetTies(object tieshu, object weishu)
        {
            string newtieshu = tieshu.ToString();
            string[] fbs = newtieshu.Split(new char[] { '|' });

            return fbs[Convert.ToInt32(weishu)];

        }
    }
}
