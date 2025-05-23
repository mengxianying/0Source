using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;

namespace Pinble_DataRivalry
{
    public partial class displayData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request["id"].ToString();

                DataSet ds = DbHelperSQL.Query("select Ct_num from v_d_num where F_drID=" + "'" + id + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    tbid.Text = disposeNum(ds.Tables[0].Rows[0]["Ct_num"].ToString());
                }
            }
        }
        public string disposeNum(string objNum)
        {
            var num = "";
            for (var i = 0; i < objNum.Split(',').Length; i++)
            {
                if (i != 0 && i % 10 == 0)
                {
                    num += "</br>";
                }
                num += objNum.Split(',')[i] + "&nbsp&nbsp";
            }
            return num;
        }
    }
}