using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���DataRivalry_Level ��ժҪ˵����
    /// </summary>
    public class DataRivalry_Level
    {
        private static readonly IDataRivalry_Level dal = DataAccess.CreateDataRivalry_Level();
        public DataRivalry_Level()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Le_id)
        {
            return dal.Exists(Le_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Level model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Level model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Le_id)
        {
            return dal.Delete(Le_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.DataRivalry_Level GetModel(int Le_id)
        {
            return dal.GetModel(Le_id);
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
