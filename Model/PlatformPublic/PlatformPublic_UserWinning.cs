using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PlatformPublic_UserWinning
    {
        public PlatformPublic_UserWinning()
        { }
        #region Model
        private int _u_id;
        private string _u_name;
        private int? _u_issue;
        private DateTime? _u_time;
        private int? _u_lottid;
        private string _u_witem;
        private string _u_wcontent;
        private decimal? _u_monery;
        private int? _u_coin;
        private string _u_platform;
        /// <summary>
        /// 
        /// </summary>
        public int u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string u_name
        {
            set { _u_name = value; }
            get { return _u_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? u_issue
        {
            set { _u_issue = value; }
            get { return _u_issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? u_time
        {
            set { _u_time = value; }
            get { return _u_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? u_lottId
        {
            set { _u_lottid = value; }
            get { return _u_lottid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string u_wItem
        {
            set { _u_witem = value; }
            get { return _u_witem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string u_wContent
        {
            set { _u_wcontent = value; }
            get { return _u_wcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? u_Monery
        {
            set { _u_monery = value; }
            get { return _u_monery; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? u_coin
        {
            set { _u_coin = value; }
            get { return _u_coin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string u_platform
        {
            set { _u_platform = value; }
            get { return _u_platform; }
        }
        #endregion Model

    }
}
