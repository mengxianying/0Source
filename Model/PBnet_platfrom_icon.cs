using System;
namespace Pbzx.Model
{
    /// <summary>
    /// PBnet_platfrom_locn:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PBnet_platfrom_icon
    {
        public PBnet_platfrom_icon()
        { }
        #region Model
        private int _p_id;
        private string _p_imgname;
        private string _p_pfpath;
        private string _p_pfname;
        private int? _p_sort;
        private int? _p_state;
        /// <summary>
        /// 
        /// </summary>
        public int p_id
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string p_imgName
        {
            set { _p_imgname = value; }
            get { return _p_imgname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string P_pfPath
        {
            set { _p_pfpath = value; }
            get { return _p_pfpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string P_pfName
        {
            set { _p_pfname = value; }
            get { return _p_pfname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P_Sort
        {
            set { _p_sort = value; }
            get { return _p_sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P_state
        {
            set { _p_state = value; }
            get { return _p_state; }
        }
        #endregion Model

    }
}