using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pinble_Chat.Contorls
{
    public partial class Head_ChatHav : System.Web.UI.UserControl
    {
        Pbzx.BLL.PBnet_platfrom_icon get_plf = new Pbzx.BLL.PBnet_platfrom_icon();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Binddata_navigation();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>

        public void Binddata_navigation()
        {

            DataSet ds = get_plf.GetList(8, "P_state=0", " P_Sort asc");
            //data_navigation.DataSource = ds;
            //data_navigation.DataBind();
            data_nav.DataSource = ds;
            data_nav.DataBind();
        }
    }
}