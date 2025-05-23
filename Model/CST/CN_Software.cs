using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_Software 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_Software
    {
        public CN_Software()
        { }
        #region Model
        private int _id;
        private int _softwaretype;
        private int _installtype;
        private string _boards;
        private string _mintopics;
        private string _minanncounts;
        private int? _status;
        private int? _flag;
        private string _mindays;
        private string _minbests;
        private string _lottery;
        private int? _lotteryid;
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
        public string Boards
        {
            set { _boards = value; }
            get { return _boards; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinTopics
        {
            set { _mintopics = value; }
            get { return _mintopics; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinAnncounts
        {
            set { _minanncounts = value; }
            get { return _minanncounts; }
        }
        /// <summary>
        /// 0:updated  1:not updated 2:forbid
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 0:private 1:public
        /// </summary>
        public int? Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinDays
        {
            set { _mindays = value; }
            get { return _mindays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinBests
        {
            set { _minbests = value; }
            get { return _minbests; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Lottery
        {
            set { _lottery = value; }
            get { return _lottery; }
        }
        /// <summary>
        /// 彩票名ID
        /// </summary>
        public int? LotteryID
        {
            set { _lotteryid = value; }
            get { return _lotteryid; }
        }
        #endregion Model

    }
}

