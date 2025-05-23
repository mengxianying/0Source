using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_Order_OrderStatic ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �������
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// ״̬���
		/// </summary>
		public int StaticID
		{
			set{ _staticid=value;}
			get{return _staticid;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? AddedDate
		{
			set{ _addeddate=value;}
			get{return _addeddate;}
		}
		/// <summary>
		/// �Ƿ����
		/// </summary>
		public bool YesOrNo
		{
			set{ _yesorno=value;}
			get{return _yesorno;}
		}
		#endregion Model

	}
}

