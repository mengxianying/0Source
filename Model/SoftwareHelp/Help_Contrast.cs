using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����SoftwareHelp_Contrast ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class Help_Contrast
    {
        public Help_Contrast()
        { }
        #region Model
        private int _ct_id;
        private string _ct_treenum;
        private string _ct_software;
        /// <summary>
        /// 
        /// </summary>
        public int Ct_id
        {
            set { _ct_id = value; }
            get { return _ct_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ct_TreeNum
        {
            set { _ct_treenum = value; }
            get { return _ct_treenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ct_software
        {
            set { _ct_software = value; }
            get { return _ct_software; }
        }
        #endregion Model
    }

}