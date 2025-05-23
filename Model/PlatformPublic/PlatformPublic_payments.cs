using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PlatformPublic_payments 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class PlatformPublic_payments
    {
        public PlatformPublic_payments()
        { }
        #region Model
        private int _pp_id;
        private string _pp_name;
        private string _pp_num;
        private int? _pp_type;
        private int? _pp_lotname = 0;
        private int? _pp_issue;
        private DateTime? _pp_time;
        private string _pp_explain;
        private decimal? _pp_data;
        private string _pp_belongs;
        /// <summary>
        /// 
        /// </summary>
        public int Pp_id
        {
            set { _pp_id = value; }
            get { return _pp_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pp_name
        {
            set { _pp_name = value; }
            get { return _pp_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pp_num
        {
            set { _pp_num = value; }
            get { return _pp_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Pp_Type
        {
            set { _pp_type = value; }
            get { return _pp_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Pp_LotName
        {
            set { _pp_lotname = value; }
            get { return _pp_lotname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Pp_issue
        {
            set { _pp_issue = value; }
            get { return _pp_issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Pp_Time
        {
            set { _pp_time = value; }
            get { return _pp_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pp_explain
        {
            set { _pp_explain = value; }
            get { return _pp_explain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Pp_data
        {
            set { _pp_data = value; }
            get { return _pp_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pp_belongs
        {
            set { _pp_belongs = value; }
            get { return _pp_belongs; }
        }
        #endregion Model
    }
}
