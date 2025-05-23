using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����Chipped_Attention ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class Chipped_Attention
    {
        public Chipped_Attention()
        { }
        #region Model
        private int _id;
        private string _aname;
        private string _attention;
        private DateTime _atime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AName
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Attention
        {
            set { _attention = value; }
            get { return _attention; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ATime
        {
            set { _atime = value; }
            get { return _atime; }
        }
        #endregion Model
    }
}
