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
using System.Text;
using System.Data.SqlClient;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class GetInstallType : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["SoftwareType"] != null && Request["SoftwareType"] != "")
            {
                string SoftwareType = Input.Filter(Request["SoftwareType"].ToString());
                Response.Write(GetData(SoftwareType));                
            }
            else
            {
                Response.Write("所有&");
            }

            Response.End();

        }
        /// <summary>
        /// 根据软件类型得到安装类型
        /// </summary>
        /// <param name="software"></param>
        /// <returns></returns>
        public string GetData(string  software)
        {
            StringBuilder strbu = new StringBuilder();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString2"]))
            {
                SqlCommand com1 = new SqlCommand("select SoftwareType ,InstallType,InstallName from CstSoftware where SoftwareName='" + software + "' ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "CstSoftware");

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    strbu.Append(row["InstallName"] + "&" + row["InstallType"] + ",");
                }
            }
            return strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "所有&";
        }

       
    }
}
