using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_Order_OrderStatic 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PBnet_Order_OrderStatic
	{
		public PBnet_Order_OrderStatic()
		{}
		#region Model
		private string _orderid;
		private int _staticid;
		private DateTime? _addeddate;
		private bool _yesorno;
		/// <summary>
		/// 订单编号
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 状态编号
		/// </summary>
		public int StaticID
		{
			set{ _staticid=value;}
			get{return _staticid;}
		}
		/// <summary>
		/// 生成时间
		/// </summary>
		public DateTime? AddedDate
		{
			set{ _addeddate=value;}
			get{return _addeddate;}
		}
		/// <summary>
		/// 是否过期
		/// </summary>
		public bool YesOrNo
		{
			set{ _yesorno=value;}
			get{return _yesorno;}
		}
		#endregion Model

	}
}

