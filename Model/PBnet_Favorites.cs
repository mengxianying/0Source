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
        /// �ղؼ�����
        /// </summary>
        public int FavoritesID
        {
            set { _favoritesid = value; }
            get { return _favoritesid; }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? DateAdded
        {
            set { _dateadded = value; }
            get { return _dateadded; }
        }
        #endregion Model
    }
}
