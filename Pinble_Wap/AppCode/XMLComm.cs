using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;

namespace Pinble_Wap
{
    public static class XMLComm
    {
        public static int GetXMls(string cpName)
        {
            WapBase wapbase = new WapBase();
            DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from  " + cpName + " order by issue desc ");
            DataRow row = dsAppData.Tables[0].Rows[0];
            switch (cpName)
            {
                case "FC3DData":
                  wapbase.Issue= row["issue"].ToString();
                  WapWebInit.web3DBaseConfig = wapbase;
                    break;
                case "TCPL35Data":
                  
                    break;
                case "TC7XCData_New":
                   
                    break;
                case "FC7LC":

                    break;
                case "FCSSData":
 
                    break;
                case "TCDLTData":
                   
                    break;
                case "TC22X5Data":
                   
                    break;
                case "TC31X7Data":
                 
                    break;

            }
            return 0;
        }
    }
}
