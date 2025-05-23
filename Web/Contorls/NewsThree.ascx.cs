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

namespace Pbzx.Web.Contorls
{
    public partial class NewsThree : System.Web.UI.UserControl
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

     //   private string _intTypeLevel = "";

        //public string IntTypeLevel
        //{
        //    get { return _intTypeLevel.Trim(); }
        //    set { _intTypeLevel = value; }
        //}



        private void BindData()
        {
            Pbzx.BLL.PBnet_News MyBLL = new Pbzx.BLL.PBnet_News();
            //if (!string.IsNullOrEmpty(IntTypeLevel))
            //{
            //    this.DataList1.DataSource = MyBLL.GetTitleListByCount(" IntShowType=" + IntTypeLevel + " order by BitIsHot desc  ", this.Count);
            //    this.DataList1.DataBind();
            //}
            //else
            //{
                this.DataList1.DataSource = MyBLL.GetTitleListByCount("  1=1  order by BitIsHot desc  ", this.Count);
                this.DataList1.DataBind();
           // }
        }
    }
}