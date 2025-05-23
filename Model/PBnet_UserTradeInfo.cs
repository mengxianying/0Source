using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_UserTradeInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// BBS�û���
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ���׽��
		/// </summary>
		public decimal? TradeMoney
		{
			set{ _trademoney=value;}
			get{return _trademoney;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? TradeTime
		{
			set{ _tradetime=value;}
			get{return _tradetime;}
		}
        
        /// <summary>
        /// �������ͣ�����λ����������˵��ʮλ�����û���˵��1-4Ϊ���룬5-9Ϊ֧������λΪ����λ��
        ///111������ת��|������ֵ�����룩
        ///112���ֽ�ת�루��������|�ֽ��ֵ�����룩
        ///113���ֹ�ת�루���û���ֵ��|�ֹ���ֵ�����룩
        /// 
        ///151����ͨ����|��ͨ����֧����
        ///152��������|������֧����
        ///153�������˻����| �����˻����֧����
        ///20-29������ƽ̨��Ͷע֧������Щ������ƽ̨ʱ��ȷ����
        /// 
        ///551�����֣�����ת����|�������֣�֧����
        ///552�����֣��ֽ�֧����|�ֽ����֣�֧����
        ///553 �ֹ�ת�������û��ۿ|�ֹ��ۿ֧����
        ///511���������Ƽ�����|�������Ƽ����루���룩
        ///512����¼�û�����|��¼�û����㣨���룩
        ///120-129������ƽ̨���н�����ת�루��Щ������ƽ̨ʱ��ȷ����
        /// </summary>
		public int TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// �˺�
		/// </summary>
		public string AccountNumber
		{
			set{ _accountnumber=value;}
			get{return _accountnumber;}
		}
		/// <summary>
		/// �ʻ�����
		/// </summary>
		public string Account_UserName
		{
			set{ _account_username=value;}
			get{return _account_username;}
		}
		/// <summary>
		/// ����Ա
		/// </summary>
		public string OperateManager
		{
			set{ _operatemanager=value;}
			get{return _operatemanager;}
		}
		/// <summary>
		/// �ʻ���������ģ����ڶ��ʣ�
		/// </summary>
		public decimal? CurrentMoney
		{
			set{ _currentmoney=value;}
			get{return _currentmoney;}
		}
		/// <summary>
		/// ��Ӧ�������ID�ţ����繺������������������������ID�ţ�����Ǻ���Ͷע������Ͷע��Ϣ���ID�ţ����ڲ�ѯ�ʽ���;��
		/// </summary>
		public string ForeignKey_id
		{
			set{ _foreignkey_id=value;}
			get{return _foreignkey_id;}
		}

		/// <summary>
		/// ��ע��Ϣ
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}


