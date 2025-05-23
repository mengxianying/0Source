using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_OrderDetail 。(属性说明自动提取数据库字段的描述信息)
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
        /// 是否开通了临时使用权限
        /// </summary>
        public int  TempOpen
        {
            get { return _TempOpen; }
            set { _TempOpen = value; }
        }

        /// <summary>
        /// 订单详细信息编号
        /// </summary>
        public long OrderDetailID
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int? Quatity
        {
            set { _quatity = value; }
            get { return _quatity; }
        }
        /// <summary>
        /// 注册方式
        /// </summary>
        public string RegType
        {
            set { _regtype = value; }
            get { return _regtype; }
        }
        /// <summary>
        /// 注册码
        /// </summary>
        public string Serial
        {
            set { _serial = value; }
            get { return _serial; }
        }
        /// <summary>
        /// 使用时间(用|分割，前半部分1:包月，2:计天，4:一年,7:终身；后半部分对应包月的月数或计天得天数)
        /// </summary>
        public string UseTime
        {
            set { _usetime = value; }
            get { return _usetime; }
        }
        /// <summary>
        /// 状态（0:未处理，1:处理成功，2:处理失败）
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model


	}
}

