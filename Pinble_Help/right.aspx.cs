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

namespace Pinble_Help
{
    public partial class right : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        /// <summary>
        /// 帮助文件说明数据绑定
        /// </summary>
        private void bind()
        {
            string Noet = Request["noet"].ToString();
            DataSet ds = get_ts.GetList("Tree_num=" + "'"+ Noet +"'");

            string content = ds.Tables[0].Rows[0]["Tree_countent"].ToString();
            
            htmlText.InnerHtml = content;

        }

    }
}
