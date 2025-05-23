using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_PayType 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_PayType
    {
        public PBnet_PayType()
        { }
        #region Model
        private int _paytypeid;
        private string _paytypename;
        private int _payvalue;
        private int? _orderid;
        private string _url;
        private int? _ftypeid;
        private bool _display;
        private string _selectaddress;
        /// <summary>
        /// 付款方式编号
        /// </summary>
        public int PayTypeID
        {
            set { _paytypeid = value; }
            get { return _paytypeid; }
        }
        /// <summary>
        /// 付款方式名称
        /// </summary>
        public string PayTypeName
        {
            set { _paytypename = value; }
            get { return _paytypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PayValue
        {
            set { _payvalue = value; }
            get { return _payvalue; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 网址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 父类别编号
        /// </summary>
        public int? FTypeID
        {
            set { _ftypeid = value; }
            get { return _ftypeid; }
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Display
        {
            set { _display = value; }
            get { return _display; }
        }
        /// <summary>
        /// 查询地址
        /// </summary>
        public string SelectAddress
        {
            set { _selectaddress = value; }
            get { return _selectaddress; }
        }
        #endregion Model

        private string _linkurl;
        /// <summary>
        /// 链接查询地址
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }

    }
}

