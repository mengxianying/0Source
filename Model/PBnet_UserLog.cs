using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_UserLog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_UserLog
    {
        public PBnet_UserLog()
        { }
        #region Model
        private long _id;
        private string _log_username;
        private string _log_password;
        private DateTime _log_time;
        private string _log_ip;
        private string _log_state;
        private string _log_stepinto;
        private string _log_urlname;
        private string _log_allhttp;
        private string _log_country;
        private string _log_city;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_username
        {
            set { _log_username = value; }
            get { return _log_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_password
        {
            set { _log_password = value; }
            get { return _log_password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime log_time
        {
            set { _log_time = value; }
            get { return _log_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_Ip
        {
            set { _log_ip = value; }
            get { return _log_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_state
        {
            set { _log_state = value; }
            get { return _log_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_stepinto
        {
            set { _log_stepinto = value; }
            get { return _log_stepinto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_urlname
        {
            set { _log_urlname = value; }
            get { return _log_urlname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_allhttp
        {
            set { _log_allhttp = value; }
            get { return _log_allhttp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_country
        {
            set { _log_country = value; }
            get { return _log_country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_city
        {
            set { _log_city = value; }
            get { return _log_city; }
        }
        #endregion Model

    }
}

