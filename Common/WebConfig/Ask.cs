using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public struct Ask
    {
        /// <summary>
        /// 拼搏吧名称
        /// </summary>
        public string WebName;
        /// <summary>
        /// 拼搏吧标题
        /// </summary>
        public string WebTitle;
        /// <summary>
        /// 拼搏吧地址
        /// </summary>
        public string WebUrl;
        /// <summary>
        /// 版权所有
        /// </summary>
        public string Copyright;
        /// <summary>
        /// 拼搏吧关键字
        /// </summary>
        public string WebKey;
        /// <summary>
        /// 拼搏吧说明
        /// </summary>
        public string WebDescription;

        /// <summary>
        /// 拼搏吧每页显示条数
        /// </summary>
        public int WebPageNum;

        /// <summary>
        /// 高悬赏分
        /// </summary>
        public int AskHighLargessPoint;
    }
}
