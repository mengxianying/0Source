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
    public partial class SoftTitle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private int _titleLength;

        public int TilteLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
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
        private int _elite;
        public int Elite
        {
            get { return _elite; }
            set { _elite = value; }
        }
        private int _hits;
        public int Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            StringBuilder strSql = new StringBuilder(" 1=1 ");
            
            if (Count > 0)
            {
                Count = Count;
            }         
            if (Type > 0)
            {
                strSql.Append(" and pb_ClassID'" + Type + "'");
            }
            strSql.Append(" and "+Method.product);
            if (Hits == -1)
            {
                strSql.Append(" ORDER BY pb_UpdateTime desc ");
            }
            else if (Hits == 3)
            {
                strSql.Append(" order by  pb_MonthHits desc");
            }
            else
            {
                strSql.Append(" ORDER BY pb_Hits desc ");
            }
            this.Repeater1.DataSource = MyBLL.GetListTitleCount(Count, strSql.ToString());
            this.Repeater1.DataBind();
        }
    }
}