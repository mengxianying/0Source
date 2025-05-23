using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 服务类型模型层
    /// 2010-10-19
    /// </summary>
    [Serializable]
    public class Market_Type
    {
        #region Model
        private int _id;
        private int _lotteryid;
        private string _typename;
        private int _intercalate;
        private int _state;
        private int _userid;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LotteryID
        {
            set { _lotteryid = value; }
            get { return _lotteryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Intercalate
        {
            set { _intercalate = value; }
            get { return _intercalate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        #endregion Model

    }
}
