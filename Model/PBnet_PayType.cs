using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_PayType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���ʽ���
        /// </summary>
        public int PayTypeID
        {
            set { _paytypeid = value; }
            get { return _paytypeid; }
        }
        /// <summary>
        /// ���ʽ����
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
        /// ������
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int? FTypeID
        {
            set { _ftypeid = value; }
            get { return _ftypeid; }
        }
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public bool Display
        {
            set { _display = value; }
            get { return _display; }
        }
        /// <summary>
        /// ��ѯ��ַ
        /// </summary>
        public string SelectAddress
        {
            set { _selectaddress = value; }
            get { return _selectaddress; }
        }
        #endregion Model

        private string _linkurl;
        /// <summary>
        /// ���Ӳ�ѯ��ַ
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }

    }
}

