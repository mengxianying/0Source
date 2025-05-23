using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{

    [Serializable]
    public class Market_Num
    {

        public Market_Num()
        { }
        #region Model
        private int _id;
        private int _itemid;
        private string _expectnum;
        private string _appendname;
        private string _issuetime;
        private int _commend;
        private string _content;
        private int? _itemidentity;
        private string _itemradio;
        private string _itemcheck;
        private string _itemnumber;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ItemID
        {
            set { _itemid = value; }
            get { return _itemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpectNum
        {
            set { _expectnum = value; }
            get { return _expectnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appendName
        {
            set { _appendname = value; }
            get { return _appendname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Commend
        {
            set { _commend = value; }
            get { return _commend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? itemidentity
        {
            set { _itemidentity = value; }
            get { return _itemidentity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string itemradio
        {
            set { _itemradio = value; }
            get { return _itemradio; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string itemcheck
        {
            set { _itemcheck = value; }
            get { return _itemcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string itemnumber
        {
            set { _itemnumber = value; }
            get { return _itemnumber; }
        }
        #endregion Model
    }
}
