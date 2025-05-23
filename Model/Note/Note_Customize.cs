using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    // <summary>
    /// 实体类Note_Customize 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Note_Customize
    {
        public Note_Customize()
        { }
        #region Model
        private int _id;
        private int _sid;
        private string _phone;
        private string _username;
        private DateTime _begintime;
        private DateTime _endtime;
        private decimal _price;
        private int status;

        private int continuationType;

        public int ContinuationType
        {
            get { return continuationType; }
            set { continuationType = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
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
        public int SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}
