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
    public partial class OrderDetail2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region 获取订单清单
        public void BindOrderDetail(string orderID)
        {
            Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
            GridView1.DataSource = orderDetailBll.SelectOrderDetailByOrderID(orderID);
            GridView1.DataBind();
            lblSumQuatity.Text = SumQuatity.ToString();
            lblSumBookPrice.Text = string.Format("{0:C2}", SumBookPrice);
        }
        #endregion

        #region 统计总数量和总价格
        decimal SumBookPrice = (decimal)0.00;
        int SumQuatity = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string regType = GridView1.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
                string[] strRegType = regType.Split(new char[] { '|' });
                decimal price = 0;
                if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                {
                    string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        price = decimal.Parse(strRegType[1]);
                    }
                }
                Label lblQuantity = (Label)e.Row.FindControl("lblQuantity");
                int quatity = Convert.ToInt32(lblQuantity.Text);
                SumQuatity += quatity;
                e.Row.Cells[3].Text = Convert.ToString(quatity * price);

                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[3].Text);
                SumBookPrice += totalBookPrice;
                e.Row.Cells[3].Text = string.Format("{0:C2}", totalBookPrice);
            }
        }
        #endregion
   



    }
}