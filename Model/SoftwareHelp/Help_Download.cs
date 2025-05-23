using System;
namespace Pbzx.Model
{
    /// <summary>
    /// Help_Download:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Help_Download
    {
        public Help_Download()
        { }
        #region Model
        private int _d_id;
        private int? _d_type;
        private string _d_download;
        /// <summary>
        /// 
        /// </summary>
        public int d_id
        {
            set { _d_id = value; }
            get { return _d_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? d_type
        {
            set { _d_type = value; }
            get { return _d_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string d_download
        {
            set { _d_download = value; }
            get { return _d_download; }
        }
        #endregion Model

    }
}
