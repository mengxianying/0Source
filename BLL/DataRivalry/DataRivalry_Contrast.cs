using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���DataRivalry_Contrast ��ժҪ˵����
    /// </summary>
    public class DataRivalry_Contrast
    {
        private static readonly IDataRivalry_Contrast dal = DataAccess.CreateDataRivalry_Contrast();
        
        public DataRivalry_Contrast()
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
        public bool Exists(int ct_id)
        {
            return dal.Exists(ct_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Contrast model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Contrast model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ct_id)
        {
            return dal.Delete(ct_id);
        }

        /// <summary>
        /// ɾ��һ������ ������Ϣ��ID 
        /// </summary>
        public int DeleteJoint(int Ct_drID)
        {
            return dal.DeleteJoint(Ct_drID);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.DataRivalry_Contrast GetModel(int ct_id)
        {
            return dal.GetModel(ct_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

       

        #endregion  ��Ա����
    }
}