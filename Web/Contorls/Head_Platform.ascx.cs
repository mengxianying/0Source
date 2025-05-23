using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pbzx.Web.Contorls
{
    public partial class Head_Platform : System.Web.UI.UserControl
    {
        Pbzx.BLL.PBnet_platfrom_icon get_pmn = new BLL.PBnet_platfrom_icon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                datalist_platformBind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void datalist_platformBind()
        {
            DataSet ds = get_pmn.GetList(8, "P_state=0", " P_Sort desc");
            datalist_platform.DataSource = ds;
            datalist_platform.DataBind();
        }
    }
}