using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_PaginAtion 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_PaginAtion
    {
        public PBnet_PaginAtion()
        { }
        #region Model
        private int _paginationid;
        private int? _id;
        private string _filepath;
        private string _physicpath;
        private string _filename;
        private string _suffix;
        private int? _pageno;
        private int? _pagetype;
        /// <summary>
        /// 
        /// </summary>
        public int PaginationID
        {
            set { _paginationid = value; }
            get { return _paginationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhysicPath
        {
            set { _physicpath = value; }
            get { return _physicpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Suffix
        {
            set { _suffix = value; }
            get { return _suffix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PageNo
        {
            set { _pageno = value; }
            get { return _pageno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PageType
        {
            set { _pagetype = value; }
            get { return _pagetype; }
        }
        #endregion Model

    }
}

