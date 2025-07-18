<script language="C#" runat="server">
    /*
 * @Description: 快钱神州行支付网关接口范例
 * @Copyright (c) 上海快钱信息服务有限公司
 * @version 2.0
 */

    //初始化结果及地址
    int rtnOk = 0;
    String rtnUrl = "";

    void Page_Load(Object sender, EventArgs E)
    {

        //获取神州行网关账户号
        String merchantAcctId = ConfigurationManager.AppSettings["RMB_mid"];

        //设置神州行网关密钥
        ///区分大小写
        String key = ConfigurationManager.AppSettings["SZX_key"];


        //获取网关版本.固定值
        ///本代码版本号固定为v2.0
        String version = Request["version"].ToString().Trim();

        //获取语言种类.固定选择值。
        ///只能选择1、2
        ///1代表中文；2代表英文
        String language = Request["language"].ToString().Trim();

        //获取支付方式
        ///可选择00、41、42、52
        ///00 代表快钱默认支付方式，目前为神州行卡密支付和快钱账户支付；41 代表快钱账户支付；42 代表神州行卡密支付和快钱账户支付；52 代表神州行卡密支付
        String payType = Request["payType"].ToString().Trim();

        //神州行卡序号
        ///如果通过神州行卡直接支付时返回
        String cardNumber = Request["cardNumber"].ToString().Trim();

        //获取神州行卡密码
        ///如果通过神州行卡直接支付时返回
        String cardPwd = Request["cardPwd"].ToString().Trim();

        //获取商户订单号
        String orderId = Request["orderId"].ToString().Trim();


        //获取原始订单金额
        ///订单提交到快钱时的金额，单位为分。
        ///比方2 ，代表0.02元
        String orderAmount = Request["orderAmount"].ToString().Trim();

        //获取快钱交易号
        ///获取该交易在快钱的交易号
        String dealId = Request["dealId"].ToString().Trim();


        //获取商户提交订单时的时间
        ///14位数字。年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]
        ///如：20080101010101
        String orderTime = Request["orderTime"].ToString().Trim();

        //获取扩展字段1
        ///与商户提交订单时的扩展字段1保持一致
        String ext1 = Request["ext1"].ToString().Trim();

        //获取扩展字段2
        ///与商户提交订单时的扩展字段2保持一致
        String ext2 = Request["ext2"].ToString().Trim();

        //获取实际支付金额
        ///单位为分
        ///比方 2 ，代表0.02元
        String payAmount = Request["payAmount"].ToString().Trim();

        //获取快钱处理时间
        String billOrderTime = Request["billOrderTime"].ToString().Trim();

        //获取处理结果
        ///10代表支付成功； 11代表支付失败
        String payResult = Request["payResult"].ToString().Trim();

        //获取签名类型
        ///1代表MD5签名
        ///当前版本固定为1
        String signType = Request["signType"].ToString().Trim();

        //获取加密签名串
        String signMsg = Request["signMsg"].ToString().Trim();




        //生成加密串。必须保持如下顺序。
        String merchantSignMsgVal = "";
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "merchantAcctId", merchantAcctId);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "version", version);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "language", language);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "payType", payType);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "cardNumber", cardNumber);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "cardPwd", cardPwd);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderId", orderId);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderAmount", orderAmount);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "dealId", dealId);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderTime", orderTime);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext1", ext1);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext2", ext2);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "payAmount", payAmount);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "billOrderTime", billOrderTime);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "payResult", payResult);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "signType", signType);
        merchantSignMsgVal = appendParam(merchantSignMsgVal, "key", key);

        String merchantSignMsg = GetMD5(merchantSignMsgVal, "utf-8");



        //商家进行数据处理，并跳转会商家显示支付结果的页面
        ///首先进行签名字符串验证
        if (signMsg.ToUpper() == merchantSignMsg.ToUpper())
        {

            switch (payResult)
            {

                case "10":
                    /*  
                     // 商户网站逻辑处理，比方更新订单支付状态为成功
                    // 特别注意：只有signMsg.ToUpper() == merchantSignMsg.ToUpper()，且payResult=10，才表示支付成功！
                    */

                    //报告给快钱处理结果，并提供将要重定向的地址。
                    rtnOk = 1;
                    decimal dcPayAmount = decimal.Parse(payAmount) / 100;
                    System.Data.DataTable dtOrder = Pbzx.Web.WebFunc.GetDsOrder(orderId);
                    decimal orderJE = 0;
                    if (dtOrder.TableName == "PBnet_Orders" || dtOrder.TableName == "PBnet_Orders_Delegates")
                    {
                        orderJE = Convert.ToDecimal(dtOrder.Rows[0]["HasNotPayedPrice"]);
                    }
                    else if (dtOrder.TableName == "PBnet_Charge")
                    {
                        orderJE = Convert.ToDecimal(dtOrder.Rows[0]["PayMoney"]);
                    }
                    if (Convert.ToInt32(orderJE * 100) != (Convert.ToInt32(payAmount)))
                    {
                        rtnOk = 1;
                        rtnUrl = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/show.aspx?msg=false";
                        break;
                    }
                    Pbzx.Web.WebFunc.UpdateOrder(orderId, true, Convert.ToString(Convert.ToDecimal(orderAmount) / 100), "99bill@pinble.com", "（自动）", 15, "快钱支付");
                    rtnUrl = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/show.aspx?msg=success";
                    Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "快钱（神州行网关）订单后台通知页，订单号：" + orderId + "\r\n结果：交易成功", true, true);
                    break;

                default:
                    rtnOk = 1;
                    rtnUrl = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/show.aspx?msg=false";
                    break;
            }

        }
        else
        {
            rtnOk = 1;
            rtnUrl = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/show.aspx?msg=error";
            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "快钱（神州行网关）订单后台通知页，订单号：" + orderId + "\r\n客户端校验码：" + signMsg + "\r\n服务器校验码：" + merchantSignMsg + "\r\n结果：校验失败，数据可疑", true, true);

            string Name = Pbzx.Common.Method.Get_UserName;
            if (Name == "0")
            {
                Name = "游客";
            }
            Pbzx.Common.Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");
        }


    }

    //功能函数。将变量值不为空的参数组成字符串
    String appendParam(String returnStr, String paramId, String paramValue)
    {

        if (returnStr != "")
        {

            if (paramValue != "")
            {

                returnStr += "&" + paramId + "=" + paramValue;
            }

        }
        else
        {

            if (paramValue != "")
            {
                returnStr = paramId + "=" + paramValue;
            }
        }

        return returnStr;
    }
    //功能函数。将变量值不为空的参数组成字符串。结束



    //功能函数。将字符串进行编码格式转换，并进行MD5加密，然后返回。开始
    private static string GetMD5(string dataStr, string codeType)
    {
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(System.Text.Encoding.GetEncoding(codeType).GetBytes(dataStr));
        System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }
    //功能函数。将字符串进行编码格式转换，并进行MD5加密，然后返回。结束

    //以下报告给快钱处理结果，并提供将要重定向的地址
</script>

<result><%=rtnOk %></result>
<redirecturl><%=rtnUrl %></redirecturl>
