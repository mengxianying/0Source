using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_Config 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_Config
    {
        public CN_Config()
        { }
        #region Model
        private int _id;
        private string _configname;
        private string _configvalue;
        private string _configdetails;
        private int? _configflag;
        private int _status;
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
        public string ConfigName
        {
            set { _configname = value; }
            get { return _configname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConfigValue
        {
            set { _configvalue = value; }
            get { return _configvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConfigDetails
        {
            set { _configdetails = value; }
            get { return _configdetails; }
        }
        /// <summary>
        /// 0:system 1:cstserver 2:other
        /// </summary>
        public int? ConfigFlag
        {
            set { _configflag = value; }
            get { return _configflag; }
        }
        /// <summary>
        /// 0:updated 1:not updated
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

