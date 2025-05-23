using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CL_PrintLine 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CL_PrintLine
    {
        public CL_PrintLine()
        { }
        #region Model
        private int _id;
        private string _sn;
        private DateTime _createtime;
        private string _creator;
        private DateTime _accepttime;
        private string _accepter;
        private DateTime? _selltime;
        private string _seller;
        private int _status;
        private int _type;
        private string _remarks;
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
        public string SN
        {
            set { _sn = value; }
            get { return _sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AcceptTime
        {
            set { _accepttime = value; }
            get { return _accepttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Accepter
        {
            set { _accepter = value; }
            get { return _accepter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SellTime
        {
            set { _selltime = value; }
            get { return _selltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Seller
        {
            set { _seller = value; }
            get { return _seller; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model

    }
}

