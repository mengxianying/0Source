using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_UrlMaping ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_UrlMaping
    {
        public PBnet_UrlMaping()
        { }
        #region Model
        private int _mapid;
        private int? _fid;
        private string _html;
        private string _aspx;
        private int? _depth;
        private string _pagename;
        private int? _orderid;
        private int? _rootid;
        private int _typeID;

        /// <summary>
        /// �����
        /// </summary>
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        /// <summary>
        /// ӳ����
        /// </summary>
        public int MapID
        {
            set { _mapid = value; }
            get { return _mapid; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int? FID
        {
            set { _fid = value; }
            get { return _fid; }
        }
        /// <summary>
        /// ����htmlҳ���ַ
        /// </summary>
        public string Html
        {
            set { _html = value; }
            get { return _html; }
        }
        /// <summary>
        /// aspxҳ���ַ
        /// </summary>
        public string Aspx
        {
            set { _aspx = value; }
            get { return _aspx; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public int? Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// ҳ������
        /// </summary>
        public string PageName
        {
            set { _pagename = value; }
            get { return _pagename; }
        }
        /// <summary>
        /// �ڱ��㼶��������
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int? RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        #endregion Model

    }
}

