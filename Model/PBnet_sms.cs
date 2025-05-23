using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_sms 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_sms
	{
		public PBnet_sms()
		{}
		#region Model
		private int _id;
		private string _servicename;
		private int? _serviceid;
		private string _serviceclass;
		private string _instruction;
		private string _paytype;
		private string _paymoney;
		private string _sendf;
		private string _serviceintro;
		private string _comid;
		private int? _delfshow;
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
		public string servicename
		{
			set{ _servicename=value;}
			get{return _servicename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? serviceid
		{
			set{ _serviceid=value;}
			get{return _serviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string serviceclass
		{
			set{ _serviceclass=value;}
			get{return _serviceclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string instruction
		{
			set{ _instruction=value;}
			get{return _instruction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string paytype
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string paymoney
		{
			set{ _paymoney=value;}
			get{return _paymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sendf
		{
			set{ _sendf=value;}
			get{return _sendf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string serviceintro
		{
			set{ _serviceintro=value;}
			get{return _serviceintro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comid
		{
			set{ _comid=value;}
			get{return _comid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? delfshow
		{
			set{ _delfshow=value;}
			get{return _delfshow;}
		}
		#endregion Model

	}
}

