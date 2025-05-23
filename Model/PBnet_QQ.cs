using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_QQ ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_QQ
    {
        public PBnet_QQ()
        { }
        #region Model
        private int _intid;
        private string _varqqnumber;
        private string _varname;
        private int? _intdisplayposition;
        private int? _intorderid;
        private bool _bitisauditing;
        private string _team;
        private string _tel;
        /// <summary>
        /// 
        /// </summary>
        public int IntId
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// qq����
        /// </summary>
        public string VarQQNumber
        {
            set { _varqqnumber = value; }
            get { return _varqqnumber; }
        }
        /// <summary>
        /// qq��ע����
        /// </summary>
        public string VarName
        {
            set { _varname = value; }
            get { return _varname; }
        }
        /// <summary>
        /// ��ʾλ�ã�0����ҳ��1��**Ƶ��ҳ��2��**Ƶ��ҳ��
        /// </summary>
        public int? IntDisplayPosition
        {
            set { _intdisplayposition = value; }
            get { return _intdisplayposition; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? IntOrderID
        {
            set { _intorderid = value; }
            get { return _intorderid; }
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool BitIsAuditing
        {
            set { _bitisauditing = value; }
            get { return _bitisauditing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Team
        {
            set { _team = value; }
            get { return _team; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        #endregion Model

    }
}

