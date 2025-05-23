using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_Black 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_Black
    {
        public CN_Black()
        { }
        #region Model
        private int _id;
        private string _blackvalue;
        private int _blackflag;
        private DateTime? _createtime;
        private int _status;
        private string _details;
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
        public string BlackValue
        {
            set { _blackvalue = value; }
            get { return _blackvalue; }
        }
        /// <summary>
        /// 1:orghdsn, 2:hdsn, 3:username, 4:ip
        /// </summary>
        public int BlackFlag
        {
            set { _blackflag = value; }
            get { return _blackflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 0:invalid  1:normal
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Details
        {
            set { _details = value; }
            get { return _details; }
        }
        #endregion Model

    }
}

