using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类SoftwareHelp_HelpName 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Help_HelpName
    {
        public Help_HelpName()
        { }
        #region Model
        private int _hn_id;
        private string _hn_name;
        private int _hn_open;
        private string _hn_path;
        /// <summary>
        /// 
        /// </summary>
        public int Hn_ID
        {
            set { _hn_id = value; }
            get { return _hn_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hn_name
        {
            set { _hn_name = value; }
            get { return _hn_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hn_Open
        {
            set { _hn_open = value; }
            get { return _hn_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hn_path
        {
            set { _hn_path = value; }
            get { return _hn_path; }
        }
        #endregion Model
    }
}
