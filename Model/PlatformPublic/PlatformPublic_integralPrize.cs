using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PlatformPublic_integralPrize 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class PlatformPublic_integralPrize
    {
        public PlatformPublic_integralPrize()
        { }
        #region Model
        private int _pip_id;
        private string _pip_user;
        private int _pip_interal;
        private int _pip_prize;
        private decimal _pip_money;
        private string _pip_belongs;
        private int _pip_freeze;
        /// <summary>
        /// 
        /// </summary>
        public int Pip_id
        {
            set { _pip_id = value; }
            get { return _pip_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pip_user
        {
            set { _pip_user = value; }
            get { return _pip_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Pip_Interal
        {
            set { _pip_interal = value; }
            get { return _pip_interal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Pip_Prize
        {
            set { _pip_prize = value; }
            get { return _pip_prize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Pip_money
        {
            set { _pip_money = value; }
            get { return _pip_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pip_belongs
        {
            set { _pip_belongs = value; }
            get { return _pip_belongs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Pip_freeze
        {
            set { _pip_freeze = value; }
            get { return _pip_freeze; }
        }
        #endregion Model
    }
}

