using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.DALFactory;
using System.Data;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Challenge_attention ��ժҪ˵����
    /// </summary>
    public class Challenge_attention
    {
        private static readonly IChallenge_attention dal = DataAccess.CreateChallenge_attention();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Challenge_attention", "Att_id");
        public Challenge_attention()
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
        public bool Exists(int Att_id)
        {
            return dal.Exists(Att_id);
        }
        public bool Exists(string name)
        {
            return dal.Exists(name);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Challenge_attention model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Challenge_attention model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Att_id)
        {
            return dal.Delete(Att_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Challenge_attention GetModel(int Att_id)
        {
            return dal.GetModel(Att_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2010-10-27
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Challenge_attention", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  ��Ա����
    }
}