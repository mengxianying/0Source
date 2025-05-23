using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public enum EadChanl
    {
        /// <summary>
        /// 首页新闻幻灯片
        /// </summary>
       首页=1,

       /// <summary>
       /// 公告
       /// </summary>
       公告 = 2,

         /// <summary>
         /// 新闻
         /// </summary>       
        新闻=3,

       

       /// <summary>
       /// 学院
       /// </summary>
        学院=4,
        /// <summary>
        /// 拼搏吧
        /// </summary>

        拼搏吧 = 5,
        /// <summary>
        /// 代理
        /// </summary>
        代理 = 7,

         /// <summary>
        /// 聊彩室
        /// </summary>

        聊彩室 = 6

    }

    public enum EadClass
    { 
    ///<summary>
    ///通栏广告
    ///</summary>

        图片广告=0,
        ///<summary>
        ///文字广告
        ///</summary>
        
        文字广告=1,
   

        /// <summary>
        /// flash广告
        /// </summary>
        flash广告 = 3,

        /// <summary>
        /// 对联广告
        /// </summary>
        对联广告 = 4,
        /// <summary>
        /// 浮动广告
        /// </summary>
        浮动广告 = 5,
        /// <summary>
        /// javascript脚本广告
        /// </summary>
        JS广告 =6
    }

    public enum EadPlaceType
    {
        ///<summary>
        ///首页图片
        ///</summary>

        首页头部图片广告区= 0,
        ///<summary>
        ///文字广告
        ///</summary>

        首页头部文字广告区 = 1,

        ///<summary>
        ///首页中间_网站公告下面广告区
        ///</summary>
        首页中间_网站公告下面广告区= 2,

        ///<summary>
        /// 首页中间_软件下面广告区
        ///</summary>
        首页中间_软件下面广告区 = 3,
        ///公告首页
        公告_公告通栏广告 = 4

    }

}
