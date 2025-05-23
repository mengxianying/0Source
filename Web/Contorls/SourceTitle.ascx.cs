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
using Pbzx.Common;

namespace Pbzx.Web.Contorls
{
    public partial class SourceTitle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private int _tilteLength;
        public int TilteLength
        {
            get { return _tilteLength; }
            set { _tilteLength = value; }
        }
        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private int _type;
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private int _hits;
        public int Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Soft MyBLL = new Pbzx.BLL.PBnet_Soft();
            StringBuilder sb = new StringBuilder(" 1=1 ");
           
            if (Type > 0)
            { 
                sb.Append(" and pb_ClassID='" + Type + "' "); 
            }
            sb.Append(" and "+Method.soft);          
            if (Hits == 2)
            {
                sb.Append(" order by  pb_Hits "); 
            }
            else if (Hits == 3)
            {
                sb.Append(" order by  pb_MonthHits ");
            }
            else
            {
                sb.Append(" order by  pb_UpdateTime "); 
            }
            sb.Append(" desc ");
            this.Repeater1.DataSource = MyBLL.GetListTitleCount(Count, sb.ToString());
            this.Repeater1.DataBind();
        }       
    }
}