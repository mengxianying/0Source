using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_ask_GradeConfig 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_ask_GradeConfig
    {
        public PBnet_ask_GradeConfig()
        { }
        #region Model
        private int _id;
        private string _gradename;
        private int _minpoint;
        private int _maxpoint;

        private string _gradeID;

        public string GradeID
        {
            get { return _gradeID; }
            set { _gradeID = value; }
        }
        /// <summary>
        /// 索引(等级ID)
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 等级名称
        /// </summary>
        public string GradeName
        {
            set { _gradename = value; }
            get { return _gradename; }
        }
        /// <summary>
        /// 到达此等级最小积分
        /// </summary>
        public int MinPoint
        {
            set { _minpoint = value; }
            get { return _minpoint; }
        }
        /// <summary>
        /// 此等级最大积分
        /// </summary>
        public int MaxPoint
        {
            set { _maxpoint = value; }
            get { return _maxpoint; }
        }
        #endregion Model

    }
}

