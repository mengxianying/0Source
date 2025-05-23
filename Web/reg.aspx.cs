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
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Text.RegularExpressions;
using System.Xml;
using System.Security.Cryptography;
namespace Pbzx.Web
{
    public partial class reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.CacheControl = "no-cache";
                Response.Expires = 0;
                //������������
                if (Request["strSearch"] != null)
                {
                    ProcessingSearch(Input.FilterAll(Server.UrlDecode(Request["strSearch"])));
                }

                //����������
                if (Request["strBulletin"] != null)
                {
                    ProcessingSearch1(Input.FilterAll(Server.UrlDecode(Request["strBulletin"])));
                }
                //����ѧԺ����
                if (Request["strShool"] != null)
                {
                    ProcessingSearch2(Input.FilterAll(Server.UrlDecode(Request["strShool"])));
                }


                //�������ŵ�������Զ�����
                if (Request["NewsClick"] != null)
                {
                    string id = Input.FilterAll(Request["NewsClick"]);
                    if (id.Length > 0)
                    {
                        NewsClickAdd(Input.FilterAll(Request["NewsClick"]));
                    }
                }

                //�������������Զ�����
                if (Request["BulletinClick"] != null)
                {
                    string id = Input.FilterAll(Request["BulletinClick"]);
                    if (id.Length > 0)
                    {
                        BulletinClickAdd(Input.FilterAll(Request["BulletinClick"]));
                    }
                }

                //�������������Զ�����
                if (Request["SchoolClick"] != null)
                {
                    string id = Input.FilterAll(Request["SchoolClick"]);
                    if (id.Length > 0)
                    {
                        SchoolClickAdd(Input.FilterAll(Request["SchoolClick"]));
                    }
                }

                //����ʡ�а�
                if (Request["province"] != null)
                {
                    GetCityData(Input.FilterAll(Server.UrlDecode(Request["province"])));
                }

                //�����ж��û����Ƿ�ռ��
                if (Request["checkUserName"] != null)
                {
                    CheckUserName(Input.FilterAll(Server.UrlDecode(Request["checkUserName"])));
                }

                if (Request["checkUserNameInput"] != null)
                {
                    CheckUserNameInput(Input.FilterAll(Server.UrlDecode(Request["checkUserNameInput"])));
                }

                //�����ж��û�Email�Ƿ�ռ��
                if (Request["checkUserEmail"] != null)
                {
                    CheckUserEmail(Input.FilterAll(Server.UrlDecode(Request["checkUserEmail"])));
                }

                if (Request["checkUserMobile"] != null)
                {
                    CheckUserMobile(Input.FilterAll(Server.UrlDecode(Request["checkUserMobile"])));
                }

                ////�����Ĳ���
                //if(Request["name_pwd"] != null)
                //{
                //    Response.Clear();
                //    LoginSort login = new LoginSort();
                //    if (!login["manager_user"] || Method.Get_UserPwd =="0")
                //    {
                //        Response.Write("var NamePWD='';");
                //        //Response.End();
                //        //Response.Redirect("/Login.aspx");
                //    }
                //    else
                //    {
                //        Response.Write("var NamePWD='" + Server.UrlEncode(Method.Get_UserName + "|" + Method.Get_UserPwd) + "';");
                //    }                    
                //    Response.End();
                //}

                //bigType
                if (Request["bigType"] != null)
                {
                    string strbigType = Input.FilterAll(Server.UrlDecode(Request["bigType"]));
                    if (!OperateText.IsNumber(strbigType))
                    {
                        Response.Write("<script>top.location ='/Error.htm';</script>");
                        Response.End();
                        return;
                    }
                    else
                    {
                        GetAskType(strbigType);
                    }
                }

                //�ж��Ƿ��¼
                if (Request["IsLogin"] != null)
                {
                    IsLogin();
                }
                //��¼
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uCode"] != null && Request["uTime"] != null)
                {
                    //                   MyCheckLogin(Server.UrlDecode(Input.FilterAll(Request["uName"])), Input.FilterAll(Request["uPwd"]), Input.FilterAll(Request["uCode"]), Input.FilterAll(Request["uTime"]));
                    MyCheckLogin(Input.FilterAll(Server.UrlDecode(Request["uName"])), Input.FilterAll(Server.UrlDecode(Request["uPwd"])), Input.FilterAll(Server.UrlDecode(Request["uCode"])), Input.FilterAll(Server.UrlDecode(Request["uTime"])));
                }
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uTime"] != null && Request["loginType"] != null)
                {
                    MyCheckLoginAsp(Input.FilterAll(Server.UrlDecode(Request["uName"])), Input.FilterAll(Server.UrlDecode(Request["uPwd"])), Input.FilterAll(Server.UrlDecode(Request["uTime"])), Input.FilterAll(Server.UrlDecode(Request["loginType"])));
                }
                //�˳�
                if (Request["loginOut"] != null)
                {
                    MyLoginOut();
                }

                //RepairMobile������֤
                if (Request["CheckEmailCode"] != null && Request["email_RM"] != null)
                {
                    CheckEmailCode();
                }

                //ע��email��֤
                if (Request["checkEmail"] != null && Request["email"] != null)
                {
                    CheckEmail();
                }

                //RepairMobile�ֻ���֤
                if (Request["CheckPhoneCode"] != null && Request["phone"] != null)
                {
                    CheckPhoneCode();
                }
                

