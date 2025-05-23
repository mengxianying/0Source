using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PBnet_WebLog
    {
        public PBnet_WebLog()
        {
            _actiontime = DateTime.Now;
        }
        #region Model
        private int _id;
        private string _actiontype;
        private string _detail;
        private string _operator;
        private string _userip;
        private DateTime _actiontime;
        /// <summary>
        /// ���
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string ActionType
        {
            set { _actiontype = value; }
            get { return _actiontype; }
        }
        /// <summary>
        /// ��ϸ����
        /// </summary>
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// IP
        /// </summary>
        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime ActionTime
        {
            set { _actiontime = value; }
            get { return _actiontime; }
        }
        #endregion Model
    }
}
