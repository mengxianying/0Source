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
    public partial class ShoppingCartList : System.Web.UI.UserControl
    {

        public HiddenField _hdfSumPrice
        {
            get
            {
                return hdfSumPrice;
            }
            set
            {
                this.hdfSumPrice = value;
            }
        }
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
            string cartGuid = null;
            string type = "0";
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                if (Request["type"] == "1")
                {
                    type = "1";
                }
            }

           
            if(type == "0")
            {
                cartGuid =  Method.GetCartGuid();
            }
            else if(type =="1")
            {
                cartGuid = Method.GetDelegateCartGuid();
            }
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            DataSet dsShoppingCart = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            GridView1.DataSource = dsShoppingCart;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {
                lblMsg.Text = "���ﳵ��ǰΪ�գ�";
            }
            else
            {
                // lblSumQuatity.Text = SumQuatity.ToString();
                //LoginSort login = new LoginSort();
                //if (login[ELoginSort.delegate_User.ToString()])
                //{
                //    Pbzx.BLL.AgentInfo agentBll = new Pbzx.BLL.AgentInfo();
                //    Pbzx.Model.AgentInfo agentModel = agentBll.GetModelName(Method.Get_UserName);
                //    decimal tempPercent = WebFunc.GetCurrentPricePercent();
                //    //lblSumBookPrice.Text = string.Format("{0:C2}", SumBookPrice) + "*" + tempPercent + "=" + string.Format("{0:C2}", SumBookPrice * tempPercent);
                //    SumBookPrice = SumBookPrice * tempPercent;
                //}
                //else
                //{
                //    lblSumBookPrice.Text = string.Format("{0:C2}", SumBookPrice);
                //}
                //hdfSumPrice.Value = SumBookPrice.ToString();
            }
        }
        #endregion


        #region ͳ�����������ܼ۸�
        public  decimal SumBookPrice = (decimal)0.00;
        int SumQuatity = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string regType =  GridView1.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
                string[] strRegType = regType.Split(new char[]{'|'});
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
                Label  lblQuantity = (Label)e.Row.FindControl("lblQuantity");
                int quatity = Convert.ToInt32(lblQuantity.Text);
                SumQuatity += quatity;
                e.Row.Cells[3].Text = price.ToString("0.00");
                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[3].Text);
                SumBookPrice += totalBookPrice;
                //e.Row.Cells[3].Text = string.Format("{0:C2}", totalBookPrice);
                e.Row.Cells[3].Text = totalBookPrice + "Ԫ";
            }           
        }
        #endregion

        protected string CheckRegTye(object regType, object pb_TypeName, object pb_DemoUrl, object pb_RegUrl)
        {
            if(string.IsNullOrEmpty(regType.ToString()))
            {
                //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("����", "���Ĺ��ﳵ�����ע����Ϣ��д�����������Ȳ�������Ȼ���ύ", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                Response.Write("<script>alert('���Ĺ��ﳵ�����ע����Ϣ��д�����������Ȳ�������Ȼ���ύ');top.location='/ShowShoppingCart.aspx';</script>");
                //return;
            }
            else 
            {
                string[] strSZ = regType.ToString().Split(new char[] { '|' });
                if (string.IsNullOrEmpty(strSZ[0]) || string.IsNullOrEmpty(strSZ[1]))
                {
                    Response.Write("<script>alert('���Ĺ��ﳵ�����ע����Ϣ��д�����������Ȳ�������Ȼ���ύ');top.location='/ShowShoppingCart.aspx';</script>");
                  //  return;
                }
            }

            if (string.IsNullOrEmpty(regType.ToString()))
            {               
                return "��û��ѡ���κ�ע�᷽ʽ";
            }            
            else
            {  
                StringBuilder sb = new StringBuilder();
                string[] strSZ = regType.ToString().Split(new char[] { '|'});
                if(strSZ[0] == "8")
                {               
                    sb.Append("����ע�᷽ʽ��");
                    try
                    {
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
                                    sb.Append("��ʹ�����û�����" + strSZ[2]);
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
                    catch(Exception ex)
                    {
                        sb.Append("��ʹ�÷�ʽ");
                    }
                }
                else if(strSZ[0] == "1")
                {
                    sb.Append("�����󶨷�ʽ��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫ/��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }                     
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/��");                       
                    }
                    //����� ����ע�᷽ʽ��֤��
                    if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("����֤�룺" + strSZ[2]);
                    }                    
                }
                else if (strSZ[0] == "9")
                {
                    sb.Append("�������ʽ(����ǰ�����)��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫ/��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/��");
                    }
                    //����� ����ע�᷽ʽ��֤��
                    if (sb.Length > 16 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("����֤�룺" + strSZ[2]);
                    }
                }
                else if(strSZ[0] == "7")
                {
                    sb.Append("�������ʽ(�����������)��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                    }
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
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
                    decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(intPrice + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(intPrice2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }                  
                }
                else if(strSZ[0] =="6")
                {
                    sb.Append("�������ʽ(���������)��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {

                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫ/��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/��");
                    }                
                }
                return sb.ToString();
            }
        }
    }
}