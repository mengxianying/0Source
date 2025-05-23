using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 实体类CM_Main
/// 新版消息管理
/// 2010-9-16
/// </summary>
namespace Pbzx.Model
{
    [Serializable]
    public class CM_Main
    {
        private int id;   //编号ID 

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string softInfo; //软件限定信息

        public string SoftInfo
        {
            get { return softInfo; }
            set { softInfo = value; }
        }

        private string regType;  //注册限定信息

        public string RegType
        {
            get { return regType; }
            set { regType = value; }
        }

        private string userClass; //用户限定信息

        public string UserClass
        {
            get { return userClass; }
            set { userClass = value; }
        }

        private string sender;  //发布人

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private int mtype; //类型（1普通消息，2.紧急消息3.网页消息.4.最新咨询）

        public int Mtype
        {
            get { return mtype; }
            set { mtype = value; }
        }

        private string category; //类别

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private int state;   //状态 0.未发布，1已发布

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        private DateTime postTime;  //发布时间

        public DateTime PostTime
        {
            get { return postTime; }
            set { postTime = value; }
        }

        private DateTime beginTime; //开始时间

        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;  //结束时间

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private string title;    //标题

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string contentURL; //内容静态页URL地址（以 http:开头）

        public string ContentURL
        {
            get { return contentURL; }
            set { contentURL = value; }
        }

        private DateTime lastTime; //最后访问时间

        public DateTime LastTime
        {
            get { return lastTime; }
            set { lastTime = value; }
        }

        private int todayCount; //今日访问次数

        public int TodayCount
        {
            get { return todayCount; }
            set { todayCount = value; }
        }

        private int totalCount; //总访问次数

        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        private string content; //消息内容

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        /// <summary>
        /// 消息宽度
        /// </summary>
        private int webWidth;

        public int WebWidth
        {
            get { return webWidth; }
            set { webWidth = value; }
        }
        /// <summary>
        /// 消息高度
        /// </summary>
        private int webHeight;

        public int WebHeight
        {
            get { return webHeight; }
            set { webHeight = value; }
        }
        /// <summary>
        /// 消息标题和内容的链接
        /// </summary>
        private string linkurl;

        public string Linkurl
        {
            get { return linkurl; }
            set { linkurl = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string hDSN;

        public string HDSN
        {
            get { return hDSN; }
            set { hDSN = value; }
        }

        /// <summary>
        /// 彩种名称
        /// </summary>
        private string softwareName;

        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }

    }
}
