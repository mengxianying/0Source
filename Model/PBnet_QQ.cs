using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_QQ 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_QQ
    {
        public PBnet_QQ()
        { }
        #region Model
        private int _intid;
        private string _varqqnumber;
        private string _varname;
        private int? _intdisplayposition;
        private int? _intorderid;
        private bool _bitisauditing;
        private string _team;
        private string _tel;
        /// <summary>
        /// 
        /// </summary>
        public int IntId
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// qq号码
        /// </summary>
        public string VarQQNumber
        {
            set { _varqqnumber = value; }
            get { return _varqqnumber; }
        }
        /// <summary>
        /// qq备注名称
        /// </summary>
        public string VarName
        {
            set { _varname = value; }
            get { return _varname; }
        }
        /// <summary>
        /// 显示位置（0：首页，1：**频道页，2：**频道页）
        /// </summary>
        public int? IntDisplayPosition
        {
            set { _intdisplayposition = value; }
            get { return _intdisplayposition; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int? IntOrderID
        {
            set { _intorderid = value; }
            get { return _intorderid; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool BitIsAuditing
        {
            set { _bitisauditing = value; }
            get { return _bitisauditing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Team
        {
            set { _team = value; }
            get { return _team; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        #endregion Model

    }
}

