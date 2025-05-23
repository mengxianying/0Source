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
    public class CM_MainBySoftwareTypeManager
    {
        private readonly ICM_MainBySoftwareType dal = DataAccess.CreateCM_MainBySoftwareType();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CM_MainBySoftwareType", "ID");
        public CM_MainBySoftwareTypeManager()
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
        public int Add(Pbzx.Model.CM_MainBySoftwareType main)
        {
            return dal.Add(main);
        }
        /// <summary>
        /// ��Ϣ���·���
        /// </summary>
        /// <param name="main">��Ϣ����</param>
        /// <returns>����1�� 0</returns>
        public bool Update(Pbzx.Model.CM_MainBySoftwareType main)
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
        public Pbzx.Model.CM_MainBySoftwareType GetMain(int ID)
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

        /// <summary>
        /// ����cmidɾ��
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteByCM_ID(int ID)
        {
            return dal.DeleteByCM_ID(ID);
        }
        #endregion
    }
}
