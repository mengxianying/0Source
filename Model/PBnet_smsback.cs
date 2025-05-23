using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_smsback 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_smsback
	{
		public PBnet_smsback()
		{}
		#region Model
		private int _id;
		private int? _pbactionid;
		private int? _pbresultid;
		private string _pbrestring;
		private int? _pbserviceid;
		private string _pbmobileid;
		private string _pbpassword;
		private string _vsurl;
		private DateTime? _vstime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pbactionid
		{
			set{ _pbactionid=value;}
			get{return _pbactionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pbresultid
		{
			set{ _pbresultid=value;}
			get{return _pbresultid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pbrestring
		{
			set{ _pbrestring=value;}
			get{return _pbrestring;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pbserviceid
		{
			set{ _pbserviceid=value;}
			get{return _pbserviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pbmobileid
		{
			set{ _pbmobileid=value;}
			get{return _pbmobileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pbpassword
		{
			set{ _pbpassword=value;}
			get{return _pbpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vsurl
		{
			set{ _vsurl=value;}
			get{return _vsurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? vstime
		{
			set{ _vstime=value;}
			get{return _vstime;}
		}
		#endregion Model

	}
}

