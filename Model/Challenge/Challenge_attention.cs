using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����Challenge_attention ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class Challenge_attention
    {
        public Challenge_attention()
        { }
        #region Model
        private int _att_id;
        private string _att_name;
        private string _att_attention;
        private DateTime _att_time;
        /// <summary>
        /// 
        /// </summary>
        public int Att_id
        {
            set { _att_id = value; }
            get { return _att_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Att_name
        {
            set { _att_name = value; }
            get { return _att_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Att_attention
        {
            set { _att_attention = value; }
            get { return _att_attention; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Att_Time
        {
            set { _att_time = value; }
            get { return _att_time; }
        }
        #endregion Model
    }
}
