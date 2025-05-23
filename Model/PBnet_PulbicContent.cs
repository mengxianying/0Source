using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_PulbicContent 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_PulbicContent
    {
        public PBnet_PulbicContent()
        { }
        #region Model
        private int _intid;
        private string _nvartitle;
        private string _ntecontent;
        private bool _bitstate;
        private string _nvarclass;
        private string _htmurl;
        private string _aspxurl;
        /// <summary>
        /// 
        /// </summary>
        public int IntID
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarTitle
        {
            set { _nvartitle = value; }
            get { return _nvartitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NteContent
        {
            set { _ntecontent = value; }
            get { return _ntecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BitState
        {
            set { _bitstate = value; }
            get { return _bitstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarClass
        {
            set { _nvarclass = value; }
            get { return _nvarclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmUrl
        {
            set { _htmurl = value; }
            get { return _htmurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AspxUrl
        {
            set { _aspxurl = value; }
            get { return _aspxurl; }
        }
        #endregion Model

    }
}

