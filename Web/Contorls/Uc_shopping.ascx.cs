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
using Maticsoft.DBUtility;

namespace Pbzx.Web.Contorls
{
    public partial class Uc_shopping : System.Web.UI.UserControl
    {
        decimal SumBookPrice = (decimal)0.00;
        int SumQuatity = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindShoppingCart();
                LoginSort login = new LoginSort();
                if (login["manager_user"])
                {
                    Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                    orderBll.GetList(" TipID='2' or TipID='3'  ");
                    int countRG = Convert.ToInt32(DbHelperSQL.GetSingle(" select count(1) from PBnet_Orders where UserName='" + Input.FilterAll(Method.Get_UserName) + "' and (TipID='2' or TipID='3') and IsCancel=0 and IsPay='0' and Type=1 "));
                    int countZD = Convert.ToInt32(DbHelperSQL.GetSingle(" select count(1) from PBnet_Orders where UserName='" + Input.FilterAll(Method.Get_UserName) + "' and (TipID='2') and IsCancel=0  and Type=0 "));
                    int countTotal = countRG + countZD;
                    if (countTotal > 0)
                    {
                        this.lblOrderCount.Text = "（" + Convert.ToString(countRG + countZD) + "）";
                    }
                    else
                    {
                        this.lblOrderCount.Text = "";  
                    }                    
                }
                else
                {
                    this.lblOrderCount.Text = "";  
                }
            }
        }
        #region 获取购物车
        public string  BindShoppingCart()
        {
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();

            DataSet dsProducts = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
            {
                 //lblMsg.Text = "购物车当前为空！";
                //spPrice.Visible = false;
                return "false";
            }
            else
            {
                spPrice.Visible = true;   
                this.MyGridView.DataSource = dsProducts;
                this.MyGridView.DataBind();
            }
            this.lblSumPrice.InnerText = WebFunc.CalcTotalPrice().ToString();
            this.lblCount.Text = SumQuatity.ToString();
            return "true";
        }
        #endregion

        public void UpdateShoppingCart()
        {
            this.UpdatePanel1.Update();
        }

        #region 统计总数量和总价格

        protected void GridView1_RowDataBound(object sender,  GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string regType = MyGridView.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
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
                SumQuatity += 1;
                e.Row.Cells[2].Text = Convert.ToString(1 * price);
                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[2].Text);
                SumBookPrice += totalBookPrice;
                e.Row.Cells[2].Text = string.Format("{0:C2}", totalBookPrice);
                e.Row.Cells[2].Style.Value = "color:#FF0000;";
            }
        }
        #endregion

        /// <summary>
        ///清空购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnClearShoppingCart_Click(object sender, ImageClickEventArgs e)
        //{
        //    WebFunc.ClearCart(Method.GetCartGuid());
        //    BindShoppingCart();
        //    lblSumPrice.InnerText = "0.00";
        //}



        #region 结算
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddOrder.aspx");
        }
        #endregion



        //protected void lbtnDel_Command(object sender, CommandEventArgs e)
        //{
        //    WebFunc.DelShoppingCartByID(e.CommandArgument.ToString());
        //    BindShoppingCart();
        //    this.lblSumPrice.InnerText = WebFunc.CalcTotalPrice().ToString();
        //}
      
        protected void btnMengRef_ServerClick(object sender, EventArgs e)
        {
            BindShoppingCart();
            Page.RegisterStartupScript(WebFunc.GetGuid(),"<script>document.getElementById('dvTest').style.display='';</script>");

        }

        



    }
}