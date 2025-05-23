using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_About 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_About
    {
        public PBnet_About()
        { }
        #region Model
        private int _id;
        private string _ustitle;
        private string _uscontent;
        private bool _usstate;
        private DateTime? _usaddtime;
        private int? _usorder;
        private bool _usisbtommshow;
        private string _usurl;
        private string _htmlurl;
        private string _aspxurl;
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
        public string UsTitle
        {
            set { _ustitle = value; }
            get { return _ustitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsContent
        {
            set { _uscontent = value; }
            get { return _uscontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UsState
        {
            set { _usstate = value; }
            get { return _usstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UsAddTime
        {
            set { _usaddtime = value; }
            get { return _usaddtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UsOrder
        {
            set { _usorder = value; }
            get { return _usorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UsIsBtommShow
        {
            set { _usisbtommshow = value; }
            get { return _usisbtommshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsUrl
        {
            set { _usurl = value; }
            get { return _usurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlUrl
        {
            set { _htmlurl = value; }
            get { return _htmlurl; }
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

