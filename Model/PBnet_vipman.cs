using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_vipman 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_vipman
	{
		public PBnet_vipman()
		{}
		#region Model
		private int _master_id;
		private string _master_name;
		private string _master_password;
		private string _column_setting;
		private string _setting;
		private DateTime? _lastime;
		private string _lastip;
		private string _cookiess;
		private bool _state;
		/// <summary>
		/// 
		/// </summary>
		public int Master_Id
		{
			set{ _master_id=value;}
			get{return _master_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Master_Name
		{
			set{ _master_name=value;}
			get{return _master_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Master_Password
		{
			set{ _master_password=value;}
			get{return _master_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Column_Setting
		{
			set{ _column_setting=value;}
			get{return _column_setting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Setting
		{
			set{ _setting=value;}
			get{return _setting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LasTime
		{
			set{ _lastime=value;}
			get{return _lastime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastIP
		{
			set{ _lastip=value;}
			get{return _lastip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cookiess
		{
			set{ _cookiess=value;}
			get{return _cookiess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

