using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IChallenge_integral ��ժҪ˵����
    /// </summary>
    public interface IChallenge_integral
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int I_id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Challenge_integral model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(Pbzx.Model.Challenge_integral model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int I_id);
        bool DeleteList(string I_idlist);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Challenge_integral GetModel(int I_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);

        //DataSet GetRank(string strWhere,string TempWhere);
        /// <summary>
        /// //���� ������ͬͳ��
        /// </summary>
        /// <param name="V_table">��ͼ����</param>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        DataSet RankSSq(string V_table, string strWhere);

        /// <summary>
        /// ���ǰ���� �� ��������
        /// </summary>
        /// <param name="V_table">��ͼ����</param>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        DataSet RankSSq(int Top, string V_table, string strWhere);
        /// <summary>
        /// ˫ɫ����ֲ�ѯ
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        DataSet selectRankS(string strWhere);
        #endregion  ��Ա����
    }
}
