using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;
using Pbzx.Common;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���DataRivalry_UpLoadFile ��ժҪ˵����
    /// </summary>
    public class DataRivalry_UpLoadFile
    {
        private static readonly IDataRivalry_UpLoadFile dal = DataAccess.CreateDataRivalry_UpLoadFile();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_d_num", "F_drID");
        public DataRivalry_UpLoadFile()
        { }
        #region  ��Ա����


        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int F_drID)
        {
            return dal.Exists(F_drID);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="FileName">�ļ���</param>
        /// <returns></returns>
        public bool Exists(string UserName, string FileName, int FileSize)
        {
            return dal.Exists(UserName, FileName, FileSize);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_UpLoadFile model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_UpLoadFile model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int F_drID)
        {
            return dal.Delete(F_drID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.DataRivalry_UpLoadFile GetModel(int F_drID)
        {
            return dal.GetModel(F_drID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetListDesc(string strWhere)
        {
            return dal.GetListDesc(strWhere);
        }
        public DataSet GetListView(string strWhere)
        {
            return dal.GetListView(strWhere);
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <param name="playName"></param>
        /// <returns></returns>
        public string AllowTime(string playName)
        {
            string dt = "";
            //3D
            if (playName == "1")
            {
                dt = Pbzx.Common.Method.GetFCDateTime.ToString();
            }
            ////˫ɫ��
            //if (playName == "3")
            //{
            //    dt = Pbzx.Common.Method.GetSSQDateTime.ToString();
            //}
            //��������
            if (playName == "4")
            {
                dt = Pbzx.Common.Method.GetTCPL35DateTime.ToString();
            }
            return dt;
        }
        /// <summary>
        /// ��ѯ��ǰ�ں�
        /// </summary>
        /// <param name="lottID">���ֱ��</param>
        /// <returns></returns>
        public string Period(int lottID)
        {
           
            string issue = Pbzx.BLL.publicMethod.Period(lottID);
            return issue;
        }
        /// <summary>
        /// ��ѯ3D��������
        /// </summary>
        /// <param name="issue">�ں�</param>
        /// <returns></returns>
        public string SelectlottNum(int issue,int lottID)
        {
            string wNum = Method.RlotteryNum(lottID, issue);
            if (wNum != "")
            {
                string num = wNum;
                return num;
            }
            return "";
        }


        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2010-10-27
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchUp(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_d_num", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  ��Ա����
    }
}
