using jdPay.PropertyUtil;
using jdPay.signature;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pbzx.Web;
using System.Configuration;
using Pbzx.Common;

namespace jdPay
{
    public partial class PayStartForm1 : System.Web.UI.Page
    {

        //必要的交易信息
        protected string v_amount;       // 订单金额-分
        protected string v_amountYuan;       // 订单金额-元
        protected string v_moneytype;    // 币种
        protected string v_md5info;      // 对拼凑串MD5私钥加密后的值
        protected string v_mid;		 // 商户号
        protected string v_url;		 // 返回页地址
        protected string v_oid;		 // 推荐订单号构成格式为 年月日-商户号-小时分钟秒


        //收货信息
        protected string v_rcvname;      // 收货人
        protected string v_rcvaddr;      // 收货地址
        protected string v_rcvtel;       // 收货人电话
        protected string v_rcvpost;      // 收货人邮编
        protected string v_rcvemail;     // 收货人邮件
        protected string v_rcvmobile;    // 收货人手机号

        //订货人信息
        protected string v_ordername;    // 订货人姓名
        protected string v_orderaddr;    // 订货人地址
        protected string v_ordertel;     // 订货人电话
        protected string v_orderpost;    // 订货人邮编
        protected string v_orderemail;   // 订货人邮件
        protected string v_ordermobile;  // 订货人手机号
        protected string pmode_id;
        //两个备注
        protected string remark1;
        protected string remark2;

        protected string v_userid;



        private void setJYvalue()
        {
            if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }

            string subject = "拼搏在线彩神通软件订单号：" + Request["OrderID"];

            //业务参数赋值；
            DataTable dtOrders = WebFunc.GetDsOrder(Input.FilterAll(Request["OrderID"]));

            if (dtOrders == null)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }

