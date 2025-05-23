using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_Nslide 。(属性说明自动提取数据库字段的描述信息)
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
        /// 自动增长编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int? NOrder
        {
            set { _norder = value; }
            get { return _norder; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 是否启用初始大小
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

