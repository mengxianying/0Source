using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Chipped_Num:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Chipped_Num
    {
        public Chipped_Num()
        { }
        #region Model
        private int _n_id;
        private int? _n_inid;
        private int? _n_rnid;
        private string _n_num;
        /// <summary>
        /// 
        /// </summary>
        public int N_id
        {
            set { _n_id = value; }
            get { return _n_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_InId
        {
            set { _n_inid = value; }
            get { return _n_inid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RnId
        {
            set { _n_rnid = value; }
            get { return _n_rnid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_num
        {
            set { _n_num = value; }
            get { return _n_num; }
        }
        #endregion Model

    }
}
