using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_OrderDetail_Delegate ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_OrderDetail_Delegate
    {
        public PBnet_OrderDetail_Delegate()
        {
            _orderid = "";
            _productid = 0;
            _quatity = 0;
            _regtype = "";
            _serial = "";
            _usetime = "|";
        }
        #region Model
        private long _orderdetailid;
        private string _orderid;
        private int? _productid;
        private int? _quatity;
        private string _regtype;
        private string _serial;
        private string _usetime;
        /// <summary>
        /// 
        /// </summary>
        public long OrderDetailID
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Quatity
        {
            set { _quatity = value; }
            get { return _quatity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegType
        {
            set { _regtype = value; }
            get { return _regtype; }
        }
        /// <summary>
        /// ���к�
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
        #endregion Model




    }
}

