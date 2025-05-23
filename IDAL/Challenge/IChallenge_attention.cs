using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IChallenge_attention ��ժҪ˵����
    /// </summary>
    public interface IChallenge_attention
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Att_id);
        bool Exists(string name);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Challenge_attention model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Challenge_attention model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Att_id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Challenge_attention GetModel(int Att_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
