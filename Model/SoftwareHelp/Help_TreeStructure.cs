using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类SoftwareHelp_TreeStructure 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Help_TreeStructure
    {
        public Help_TreeStructure()
        { }
        #region Model
        private int _tree_id;
        private string _tree_name;
        private string _tree_superiornoet;
        private string _tree_num;
        private string _tree_rootnotd;
        private string _tree_countent;
        private string _tree_path;
        private int? _tree_sort = 0;
        /// <summary>
        /// 
        /// </summary>
        public int Tree_id
        {
            set { _tree_id = value; }
            get { return _tree_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tree_name
        {
            set { _tree_name = value; }
            get { return _tree_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tree_superiorNoet
        {
            set { _tree_superiornoet = value; }
            get { return _tree_superiornoet; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tree_num
        {
            set { _tree_num = value; }
            get { return _tree_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tree_RootNotd
        {
            set { _tree_rootnotd = value; }
            get { return _tree_rootnotd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tree_countent
        {
            set { _tree_countent = value; }
            get { return _tree_countent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tree_Path
        {
            set { _tree_path = value; }
            get { return _tree_path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Tree_sort
        {
            set { _tree_sort = value; }
            get { return _tree_sort; }
        }
        #endregion Model
    }
}