                //ע��phone��֤
                if (Request["checkPhone"] != null && Request["phone"] != null)
                {
                    CheckPhone();
                }


                //���㵱ǰ�м۸񣬸��������ݿ�
                if (Request["product"] != null && Request["quantity"] != null && Request["type"] != null && Request["price"] != null)
                {
                    UpdateShoppingCart(Input.FilterAll(Server.UrlDecode(Request["product"])), Input.FilterAll(Server.UrlDecode(Request["quantity"])), Input.FilterAll(Server.UrlDecode(Request["type"])), Input.FilterAll(Server.UrlDecode(Request["price"])));
                }

                ///���㵱ǰ���ﳵ��Ʒ�ܼ۸�
                if (Request["CalcPrice"] != null && Request["CalcPrice"] == "Yes")
                {
                    CalcTotalPrice();
                }
                //ɾ�����ﳵ��Ʒ
                if (Request["delCart"] != null)
                {
                    DelShoppingCartByID(Input.FilterAll(Server.UrlDecode(Request["delCart"])));
                }

                //��չ��ﳵ
                if (Request["clearCart"] != null)
                {
                    ClearCart(Input.FilterAll(Server.UrlDecode(Request["clearCart"])));
                }
                //���Żõ�Ƭ
                if (Request["newsSlide"] != null)
                {
                    string temp = Input.FilterAll(Server.UrlDecode(Request["newsSlide"]));
                    if (temp.ToLower() == "yes")
                    {
                        BindHot();
                    }
                }

                ///����Ƿ��Ǹ߼��û�
                if (Request["IsRealInfo"] != null)
                {
                    string temp = Request["IsRealInfo"];
                    if (temp == "IsRealInfo")
                    {
                        CheckIsRealInfo();
                    }
                }

                //����û��Ƿ���ڣ�����ѯ��ʵ�û���
                if (Request["SelectUserRealName"] != null)
                {
                    CheckUserRealName(Input.FilterAll(Server.UrlDecode(Request["SelectUserRealName"])));
                }

                //��⾭�����Ƿ��Ѿ�����
                if (Request["CheckIsBroker"] != null)
                {
                    if (Input.FilterAll(Request["CheckIsBroker"]) == "abc")
                    {
                        CheckIsBroker();
                    }

                }
                //�������Ƿ��Ѿ�����
                if (Request["CheckIsDaili"] != null)
                {
                    if (Input.FilterAll(Request["CheckIsDaili"]) == "abc")
                    {
                        CheckIsDaili();
                    }

                }


                //���ﳵ������Ӳ�Ʒ
                if (Request["quickAddProduct"] != null)
                {
                    QuickAddProduct(Server.UrlDecode(Input.FilterAll(Server.UrlDecode(Request["quickAddProduct"]))));
                }

                //��֤����ڣ������̰��µ�ʱ����֤�Ƿ���ȷ
                if (!string.IsNullOrEmpty(Request["keyUpCheckVerifyCode"]) && !string.IsNullOrEmpty(Request["type"]))
                {
                    if (Request["type"] == "1")
                    {
                        keyUpCheckVerifyCode(Request["keyUpCheckVerifyCode"], 1);
                    }
                    else if (Request["type"] == "3")
                    {
                        //custom by Bryansun
                        keyUpCheckVerifyCodeC(Request["keyUpCheckVerifyCode"]);
                    }
                    else
                    {
                        keyUpCheckVerifyCode(Request["keyUpCheckVerifyCode"], 2);
                    }
                }


                //��̨�༭���ϴ�����///////////////////////////////////////////////////////////////////////////////
                if (!string.IsNullOrEmpty(Request["CheckAdminUpload"]) && Request["CheckAdminUpload"] == "meng")
                {
                    CheckAdminUpload();
                }

