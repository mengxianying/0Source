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

namespace Pbzx.Web.PB_Manage
{
    public partial class Old_pb_adminLogEditor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["ID"]))
            {
                BindData(int.Parse(Request["ID"]));
            }

        }
        private void BindData(int ID)
        {
            
            Pbzx.BLL.PBnet_UserLog  adminLoginBLL = new Pbzx.BLL.PBnet_UserLog();
            Pbzx.Model.PBnet_UserLog model = adminLoginBLL.GetModel(ID);

            this.lbllog_username.Text = model.log_username;
            this.lblPWD.Text = model.log_password;
            this.lbllog_time.Text = model.log_time.ToString();
            lbllog_Ip.Text = model.log_Ip;
            lbllog_state.Text = model.log_state;
            lbllog_stepinto.Text = model.log_stepinto;
            lbllog_urlname.Text = model.log_urlname;
            lbllog_country.Text = model.log_country + "&nbps;" + model.log_city;
            lbllog_allhttp.Text = model.log_allhttp;
        }
    }
}
