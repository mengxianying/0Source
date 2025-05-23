using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    [Serializable]
    public class Market_CancelIndent
    {
        public Market_CancelIndent()
        { }
        #region Model
        private int _cancelid;
        private int? _cancelindent;
        private DateTime? _ctime;
        private int? _capprove;
        private string _cancelname;
        private int _cancelitem;
        private string _cancelsake;
        private string _other;
        private DateTime? _approvetime;
        /// <summary>
        /// 
        /// </summary>
        public int CancelID
        {
            set { _cancelid = value; }
            get { return _cancelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CancelIndent
        {
            set { _cancelindent = value; }
            get { return _cancelindent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CTime
        {
            set { _ctime = value; }
            get { return _ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CApprove
        {
            set { _capprove = value; }
            get { return _capprove; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CancelName
        {
            set { _cancelname = value; }
            get { return _cancelname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CancelItem
        {
            set { _cancelitem = value; }
            get { return _cancelitem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CancelSake
        {
            set { _cancelsake = value; }
            get { return _cancelsake; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? approveTime
        {
            set { _approvetime = value; }
            get { return _approvetime; }
        }
        #endregion Model

    }
}
