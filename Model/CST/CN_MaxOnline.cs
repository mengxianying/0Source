using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_MaxOnline 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    public class CN_MaxOnline
    {
        public CN_MaxOnline()
        { }
        #region Model
        private int? _id;
        private int _softwaretype;
        private int _installtype;
        private int _maxcount;
        private DateTime _recodetime;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SoftwareType
        {
            set { _softwaretype = value; }
            get { return _softwaretype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InstallType
        {
            set { _installtype = value; }
            get { return _installtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MaxCount
        {
            set { _maxcount = value; }
            get { return _maxcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RecodeTime
        {
            set { _recodetime = value; }
            get { return _recodetime; }
        }
        #endregion Model

    }
}

