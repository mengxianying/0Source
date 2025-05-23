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
    public partial class DelegateProductList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShoppingCart();
            }
        }

        #region 获取购物车
        public void BindShoppingCart()
        {
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            GridView1.DataSource = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                lblMsg.Text = "购物车当前为空！";
            }
            else
            {
                lblSumQuatity.Text = SumQuatity.ToString();
                lblSumBookPrice.Text = string.Format("{0:c}", SumBookPrice);
            }
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
                e.Row.Cells[3].Text = string.Format("{0:c}", totalBookPrice);
            }
        }
        #endregion

        protected string CheckRegTye(object regType, object pb_TypeName, object pb_DemoUrl, object pb_RegUrl)
        {

            if (string.IsNullOrEmpty(regType.ToString()))
            {
                return "您没有选择任何注册方式";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string[] strSZ = regType.ToString().Split(new char[] { '|' });
                if (strSZ[0] == "8")
                {

                    sb.Append("网络注册方式：");
                    Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
                    DataSet ds = priceBLL.GetList(" VarVersionType='" + pb_TypeName.ToString() + "' ");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string useTime = row["VarUseTime"].ToString();
                        string price = row["VarPrice"].ToString();
                        string intPrice = price.Remove(price.IndexOf("元"));
                        if (strSZ.Length > 1 && !string.IsNullOrEmpty(strSZ[1]))
                        {
                            string[] priceSZ = strSZ[1].Split(new char[] { '&' });
                            if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                            {
                                price = priceSZ[0];
                                if (decimal.Parse(intPrice) == decimal.Parse(price))
                                {
                                    sb.Append(useTime + price + "元， 天数：" + priceSZ[1]);
                                }
                            }
                            else
                            {
                                if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                                {
                                    sb.Append(useTime + price);
                                }
                            }
                            //后添加 网络注册方式用户名
                            if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                            {
                                sb.Append("；注册用户名：" + strSZ[2]);
                                break;
                            }
                        }
                        else
                        {
                            if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                            {
                                sb.Append("无使用方式");
                                break;
                            }
                        }
                    }
                }
                else if (strSZ[0] == "1")
                {
                    sb.Append("单机绑定方式：");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("元"));


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("元"));
                    if (pb_TypeName.ToString() == "专业版")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "元一年");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "元/套");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "元/套");
                    }
                    //后添加 单机注册方式认证码
                    if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("；认证码：" + strSZ[2]);
                    }
                }
                else if (strSZ[0] == "9")
                {
                    sb.Append("软件狗注册方式（不买软件狗）：");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("元"));


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("元"));
                    if (pb_TypeName.ToString() == "专业版")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "元一年");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "元/套");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "元/套");
                    }
                    //后添加 单机注册方式认证码
                    if (sb.Length > 16 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("；认证码：" + strSZ[2]);
                    }
                }
                else if (strSZ[0] == "7")
                {
                    sb.Append("软件狗注册方式（买软件狗）：");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("元"));
                    decimal p1 = 0;
                    if (decimal.TryParse(intPrice, out p1))
                    {
                    }
                    else
                    {
                        intPrice = "";
                    }
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("元"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                    }
                    decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;


                    if (pb_TypeName.ToString() == "专业版")
                    {
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(intPrice + "元一年 + " + WebInit.webBaseConfig.SoftdogPrice + "元");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(intPrice2 + "元终身 + " + WebInit.webBaseConfig.SoftdogPrice + "元");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "元终身 + " + WebInit.webBaseConfig.SoftdogPrice + "元");
                    }
                }
                return sb.ToString();
            }
        }
    }
}