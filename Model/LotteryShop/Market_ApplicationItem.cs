using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    ///添加项目信息模型类
    /// 添加人：杨良伟
    ///2010-10-25 
    /// </summary>
    [Serializable]
    public class Market_ApplicationItem
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 彩种对象
        /// </summary>
        private PBnet_LotteryMenu applotteryid;

        public PBnet_LotteryMenu Applotteryid
        {
            get { return applotteryid; }
            set { applotteryid = value; }
        }
        /// <summary>
        /// 项目类别
        /// </summary>
        private string itemname;

        public string Itemname
        {
            get { return itemname; }
            set { itemname = value; }
        }
        /// <summary>
        /// 用户对象
        /// </summary>
        private PBnet_UserTable appuserid;

        public PBnet_UserTable Appuserid
        {
            get { return appuserid; }
            set { appuserid = value; }
        }
        /// <summary>
        /// 玩法说明
        /// </summary>
        private string itemviscera;

        public string Itemviscera
        {
            get { return itemviscera; }
            set { itemviscera = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime applicationtime;

        public DateTime Applicationtime
        {
            get { return applicationtime; }
            set { applicationtime = value; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        private int fettlenumber;

        public int Fettlenumber
        {
            get { return fettlenumber; }
            set { fettlenumber = value; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        private string gloze;

        public string Gloze
        {
            get { return gloze; }
            set { gloze = value; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>
        private DateTime replytime;

        public DateTime Replytime
        {
            get { return replytime; }
            set { replytime = value; }
        }
        /// <summary>
        /// 是否共同使用
        /// </summary>
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
