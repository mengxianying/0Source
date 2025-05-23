using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_ShoppingCart 。(属性说明自动提取数据库字段的描述信息)
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
        /// 购物车ID
        /// </summary>
        public long CartID
        {
            set { _cartid = value; }
            get { return _cartid; }
        }
        /// <summary>
        /// 购物车唯一标示
        /// </summary>
        public string CartGuid
        {
            set { _cartguid = value; }
            get { return _cartguid; }
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
        /// 
        /// </summary>
        public string RegType
        {
            set { _regtype = value; }
            get { return _regtype; }
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
        /// 生成时间
        /// </summary>
        public DateTime? DataAdded
        {
            set { _dataadded = value; }
            get { return _dataadded; }
        }
        /// <summary>
        /// 使用时间(用|分割，前半部分1:包月，2:计天，4:一年,7:终身；后半部分对应包月的月数或计天得天数)
        /// </summary>
        public string UseTime
        {
            set { _usetime = value; }
            get { return _usetime; }
        }
        #endregion Model

	}
}

