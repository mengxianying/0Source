using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_UserTradeInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PBnet_UserTradeInfo
	{
		public PBnet_UserTradeInfo()
		{}
	
        		#region Model
		private int _id;
		private string _username;
		private decimal? _trademoney;
		private DateTime? _tradetime;
		private int _tradetype;
		private string _bankname;
		private string _accountnumber;
		private string _account_username;
		private string _operatemanager;
		private decimal? _currentmoney;
		private string _foreignkey_id;
		private string _remark;
		/// <summary>
		/// 索引ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// BBS用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 交易金额
		/// </summary>
		public decimal? TradeMoney
		{
			set{ _trademoney=value;}
			get{return _trademoney;}
		}
		/// <summary>
		/// 交易时间
		/// </summary>
		public DateTime? TradeTime
		{
			set{ _tradetime=value;}
			get{return _tradetime;}
		}
        
        /// <summary>
        /// 交易类型：（百位对于我们来说，十位对于用户来说，1-4为收入，5-9为支出，个位为区分位）
        ///111：网银转入|网银充值（收入）
        ///112：现金转入（含邮政汇款）|现金充值（收入）
        ///113：手工转入（给用户充值）|手工充值（收入）
        /// 
        ///151：普通购买|普通购买（支出）
        ///152：代理购买|代理购买（支出）
        ///153：经纪人活动购买| 经纪人活动购买（支出）
        ///20-29：合买平台的投注支付（这些做具体平台时再确定）
        /// 
        ///551：提现（网银转出）|网银提现（支出）
        ///552：提现（现金支付）|现金提现（支出）
        ///553 手工转出（给用户扣款）|手工扣款（支出）
        ///511：经纪人推荐收入|经纪人推荐收入（收入）
        ///512：登录用户返点|登录用户返点（收入）
        ///120-129：合买平台的中奖收入转入（这些做具体平台时再确定）
        /// </summary>
		public int TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
		/// 开户行
		/// </summary>
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string AccountNumber
		{
			set{ _accountnumber=value;}
			get{return _accountnumber;}
		}
		/// <summary>
		/// 帐户姓名
		/// </summary>
		public string Account_UserName
		{
			set{ _account_username=value;}
			get{return _account_username;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperateManager
		{
			set{ _operatemanager=value;}
			get{return _operatemanager;}
		}
		/// <summary>
		/// 帐户余额（操作后的，便于对帐）
		/// </summary>
		public decimal? CurrentMoney
		{
			set{ _currentmoney=value;}
			get{return _currentmoney;}
		}
		/// <summary>
		/// 对应表的索引ID号（比如购买软件，则是软件购买申请表的ID号，如果是合买投注，则是投注信息表的ID号，便于查询资金用途）
		/// </summary>
		public string ForeignKey_id
		{
			set{ _foreignkey_id=value;}
			get{return _foreignkey_id;}
		}

		/// <summary>
		/// 备注信息
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}


