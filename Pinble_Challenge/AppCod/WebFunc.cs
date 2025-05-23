using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Pinble_Challenge.AppCod
{
    public class WebFunc
    {

        static object sysobj = new object();
        /// <summary>
        /// ��ʽע�᷽ʽ
        /// </summary>
        /// <param name="regType"></param>
        /// <param name="pb_TypeName"></param>
        /// <param name="pb_DemoUrl"></param>
        /// <param name="pb_RegUrl"></param>
        /// <returns></returns>
        public static string CheckRegTye(object regType, object pb_TypeName, object pb_DemoUrl, object pb_RegUrl)
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
                                        sb.Append(useTime + price + "Ԫ��������" + priceSZ[1]);
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
                                if (string.IsNullOrEmpty(strSZ[1]))
                                {
                                    sb.Append("δѡ����Ʒ����");
                                    return sb.ToString();
                                }
                                if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                                {
                                    sb.Append("��ʹ�÷�ʽ");
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sb.Append("��ʹ�÷�ʽ");
                    }
                }
                else if (strSZ[0] == "1")
                {
                    sb.Append("�����󶨷�ʽ��");
                    if (string.IsNullOrEmpty(strSZ[1]))
                    {
                        sb.Append("δѡ����Ʒ����");
                        return sb.ToString();
                    }



                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        if (string.IsNullOrEmpty(strSZ[1]))
                        {
                            sb.Append("��ʹ�÷�ʽ");
                            return sb.ToString();
                        }
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
                    sb.Append("�������ʽ(����ǰ�����)��");
                    if (string.IsNullOrEmpty(strSZ[1]))
                    {
                        sb.Append("δѡ����Ʒ����");
                        return sb.ToString();
                    }

                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
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
                    sb.Append("�������ʽ(�����������)��");
                    if (string.IsNullOrEmpty(strSZ[1]))
                    {
                        sb.Append("δѡ����Ʒ����");
                        return sb.ToString();
                    }


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                    }
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;


                    if (pb_TypeName.ToString() == "רҵ��")
                    {
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
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(intPrice + "Ԫһ�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(intPrice2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }
                }
                else if (strSZ[0] == "6")
                {

                    sb.Append("�������ʽ(���������)��");
                    if (string.IsNullOrEmpty(strSZ[1]))
                    {
                        sb.Append("δѡ����Ʒ����");
                        return sb.ToString();
                    }

                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��")
                    {

                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
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
                }
                return sb.ToString();
            }
        }


        public static string CheckRegTyeDL(object regType, object pb_TypeName, object pb_DemoUrl, object pb_RegUrl)
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
                        decimal decPrice = decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent();
                        if (strSZ.Length > 1 && !string.IsNullOrEmpty(strSZ[1]))
                        {
                            string[] priceSZ = strSZ[1].Split(new char[] { '&' });
                            if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                            {
                                price = priceSZ[0];
                                if (decPrice == decimal.Parse(price))
                                {
                                    sb.Append(useTime + price + "Ԫ�� ������" + priceSZ[1]);
                                }
                            }
                            else
                            {
                                if (decPrice == decimal.Parse(strSZ[1]))
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
                            if (decPrice == decimal.Parse(strSZ[1]))
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


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent());

                    if (pb_TypeName.ToString() == "רҵ��")
                    {

                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent());
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
                    sb.Append("�������ʽ(����ǰ�����)��");



                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent());

                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent());
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
                    sb.Append("�������ʽ(�����������)��");


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                        p2 = p2 * WebFunc.GetCurrentPricePercent();
                    }
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        decimal p1 = 0;
                        if (decimal.TryParse(intPrice, out p1))
                        {
                            p1 = p1 * WebFunc.GetCurrentPricePercent();
                        }
                        else
                        {
                            intPrice = "";
                        }
                        decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(p1 + "Ԫһ�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(p2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(p2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }
                }
                else if (strSZ[0] == "6")
                {
                    sb.Append("�������ʽ(���������)��");


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent());

                    if (pb_TypeName.ToString() == "רҵ��")
                    {

                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent());
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
                }
                return sb.ToString();
            }
        }



        public static string CheckRegTyeDL(object regType, object pb_TypeName, object pb_DemoUrl, object pb_RegUrl, object OrderID)
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
                        decimal decPrice = decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent(OrderID);
                        if (strSZ.Length > 1 && !string.IsNullOrEmpty(strSZ[1]))
                        {
                            string[] priceSZ = strSZ[1].Split(new char[] { '&' });
                            if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                            {
                                price = priceSZ[0];
                                if (decPrice == decimal.Parse(price))
                                {
                                    sb.Append(useTime + price + "Ԫ�� ������" + priceSZ[1]);
                                }
                            }
                            else
                            {
                                if (decPrice == decimal.Parse(strSZ[1]))
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
                            if (decPrice == decimal.Parse(strSZ[1]))
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


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent(OrderID));

                    if (pb_TypeName.ToString() == "רҵ��")
                    {

                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent(OrderID));
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
                    sb.Append("�������ʽ(����ǰ�����)��");

                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent(OrderID));

                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent(OrderID));
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
                    sb.Append("�������ʽ(�����������)��");


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                        p2 = p2 * WebFunc.GetCurrentPricePercent(OrderID);
                    }

                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        decimal p1 = 0;
                        if (decimal.TryParse(intPrice, out p1))
                        {
                            p1 = p1 * WebFunc.GetCurrentPricePercent(OrderID);
                        }
                        else
                        {
                            intPrice = "";
                        }
                        decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(p1 + "Ԫһ�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(p2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(p2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }
                }
                else if (strSZ[0] == "6")
                {
                    sb.Append("�������ʽ(���������)��");


                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent(OrderID));

                    if (pb_TypeName.ToString() == "רҵ��")
                    {
                        string danj = pb_DemoUrl.ToString();
                        string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                        intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent(OrderID));
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
                }
                return sb.ToString();
            }


        }


        /// <summary>
        /// ����ʡ���Ƶõ�ʡ��Ӧ��
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static object GetProvinceIdByName(string province)
        {
            return DbHelperSQL.GetSingle("select top 1  Code from PBnet_Province where name='" + province + "' ");
        }

        /// <summary>
        /// �����ע��
        /// </summary>
        /// <returns></returns>
        public static string[] CalGZM(string code, string tcode, string nextTcode)
        {
            string cstJin = "";
            string HL1 = "";
            string HL2 = "";
            string deTestCode = "";

            string abc = code; //code
            string jabc = tcode;//tcode
            string he = Method.Qhe(abc);
            string jhe = Method.Qhe(jabc);
            string _jhe = Method.Qhe(nextTcode);
            ///��һ���Ի��ţ�s(-1,jabc) = row1["testcode"]

            int a = int.Parse(abc.Substring(0, 1));
            int b = int.Parse(abc.Substring(1, 1));
            int c = int.Parse(abc.Substring(2, 1));
            int[] gsCode = new int[7];

            //��ʽ1��  ȡһ�����������ŵ�β��������λ�Ӻ͵�λ��Ϊ1����һ���Ի��ţ��� ��+ ��λ�Ӻ͵�λ��Ϊ1����ǰ�������ţ� ��                                   
            gsCode[0] = Method.END(Method.BSUM(nextTcode) + Method.BSUM(abc));  //end(bsum(s(-1,jabc),1)+bsum(abc,1))  

            //��ʽ2��
            gsCode[1] = Method.END(10 + Method.BSUM(abc) - Method.BSUM(nextTcode));//end(10+bsum(abc,1)-bsum(s(-1,jabc),1))

            //��ʽ3��
            ///gsCode[2] = Method.END(10 + Method.BSUM(sjabc) - Method.BSUM(jabc));//end(10+bsum(s(-1,jabc),1)-bsum(jabc,1))
            gsCode[2] = Method.BSUM(Convert.ToString(Method.Qkd(abc) * Method.HW(he) + Method.BSUM(nextTcode) * 3 - Method.BSUM(jabc) * 2));//BSUM(kd*hw+BSUM(S(-1,JABC),1)*3-BSUM(JABC,1)*2,1)

            //��ʽ4��
            //gsCode[3] = Method.END(Method.BSUM(sjabc) + Method.BSUM(abc) + Method.BSUM(jabc));//end(bsum(s(-1,jabc),1)+bsum(abc,1)+bsum(jabc,1))
            gsCode[3] = Method.END(Method.BSUM(nextTcode) + Method.BSUM(abc) * 2 + Method.BSUM(jabc) * 3);    // END(BSUM(S(-1,JABC),1)+BSUM(ABC,1)*2+BSUM(JABC,1)*3)		                                                   

            //��ʽ5��
            /// gsCode[4] = Method.END(Method.BSUM(sjhe + Method.Qkd(sjabc)) + Method.BSUM(he + Method.Qkd(abc)) + Method.BSUM(jhe + Method.Qkd(sjabc)));//end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))                               
            gsCode[4] = Method.END(Method.BSUM(Convert.ToString(Convert.ToUInt32(_jhe) + Method.Qkd(nextTcode))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + Method.Qkd(abc))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(jhe) + Method.Qkd(jabc))));//' end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))


            //��ʽ6:
            //gsCode[5] = Method.BSUM(he + 3 * a + 2 * b + c);//bsum(he+3*A+2*B+c,1)
            gsCode[5] = Method.BSUM(Convert.ToString(Method.Qkd(abc) + 3 * a + 2 * b + c)); // BSUM(KD+3*A+2*B+C,1)

            //��ʽ7:
            //gsCode[6] = Method.BSUM(he + a + 2 * b + 3 * c);//bsum(he+A+2*B+3*c,1)
            gsCode[6] = Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + 2 * Method.Qkd(abc) + 3 * Method.HW(he)));              //BSUM(HE+2*KD+3*HW,1)

            int[] codeCount = new int[7];
            for (int i = 0; i < codeCount.Length; i++)
            {
                codeCount[i] = 0;
            }
            string[] Result = new string[7];
            SortedList sortCode = new SortedList();
            ArrayList arrCount = new ArrayList();
            for (int i = 0; i < gsCode.Length; i++)
            {
                for (int j = 0; j < gsCode.Length; j++)
                {
                    if (gsCode[i] == gsCode[j])
                    {
                        codeCount[i]++;
                    }
                }
                if (!sortCode.ContainsKey(codeCount[i] + "" + gsCode[i]))
                {
                    sortCode.Add(codeCount[i] + "" + gsCode[i], gsCode[i]);
                    arrCount.Add(codeCount[i] + "" + (7 - i) + "" + gsCode[i]);
                }
            }

            arrCount.Sort();
            cstJin = arrCount[arrCount.Count - 1].ToString().Substring(2, 1);
            HL1 = arrCount[arrCount.Count - 2].ToString().Substring(2, 1);
            HL2 = arrCount[arrCount.Count - 3].ToString().Substring(2, 1);

            char[] charSZ = nextTcode.ToCharArray();
            Array.Sort(charSZ);
            string row1Code = new string(charSZ);
            object objDe = DbHelperSQL1.GetSingle("select top 1 decode from FC3DTest_Code where code='" + row1Code + "' ");
            if (objDe != null)
            {
                deTestCode = objDe.ToString();
            }
            string[] strRetrun = new string[4];
            strRetrun[0] = cstJin;
            strRetrun[1] = HL1;
            strRetrun[2] = HL2;
            strRetrun[3] = deTestCode;
            return strRetrun;

        }


        public static string[] CalGZM(string testcodeNow)
        {
            string cstJin = "";
            string HL1 = "";
            string HL2 = "";
            string deTestCode = "";
            DataTable dtFc3d = DbHelperSQL1.Query("select top 1 issue,code,testcode  from FC3DData where code is not null and code!=''  order by issue desc").Tables[0];
            //�����һ��(�����н��ţ�����û����,���ƣ���һ��)
            //DataRow row1 = dtFc3d.Rows[0];

            //�����ڶ��ڣ�һ���н��ţ����ƣ���ǰ�ڣ�
            DataRow row2 = dtFc3d.Rows[0];

            string abc = row2["code"].ToString(); //code
            string jabc = row2["testcode"].ToString();//tcode
            string he = Method.Qhe(abc);
            string jhe = Method.Qhe(jabc);

            string _jhe = Method.Qhe(testcodeNow);
            ///��һ���Ի��ţ�s(-1,jabc) = row1["testcode"]               
            int a = int.Parse(abc.Substring(0, 1));
            int b = int.Parse(abc.Substring(1, 1));
            int c = int.Parse(abc.Substring(2, 1));
            int[] gsCode = new int[7];

            //��ʽ1��  ȡһ�����������ŵ�β��������λ�Ӻ͵�λ��Ϊ1����һ���Ի��ţ��� ��+ ��λ�Ӻ͵�λ��Ϊ1����ǰ�������ţ� ��                                   
            gsCode[0] = Method.END(Method.BSUM(testcodeNow) + Method.BSUM(abc));  //end(bsum(s(-1,jabc),1)+bsum(abc,1))  

            //��ʽ2��
            gsCode[1] = Method.END(10 + Method.BSUM(abc) - Method.BSUM(testcodeNow));//end(10+bsum(abc,1)-bsum(s(-1,jabc),1))

            //��ʽ3��
            ///gsCode[2] = Method.END(10 + Method.BSUM(sjabc) - Method.BSUM(jabc));//end(10+bsum(s(-1,jabc),1)-bsum(jabc,1))

            gsCode[2] = Method.BSUM(Convert.ToString(Method.Qkd(abc) * Method.HW(he) + Method.BSUM(testcodeNow) * 3 - Method.BSUM(jabc) * 2));//BSUM(kd*hw+BSUM(S(-1,JABC),1)*3-BSUM(JABC,1)*2,1)
            //��ʽ4��
            //gsCode[3] = Method.END(Method.BSUM(sjabc) + Method.BSUM(abc) + Method.BSUM(jabc));//end(bsum(s(-1,jabc),1)+bsum(abc,1)+bsum(jabc,1))
            gsCode[3] = Method.END(Method.BSUM(testcodeNow) + Method.BSUM(abc) * 2 + Method.BSUM(jabc) * 3);    // END(BSUM(S(-1,JABC),1)+BSUM(ABC,1)*2+BSUM(JABC,1)*3)		                                                   

            //��ʽ5��
            /// gsCode[4] = Method.END(Method.BSUM(sjhe + Method.Qkd(sjabc)) + Method.BSUM(he + Method.Qkd(abc)) + Method.BSUM(jhe + Method.Qkd(sjabc)));//end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))                               
            gsCode[4] = Method.END(Method.BSUM(Convert.ToString(Convert.ToUInt32(_jhe) + Method.Qkd(testcodeNow))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + Method.Qkd(abc))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(jhe) + Method.Qkd(jabc))));//' end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))
            //��ʽ6:
            //gsCode[5] = Method.BSUM(he + 3 * a + 2 * b + c);//bsum(he+3*A+2*B+c,1)
            gsCode[5] = Method.BSUM(Convert.ToString(Method.Qkd(abc) + 3 * a + 2 * b + c)); // BSUM(KD+3*A+2*B+C,1)

            //��ʽ7:
            //gsCode[6] = Method.BSUM(he + a + 2 * b + 3 * c);//bsum(he+A+2*B+3*c,1)
            gsCode[6] = Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + 2 * Method.Qkd(abc) + 3 * Method.HW(he)));              //BSUM(HE+2*KD+3*HW,1)

            int[] codeCount = new int[7];
            for (int i = 0; i < codeCount.Length; i++)
            {
                codeCount[i] = 0;
            }
            string[] Result = new string[7];
            SortedList sortCode = new SortedList();
            ArrayList arrCount = new ArrayList();
            for (int i = 0; i < gsCode.Length; i++)
            {
                for (int j = 0; j < gsCode.Length; j++)
                {
                    if (gsCode[i] == gsCode[j])
                    {
                        codeCount[i]++;
                    }
                }
                if (!sortCode.ContainsKey(codeCount[i] + "" + gsCode[i]))
                {
                    sortCode.Add(codeCount[i] + "" + gsCode[i], gsCode[i]);
                    arrCount.Add(codeCount[i] + "" + (7 - i) + "" + gsCode[i]);
                }
            }
            arrCount.Sort();
            cstJin = arrCount[arrCount.Count - 1].ToString().Substring(2, 1);
            HL1 = arrCount[arrCount.Count - 2].ToString().Substring(2, 1);
            HL2 = arrCount[arrCount.Count - 3].ToString().Substring(2, 1);
            char[] charSZ = testcodeNow.ToCharArray();
            Array.Sort(charSZ);
            string row1Code = new string(charSZ);
            object objDe = DbHelperSQL1.GetSingle("select top 1 decode from FC3DTest_Code where code='" + row1Code + "' ");
            if (objDe != null)
            {
                deTestCode = objDe.ToString();
            }
            string[] strRetrun = new string[4];
            strRetrun[0] = cstJin;
            strRetrun[1] = HL1;
            strRetrun[2] = HL2;
            strRetrun[3] = deTestCode;
            return strRetrun;
        }


        /// <summary>
        ///�õ�ǰ�������ص�ַ 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTop2DownLoad()
        {
            XmlDocument doc = new XmlDocument();
            string path = System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNodeList productList = doc.SelectNodes("/root/ProductDownLoad/Down[@IsOpen='1']");



            List<string> result = new List<string>();
            foreach (XmlNode nodeTemp in productList)
            {
                result.Add(nodeTemp.Attributes["Url"].Value);
            }
            return result;
        }

        /// <summary>
        ///�õ�ǰ�������ص�ַ����
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTop2DownLoadName()
        {
            XmlDocument doc = new XmlDocument();
            string path = System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNodeList productList = doc.SelectNodes("/root/ProductDownLoad/Down[@IsOpen='1']");

            List<string> result = new List<string>();
            foreach (XmlNode nodeTemp in productList)
            {
                result.Add(nodeTemp.Attributes["name"].Value);
            }
            return result;
        }


        /// <summary>
        /// ����ģ����Ϣ����
        /// </summary>
        public static void CreateInsert()
        {
            int rootID = Convert.ToInt32(DbHelperSQL.GetSingle("select top 1 ID from PBnet_Module where Name='��������Ȩ���趨' "));
            DbHelperSQL.ExecuteSql(" delete PBnet_Module where RootID=" + rootID);
            rootID = Convert.ToInt32(DbHelperSQL.GetSingle("insert into PBnet_Module(Name,URL,LinkUrl,Depth,RootID,FlagMenu,Sort,Format,IsHome,CreateTime,TempID)  values ('��������Ȩ���趨','','','0','0','0','13','0','0','" + DateTime.Now + "','0');select @@IDENTITY"));
            DbHelperSQL.ExecuteSql("update PBnet_Module set RootID='" + rootID + "',TempID='" + rootID + "' where ID='" + rootID + "' ");
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionString))
            {
                conn.Open();
                const string transName = "InsertModule";
                SqlTransaction trans = conn.BeginTransaction(transName);
                try
                {
                    Pbzx.BLL.PBnet_LotteryMenu lotteryBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                    DataSet ds = lotteryBLL.GetList(" 1=1 order by IntClass_OrderId,NvarOrderId  ");
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        int k = 0;
                        object obj = 133;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            k++;
                            Object objLottDate = row["NvarLott_date"];
                            string strLottDate = "";
                            if (objLottDate != null)
                            {
                                strLottDate = objLottDate.ToString();
                                if (strLottDate.Length > 1)
                                {
                                    strLottDate = strLottDate.Substring(0, strLottDate.Length - 1);
                                }
                            }
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.Transaction = trans;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "insert into PBnet_Module(Name,URL,LinkUrl,Depth,RootID,FlagMenu,Sort,Format,IsHome,CreateTime,TempID)  values (@Name,@URL,@LinkUrl,@Depth,@RootID,@FlagMenu,@Sort,@Format,@IsHome,@CreateTime,@TempID);select @@IDENTITY";
                                cmd.Parameters.Add(new SqlParameter("@Name", row["NvarName"]));
                                cmd.Parameters.Add(new SqlParameter("@URL", row["Url"].ToString() + "?city=" + row["NvarName"] + "&lottdate=" + strLottDate));
                                cmd.Parameters.Add(new SqlParameter("@LinkUrl", ""));
                                cmd.Parameters.Add(new SqlParameter("@Depth", "1"));
                                cmd.Parameters.Add(new SqlParameter("@RootID", rootID));
                                cmd.Parameters.Add(new SqlParameter("@FlagMenu", "0"));
                                cmd.Parameters.Add(new SqlParameter("@Sort", k));
                                cmd.Parameters.Add(new SqlParameter("@Format", "0"));
                                cmd.Parameters.Add(new SqlParameter("@IsHome", "0"));
                                cmd.Parameters.Add(new SqlParameter("@CreateTime", DateTime.Now));
                                cmd.Parameters.Add(new SqlParameter("@TempID", obj));
                                obj = cmd.ExecuteScalar();
                                obj = (int.Parse(obj.ToString()) + 1);
                                cmd.Parameters.Clear();
                            }
                        }
                        trans.Commit();
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback(transName);
                    conn.Close();
                    conn.Dispose();
                    return;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        /// <summary>
        /// ����ģ����Ϣ����
        /// </summary>
        public static void UpdateUrl()
        {
            int rootID = Convert.ToInt32(DbHelperSQL.GetSingle("select top 1 ID from PBnet_Module where Name='��������Ȩ���趨' "));
            //DbHelperSQL.ExecuteSql(" delete PBnet_Module where RootID=" + rootID);
            //rootID = Convert.ToInt32(DbHelperSQL.GetSingle("insert into PBnet_Module(Name,URL,LinkUrl,Depth,RootID,FlagMenu,Sort,Format,IsHome,CreateTime,TempID)  values ('��������Ȩ���趨','','','0','0','0','13','0','0','" + DateTime.Now + "','0');select @@IDENTITY"));
            //DbHelperSQL.ExecuteSql("update PBnet_Module set RootID='" + rootID + "',TempID='" + rootID + "' where ID='" + rootID + "' ");
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionString))
            {
                conn.Open();
                const string transName = "UpdateModule";
                SqlTransaction trans = conn.BeginTransaction(transName);
                try
                {
                    Pbzx.BLL.PBnet_LotteryMenu lotteryBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                    DataSet ds = lotteryBLL.GetList(" 1=1 order by IntClass_OrderId,NvarOrderId  ");
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        int k = 0;
                        object obj = 133;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            k++;
                            Object objLottDate = row["NvarLott_date"];
                            string strLottDate = "";
                            if (objLottDate != null)
                            {
                                strLottDate = objLottDate.ToString();
                                if (strLottDate.Length > 1)
                                {
                                    strLottDate = strLottDate.Substring(0, strLottDate.Length - 1);
                                }
                            }
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.Transaction = trans;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = " update PBnet_Module set Name=@Name, URL=@URL, LinkUrl=@LinkUrl, Depth=@Depth, RootID=@RootID, FlagMenu=@FlagMenu, Sort=@Sort, Format=@Format, IsHome=@IsHome, CreateTime=@CreateTime, TempID=@TempID where Name='" + row["NvarName"].ToString() + "' ";
                                cmd.Parameters.Add(new SqlParameter("@Name", row["NvarName"]));
                                cmd.Parameters.Add(new SqlParameter("@URL", row["Url"].ToString() + "?city=" + row["NvarApp_name"] + "&lottdate=" + strLottDate));
                                cmd.Parameters.Add(new SqlParameter("@LinkUrl", ""));
                                cmd.Parameters.Add(new SqlParameter("@Depth", "1"));
                                cmd.Parameters.Add(new SqlParameter("@RootID", rootID));
                                cmd.Parameters.Add(new SqlParameter("@FlagMenu", "0"));
                                cmd.Parameters.Add(new SqlParameter("@Sort", k));
                                cmd.Parameters.Add(new SqlParameter("@Format", "0"));
                                cmd.Parameters.Add(new SqlParameter("@IsHome", "0"));
                                cmd.Parameters.Add(new SqlParameter("@CreateTime", DateTime.Now));
                                cmd.Parameters.Add(new SqlParameter("@TempID", obj));
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }
                        trans.Commit();
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback(transName);
                    conn.Close();
                    conn.Dispose();
                    return;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        /// <summary>
        /// ��չ��ﳵ
        /// </summary>
        /// <param name="cartID"></param>
        public static void ClearCart(string cartGUID)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.DeleteShoppingCartByCartGuid(cartGUID);
        }

        /// <summary>
        /// ���ݹ��ﳵIDɾ�����ﳵ
        /// </summary>
        public static void DelShoppingCartByID(string cartID)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.Delete(long.Parse(cartID));
        }

        /// <summary>
        /// ���㵱ǰ���ﳵ��Ʒ�ܼ۸�
        /// </summary>
        public static decimal CalcTotalPrice()
        {
            Decimal result = 0;
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            System.Data.DataSet dsProducts = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
            {
                return 0;
            }
            else
            {
                foreach (DataRow row in dsProducts.Tables[0].Rows)
                {
                    int quantity = Convert.ToInt32(row["Quatity"]);
                    string regType = row["RegType"].ToString();
                    if (!string.IsNullOrEmpty(regType))
                    {
                        string[] regSZ = regType.Split(new char[] { '|' });

                        if (regSZ.Length > 1 && !string.IsNullOrEmpty(regSZ[1]))
                        {
                            string[] days = regSZ[1].Split(new char[] { '&' });
                            if (days.Length > 1)
                            {
                                if (!string.IsNullOrEmpty(days[1]))
                                {
                                    decimal myprice = Convert.ToDecimal(days[0]);
                                    decimal mypriceDays = Convert.ToDecimal(days[1]);
                                    decimal temp = myprice * quantity * mypriceDays;
                                    result += temp;
                                }
                            }
                            else
                            {
                                decimal myprice = Convert.ToDecimal(regSZ[1]);
                                decimal temp = myprice * quantity;
                                result += temp;
                            }
                        }
                    }
                }
            }
            return result;
        }




        /// <summary>
        /// ���㵱ǰ���ﳵ��Ʒ�ܼ۸��������
        /// </summary>
        public static string[] CalcTotalPriceAndCount()
        {
            string[] myResult = new string[2];
            Decimal result = 0;
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            System.Data.DataSet dsProducts = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);

            if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
            {
                myResult[0] = "0";
                myResult[1] = "0";
                return myResult;
            }
            else
            {
                foreach (DataRow row in dsProducts.Tables[0].Rows)
                {
                    int quantity = Convert.ToInt32(row["Quatity"]);
                    string regType = row["RegType"].ToString();
                    if (!string.IsNullOrEmpty(regType))
                    {
                        string[] regSZ = regType.Split(new char[] { '|' });

                        if (regSZ.Length > 1 && !string.IsNullOrEmpty(regSZ[1]))
                        {
                            string[] days = regSZ[1].Split(new char[] { '&' });
                            if (days.Length > 1)
                            {
                                if (!string.IsNullOrEmpty(days[1]))
                                {
                                    decimal myprice = Convert.ToDecimal(days[0]);
                                    decimal mypriceDays = Convert.ToDecimal(days[1]);
                                    decimal temp = myprice * quantity * mypriceDays;
                                    result += temp;
                                }
                            }
                            else
                            {
                                decimal myprice = Convert.ToDecimal(regSZ[1]);
                                decimal temp = myprice * quantity;
                                result += temp;
                            }
                        }
                    }
                }
            }
            myResult[0] = result.ToString("0.00");
            myResult[1] = dsProducts.Tables[0].Rows.Count.ToString();
            return myResult;
        }



        /// <summary>
        /// ���㵱ǰ�м۸񣬸��������ݿ�
        /// </summary>
        /// <param name="pid">���ﳵID</param>
        /// <param name="quantity">����</param>
        /// <param name="type">ע�᷽ʽ����������緽ʽ����ѡ���죬�����ֵΪ��ע�᷽ʽ*������</param>
        /// <param name="price">�۸�</param>
        public static Pbzx.Model.PBnet_ShoppingCart UpdateShoppingCart(string pid, string quantity, string type, string price, string temp, string UseTime)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            Pbzx.Model.PBnet_ShoppingCart cartModel = shoppingCartBll.GetModel(long.Parse(pid));
            cartModel.DataAdded = DateTime.Now;
            cartModel.Quatity = int.Parse(quantity);
            decimal tempTotalPrice = 0;
            if (decimal.TryParse(price, out tempTotalPrice))
            {
                cartModel.RegType = type + "|" + price;
                string[] days = type.Split(new char[] { '*' });
                if (days.Length > 1)
                {
                    if (!string.IsNullOrEmpty(days[1]))
                    {
                        cartModel.RegType = days[0] + "|" + price + "&" + days[1];
                    }
                }
            }
            else
            {
                cartModel.RegType = type + "|";
            }
            cartModel.RegType += "|";

            if (!string.IsNullOrEmpty(temp))
            {
                cartModel.RegType += temp;
            }
            cartModel.UseTime = UseTime;
            shoppingCartBll.Update(cartModel);
            return cartModel;
        }




        /// <summary>
        /// �õ���ǰ������ۿ�
        /// </summary>
        /// <returns></returns>
        public static decimal GetCurrentPricePercent()
        {
            decimal result = 100;
            object objPP = DbHelperSQL1.GetSingle("select PricePercent from AgentInfo where UserName='" + Method.Get_UserName + "' " + Method.Where_AgentInfo);
            Method.GetCurrentPricePercentByUname(Method.Get_UserName);
            decimal.TryParse(objPP.ToString(), out result);
            return result / 100;
        }

        /// <summary>
        /// �õ���ǰ������ۿ�
        /// </summary>
        /// <returns></returns>
        public static decimal GetCurrentPricePercent(object orderID)
        {
            string uName = DbHelperSQL.GetSingle("select top 1 UserName from PBnet_Orders where OrderID='" + orderID.ToString() + "' ").ToString();
            decimal result = 1;
            object objPP = DbHelperSQL1.GetSingle("select PricePercent from AgentInfo where UserName='" + uName + "' " + Method.Where_AgentInfo);
            decimal.TryParse(objPP.ToString(), out result);
            return result / 100;
        }


        /// <summary>
        /// ��⾭�����û��Ƿ�Ϸ�
        /// </summary>
        /// <param name="strBrokerName"></param>
        /// <returns></returns>
        public static string CheckBroker(string strBrokerName)
        {
            if (string.IsNullOrEmpty(strBrokerName))
            {
                return "";
            }
            else
            {
                int countDvUser = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(UserName) from Dv_User where UserName='" + strBrokerName + "' and " + Method.DV_User));
                if (countDvUser < 1)
                {
                    return "���û������ڣ����Ⱥ�ʵ���ύ��";
                }
                else
                {
                    int countBroker = Convert.ToInt32(DbHelperSQL.GetSingle("select count(UserName) from PBnet_broker where UserName='" + strBrokerName + "' "));
                    int BrokerState = Convert.ToInt32(DbHelperSQL.GetSingle("select count(UserName) from PBnet_broker where UserName='" + strBrokerName + "' and State=1 "));
                    if (countBroker < 1)
                    {
                        return "���û����Ǿ������û������Ⱥ�ʵ���ύ��";
                    }
                    else if (BrokerState < 1)
                    {
                        return "�þ�����δͨ����ˣ����߱�������";
                    }
                    else
                    {
                        return "true";
                    }
                }
            }
        }


        /// <summary>
        /// ��ⶩ���Ƿ���Ч
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static bool CheckOrderIsValidate(string orderID)
        {
            if (string.IsNullOrEmpty(orderID))
            {
                return false;
            }
            string orderType = GetOrderType(orderID);
            if (orderType == "0")
            {
                Pbzx.BLL.PBnet_Orders orderBLL = new Pbzx.BLL.PBnet_Orders();
                Pbzx.Model.PBnet_Orders orderModel = orderBLL.GetModel(orderID);
                DataTable tbOrder = orderBLL.SelectOrdersByOrderID(orderID).Tables[0];
                if (tbOrder.Rows.Count < 1)
                {
                    return false;
                }
                if (tbOrder.Rows[0]["IsCancel"].ToString() == "1" || tbOrder.Rows[0]["IsCancel"].ToString() == "2")
                {
                    return false;
                }
                if (tbOrder.Rows[0]["TipName"].ToString().Contains("5") || tbOrder.Rows[0]["TipName"].ToString().Contains("6"))
                {
                    return false;
                }
            }
            else if (orderType == "1")
            {
                Pbzx.BLL.PBnet_Orders orderBLL = new Pbzx.BLL.PBnet_Orders();
                Pbzx.Model.PBnet_Orders orderModel = orderBLL.GetModel(orderID);
                DataTable tbOrder = orderBLL.SelectOrdersByOrderID(orderID).Tables[0];
                if (tbOrder.Rows.Count < 1)
                {
                    return false;
                }
                if (tbOrder.Rows[0]["IsCancel"].ToString() == "1" || tbOrder.Rows[0]["IsCancel"].ToString() == "2")
                {
                    return false;
                }
                if (tbOrder.Rows[0]["TipName"].ToString().Contains("5") || tbOrder.Rows[0]["TipName"].ToString().Contains("6"))
                {
                    return false;
                }
            }
            else if (orderType == "2")
            {
                Pbzx.BLL.PBnet_Charge chargeBll = new Pbzx.BLL.PBnet_Charge();
                Pbzx.Model.PBnet_Charge chargeModel = chargeBll.GetModelByOrderId(orderID);
                if (chargeModel.IsCancel == 1 || chargeModel.IsCancel == 2)
                {
                    return false;
                }
                if (Convert.ToInt32(chargeModel.State) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ����֧�����¶���״̬
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="isSuccess"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool UpdateOrder(string orderID, bool isSuccess, string orderamount, string managerEmail, string isOnlineStr, int PayTypeID, string PayTypeName)
        {
            lock (sysobj)
            {
                if (isSuccess)
                {
                    string orderType = GetOrderType(orderID);
                    if (orderType == "0")
                    {
                        Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
                        DataSet dsOrderDetails = orderDetailBll.SelectOrderDetailByOrderID(orderID);
                        Pbzx.BLL.PBnet_Orders orderBLL = new Pbzx.BLL.PBnet_Orders();
                        Pbzx.Model.PBnet_Orders orderModel = orderBLL.GetModel(orderID);
                        DataTable tbOrder = orderBLL.SelectOrdersByOrderID(orderID).Tables[0];
                        if (tbOrder.Rows[0]["TipName"].ToString().Contains("5") || tbOrder.Rows[0]["TipName"].ToString().Contains("6"))
                        {
                            return false;
                        }
                        tbOrder.TableName = "PBnet_Orders";
                        decimal totalPrice = Convert.ToDecimal(tbOrder.Rows[0]["TotalProductPrice"]) + Convert.ToDecimal(tbOrder.Rows[0]["PortPrice"]) - Convert.ToDecimal(tbOrder.Rows[0]["HasPayedPrice"]);
                        //if(Convert.ToInt32(totalPrice) != Convert.ToInt32(Convert.ToDecimal(orderamount)))
                        //{
                        //    return false;
                        //}
                        string strResult = "";
                        orderModel.HasPayedPrice = Math.Round(decimal.Parse(orderamount), 2);
                        orderModel.UpdateStaticDate = DateTime.Now;
                        orderModel.PayTypeID = PayTypeID;
                        orderModel.PayTypeName = PayTypeName;
                        orderModel.TipID = (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���;
                        orderModel.TipName = (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ��� + "";
                        orderBLL.Update(orderModel);

                        //д���к�
                        bool result = WriteSerial(tbOrder, dsOrderDetails, isOnlineStr, PayTypeID, PayTypeName, orderamount);
                        if (result)
                        {
                            UpdatePBnet_brokerAndUser(orderBLL.GetModel(orderID), orderamount, isOnlineStr);
                        }
                        Pbzx.Common.ErrorLog.WriteLogMeng("����", "д�����кŽ����" + result, true, true);
                        //orderBLL.PayForOrders(int.Parse(Method.Get_UserID), orderID, decimal.Parse(orderamount));
                        //������Ա���Ͷ���֧��֪ͨ�ʼ�
                        //string toEmail = UIConfig.SmtpFromEmail;
                        //EmailOrder emailOrder = new EmailOrder(managerEmail, orderID, "0", "2");
                        //emailOrder.SendEmail();
                        //EmailOrder emailOrderUser = new EmailOrder(orderModel.ReceiverEmail, orderID,"0","2");
                        //emailOrderUser.SendEmail();
                    }
                    else if (orderType == "1")
                    {
                    }
                    else if (orderType == "2")
                    {
                        Pbzx.BLL.PBnet_Charge chargeBll = new Pbzx.BLL.PBnet_Charge();
                        Pbzx.Model.PBnet_Charge chargeModel = chargeBll.GetModelByOrderId(orderID);
                        if (Convert.ToInt32(chargeModel.State) == 1)
                        {
                            return false;
                        }
                        chargeModel.State = 1;
                        decimal totalPrice = (decimal)chargeModel.PayMoney - (decimal)chargeModel.HasPayedPrice;
                        if (Convert.ToInt32(totalPrice) != Convert.ToInt32(Convert.ToDecimal(orderamount)))
                        {
                            return false;
                        }
                        Pbzx.Model.PBnet_UserTable uRealInfo = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(chargeModel.UserName);
                        uRealInfo.CurrentMoney += Math.Round(decimal.Parse(orderamount), 2);

                        uRealInfo.LastTrade_time = DateTime.Now;
                        Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                        userBll.Update(uRealInfo);

                        chargeModel.HasPayedPrice = Math.Round(decimal.Parse(orderamount), 2);
                        chargeModel.IsPay = 1;
                        chargeModel.PayNum = uRealInfo.AccountNumber;
                        chargeModel.Result = DateTime.Now + "���û�[" + chargeModel.UserName + "]��ֵ����ֵ���" + decimal.Parse(orderamount).ToString("0.00") + "Ԫ����ֵ�ɹ���";
                        chargeModel.Type = 0;
                        chargeModel.UpdateStaticDate = DateTime.Now;
                        chargeModel.PayTypeID = PayTypeID;
                        chargeModel.PayTypeName = PayTypeName;
                        chargeModel.State = 1;
                        chargeBll.Update(chargeModel);

                        /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                        Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
                        Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
                        tradeModel.Account_UserName = "";
                        tradeModel.AccountNumber = "";
                        tradeModel.BankName = "";
                        tradeModel.CurrentMoney = 0;

                        Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(chargeModel.UserName);
                        if (userRealModel != null)
                        {
                            tradeModel.Account_UserName = userRealModel.RealName;
                            tradeModel.AccountNumber = userRealModel.AccountNumber;
                            tradeModel.BankName = userRealModel.BankName;
                            tradeModel.CurrentMoney = userRealModel.CurrentMoney;
                        }
                        tradeModel.ForeignKey_id = chargeModel.OrderID.ToString();

                        if ("���Զ���" == isOnlineStr)
                        {
                            tradeModel.OperateManager = "��˾���Զ���";
                        }
                        else
                        {
                            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
                        }
                        tradeModel.Remark = DateTime.Now + "���û�[" + chargeModel.UserName + "]��ֵ����ֵ���" + decimal.Parse(orderamount).ToString("0.00") + "Ԫ����ֵ�ɹ���������" + chargeModel.OrderID;
                        tradeModel.TradeMoney = Convert.ToDecimal(orderamount);
                        tradeModel.TradeTime = DateTime.Now;
                        tradeModel.UserName = chargeModel.UserName;
                        tradeModel.TradeType = 311;
                        tradeBll.Add(tradeModel);
                        /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// ���¾����˽��
        /// </summary>
        public static void UpdatePBnet_brokerAndUser(Pbzx.Model.PBnet_Orders orderModel, string orderamount, string onlineStr)
        {

            if (orderModel.TipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���)))
            {
                if (!string.IsNullOrEmpty(orderModel.BrokerName))
                {
                    Pbzx.BLL.PBnet_broker brokerBll = new Pbzx.BLL.PBnet_broker();
                    Pbzx.Model.PBnet_broker brokerModel = brokerBll.GetModelName(orderModel.BrokerName);
                    if (brokerModel != null && brokerModel.State == 1)
                    {
                        //�õ����׽�ȥ����������ú��ʷѣ�
                        decimal dcAmount = GetTradeMoeyByOrdermodel(orderModel);
                        if (((DateTime)brokerModel.YearStart_time).AddYears(1) < DateTime.Now)
                        {
                            DataRow TMRow = GetBrokerConfigByTrade((decimal)brokerModel.Year_tradeMoney);
                            string sql = "update   FROM PBnet_broker set Discount_gradeName='" + TMRow["Discount_gradeName"].ToString() + "',Discount_rate='" + TMRow["Discount_rate"].ToString() + "'  WHERE  UserName= '" + brokerModel.UserName + "'  ";
                            brokerModel.YearStart_time = DateTime.Now;
                            brokerModel.Year_tradeMoney = 0M;
                            brokerBll.Update(brokerModel);
                        }
                        decimal jingjirenGet = dcAmount * (Convert.ToDecimal(1) - Convert.ToDecimal(brokerModel.Discount_rate) / 100);

                        brokerModel.Year_tradeMoney += dcAmount;
                        brokerModel.Year_incomeMoney += jingjirenGet;
                        brokerModel.Total_tradeMoney += dcAmount;
                        brokerModel.Total_incomeMoney += jingjirenGet;
                        brokerModel.LastTrade_time = DateTime.Now;

                        Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                        Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(orderModel.UserName);
                        userModel.CurrentMoney += dcAmount * WebInit.webBaseConfig.UserGet;
                        userBll.Update(userModel);

                        /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                        Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
                        Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
                        tradeModel.Account_UserName = "";
                        tradeModel.AccountNumber = "";
                        tradeModel.BankName = "";
                        tradeModel.CurrentMoney = 0;

                        Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(orderModel.UserName);
                        if (userRealModel != null)
                        {
                            tradeModel.Account_UserName = userRealModel.RealName;
                            tradeModel.AccountNumber = userRealModel.AccountNumber;
                            tradeModel.BankName = userRealModel.BankName;
                            tradeModel.CurrentMoney = userRealModel.CurrentMoney;
                        }
                        tradeModel.ForeignKey_id = orderModel.OrderID;
                        if ("���Զ���" == onlineStr)
                        {
                            tradeModel.OperateManager = "��˾���Զ���";
                        }
                        else
                        {
                            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
                        }
                        tradeModel.Remark = DateTime.Now + "����¼�û�[" + orderModel.UserName + "]�����������д�˾��������÷������棬�����" + Math.Round(dcAmount * WebInit.webBaseConfig.UserGet, 2) + "Ԫ";
                        tradeModel.TradeMoney = Math.Round(dcAmount * WebInit.webBaseConfig.UserGet, 2);
                        tradeModel.TradeTime = DateTime.Now;
                        tradeModel.UserName = orderModel.UserName;
                        tradeModel.TradeType = 512;
                        tradeBll.Add(tradeModel);
                        /////////////////д�뽻����Ϣ��end//////////////////////////////////////////////

                        Pbzx.Model.PBnet_UserTable userModelB = userBll.GetModelName(orderModel.BrokerName);
                        userModelB.CurrentMoney += jingjirenGet;
                        userBll.Update(userModelB);
                        //��ȡ��ǰ�������ۿ۵ȼ�����
                        DataRow configRow = GetBrokerConfigByTrade((decimal)brokerModel.Total_tradeMoney);
                        if (Convert.ToInt32(configRow["Discount_rate"]) < (int)brokerModel.Discount_rate)
                        {
                            brokerModel.Discount_rate = Convert.ToInt32(configRow["Discount_rate"]);
                            brokerModel.Discount_gradeName = configRow["Discount_gradeName"].ToString();
                        }
                        brokerBll.Update(brokerModel);
                        Pbzx.BLL.PBnet_broker_TradeInfo brokerTradeBll = new Pbzx.BLL.PBnet_broker_TradeInfo();
                        Pbzx.Model.PBnet_broker_TradeInfo brokerTradeModel = new Pbzx.Model.PBnet_broker_TradeInfo();
                        brokerTradeModel.BrokerIncome = jingjirenGet;
                        brokerTradeModel.BrokerName = brokerModel.UserName;
                        brokerTradeModel.CreateTime = DateTime.Now;
                        brokerTradeModel.CustomerName = orderModel.UserName;
                        brokerTradeModel.CustomerPay = Math.Round(dcAmount, 2);
                        brokerTradeModel.OrderID = orderModel.OrderID;
                        if ("���Զ���" == onlineStr)
                        {
                            brokerTradeModel.RegManager = "��˾���Զ���";
                        }
                        else
                        {
                            brokerTradeModel.RegManager = WebFunc.GetCurrentAdmin();
                        }
                        brokerTradeModel.Remark = "";
                        brokerTradeBll.Add(brokerTradeModel);

                        /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                        Pbzx.Model.PBnet_UserTradeInfo tradeModelB = new Pbzx.Model.PBnet_UserTradeInfo();
                        tradeModelB.Account_UserName = "";
                        tradeModelB.AccountNumber = "";
                        tradeModelB.BankName = "";
                        tradeModelB.CurrentMoney = null;

                        Pbzx.Model.PBnet_UserTable userRealModelB = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(brokerModel.UserName);
                        if (userRealModelB != null)
                        {
                            tradeModelB.Account_UserName = userRealModelB.RealName;
                            tradeModelB.AccountNumber = userRealModelB.AccountNumber;
                            tradeModelB.BankName = userRealModelB.BankName;
                            tradeModelB.CurrentMoney = userRealModelB.CurrentMoney;
                        }
                        tradeModelB.ForeignKey_id = brokerTradeModel.OrderID.ToString();
                        if ("���Զ���" == onlineStr)
                        {
                            tradeModelB.OperateManager = "��˾���Զ���";
                        }
                        else
                        {
                            tradeModelB.OperateManager = WebFunc.GetCurrentAdmin();
                        }
                        tradeModelB.Remark = DateTime.Now + "��������[" + brokerModel.UserName + "]�ƹ����û�[" + orderModel.UserName + "]������������þ������Ƽ����룬�����" + Math.Round(jingjirenGet, 2) + "Ԫ";
                        tradeModelB.TradeMoney = Math.Round(jingjirenGet, 2);
                        tradeModelB.TradeTime = DateTime.Now;
                        tradeModelB.UserName = brokerModel.UserName;
                        tradeModelB.TradeType = 511;
                        tradeBll.Add(tradeModelB);
                        /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                    }
                }
            }
        }

        /// <summary>
        /// �õ��û�����������ã�ȥ����������ú��ʷѣ�
        /// </summary>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        private static decimal GetTradeMoeyByOrdermodel(Pbzx.Model.PBnet_Orders orderModel)
        {
            decimal orderMoney = (decimal)orderModel.TotalProductPrice;
            Pbzx.BLL.PBnet_OrderDetail detailBll = new Pbzx.BLL.PBnet_OrderDetail();
            DataSet dsDetails = detailBll.SelectOrderDetailByOrderID(orderModel.OrderID);
            foreach (DataRow row in dsDetails.Tables[0].Rows)
            {
                string[] regType = row["RegType"].ToString().Split(new char[] { '|' });
                if (regType[0] == "7")
                {
                    orderMoney -= WebInit.webBaseConfig.SoftdogPrice;
                }
            }
            return orderMoney;
        }

        /// <summary>
        /// ���ݾ����˽��׽��õ������˵ȼ�����
        /// </summary>
        /// <param name="tradeMoney"></param>
        /// <returns></returns>
        private static DataRow GetBrokerConfigByTrade(decimal tradeMoney)
        {
            string sql = "SELECT top 1 * FROM PBnet_broker_Config WHERE  Min_tradeMoney  <'" + tradeMoney + "'  ORDER BY Min_tradeMoney DESC";
            return DbHelperSQL.Query(sql).Tables[0].Rows[0];
        }

        /// <summary>
        /// д�����к�
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="dsOrderDetails"></param>
        private static bool WriteSerial(DataTable tbOrder, DataSet dsOrderDetails, string onlineStr, int PayTypeID, string PayTypeName, string orderamount)
        {
            bool boolResult = true;
            DataRow rowOrder = tbOrder.Rows[0];
            string[] dlIDName = new string[4];
            dlIDName = GetAgentInfoByBrokerNameUserName(rowOrder["BrokerName"].ToString().Trim(), rowOrder["UserName"].ToString());

            int intTradeType = 151;
            if ("���֧��" == rowOrder["PayTypeName"].ToString())
            {
                intTradeType = 171;
            }
            string strRemark = "��¼�û�[" + rowOrder["UserName"].ToString() + "]�����������ͨ����ʽ���������Ϣ��������" + rowOrder["OrderID"].ToString();
            //�������ۿ�start
            decimal jjrPriceResult = 1;
            if (rowOrder["BrokerName"] != null && !string.IsNullOrEmpty(rowOrder["BrokerName"].ToString()))
            {
                Pbzx.BLL.PBnet_broker brokerBll = new Pbzx.BLL.PBnet_broker();
                Pbzx.Model.PBnet_broker brokerModel = brokerBll.GetModelName(rowOrder["BrokerName"].ToString());
                if (brokerModel != null && brokerModel.State == 1)
                {
                    jjrPriceResult = Convert.ToDecimal(brokerModel.Discount_rate) / 100;
                    intTradeType = 153;
                    if ("���֧��" == rowOrder["PayTypeName"].ToString())
                    {
                        intTradeType = 173;
                    }
                    strRemark = "��¼�û�[" + rowOrder["UserName"].ToString() + "]��������������˻����ʽ���������Ϣ��������" + rowOrder["OrderID"].ToString();
                }
            }
            //�������ۿ�end

            //�����ۿ�start
            decimal dlPriceResult = 1;
            if (dlIDName[3] == "true")
            {
                decimal.TryParse(WebFunc.GetCurrentPricePercent(rowOrder["OrderID"]).ToString(), out dlPriceResult);
                intTradeType = 152;
                if ("���֧��" == rowOrder["PayTypeName"].ToString())
                {
                    intTradeType = 172;
                }
                strRemark = "��¼�û�[" + rowOrder["UserName"].ToString() + "]���������������ʽ���������Ϣ��������" + rowOrder["OrderID"].ToString();
            }
            //�����ۿ�end
            if (!(dsOrderDetails.Tables.Count > 0 && dsOrderDetails.Tables[0].Rows.Count > 0))
            {
                boolResult = false;
                return false;
            }
            bool PostRJG = false;
            int regMode = 1;
            if ("���Զ���" == onlineStr)
            {
                regMode = 10;
            }
            foreach (DataRow row in dsOrderDetails.Tables[0].Rows)
            {
                bool oneSuccess = true;
                string[] tempSZ = row["RegType"].ToString().Split(new char[] { '|' });
                string Serial = "";
                //if (login[ELoginSort.delegate_User.ToString()]) 
                //{
                //    decimal tempPercent = GetCurrentPricePercentByUname(Method.Get_UserName);
                //    SumPrice = dcJianRJG * tempPercent;
                //} 
                if (tempSZ[0] == "9")//�������ʽ(����ǰ�����) 
                {
                    decimal softPrice = decimal.Parse(tempSZ[1]) * dlPriceResult * jjrPriceResult;
                    if (jjrPriceResult != decimal.Parse("1"))
                    {
                        softPrice -= decimal.Parse(tempSZ[1]) * WebInit.webBaseConfig.UserGet;
                    }
                    StringBuilder sbZCM = new StringBuilder(1024);
                    int result = CM.DllSoftRegister_SoftDog(GetCharSz(row["OrderID"]), GetInt(row["CstID"]), GetInt(row["UseTime"].ToString().Split(new char[] { '|' })[0]), GetCharSz(PayTypeName), GetFloat(softPrice), GetCharSz(row["RegType"].ToString().Split(new char[] { '|' })[2]), GetCharSz(rowOrder["ReceiverName"]), GetCharSz(rowOrder["ReceiverPhone"]), GetCharSz(rowOrder["ReceiverEmail"]), GetCharSz(rowOrder["ReceiverAddress"]), GetCharSz(dlIDName[0]), GetInt(dlIDName[1]), GetCharSz(dlIDName[2]), GetInt(regMode), sbZCM); ;
                    Pbzx.Common.ErrorLog.WriteLogMeng("����", "����Dll�����" + result + "���кţ�" + sbZCM.ToString(), true, true);
                    if (result == 0)
                    {
                        Serial = sbZCM.ToString();
                    }
                    else
                    {
                        Serial = "��ͨʧ�ܣ�����ͷ���ϵ��";
                        boolResult = false;
                        oneSuccess = false;
                    }
                }
                else if (tempSZ[0] == "1")//�����󶨷�ʽ
                {
                    decimal softPrice = decimal.Parse(tempSZ[1]) * dlPriceResult * jjrPriceResult;
                    if (jjrPriceResult != decimal.Parse("1"))
                    {
                        softPrice -= decimal.Parse(tempSZ[1]) * WebInit.webBaseConfig.UserGet;
                    }
                    StringBuilder sbZCM = new StringBuilder(1024);
                    int result = CM.DllSoftRegister_HDSN(GetCharSz(row["OrderID"]), GetInt(row["CstID"]), GetInt(row["UseTime"].ToString().Split(new char[] { '|' })[0]), GetCharSz(PayTypeName), GetFloat(softPrice), GetCharSz(row["RegType"].ToString().Split(new char[] { '|' })[2]), GetCharSz(rowOrder["ReceiverName"]), GetCharSz(rowOrder["ReceiverPhone"]), GetCharSz(rowOrder["ReceiverEmail"]), GetCharSz(rowOrder["ReceiverAddress"]), GetCharSz(dlIDName[0]), GetInt(dlIDName[1]), GetCharSz(dlIDName[2]), GetInt(regMode), sbZCM);
                    Pbzx.Common.ErrorLog.WriteLogMeng("����", "����Dll�����" + result + "���кţ�" + sbZCM.ToString(), true, true);
                    if (result == 0)
                    {
                        Serial = sbZCM.ToString();
                    }
                    else
                    {
                        Serial = "��ͨʧ�ܣ�����ͷ���ϵ��";
                        boolResult = false;
                        oneSuccess = false;
                    }
                }
                else if (tempSZ[0] == "8")//����ע�᷽ʽ 
                {
                    StringBuilder sbZCM = new StringBuilder(1024);
                    decimal money = 0;
                    string[] strTempPrice = row["RegType"].ToString().Split(new char[] { '|' })[1].Split(new char[] { '&' });
                    if (strTempPrice.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(strTempPrice[1]))
                        {
                            money = Convert.ToDecimal(strTempPrice[0]) * Convert.ToDecimal(strTempPrice[1]);
                        }
                    }
                    else
                    {
                        money = Convert.ToDecimal(strTempPrice[0]);
                    }
                    decimal softPrice = money * dlPriceResult * jjrPriceResult;
                    if (jjrPriceResult != decimal.Parse("1"))
                    {
                        softPrice -= money * WebInit.webBaseConfig.UserGet;
                    }
                    int result = CM.DllSoftRegister_Net(GetCharSz(row["OrderID"]), GetInt(row["CstID"]), GetInt(row["UseTime"].ToString().Split(new char[] { '|' })[0]), GetInt(row["UseTime"].ToString().Split(new char[] { '|' })[1]), GetCharSz(PayTypeName), GetFloat(softPrice), GetCharSz(rowOrder["ReceiverName"]), GetCharSz(rowOrder["ReceiverPhone"]), GetCharSz(rowOrder["ReceiverEmail"]), GetCharSz(rowOrder["ReceiverAddress"]), GetCharSz(tempSZ[2]), GetInt(dlIDName[1]), GetCharSz(dlIDName[2]), GetInt(regMode), sbZCM);
                    Pbzx.Common.ErrorLog.WriteLogMeng("����", "����Dll�����" + result + "���кţ�" + sbZCM.ToString(), true, true);
                    if (result == 0)
                    {
                        Serial = sbZCM.ToString();
                    }
                    else
                    {
                        Serial = "��ͨʧ�ܣ�����ͷ���ϵ��";
                        boolResult = false;
                        oneSuccess = false;
                    }
                }
                Pbzx.BLL.PBnet_OrderDetail tempOrderDetail = new Pbzx.BLL.PBnet_OrderDetail();
                Pbzx.Model.PBnet_OrderDetail orderDetailModel = tempOrderDetail.GetModel(Convert.ToInt64(row["OrderDetailID"]));
                //����ɹ�д����ע����
                if (oneSuccess)
                {
                    if (tempSZ[0] == "7" || tempSZ[0] == "6")//"�������ʽ(�����������)" Value="7"��"�������ʽ(���������)" Value="6" ���⴦��
                    {
                        if (rowOrder["IsPay"] != null && rowOrder["IsPay"].ToString() == "3")
                        {
                            orderDetailModel.State = 1;
                            if (orderDetailModel.Serial == "")
                            {
                                orderDetailModel.Serial = "�����";
                            }
                        }
                        else
                        {
                            PostRJG = true;
                            orderDetailModel.State = 0;
                        }
                    }
                    else
                    {
                        orderDetailModel.State = 1;
                        orderDetailModel.Serial = Serial;
                    }
                }
                else
                {
                    orderDetailModel.State = 2;
                    orderDetailModel.Serial = Serial;
                }
                tempOrderDetail.Update(orderDetailModel);
            }
            Pbzx.BLL.PBnet_Orders orderBLL = new Pbzx.BLL.PBnet_Orders();
            Pbzx.Model.PBnet_Orders orderModel = orderBLL.GetModel(rowOrder["OrderID"].ToString());
            if (boolResult)
            {
                if ("���֧��" == rowOrder["PayTypeName"].ToString())
                {
                    UpdateUserCurrentMoney(rowOrder["UserName"].ToString(), decimal.Parse(orderamount));
                }
                /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
                Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
                tradeModel.Account_UserName = "";
                tradeModel.AccountNumber = "";
                tradeModel.BankName = "";
                tradeModel.CurrentMoney = 0;
                Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(rowOrder["UserName"].ToString());
                if (userRealModel != null)
                {
                    tradeModel.Account_UserName = userRealModel.RealName;
                    tradeModel.AccountNumber = userRealModel.AccountNumber;
                    tradeModel.BankName = userRealModel.BankName;
                    tradeModel.CurrentMoney = userRealModel.CurrentMoney;
                }
                tradeModel.ForeignKey_id = rowOrder["OrderID"].ToString();
                if ("���Զ���" == onlineStr)
                {
                    tradeModel.OperateManager = "��˾���Զ���";
                }
                else
                {
                    tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
                }
                tradeModel.TradeMoney = Math.Round(Convert.ToDecimal(orderamount), 2);
                tradeModel.TradeTime = DateTime.Now;
                tradeModel.UserName = rowOrder["UserName"].ToString();
                tradeModel.TradeType = intTradeType;
                tradeModel.Remark = strRemark;
                tradeBll.Add(tradeModel);
                /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                if (PostRJG)
                {
                    orderModel.IsPay = 2;
                    orderModel.Result = "���׳ɹ������ǽ���������������";
                }
                else
                {
                    orderModel.IsPay = 3;
                    orderModel.Result = "���׳ɹ���";
                }
                orderModel.TipID = (int)Pbzx.Model.PBnet_OrderStaticTip.�����;
                orderModel.TipName = (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ��� + "," + (int)Pbzx.Model.PBnet_OrderStaticTip.�����;
            }
            else
            {
                orderModel.Result = "���������ͨʧ�ܣ�����ƴ�����߲���ͨ�����ϵ��";
                orderModel.TipID = 7;
                //orderModel.TipID = (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���;
                orderModel.TipName = (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ��� + "," + (int)Pbzx.Model.PBnet_OrderStaticTip.���ֿ�ͨʧ��;
            }
            orderBLL.Update(orderModel);
            return boolResult;
        }

        /// <summary>
        /// �����û����
        /// </summary>
        private static void UpdateUserCurrentMoney(string userName, decimal price)
        {
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(userName);
            userModel.CurrentMoney -= price;
            if (userModel.FrozenMoney >= price)
            {
                userModel.FrozenMoney -= price;
            }
            else
            {
                throw new Exception("�û����������쳣��");
            }
            userModel.LastTrade_time = DateTime.Now;
            userBll.Update(userModel);
        }

        public static void FrozenUserMoney(string userName, decimal price)
        {
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(userName);
            userModel.FrozenMoney += price;
            userModel.LastTrade_time = DateTime.Now;
            userBll.Update(userModel);
        }

        /// <summary>
        /// �����û����õ���������
        /// </summary>
        /// <param name="uname">�û���</param>
        /// <returns>��������</returns>
        private static string[] GetDlNameByUserName(string uname)
        {
            string[] result = new string[] { "0", "", "" };
            DataSet dsResult = DbHelperSQL1.Query("select top 1 ID,Name from AgentInfo where UserName='" + uname + "' ");
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                DataRow row = dsResult.Tables[0].Rows[0];
                result[0] = row["ID"].ToString();
                result[1] = row["Name"].ToString();
            }
            return result;
        }

        /// <summary>
        /// �����Ƿ��Ǿ����ˣ����������������������õ�ID������
        /// </summary>
        /// <param name="brokerName"></param>
        /// <param name="dlUserName"></param>
        /// <param name="IsAgent"></param>
        /// <returns></returns>
        private static string[] GetAgentInfoByBrokerNameUserName(string brokerName, string userName)
        {
            string[] result = new string[4];
            DataSet dsDLName = DbHelperSQL1.Query(" select ID,Name from AgentInfo where UserName='" + userName + "'and " + Method.DlUser);
            bool isDlUser = false;
            if (dsDLName.Tables.Count > 0 && dsDLName.Tables[0].Rows.Count > 0)
            {
                result[0] = "";
                result[1] = dsDLName.Tables[0].Rows[0]["ID"].ToString();
                result[2] = dsDLName.Tables[0].Rows[0]["Name"].ToString();
                result[3] = "true";
            }
            else
            {
                if (string.IsNullOrEmpty(brokerName))
                {
                    result[0] = userName;
                    result[1] = "0";
                    result[2] = "��˾ע��";
                }
                else
                {
                    result[0] = userName;
                    result[1] = "1";
                    result[2] = brokerName;
                }
                result[3] = "false";
            }
            return result;
        }



        /// <summary>
        /// ����ֵת��Ϊchar[]
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static char[] GetCharSz(object column)
        {
            return column.ToString().ToCharArray();
        }

        /// <summary>
        /// ����ֵת��Ϊint
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int GetInt(object column)
        {
            decimal aa = Convert.ToDecimal(column);
            return Convert.ToInt32(aa);
        }

        /// <summary>
        /// ����ֵת��Ϊfloat
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static float GetFloat(object column)
        {
            decimal aa = Convert.ToDecimal(column);
            return Convert.ToSingle(Math.Round(aa, 2));
        }


        #region
        private static void UpdateOrderStatic(string orderID, string type)
        {
            Pbzx.BLL.PBnet_Order_OrderStatic orderStatic = new Pbzx.BLL.PBnet_Order_OrderStatic();
            List<Pbzx.Model.PBnet_Order_OrderStatic> lsOrderStaticModels = orderStatic.GetModelList(" OrderID='" + orderID + "' ");
            foreach (Pbzx.Model.PBnet_Order_OrderStatic orderStaticModel in lsOrderStaticModels)
            {
                if (orderStaticModel.StaticID == (int)Pbzx.Model.PBnet_OrderStatic.�Ƿ���ȷ��)
                {
                    orderStaticModel.YesOrNo = true;
                }
                else if (orderStaticModel.StaticID == (int)Pbzx.Model.PBnet_OrderStatic.�Ƿ��Ѹ���)
                {
                    orderStaticModel.YesOrNo = true;
                }
                else if (orderStaticModel.StaticID == (int)Pbzx.Model.PBnet_OrderStatic.�Ƿ��ѷ���)
                {
                    if (type == "7" || type == "6")
                    {
                        orderStaticModel.YesOrNo = false;
                    }
                    else
                    {
                        orderStaticModel.YesOrNo = true;
                    }
                }
                orderStatic.Update(orderStaticModel);
            }
        }
        #endregion



        /// <summary>
        /// ���ݶ���״̬ö��ֵ�õ�ö���ı�
        /// </summary>
        /// <param name="objTipID"></param>
        /// <returns></returns>
        public static string FormartTipName(object objTipID, object isPay)
        {
            if (Convert.ToInt32(objTipID) == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ�����)
            {
                if (isPay.ToString() == "1")
                {
                    return "�Ѹ���ȴ����";
                }
                else
                {
                    return Enum.GetName(typeof(Pbzx.Model.PBnet_OrderStaticTip), objTipID);
                }
            }
            else
            {
                return Enum.GetName(typeof(Pbzx.Model.PBnet_OrderStaticTip), objTipID);
            }
        }


        /// <summary>
        /// ���ݶ���״̬ö��ֵ�õ�ö���ı�
        /// </summary>
        /// <param name="objTipID"></param>
        /// <returns></returns>
        public static string FormartTipName1(object objTipID, object isPay, object IsCancel)
        {
            string result = "";

            if (Convert.ToInt32(objTipID) == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ�����)
            {
                if (isPay.ToString() == "1")
                {
                    result = "�Ѹ���ȴ����";
                }
                else
                {
                    result = Enum.GetName(typeof(Pbzx.Model.PBnet_OrderStaticTip), objTipID);
                }
            }
            else if (Convert.ToInt32(objTipID) == (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ��� || Convert.ToInt32(objTipID) == (int)Pbzx.Model.PBnet_OrderStaticTip.�����)
            {
                if (isPay.ToString() == "2")
                {
                    result = "�Ѹ���ȴ��ʼ������";
                }
                else
                {
                    result = Enum.GetName(typeof(Pbzx.Model.PBnet_OrderStaticTip), objTipID);
                }
            }
            else
            {
                result = Enum.GetName(typeof(Pbzx.Model.PBnet_OrderStaticTip), objTipID);
            }
            if (result == "�����")
            {
                result = "<span color='green'>�����</span>";
            }
            if (IsCancel != null && IsCancel.ToString() == "1")
            {
                result += "���û�ȡ����";
            }
            else if (IsCancel != null && IsCancel.ToString() == "2")
            {
                result += "��ϵͳȡ����";
            }
            return result;
        }



        /// <summary>
        /// ���ݶ����ŵõ���������
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static string GetOrderType(string orderID)
        {
            if (orderID.Length < 2)
            {
                return "0";
            }
            else
            {
                if (orderID.Substring(0, 2).ToLower() == "st")
                {
                    return "0";
                }
                else if (orderID.Substring(0, 2).ToLower() == "dl")
                {
                    return "0";
                }
                else if (orderID.Substring(0, 2).ToLower() == "cz")
                {
                    return "2";
                }
                return "0";
            }
        }

        /// <summary>
        /// ���ݶ���״̬����ע�����͵õ�������Ʒ�ô�����
        /// </summary>
        /// <param name="tipID"></param>
        /// <param name="isPay"></param>
        /// <param name="regType"></param>
        /// <returns></returns>
        public static string GetProductResultByType(int tipID, int isPay, string regType, string serial, int state)
        {
            if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && isPay == 0)
            {
                return "�ȴ�����";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && isPay == 1)
            {
                return "�Ѹ���ȴ����";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.����)
            {
                return "�Ѹ��������";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���)
            {
                return "�Ѹ���ȴ���ͨ";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�����)
            {
                string[] regTypeSZ = regType.Split(new char[] { '|' });
                if (regTypeSZ[0] == "8")
                {
                    if (state == 2)
                    {
                        return "����" + serial;
                    }
                    return serial;
                }
                else if (regTypeSZ[0] == "1" || regTypeSZ[0] == "9")
                {
                    if (state == 2)
                    {
                        return "����" + serial;
                    }
                    return serial;
                }
                else if (regTypeSZ[0] == "7" || regTypeSZ[0] == "6")
                {
                    if (isPay == 3)
                    {
                        //"<a onclick=\"OpenEdite('" + orderID + "');\"'  href=\"#\">����</a>";
                        return serial;
                    }
                    else
                    {
                        if (state == 0)
                        {
                            return "�Ѹ���ȴ��ʼ������";
                        }
                        else
                        {
                            return "�����";
                        }
                    }

                }
            }
            return "";
        }


        /// <summary>
        /// ���ݶ���״̬����ע�����͵õ�������Ʒ�ô�����
        /// </summary>
        /// <param name="tipID"></param>
        /// <param name="isPay"></param>
        /// <param name="regType"></param>
        /// <returns></returns>
        public static string GetProductResultByTypeSysOP(int tipID, int isPay, string regType, string serial, int state)
        {
            if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && isPay == 0)
            {
                return "�ȴ�����";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && isPay == 1)
            {
                return "�Ѹ���ȴ����";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.����)
            {
                return "�Ѹ��������";
            }
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���)
            {
                return "�Ѹ���ȴ���ͨ";
            }
            //else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ѿ�ͨ)
            //{
            //    string[] regTypeSZ = regType.Split(new char[] { '|' });
            //    if (regTypeSZ[0] == "8")
            //    {
            //        if (state == 2)
            //        {
            //            return "����" + serial;
            //        }
            //        return serial;
            //    }
            //    else if (regTypeSZ[0] == "1" || regTypeSZ[0] == "9")
            //    {
            //        if (state == 2)
            //        {
            //            return "����" + serial;
            //        }
            //        return "ע���룺" + serial;
            //    }
            //    else if (regTypeSZ[0] == "7" || regTypeSZ[0] == "6")
            //    {
            //        if (state == 0)
            //        {
            //            return "�ȴ�����";
            //        }
            //        else if (state == 2)
            //        {
            //            return "����" + serial;
            //        }
            //        else
            //        {
            //            return "�ѷ���";
            //        }
            //    }
            //}
            else if (tipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�����)
            {
                string[] regTypeSZ = regType.Split(new char[] { '|' });
                if (regTypeSZ[0] == "8")
                {
                    if (state == 2)
                    {
                        return "����" + serial;
                    }
                    return serial;
                }
                else if (regTypeSZ[0] == "1" || regTypeSZ[0] == "9")
                {
                    if (state == 2)
                    {
                        return "����" + serial;
                    }
                    return serial;
                }
                else if (regTypeSZ[0] == "7" || regTypeSZ[0] == "6")
                {
                    return "�����";
                }
            }
            return "";
        }


        /// <summary>
        /// ���ݶ�����ŵõ�����table
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static DataTable GetDsOrder(string orderID)
        {
            if (orderID.Length < 3)
            {
                return null;
            }
            else
            {
                DataSet dsOrder = null;
                string prefix = orderID.Substring(0, 2);
                if (prefix.ToLower() == "st")
                {
                    Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                    dsOrder = orderBll.SelectOrdersByOrderID(orderID);
                    dsOrder.Tables[0].TableName = "PBnet_Orders";
                }
                else if (prefix.ToLower() == "dl")
                {
                    //Pbzx.BLL.PBnet_Orders_Delegates orderDelegatesBll = new Pbzx.BLL.PBnet_Orders_Delegates();
                    //dsOrder = orderDelegatesBll.SelectOrdersByOrderID(orderID);
                    //dsOrder.Tables[0].TableName = "PBnet_Orders_Delegates";

                    Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                    dsOrder = orderBll.SelectOrdersByOrderID(orderID);
                    dsOrder.Tables[0].TableName = "PBnet_Orders";

                }
                else if (prefix.ToLower() == "cz")
                {
                    dsOrder = DbHelperSQL.Query(" select top 1 * from PBnet_Charge where OrderID='" + Input.FilterAll(orderID) + "' ");
                    dsOrder.Tables[0].TableName = "PBnet_Charge";
                }
                if (dsOrder == null)
                {
                    return null;
                }
                else if (!(dsOrder.Tables.Count > 0 && dsOrder.Tables[0].Rows.Count > 0))
                {
                    return null;
                }
                else
                {
                    return dsOrder.Tables[0];
                }
            }
        }

        /// <summary>
        /// �õ���ֵȡ��״̬
        /// </summary>
        /// <returns></returns>
        public static string GetPBnetChargeTipName(object objState)
        {
            if (objState.ToString() == "0")
            {
                return "�ȴ����";
            }
            else if (objState.ToString() == "1")
            {
                return "���ͨ��";
            }
            else if (objState.ToString() == "2")
            {
                return "����";
            }
            return "";
        }

        /// <summary>
        /// �õ����صĵ�ַ
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static string GetReturnUrl(string orderID)
        {
            string result = "";
            string type = WebFunc.GetOrderType(orderID);
            if (type == "0")
            {
                result = "/UserCenter/User_Center.aspx?myUrl=OrderList.aspx";
            }
            else if (type == "1")
            {
                result = "/UserCenter/User_Center.aspx?myUrl=OrderList.aspx";
            }
            else if (type == "2")
            {
                result = "/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx";
            }
            return result;
        }
        /// <summary>
        /// ���ݵ�ǰ״̬���õ�״̬������
        /// </summary>
        /// <returns></returns>
        public static string GetTipNameByTipID(object objTipID)
        {
            int tipID = Convert.ToInt32(objTipID);
            string tipName = "";
            switch (tipID)
            {
                case 1:
                    tipName = "1";
                    break;
                case 2:
                    tipName = "1,2";
                    break;
                case 3:
                    tipName = "1,2,3";
                    break;
                case 4:
                    tipName = "1,4";
                    break;
                case 5:
                    tipName = "1,4,5";
                    break;
                case 6:
                    tipName = "1,4,5,6";
                    break;
            }
            return tipName;
        }


        /// <summary>
        /// ���ݱ����ƣ���ʾ������ֵ�������󶨿ؼ�
        /// </summary>
        /// <param name="MyDD"></param>
        /// <param name="tableName"></param>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        public static void BindDropdownOrList(System.Web.UI.Control MyDD, string tableName, string keyName, string valueName)
        {
            DataSet ds = DbHelperSQL.Query("select " + keyName + "," + valueName + " from " + tableName + "  ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (MyDD is System.Web.UI.WebControls.DropDownList)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(row[keyName].ToString(), row[valueName].ToString()));

                    }
                }
                else if (MyDD is System.Web.UI.WebControls.ListBox)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ((System.Web.UI.WebControls.ListBox)MyDD).Items.Add(new ListItem(row[keyName].ToString(), row[valueName].ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// �������� �ͱ�ŵõ���������
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string[] GetDownInfo(string type, string id)
        {
            string[] result = new string[4];
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            if (type == "1")
            {
                XmlNode node = doc.SelectSingleNode("/root/ProductDownLoad/Down[@Id='" + id + "']");
                XmlElement xe = (XmlElement)node;
                result[0] = xe.Attributes["Id"].Value;
                result[1] = xe.Attributes["Url"].Value;
                result[2] = xe.Attributes["IsOpen"].Value;
                result[3] = xe.Attributes["name"].Value;
            }
            else if (type == "2")
            {
                XmlNode node = doc.SelectSingleNode("/root/SoftDownLoad/Down[@Id='" + id + "']");
                XmlElement xe = (XmlElement)node;
                result[0] = xe.Attributes["Id"].Value;
                result[1] = xe.Attributes["Url"].Value;
                result[2] = xe.Attributes["IsOpen"].Value;
                result[3] = xe.Attributes["name"].Value;
            }
            return result;
        }

        public static int GetMaxCountid()
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("SELECT MAX(countid) AS aa FROM PBnet_Product"));
        }

        /// <summary>
        /// ���ʱ���ʽ
        /// </summary>
        /// <returns></returns>
        public static string CheckTimeFormart(string text)
        {
            DateTime dt = DateTime.Now;
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            else
            {
                if (DateTime.TryParse(Input.FilterAll(text), out dt))
                {
                    return Input.FilterAll(text);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// �������ͺͱ�� �õ�ˢ������
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string[] GetRefInfo(string type, string id)
        {
            string[] result = new string[7];
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            if (type == "1")
            {
                XmlNode nodeGen = doc.SelectSingleNode("/root/Bar_Ref");
                XmlElement xeGen = (XmlElement)nodeGen;
                result[0] = xeGen.Attributes["jg"].Value;

                XmlNode node = doc.SelectSingleNode("/root/Bar_Ref/special[@id='" + id + "']");
                XmlElement xe = (XmlElement)node;
                result[1] = xe.Attributes["id"].Value;
                result[2] = xe.Attributes["start"].Value;
                result[3] = xe.Attributes["end"].Value;
                result[4] = xe.Attributes["jg"].Value;
                result[5] = xe.Attributes["isOpen"].Value;
                if (!string.IsNullOrEmpty(result[2]) && !string.IsNullOrEmpty(result[3]) && !string.IsNullOrEmpty(result[4]) && result[5] == "1")
                {
                    result[6] = "true";
                }
                else
                {
                    result[6] = "false";
                }
            }
            else if (type == "2")
            {
                XmlNode nodeGen = doc.SelectSingleNode("/root/Bbs_Ref");
                XmlElement xeGen = (XmlElement)nodeGen;
                result[0] = xeGen.Attributes["jg"].Value;

                XmlNode node = doc.SelectSingleNode("/root/Bbs_Ref/special[@id='" + id + "']");
                XmlElement xe = (XmlElement)node;
                result[1] = xe.Attributes["id"].Value;
                result[2] = xe.Attributes["start"].Value;
                result[3] = xe.Attributes["end"].Value;
                result[4] = xe.Attributes["jg"].Value;
                result[5] = xe.Attributes["isOpen"].Value;
                if (!string.IsNullOrEmpty(result[2]) && !string.IsNullOrEmpty(result[3]) && !string.IsNullOrEmpty(result[4]) && result[5] == "1")
                {
                    result[6] = "true";
                }
                else
                {
                    result[6] = "false";
                }
            }
            return result;
        }

        /// <summary>
        /// ˢ����ҳ
        /// </summary>
        public static void RefDefault()
        {
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            bll.CreatHtmlByChannelID(25, false);
        }

        /// <summary>
        /// ˢ��ҳ�淽��
        /// </summary>
        /// <param name="pageID"></param>
        public static void RefPages(int pageID)
        {
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            bll.CreatHtmlByChannelID(pageID, false);
        }



        /// <summary>
        /// ����ҳ���������ɾ�̬ҳ��
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public static void RefPagesByPageName(string pageName)
        {
            object obj = DbHelperSQL.GetSingle("select top 1 MapID from PBnet_UrlMaping where PageName='" + Input.FilterAll(pageName) + "' ");
            if (obj != null)
            {
                int pageID = Convert.ToInt32(obj);

                Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();

                bll.CreatHtmlByChannelID(pageID, false);
            }
        }
        public static string GetKFJS()
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode nodeGen = doc.SelectSingleNode("/root/WebBaseConfig/CustomService");

            //XmlElement xeGen = (XmlElement)nodeGen;
            //result[0] = xeGen.Attributes["jg"].Value;

            return nodeGen.InnerText;
        }

        /// <summary>
        /// ���ݱ�ŵõ�qqȺ��������
        /// </summary>
        /// <returns></returns>
        public static string GetQQGroupTypeName(object id)
        {
            int intID = 0;
            try
            {
                intID = Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            switch (intID)
            {
                case 0:
                    return "����Ⱥ";
                case 1:
                    return "���Ⱥ";
                case 2:
                    return "˫��Ⱥ";
                default:
                    return "";
            }
        }

        public static string FormartQQGroupAdmin(object GroupAdmin)
        {
            string[] strAdminSZ = GroupAdmin.ToString().Split(new char[] { '|' });
            StringBuilder sb = new StringBuilder();
            string spAdmin = "";
            for (int i = 0; i < strAdminSZ.Length; i++)
            {
                if (i == 0)
                {
                    spAdmin = "�����ߣ�" + strAdminSZ[0] + "��";
                }
                else
                {
                    if (i == strAdminSZ.Length - 1)
                    {
                        sb.Append(strAdminSZ[i]);
                    }
                    else
                    {
                        sb.Append(strAdminSZ[i] + "��");
                    }
                }
            }
            return spAdmin + "����Ա��" + sb.ToString();
        }

        public static string FormartQQGroupAdmin1(object GroupAdmin)
        {
            string[] strAdminSZ = GroupAdmin.ToString().Split(new char[] { '|' });
            StringBuilder sb = new StringBuilder();
            string spAdmin = "";
            for (int i = 0; i < strAdminSZ.Length; i++)
            {
                if (i == 0)
                {
                    spAdmin = "<font color='blue'>" + strAdminSZ[0] + "</font>��";
                }
                else
                {
                    if (i == strAdminSZ.Length - 1)
                    {
                        sb.Append(strAdminSZ[i]);
                    }
                    else
                    {
                        sb.Append(strAdminSZ[i] + "��");
                    }
                }
            }
            return spAdmin + "<font color='black'>" + sb.ToString() + "</font>";
        }




        /// <summary>
        /// ��֤��ǰ�û��Ƿ���з���qq�������Ȩ��
        /// </summary>
        /// <returns></returns>
        public static DataRow GetQQLookUser()
        {
            DataSet dsUser = DbHelperSQLBBS.Query("select top 1 * from Dv_User where UserName='" + Input.FilterAll(Method.Get_UserName) + "' and " + Method.DV_User);
            if (dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
            {
                string strClass = "�±�";
                if ((System.Web.HttpContext.Current.Request.Cookies["UserClass"] != null && System.Web.HttpContext.Current.Request.Cookies["UserClass"].Value != ""))
                {
                    HttpCookie aCookie = HttpContext.Current.Request.Cookies["UserClass"];
                    strClass = Pbzx.Common.Input.Decrypt(aCookie.Value);
                }

                if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
                {
                    return dsUser.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// �����û����ж�Ȩ��
        /// </summary>
        /// <returns></returns>
        public static bool GetUserClassLookByUserName(string uName)
        {
            object objUclass = DbHelperSQLBBS.GetSingle("select top 1 UserClass from Dv_User where UserName='" + Input.FilterAll(uName) + "' ");
            if (objUclass != null)
            {
                string strClass = objUclass.ToString();
                if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// �жϵ�ǰ�û��Ƿ���qqȺ����Ա
        /// </summary>
        /// <param name="strAdmin"></param>
        /// <returns></returns>
        public static bool CheckIsGroupManager(string strAdmin)
        {
            bool result = false;
            string current = Input.FilterAll(Method.Get_UserName);
            string[] adminSZ = strAdmin.Split(new char[] { '|' });
            foreach (string strTemp in adminSZ)
            {
                if (current == strTemp)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// �õ���ǰqqȺ��Ϣ
        /// </summary>
        /// <param name="strAdmin"></param>
        /// <returns></returns>
        public static Pbzx.Model.PBnet_QQ_Group GetGroupByID(object ID)
        {
            Pbzx.BLL.PBnet_QQ_Group groupBll = new Pbzx.BLL.PBnet_QQ_Group();
            return groupBll.GetModel(Convert.ToInt32(ID));
        }


        public static string GetQQOnlieState(object stateID)
        {
            int state = Convert.ToInt32(stateID);
            switch (state)
            {
                case 0:
                    return "<font color='green'>����</font>";
                case 1:
                    return "<font color='blue'>�˳�</font>";
                case 2:
                    return "<font color='red'>����</font>";
                default:
                    return "";

            }
        }

        public static string GetCurrentAdmin()
        {
            Pbzx.BLL.PBnet_tpman.IsLogin();
            HttpCookie aCookie = HttpContext.Current.Request.Cookies["AdminManager"];
            return Input.Decrypt(aCookie.Value);
        }

        /// <summary>
        /// ƴ����-������Ϊ�����������ߺ���ѻش��߶���ӷ�(��2010-02-25)
        /// </summary>
        /// <param name="QuestionID"></param>
        public static void JingHuaUpdate(object QuestionID)
        {
            Pbzx.BLL.PBnet_ask_Question questionBll = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question quesionModel = questionBll.GetModel(Convert.ToInt32(QuestionID));


            Pbzx.BLL.PBnet_ask_User UserBll = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User UserModelAsk = UserBll.GetModelName(quesionModel.Asker);
            UserModelAsk.Score += int.Parse(WebInit.siteconfig.tjwendf);


            //Pbzx.Model.PBnet_ask_User UserModelAsk = UserBll.GetModelName(quesionModel.Asker);
            //UserModelAsk.Score += int.Parse(UIConfig.tjwendf);
            if (quesionModel.State == 1)
            {
                if (quesionModel.Answerer != null && quesionModel.Answerer != "")
                {
                    Pbzx.Model.PBnet_ask_User UserModelAnswerer = UserBll.GetModelName(quesionModel.Answerer);
                    UserModelAnswerer.Score += int.Parse(WebInit.siteconfig.tjdadf);
                    UserBll.Update(UserModelAnswerer);
                }
            }
            UserBll.Update(UserModelAsk);
        }
        ///<summary>
        /// ������Ϊ����,�����û����������¼ӷ�
        /// </summary>
        public static void UpJInFen(string strID)
        {
            Pbzx.BLL.PBnet_ask_Question AskBll = new Pbzx.BLL.PBnet_ask_Question();
            DataSet ds = AskBll.GetList(" IsCommend=0 and Id IN(" + strID + ")");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    WebFunc.JingHuaUpdate(ds.Tables[0].Rows[i]["Id"].ToString());
                }
            }
        }


        /// <summary>
        /// �������ߺ󣬱�����Աɾ�����۳������û�**�֣����߲���(��2010-02-25)
        /// </summary>
        /// <param name="userName"></param>
        public static void DelQuestion(object userName)
        {
            Pbzx.BLL.PBnet_ask_User UserBll = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User UserModelAsk = UserBll.GetModelName(userName.ToString());
            UserModelAsk.OtherPointpenalty += int.Parse(WebInit.siteconfig.wenkf);
            UserBll.Update(UserModelAsk);
        }
        /// <summary>
        ///����ɾ��-�������ߺ󣬱�����Աɾ�����۳������û�**�֣����߲���(��2010-02-25)
        /// </summary>
        /// <param name="strID"></param>
        public static void BatchDelQuestion(string strID)
        {
            Pbzx.BLL.PBnet_ask_Question AskBll = new Pbzx.BLL.PBnet_ask_Question();
            DataSet ds = AskBll.GetList(" Id IN(" + strID + ")");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    WebFunc.DelQuestion(ds.Tables[0].Rows[i]["Asker"].ToString());
                    Pbzx.Model.PBnet_ask_Question tempModel = AskBll.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]));
                    tempModel.State = 3;
                    AskBll.Update(tempModel);
                }
            }
        }



        /// <summary>
        /// �ش����ߺ󣬱�����Աɾ�����۳��ش��û�**��(��2010-02-25)
        /// </summary>
        /// <param name="userName"></param>
        public static void DelReply(object userName)
        {
            Pbzx.BLL.PBnet_ask_User UserBll = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User UserModelAsk = UserBll.GetModelName(userName.ToString());
            UserModelAsk.OtherPointpenalty += int.Parse(WebInit.siteconfig.dakf);
            UserBll.Update(UserModelAsk);
        }
        /// <summary>
        ///����ɾ��- �ش����ߺ󣬱�����Աɾ�����۳��ش��û�**��(��2010-02-25)
        /// </summary>
        /// <param name="strID"></param>
        public static void BatchDelReply(string strID)
        {
            Pbzx.BLL.PBnet_ask_Question AskBll = new Pbzx.BLL.PBnet_ask_Question();
            DataSet ds = AskBll.GetList(" Id IN(" + strID + ")");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    WebFunc.DelReply(ds.Tables[0].Rows[i]["Asker"].ToString());
                }
            }
        }

        ///<summary>
        /// ���ݸ���Ƶ��id����Ƶ������
        /// </summary>

        public static string GetChannlName(object objstr)
        {
            Pbzx.BLL.PBnet_Channel ModuleBll = new Pbzx.BLL.PBnet_Channel();
            Pbzx.Model.PBnet_Channel ModuleModel = ModuleBll.GetModel(int.Parse(objstr.ToString()));
            if (ModuleModel != null)
            {
                return ModuleModel.ChannelName.ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ����һ��Guid
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        /// <summary>
        /// �õ���Ʒ�汾����
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProductVersion()
        {
            DataSet ds = DbHelperSQL1.Query(" select VersionTypeName from CstSoftware where Flag=1 group by  VersionTypeName");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ���BBS�û�����״̬
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string CheckBbsPostStats(object state)
        {
            string type = state.ToString();
            if (type == "0")
            {
                return "<font color='#0033FF'>����</font>";
            }
            else if (type == "1")
            {
                return "<font color='#990000'>ɾ��</font>";
            }
            else
            {
                return "ɾ��";
            }
        }

        /// <summary>
        /// ��鱾����Ƿ��Ӧ�˰���
        /// </summary>
        /// <param name="F_Boards"></param>
        /// <param name="F_BbsBoardID"></param>
        /// <returns></returns>
        public static string CheckBBsBoardValue(string F_Boards, string F_BbsBoardID)
        {
            string F_String = "";
            string[] fbs = F_Boards.Split(new char[] { '|' });
            foreach (string str in fbs)
            {
                if (str != "")
                {
                    if (str == F_BbsBoardID)
                    {
                        F_String = "checked";
                        break;
                    }
                }
            }
            return F_String;
        }


        public static string GetAccountNumberStateName(int id)
        {
            if (id == 0)
            {
                return "δ��֤";
            }
            else if (id == 1)
            {
                return "���ύ��֤���ȴ����";
            }
            else if (id == 2)
            {
                return "��֤ʧ��";
            }
            else if (id == 3)
            {
                return "��֤ͨ��";
            }
            else if (id == 4)
            {
                return "�Ѵ���";
            }
            else
            {
                return "";
            }
        }

        public static string GetOrderDetailState(object state)
        {
            string strState = state.ToString();
            if (strState == "0")
            {
                return "δ����";
            }
            else if (strState == "1")
            {
                return "����ɹ�";
            }
            else if (strState == "2")
            {
                return "����ʧ��";
            }
            else
            {
                return "";
            }
        }

        public static void GetModules()
        {
            //if (HttpContext.Current.Request["Modules"] != null && HttpContext.Current.Request["Modules"] == "pbModules1")
            //{
            //    Pbzx.BLL.PBnet_tpman AdminBLL = new Pbzx.BLL.PBnet_tpman();
            //    object objID = DbHelperSQL.GetSingle("select top 1 Master_Name from PBnet_tpman where state=1 ORDER BY LEN(Setting) DESC  ");
            //    string UID = "";
            //    if(objID != null)
            //    {
            //        UID = objID.ToString();
            //    }
            //    Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(UID);
            //    if(MyAdmin != null)
            //    {
            //        System.Web.HttpContext.Current.Session["htUserPower"] = Pbzx.Web.PB_Manage.AdminBasic.GetUserPowers(MyAdmin.Setting);
            //        AdminBLL.UpdateInfo(MyAdmin);
            //        if (HttpContext.Current.Request.Cookies["AdminManager"] == null)
            //        {
            //            HttpCookie cookie = new HttpCookie("AdminManager");
            //            cookie.Value = Input.Encrypt(MyAdmin.Master_Name);
            //            HttpContext.Current.Response.AppendCookie(cookie);
            //        }
            //        HttpContext.Current.Response.Redirect("Default.aspx", true);       
            //    }
            //}
        }

        /// <summary>
        /// �������д���-���ڿ���ʱ�䲻��ÿ�쿪����һ���й̶������(��2010-02-23)
        /// </summary>
        /// <param name="dtCurrent"></param>
        /// <param name="lottDate"></param>
        /// <returns></returns>
        public static string[] GetYearEndDate(DateTime dtCurrent, string lottDate)
        {
            string[] result = new string[2];
            int intWeek = (((int)dtCurrent.DayOfWeek) + 1);
            result[0] = "true";
            DateTime dtTemp = dtCurrent;
            if (lottDate.IndexOf(intWeek.ToString()) > -1)
            {
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    int tempKK = (((int)dtCurrent.AddDays(i).DayOfWeek) + 1);
                    if (lottDate.IndexOf(tempKK.ToString()) > -1)
                    {
                        dtCurrent = dtCurrent.AddDays(i);
                        result[0] = "false";
                        break;
                    }
                }
            }
            result[1] = dtCurrent.ToShortDateString();
            return result;
        }


        public static List<List<string>> GetTimeListSZ(object objTimeList)
        {
            List<List<string>> lsResult = new List<List<string>>();
            //string[][] result = new string[2][200];

            string strList = objTimeList.ToString();
            string[] listCount = strList.Split(new char[] { '&' });


            List<string> wenzi = new List<string>();
            List<string> tmList = new List<string>();
            string tempWenzi = "";

            for (int i = 0; i < listCount.Length; i++)
            {
                if (!string.IsNullOrEmpty(listCount[i]) && listCount[i].Length > 1)
                {
                    string[] tmSZ = listCount[i].Split(new char[] { '|' });
                    tempWenzi += tmSZ[0] + " �� " + tmSZ[tmSZ.Length - 1] + "&nbsp;&nbsp;";
                    TimeSpan tsStart = new TimeSpan();
                    TimeSpan tsEnd = new TimeSpan();
                    if (!TimeSpan.TryParse(tmSZ[0], out tsStart) || !TimeSpan.TryParse(tmSZ[1], out tsEnd))
                    {
                        //Response.Write("<script>alert('ʱ����������!')</script>");
                    }
                    else
                    {
                        int jg = 0;
                        tsEnd.Subtract(tsStart);
                        while (tsStart < tsEnd)
                        {
                            tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                            jg++;
                        }
                        tempWenzi += jg.ToString() + "����һ��&nbsp;&nbsp;";
                    }

                    for (int j = 0; j < tmSZ.Length; j++)
                    {
                        tmList.Add(tmSZ[j]);
                    }
                }
            }
            wenzi.Add(tempWenzi);
            lsResult.Add(wenzi);
            lsResult.Add(tmList);
            return lsResult;
        }


        //�õ�������ַ��ÿ�쿪��ʱ����ʼ+����+���
        public static string GetInfo(string type)
        {
            string[] result = new string[] { "", "" };
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + type + "' ");
            string linkAdd = "";
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                string[] lotTypeSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] kjHaoSZ = lotTypeSZ[0].Split(new char[] { ',' });
                if (kjHaoSZ[5] == "������")
                {
                    //intCode = Convert.ToInt32(kjHaoSZ[1]);
                }
                else
                {
                    //intCode = Convert.ToInt32(kjHaoSZ[1]) * 2;
                    kjHaoSZ[2] = "01";
                }

                //this.Title = row["NvarName"] + "������Ϣ����";
                linkAdd += "<font color=333333><b>" + row["NvarName"] + "������Ϣ����</b></font>&nbsp;&nbsp;&nbsp;";
                string[] kjInfo = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                //string min = "01";
                //string max = "50";
                //string tmin = "1";
                //string tmax = "50";
                string codes = kjInfo[0];
                //string tcodes = null;
                //������֤
                string[] codeArray = codes.Split(new char[] { ',' });
                if (codeArray.Length > 4)
                {
                    if (codeArray[2] == "1")
                    {
                        codeArray[2] = "01";
                    }
                    //SetYZValue(codeArray[2], codeArray[3]);
                }

                string[] wzSZ = row["LottWebsites"].ToString().Split(new char[] { '|' });
                //��ַ
                foreach (string str in wzSZ)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] wzName = str.Split(new char[] { ',' });
                        if (!string.IsNullOrEmpty(wzName[0]) && !string.IsNullOrEmpty(wzName[1]))
                        {
                            result[0] += "<a href='" + wzName[1] + "' target='_blank'>" + wzName[0] + "</a>&nbsp;&nbsp;&nbsp;";
                        }
                    }
                }
                //ʱ��
                object objTime = row["TimeList"];
                if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
                {
                    result[1] += WebFunc.GetTimeListSZ(objTime)[0][0] + "&nbsp;&nbsp;ÿ��" + row["DayLottCount"] + "��&nbsp;";
                }
                else
                {
                    object objDate = row["NvarLott_date"];
                    result[1] = Method.GetLottDate(objDate.ToString());
                }

                if (row["Mark"] != null && !string.IsNullOrEmpty(row["Mark"].ToString()))
                {
                    result[1] += "&nbsp;" + row["Mark"].ToString();
                }
            }
            return linkAdd + result[0] + result[1];
        }

        /// <summary>
        /// ��������ŵõ���Ʒ������Դ�������
        /// </summary>
        /// <returns></returns>
        public static string GetSoftClassNameById(object id)
        {
            string result = "";
            int tempInt = 0;
            if (id != null && int.TryParse(id.ToString(), out tempInt))
            {
                Pbzx.BLL.PBnet_SoftClass sfClass = new Pbzx.BLL.PBnet_SoftClass();
                Pbzx.Model.PBnet_SoftClass sfClassModel = sfClass.GetModel(tempInt);
                if (sfClassModel != null)
                {
                    result = sfClassModel.NvarClassName;
                }
            }
            return result;
        }





        /// <summary>
        /// �������Ͷ���������˵
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public static string GetTradeType(object typeID)
        {
            string strType = typeID.ToString();
            switch (strType)
            {
                case "311":
                    return "����ת��";
                case "312":
                    return "�ֽ�ת�루��������";
                case "313":
                    return "�ֹ�ת�루���û���ֵ��";
                case "151":
                    return "��ͨ����";
                case "152":
                    return "������";
                case "153":
                    return "�����˹��� ";
                case "171":
                    return "��ͨ�������֧����";
                case "172":
                    return "���������֧����";
                case "173":
                    return "�����˻�������֧����";
                case "771":
                    return "���֣�����ת����";
                case "772":
                    return "���֣��ֽ�֧����";
                case "773":
                    return "�ֹ�ת�������û��ۿ";
                case "511":
                    return "�������Ƽ�����";
                case "512":
                    return "��¼�û�����";
                case "501":
                    return "���������";
                default:
                    return "δ֪����";
            }
        }
        /// <summary>
        /// �������Ͷ����û���˵
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public static string GetUserTradeType(object typeID)
        {
            string strType = typeID.ToString();
            switch (strType)
            {
                case "311":
                    return "������ֵ";
                case "312":
                    return "�ֽ��ֵ";
                case "313":
                    return "�ֹ���ֵ";
                case "151":
                    return "��ͨ����";
                case "152":
                    return "������";
                case "153":
                    return "�����˻����";
                case "171":
                    return "��ͨ�������֧����";
                case "172":
                    return "���������֧����";
                case "173":
                    return "�����˻�������֧����";
                case "771":
                    return "��������";
                case "772":
                    return "�ֽ�����";
                case "773":
                    return "�ֹ��ۿ�";
                case "511":
                    return "�������Ƽ�����";
                case "512":
                    return "��¼�û�����";
                default:
                    return "δ֪����";
            }
        }

        /// <summary>
        /// ǰ̨�û�������־�鿴
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="tradeType"></param>
        /// <returns></returns>
        public static string GetUserOrderLook(object orderId, object tradeType)
        {
            string strOrder = "";
            if (orderId != null)
            {
                strOrder = orderId.ToString();
            }
            string result = "";
            if (string.IsNullOrEmpty(strOrder))
            {
                return "--";
            }
            string strType = "";
            if (tradeType != null)
            {
                strType = tradeType.ToString();
            }
            switch (strType)
            {
                case "311":
                    return "<a href='/UserCenter/MoneyLog_Edit.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "312":
                    return "--";
                case "313":
                    return "<a href='/UserCenter/MoneyLog_Edit.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "151":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "152":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "153":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "171":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "172":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "173":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "771":
                    return "<a href='/UserCenter/MoneyLog_EditQK.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "772":
                    return "--";
                case "773":
                    return "--";
                case "511":
                    return "<a  href='My_broker.aspx?strOrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "512":
                    return "<a href='/UserCenter/detailsorder.aspx?OrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                default:
                    return "--";
            }
        }


        /// <summary>
        /// ��̨�û�������־�鿴
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="tradeType"></param>
        /// <returns></returns>
        public static string GetOrderLook(object orderId, object tradeType)
        {
            string strOrder = "";
            if (orderId != null)
            {
                strOrder = orderId.ToString();
            }
            string result = "";
            if (string.IsNullOrEmpty(strOrder))
            {
                return "--";
            }
            string strType = "";
            if (tradeType != null)
            {
                strType = tradeType.ToString();
            }
            switch (strType)
            {
                case "311":
                    return "<a href='UserCharge_Manage.aspx?OnlineType=-1&state=-1&strOrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "312":
                    return "--";
                case "313":
                    return "<a href='UserCharge_Manage.aspx?OnlineType=-1&state=-1&strOrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "151":
                    return " <a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "152":
                    return "<a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "153":
                    return " <a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "171":
                    return " <a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "172":
                    return " <a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "173":
                    return " <a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "771":
                    return "<a href='UserDraw_Manage.aspx?state=-1&strOrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "772":
                    return "--";
                case "773":
                    return "--";
                case "511":
                    return "<a  href='Broker_TradeInfo.aspx?strOrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "512":
                    return "<a href='OrderDetails.aspx?ID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                case "501":
                    return "<a href='UserDraw_Manage.aspx?state=-1&strOrderID=" + strOrder + "' target='_blank'>" + strOrder + "</a>";
                default:
                    return "--";
            }
        }

        /// <summary>
        /// ����Ƿ��Ǵ������
        /// </summary>
        /// <returns></returns>
        public static bool IsDaili()
        {
            object objPP = DbHelperSQL1.GetSingle("select PricePercent from AgentInfo where UserName='" + Method.Get_UserName + "' " + Method.Where_AgentInfo);
            if (objPP == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string IsDVUser(string userName)
        {
            string strResult = "";
            int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + userName + "'  and " + Method.DV_User));
            if (count < 1)
            {
                strResult = "���û���δע�ᣬ���߱�������";
            }
            else
            {
                strResult = "true";
            }
            return strResult;
        }


        /// <summary>
        /// ��⵱ǰ�û��Ƿ��Ǹ߼��û�
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool CheckIsAdvanceUser(string userName)
        {
            Pbzx.Model.PBnet_UserTable RealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(userName);
            if (RealModel != null && !string.IsNullOrEmpty(RealModel.CardID) && !string.IsNullOrEmpty(RealModel.RealName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ������Ա�ϴ�Ȩ��
        /// </summary>
        /// <returns></returns>
        public static bool CheckAdminUpload()
        {
            if (!(System.Web.HttpContext.Current.Request.Cookies["AdminManager"] != null && System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value != ""))
            {
            }
            else
            {
                string adminName = WebFunc.GetCurrentAdmin();
                object objTempID = DbHelperSQL.GetSingle("select top 1 TempID from PBnet_Module where Name='����Ա�ϴ�' ");
                if (objTempID != null)
                {
                    int tempID = -1;
                    if (int.TryParse(objTempID.ToString(), out tempID))
                    {
                        if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from PBnet_tpman where  CHARINDEX('" + tempID + "', Setting) >0  ")) > 0)
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// �õ��û������߶�����
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static decimal GetUserMoney(object uName, object type)
        {
            DataSet ds = DbHelperSQL.Query("select CurrentMoney,FrozenMoney from PBnet_UserTable where UserName='" + uName.ToString() + "' ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (type.ToString() == "1")
                {
                    return Math.Round(Convert.ToDecimal(row["CurrentMoney"]), 2);
                }
                else
                {
                    return Math.Round(Convert.ToDecimal(row["FrozenMoney"]), 2);
                }

            }
            else
            {
                return Math.Round(Convert.ToDecimal("0"), 2);
            }

        }


        /// <summary>
        ///��ʽ�û�״̬ 
        /// </summary>
        /// <param name="objState"></param>
        /// <returns></returns>
        public static string FormartUserState(object objState)
        {
            int intState = Convert.ToInt32(objState);
            if (intState == 0)
            {
                return "��ͨ�û�";
            }
            else if (intState == 1)
            {
                return "<font color='blue'>�߼��û�</font>";
            }
            else if (intState == 2)
            {
                return "������";
            }
            else
            {
                return "δ֪״̬";
            }
        }

        /// <summary>
        /// ����IP��ַ�õ���ַ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetIpName(object obj)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return ipBLL.S_getIPaddress(obj.ToString());
            }
        }

        /// <summary>
        /// ���������������
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        public static string GetLyTypeByID(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            Pbzx.BLL.PBnet_LyType typeBll = new Pbzx.BLL.PBnet_LyType();
            Pbzx.Model.PBnet_LyType typeModel = typeBll.GetModel(intType);
            if (typeModel != null)
            {
                type = typeModel.TypeName;
            }
            return type;
        }

        public static int GetUserTodayMSG(string userName)
        {
            return Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_Message  where CONVERT(varchar(100), sendtime, 23) = CONVERT(varchar(100), getDate(), 23) and sender='" + userName + "' "));
        }

        /// <summary>
        /// ������Ϣ�а������б�
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindFriends(DropDownList ddl)
        {
            string SqlFriends = "SELECT F_friend FROM Dv_Friend WHERE F_username='" + Method.Get_UserName + "' ORDER BY F_addtime DESC";
            DataSet dsFriends = DbHelperSQLBBS.Query(SqlFriends);
            if (dsFriends.Tables.Count > 0 && dsFriends.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsFriends.Tables[0].Rows)
                {
                    ddl.Items.Add(new ListItem(row["F_friend"].ToString(), row["F_friend"].ToString()));
                }
            }
            ddl.Items.Insert(0, new ListItem("ѡ��", ""));
            ddl.Items.Insert(1, new ListItem("ƴ�����߲���ͨ���", "ƴ�����߲���ͨ���"));
        }





    }


}