            DataSet dsDetails = null;
            DataRow row = null;
            if (dtOrders != null)
            {
                //Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付订单开始，订单号：" + Request["OrderID"], true, true);
                row = dtOrders.Rows[0];
                string out_trade_no = row["OrderID"].ToString();





                //服务器通知url（Alipay_Notify.aspx文件所在路经），必须是完整的路径地址
                string notify_url = WebInit.webBaseConfig.WebUrl + "jdPay/ybtongzhi.aspx"; //服务器通知返回接口
                //服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
                string return_url = WebInit.webBaseConfig.WebUrl + "jdPay/SuccessForm1.aspx"; //重定下地址


                decimal payJE = 0;
                if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
                }
                else if (dtOrders.TableName == "PBnet_Charge")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
                }
                v_amount =  Math.Round((Convert.ToDecimal(payJE)*100),0)+"";
                v_moneytype = "CNY";
                v_amountYuan = Math.Round((Convert.ToDecimal(payJE)),2) + "";

                ////Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "验证支付宝订单，此订单为商品订单。",true);
                //dsDetails = new Pbzx.BLL.PBnet_OrderDetail().SelectOrderDetailByOrderID(out_trade_no);

                //StringBuilder sbBody = new StringBuilder("");
                ////业务参数赋值；
                //string show_url = WebInit.webBaseConfig.WebUrl + "UserCenter/OrderShow/" + ViewState["Type"].ToString() + "-" + out_trade_no + ".htm";  //show_url商品展示地址，这个链接的作用是在支付宝收银台的商品链接旁边有个下划线“详情”的链接，而点链接弹出的一个新页面便是这个商品展示地址的页面。+ out_trade_no + "&type=" + ViewState["Type"]                

                //foreach (DataRow rowDetails in dsDetails.Tables[0].Rows)
                //{
                //    sbBody.AppendLine(rowDetails["pb_SoftName"].ToString());//+ WebFunc.CheckRegTye(rowDetails["RegType"], rowDetails["pb_TypeName"], rowDetails["pb_DemoUrl"], rowDetails["pb_RegUrl"]));
                //}
                //string body = StrFormat.CutStringByNum(sbBody.ToString(), 380);		//商品描述，即备注


                //交易单号
                this.tradeNum.Value = DateTime.Now.ToString("MMddHHmmss") + "_" + out_trade_no;

                //交易名称
                tradeName.Value = subject;
                //交易描述
                tradeDesc.Value = "";
                //金额
                amount.Value = v_amount;
                //返回地址
                callbackUrl.Value = return_url;
                //通知地址
                notifyUrl.Value = notify_url;
                v_userid = row["UserName"].ToString();
                userId.Value = v_userid;
                currency.Value = "CNY";


            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.merchant.Value = PropertyUtils.getProperty("wepay.merchant.num");
                DateTime nowDate = DateTime.Now;
                this.tradeTime.Value = nowDate.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
                this.ip.Value = getIp();
                setJYvalue();
            }

            #region
            ViewState["Type"] = "0";
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                if (Request["type"] == "1")
                {
                    ViewState["Type"] = "1";
                }
            }
            LoginSort login = new LoginSort();
            if (!login["manager_user"])
            {
                Response.Redirect("/login.aspx");
                return;
            }


            #endregion



            //v_mid = "1001";//ConfigurationManager.AppSettings["c_mid"].ToString();// 商户号，这里为测试商户号1001，替换为自己的商户号即可
            //v_url = WebInit.webBaseConfig.WebUrl + "jdpay/Receive.aspx"; // 商户自定义返回接收支付结果的页面
            // MD5密钥要跟订单提交页相同，如Send.asp里的 key = "test" ,修改""号内 test 为您的密钥
            //string key = "xxxx";//ConfigurationManager.AppSettings["c_pass"].ToString(); 			 // 如果您还没有设置MD5密钥请登陆我们为您提供商户后台，地址：https://merchant3.chinabank.com.cn/
            // 登陆后在上面的导航栏里可能找到“B2C”，在二级导航栏里有“MD5密钥设置”
            // 建议您设置一个16位以上的密钥或更高，密钥最多64位，但设置16位已经足够了

            //Pbzx.Common.ErrorLog.WriteLogMeng("\r\n网银在线验证订单，此订单为。");

            if (string.IsNullOrEmpty(Request["OrderID"]) || Request["OrderID"] == "")
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));

                return;
            }
            else
            {
                if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
                {
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "history.go(-1);", "", false, false));
                    return;
                }
                //DataTable dtOrders = WebFunc.GetDsOrder(Request["OrderID"]);
                //if (dtOrders == null)
                //{
                //    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
                //    return;
                //}
                //     Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付订单开始，订单号：" + Request["OrderID"], true, true);

                //decimal payJE = 0;
                //if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
                //{
                //    payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
                //}
                //else if (dtOrders.TableName == "PBnet_Charge")
                //{
                //    payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
                //}
                //v_amount = string.Format("{0:f}", Convert.ToDecimal(payJE));
                //v_oid = Input.FilterAll(Request["OrderID"]);
                //string text = v_amount + v_moneytype + v_oid + v_mid + v_url + key; // 拼凑加密串
                //v_md5info = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text, "md5").ToUpper();


            }
        }


        private SortedDictionary<String, String> orderInfoDic = new SortedDictionary<string, string>();
        private String oriUrl;
        public SortedDictionary<String, String> orderInfo
        {
            get { return orderInfoDic; }
        }

        public String payUrl
        {
            get { return oriUrl; }
        }



        private String getIp()
        {
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs)
            {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWork则为ipv6
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    String ipaddress = ip.ToString();
                    if(ipaddress.StartsWith("192.168") || ipaddress.StartsWith("127.0"))
                    {
                        continue;
                    }
                    IpCollection.Add(ip.ToString());
                    System.Diagnostics.Debug.WriteLine("IPV4:" + ip.ToString());
                }
                    
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            if (IpArray.Length < 1)
            {
                return "169.254.83.103";
                //return Request.ServerVariables.Get("Local_Addr").ToString();
            }
            return IpArray[0];
        }

        protected void showlayerClick(object sender, EventArgs e)
        {
            oriUrl = this.saveUrl.Value.Trim();
            orderInfoDic.AddOrPeplace("version", this.version.Value.Trim());
            orderInfoDic.AddOrPeplace("merchant", this.merchant.Value.Trim());
            orderInfoDic.AddOrPeplace("device", this.device.Value.Trim());
            orderInfoDic.AddOrPeplace("tradeNum", this.tradeNum.Value.Trim());
            orderInfoDic.AddOrPeplace("tradeName", this.tradeName.Value.Trim());
            orderInfoDic.AddOrPeplace("tradeDesc", this.tradeDesc.Value.Trim());
            orderInfoDic.AddOrPeplace("tradeTime", this.tradeTime.Value.Trim());
            orderInfoDic.AddOrPeplace("amount", this.amount.Value.Trim());
            orderInfoDic.AddOrPeplace("currency", this.currency.Value.Trim());
            orderInfoDic.AddOrPeplace("note", this.note.Value.Trim());
            orderInfoDic.AddOrPeplace("callbackUrl", this.callbackUrl.Value.Trim());
            orderInfoDic.AddOrPeplace("notifyUrl", this.notifyUrl.Value.Trim());
            orderInfoDic.AddOrPeplace("ip", this.ip.Value.Trim());
            orderInfoDic.AddOrPeplace("specCardNo", this.specCardNo.Value.Trim());
            orderInfoDic.AddOrPeplace("specId", this.specId.Value.Trim());
            orderInfoDic.AddOrPeplace("specName", this.specName.Value.Trim());
            orderInfoDic.AddOrPeplace("userType", this.userType.Value.Trim());
            orderInfoDic.AddOrPeplace("userId", this.userId.Value.Trim());
            orderInfoDic.AddOrPeplace("expireTime", this.expireTime.Value.Trim());
            orderInfoDic.AddOrPeplace("orderType", this.orderType.Value.Trim());
            orderInfoDic.AddOrPeplace("industryCategoryCode", this.industryCategoryCode.Value.Trim());

            String priKey = PropertyUtils.getProperty("wepay.merchant.rsaPrivateKey");
            String desKey = PropertyUtils.getProperty("wepay.merchant.desKey");
            List<String> unSignedKeyList = new List<string>();
            unSignedKeyList.Add("sign");
            String signStr = SignUtil.signRemoveSelectedKeys(orderInfoDic,priKey,unSignedKeyList);
            System.Diagnostics.Debug.WriteLine("sign:" + signStr);
            orderInfoDic.AddOrPeplace("sign", signStr);
            byte[] key = Convert.FromBase64String(desKey);
                 //当模式为ECB时，IV无用,java默认使用的ECB
            if (isNotBlank(orderInfoDic.getVaule("device")))
            {
                //String desStr = Des3.Des3EncryptECB(key, orderInfoDic.getVaule("device"));
                orderInfoDic.AddOrPeplace("device", Des3.Des3EncryptECB(key,orderInfoDic.getVaule("device")));
                //String str = Des3.Des3DecryptECB(key, desStr);
            }
           orderInfoDic.AddOrPeplace("tradeNum", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("tradeNum")));
            if (isNotBlank(orderInfoDic.getVaule("tradeName")))
            {
                orderInfoDic.AddOrPeplace("tradeName", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("tradeName")));
            }
            if (isNotBlank(orderInfoDic.getVaule("tradeDesc")))
            {
                orderInfoDic.AddOrPeplace("tradeDesc", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("tradeDesc")));
            }
            orderInfoDic.AddOrPeplace("tradeTime", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("tradeTime")));
            orderInfoDic.AddOrPeplace("amount", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("amount")));
            orderInfoDic.AddOrPeplace("currency", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("currency")));
            if (isNotBlank(orderInfoDic.getVaule("note")))
            {
                orderInfoDic.AddOrPeplace("note", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("note")));
            }
            orderInfoDic.AddOrPeplace("callbackUrl", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("callbackUrl")));
            orderInfoDic.AddOrPeplace("notifyUrl", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("notifyUrl")));
            orderInfoDic.AddOrPeplace("ip", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("ip")));
            if (isNotBlank(orderInfoDic.getVaule("userType")))
            {
                orderInfoDic.AddOrPeplace("userType", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("userType")));
            }
            if (isNotBlank(orderInfoDic.getVaule("userId")))
            {
                orderInfoDic.AddOrPeplace("userId", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("userId")));
            }
            if (isNotBlank(orderInfoDic.getVaule("expireTime")))
            {
                orderInfoDic.AddOrPeplace("expireTime", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("expireTime")));
            }
            if (isNotBlank(orderInfoDic.getVaule("orderType")))
            {
                orderInfoDic.AddOrPeplace("orderType", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("orderType")));
            }
            if (isNotBlank(orderInfoDic.getVaule("industryCategoryCode")))
            {
                orderInfoDic.AddOrPeplace("industryCategoryCode", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("industryCategoryCode")));
            }
            if (isNotBlank(orderInfoDic.getVaule("specCardNo")))
            {
                orderInfoDic.AddOrPeplace("specCardNo", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("specCardNo")));
            }
            if (isNotBlank(orderInfoDic.getVaule("specId")))
            {
                orderInfoDic.AddOrPeplace("specId", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("specId")));
            }
            if (isNotBlank(orderInfoDic.getVaule("specName")))
            {
                orderInfoDic.AddOrPeplace("specName", Des3.Des3EncryptECB(key, orderInfoDic.getVaule("specName")));
            }
            Server.Transfer("autoSubmitForm1.aspx");
        }

        private bool isNotBlank(String value)
        {
            if(value!=null && value.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}