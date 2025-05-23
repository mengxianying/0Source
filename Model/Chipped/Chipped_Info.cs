using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class Chipped_Info
    {
        #region Model
        private string _qnumber;
        private string _chippedname;
        private int? _chippedshare;
        private DateTime? _chippedtime;
        /// <summary>
        /// 
        /// </summary>
        public string QNumber
        {
            set { _qnumber = value; }
            get { return _qnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChippedName
        {
            set { _chippedname = value; }
            get { return _chippedname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ChippedShare
        {
            set { _chippedshare = value; }
            get { return _chippedshare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ChippedTime
        {
            set { _chippedtime = value; }
            get { return _chippedtime; }
        }
        #endregion Model
    }
}
