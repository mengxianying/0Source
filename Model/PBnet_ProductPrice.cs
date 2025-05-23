using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_ProductPrice ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �۸���
        /// </summary>
        public int IntPriceID
        {
            set { _intpriceid = value; }
            get { return _intpriceid; }
        }
        /// <summary>
        /// �汾���
        /// </summary>
        public string VarVersionType
        {
            set { _varversiontype = value; }
            get { return _varversiontype; }
        }
        /// <summary>
        /// ʹ��ʱ��
        /// </summary>
        public string VarUseTime
        {
            set { _varusetime = value; }
            get { return _varusetime; }
        }
        /// <summary>
        /// ����۸�
        /// </summary>
        public string VarPrice
        {
            set { _varprice = value; }
            get { return _varprice; }
        }
        /// <summary>
        /// ������߸���ʱ��
        /// </summary>
        public DateTime DatUpdateTime
        {
            set { _datupdatetime = value; }
            get { return _datupdatetime; }
        }
        /// <summary>
        /// �޸Ĵ˼۸�Ĺ���Ա�û���
        /// </summary>
        public string VarAdmin
        {
            set { _varadmin = value; }
            get { return _varadmin; }
        }
        #endregion Model

	}
}

