using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类DataRivalry_Contrast 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class DataRivalry_Contrast
    {
        public DataRivalry_Contrast()
        { }
        #region Model
        private int _ct_id;
        private int _ct_drid;
        private string _ct_num;
        /// <summary>
        /// 
        /// </summary>
        public int ct_id
        {
            set { _ct_id = value; }
            get { return _ct_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ct_drID
        {
            set { _ct_drid = value; }
            get { return _ct_drid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ct_Num
        {
            set { _ct_num = value; }
            get { return _ct_num; }
        }
        #endregion Model
    }
}
