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
using Pinble_Sms.AppCod;


namespace Pinble_Market
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
                    CheckUserName(Server.UrlDecode(Input.FilterAll(Request["checkUserName"])));
                }

                if (Request["checkUserNameInput"] != null)
                {
                    CheckUserNameInput(Server.UrlDecode(Input.FilterAll(Request["checkUserNameInput"])));
                }

                //�����ж��û�Email�Ƿ�ռ��
                if (Request["checkUserEmail"] != null)
                {
                    CheckUserEmail(Server.UrlDecode(Input.FilterAll(Request["checkUserEmail"])));
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
                    GetAskType(Server.UrlDecode(Request["bigType"]));
                }

                //�ж��Ƿ��¼
                if (Request["IsLogin"] != null)
                {
                    IsLogin();
                }
                //��¼
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uCode"] != null && Request["uTime"] != null)
                {
                    MyCheckLogin(Server.UrlDecode(Input.FilterAll(Request["uName"])), Input.FilterAll(Request["uPwd"]), Input.FilterAll(Request["uCode"]), Input.FilterAll(Request["uTime"]));
                }
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uTime"] != null && Request["loginType"] != null)
                {
                    MyCheckLoginAsp(Server.UrlDecode(Input.FilterAll(Request["uName"])), Input.FilterAll(Request["uPwd"]), Input.FilterAll(Request["uTime"]), Input.FilterAll(Request["loginType"]));
                }
                //�˳�
                if (Request["loginOut"] != null)
                {
                    MyLoginOut();
                }
                //���㵱ǰ�м۸񣬸��������ݿ�
                if (Request["product"] != null && Request["quantity"] != null && Request["type"] != null && Request["price"] != null)
                {
                    UpdateShoppingCart(Input.FilterAll(Request["product"]), Input.FilterAll(Request["quantity"]), Input.FilterAll(Request["type"]), Input.FilterAll(Request["price"]));
                }

                ///���㵱ǰ���ﳵ��Ʒ�ܼ۸�
                if (Request["CalcPrice"] != null && Request["CalcPrice"] == "Yes")
                {
                    CalcTotalPrice();
                }
                //ɾ�����ﳵ��Ʒ
                if (Request["delCart"] != null)
                {
                    DelShoppingCartByID(Input.FilterAll(Request["delCart"]));
                }

                //��չ��ﳵ
                if (Request["clearCart"] != null)
                {
                    ClearCart(Input.FilterAll(Request["clearCart"]));
                }
                //���Żõ�Ƭ
                if (Request["newsSlide"] != null)
                {
                    string temp = Input.FilterAll(Request["newsSlide"]);
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
                    CheckUserRealName(Input.FilterAll(Request["SelectUserRealName"]));
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
                    QuickAddProduct(Server.UrlDecode(Input.FilterAll(Request["quickAddProduct"])));
                }

                //��֤����ڣ������̰��µ�ʱ����֤�Ƿ���ȷ
                if (!string.IsNullOrEmpty(Request["keyUpCheckVerifyCode"]) && !string.IsNullOrEmpty(Request["type"]))
                {
                    if (Request["type"] == "1")
                    {
                        keyUpCheckVerifyCode(Request["keyUpCheckVerifyCode"], 1);
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



            }
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
                if (!CheckIsFree(zongsPrice))
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
            object objSingle = DbHelperSQL.GetSingle("select top 1 RealName  from PBnet_UserTable where UserName='" + uname + "' and State !='10' ");
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


        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <param name="uCode"></param>
        private void MyCheckLogin(string uName, string uPwd, string uCode, string uTime)
        {
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
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + uName + "' ");
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
                Pbzx.BLL.PinbleLogin LoginBll = new Pbzx.BLL.PinbleLogin();
                string result = LoginBll.CheckLogin(uName, uPwd, uTime, true);
                if (!string.IsNullOrEmpty(result))
                {
                    strResult = result;
                }
                else
                {
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and  issend = 1 and delR = 0 and incept = '" + uName + "' ");
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
            int strLength = Method.GetStrLen(userName);
            string result = "";
            if (userName == "")
            {
                result = "<font color='red'>�û�������Ϊ�գ�</font>";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                result = "<font color='red'>�û���������3-12λ(������ĸ�����֡�����)��</font>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                result = "<font color='red'>�û���������3-12λ��</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                result = "<font color='red'>�Բ���,�����û����Ѿ���ռ�ã�</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">����ʹ��&nbsp;</font>";
            }
            Response.Write(result);
            Response.End();
        }


        private void CheckUserNameInput(string userName)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            int strLength = Method.GetStrLen(userName);
            string result = "";
            if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "' and " + Method.DV_User))
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
            StringBuilder strbu = new StringBuilder();
            if (userEmail == "")
            {
                Response.Write("<font color='red'>Email����Ϊ�գ�</font>");
            }
            else if (!Regex.IsMatch(userEmail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                Response.Write("<font color='red'>Email��ʽ����ȷ��</font>");
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + userEmail + "'"))
            {
                Response.Write("<font color='red'>�Բ���,����Email�Ѿ���ռ�ã�</font>");
            }
            else
            {
                Response.Write("<font color=\"#8594A7\">����ʹ��&nbsp;</font>");
            }

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
