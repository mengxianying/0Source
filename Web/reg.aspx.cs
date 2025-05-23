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
                    CheckUserName(Input.FilterAll(Server.UrlDecode(Request["checkUserName"])));
                }

                if (Request["checkUserNameInput"] != null)
                {
                    CheckUserNameInput(Input.FilterAll(Server.UrlDecode(Request["checkUserNameInput"])));
                }

                //处理判断用户Email是否被占用
                if (Request["checkUserEmail"] != null)
                {
                    CheckUserEmail(Input.FilterAll(Server.UrlDecode(Request["checkUserEmail"])));
                }

                if (Request["checkUserMobile"] != null)
                {
                    CheckUserMobile(Input.FilterAll(Server.UrlDecode(Request["checkUserMobile"])));
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

                //判断是否登录
                if (Request["IsLogin"] != null)
                {
                    IsLogin();
                }
                //登录
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uCode"] != null && Request["uTime"] != null)
                {
                    //                   MyCheckLogin(Server.UrlDecode(Input.FilterAll(Request["uName"])), Input.FilterAll(Request["uPwd"]), Input.FilterAll(Request["uCode"]), Input.FilterAll(Request["uTime"]));
                    MyCheckLogin(Input.FilterAll(Server.UrlDecode(Request["uName"])), Input.FilterAll(Server.UrlDecode(Request["uPwd"])), Input.FilterAll(Server.UrlDecode(Request["uCode"])), Input.FilterAll(Server.UrlDecode(Request["uTime"])));
                }
                if (Request["uName"] != null && Request["uPwd"] != null && Request["uTime"] != null && Request["loginType"] != null)
                {
                    MyCheckLoginAsp(Input.FilterAll(Server.UrlDecode(Request["uName"])), Input.FilterAll(Server.UrlDecode(Request["uPwd"])), Input.FilterAll(Server.UrlDecode(Request["uTime"])), Input.FilterAll(Server.UrlDecode(Request["loginType"])));
                }
                //退出
                if (Request["loginOut"] != null)
                {
                    MyLoginOut();
                }

                //RepairMobile邮箱验证
                if (Request["CheckEmailCode"] != null && Request["email_RM"] != null)
                {
                    CheckEmailCode();
                }

                //注册email验证
                if (Request["checkEmail"] != null && Request["email"] != null)
                {
                    CheckEmail();
                }

                //RepairMobile手机验证
                if (Request["CheckPhoneCode"] != null && Request["phone"] != null)
                {
                    CheckPhoneCode();
                }
                

                //注册phone验证
                if (Request["checkPhone"] != null && Request["phone"] != null)
                {
                    CheckPhone();
                }


                //计算当前行价格，更新至数据库
                if (Request["product"] != null && Request["quantity"] != null && Request["type"] != null && Request["price"] != null)
                {
                    UpdateShoppingCart(Input.FilterAll(Server.UrlDecode(Request["product"])), Input.FilterAll(Server.UrlDecode(Request["quantity"])), Input.FilterAll(Server.UrlDecode(Request["type"])), Input.FilterAll(Server.UrlDecode(Request["price"])));
                }

                ///计算当前购物车商品总价格
                if (Request["CalcPrice"] != null && Request["CalcPrice"] == "Yes")
                {
                    CalcTotalPrice();
                }
                //删除购物车商品
                if (Request["delCart"] != null)
                {
                    DelShoppingCartByID(Input.FilterAll(Server.UrlDecode(Request["delCart"])));
                }

                //清空购物车
                if (Request["clearCart"] != null)
                {
                    ClearCart(Input.FilterAll(Server.UrlDecode(Request["clearCart"])));
                }
                //新闻幻灯片
                if (Request["newsSlide"] != null)
                {
                    string temp = Input.FilterAll(Server.UrlDecode(Request["newsSlide"]));
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
                    CheckUserRealName(Input.FilterAll(Server.UrlDecode(Request["SelectUserRealName"])));
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
                    QuickAddProduct(Server.UrlDecode(Input.FilterAll(Server.UrlDecode(Request["quickAddProduct"]))));
                }

                //验证码框内，当键盘按下的时候验证是否正确
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


                //后台编辑器上传功能///////////////////////////////////////////////////////////////////////////////
                if (!string.IsNullOrEmpty(Request["CheckAdminUpload"]) && Request["CheckAdminUpload"] == "meng")
                {
                    CheckAdminUpload();
                }

                //网页关键字
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
                Response.Write("<script>parent.yanzhengmacallback('P');</script>"); //Response.Write("验证码已经失效！请点击验证码图片重新获取验证码");
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

        private void InitLoginIP(string username)
        {
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("userlogin")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //给它不可能的地址
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
                //判断IP
                string ip = "";
                if (Context.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
                {
                    // 得到真实的客户端地址
                    ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
                }
                else//如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP 
                {
                    //得到服务端的地址 
                    ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
                }
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log(username, "", "已屏蔽该IP位置登录", "登录相关");
                    Response.Redirect("http://www.pinble.com");
                }
                //判断省份
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log(username, "", "已屏蔽该地址位置登录", "登录相关");
                    Response.Redirect("http://www.pinble.com");
                }
            }
        }

        /// <summary>
        /// 循环判断
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
        /// 登录
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
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Input.FilterAll(Server.UrlDecode(uName)) + "' ");
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


        /// <summary>
        /// RepairMobile邮箱验证码验证
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
                            //检查是否在60秒内连续发送短信
                            ErrorInfo = "请勿连续点击发送按钮，如果没收到验证码请60秒后再发送。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        //else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        //{
                        //    //检查手机号码当天是否已经发送3次短信
                        //    ErrorInfo = "对不起，该电子邮箱" + strEmail + "今天已发送3次验证码，请改天再发。";
                        //    return;
                        //}
                        //else if (DbHelperSQL.Exists("SELECT top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        //{
                        //    //检查手机号码是否正在发送短信
                        //    ErrorInfo = "正在发送验证码，请勿重复发送。";
                        //    return;
                        //}

                        string serverCode = GenerateRandomCode();
                        Session["Email_CHECKCODE_RM"] = serverCode;
                        //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                        //String shoujiayanzhengma = serverCode;

                        // 启用高防后IP地址都一样了，不再插入IP地址
                        //strIP = "";

                        //String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                        //Response.Write(zsql);

                        //int result = 0;
                        //result = DbHelperSQL.ExecuteSql(zsql);

                        //远程调用
                        Pbzx.Web.Web_JmailService.WebService1 wb = new Pbzx.Web.Web_JmailService.WebService1();


                        if (wb.GetEmail(strEmail, "拼搏在线注册验证码（系统自动发送，请勿回复）", "您正在拼搏在线邮箱验证，验证码为：" + serverCode + "，请返回页面输入验证码（此为系统邮件，请勿回复）"))
                        {
                            Session["Email_CHECKCODE_RM"] = serverCode;
                            Pbzx.Common.ErrorLog.WriteLogMeng("邮件发送", "邮件发送成功：" + strEmail + "；验证码:" + serverCode + "\r\n", true, true);
                            Response.Write("true");
                            Response.End();
                            return;
                        }
                        else
                        {
                            ErrorInfo = "邮件发送失败";
                        }

                    }
                    else
                    {
                        ErrorInfo = "电子邮箱不能为空";
                    }
                }
                else
                {
                    ErrorInfo = "电子邮箱不能为空";
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
        /// RepairMobile手机验证码验证
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
                        //检查手机号码是否正确
                        if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$") && strMobile.Length != 11)
                        {
                            ErrorInfo = "对不起，该手机号码" + strMobile + "不正确！。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where MOBILE='" + strMobile + "' "))
                        {
                            //检查手机号码是否已经注册
                            ErrorInfo = "对不起，该手机号码" + strMobile + "已被使用。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Exists("select top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE (MOBILE = '" + strMobile + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //检查是否在60秒内连续发送短信
                            ErrorInfo = "请勿连续点击发送按钮，如果没收到验证码请60秒后再发送。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        {
                            //检查手机号码当天是否已经发送3次短信
                            ErrorInfo = "对不起，该手机号码" + strMobile + "今天已发送3次验证码，请改天再发。";
                            return;
                        }
                        //                            else if (DbHelperSQL.Query("SELECT IP  FROM dbo.PBnet_TBL_SMS WHERE Len(IP) > 0 and IP = '" + strIP + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count > IP_ValideCode_Count)
                        //                            {
                        //                                //检查当前IP当天是否已经发送3次短信
                        ////                              ErrorInfo = "对不起，该IP地址" + strIP + " 今天发送验证码次数已经超额，请改天再发。";
                        //                                ErrorInfo = "对不起，今天发送验证码次数已经超额，请改天再发。";
                        //                                return;
                        //                            }
                        else if (DbHelperSQL.Exists("SELECT top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        {
                            //检查手机号码是否正在发送短信
                            ErrorInfo = "正在发送验证码，请勿重复发送。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }

                        string[] str = new string[4];
                        string serverCode = "";
                        //生成随机生成器 
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

                        // 启用高防后IP地址都一样了，不再插入IP地址
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
                        ErrorInfo = "手机号码不能为空";
                    }
                }
                else
                {
                    ErrorInfo = "手机号码不能为空";
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
        /// 注册email验证码验证
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
                        //检查电子邮箱格式是否正确
                        if (!Regex.IsMatch(strEmail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                        {
                            ErrorInfo = "对不起，该电子邮箱" + strEmail + "格式不正确！。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + strEmail + "'"))
                        {
                            //检查手机号码是否已经注册
                            ErrorInfo = "对不起，该电子邮箱" + strEmail + "已被使用。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Exists("select top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE (EMAIL = '" + strEmail + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //检查是否在60秒内连续发送短信
                            ErrorInfo = "请勿连续点击发送按钮，如果没收到验证码请60秒后再发送。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        //else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        //{
                        //    //检查手机号码当天是否已经发送3次短信
                        //    ErrorInfo = "对不起，该电子邮箱" + strEmail + "今天已发送3次验证码，请改天再发。";
                        //    return;
                        //}
                        //else if (DbHelperSQL.Exists("SELECT top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE EMAIL = '" + strEmail + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        //{
                        //    //检查手机号码是否正在发送短信
                        //    ErrorInfo = "正在发送验证码，请勿重复发送。";
                        //    return;
                        //}

                        string serverCode = GenerateRandomCode();
                        Session["Email_CHECKCODE"] = serverCode;
                        //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                        //String shoujiayanzhengma = serverCode;

                        // 启用高防后IP地址都一样了，不再插入IP地址
                        //strIP = "";

                        //String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                        //Response.Write(zsql);

                        //int result = 0;
                        //result = DbHelperSQL.ExecuteSql(zsql);

                        //远程调用
                        Pbzx.Web.Web_JmailService.WebService1 wb = new Pbzx.Web.Web_JmailService.WebService1();

                        Pbzx.Common.ErrorLog.WriteLogMeng("邮件发送", "邮件发送开始：" + strEmail + "；验证码:"+ serverCode+"\r\n", true, true);
                        if (wb.GetEmail(strEmail, "拼搏在线注册验证码（系统自动发送，请勿回复）", "您正在注册拼搏在线，验证码为：" + serverCode + "，请返回页面输入验证码（此为系统邮件，请勿回复）"))
                        {
                            Session["Email_CHECKCODE"] = serverCode;
                            Pbzx.Common.ErrorLog.WriteLogMeng("邮件发送", "邮件发送成功：" + strEmail + "；验证码:" + serverCode + "\r\n", true, true);
                            Response.Write("true");
                            Response.End();
                            return;
                        }
                        else
                        {
                            Pbzx.Common.ErrorLog.WriteLogMeng("邮件发送", "邮件发送失败：" + strEmail + "；验证码:" + serverCode + "\r\n", true, true);
                            ErrorInfo = "邮件发送失败";
                        }

                    }
                    else
                    {
                        ErrorInfo = "电子邮箱不能为空";
                    }
                }
                else
                {
                    ErrorInfo = "电子邮箱不能为空";
                }
                Response.Write(ErrorInfo);
                Response.End();
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("邮件发送", "邮件发送异常：" + ex.ToString() + "\r\n", true, true);
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
                        //检查手机号码是否正确
                        if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$") && strMobile.Length != 11)
                        {
                            ErrorInfo = "对不起，该手机号码" + strMobile + "不正确！。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where MOBILE='" + strMobile + "' "))
                        {
                            //检查手机号码是否已经注册
                            ErrorInfo = "对不起，该手机号码" + strMobile + "已被使用。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Exists("select top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE (MOBILE = '" + strMobile + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                        {
                            //检查是否在60秒内连续发送短信
                            ErrorInfo = "请勿连续点击发送按钮，如果没收到验证码请60秒后再发送。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }
                        else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                        {
                            //检查手机号码当天是否已经发送3次短信
                            ErrorInfo = "对不起，该手机号码" + strMobile + "今天已发送3次验证码，请改天再发。";
                            return;
                        }
                        //                            else if (DbHelperSQL.Query("SELECT IP  FROM dbo.PBnet_TBL_SMS WHERE Len(IP) > 0 and IP = '" + strIP + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count > IP_ValideCode_Count)
                        //                            {
                        //                                //检查当前IP当天是否已经发送3次短信
                        ////                              ErrorInfo = "对不起，该IP地址" + strIP + " 今天发送验证码次数已经超额，请改天再发。";
                        //                                ErrorInfo = "对不起，今天发送验证码次数已经超额，请改天再发。";
                        //                                return;
                        //                            }
                        else if (DbHelperSQL.Exists("SELECT top 1 PARAS  FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                        {
                            //检查手机号码是否正在发送短信
                            ErrorInfo = "正在发送验证码，请勿重复发送。";
                            Response.Write(ErrorInfo);
                            Response.End();
                        }

                        string[] str = new string[4];
                        string serverCode = "";
                        //生成随机生成器 
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

                        // 启用高防后IP地址都一样了，不再插入IP地址
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
                        ErrorInfo = "手机号码不能为空";
                    }
                }
                else
                {
                    ErrorInfo = "手机号码不能为空";
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
            // 包含所有可能字符的字符池
            char[] charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();//abcdefghijklmnopqrstuvwxyz
            // 使用加密级别的随机数生成器
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[6];
                rng.GetBytes(tokenData); // 填充随机字节

                char[] result = new char[6];
                for (int i = 0; i < 6; i++)
                {
                    // 将字节值映射到字符池索引
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
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "暂无数据&");
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
                result = "<font color='red'>用户名不能为空！</font>";
            }
            else if (!Regex.IsMatch(strName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                result = "<font color='red'>用户名必须是3-12位(允许字母、数字、汉字)！</font>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                result = "<font color='red'>用户名必须是3-12位！</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + strName + "'"))
            {
                result = "<font color='red'>对不起,您的用户名已经被占用！</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">可以使用&nbsp;</font>";
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
                result = "<font color='red'>此用户名不存在或已经被锁定！</font>";
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
                result = "<font color='red'>Email不能为空！</font>";
            }
            else if (!Regex.IsMatch(strEmail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                result = "<font color='red'>Email格式不正确！</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + strEmail + "'"))
            {
                result = "<font color='red'>对不起，您的Email已经被占用！</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">可以使用&nbsp;</font>";
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
                result = "<font color='red'>手机号码不能为空！</font>";
            }
            else if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$"))
            {
                result = "<font color='red'>手机号码不正确！</font>";
            }
            else if (DbHelperSQLBBS.Exists("select * from dbo.Dv_User where Mobile='" + strMobile + "'"))
            {
                result = "<font color='red'>对不起，该手机号码已经被使用！</font>";
            }
            else
            {
                result = "<font color=\"#8594A7\">可以使用&nbsp;</font>";
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
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "暂无数据&");
            Response.End();
        }
    }
}
