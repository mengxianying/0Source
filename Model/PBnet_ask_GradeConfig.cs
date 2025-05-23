using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_ask_GradeConfig ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_ask_GradeConfig
    {
        public PBnet_ask_GradeConfig()
        { }
        #region Model
        private int _id;
        private string _gradename;
        private int _minpoint;
        private int _maxpoint;

        private string _gradeID;

        public string GradeID
        {
            get { return _gradeID; }
            set { _gradeID = value; }
        }
        /// <summary>
        /// ����(�ȼ�ID)
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �ȼ�����
        /// </summary>
        public string GradeName
        {
            set { _gradename = value; }
            get { return _gradename; }
        }
        /// <summary>
        /// ����˵ȼ���С����
        /// </summary>
        public int MinPoint
        {
            set { _minpoint = value; }
            get { return _minpoint; }
        }
        /// <summary>
        /// �˵ȼ�������
        /// </summary>
        public int MaxPoint
        {
            set { _maxpoint = value; }
            get { return _maxpoint; }
        }
        #endregion Model

    }
}

