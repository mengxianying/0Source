using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PBnet_Group
    {
        public PBnet_Group()
        { }
        #region Model
        private int _id;
        private string _groupname;
        private byte[] _authority;
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 权限值
        /// </summary>
        public byte[] Authority
        {
            set { _authority = value; }
            get { return _authority; }
        }
        #endregion Model
    }
}
