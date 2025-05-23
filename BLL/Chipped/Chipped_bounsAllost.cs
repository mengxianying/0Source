using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Chipped_bounsAllost ��ժҪ˵����
    /// </summary>
    public class Chipped_bounsAllost
    {
        private static readonly IChipped_bounsAllost dal = DataAccess.CreateChipped_bounsAllost();
        public Chipped_bounsAllost()
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
        public bool Exists(string AwardNum, string AwardName, int lotteryState)
        {
            return dal.Exists(AwardNum,AwardName,lotteryState);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Chipped_bounsAllost model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.Chipped_bounsAllost model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string AwardNum)
        {
            dal.Delete(AwardNum);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_bounsAllost GetModel(int ID)
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
