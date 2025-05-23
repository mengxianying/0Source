using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_broker_content 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_broker_content
    {
        public PBnet_broker_content()
        { }
        #region Model
        private int _id;
        private string _btitle;
        private string _bcontent;
        private string _btype;
        private int? _intsortid;
        private bool _isauditing;
        private DateTime? _baddtime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Btitle
        {
            set { _btitle = value; }
            get { return _btitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bcontent
        {
            set { _bcontent = value; }
            get { return _bcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Btype
        {
            set { _btype = value; }
            get { return _btype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntSortID
        {
            set { _intsortid = value; }
            get { return _intsortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BaddTime
        {
            set { _baddtime = value; }
            get { return _baddtime; }
        }
        #endregion Model

    }
}

