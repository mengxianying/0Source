using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    /// <summary>
    /// 网站基本信息
    /// </summary>
    public struct WebBaseConfig
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName;
        /// <summary>
        /// 网站标题
        /// </summary>
        public string WebTitle;
        /// <summary>
        /// 网站地址
        /// </summary>
        public string WebUrl;
        /// <summary>
        /// 版权所有
        /// </summary>
        public string Copyright;
        /// <summary>
        /// 网站关键字
        /// </summary>
        public string WebKey;
        /// <summary>
        /// 购物车通知
        /// </summary>
        public string Buy;
        /// <summary>
        /// 网站说明
        /// </summary>
        public string WebDescription;

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int WebPageNum;
        /// <summary>
        /// 前台每页显示条数
        /// </summary>
        public int WebPageNum2;
        /// <summary>
        /// 分页标志
        /// </summary>
        public string PaginAtion;
        /// <summary>
        /// 后台CSS
        /// </summary>
        public string BackCssStyleUrl;
        /// <summary>
        /// 新闻过期天数
        /// </summary>
        public string ArticleOverDue;
        /// <summary>
        /// 文本过滤
        /// </summary>
        public string LeachInfo;

        /// <summary>
        /// '热门文章点击数/热门下载次数
        /// </summary>
        public int HitsOfHot;

        /// <summary>
        /// 软件狗价格
        /// </summary>
        public decimal SoftdogPrice;

        /// <summary>
        /// 网络方式计天，天数
        /// </summary>
        public string Days;

        /// <summary>
        /// 软件类别弹窗口，checkbox列数
        /// </summary>
        public int PopSoftClassCol;

        /// <summary>
        /// 静态页编码
        /// </summary>
        public string Encoding;

        /// <summary>
        /// 聊彩室地址
        /// </summary>
        public string ChatUrl;
        /// <summary>
        /// 快递公司
        /// </summary>
        public string Express;
        /// <summary>
        /// 新闻资讯首页幻灯片显示个数
        /// </summary>
        public int Nslide;

        /// <summary>
        /// 春节开奖休市开始时间
        /// </summary>
        public string YearStart;
        /// <summary>
        /// 春节开奖休市结束时间
        /// </summary>
        public string YearEnd;

        /// <summary>
        /// 用户填写经纪人后所得返点
        /// </summary>
        public decimal UserGet;

        /// <summary>
        /// 同一IP每天可发送的短信验证码次数
        /// </summary>
        public int IP_ValideCode_Count;

        /// <summary>
        /// 软件商城和资源下载详情页下载描述
        /// </summary>
        public string DowloadTips;

        /// <summary>
        /// 首页试机号是否显示
        /// </summary>
        public string FirstPageTcodeDisp;

    }
}
