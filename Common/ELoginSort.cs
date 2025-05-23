using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public enum ELoginSort
    {
        /// <summary>
        /// 用户基本信息
        /// </summary>
        manager_user,

        /// <summary>
        /// 用户真实信息
        /// </summary>
        user_RealInfo,

        /// <summary>
        /// 代理信息
        /// </summary>
        user_Broker,

        /// <summary>
        /// 拼搏吧信息
        /// </summary>
        ask_User,

        /// <summary>
        /// 代理用户信息
        /// </summary>       
        delegate_User,

        AgentInfo_Apply,
        AccountNumber,
        Email
    }

    
}
