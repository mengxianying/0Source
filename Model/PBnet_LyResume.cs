using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_LyResume 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_LyResume
    {
        public PBnet_LyResume()
        { }
        #region Model
        private int _systemnumber;
        private int? _lylistid;
        private DateTime? _resumetime;
        private string _resumecontent;
        private string _resumeauthor;
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
        public int? LyListID
        {
            set { _lylistid = value; }
            get { return _lylistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ResumeTime
        {
            set { _resumetime = value; }
            get { return _resumetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResumeContent
        {
            set { _resumecontent = value; }
            get { return _resumecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResumeAuthor
        {
            set { _resumeauthor = value; }
            get { return _resumeauthor; }
        }
        #endregion Model

    }
}

