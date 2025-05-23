using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_ipdata 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_ipdata
	{
		public PBnet_ipdata()
		{}
		#region Model
		private decimal _ip1;
		private decimal _ip2;
		private string _country;
		private string _city;
		/// <summary>
		/// IP地址一
		/// </summary>
		public decimal ip1
		{
			set{ _ip1=value;}
			get{return _ip1;}
		}
		/// <summary>
		/// IP地址2
		/// </summary>
		public decimal ip2
		{
			set{ _ip2=value;}
			get{return _ip2;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 城市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		#endregion Model

	}
}

