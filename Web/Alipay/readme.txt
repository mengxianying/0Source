
1.支付宝接口中需要修改参数的文件有 Default.aspx文件;买家付款成功后反馈的页面时 return_url(页面跳转),notify_url(后台通知);AliPay.cs不用修改.  Default.aspx文件中 seller_email,key,partner 对应的分别是支付宝帐号,安全校验码和合作id 
(注：如何获取安全校验码和合作ID
1.访问 www.alipay.com，然后登陆您的帐户.
2.点击右上角的“商家工具”.
3.在网站集成目录下，选择适合您的交易方式，然后点击点此申请.
4.填写好申请表格，点击下一步，您可以看到一段32位的字符串—就是安全校验.
5.合作ID在安全校验码下方.)
 Default.aspx页面,需要传递参数到这个页面,需要传递的参数是 subject(商品名称),body(商品说明),price,out_trade_no(外部商家订单号.为了方便测试,我在Default.aspx这个页面采用的是以日期的形式的数字字符串,这个订单号必须保证提交给支付宝的时候是唯一的,否则支付不了

2.
 return_url  和 notify_url 的区别及其操作.
买家付款成功后,如果接口中指定有return_url ,买家付完款后会跳到 return_url所在的页面,这个页面可以展示给客户看,这个页面只有付款成功才会跳转.

 notify_url: 服务器后台通知,这个页面是程序后台运行的(买家和卖家都看不到),买家付完款后,支付宝会调用notify_url这个页面所在的页面并把相应的参数传递到这个页面,这个页面根据支付宝传递过来的参数修改网站订单的状态,更新完订单后需要在页面上打印出一个success 给支付宝,如果反馈给支付宝的不是success,支付宝会继续调用这个页面. 
 
 流程:  买家付完款(trade_status=WAIT_SELLER_SEND_GOODS or trade_status=TRADE_FINISHED)--->支付宝通知notify_url--->如果反馈给支付宝的是success(表示成功,这个状态下不再反馈,如果不是继续通知,一般第一次发送和第二次发送的时间间隔是3分钟)
 剩下的过程,卖家发货,买家确认收货,交易成功都是这个流程


排除常见错误的方法：
1:错误信息提示为：ILLEGAL_SIGN，属于签名验证出错
CreatUrl的方式参数不一致，编码问题都可以引起这个错误
2:错误信息提示为：ILLEGAL_ARGUMENT，属于参数格式有问题
查看接口发送页的参数是不是符合要求
3：错误信息提示为：ILLEGAL_SERVICE，属于无效接口名称
查看service参数
4：错误信息提示为ILLEGAL_PARTNER，属于无效合作伙伴ID
查看partner参数
5:错误信息提示为ILLEGAL_SIGN_TYPE，属于无效签名方式
sign_type是加密类型，一般为md5
6:错误信息提示为DIRECT_PAY_AMOUNT_OUT_OF_RANGE，属于快速付款交易总金额超出最大值限制
快速付款余额支付最大限制为：2000，用卡没限制
7:错误信息提示为HASH_NO_PRIVILEGE，属于没有权限访问该服务
查看service参数和卖家支付宝帐号所拥有的权限是不是一致
8:错误信息提示为DONATE_GREATER_THAN_MAX，属于小额捐赠总金额超出最大值限制
小额捐赠一般现在为100
9:错误信息提示为OUT_TRADE_NO_EXIST，属于外部交易号已经存在
外部交易号重复
10:错误信息提示为TRADE_NOT_EXIST，属于交易不存在
11:错误信息提示为ILLEGAL_PAYMENT_TYPE，属于无效支付类型
查看有没有PAYMENT_TYPE参数，是不是对的
12:错误信息提示为BUYER_NOT_EXIST，属于买家不存在
查看buyer_email的帐号是不是支付宝帐号
13:错误信息提示为SELLER_NOT_EXIST，属于卖家不存在
seller_email的帐号是不是支付宝帐号
14:错误信息提示为BUYER_SELLER_EQUAL，属于买家、卖家是同一帐户
同一个支付宝帐号不能同为买家和卖家
15:错误信息提示为ILLEGAL_LOGISTICS_FORMAT，属于无效物流格式
只有三种物流类型：EMS，POST，EXPRESS，即为EMS，平邮，其他快递
16:错误信息提示为TOTAL_FEE_LESSEQUAL_ZERO，属于交易总金额小于等于0
price或者total_fee不能小于等于0
17:错误信息提示为TOTAL_FEE_OUT_OF_RANGE，属于交易总金额超出范围
18:错误信息提示为ILLEGAL_FEE_PARAM，属于非法交易金额格式
price或者total_fee的值是否规范