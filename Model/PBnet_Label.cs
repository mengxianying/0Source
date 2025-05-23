using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_Label ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_Label
    {
        public PBnet_Label()
        { }
        #region Model
        private int _id;
        private int? _labelid;
        private string _labelname;
        private string _content;
        private string _labeltype;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Labelid
        {
            set { _labelid = value; }
            get { return _labelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LabelName
        {
            set { _labelname = value; }
            get { return _labelname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LabelType
        {
            set { _labeltype = value; }
            get { return _labeltype; }
        }
        #endregion Model

    }
}

