using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����DataRivalry_Level ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class DataRivalry_Level
    {
        public DataRivalry_Level()
        { }
        #region Model
        private int _le_id;
        private int _le_level;
        private int _le_brange;
        private int _le_erange;
        private int _le_type;
        private int _le_rewards;
        /// <summary>
        /// 
        /// </summary>
        public int Le_id
        {
            set { _le_id = value; }
            get { return _le_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Le_level
        {
            set { _le_level = value; }
            get { return _le_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Le_BRange
        {
            set { _le_brange = value; }
            get { return _le_brange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Le_ERange
        {
            set { _le_erange = value; }
            get { return _le_erange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Le_type
        {
            set { _le_type = value; }
            get { return _le_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Le_rewards
        {
            set { _le_rewards = value; }
            get { return _le_rewards; }
        }
        #endregion Model
    }
}

