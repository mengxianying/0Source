using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_ProductPrice 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_ProductPrice
	{
		public PBnet_ProductPrice()
		{
            _varadmin = "";
            _datupdatetime = DateTime.Now;
        }
        #region Model
        private int _intpriceid;
        private string _varversiontype;
        private string _varusetime;
        private string _varprice;
        private DateTime _datupdatetime;
        private string _varadmin;
        /// <summary>
        /// 价格编号
        /// </summary>
        public int IntPriceID
        {
            set { _intpriceid = value; }
            get { return _intpriceid; }
        }
        /// <summary>
        /// 版本类别
        /// </summary>
        public string VarVersionType
        {
            set { _varversiontype = value; }
            get { return _varversiontype; }
        }
        /// <summary>
        /// 使用时间
        /// </summary>
        public string VarUseTime
        {
            set { _varusetime = value; }
            get { return _varusetime; }
        }
        /// <summary>
        /// 网络价格
        /// </summary>
        public string VarPrice
        {
            set { _varprice = value; }
            get { return _varprice; }
        }
        /// <summary>
        /// 加入或者更新时间
        /// </summary>
        public DateTime DatUpdateTime
        {
            set { _datupdatetime = value; }
            get { return _datupdatetime; }
        }
        /// <summary>
        /// 修改此价格的管理员用户名
        /// </summary>
        public string VarAdmin
        {
            set { _varadmin = value; }
            get { return _varadmin; }
        }
        #endregion Model

	}
}

