using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_LyBook 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_LyBook
    {
        public PBnet_LyBook()
        { }
        #region Model
        private int _systemnumber;
        private string _lyusername;
        private int? _lyuserid;
        private int? _lysort;
        private string _ly_phone;
        private string _ly_email;
        private string _lycontent;
        private int? _lystate;
        private DateTime? _lylogtime;
        private string _lylogip;
        /// <summary>
        /// 
        /// </summary>
        public int SystemNumber
        {
            set { _systemnumber = value; }
            get { return _systemnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LyUserName
        {
            set { _lyusername = value; }
            get { return _lyusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LyUserID
        {
            set { _lyuserid = value; }
            get { return _lyuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LySort
        {
            set { _lysort = value; }
            get { return _lysort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ly_Phone
        {
            set { _ly_phone = value; }
            get { return _ly_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ly_Email
        {
            set { _ly_email = value; }
            get { return _ly_email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LyContent
        {
            set { _lycontent = value; }
            get { return _lycontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LyState
        {
            set { _lystate = value; }
            get { return _lystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LyLogTime
        {
            set { _lylogtime = value; }
            get { return _lylogtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LyLogIp
        {
            set { _lylogip = value; }
            get { return _lylogip; }
        }
        #endregion Model

    }
}

