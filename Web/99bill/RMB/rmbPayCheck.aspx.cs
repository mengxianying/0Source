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


/*
����webservice��
https://www.99bill.com/apipay/services/gatewayOrderQuery?wsdl  (�Ƽ���)
��http://www.99bill.com/apipay/services/gatewayOrderQuery?wsdl

��Visual Studio 2005��App_WebReferences�ļ������������webservice���ã�������ΪNewPayCheck
*/
using Pbzx.Web.NewPayCheck;



public partial class test_rmbPayCheck : System.Web.UI.Page
{

	//�̻���ѯ�ӿ���Կ
//�̻�����ʹ�ÿ�Ǯ�����֧�����ز�ѯ�ӿڣ���Ҫ���Ǯ�ͻ�������Ա��ϵ�����ͨ���󣬿�Ǯ�Ὣ�̻����ز�ѯ�ӿ���Կ�������̻���Ǯ�˻�����Ӧ�������С�
    private string key = "7STR3KSN4LT44QR7";
	
	
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	
    protected void btnPayCheck_Click(object sender, EventArgs e)
    {
        #region �������󸶿�����
		//�����������
        GatewayOrderQueryRequest orderQueryRequest = new GatewayOrderQueryRequest();
		
		//�ַ���
		//�̶�ֵ��1
		//1����UTF-8 
        orderQueryRequest.inputCharset = "1";
		
		//��ѯ�ӿڰ汾
		//�̶�ֵ��v2.0
		//ע��ΪСд��ĸ
        orderQueryRequest.version = "v2.0";
		
		//ǩ������
		//�̶�ֵ��1
		//1����MD5����ǩ����ʽ
        orderQueryRequest.signType = 1;
		
		//������˺�
		//���ִ�
		//����������ָ�����տ���Ŀ�Ǯ�û���������˺�
        orderQueryRequest.merchantAcctId = ConfigurationManager.AppSettings["RMB_mid"];

		
		//��ѯ��ʽ
		//�̶�ѡ��ֵ��0��1
		//0���̻������ŵ��ʲ�ѯ�����ظö�����Ϣ��
		//1�����׽���ʱ��������ѯ��ֻ���سɹ�������
        orderQueryRequest.queryType = 1;
		
		//��ѯģʽ
		//�̶�ֵ��1
		//1����򵥲�ѯ�����ػ���������Ϣ��
        orderQueryRequest.queryMode = 1;
		
		//���׿�ʼʱ��
		//���ִ���һ��14λ
		//��ʽΪ����[4λ]��[2λ]��[2λ]ʱ[2λ]��[2λ]��[2λ]�����磺20071117020101
        orderQueryRequest.startTime = "20080303000000";
		
		//���׽���ʱ��
		//���ִ���һ��14λ
		//��ʽΪ����[4λ]��[2λ]��[2λ]ʱ[2λ]��[2λ]��[2λ]�����磺20071117020101
        orderQueryRequest.endTime = "20080307182100";
		
		//�����¼��ҳ��
		//���ִ�
		//�ڲ�ѯ������������ܴ�ʱ����Ǯ�Ὣ֧������ֶ�η��ء���������ʾ�̻���Ҫ�õ��ļ�¼��ҳ�롣
		//Ĭ��Ϊ1����ʾ��1ҳ��
        orderQueryRequest.requestPage = "1";
		
		//�̻�������
		//�ַ���
		//ֻ����ʹ����ĸ�����֡�- ��_,������ĸ�����ֿ�ͷ
        orderQueryRequest.orderId = "20080305345727";

		//����ǩ���ַ���
        string tempMac = "inputCharset=" + orderQueryRequest.inputCharset + 
                        "&version=" + orderQueryRequest.version + 
                        "&signType=" + orderQueryRequest.signType + 
                        "&merchantAcctId=" + orderQueryRequest.merchantAcctId +
                        "&queryType=" + orderQueryRequest.queryType +
                        "&queryMode=" + orderQueryRequest.queryMode +
                        "&startTime=" + orderQueryRequest.startTime +
                        "&endTime=" + orderQueryRequest.endTime +
                        "&requestPage=" + orderQueryRequest.requestPage +
                        "&orderId=" + orderQueryRequest.orderId +
                        "&key=" + key;
        orderQueryRequest.signMsg = FormsAuthentication.HashPasswordForStoringInConfigFile(tempMac, "MD5").ToUpper();
		
        #endregion �������󸶿�����



        #region ��ʾ���ύ������
		//��ӡ�ύ������
        this.lblSubmit.Text = "�ύ���ݡ�������" + tempMac;
        #endregion ��ʾ���ύ������



        GatewayOrderQueryService orderQueryService = new GatewayOrderQueryService();
		
		//����gatewayOrderQuery()����
        GatewayOrderQueryResponse orderQueryResponse = orderQueryService.gatewayOrderQuery(orderQueryRequest);



        #region ��֧�����ؽ�����д��������ӡ�������
        //��ӡ֧���������
        if (orderQueryResponse != null)
        {
            string result = "�������ݡ�������";
			
			//���ذ汾
			//�̶�ֵ��v2.0
			//���ύʱ�Ĳ�ѯ�汾�ű���һ��
            result += "version=" + orderQueryResponse.version;
			
			//ǩ������
			//�̶�ֵ��1
			//���ύʱ��ǩ�����ͱ���һ��
            result += "&signType=" + orderQueryResponse.signType;
			
			//������˺�
			//���ִ�
			//���ύʱ�Ŀ�Ǯ�˺ű���һ��
            result += "&merchantAcctId=" + orderQueryResponse.merchantAcctId;
			
			//�������
			//ʧ��ʱ���صĴ�����룬����Ϊ�ա�
			//��ϸ���ϼ����Ĳο����ϡ�
            result += "&errCode=" + orderQueryResponse.errCode;
			
			//��¼����ǰҳ��
			//���ִ�
            result += "&currentPage=" + orderQueryResponse.currentPage;
			
			//��¼����ҳ��
			//���ִ�
            result += "&pageCount=" + orderQueryResponse.pageCount;
			
			//��¼����ҳ����
			//���ִ�
            result += "&pageSize=" + orderQueryResponse.pageSize;
			
			//��¼��������
			//���ִ�
            result += "&recordCount=" + orderQueryResponse.recordCount;
			
			//ǩ���ַ���			
			//�������²�Ϊ�յĲ�������Ӧֵ����������˳�򼰹�������ַ����������ٶ�ȫ����Ϊ�գ�
//version={version}&signTyp={signTyp}&merchantAcctId={merchantAcctId}&errCode={errCode}&currentPage={currentPage}&pageCount={pageCount}&pageSize={pageSize}&recordCount={recordCount}&key={key}
			//Ȼ�����32λ�㷨��MD5���ܺ�ת��Ϊ��д��
            result += "&signMsg=" + orderQueryResponse.signMsg;
			
			
			#region �Է��صĶ������ݽ��д��������ӡ����
			//��ӡ���صĶ�������
            result += "&������Ϣ��";
            if (orderQueryResponse.orders != null && orderQueryResponse.orders.Length > 0)
            {
                for (int i = 0; i < orderQueryResponse.orders.Length; i++)
                {
					//�̻�������
					//��ĸ�����֡�-��_ �������
					//���ύʱ���̻������ű���һ��
                    result += "&orderId[" + i + "]=" + orderQueryResponse.orders[i].orderId;
					
					//�̻��������
					//��������
					//�Է�Ϊ��λ���ȷ�10Ԫ���ύʱ���ӦΪ1000
					//���ύ����ʱ���̻���������һ��
                    result += "&orderAmount[" + i + "]=" + orderQueryResponse.orders[i].orderAmount;
					
					//�̻������ύʱ��
					//���ִ�
					//���ύ����ʱ���̻������ύʱ�䱣��һ��
                    result += "&orderTime[" + i + "]=" + orderQueryResponse.orders[i].orderTime;
					
					//��Ǯ����ʱ��
					//���ִ�
					//��Ǯ���ոñʽ��ײ����д�������ʱ�䡣
					//��ʽΪ����[4λ]��[2λ]��[2λ]ʱ[2λ]��[2λ]��[2λ]�����磺20071117020101
                    result += "&dealTime[" + i + "]=" + orderQueryResponse.orders[i].dealTime;
					
					//������
					//�̶�ѡ��ֵ��10��11��20
					//10��֧���ɹ�
					//ֻ����֧���ɹ��ļ�¼
                    result += "&payResult[" + i + "]=" + orderQueryResponse.orders[i].payResult;
					
					//֧����ʽ
					//�̶�ѡ��ֵ��00��10��11��12��13��14
					//10�����п�֧��
					//11���绰����֧��
					//12����Ǯ������˻�֧��
					//13������֧��
					//14��B2B֧��
                    result += "&payType[" + i + "]=" + orderQueryResponse.orders[i].payType;
					
					//����ʵ��֧�����
					//��������
					//������ʹ���Ż�ȯ��������û�ʵ��֧���Ľ��
					//�Է�Ϊ��λ���ȷ�10Ԫ���ύʱ���ӦΪ1000
                    result += "&payAmount[" + i + "]=" + orderQueryResponse.orders[i].payAmount;
					
					//����
					//���ִ�
					//��Ǯ��ȡ�̻��������ѣ���λΪ�֡�
                    result += "&fee[" + i + "]=" + orderQueryResponse.orders[i].fee;
					
					//��Ǯ���׺�
					//���ִ�
					//�ý����ڿ�Ǯϵͳ�ж�Ӧ�Ľ��׺�
                    result += "&dealId[" + i + "]=" + orderQueryResponse.orders[i].dealId;
					
					//����ǩ���ַ���
					//�Ե���������Ϣ��Ϊ�յĲ�������Ӧֵ����������˳�򼰹�������ַ����������ٶ�ȫ����Ϊ�գ�
//orderId={orderId}&orderAmount={orderAmount}&orderTime={orderTime}&dealTime={dealTime}&payResult={payResult}&payType={payType}&payAmount={payAmount}&fee={fee}&dealId={dealId}&key={key}
					//Ȼ�����32λ�㷨��MD5���ܺ�ת��Ϊ��д��
                    result += "&signInfo[" + i + "]=" + orderQueryResponse.orders[i].signInfo;
                    result += "\n------------------------------------------\n";
                }
			#endregion �Է��صĶ������ݽ��д��������ӡ����
			
            }
            else
            {
                result += "�޶�����¼";
            }

            this.lblPayResult.Text = result;
        }
        #endregion ��֧�����ؽ�����д��������ӡ�������
    }
}
