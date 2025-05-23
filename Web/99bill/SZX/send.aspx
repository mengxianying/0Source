<%@ Register Src="../../Contorls/Head.ascx" TagName="Head" TagPrefix="uc3" %>
<%@ Register Src="../../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>

<script language="C#" runat="server">
    /**
 * @Description: ��Ǯ������֧�����ؽӿڷ���
 * @Copyright (c) �Ϻ���Ǯ��Ϣ�������޹�˾
 * @version 2.0
 */
    public string strOrderID = "";
    public string strOrderAmount = "";
    void Page_Load(Object sender, EventArgs E)
    {

        //�����������˻���
        ///�����Ǯ������ϵ��ȡ
        merchantAcctId.Value = ConfigurationManager.AppSettings["SZX_mid"];

        //����������������Կ
        ///���ִ�Сд
        String key = ConfigurationManager.AppSettings["SZX_key"];


        //�ַ���.�̶�ѡ��ֵ����Ϊ�ա�
        ///ֻ��ѡ��1��2��3��5
        ///1����UTF-8; 2����GBK; 3����gb2312; 5 ����big5
        ///Ĭ��ֵΪ1
        inputCharset.Value = "1";

        //����������֧������ĺ�̨��ַ.��[pageUrl]����ͬʱΪ�ա������Ǿ��Ե�ַ��
        ///��Ǯͨ�����������ӵķ�ʽ�����׽�����͵�[bgUrl]��Ӧ��ҳ���ַ�����̻�������ɺ������<result>���Ϊ1��ҳ���ת��<redirecturl>��Ӧ�ĵ�ַ��
        ///�����Ǯδ���յ�<redirecturl>��Ӧ�ĵ�ַ����Ǯ����֧�����GET��[pageUrl]��Ӧ��ҳ�档
        bgUrl.Value = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/receive.aspx";

        //����֧�������ҳ���ַ.��[bgUrl]����ͬʱΪ�ա������Ǿ��Ե�ַ��
        ///���[bgUrl]Ϊ�գ���Ǯ��֧�����GET��[pageUrl]��Ӧ�ĵ�ַ��
        ///���[bgUrl]��Ϊ�գ�����[bgUrl]ҳ��ָ����<redirecturl>��ַ��Ϊ�գ���ת��<redirecturl>��Ӧ�ĵ�ַ.
        pageUrl.Value = "";

        //���ذ汾.�̶�ֵ
        ///��Ǯ����ݰ汾�������ö�Ӧ�Ľӿڴ������
        ///������汾�Ź̶�Ϊv2.0
        version.Value = "v2.0";

        //��������.�̶�ѡ��ֵ��
        ///ֻ��ѡ��1��2��3
        ///1�������ģ�2����Ӣ��
        ///Ĭ��ֵΪ1
        language.Value = "1";

        //ǩ������.�̶�ֵ
        ///1����MD5ǩ��
        ///��ǰ�汾�̶�Ϊ1
        signType.Value = "1";

        if (string.IsNullOrEmpty(Pbzx.Common.Input.FilterAll(Request["OrderID"])) || Request["OrderID"] == "")
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "��������", 400, "1", "history.go(-1);", "", false, false));
            return;
        }
        strOrderID = Pbzx.Common.Input.FilterAll(Request["OrderID"]);
        System.Data.DataTable dtOrder = Pbzx.Web.WebFunc.GetDsOrder(strOrderID);
        if (dtOrder == null)
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "��������", 400, "1", "history.go(-1);", "", false, false));
            return;
        }
        if (!Pbzx.Web.WebFunc.CheckOrderIsValidate(Request["OrderID"]))
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "�Բ��𣡸ö�����ȡ��������ʧЧ��", 400, "1", "history.go(-1);", "", false, false));
            return;
        }


        string payName = "";
        string payContact = "";

        string strProductName = "";
        string strProductDesc = "";

        if (dtOrder.TableName == "PBnet_Orders" || dtOrder.TableName == "PBnet_Orders_Delegates")
        {
            payName = dtOrder.Rows[0]["ReceiverName"].ToString();
            payContact = dtOrder.Rows[0]["ReceiverEmail"].ToString();
            strOrderAmount = dtOrder.Rows[0]["HasNotPayedPrice"].ToString();

            Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
            System.Data.DataTable tbDetail = orderDetailBll.SelectOrderDetailByOrderID(strOrderID).Tables[0];
            //StringBuilder sbDetail = new StringBuilder("");
            //for (int i = 0; i < tbDetail.Rows.Count; i++)
            //{
            //    sbDetail.Append(i + "��" + tbDetail.Rows[i]["pb_SoftName"] + "��");
            //}
            if (dtOrder.TableName == "PBnet_Orders")
            {
                strProductName = "ƴ�������û�����";
                strProductDesc = "ƴ�������û����������ţ�" + strOrderID;
            }
            else
            {
                strProductName = "ƴ�����ߴ����û�����";
                strProductDesc = "ƴ�����ߴ����û������������ţ�" + strOrderID;
            }
            //strProductName += Pbzx.Common.StrFormat.CutStringByNum(sbDetail, 100);
            //strProductDesc += Pbzx.Common.StrFormat.CutStringByNum(sbDetail, 300);
        }
        else if (dtOrder.TableName == "PBnet_Charge")
        {
            payName = dtOrder.Rows[0]["RealName"].ToString();
            payContact = "";
            strOrderAmount = dtOrder.Rows[0]["PayMoney"].ToString();
            strProductName = "ƴ�������û���ֵ��������ֵ��" + Convert.ToDecimal(strOrderAmount).ToString("0.00") + "Ԫ";
            strProductDesc = "ƴ�������û���ֵ�����������ţ�" + strOrderID;
        }

        Pbzx.Common.ErrorLog.WriteLogMeng("���߽���", "��Ǯ�����������أ�������ʼ�������ţ�" + orderId.Value, true, true);

        //֧��������
        ///��Ϊ���Ļ�Ӣ���ַ�
        payerName.Value = payName;

        //֧������ϵ��ʽ����.�̶�ѡ��ֵ
        ///ֻ��ѡ��1
        ///1����Email
        payerContactType.Value = "1";

        //֧������ϵ��ʽ
        ///ֻ��ѡ��Email���ֻ���
        payerContact.Value = payContact;

        //�̻�������
        ///����ĸ�����֡���[-][_]���
        orderId.Value = strOrderID;

        //�������
        ///�Է�Ϊ��λ����������������
        ///�ȷ�2������0.02Ԫ
        orderAmount.Value = Convert.ToInt32(decimal.Parse(strOrderAmount) * 100).ToString();
        //֧����ʽ.�̶�ѡ��ֵ
        ///��ѡ��00��41��42��52
        ///00 �����ǮĬ��֧����ʽ��ĿǰΪ�����п���֧���Ϳ�Ǯ�˻�֧����41 �����Ǯ�˻�֧����42 ���������п���֧���Ϳ�Ǯ�˻�֧����52 ���������п���֧��
        payType.Value = "00";

        //ȫ��֧����־
        ///ֻ��ѡ������ 0 �� 1
        ///0 �����ȫ��֧����ʽ��֧����ɺ󷵻ض������Ϊ�̻��ύ�Ķ��������Ԥ���ѿ����С�ڶ������ʱ������֧�����Ϊʧ�ܣ�Ԥ���ѿ������ڻ���ڶ������ʱ������֧�����Ϊ�ɹ���
        ///1 ����ȫ��֧����ʽ��֧����ɺ󷵻ض������Ϊ�û�Ԥ���ѿ�����ֻҪԤ���ѿ������ɹ�������֧�Ϻ���Ǯ��Ϣ�������޹�˾ ��Ȩ���� �� 6 ҳ�������Ϊ�ɹ���
        fullAmountFlag.Value = "0";

        //�����ύʱ��
        ///14λ���֡���[4λ]��[2λ]��[2λ]ʱ[2λ]��[2λ]��[2λ]
        ///�磻20080101010101
        orderTime.Value = Convert.ToDateTime(dtOrder.Rows[0]["OrderDate"]).ToString("yyyyMMddHHmmss");

        //��Ʒ����
        ///��Ϊ���Ļ�Ӣ���ַ�
        productName.Value = strProductName;


        //��Ʒ����
        ///��Ϊ�գ��ǿ�ʱ����Ϊ����
        productNum.Value = "1";

        //��Ʒ����
        ///��Ϊ�ַ���������
        productId.Value = "";

        //��Ʒ����
        productDesc.Value = strProductDesc;

        //��չ�ֶ�1
        ///��֧��������ԭ�����ظ��̻�
        ext1.Value = "";

        //��չ�ֶ�2
        ///��֧��������ԭ�����ظ��̻�
        ext2.Value = "";






        //�����п��ܺ��������ַ��Ĳ������б���
        payerName.Value = System.Web.HttpUtility.UrlEncode(payerName.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        productName.Value = System.Web.HttpUtility.UrlEncode(productName.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        productDesc.Value = System.Web.HttpUtility.UrlEncode(productDesc.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        ext1.Value = System.Web.HttpUtility.UrlEncode(ext1.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        ext2.Value = System.Web.HttpUtility.UrlEncode(ext2.Value, Encoding.GetEncoding("UTF-8")).ToUpper();



        //���ɼ���ǩ����
        ///����ذ�������˳��͹�����ɼ��ܴ���
        String signMsgVal = "";
        signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset.Value);
        signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl.Value);
        signMsgVal = appendParam(signMsgVal, "pageUrl", pageUrl.Value);
        signMsgVal = appendParam(signMsgVal, "version", version.Value);
        signMsgVal = appendParam(signMsgVal, "language", language.Value);
        signMsgVal = appendParam(signMsgVal, "signType", signType.Value);
        signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId.Value);
        signMsgVal = appendParam(signMsgVal, "payerName", payerName.Value);
        signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType.Value);
        signMsgVal = appendParam(signMsgVal, "payerContact", payerContact.Value);
        signMsgVal = appendParam(signMsgVal, "orderId", orderId.Value);
        signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount.Value);
        signMsgVal = appendParam(signMsgVal, "payType", payType.Value);
        signMsgVal = appendParam(signMsgVal, "fullAmountFlag", fullAmountFlag.Value);
        signMsgVal = appendParam(signMsgVal, "orderTime", orderTime.Value);
        signMsgVal = appendParam(signMsgVal, "productName", productName.Value);
        signMsgVal = appendParam(signMsgVal, "productNum", productNum.Value);
        signMsgVal = appendParam(signMsgVal, "productId", productId.Value);
        signMsgVal = appendParam(signMsgVal, "productDesc", productDesc.Value);
        signMsgVal = appendParam(signMsgVal, "ext1", ext1.Value);
        signMsgVal = appendParam(signMsgVal, "ext2", ext2.Value);
        signMsgVal = appendParam(signMsgVal, "key", key);

        signMsg.Value = GetMD5(signMsgVal, "utf-8").ToUpper();


    }

    //���ܺ�����������ֵ��Ϊ�յĲ�������ַ���
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
    //���ܺ�����������ֵ��Ϊ�յĲ�������ַ���������



    //���ܺ��������ַ������б����ʽת����������MD5���ܣ�Ȼ�󷵻ء���ʼ
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
    //���ܺ��������ַ������б����ʽת����������MD5���ܣ�Ȼ�󷵻ء�����
