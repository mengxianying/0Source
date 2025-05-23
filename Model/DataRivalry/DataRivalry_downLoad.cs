using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类DataRivalry_downLoad 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class DataRivalry_downLoad
    {
        public DataRivalry_downLoad()
        { }
        #region Model
        private int _dl_id;
        private string _dl_name;
        private DateTime? _dl_time;
        private int? _dl_ufid;
        private int? _dl_dl;
        private string _dl_dlname;
        /// <summary>
        /// 
        /// </summary>
        public int Dl_id
        {
            set { _dl_id = value; }
            get { return _dl_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Dl_name
        {
            set { _dl_name = value; }
            get { return _dl_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Dl_Time
        {
            set { _dl_time = value; }
            get { return _dl_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Dl_ufID
        {
            set { _dl_ufid = value; }
            get { return _dl_ufid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Dl_dl
        {
            set { _dl_dl = value; }
            get { return _dl_dl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Dl_dlName
        {
            set { _dl_dlname = value; }
            get { return _dl_dlname; }
        }
        #endregion Model
    }
}