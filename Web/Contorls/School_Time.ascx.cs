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
using System.Text;

namespace Pbzx.Web.Contorls
{
    public partial class School_Time : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private int _titleLength;

        public int TitleLength
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

        private string _typeName = "";

        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }
        private int _isHot;

        public int IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }
        private void BindData()
        {
            string strHot = "";
            if (IsHot > 0)
            {
                strHot = Method.CheckNewsHot(true);
            }
            else if (IsHot == 0)
            {
                strHot = "";
            }
            else
            {
                strHot = Method.CheckNewsHot(false);
            }
            
            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
            Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            if (!string.IsNullOrEmpty(TypeName))
            {
                Pbzx.Model.PBnet_NewsType typemodel = newsTypeBLL.GetModelByTypeName(TypeName);
                if (typemodel == null)
                {
                    return;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(" 1=1 ");
                    sb.Append(strHot);
                    sb.Append(" and IntShowType=" + typemodel.IntNewsTypeID + " ");
                    this.Repeater1.DataSource = newsBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " order by DatDateAndTime desc  ", this.Count);
                    this.Repeater1.DataBind();
                }
            }
            else {
                StringBuilder sb = new StringBuilder(" 1=1 ");
                sb.Append(strHot);
                this.Repeater1.DataSource = newsBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + "order by DatDateAndTime desc ", this.Count);
                this.Repeater1.DataBind();
            }
        }
    }
}