using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Drawer_user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Drawer_user
    {
        public Drawer_user()
        { }
        #region Model
        private int _d_id;
        private string _d_username;
        private string _d_passsword;
        private string _d_code;
        /// <summary>
        /// 
        /// </summary>
        public int D_id
        {
            set { _d_id = value; }
            get { return _d_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string D_userName
        {
            set { _d_username = value; }
            get { return _d_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string D_passsWord
        {
            set { _d_passsword = value; }
            get { return _d_passsword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string D_code
        {
            set { _d_code = value; }
            get { return _d_code; }
        }
        #endregion Model

    }
}
