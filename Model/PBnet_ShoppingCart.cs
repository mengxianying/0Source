using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_ShoppingCart ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class PBnet_ShoppingCart
	{
		public PBnet_ShoppingCart()
		{
            _regtype = "";
            _usetime = "|";
            _dataadded = DateTime.Now;
        }
        #region Model
        private long _cartid;
        private string _cartguid;
        private int? _productid;
        private string _regtype;
        private int? _quatity;
        private DateTime? _dataadded;
        private string _usetime;
        /// <summary>
        /// ���ﳵID
        /// </summary>
        public long CartID
        {
            set { _cartid = value; }
            get { return _cartid; }
        }
        /// <summary>
        /// ���ﳵΨһ��ʾ
        /// </summary>
        public string CartGuid
        {
            set { _cartguid = value; }
            get { return _cartguid; }
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
        /// 
        /// </summary>
        public string RegType
        {
            set { _regtype = value; }
            get { return _regtype; }
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
        /// ����ʱ��
        /// </summary>
        public DateTime? DataAdded
        {
            set { _dataadded = value; }
            get { return _dataadded; }
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

