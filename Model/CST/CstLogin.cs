using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类CstLogin 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CstLogin
	{
		public CstLogin()
		{}
		#region Model
		private int _id;
		private string _hdsn;
		private string _rn;
		private int _softwaretype;
		private int _installtype;
		private string _version;
		private string _osversion;
		private DateTime? _logintime;
		private string _ip;
		private int? _logincount;
		private int? _totalcount;
		private DateTime? _firstlogintime;
		private DateTime _agintime;
		private int? _status;
		private int? _hdsntype;
		private DateTime? _expiredate;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public string RN
		{
			set{ _rn=value;}
			get{return _rn;}
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
		public string Version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OSVersion
		{
			set{ _osversion=value;}
			get{return _osversion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LoginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TotalCount
		{
			set{ _totalcount=value;}
			get{return _totalcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FirstLoginTime
		{
			set{ _firstlogintime=value;}
			get{return _firstlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AginTime
		{
			set{ _agintime=value;}
			get{return _agintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HDSNType
		{
			set{ _hdsntype=value;}
			get{return _hdsntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpireDate
		{
			set{ _expiredate=value;}
			get{return _expiredate;}
		}
		#endregion Model

	}
}

