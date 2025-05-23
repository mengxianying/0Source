using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Drawer_configure:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Drawer_configure
    {
        public Drawer_configure()
        { }
        #region Model
        private int _dtc_id;
        private string _dtc_name;
        private int? _dtc_cf;
        /// <summary>
        /// 
        /// </summary>
        public int Dtc_id
        {
            set { _dtc_id = value; }
            get { return _dtc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Dtc_name
        {
            set { _dtc_name = value; }
            get { return _dtc_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Dtc_cf
        {
            set { _dtc_cf = value; }
            get { return _dtc_cf; }
        }
        #endregion Model

    }
}