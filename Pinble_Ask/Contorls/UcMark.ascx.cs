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

namespace Pinble_Ask.Contorls
{
    public partial class UcMark : System.Web.UI.UserControl
    {
        public int BianHao = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //绑定积分排行
                BindJFBang();
            }
        }
        public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex != -1)
            //{
            //    int id = e.Row.RowIndex + 1;

            //    e.Row.Cells[0].Text = "<a href='UserShow.aspx?name=" + Input.Encrypt(GridView1.DataKeys[e.Row.RowIndex]["ID"].ToString()) + "' target='_blank'><img src=\"images/N" + id.ToString() + ".jpg\" width=\"15\" height=\"12\" border='0' />" + "</a>";
            //}
        }

        /// <summary>
        /// 绑定积分排行
        /// </summary>
        private void BindJFBang()
        {
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            this.GridView1.DataSource = userBLL.Query(" select top 8 * from PBnet_ask_User where State=0 order by (Score - Pointpenalty-otherPointpenalty) DESC,OpenTime asc  ");
            this.GridView1.DataBind();
        }
    }
}