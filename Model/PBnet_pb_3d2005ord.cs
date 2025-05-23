using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_pb_3d2005ord 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_pb_3d2005ord
	{
		public PBnet_pb_3d2005ord()
		{}
		#region Model
		private long _id;
		private string _username;
		private string _usertel;
		private string _usermail;
		private string _useraddress;
		private string _ordfrom;
		private int? _ordfromnum;
		private DateTime? _orddate;
		private bool _state;
		private string _userip;
		private DateTime? _usedate;
		private string _userlog;
		/// <summary>
		/// 
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usertel
		{
			set{ _usertel=value;}
			get{return _usertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usermail
		{
			set{ _usermail=value;}
			get{return _usermail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useraddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ordfrom
		{
			set{ _ordfrom=value;}
			get{return _ordfrom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ordfromnum
		{
			set{ _ordfromnum=value;}
			get{return _ordfromnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? orddate
		{
			set{ _orddate=value;}
			get{return _orddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userip
		{
			set{ _userip=value;}
			get{return _userip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? usedate
		{
			set{ _usedate=value;}
			get{return _usedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userlog
		{
			set{ _userlog=value;}
			get{return _userlog;}
		}
		#endregion Model

	}
}

