using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PBnet_Favorites
    {
        public PBnet_Favorites()
        { }
        #region Model
        private int _favoritesid;
        private int _userid;
        private string _username;
        private int? _productid;
        private string _tablename;
        private DateTime? _dateadded;
        /// <summary>
        /// 收藏夹名称
        /// </summary>
        public int FavoritesID
        {
            set { _favoritesid = value; }
            get { return _favoritesid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? DateAdded
        {
            set { _dateadded = value; }
            get { return _dateadded; }
        }
        #endregion Model
    }
}
