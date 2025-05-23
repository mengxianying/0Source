using System;
using System.Collections.Generic;
using System.Text;
namespace Pbzx.Model
{
    /// <summary>
    /// Chipped_UserTrack:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Chipped_UserTrack
    {
        public Chipped_UserTrack()
        { }
        #region Model
        private int _ut_id;
        private string _ut_username;
        private int? _ut_lname;
        private int? _ut_state;
        /// <summary>
        /// 
        /// </summary>
        public int ut_id
        {
            set { _ut_id = value; }
            get { return _ut_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ut_username
        {
            set { _ut_username = value; }
            get { return _ut_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ut_Lname
        {
            set { _ut_lname = value; }
            get { return _ut_lname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ut_state
        {
            set { _ut_state = value; }
            get { return _ut_state; }
        }
        #endregion Model

    }
}
