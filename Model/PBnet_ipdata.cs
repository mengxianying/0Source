using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_ipdata ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// IP��ַһ
		/// </summary>
		public decimal ip1
		{
			set{ _ip1=value;}
			get{return _ip1;}
		}
		/// <summary>
		/// IP��ַ2
		/// </summary>
		public decimal ip2
		{
			set{ _ip2=value;}
			get{return _ip2;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		#endregion Model

	}
}

