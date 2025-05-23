using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_UserProtectPwd ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_UserProtectPwd
    {
        public PBnet_UserProtectPwd()
        {
            _type = 0;
        }
        #region Model
        private int _id;
        private string _username;
        private string _securityquestion;
        private string _answer;
        private string _cardid;
        private string _mobile;
        private string _email;
        private int? _type;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// BBS�û���
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// �ܱ�����
        /// </summary>
        public string SecurityQuestion
        {
            set { _securityquestion = value; }
            get { return _securityquestion; }
        }
        /// <summary>
        /// �ܱ���
        /// </summary>
        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
        }
        /// <summary>
        /// ���֤��
        /// </summary>
        public string CardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// �󶨵��ֻ���
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// �󶨵�e_mail
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// ���(0:��̳���뱣����1:�������뱣��)
        /// </summary>
        public int? type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model


    }
}

