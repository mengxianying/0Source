using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    ///�����Ŀ��Ϣģ����
    /// ����ˣ�����ΰ
    ///2010-10-25 
    /// </summary>
    [Serializable]
    public class Market_ApplicationItem
    {
        /// <summary>
        /// ���ID
        /// </summary>
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// ���ֶ���
        /// </summary>
        private PBnet_LotteryMenu applotteryid;

        public PBnet_LotteryMenu Applotteryid
        {
            get { return applotteryid; }
            set { applotteryid = value; }
        }
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        private string itemname;

        public string Itemname
        {
            get { return itemname; }
            set { itemname = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        private PBnet_UserTable appuserid;

        public PBnet_UserTable Appuserid
        {
            get { return appuserid; }
            set { appuserid = value; }
        }
        /// <summary>
        /// �淨˵��
        /// </summary>
        private string itemviscera;

        public string Itemviscera
        {
            get { return itemviscera; }
            set { itemviscera = value; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        private DateTime applicationtime;

        public DateTime Applicationtime
        {
            get { return applicationtime; }
            set { applicationtime = value; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        private int fettlenumber;

        public int Fettlenumber
        {
            get { return fettlenumber; }
            set { fettlenumber = value; }
        }
        /// <summary>
        /// �ظ�����
        /// </summary>
        private string gloze;

        public string Gloze
        {
            get { return gloze; }
            set { gloze = value; }
        }
        /// <summary>
        /// �ظ�ʱ��
        /// </summary>
        private DateTime replytime;

        public DateTime Replytime
        {
            get { return replytime; }
            set { replytime = value; }
        }
        /// <summary>
        /// �Ƿ�ͬʹ��
        /// </summary>
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
