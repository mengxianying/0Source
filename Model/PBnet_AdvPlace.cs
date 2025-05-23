using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_AdvPlace 。(属性说明自动提取数据库字段的描述信息)
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
        /// 广告位名称或者描述
        /// </summary>
        public string PlaceName
        {
            set { _placename = value; }
            get { return _placename; }
        }
        /// <summary>
        /// 类别ID（文字、图片、flash、对联、浮动、JS广告）
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 广告位类别
        /// </summary>
        public int ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public int? PlaceHeight
        {
            set { _placeheight = value; }
            get { return _placeheight; }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public int? PlaceWidth
        {
            set { _placewidth = value; }
            get { return _placewidth; }
        }
        /// <summary>
        /// 广告位行列坐标(例:1*1)
        /// </summary>
        public string PlacePosition
        {
            set { _placeposition = value; }
            get { return _placeposition; }
        }
        /// <summary>
        /// 广告位类别位置（配置枚举，例如：首页top图片:0；首页文字广告:1；）
        /// </summary>
        public string PlaceType
        {
            set { _placetype = value; }
            get { return _placetype; }
        }
        #endregion Model

    }
}

