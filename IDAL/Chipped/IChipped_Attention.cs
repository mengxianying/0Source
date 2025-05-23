using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IChipped_Attention ��ժҪ˵����
	/// </summary>
	public interface IChipped_Attention
	{
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int id);
        bool Exists(string AName, string AttentionName);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Chipped_Attention model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.Chipped_Attention model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(string name);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Chipped_Attention GetModel(int id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
	}
}

