using System;
using System.Collections.Generic;
using System.Text;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Data;

namespace Pbzx.BLL
{
    public class CM_MainManager
    {
        private readonly ICM_Main dal = DataAccess.CreateCM_Main();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CM_Main", "ID");
        public CM_MainManager()
        {
            basicDAL.IsCst = true;

        }
        #region
        /// <summary>
        /// ����ID�ж������Ƿ����
        /// </summary>
        /// <param name="ID">ID���</param>
        /// <returns>boolֵ���ҵ�����true ����Ϊ false</returns>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
                /// <summary>
        /// ��Ϣ��ӷ���
        /// </summary>
        /// <param name="main">��Ϣ����</param>
        /// <returns>������Ӻ��ID</returns>
        public int Add(Pbzx.Model.CM_Main main)
        {
            return dal.Add(main); 
        }
                /// <summary>
        /// ��Ϣ���·���
        /// </summary>
        /// <param name="main">��Ϣ����</param>
        /// <returns>����1�� 0</returns>
        public bool Update(Pbzx.Model.CM_Main main)
        {
            return dal.Update(main) > 0 ? true : false;
        }
        /// <summary>
        /// ɾ����Ϣ�ķ���
        /// </summary>
        /// <param name="ID">��ϢID</param>
        /// <returns>�ɹ�Ϊ1 ʧ��Ϊ 0</returns>
        public bool Delete(int ID)
        {
            return dal.Delete(ID) > 0 ? true : false; 
        }
        
        /// <summary>
        /// ������ϢID �õ�����ʵ�����
        /// </summary>
        /// <param name="ID">��ϢID</param>
        /// <returns>��Ϣ����</returns>
        public Pbzx.Model.CM_Main GetMain(int ID)
        {
            return dal.GetMain(ID);
        }
                /// <summary>
        /// ��������������������Ϣ1
        /// </summary>
        /// <param name="strWhere">��Ϣ����</param>
        /// <returns>���ݱ�</returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        ///���ػ�������б�2û������
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }
        #endregion

        #region
        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch("ID", "CM_Main", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion
    }
}
