using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_UrlMaping 。(属性说明自动提取数据库字段的描述信息)
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
        /// 类别编号
        /// </summary>
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        /// <summary>
        /// 映射编号
        /// </summary>
        public int MapID
        {
            set { _mapid = value; }
            get { return _mapid; }
        }
        /// <summary>
        /// 父类别编号
        /// </summary>
        public int? FID
        {
            set { _fid = value; }
            get { return _fid; }
        }
        /// <summary>
        /// 最终html页面地址
        /// </summary>
        public string Html
        {
            set { _html = value; }
            get { return _html; }
        }
        /// <summary>
        /// aspx页面地址
        /// </summary>
        public string Aspx
        {
            set { _aspx = value; }
            get { return _aspx; }
        }
        /// <summary>
        /// 类别种类编号
        /// </summary>
        public int? Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 页面名称
        /// </summary>
        public string PageName
        {
            set { _pagename = value; }
            get { return _pagename; }
        }
        /// <summary>
        /// 在本层级内排序编号
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 根类别
        /// </summary>
        public int? RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        #endregion Model

    }
}

