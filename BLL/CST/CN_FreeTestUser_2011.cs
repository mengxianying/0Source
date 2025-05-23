using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���CN_FreeTestUser ��ժҪ˵����
    /// </summary>
    public class CN_FreeTestUser_2011
    {

        private static readonly ICN_FreeTestUser_2011 dal = DataAccess.CreateCN_FreeTestUser_2011();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_FreeTestUser2011", "ID");

        public CN_FreeTestUser_2011()
        {
            basicDAL.IsCst = true;
        }
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
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.CN_FreeTestUser2011 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.CN_FreeTestUser2011 model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CN_FreeTestUser2011 GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }



        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_FreeTestUser2011", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  ��Ա����
    }
}

