using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_OrderDetail ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class PBnet_OrderDetail
	{
		public PBnet_OrderDetail()
		{
            _orderid = "";
            _productid = 0;
            _quatity = 0;
            _regtype = "";
            _serial = "";
            _usetime = "|";
            _state = 0;
            _TempOpen = 0;
        }
        #region Model
        private long _orderdetailid;
        private string _orderid;
        private int? _productid;
        private int? _quatity;
        private string _regtype;
        private string _serial;
        private string _usetime;
        private int? _state;

        private int _TempOpen;
        /// <summary>
        /// �Ƿ�ͨ����ʱʹ��Ȩ��
        /// </summary>
        public int  TempOpen
        {
            get { return _TempOpen; }
            set { _TempOpen = value; }
        }

        /// <summary>
        /// ������ϸ��Ϣ���
        /// </summary>
        public long OrderDetailID
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public int? Quatity
        {
            set { _quatity = value; }
            get { return _quatity; }
        }
        /// <summary>
        /// ע�᷽ʽ
        /// </summary>
        public string RegType
        {
            set { _regtype = value; }
            get { return _regtype; }
        }
        /// <summary>
        /// ע����
        /// </summary>
        public string Serial
        {
            set { _serial = value; }
            get { return _serial; }
        }
        /// <summary>
        /// ʹ��ʱ��(��|�ָǰ�벿��1:���£�2:���죬4:һ��,7:������벿�ֶ�Ӧ���µ���������������)
        /// </summary>
        public string UseTime
        {
            set { _usetime = value; }
            get { return _usetime; }
        }
        /// <summary>
        /// ״̬��0:δ����1:����ɹ���2:����ʧ�ܣ�
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model


	}
}

