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
                //处理新闻搜索
                if (Request["strSearch"] != null)
                {
                    ProcessingSearch(Input.FilterAll(Server.UrlDecode(Request["strSearch"])));
                }

                //处理公告搜索
                if (Request["strBulletin"] != null)
                {
                    ProcessingSearch1(Input.FilterAll(Server.UrlDecode(Request["strBulletin"])));
                }
                //处理学院搜索
                if (Request["strShool"] != null)
                {
                    ProcessingSearch2(Input.FilterAll(Server.UrlDecode(Request["strShool"])));
                }


                //处理新闻点击次数自动增加
                if (Request["NewsClick"] != null)
                {
                    string id = Input.FilterAll(Request["NewsClick"]);
                    if (id.Length > 0)
                    {
                        NewsClickAdd(Input.FilterAll(Request["NewsClick"]));
                    }
                }

                //处理公告点击次数自动增加
                if (Request["BulletinClick"] != null)
                {
                    string id = Input.FilterAll(Request["BulletinClick"]);
                    if (id.Length > 0)
                    {
                        BulletinClickAdd(Input.FilterAll(Request["BulletinClick"]));
                    }
                }

                //处理公告点击次数自动增加
                if (Request["SchoolClick"] != null)
                {
                    string id = Input.FilterAll(Request["SchoolClick"]);
                    if (id.Length > 0)
                    {
                        SchoolClickAdd(Input.FilterAll(Request["SchoolClick"]));
                    }
                }

                //处理省市绑定
                if (Request["province"] != null)
                {
                    GetCityData(Input.FilterAll(Server.UrlDecode(Request["province"])));
                }

                //处理判断用户名是否占用
                if (Request["checkUserName"] != null)
                {
                    CheckUserName(Server.UrlDecode(Input.FilterAll(Request["checkUserName"])));
                }

                if (Request["checkUserNameInput"] != null)
                {
                    CheckUserNameInput(Server.UrlDecode(Input.FilterAll(Request["checkUserNameInput"])));
                }

                //处理判断用户Email是否被占用
                if (Request["checkUserEmail"] != null)
                {
                    CheckUserEmail(Server.UrlDecode(Input.FilterAll(Request["checkUserEmail"])));
                }

                ////处理聊彩室
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

                //判断是否登录
                if (Request["IsLogin"] != null)
                {
                    IsLogin();
                }
                //登录
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uCode"] != null && Request["uTime"] != null)
                {
                    MyCheckLogin(Server.UrlDecode(Input.FilterAll(Request["uName"])), Input.FilterAll(Request["uPwd"]), Input.FilterAll(Request["uCode"]), Input.FilterAll(Request["uTime"]));
                }
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uTime"] != null && Request["loginType"] != null)
                {
                    MyCheckLoginAsp(Server.UrlDecode(Input.FilterAll(Request["uName"])), Input.FilterAll(Request["uPwd"]), Input.FilterAll(Request["uTime"]), Input.FilterAll(Request["loginType"]));
                }
                //退出
                if (Request["loginOut"] != null)
                {
                    MyLoginOut();
                }
                //计算当前行价格，更新至数据库
                if (Request["product"] != null && Request["quantity"] != null && Request["type"] != null && Request["price"] != null)
                {
                    UpdateShoppingCart(Input.FilterAll(Request["product"]), Input.FilterAll(Request["quantity"]), Input.FilterAll(Request["type"]), Input.FilterAll(Request["price"]));
                }

                ///计算当前购物车商品总价格
                if (Request["CalcPrice"] != null && Request["CalcPrice"] == "Yes")
                {
                    CalcTotalPrice();
                }
                //删除购物车商品
                if (Request["delCart"] != null)
                {
                    DelShoppingCartByID(Input.FilterAll(Request["delCart"]));
                }

                //清空购物车
                if (Request["clearCart"] != null)
                {
                    ClearCart(Input.FilterAll(Request["clearCart"]));
                }
                //新闻幻灯片
                if (Request["newsSlide"] != null)
                {
                    string temp = Input.FilterAll(Request["newsSlide"]);
                    if (temp.ToLower() == "yes")
                    {
                        BindHot();
                    }
                }

                ///检查是否是高级用户
                if (Request["IsRealInfo"] != null)
                {
                    string temp = Request["IsRealInfo"];
                    if (temp == "IsRealInfo")
                    {
                        CheckIsRealInfo();
                    }
                }

                //检测用户是否存在，并查询真实用户名
                if (Request["SelectUserRealName"] != null)
                {
                    CheckUserRealName(Input.FilterAll(Request["SelectUserRealName"]));
                }

                //检测经纪人是否已经申请
                if (Request["CheckIsBroker"] != null)
                {
                    if (Input.FilterAll(Request["CheckIsBroker"]) == "abc")
                    {
                        CheckIsBroker();
                    }

                }
                //检测代理是否已经申请
                if (Request["CheckIsDaili"] != null)
                {
                    if (Input.FilterAll(Request["CheckIsDaili"]) == "abc")
                    {
                        CheckIsDaili();
                    }

                }


                //购物车快速添加产品
                if (Request["quickAddProduct"] != null)
                {
                    QuickAddProduct(Server.UrlDecode(Input.FilterAll(Request["quickAddProduct"])));
                }

                //验证码框内，当键盘按下的时候验证是否正确
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


                //后台编辑器上传功能///////////////////////////////////////////////////////////////////////////////
                if (!string.IsNullOrEmpty(Request["CheckAdminUpload"]) && Request["CheckAdminUpload"] == "meng")
                {
                    CheckAdminUpload();
                }



            }
        }
        /// <summary>
        /// 检查验证码是否正确
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
        /// 检查验证码是否正确
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
                Response.Write("验证码已经失效！请点击验证码图片重新获取验证码");
            }
            Response.End();
        }

        #region 购物车快速添加产品
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


        #region 加入购物车
        private void InsertShoppingCart(int productID)
        {
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            Pbzx.Model.PBnet_Product productModel = productBLL.GetModel(productID);
            string danjPrice = productModel.pb_DemoUrl;
            string zongsPrice = productModel.pb_RegUrl;

            if (productModel.pb_TypeName == "专业版")
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
            int index1 = strPrice.IndexOf("元");
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

        //检测经纪人是否已经申请
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

        //检测代理是否已经申请
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

        //检测用户是否存在，并查询真实用户名
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
        /// 检测是否是高级用户
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
        /// 清空购物车
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
        /// 根据购物车ID删除购物车
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
        /// 计算当前购物车商品总价格
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
        /// 计算当前行价格，更新至数据库
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
        /// 登录
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
                strResult = "验证码已经失效！请点击验证码重新获取。";
            }
            else if (uCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                strResult = "验证码错误";
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
        /// 登录
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
        /// 退出
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
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "暂无数据&");
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
                result = "<font color='red'>用户名不能为空！</font>";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                result = "<font color='red'>用户名必须是3-12位(允许字母、数字、汉字)！</font>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                result = "<font color='red'>用户名必须是3-12位！</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                result = "<font color='red'>对不起,您的用户名已经被占用！</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">可以使用&nbsp;</font>";
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
                result = "<font color='red'>此用户名不存在或已经被锁定！</font>";
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
                Response.Write("<font color='red'>Email不能为空！</font>");
            }
            else if (!Regex.IsMatch(userEmail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                Response.Write("<font color='red'>Email格式不正确！</font>");
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + userEmail + "'"))
            {
                Response.Write("<font color='red'>对不起,您的Email已经被占用！</font>");
            }
            else
            {
                Response.Write("<font color=\"#8594A7\">可以使用&nbsp;</font>");
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
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "暂无数据&");
            Response.End();
        }
    }
}
