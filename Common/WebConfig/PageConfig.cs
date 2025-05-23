using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public struct PageConfig
    {


        //<IndexNewsCount value="18" />
        //<IndexBulletinCount value="10" />
        //<IndexNewUpdateProduct value="10" />
        //<IndexNewUpdateSoft value="10" />

        //<IndexSoft value="8" />
        //<IndexSchool value="8" />
        //<IndexBar value="8" />
        //<IndexBbs value="8" />





        /// <summary>
        /// 首页新闻条数
        /// </summary>
        public string IndexNewsCount;

        /// <summary>
        /// 首页网站公告条数
        /// </summary>
        public string IndexBulletinCount;

        /// <summary>
        /// 首页最新更新产品条数
        /// </summary>
        public string IndexNewUpdateProduct;

        /// <summary>
        /// 首页首页最新更新软件条数
        /// </summary>
        public string IndexNewUpdateSoft;

        /// <summary>
        /// 首页资源下载条数
        /// </summary>
        public string IndexSoft;

        /// <summary>
        /// 首页软件学院条数
        /// </summary>
        public string IndexSchool;

        /// <summary>
        /// 首页拼搏吧条数
        /// </summary>
        public string IndexBar;

        /// <summary>
        /// 首页热点论坛条数
        /// </summary>
        public string IndexBbs;

        /// <summary>
        /// 首页友情链接条数
        /// </summary>
        public string IndexLinkCount;

        /// <summary>
        /// 首页图片友情链接条数
        /// </summary>
        public string IndexLinkCountPic;

        //<BulletinTypeCount value="24" />
        //<BulletinNewUpdateCount value="9"  />
        //<BulletinNewHotCount value="8"  />


        //<NewsTypeCount value="24" />
        //<SchollTypeCount value="8" />   


        /// <summary>
        /// 网站公告首页类别显示个数
        /// </summary>
        public string BulletinTypeCount;

        /// <summary>
        /// 网站公告首页最新显示个数
        /// </summary>
        public string BulletinNewUpdateCount;

        /// <summary>
        /// 网站公告首页热点显示个数
        /// </summary>
        public string BulletinNewHotCount;

        /// <summary>
        /// 新闻资讯首页类别显示个数
        /// </summary>
        public string NewsTypeCount;

        /// <summary>
        /// 新闻资讯首页最新显示个数
        /// </summary>
        public string NewsNewUpdateCount;

        /// <summary>
        /// 新闻资讯首页热点显示个数
        /// </summary>
        public string NewsNewHotCount;

        /// <summary>
        /// 软件学院首页类别显示个数
        /// </summary>
        public string ScholTypeCount;

        /// <summary>
        /// 软件学院中间列表显示个数
        /// </summary>
        public string ScholCenterList;

        /// <summary>
        /// 软件学院首页热点显示个数
        /// </summary>
        public string ScholHotCount;

        /// <summary>
        /// 软件学院首页商品显示个数
        /// </summary>
        public string Scholsoft;

        /// <summary>
        /// 软件学院首页资源显示个数
        /// </summary>
        public string Scholsoure;




        /// <summary>
        /// 经纪人公告
        /// </summary>
        public string BrokerBulletin;

        /// <summary>
        /// 软件内嵌显示字数
        /// </summary>
        public string SoftLength;

        /// <summary>
        ///软件内嵌显示条数 
        /// </summary>
        public string SoftCount;
        /// <summary>
        /// 公告显示字数
        /// </summary>
        public string CstLength;
        /// <summary>
        /// 公告显示条数
        /// </summary>
        public string CstCount;





        /// <summary>
        /// 最新商品显示长度
        /// </summary>
        public string Softlength;

        /// <summary>
        /// 最新商品显示列数
        /// </summary>
        public string Softlie;

        /// <summary>
        /// 商品下载显示长度
        /// </summary>
        public string Softxzlength;

        /// <summary>
        /// 商品下载显示列数
        /// </summary>
        public string Softxzlie;


        /// <summary>
        ///本月 商品下载显示长度
        /// </summary>
        public string SoftMlength;

        /// <summary>
        /// 本月商品下载显示列数
        /// </summary>
        public string SoftMlie;



        /// <summary>
        /// 资源显示长度
        /// </summary>
        public string Sourcelegth;

        /// <summary>
        /// 资源显示列数
        /// </summary>
        public string Sourcelie;

                /// <summary>
        /// 资源总下载显示长度
        /// </summary>
        public string Sourcecountlegth;

        /// <summary>
        /// 资源总下载显示列数
        /// </summary>
        public string Sourcecountlie;


                /// <summary>
        /// 本月资源显示长度
        /// </summary>
        public string SourceMlegth;

        /// <summary>
        /// 本月资源显示列数
        /// </summary>
        public string SourceMlie;
        


    }

    public struct SiteConfig
    {
        public string WebTitle;

        /// <summary>
        /// 提问上线后被管理员删除所扣除的积分
        /// </summary>

        public string wenkf;

        /// <summary>
        /// 回答上线后被管理员删除所扣除的积分
        /// </summary>

        public string dakf;

        /// <summary>
        /// 用户回答被提问者采纳为最佳答案所得的积分
        /// </summary>

        public string dajiadf;

        /// <summary>
        /// 用户注册时获得的积分
        /// </summary>

        public string regf;

        /// <summary>
        /// 用户回答一个问题所得的积分
        /// </summary>

        public string dadf;

        /// <summary>
        /// 问题被选为精华推荐提问者所得的积分
        /// </summary>
        public string tjwendf;


        /// <summary>
        /// 问题被选为精华推荐最佳回答者所得的积分
        /// </summary>

        public string tjdadf;


        /// <summary>
        /// 用户匿名提问所需积分
        /// </summary>

        public string mdf;


        /// <summary>
        /// 问题15天内不处理所扣除的积分
        /// </summary>

        public string gqkf;


        /// <summary>
        /// 处理过期问题
        /// </summary>

        public string clwendf;

        /// <summary>
        /// 多少天后设为过期问题
        /// </summary>

        public string OverTime;
        /// <summary>
        ///  评论被删除后，评论者的积分将被扣除分
        /// </summary>


        public string plkf;
        /// <summary>
        /// 精华推荐数
        /// </summary>

        public string CommendNum;


        /// <summary>
        /// 近期热点数
        /// </summary>

        public string HotNum;


        /// <summary>
        /// 悬赏分问题数
        /// </summary>

        public string PointNum;


        /// <summary>
        /// 待解决的问题数
        /// </summary>

        public string StateNNum;

        /// <summary>
        /// 新解决的问题数
        /// </summary>
        public string StateYNum;

        /// <summary>
        /// 拼搏吧公告
        /// </summary>
        public string BarBulletin;
    }
    /// <summary>
    /// 彩票超市条数配置
    /// 创建人：小伟
    /// 创建时间：2010-11-15
    /// </summary>
    public struct MarketConfig
    {
       //--------------------------------首页设置------------------------
        /// <summary>
        /// 推荐项目，显示名称
        /// </summary>
        public string ItemName;
        /// <summary>
        /// 推荐项目，显示条数
        /// </summary>
        public string ItemCount;

        /// <summary>
        /// 商家排行 显示名称
        /// </summary>
        public string ShopName;
        /// <summary>
        /// 商家排行 显示条数
        /// </summary>
        public string ShopCount;

        /// <summary>
        /// 项目服务信息 显示名称
        /// </summary>
        public string ItemServerName;
        /// <summary>
        /// 项目服务信息 显示条数
        /// </summary>
        public string ItemServerCount;
        //-----------------------------------end-----------------------------

        //-----------------------------------其他页设置----------------------
        /// <summary>
        /// 彩种详细信息 显示名称
        /// </summary>
        public string ParticularName;
        /// <summary>
        /// 彩种详细信息 显示条数
        /// </summary>
        public string ParticularCount;

    }

    /// <summary>
    /// 平台开奖时间配置
    /// 2013-01-04
    /// zhouwei
    /// </summary>
    public struct PlatformTimeConfig
    {
        //3D 开奖时间
        public string FC3DDataTime;

        //七乐彩开奖时间
        public string FC7LCTime;

        //双色球开奖时间
        public string FCSSDataTime;

        //排列3 5开奖时间
        public string TCPL35DataTime;

        //七星彩开奖时间
        public string TC7XCDataTime;

        //大乐透开奖时间
        public string TCDLTDataTime;

        //强制执行开奖 设置
        public string LottCompulsory;

        //允许执行开奖页面时间
        public string ExecutionTime;

    }
    /// <summary>
    /// 平台彩种开奖截止时间设置
    /// 2013-01-09
    /// </summary>
    public struct PlatformEndTimeConfig
    { 
        //3D 开奖截止时间
        public string FC3DEndTime;

        //双色球 开奖截止时间
        public string FCSSQEndTime;

        //排列3 5 开奖截止时间
        public string TCPL35EndTime;
    }

    /// <summary>
    /// 大底平台-单选大底配置
    /// </summary>
    public struct SwitchConfig
    {
        //金币设置 
        public string Switch;

        //上传范围设置
        public string LeastRange;   //最小注数
        public string MaximumRange; //最大注数

        //单选大底 基数设置 1000底基数
        public string InTwo;   //2D 中2位最大数
        public string InOne;   //1D 中1位最大数
        public string InZero;  //0D 中0位最大数

        //设置上下限
        public string InTwoUpperlimit;   //2D上限
        public string InTwoLowerlimit;   //2D下限

        public string InOneUpperlimit;  //1D上限
        public string InOneLowerlimit;  //1D下限

        public string InZeroUpperlimit; //0D上限
        public string InZeroLowerlimit; //0D下限

        //所获积分设置
        public string IntegralTwo;  //2D
        public string IntegralOne;  //1D
        public string IntegralZero; //0D 
        public string IntegralGroup; //全中

        //所获金币设置
        public string CoinTwo;  //2D 
        public string CoinOne;  //1D
        public string CoinZero; //0D
        public string CoinGroup;  //全中
    }
    /// <summary>
    /// 大底平台-组选大底配置
    /// </summary>
    public struct GroupNumConfig
    {

        //上传范围设置
        public string LeastRange;   //最小注数
        public string MaximumRange; //最大注数

        //单选大底 基数设置 组6
        public string InTwo;   //2D 中2位最大数
        public string InOne;   //1D 中1位最大数
        public string InZero;  //0D 中0位最大数

        //单选大底 基数设置 组3
        public string InTwozt;   //2D 中2位最大数
        public string InOnezt;   //1D 中1位最大数
        public string InZerozt;  //0D 中0位最大数

        //单选大底 基数设置 豹子
        public string InTwobz;   //2D 中2位最大数
        public string InOnebz;   //1D 中1位最大数
        public string InZerobz;  //0D 中0位最大数

        //设置上下限
        public string InTwoUpperlimit;   //2D上限
        public string InTwoLowerlimit;   //2D下限

        public string InOneUpperlimit;  //1D上限
        public string InOneLowerlimit;  //1D下限

        public string InZeroUpperlimit; //0D上限
        public string InZeroLowerlimit; //0D下限

        //所获积分设置
        public string IntegralTwo;  //2D
        public string IntegralOne;  //1D
        public string IntegralZero; //0D 
        public string IntegralGroup; //全中

        //所获金币设置
        public string CoinTwo;  //2D 
        public string CoinOne;  //1D
        public string CoinZero; //0D
        public string CoinGroup;  //全中
    }
    /// <summary>
    /// 擂台XML设置参数
    /// </summary>
    public struct lottIntegral
    {
        public string h3HitOne;
        public string h3HitTwo;
        public string h3HitThree;

        public string h6HitOne;
        public string h6HitTwo;
        public string h6HitThree;
        public string h6HitFour;
        public string h6HitFive;
        public string h6HitSix;

        public string s3hHit;

        public string s6hHit;

        public string lHit;

        public string l3Hit;

        public string s3lHit;

        public string s6lHit;


        public string h3l61Hit;
        public string h3l60Hit;
        public string h3l51Hit;
        public string h3l50Hit;
        public string h3l41Hit;
        public string h3l40Hit;
        public string h3l31Hit;
        public string h3l30Hit;
        public string h3l21Hit;
        public string h3l20Hit;
        public string h3l11Hit;
        public string h3l01Hit;

        public string h2l61Hit;
        public string h2l60Hit;
        public string h2l51Hit;
        public string h2l50Hit;
        public string h2l41Hit;
        public string h2l40Hit;
        public string h2l31Hit;
        public string h2l30Hit;
        public string h2l21Hit;
        public string h2l20Hit;
        public string h2l11Hit;
        public string h2l01Hit;


        public string ddHit;

        public string sdHitOne;
        public string sdHitTwo;

        public string GroupHit;
        public string dirHit;

        public string sMHitOne;
        public string sMHitTwo;

        public string dKHit;

        public string dhHit;

        public string shHit;

        public string dw5Hit;
        public string dw3Hit;
        public string m5Hit;
    }

}
