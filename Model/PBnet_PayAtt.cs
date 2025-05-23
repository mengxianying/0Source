using System;
namespace Pbzx.Model
{
    /// <summary>
    /// PBnet_PayAtt:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PBnet_PayAtt
    {
        public PBnet_PayAtt()
        { }
        #region Model
        private int _pa_id;
        private string _pa_fans;
        private DateTime? _pa_time;
        private string _pa_idol;
        private string _pa_psign;
        private int? _pa_state;
        /// <summary>
        /// 
        /// </summary>
        public int Pa_id
        {
            set { _pa_id = value; }
            get { return _pa_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pa_fans
        {
            set { _pa_fans = value; }
            get { return _pa_fans; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Pa_time
        {
            set { _pa_time = value; }
            get { return _pa_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pa_Idol
        {
            set { _pa_idol = value; }
            get { return _pa_idol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pa_PSign
        {
            set { _pa_psign = value; }
            get { return _pa_psign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Pa_state
        {
            set { _pa_state = value; }
            get { return _pa_state; }
        }
        #endregion Model

    }
}

