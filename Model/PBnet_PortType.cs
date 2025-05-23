using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_PortType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PBnet_PortType
	{
		public PBnet_PortType()
		{}
		#region Model
		private int _porttypeid;
		private string _porttypename;
		private decimal? _portprice;
		/// <summary>
		/// 邮递方式编号
		/// </summary>
		public int PortTypeID
		{
			set{ _porttypeid=value;}
			get{return _porttypeid;}
		}
		/// <summary>
		/// 邮递方式名
		/// </summary>
		public string PortTypeName
		{
			set{ _porttypename=value;}
			get{return _porttypename;}
		}
		/// <summary>
		/// 邮递价格
		/// </summary>
		public decimal? PortPrice
		{
			set{ _portprice=value;}
			get{return _portprice;}
		}
		#endregion Model

	}
}

