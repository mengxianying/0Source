using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Chipped_RandomNum:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Chipped_RandomNum
    {
        public Chipped_RandomNum()
        { }
        #region Model
        private int _rn_id;
        private string _rn_name;
        private int? _rn_play;
        private int? _rn_note;
        private int? _rn_multiple;
        private decimal? _rn_tmtion;
        private int? _rn_mess;
        private int? _rn_state = 0;
        private DateTime? _rn_time;

        private string _rn_num;

        public string Rn_num
        {
            get { return _rn_num; }
            set { _rn_num = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Rn_id
        {
            set { _rn_id = value; }
            get { return _rn_id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Rn_name
        {
            set { _rn_name = value; }
            get { return _rn_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Rn_play
        {
            set { _rn_play = value; }
            get { return _rn_play; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Rn_note
        {
            set { _rn_note = value; }
            get { return _rn_note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Rn_multiple
        {
            set { _rn_multiple = value; }
            get { return _rn_multiple; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Rn_tmtion
        {
            set { _rn_tmtion = value; }
            get { return _rn_tmtion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Rn_mess
        {
            set { _rn_mess = value; }
            get { return _rn_mess; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Rn_state
        {
            set { _rn_state = value; }
            get { return _rn_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Rn_time
        {
            set { _rn_time = value; }
            get { return _rn_time; }
        }
        #endregion Model


    }
}