</script>

<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
<head>
    <title>ʹ�ÿ�Ǯ֧�� - ƴ�����߲���ͨ���</title>
    <meta http-equiv="content-type" content="text/html; charset=gb2312" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc3:Head ID="Head1" runat="server" />
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
        <tr>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12%">
                            <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" /></td>
                        <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                            ���������������Ϣ</td>
                        <td width="1%">
                            <img src="/Images/Web/order_bg1c.jpg" width="10" height="44" border="0" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="10" background="/Images/Web/order_bg2a.jpg">
                &nbsp;</td>
            <td width="970" align="center" bgcolor="#FFFFFF">
                <br />
                <table width="90%" border="0" cellpadding="8" cellspacing="0">
                    <tr>
                        <td class="order_14black" align="center">
                            ���Ķ���<span class="order_14red"><%=strOrderID%></span> �Ѿ��ύ������Ҫ֧����<span class="order_14red"><%=decimal.Parse(strOrderAmount).ToString("0.00")%>Ԫ</span></td>
                    </tr>
                    <tr>
                        <td class="order_14black" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="40%" border="0" align="center" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="/images/web/kuaiqian.jpg" width="111" height="44" alt="" border="0" /></td>
                                    <td align="left">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="0">
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- <input type="submit" name="submit" value="����" id="Submit1" class="order_wangyinbtn" onclick="return Submit1_onclick()" />  -->
                                        <form name="kqPay" method="post" action="https://www.99bill.com/szxgateway/recvMerchantInfoAction.htm">
                                            <input type="hidden" id="inputCharset" name="inputCharset" runat="server" />
                                            <input type="hidden" id="bgUrl" name="bgUrl" runat="server" />
                                            <input type="hidden" id="pageUrl" name="pageUrl" runat="server" />
                                            <input type="hidden" id="version" name="version" runat="server" />
                                            <input type="hidden" id="language" name="language" runat="server" />
                                            <input type="hidden" id="signType" name="signType" runat="server" />
                                            <input type="hidden" id="merchantAcctId" name="merchantAcctId" runat="server" />
                                            <input type="hidden" id="payerName" name="payerName" runat="server" />
                                            <input type="hidden" id="payerContactType" name="payerContactType" runat="server" />
                                            <input type="hidden" id="payerContact" name="payerContact" runat="server" />
                                            <input type="hidden" id="orderId" name="orderId" runat="server" />
                                            <input type="hidden" id="orderAmount" name="orderAmount" runat="server" />
                                            <input type="hidden" id="payType" name="payType" runat="server" />
                                            <input type="hidden" id="fullAmountFlag" name="fullAmountFlag" runat="server" />
                                            <input type="hidden" id="orderTime" name="orderTime" runat="server" />
                                            <input type="hidden" id="productName" name="productName" runat="server" />
                                            <input type="hidden" id="productNum" name="productNum" runat="server" />
                                            <input type="hidden" id="productId" name="productId" runat="server" />
                                            <input type="hidden" id="productDesc" name="productDesc" runat="server" />
                                            <input type="hidden" id="ext1" name="ext1" runat="server" />
                                            <input type="hidden" id="ext2" name="ext2" runat="server" />
                                            <input type="hidden" id="signMsg" name="signMsg" runat="server" />
                                            <input type="submit" id="submit" class="order_kuaiqian" value="" /></form>
                                    </td>
                                </tr>
                            </table>
                            <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="6">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="90%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td width="10" background="/Images/Web/order_bg2c.jpg">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" /></td>
            <td background="/Images/Web/order_bg3b.jpg">
            </td>
            <td>
                <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" /></td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <uc4:Footer ID="Footer1" runat="server" />
</body>
</html>
