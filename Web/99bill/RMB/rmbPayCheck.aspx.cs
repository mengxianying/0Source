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
调用webservice：
https://www.99bill.com/apipay/services/gatewayOrderQuery?wsdl  (推荐！)
或http://www.99bill.com/apipay/services/gatewayOrderQuery?wsdl

在Visual Studio 2005的App_WebReferences文件夹下添加以上webservice引用，并命名为NewPayCheck
*/
using Pbzx.Web.NewPayCheck;



public partial class test_rmbPayCheck : System.Web.UI.Page
{

	//商户查询接口密钥
//商户初次使用快钱人民币支付网关查询接口，需要与快钱客户服务人员联系，审核通过后，快钱会将商户网关查询接口密钥发送至商户快钱账户所对应的邮箱中。
    private string key = "7STR3KSN4LT44QR7";
	
	
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	
    protected void btnPayCheck_Click(object sender, EventArgs e)
    {
        #region 构造请求付款数组
		//生成请求对象
        GatewayOrderQueryRequest orderQueryRequest = new GatewayOrderQueryRequest();
		
		//字符集
		//固定值：1
		//1代表UTF-8 
        orderQueryRequest.inputCharset = "1";
		
		//查询接口版本
		//固定值：v2.0
		//注意为小写字母
        orderQueryRequest.version = "v2.0";
		
		//签名类型
		//固定值：1
		//1代表MD5加密签名方式
        orderQueryRequest.signType = 1;
		
		//人民币账号
		//数字串
		//本参数用来指定接收款项的快钱用户的人民币账号
        orderQueryRequest.merchantAcctId = ConfigurationManager.AppSettings["RMB_mid"];

		
		//查询方式
		//固定选择值：0、1
		//0按商户订单号单笔查询（返回该订单信息）
		//1按交易结束时间批量查询（只返回成功订单）
        orderQueryRequest.queryType = 1;
		
		//查询模式
		//固定值：1
		//1代表简单查询（返回基本订单信息）
        orderQueryRequest.queryMode = 1;
		
		//交易开始时间
		//数字串，一共14位
		//格式为：年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]，例如：20071117020101
        orderQueryRequest.startTime = "20080303000000";
		
		//交易结束时间
		//数字串，一共14位
		//格式为：年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]，例如：20071117020101
        orderQueryRequest.endTime = "20080307182100";
		
		//请求记录集页码
		//数字串
		//在查询结果数据总量很大时，快钱会将支付结果分多次返回。本参数表示商户需要得到的记录集页码。
		//默认为1，表示第1页。
        orderQueryRequest.requestPage = "1";
		
		//商户订单号
		//字符串
		//只允许使用字母、数字、- 、_,并以字母或数字开头
        orderQueryRequest.orderId = "20080305345727";

		//构造签名字符串
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
		
        #endregion 构造请求付款数组



        #region 显示所提交的数据
		//打印提交的数据
        this.lblSubmit.Text = "提交数据————" + tempMac;
        #endregion 显示所提交的数据



        GatewayOrderQueryService orderQueryService = new GatewayOrderQueryService();
		
		//调用gatewayOrderQuery()方法
        GatewayOrderQueryResponse orderQueryResponse = orderQueryService.gatewayOrderQuery(orderQueryRequest);



        #region 对支付返回结果进行处理：例如打印结果数据
        //打印支付结果数据
        if (orderQueryResponse != null)
        {
            string result = "接收数据————";
			
			//网关版本
			//固定值：v2.0
			//与提交时的查询版本号保持一致
            result += "version=" + orderQueryResponse.version;
			
			//签名类型
			//固定值：1
			//与提交时的签名类型保持一致
            result += "&signType=" + orderQueryResponse.signType;
			
			//人民币账号
			//数字串
			//与提交时的快钱账号保持一致
            result += "&merchantAcctId=" + orderQueryResponse.merchantAcctId;
			
			//错误代码
			//失败时返回的错误代码，可以为空。
			//详细资料见下文参考资料。
            result += "&errCode=" + orderQueryResponse.errCode;
			
			//记录集当前页码
			//数字串
            result += "&currentPage=" + orderQueryResponse.currentPage;
			
			//记录集总页码
			//数字串
            result += "&pageCount=" + orderQueryResponse.pageCount;
			
			//记录集当页条数
			//数字串
            result += "&pageSize=" + orderQueryResponse.pageSize;
			
			//记录集总条数
			//数字串
            result += "&recordCount=" + orderQueryResponse.recordCount;
			
			//签名字符串			
			//对于以下不为空的参数及对应值，按照如下顺序及规则组成字符串（本例假定全部不为空）
//version={version}&signTyp={signTyp}&merchantAcctId={merchantAcctId}&errCode={errCode}&currentPage={currentPage}&pageCount={pageCount}&pageSize={pageSize}&recordCount={recordCount}&key={key}
			//然后进行32位算法的MD5加密后，转化为大写。
            result += "&signMsg=" + orderQueryResponse.signMsg;
			
			
			#region 对返回的订单数据进行处理：例如打印出来
			//打印返回的订单数据
            result += "&订单信息：";
            if (orderQueryResponse.orders != null && orderQueryResponse.orders.Length > 0)
            {
                for (int i = 0; i < orderQueryResponse.orders.Length; i++)
                {
					//商户订单号
					//字母、数字、-、_ 及其组合
					//与提交时的商户订单号保持一致
                    result += "&orderId[" + i + "]=" + orderQueryResponse.orders[i].orderId;
					
					//商户订单金额
					//整型数字
					//以分为单位。比方10元，提交时金额应为1000
					//与提交订单时的商户订单金额保持一致
                    result += "&orderAmount[" + i + "]=" + orderQueryResponse.orders[i].orderAmount;
					
					//商户订单提交时间
					//数字串
					//与提交订单时的商户订单提交时间保持一致
                    result += "&orderTime[" + i + "]=" + orderQueryResponse.orders[i].orderTime;
					
					//快钱交易时间
					//数字串
					//快钱接收该笔交易并进行处理的最后时间。
					//格式为：年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]，例如：20071117020101
                    result += "&dealTime[" + i + "]=" + orderQueryResponse.orders[i].dealTime;
					
					//处理结果
					//固定选择值：10、11、20
					//10：支付成功
					//只返回支付成功的记录
                    result += "&payResult[" + i + "]=" + orderQueryResponse.orders[i].payResult;
					
					//支付方式
					//固定选择值：00、10、11、12、13、14
					//10：银行卡支付
					//11：电话银行支付
					//12：快钱人民币账户支付
					//13：线下支付
					//14：B2B支付
                    result += "&payType[" + i + "]=" + orderQueryResponse.orders[i].payType;
					
					//订单实际支付金额
					//整型数字
					//返回在使用优惠券等情况后，用户实际支付的金额
					//以分为单位。比方10元，提交时金额应为1000
                    result += "&payAmount[" + i + "]=" + orderQueryResponse.orders[i].payAmount;
					
					//费用
					//数字串
					//快钱收取商户的手续费，单位为分。
                    result += "&fee[" + i + "]=" + orderQueryResponse.orders[i].fee;
					
					//快钱交易号
					//数字串
					//该交易在快钱系统中对应的交易号
                    result += "&dealId[" + i + "]=" + orderQueryResponse.orders[i].dealId;
					
					//订单签名字符串
					//对单个订单信息不为空的参数及对应值，按照如下顺序及规则组成字符串（本例假定全部不为空）
//orderId={orderId}&orderAmount={orderAmount}&orderTime={orderTime}&dealTime={dealTime}&payResult={payResult}&payType={payType}&payAmount={payAmount}&fee={fee}&dealId={dealId}&key={key}
					//然后进行32位算法的MD5加密后，转化为大写。
                    result += "&signInfo[" + i + "]=" + orderQueryResponse.orders[i].signInfo;
                    result += "\n------------------------------------------\n";
                }
			#endregion 对返回的订单数据进行处理：例如打印出来
			
            }
            else
            {
                result += "无订单记录";
            }

            this.lblPayResult.Text = result;
        }
        #endregion 对支付返回结果进行处理：例如打印结果数据
    }
}
