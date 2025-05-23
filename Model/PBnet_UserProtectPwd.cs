using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_UserProtectPwd 。(属性说明自动提取数据库字段的描述信息)
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
        /// BBS用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密保问题
        /// </summary>
        public string SecurityQuestion
        {
            set { _securityquestion = value; }
            get { return _securityquestion; }
        }
        /// <summary>
        /// 密保答案
        /// </summary>
        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// 绑定的手机号
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 绑定的e_mail
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 类别(0:论坛密码保护，1:交易密码保护)
        /// </summary>
        public int? type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model


    }
}

