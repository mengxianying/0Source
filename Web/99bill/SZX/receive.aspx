<script language="C#" runat="server">
    /*
 * @Description: ��Ǯ������֧�����ؽӿڷ���
 * @Copyright (c) �Ϻ���Ǯ��Ϣ�������޹�˾
 * @version 2.0
 */

    //��ʼ���������ַ
    int rtnOk = 0;
    String rtnUrl = "";

    void Page_Load(Object sender, EventArgs E)
    {

        //��ȡ�����������˻���
        String merchantAcctId = ConfigurationManager.AppSettings["RMB_mid"];

        //����������������Կ
        ///���ִ�Сд
        String key = ConfigurationManager.AppSettings["SZX_key"];


        //��ȡ���ذ汾.�̶�ֵ
        ///������汾�Ź̶�Ϊv2.0
        String version = Request["version"].ToString().Trim();

        //��ȡ��������.�̶�ѡ��ֵ��
        ///ֻ��ѡ��1��2
        ///1�������ģ�2����Ӣ��
        String language = Request["language"].ToString().Trim();

        //��ȡ֧����ʽ
        ///��ѡ��00��41��42��52
        ///00 �����ǮĬ��֧����ʽ��ĿǰΪ�����п���֧���Ϳ�Ǯ�˻�֧����41 �����Ǯ�˻�֧����42 ���������п���֧���Ϳ�Ǯ�˻�֧����52 ���������п���֧��
        String payType = Request["payType"].ToString().Trim();

        //�����п����
        ///���ͨ�������п�ֱ��֧��ʱ����
        String cardNumber = Request["cardNumber"].ToString().Trim();

        //��ȡ�����п�����
        ///���ͨ�������п�ֱ��֧��ʱ����
        String cardPwd = Request["cardPwd"].ToString().Trim();

        //��ȡ�̻�������
        String orderId = Request["orderId"].ToString().Trim();


        //��ȡԭʼ�������
        ///�����ύ����Ǯʱ�Ľ���λΪ�֡�
        ///�ȷ�2 ������0.02Ԫ
        String orderAmount = Request["orderAmount"].ToString().Trim();

        //��ȡ��Ǯ���׺�
        ///��ȡ�ý����ڿ�Ǯ�Ľ��׺�
        String dealId = Request["dealId"].ToString().Trim();


        //��ȡ�̻��ύ����ʱ��ʱ��
        ///14λ���֡���[4λ]��[2λ]��[2λ]ʱ[2λ]��[2λ]��[2λ]
        ///�磺20080101010101
        String orderTime = Request["orderTime"].ToString().Trim();

        //��ȡ��չ�ֶ�1
        ///���̻��ύ����ʱ����չ�ֶ�1����һ��
        String ext1 = Request["ext1"].ToString().Trim();

        //��ȡ��չ�ֶ�2
        ///���̻��ύ����ʱ����չ�ֶ�2����һ��
        String ext2 = Request["ext2"].ToString().Trim();

        //��ȡʵ��֧�����
        ///��λΪ��
        ///�ȷ� 2 ������0.02Ԫ
        String payAmount = Request["payAmount"].ToString().Trim();

        //��ȡ��Ǯ����ʱ��
        String billOrderTime = Request["billOrderTime"].ToString().Trim();

        //��ȡ������
        ///10����֧���ɹ��� 11����֧��ʧ��
        String payResult = Request["payResult"].ToString().Trim();

        //��ȡǩ������
        ///1����MD5ǩ��
        ///��ǰ�汾�̶�Ϊ1
        String signType = Request["signType"].ToString().Trim();

        //��ȡ����ǩ����
        String signMsg = Request["signMsg"].ToString().Trim();




        //���ɼ��ܴ������뱣������˳��
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



        //�̼ҽ������ݴ�������ת���̼���ʾ֧�������ҳ��
        ///���Ƚ���ǩ���ַ�����֤
        if (signMsg.ToUpper() == merchantSignMsg.ToUpper())
        {

            switch (payResult)
            {

                case "10":
                    /*  
                     // �̻���վ�߼������ȷ����¶���֧��״̬Ϊ�ɹ�
                    // �ر�ע�⣺ֻ��signMsg.ToUpper() == merchantSignMsg.ToUpper()����payResult=10���ű�ʾ֧���ɹ���
                    */

                    //�������Ǯ�����������ṩ��Ҫ�ض���ĵ�ַ��
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
                    Pbzx.Web.WebFunc.UpdateOrder(orderId, true, Convert.ToString(Convert.ToDecimal(orderAmount) / 100), "99bill@pinble.com", "���Զ���", 15, "��Ǯ֧��");
                    rtnUrl = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/show.aspx?msg=success";
                    Pbzx.Common.ErrorLog.WriteLogMeng("���߽���", "��Ǯ�����������أ�������̨֪ͨҳ�������ţ�" + orderId + "\r\n��������׳ɹ�", true, true);
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
            Pbzx.Common.ErrorLog.WriteLogMeng("���߽���", "��Ǯ�����������أ�������̨֪ͨҳ�������ţ�" + orderId + "\r\n�ͻ���У���룺" + signMsg + "\r\n������У���룺" + merchantSignMsg + "\r\n�����У��ʧ�ܣ����ݿ���", true, true);

            string Name = Pbzx.Common.Method.Get_UserName;
            if (Name == "0")
            {
                Name = "�ο�";
            }
            Pbzx.Common.Method.record_user_log(Name, "У��ʧ�ܣ����ݿ���", "���ݿ���", "���⹥��");
        }


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

    //���±������Ǯ�����������ṩ��Ҫ�ض���ĵ�ַ
</script>

<result><%=rtnOk %></result>
<redirecturl><%=rtnUrl %></redirecturl>
