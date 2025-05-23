using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Chipped_winning ��ժҪ˵����
    /// </summary>
    public class Chipped_winning
    {
        private static readonly IChipped_winning dal = DataAccess.CreateChipped_winning();
        public Chipped_winning()
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
        public bool Exists(string Qnum)
        {
            return dal.Exists(Qnum);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Chipped_winning model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.Chipped_winning model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_winning GetModel(int ID)
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

        #endregion  ��Ա����
    }
}


