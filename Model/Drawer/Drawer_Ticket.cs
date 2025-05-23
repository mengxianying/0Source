using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Drawer_Ticket:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Drawer_Ticket
    {
        public Drawer_Ticket()
        { }
        #region Model
        private int _tic_id;
        private string _tic_dname;
        private string _tic_mark;
        private string _tic_condition;
        private string _tic_state;
        /// <summary>
        /// 
        /// </summary>
        public int Tic_id
        {
            set { _tic_id = value; }
            get { return _tic_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tic_DName
        {
            set { _tic_dname = value; }
            get { return _tic_dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tic_mark
        {
            set { _tic_mark = value; }
            get { return _tic_mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tic_Condition
        {
            set { _tic_condition = value; }
            get { return _tic_condition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tic_state
        {
            set { _tic_state = value; }
            get { return _tic_state; }
        }
        #endregion Model

    }
}
