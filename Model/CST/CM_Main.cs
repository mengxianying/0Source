using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ʵ����CM_Main
/// �°���Ϣ����
/// 2010-9-16
/// </summary>
namespace Pbzx.Model
{
    [Serializable]
    public class CM_Main
    {
        private int id;   //���ID 

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string softInfo; //����޶���Ϣ

        public string SoftInfo
        {
            get { return softInfo; }
            set { softInfo = value; }
        }

        private string regType;  //ע���޶���Ϣ

        public string RegType
        {
            get { return regType; }
            set { regType = value; }
        }

        private string userClass; //�û��޶���Ϣ

        public string UserClass
        {
            get { return userClass; }
            set { userClass = value; }
        }

        private string sender;  //������

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private int mtype; //���ͣ�1��ͨ��Ϣ��2.������Ϣ3.��ҳ��Ϣ.4.������ѯ��

        public int Mtype
        {
            get { return mtype; }
            set { mtype = value; }
        }

        private string category; //���

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private int state;   //״̬ 0.δ������1�ѷ���

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        private DateTime postTime;  //����ʱ��

        public DateTime PostTime
        {
            get { return postTime; }
            set { postTime = value; }
        }

        private DateTime beginTime; //��ʼʱ��

        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;  //����ʱ��

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private string title;    //����

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string contentURL; //���ݾ�̬ҳURL��ַ���� http:��ͷ��

        public string ContentURL
        {
            get { return contentURL; }
            set { contentURL = value; }
        }

        private DateTime lastTime; //������ʱ��

        public DateTime LastTime
        {
            get { return lastTime; }
            set { lastTime = value; }
        }

        private int todayCount; //���շ��ʴ���

        public int TodayCount
        {
            get { return todayCount; }
            set { todayCount = value; }
        }

        private int totalCount; //�ܷ��ʴ���

        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        private string content; //��Ϣ����

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        /// <summary>
        /// ��Ϣ���
        /// </summary>
        private int webWidth;

        public int WebWidth
        {
            get { return webWidth; }
            set { webWidth = value; }
        }
        /// <summary>
        /// ��Ϣ�߶�
        /// </summary>
        private int webHeight;

        public int WebHeight
        {
            get { return webHeight; }
            set { webHeight = value; }
        }
        /// <summary>
        /// ��Ϣ��������ݵ�����
        /// </summary>
        private string linkurl;

        public string Linkurl
        {
            get { return linkurl; }
            set { linkurl = value; }
        }
        /// <summary>
        /// �û�����
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
        /// ��������
        /// </summary>
        private string softwareName;

        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }

    }
}
