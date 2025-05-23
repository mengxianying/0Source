using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;
using System.IO;


namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���DataRivalry_downLoad ��ժҪ˵����
    /// </summary>
    public class DataRivalry_downLoad
    {
        private static readonly IDataRivalry_downLoad dal = DataAccess.CreateDataRivalry_downLoad();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_DataRivalry_download", "F_drID");
        Pbzx.SQLServerDAL.Basic basicDALD = new Pbzx.SQLServerDAL.Basic("v_downloadNum", "F_drID");
        public DataRivalry_downLoad()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Dl_id)
        {
            return dal.Exists(Dl_id);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="Dl_ufID">��׵�ID</param>
        /// <param name="Dl_name">��Ա����</param>
        /// <returns></returns>
        public bool Exists(int Dl_ufID, string Dl_name)
        {
            return dal.Exists(Dl_ufID, Dl_name);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_downLoad model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_downLoad model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Dl_id)
        {
            return dal.Delete(Dl_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.DataRivalry_downLoad GetModel(int Dl_id)
        {
            return dal.GetModel(Dl_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
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

        public DataTable GuestGetBySearchdownLoad(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_DataRivalry_download", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2012-08-20
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchdownD(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDALD.GuestGetBySearch(basicDAL.strPKName, "v_downloadNum", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  ��Ա����
    }
}