                //��ҳ�ؼ���
                if (Request["GetMetaDesc"] != null)
                {
                    GetKeyString();
                }


            }
        }

        protected void GetKeyString()
        {
            Response.Clear();
            StringBuilder sb = new StringBuilder("");
            DataSet obj = DbHelperSQL.Query("select  metaDesc from PBnet_MetaDesc order by NEWID()");
            if (obj != null)
            {
                foreach (DataRow row in obj.Tables[0].Rows)
                {
                    sb.Append(row[0].ToString() + " ");

                }
            }


            Response.Write(sb.ToString());

            Response.End();
        }

        /// <summary>
        /// �����֤���Ƿ���ȷ
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        private void CheckAdminUpload()
        {
            Response.Clear();
            if (WebFunc.CheckAdminUpload())
            {
                Response.Write("true");
            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }

        public void keyUpCheckVerifyCodeC(string text)
        {
            Response.Clear();
            object objSession = null;
            objSession = Session["ValidateCode"];
            if (objSession != null)
            {
                if (objSession.ToString().ToUpper() == text.ToUpper())
                {
                    Response.Write("<script>parent.yanzhengmacallback('Y');</script>");
                }
                else
                {
                    Response.Write("<script>parent.yanzhengmacallback('N');</script>");
                }
            }
            else
            {
                Response.Write("<script>parent.yanzhengmacallback('P');</script>"); //Response.Write("��֤���Ѿ�ʧЧ��������֤��ͼƬ���»�ȡ��֤��");
            }
            Response.End();
        }

        /// <summary>
        /// �����֤���Ƿ���ȷ
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        private void keyUpCheckVerifyCode(string text, int type)
        {
            Response.Clear();
            object objSession = null;
            if (type == 1)
            {
                objSession = Session["ValidateCode"];
            }
            else if (type == 2)
            {
                objSession = Session["Code"];
            }
            if (objSession != null)
            {
                if (objSession.ToString().ToUpper() == text.ToUpper())
                {


                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }
            }
            else
            {
                Response.Write("��֤���Ѿ�ʧЧ��������֤��ͼƬ���»�ȡ��֤��");
            }
            Response.End();
        }

        #region ���ﳵ������Ӳ�Ʒ
        private void QuickAddProduct(string value)
        {
            Response.Clear();
            Response.Write(EnCodePower(value));
            Response.End();
        }

        public string EnCodePower(string value)
        {
            StringBuilder sb = new StringBuilder();

            string[] res = value.Split(new char[] { ',' });
            foreach (string strSZ in res)
            {
                if (!string.IsNullOrEmpty(strSZ))
                {
                    InsertShoppingCart(int.Parse(strSZ));
                }
            }
            return "true";
        }


        #region ���빺�ﳵ
        private void InsertShoppingCart(int productID)
        {
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            Pbzx.Model.PBnet_Product productModel = productBLL.GetModel(productID);
            string danjPrice = productModel.pb_DemoUrl;
            string zongsPrice = productModel.pb_RegUrl;

            if (productModel.pb_TypeName == "רҵ��")
            {
                if (!CheckIsFree(danjPrice) && !CheckIsFree(zongsPrice))
                {
                    return;
                }
            }
            else
            {
                if (!CheckIsFree(danjPrice))
                {
                    return;
                }
            }

            string cartGuid = Method.GetCartGuid();

            Pbzx.Model.PBnet_ShoppingCart shoppingCart = new Pbzx.Model.PBnet_ShoppingCart();
            shoppingCart.ProductID = productID;
            shoppingCart.CartGuid = cartGuid;
            shoppingCart.Quatity = 1;
            shoppingCart.RegType = "";
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.InsertShoppingCart(shoppingCart);
        }
        #endregion

        private bool CheckIsFree(string strPrice)
        {
            int index1 = strPrice.IndexOf("Ԫ");
            if (index1 < 0)
            {
                return false;
            }
            string intPrice = strPrice.Remove(index1);
            decimal p = 0M;
            if (decimal.TryParse(intPrice, out p))
            {
                if (p <= decimal.Parse("0"))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
        #endregion

        //��⾭�����Ƿ��Ѿ�����
        private void CheckIsBroker()
        {
            Response.Clear();
            LoginSort login = new LoginSort();
            if (login[ELoginSort.user_Broker.ToString()])
            {
                Response.Write("broker");
            }
            else if (login[ELoginSort.delegate_User.ToString()])
            {
                Response.Write("daili");
            }
            else
            {
                Response.Write("Broker_Agrt.aspx");
            }
            Response.End();
        }

        //�������Ƿ��Ѿ�����
        private void CheckIsDaili()
        {
            Response.Clear();
            LoginSort login = new LoginSort();
            if (login[ELoginSort.delegate_User.ToString()])
            {
                Response.Write("daili");
            }
            else if (login[ELoginSort.user_Broker.ToString()])
            {
                Response.Write("broker");
            }
            else
            {
                Response.Write("");
            }
            Response.End();
        }

        //����û��Ƿ���ڣ�����ѯ��ʵ�û���
        private void CheckUserRealName(string uname)
        {
            Response.Clear();
            object objSingle = DbHelperSQL.GetSingle("select top 1 RealName  from PBnet_UserTable where UserName='" + Input.FilterAll(Server.UrlDecode(uname)) + "' and State !='10' ");
            if (objSingle == null)
            {
                Response.Write("");
            }
            else
            {
                Response.Write(objSingle.ToString());
            }
            Response.End();
        }

        /// <summary>
        /// ����Ƿ��Ǹ߼��û�
        /// </summary>
        private void CheckIsRealInfo()
        {
            Response.Clear();
            LoginSort login = new LoginSort();
            if (!login[ELoginSort.user_RealInfo.ToString()])
            {
                Response.Write("false");
            }
            else
            {
                Response.Write("true");
            }
            Response.End();
        }

        private void BindHot()
        {
            StringBuilder sbSrc = new StringBuilder();
            StringBuilder sbUrl = new StringBuilder();
            //DataSet ds = MyBll.GetList("IntDisPosition=1");
            try
            {
                DataSet ds = DbHelperSQL.Query("select top " + WebInit.webBaseConfig.Nslide + " * from PBnet_Nslide where IsEnable='1' order by NOrder  ");
                DataTable dt = ds.Tables[0];
                for (int ii = 0; ii < dt.Rows.Count; ii++)
                {
                    string tempSrc = dt.Rows[ii]["PicUrl"].ToString();
                    string tempUrl = dt.Rows[ii]["LinkUrl"].ToString();
                    if (!string.IsNullOrEmpty(tempSrc) && !string.IsNullOrEmpty(tempUrl))
                    {
                        sbSrc.Append(tempSrc + "|");
                        sbUrl.Append(tempUrl + "|");
                    }
                }
                string strSrc = sbSrc.Length > 1 ? sbSrc.Remove(sbSrc.Length - 1, 1).ToString() : "";
                string strUrl = sbUrl.Length > 1 ? sbUrl.Remove(sbUrl.Length - 1, 1).ToString() : "";
                Response.Clear();
                if (strSrc == "" || strUrl == "")
                {
                    Response.Write("");
                }
                else
                {
                    Response.Write(strSrc + "!" + strUrl);
                }
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                //Response.Clear();
                //Response.Write("");
                //Response.End();
            }
        }


        /// <summary>
        /// ��չ��ﳵ
        /// </summary>
        /// <param name="cartID"></param>
        private void ClearCart(string cartID)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            Pbzx.Model.PBnet_ShoppingCart cartModel = shoppingCartBll.GetModel(long.Parse(cartID));
            cartModel.Quatity = 0;
            cartModel.RegType = "";
            shoppingCartBll.Update(cartModel);
            Response.Clear();
            Response.Write("ok");
            Response.End();
        }

        /// <summary>
        /// ���ݹ��ﳵIDɾ�����ﳵ
        /// </summary>
        private void DelShoppingCartByID(string cartID)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.Delete(long.Parse(cartID));
            Response.Clear();
            string[] result = WebFunc.CalcTotalPriceAndCount();
            Response.Write(result[0] + "|" + result[1]);
            Response.End();
        }

        /// <summary>
        /// ���㵱ǰ���ﳵ��Ʒ�ܼ۸�
        /// </summary>
        private void CalcTotalPrice()
        {
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            System.Data.DataSet dsProducts = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
                return;
            }
            else
            {
                Decimal result = 0;
                foreach (DataRow row in dsProducts.Tables[0].Rows)
                {
                    int quantity = Convert.ToInt32(row["Quatity"]);
                    string regType = row["RegType"].ToString();
                    if (!string.IsNullOrEmpty(regType))
                    {
                        string[] regSZ = regType.Split(new char[] { '|' });

                        if (regSZ.Length > 1)
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
                Response.Clear();
                Response.Write(result.ToString());
                Response.End();
            }
        }


        /// <summary>
        /// ���㵱ǰ�м۸񣬸��������ݿ�
        /// </summary>
        private void UpdateShoppingCart(string pid, string quantity, string type, string price)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            Pbzx.Model.PBnet_ShoppingCart cartModel = shoppingCartBll.GetModel(long.Parse(pid));
            cartModel.DataAdded = DateTime.Now;
            cartModel.Quatity = int.Parse(quantity);
            decimal temp = 0;

            if (decimal.TryParse(price, out temp))
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
                cartModel.RegType = type;
            }

            shoppingCartBll.Update(cartModel);
            Response.Clear();
            Response.Write("ok");
            Response.End();
        }

        private void InitLoginIP(string username)
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("userlogin")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //���������ܵĵ�ַ
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
                //�ж�IP
                string ip = "";
                if (Context.Request.ServerVariables["HTTP_VIA"] != null) // �������� using proxy 
                {
                    // �õ���ʵ�Ŀͻ��˵�ַ
                    ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
                }
                else//���û��ʹ�ô�����������ߵò����ͻ��˵�ip  not using proxy or can't get the Client IP 
                {
                    //�õ�����˵ĵ�ַ 
                    ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
                }
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log(username, "", "�����θ�IPλ�õ�¼", "��¼���");
                    Response.Redirect("http://www.pinble.com");
                }
                //�ж�ʡ��
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log(username, "", "�����θõ�ַλ�õ�¼", "��¼���");
                    Response.Redirect("http://www.pinble.com");
                }
            }
        }

        /// <summary>
        /// ѭ���ж�
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool NewMethod(string s_temp, string sfs)
        {
            sfs = sfs.Replace("|\r\n", "|");
            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <param name="uCode"></param>
        private void MyCheckLogin(string uName, string uPwd, string uCode, string uTime)
        {
            InitLoginIP(uName);

            string strResult = "";
            Pbzx.BLL.PinbleLogin LoginBll = new Pbzx.BLL.PinbleLogin();
            if (Session["ValidateCode"] == null)
            {
                strResult = "��֤���Ѿ�ʧЧ��������֤�����»�ȡ��";
            }
            else if (uCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                strResult = "��֤�����";
            }
            else
            {
                string result = LoginBll.CheckLogin(uName, uPwd, uTime);
                if (!string.IsNullOrEmpty(result))
                {
                    strResult = result;
                }
                else
                {
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Input.FilterAll(Server.UrlDecode(uName)) + "' ");
                    strResult = "true&" + objMsgCount.ToString();
                }
            }
            Response.Clear();
            Response.Write(strResult);
            Response.End();
        }


        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <param name="uCode"></param>
        private void MyCheckLoginAsp(string uName, string uPwd, string uTime, string loginType)
        {
            if (loginType.ToLower() == "pinbleasp")
            {
                string strResult = "";
                string strName;
                strName = Input.FilterAll(Server.UrlDecode(uName));
                Pbzx.BLL.PinbleLogin LoginBll = new Pbzx.BLL.PinbleLogin();
                string result = LoginBll.CheckLogin(strName, uPwd, uTime, true);
                if (!string.IsNullOrEmpty(result))
                {
                    strResult = result;
                }
                else
                {
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and  issend = 1 and delR = 0 and incept = '" + strName + "' ");
                    strResult = "true&" + objMsgCount.ToString();
                }
                Response.Clear();

                string callback = Request["callback"];
                Response.Write(callback + "({msg:'" + strResult + "'})");
                Response.End();
            }
        }



        /// <summary>
        /// �˳�
        /// </summary>
        private void MyLoginOut()
        {
            try
            {
                Pbzx.BLL.PinbleLogin.UserOut();
                Response.Write("true");
            }
            catch (Exception ex)
            {
                Response.Write("false");
            }
        }


        /// <summary>
        /// RepairMobile������֤����֤
        /// </summary>
        private void CheckEmailCode()
        {
            string ErrorInfo = "";
            try
            {
                if (Request.Params["email_RM"] != null)
                {
                    string strEmail = Input.FilterAll(Request.Params["email_RM"].ToString().Trim());
                    string strIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                    int IP_ValideCode_Count = WebInit.webBaseConfig.IP_ValideCode_Count;

                    if (strEmail != null)
                    {
                        if (DbHelperSQL.Exists("select top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE (EMAIL = '" + strEmail + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //����Ƿ���60�����������Ͷ���
                            ErrorInfo = "��������������Ͱ�ť�����û�յ���֤����60����ٷ��͡�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        //else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        //{
                        //    //����ֻ����뵱���Ƿ��Ѿ�����3�ζ���
                        //    ErrorInfo = "�Բ��𣬸õ�������" + strEmail + "�����ѷ���3����֤�룬������ٷ���";
                        //    return;
                        //}
                        //else if (DbHelperSQL.Exists("SELECT top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        //{
                        //    //����ֻ������Ƿ����ڷ��Ͷ���
                        //    ErrorInfo = "���ڷ�����֤�룬�����ظ����͡�";
                        //    return;
                        //}

                        string serverCode = GenerateRandomCode();
                        Session["Email_CHECKCODE_RM"] = serverCode;
                        //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                        //String shoujiayanzhengma = serverCode;

                        // ���ø߷���IP��ַ��һ���ˣ����ٲ���IP��ַ
                        //strIP = "";

                        //String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                        //Response.Write(zsql);

                        //int result = 0;
                        //result = DbHelperSQL.ExecuteSql(zsql);

                        //Զ�̵���
                        Pbzx.Web.Web_JmailService.WebService1 wb = new Pbzx.Web.Web_JmailService.WebService1();


                        if (wb.GetEmail(strEmail, "ƴ������ע����֤�루ϵͳ�Զ����ͣ�����ظ���", "������ƴ������������֤����֤��Ϊ��" + serverCode + "���뷵��ҳ��������֤�루��Ϊϵͳ�ʼ�������ظ���"))
                        {
                            Session["Email_CHECKCODE_RM"] = serverCode;
                            Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ�����", "�ʼ����ͳɹ���" + strEmail + "����֤��:" + serverCode + "\r\n", true, true);
                            Response.Write("true");
                            Response.End();
                            return;
                        }
                        else
                        {
                            ErrorInfo = "�ʼ�����ʧ��";
                        }

                    }
                    else
                    {
                        ErrorInfo = "�������䲻��Ϊ��";
                    }
                }
                else
                {
                    ErrorInfo = "�������䲻��Ϊ��";
                }
                Response.Write(ErrorInfo);
                Response.End();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                //Response.Write("true");
                //Response.End();
                throw new Exception(ex.ToString());
            }

        }

        /// <summary>
        /// RepairMobile�ֻ���֤����֤
        /// </summary>
        private void CheckPhoneCode()
        {
            string ErrorInfo = "";

            try
            {
                if (Request.Params["phone"] != null)
                {
                    string strMobile = Input.FilterAll(Request.Params["phone"].ToString().Trim());
                    string strIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                    int IP_ValideCode_Count = WebInit.webBaseConfig.IP_ValideCode_Count;

                    if (strMobile != null)
                    {
                        //����ֻ������Ƿ���ȷ
                        if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$") && strMobile.Length != 11)
                        {
                            ErrorInfo = "�Բ��𣬸��ֻ�����" + strMobile + "����ȷ����";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where MOBILE='" + strMobile + "' "))
                        {
                            //����ֻ������Ƿ��Ѿ�ע��
                            ErrorInfo = "�Բ��𣬸��ֻ�����" + strMobile + "�ѱ�ʹ�á�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Exists("select top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE (MOBILE = '" + strMobile + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //����Ƿ���60�����������Ͷ���
                            ErrorInfo = "��������������Ͱ�ť�����û�յ���֤����60����ٷ��͡�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        {
                            //����ֻ����뵱���Ƿ��Ѿ�����3�ζ���
                            ErrorInfo = "�Բ��𣬸��ֻ�����" + strMobile + "�����ѷ���3����֤�룬������ٷ���";
                            return;
                        }
                        //                            else if (DbHelperSQL.Query("SELECT IP  FROM dbo.PBnet_TBL_SMS WHERE Len(IP) > 0 and IP = '" + strIP + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count > IP_ValideCode_Count)
                        //                            {
                        //                                //��鵱ǰIP�����Ƿ��Ѿ�����3�ζ���
                        ////                              ErrorInfo = "�Բ��𣬸�IP��ַ" + strIP + " ���췢����֤������Ѿ����������ٷ���";
                        //                                ErrorInfo = "�Բ��𣬽��췢����֤������Ѿ����������ٷ���";
                        //                                return;
                        //                            }
                        else if (DbHelperSQL.Exists("SELECT top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        {
                            //����ֻ������Ƿ����ڷ��Ͷ���
                            ErrorInfo = "���ڷ�����֤�룬�����ظ����͡�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }

                        string[] str = new string[4];
                        string serverCode = "";
                        //������������� 
                        Random random = new Random();
                        for (int i = 0; i < 4; i++)
                        {
                            str[i] = random.Next(10).ToString().Substring(0, 1);
                        }
                        foreach (string s in str)
                        {
                            serverCode += s;
                        }
                        //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                        String shoujiayanzhengma = serverCode;

                        // ���ø߷���IP��ַ��һ���ˣ����ٲ���IP��ַ
                        strIP = "";

                        //Session["UID"]




                        String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,USERNAME,USERPASSWORD,EMAIL, MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + Session["UID"].ToString() + "','" + Session["txtUserPassword"].ToString() + "','" + Session["txtEmail"].ToString() + "','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                        //Response.Write(zsql);

                        int result = 0;
                        result = DbHelperSQL.ExecuteSql(zsql);
                        Session["MOBILE_CHECKCODE"] = shoujiayanzhengma;

                        Response.Write("true");
                        Response.End();
                        return;
                    }
                    else
                    {
                        ErrorInfo = "�ֻ����벻��Ϊ��";
                    }
                }
                else
                {
                    ErrorInfo = "�ֻ����벻��Ϊ��";
                }


                Response.Write(ErrorInfo);
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("");
                Response.End();
                throw new Exception(ex.ToString());
            }


        }


        /// <summary>
        /// ע��email��֤����֤
        /// </summary>
        private void CheckEmail()
        {
            string ErrorInfo = "";
            try
            {
                if (Request.Params["email"] != null)
                {
                    string strEmail = Input.FilterAll(Request.Params["email"].ToString().Trim());
                    string strIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                    int IP_ValideCode_Count = WebInit.webBaseConfig.IP_ValideCode_Count;

                    if (strEmail != null)
                    {
                        //�����������ʽ�Ƿ���ȷ
                        if (!Regex.IsMatch(strEmail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                        {
                            ErrorInfo = "�Բ��𣬸õ�������" + strEmail + "��ʽ����ȷ����";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + strEmail + "'"))
                        {
                            //����ֻ������Ƿ��Ѿ�ע��
                            ErrorInfo = "�Բ��𣬸õ�������" + strEmail + "�ѱ�ʹ�á�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Exists("select top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE (EMAIL = '" + strEmail + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //����Ƿ���60�����������Ͷ���
                            ErrorInfo = "��������������Ͱ�ť�����û�յ���֤����60����ٷ��͡�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        //else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        //{
                        //    //����ֻ����뵱���Ƿ��Ѿ�����3�ζ���
                        //    ErrorInfo = "�Բ��𣬸õ�������" + strEmail + "�����ѷ���3����֤�룬������ٷ���";
                        //    return;
                        //}
                        //else if (DbHelperSQL.Exists("SELECT top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        //{
                        //    //����ֻ������Ƿ����ڷ��Ͷ���
                        //    ErrorInfo = "���ڷ�����֤�룬�����ظ����͡�";
                        //    return;
                        //}

                        string serverCode = GenerateRandomCode();
                        Session["Email_CHECKCODE"] = serverCode;
                        //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                        //String shoujiayanzhengma = serverCode;

                        // ���ø߷���IP��ַ��һ���ˣ����ٲ���IP��ַ
                        //strIP = "";

                        //String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                        //Response.Write(zsql);

                        //int result = 0;
                        //result = DbHelperSQL.ExecuteSql(zsql);

                        //Զ�̵���
                        Pbzx.Web.Web_JmailService.WebService1 wb = new Pbzx.Web.Web_JmailService.WebService1();

                        Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ�����", "�ʼ����Ϳ�ʼ��" + strEmail + "����֤��:"+ serverCode+"\r\n", true, true);
                        if (wb.GetEmail(strEmail, "ƴ������ע����֤�루ϵͳ�Զ����ͣ�����ظ���", "������ע��ƴ�����ߣ���֤��Ϊ��" + serverCode + "���뷵��ҳ��������֤�루��Ϊϵͳ�ʼ�������ظ���"))
                        {
                            Session["Email_CHECKCODE"] = serverCode;
                            Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ�����", "�ʼ����ͳɹ���" + strEmail + "����֤��:" + serverCode + "\r\n", true, true);
                            Response.Write("true");
                            Response.End();
                            return;
                        }
                        else
                        {
                            Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ�����", "�ʼ�����ʧ�ܣ�" + strEmail + "����֤��:" + serverCode + "\r\n", true, true);
                            ErrorInfo = "�ʼ�����ʧ��";
                        }

                    }
                    else
                    {
                        ErrorInfo = "�������䲻��Ϊ��";
                    }
                }
                else
                {
                    ErrorInfo = "�������䲻��Ϊ��";
                }
                Response.Write(ErrorInfo);
                Response.End();
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ�����", "�ʼ������쳣��" + ex.ToString() + "\r\n", true, true);
                ErrorLog.WriteLog(ex);
                //Response.Write("true");
                //Response.End();  
                throw new Exception(ex.ToString());
            }

        }


        private void CheckPhone()
        {
            string ErrorInfo = "";

            try
            {
                if (Request.Params["phone"] != null)
                {
                    string strMobile = Input.FilterAll(Request.Params["phone"].ToString().Trim());
                    string strIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                    int IP_ValideCode_Count = WebInit.webBaseConfig.IP_ValideCode_Count;

                    if (strMobile != null)
                    {
                        //����ֻ������Ƿ���ȷ
                        if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$") && strMobile.Length != 11)
                        {
                            ErrorInfo = "�Բ��𣬸��ֻ�����" + strMobile + "����ȷ����";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where MOBILE='" + strMobile + "' "))
                        {
                            //����ֻ������Ƿ��Ѿ�ע��
                            ErrorInfo = "�Բ��𣬸��ֻ�����" + strMobile + "�ѱ�ʹ�á�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Exists("select top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE (MOBILE = '" + strMobile + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //����Ƿ���60�����������Ͷ���
                            ErrorInfo = "��������������Ͱ�ť�����û�յ���֤����60����ٷ��͡�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        {
                            //����ֻ����뵱���Ƿ��Ѿ�����3�ζ���
                            ErrorInfo = "�Բ��𣬸��ֻ�����" + strMobile + "�����ѷ���3����֤�룬������ٷ���";
                            return;
                        }
                        //                            else if (DbHelperSQL.Query("SELECT IP  FROM dbo.PBnet_TBL_SMS WHERE Len(IP) > 0 and IP = '" + strIP + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count > IP_ValideCode_Count)
                        //                            {
                        //                                //��鵱ǰIP�����Ƿ��Ѿ�����3�ζ���
                        ////                              ErrorInfo = "�Բ��𣬸�IP��ַ" + strIP + " ���췢����֤������Ѿ����������ٷ���";
                        //                                ErrorInfo = "�Բ��𣬽��췢����֤������Ѿ����������ٷ���";
                        //                                return;
                        //                            }
                        else if (DbHelperSQL.Exists("SELECT top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        {
                            //����ֻ������Ƿ����ڷ��Ͷ���
                            ErrorInfo = "���ڷ�����֤�룬�����ظ����͡�";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }

                        string[] str = new string[4];
                        string serverCode = "";
                        //������������� 
                        Random random = new Random();
                        for (int i = 0; i < 4; i++)
                        {
                            str[i] = random.Next(10).ToString().Substring(0, 1);
                        }
                        foreach (string s in str)
                        {
                            serverCode += s;
                        }
                        //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                        String shoujiayanzhengma = serverCode;

                        // ���ø߷���IP��ַ��һ���ˣ����ٲ���IP��ַ
                        strIP = "";

                        String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,USERNAME,USERPASSWORD,EMAIL, MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + Session["Username"].ToString() + "','" + Session["Password"].ToString() + "','" + Session["Email"].ToString() + "','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                        //Response.Write(zsql);

                        int result = 0;
                        result = DbHelperSQL.ExecuteSql(zsql);
                        Session["MOBILE_CHECKCODE"] = shoujiayanzhengma;

                        Response.Write("true");
                        Response.End();
                        return;
                    }
                    else
                    {
                        ErrorInfo = "�ֻ����벻��Ϊ��";
                    }
                }
                else
                {
                    ErrorInfo = "�ֻ����벻��Ϊ��";
                }


                Response.Write(ErrorInfo);
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("");
                Response.End();
                throw new Exception(ex.ToString());
            }


        }

        public string GenerateRandomCode()
        {
            // �������п����ַ����ַ���
            char[] charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();//abcdefghijklmnopqrstuvwxyz
            // ʹ�ü��ܼ���������������
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[6];
                rng.GetBytes(tokenData); // �������ֽ�

                char[] result = new char[6];
                for (int i = 0; i < 6; i++)
                {
                    // ���ֽ�ֵӳ�䵽�ַ�������
                    int index = tokenData[i] % charPool.Length;
                    result[i] = charPool[index];
                }

                return new string(result);
            }
        }


        private void IsLogin()
        {
            Response.Clear();
            LoginSort login = new LoginSort();
            if (login[Pbzx.Common.ELoginSort.manager_user.ToString()])
            {
                object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' ");
                Response.Write("true&" + Pbzx.Common.Method.Get_UserName + "&" + objMsgCount.ToString());
            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }

        private void ProcessingSearch(string str)
        {
            Response.Clear();
            string strReturn = "";
            string result = Input.Encrypt(Input.FilterAll(str));
            strReturn = "/News_list.aspx?Search=" + result;
            Response.Write(strReturn);
            Response.End();
        }
        private void ProcessingSearch1(string str)
        {
            string strReturn = "";
            string result = Input.Encrypt(Input.FilterAll(str));
            strReturn = "/Bulletin_list.aspx?Search=" + result;
            Response.Write(strReturn);
            Response.End();
        }

        private void ProcessingSearch2(string str)
        {
            string strReturn = "";
            string result = Input.Encrypt(Input.FilterAll(str));
            strReturn = "/School_Coutent_List.aspx?Search=" + result;
            Response.Write(strReturn);
            Response.End();
        }
        private void NewsClickAdd(string click)
        {
            Response.Clear();
            int id = 0;
            if (int.TryParse(click, out id))
            {
                Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
                Pbzx.Model.PBnet_News model = newsBLL.GetModel(id);
                if (model == null)
                {
                    Response.Write("var clickcount='0';");
                    Response.End();
                    return;
                }
                model.IntClick += 1;
                newsBLL.Update(model);
                Response.Write("var clickcount='" + model.IntClick.ToString() + "';");
                Response.End();
            }
            else
            {
                Response.Write("var clickcount='0';");
                Response.End();
            }
        }
        private void BulletinClickAdd(string click)
        {
            Response.Clear();
            int id = 0;
            if (int.TryParse(click, out id))
            {
                Pbzx.BLL.PBnet_Bulletin bulletinBLL = new Pbzx.BLL.PBnet_Bulletin();
                Pbzx.Model.PBnet_Bulletin model = bulletinBLL.GetModel(int.Parse(click));
                if (model == null)
                {
                    Response.Write("var clickcount='0';");
                    Response.End();
                    return;
                }
                model.IntClick += 1;
                bulletinBLL.Update(model);
                Response.Write("var clickcount='" + model.IntClick.ToString() + "';");
                Response.End();
            }
            else
            {
                Response.Write("var clickcount='0';");
                Response.End();
            }
        }

        private void SchoolClickAdd(string click)
        {
            Response.Clear();
            int id = 0;
            if (int.TryParse(click, out id))
            {
                Pbzx.BLL.PBnet_School bulletinBLL = new Pbzx.BLL.PBnet_School();
                Pbzx.Model.PBnet_School model = bulletinBLL.GetModel(int.Parse(click));
                if (model == null)
                {
                    Response.Write("var clickcount='0';");
                    Response.End();
                    return;
                }
                model.IntClick += 1;
                bulletinBLL.Update(model);
                Response.Write("var clickcount='" + model.IntClick.ToString() + "';");
                Response.End();
            }
            else
            {
                Response.Write("var clickcount='0';");
                Response.End();
            }
        }

        private void GetCityData(string province)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlCommand com1 = new SqlCommand("select Code ,Name,ProvinceId from PBnet_City where ProvinceId='" + province + "' ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "dbo.City");

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    strbu.Append(row["Name"] + "&" + row["Code"] + ",");
                }
            }
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "��������&");
            Response.End();
        }

        private void CheckUserName(string userName)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            string strName;
            strName = Input.FilterAll(userName);
            int strLength = Method.GetStrLen(strName);
            string result = "";
            if (strName == "")
            {
                result = "<font color='red'>�û�������Ϊ�գ�</font>";
            }
            else if (!Regex.IsMatch(strName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                result = "<font color='red'>�û���������3-12λ(������ĸ�����֡�����)��</font>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                result = "<font color='red'>�û���������3-12λ��</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + strName + "'"))
            {
                result = "<font color='red'>�Բ���,�����û����Ѿ���ռ�ã�</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">����ʹ��&nbsp;</font>";
            }
            Response.Write("<textarea id='p'>");
            Response.Write(result);
            Response.Write("</textarea>");
            Response.Write("<script>parent.document.getElementById('mySpUname').innerHTML=document.getElementById('p').value</script>");
            Response.End();
        }


        private void CheckUserNameInput(string userName)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            string strName;
            strName = Input.FilterAll(userName);
            int strLength = Method.GetStrLen(strName);
            string result = "";
            if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + strName + "' and " + Method.DV_User))
            {
                result = "true";
            }
            else
            {
                result = "<font color='red'>���û��������ڻ��Ѿ���������</font>";
            }
            Response.Write(result);
            Response.End();
        }

        private void CheckUserEmail(string userEmail)
        {
            Response.Clear();
            String result = "";
            StringBuilder strbu = new StringBuilder();
            string strEmail;
            strEmail = Input.FilterAll(userEmail);
            if (strEmail == "")
            {
                result = "<font color='red'>Email����Ϊ�գ�</font>";
            }
            else if (!Regex.IsMatch(strEmail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                result = "<font color='red'>Email��ʽ����ȷ��</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + strEmail + "'"))
            {
                result = "<font color='red'>�Բ�������Email�Ѿ���ռ�ã�</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">����ʹ��&nbsp;</font>";
            }

            Response.Write("<textarea id='p'>");
            Response.Write(result);
            Response.Write("</textarea>");
            Response.Write("<script>parent.document.getElementById('mySpUserEmail').innerHTML=document.getElementById('p').value</script>");
            Response.End();

        }


        private void CheckUserMobile(string userMobile)
        {
            Response.Clear();
            String result = "";
            StringBuilder strbu = new StringBuilder();
            string strMobile;
            strMobile = Input.FilterAll(userMobile);
            if (strMobile == "")
            {
                result = "<font color='red'>�ֻ����벻��Ϊ�գ�</font>";
            }
            else if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$"))
            {
                result = "<font color='red'>�ֻ����벻��ȷ��</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from dbo.Dv_User where Mobile='" + strMobile + "'"))
            {
                result = "<font color='red'>�Բ��𣬸��ֻ������Ѿ���ʹ�ã�</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">����ʹ��&nbsp;</font>";
            }

            Response.Write("<textarea id='p'>");
            Response.Write(result);
            Response.Write("</textarea>");
            Response.Write("<script>parent.document.getElementById('mySpUserMobile').innerHTML=document.getElementById('p').value</script>");
            Response.End();

        }

        private void GetAskType(string bigType)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlCommand com1 = new SqlCommand("select Id ,TypeName,FTypeID from PBnet_ask_Type where FTypeID='" + bigType + "' ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "dbo.PBnet_ask_Type");

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    strbu.Append(row["TypeName"] + "&" + row["Id"] + ",");
                }
            }
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "��������&");
            Response.End();
        }
    }
}
