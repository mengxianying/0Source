using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public struct UserConfig
    {
        /// <summary>
        /// 用户名最小长度
        /// </summary>
        public string UserNameMin;
        /// <summary>
        /// 用户名最大长度
        /// </summary>
        public string UserNameLong;
        /// <summary>
        /// 密码最小长度
        /// </summary>
        public string PassWordMin;

        /// <summary>
        /// 密码最大长度
        /// </summary>
        public string PassWordLong;

        /// <summary>
        /// 限制登录失败次数
        /// </summary>
        public string OnLoginNum;
        /// <summary>
        /// 头像默认地址
        /// </summary>
        public string Facefile;
        /// <summary>
        /// 是否发送EMAIL
        /// </summary>
        public string IsSendEmail;
        /// <summary>
        /// 在线过期时长
        /// </summary>
        public string OnLineTime;
        /// <summary>
        /// 用户文件夹空间
        /// </summary>
        public string FolderSpace;
        /// <summary>
        /// 用户密码提示问题
        /// </summary>
        public string PassWordQuestion;
        /// <summary>
        /// 不可注册的用户名
        /// </summary>
        public string UnUserName;
        /// <summary>
        /// 个人注册协议
        /// </summary>
        public string PersonRegeditAgreement;

        /// <summary>
        /// 个人注册协议
        /// </summary>
        public string PersonRegeditAgreementGao;

         /// <summary>
        /// 经纪人注册协议
        /// </summary>
        public string BrokerAgreement;

        /// <summary>
        /// 代理注册协议
        /// </summary>
        public string AgentAgreement;


        /// <summary>
        /// 银行
        /// </summary>
        public string Banks;
    }
}
