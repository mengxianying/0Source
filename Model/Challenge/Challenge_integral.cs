using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Challenge_integral 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Challenge_integral
    {
        public Challenge_integral()
        { }
        #region Model
        private int _i_id;
        private string _i_name;
        private int? _i_lottid;
        private string _i_condname;
        private int? _i_integral;
        /// <summary>
        /// 
        /// </summary>
        public int I_id
        {
            set { _i_id = value; }
            get { return _i_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string I_name
        {
            set { _i_name = value; }
            get { return _i_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? I_lottid
        {
            set { _i_lottid = value; }
            get { return _i_lottid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string I_condName
        {
            set { _i_condname = value; }
            get { return _i_condname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? I_integral
        {
            set { _i_integral = value; }
            get { return _i_integral; }
        }
        #endregion Model

    }
}
