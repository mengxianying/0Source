using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_Nslide ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_Nslide
    {
        public PBnet_Nslide()
        {
            _norder = 0;
            _isenable = false;
            _isinitial = false;
            _width = 508;
            _height = 240;
        }
        #region Model
        private int _id;
        private string _linkurl;
        private string _picurl;
        private int? _norder;
        private string _title;
        private bool _isenable;
        private bool _isinitial;
        private int? _width;
        private int? _height;
        /// <summary>
        /// �Զ��������
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? NOrder
        {
            set { _norder = value; }
            get { return _norder; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// �Ƿ����ó�ʼ��С
        /// </summary>
        public bool IsInitial
        {
            set { _isinitial = value; }
            get { return _isinitial; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? height
        {
            set { _height = value; }
            get { return _height; }
        }
        #endregion Model

    }
}

