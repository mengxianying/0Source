using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Chipped_winning 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Chipped_winning
    {
        public Chipped_winning()
        { }
        #region Model
        private int _id;
        private string _rnumber;
        private string _winningnum;
        private decimal _bonus;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RNumber
        {
            set { _rnumber = value; }
            get { return _rnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string winningNum
        {
            set { _winningnum = value; }
            get { return _winningnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bonus
        {
            set { _bonus = value; }
            get { return _bonus; }
        }
        #endregion Model
    }
}
