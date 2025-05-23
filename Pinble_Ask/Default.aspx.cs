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
using System.Text;
using Pbzx.Common;

namespace Pinble_Ask
{
    public partial class Default : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UcQuestion1.Count =int.Parse(WebInit.siteconfig.CommendNum);
                UcQuestion2.Count = int.Parse(WebInit.siteconfig.HotNum);
                UcQuestion3.Count = int.Parse(WebInit.siteconfig.PointNum);
                UcQuestionR1.Count = int.Parse(WebInit.siteconfig.StateNNum);
                UcQuestionR2.Count = int.Parse(WebInit.siteconfig.StateYNum);
                Bulletin_r1.Count = int.Parse(WebInit.siteconfig.BarBulletin);
            
            }
        }
        

    }
}
