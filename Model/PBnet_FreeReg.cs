using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_FreeReg 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_FreeReg
	{
		public PBnet_FreeReg()
		{}
		#region Model
		private int _intfrid;
		private string _rn;
		private string _hdsn;
		private int _status;
		private int _softwaretype;
		private int _installtype;
		private DateTime? _requesttime;
		private DateTime? _registertime;
		private string _username;
		private string _usertel;
		private string _useremail;
		private string _useraddress;
		private string _bbsid;
		private bool _nameerror;
		private bool _addresserror;
		private string _errorinfo;
		private string _remarks;
		private int? _querycount;
		private DateTime? _querytime;
		private string _queryip;
		/// <summary>
		/// 
		/// </summary>
		public int intFrID
		{
			set{ _intfrid=value;}
			get{return _intfrid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RN
		{
			set{ _rn=value;}
			get{return _rn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HDSN
		{
			set{ _hdsn=value;}
			get{return _hdsn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SoftwareType
		{
			set{ _softwaretype=value;}
			get{return _softwaretype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int InstallType
		{
			set{ _installtype=value;}
			get{return _installtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RequestTime
		{
			set{ _requesttime=value;}
			get{return _requesttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegisterTime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserTel
		{
			set{ _usertel=value;}
			get{return _usertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserAddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BbsID
		{
			set{ _bbsid=value;}
			get{return _bbsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool NameError
		{
			set{ _nameerror=value;}
			get{return _nameerror;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AddressError
		{
			set{ _addresserror=value;}
			get{return _addresserror;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrorInfo
		{
			set{ _errorinfo=value;}
			get{return _errorinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QueryCount
		{
			set{ _querycount=value;}
			get{return _querycount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? QueryTime
		{
			set{ _querytime=value;}
			get{return _querytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QueryIP
		{
			set{ _queryip=value;}
			get{return _queryip;}
		}
		#endregion Model

	}
}

