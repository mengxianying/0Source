using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Chipped_cofig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Chipped_cofig
    {
        public Chipped_cofig()
        { }
        #region Model
        private int _cfg_id;
        private string _cfg_lname;
        private int _cfg_state;
        private int? _cfg_tarstate;
        /// <summary>
        /// 
        /// </summary>
        public int cfg_id
        {
            set { _cfg_id = value; }
            get { return _cfg_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfg_lname
        {
            set { _cfg_lname = value; }
            get { return _cfg_lname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cfg_state
        {
            set { _cfg_state = value; }
            get { return _cfg_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cfg_tarState
        {
            set { _cfg_tarstate = value; }
            get { return _cfg_tarstate; }
        }
        #endregion Model

    }
}
