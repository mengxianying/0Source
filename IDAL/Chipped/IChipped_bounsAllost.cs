using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IChipped_bounsAllost ��ժҪ˵����
    /// </summary>
    public interface IChipped_bounsAllost
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string AwardNum, string AwardName, int lotteryState);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Chipped_bounsAllost model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.Chipped_bounsAllost model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(string AwardNum);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Chipped_bounsAllost GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
