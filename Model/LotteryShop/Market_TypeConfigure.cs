using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 服务类型详细配置
    /// 2010-10-19
    /// </summary>
    [Serializable]
    public class Market_TypeConfigure
    {
        #region Model
        private int _configureid;
        private int _typeid;
        private int _on_off;
        private int _sign;
        private DateTime _begintime;
        private DateTime _endtime;
        private int _upload;
        private decimal _smallmoney;
        private decimal _bigmoney;
        private string _ticheng;
        private int _manyissue;
        private int _recommend;
        /// <summary>
        /// 
        /// </summary>
        public int ConfigureID
        {
            set { _configureid = value; }
            get { return _configureid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TypeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int On_off
        {
            set { _on_off = value; }
            get { return _on_off; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sign
        {
            set { _sign = value; }
            get { return _sign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Upload
        {
            set { _upload = value; }
            get { return _upload; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SmallMoney
        {
            set { _smallmoney = value; }
            get { return _smallmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal BigMoney
        {
            set { _bigmoney = value; }
            get { return _bigmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ticheng
        {
            set { _ticheng = value; }
            get { return _ticheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ManyIssue
        {
            set { _manyissue = value; }
            get { return _manyissue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Recommend
        {
            set { _recommend = value; }
            get { return _recommend; }
        }
        #endregion Model
    }
}
