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

        #region ��ȡ���ﳵ
        public void BindShoppingCart()
        {
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            GridView1.DataSource = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                lblMsg.Text = "���ﳵ��ǰΪ�գ�";
            }
            else
            {
                lblSumQuatity.Text = SumQuatity.ToString();
                lblSumBookPrice.Text = string.Format("{0:c}", SumBookPrice);
            }
        }
        #endregion

        #region ͳ�����������ܼ۸�
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
                return "��û��ѡ���κ�ע�᷽ʽ";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string[] strSZ = regType.ToString().Split(new char[] { '|' });
                if (strSZ[0] == "8")
                {

                    sb.Append("����ע�᷽ʽ��");
                    Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
                    DataSet ds = priceBLL.GetList(" VarVersionType='" + pb_TypeName.ToString() + "' ");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string useTime = row["VarUseTime"].ToString();
                        string price = row["VarPrice"].ToString();
                        string intPrice = price.Remove(price.IndexOf("Ԫ"));
                        if (strSZ.Length > 1 && !string.IsNullOrEmpty(strSZ[1]))
                        {
                            string[] priceSZ = strSZ[1].Split(new char[] { '&' });
                            if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                            {
                                price = priceSZ[0];
                                if (decimal.Parse(intPrice) == decimal.Parse(price))
                                {
                                    sb.Append(useTime + price + "Ԫ�� ������" + priceSZ[1]);
                                }
                            }
                            else
                            {
                                if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                                {
                                    sb.Append(useTime + price);
                                }
                            }
                            //����� ����ע�᷽ʽ�û���
                            if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                            {
                                sb.Append("��ע���û�����" + strSZ[2]);
                                break;
                            }
                        }
                        else
                        {
                            if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                            {
                                sb.Append("��ʹ�÷�ʽ");
                                break;
                            }
                        }
                    }
                }
                else if (strSZ[0] == "1")
                {
                    sb.Append("�����󶨷�ʽ��");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫһ��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "Ԫ/��");
                    }
                    //����� ����ע�᷽ʽ��֤��
                    if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("����֤�룺" + strSZ[2]);
                    }
                }
                else if (strSZ[0] == "9")
                {
                    sb.Append("�����ע�᷽ʽ���������������");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫһ��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "Ԫ/��");
                    }
                    //����� ����ע�᷽ʽ��֤��
                    if (sb.Length > 16 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("����֤�룺" + strSZ[2]);
                    }
                }
                else if (strSZ[0] == "7")
                {
                    sb.Append("�����ע�᷽ʽ�������������");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    decimal p1 = 0;
                    if (decimal.TryParse(intPrice, out p1))
                    {
                    }
                    else
                    {
                        intPrice = "";
                    }
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                    }
                    decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;


                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(intPrice + "Ԫһ�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(intPrice2 + "Ԫ���� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "Ԫ���� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }
                }
                return sb.ToString();
            }
        }
    }
}