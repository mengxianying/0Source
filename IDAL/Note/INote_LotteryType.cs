using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�INote_LotteryType ��ժҪ˵����
    /// </summary>
    public interface INote_LotteryType
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int SID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Note_LotteryType model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Note_LotteryType model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int SID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Note_LotteryType GetModel(int SID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
