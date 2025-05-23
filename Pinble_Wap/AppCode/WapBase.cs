using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pinble_Wap
{
    public struct WapBase
    {
        /// <summary>
        /// 春节开奖休市开始时间
        /// </summary>
        public string YearStart;
        /// <summary>
        /// 春节开奖休市结束时间
        /// </summary>
        public string YearEnd;

        //期数
        public string Issue;

        //试机号Testcode
        public string Testcode;

        //开奖号码txtCode
        public string Code;

        //最后修改时间
        public string Date;

        //彩神通关注码

       public string  Machine;

        //尾数
        public string TCode;

        public string Ball;

        public string Decode;

        public string AttentionCode;
        //金码


    }
}
