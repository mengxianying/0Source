using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_AdvPlace ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_AdvPlace
    {
        public PBnet_AdvPlace()
        { }
        #region Model
        private int _id;
        private string _placename;
        private int _typeid;
        private int _channelid;
        private int? _placeheight;
        private int? _placewidth;
        private string _placeposition;
        private string _placetype;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ���λ���ƻ�������
        /// </summary>
        public string PlaceName
        {
            set { _placename = value; }
            get { return _placename; }
        }
        /// <summary>
        /// ���ID�����֡�ͼƬ��flash��������������JS��棩
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// ���λ���
        /// </summary>
        public int ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// �߶�
        /// </summary>
        public int? PlaceHeight
        {
            set { _placeheight = value; }
            get { return _placeheight; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public int? PlaceWidth
        {
            set { _placewidth = value; }
            get { return _placewidth; }
        }
        /// <summary>
        /// ���λ��������(��:1*1)
        /// </summary>
        public string PlacePosition
        {
            set { _placeposition = value; }
            get { return _placeposition; }
        }
        /// <summary>
        /// ���λ���λ�ã�����ö�٣����磺��ҳtopͼƬ:0����ҳ���ֹ��:1����
        /// </summary>
        public string PlaceType
        {
            set { _placetype = value; }
            get { return _placetype; }
        }
        #endregion Model

    }
}

