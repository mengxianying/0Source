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

namespace Pbzx.Web.Contorls
{
    public partial class OrderInfo : System.Web.UI.UserControl
    {
        private bool _disPortType = false;

        /// <summary>
        /// 是否显示protType
        /// </summary>
        public bool DisPortType
        {
            get { return _disPortType; }
            set { _disPortType = value; }
        }

        private string type = "0";

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string txtZK1;

        public string TxtZK1
        {
            get { return txtZK1; }
            set { txtZK1 = value; }
        }

        private string txtZK2;

        public string TxtZK2
        {
            get { return txtZK2; }
            set { txtZK2 = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Panel pnlPortType = ((Panel)FormView1.FindControl("pnlPortType"));
                if(pnlPortType != null)
                {
                    pnlPortType.Visible = DisPortType; 
                }


            }
        }

        public void BindOrderInfo(string orderID)
        {
            decimal JJRZK = Method.GetCurrentPricePercent(orderID);
            if (decimal.Parse("1") == JJRZK)
            {
            }
            else
            {
                TxtZK1 = "代理折扣：";
                TxtZK2 = Convert.ToInt32(JJRZK * 100) + "%";
            }

            DataSet ds = null;
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                if (Request["type"] == "1")
                {
                    type = "1";
                }
            }
            if (type == "0")
            {
                ds = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(orderID);
            }
            else
            {
                ds = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(orderID);
            }
          
            FormView1.DataSource = ds;
            FormView1.DataBind();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                _HasNotPayedPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["HasNotPayedPrice"]);
                _TipID = Convert.ToInt32(ds.Tables[0].Rows[0]["TipID"]);
            }
        }

        private decimal _HasNotPayedPrice;
        public decimal HasNotPayedPrice
        {
            get { return _HasNotPayedPrice; }
            set { _HasNotPayedPrice = value; }
        }

        private int _TipID;
        public int TipID
        {
            get { return _TipID; }
            set { _TipID = value; }
        }
    }
}