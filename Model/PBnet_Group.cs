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
        /// ���
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// Ȩ��ֵ
        /// </summary>
        public byte[] Authority
        {
            set { _authority = value; }
            get { return _authority; }
        }
        #endregion Model
    }
}
