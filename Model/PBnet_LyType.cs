using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_LyType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_LyType
    {
        public PBnet_LyType()
        { }
        #region Model
        private int _id;
        private string _typename;
        private bool _isauditing;
        private int? _orderid;
        /// <summary>
        /// �����
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        #endregion Model
    }
}
