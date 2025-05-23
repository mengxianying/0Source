using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Help_Contrast ��ժҪ˵����
    /// </summary>
    public class Help_Contrast
    {
        private static readonly IHelp_Contrast dal = DataAccess.CreateHelp_Contrast();
        public Help_Contrast()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Ct_id)
        {
            return dal.Exists(Ct_id);
        }
        public bool Exists(string Ct_TreeNum, string Ct_software)
        {
            return dal.Exists(Ct_TreeNum, Ct_software);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Help_Contrast model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Help_Contrast model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Ct_id)
        {
            return dal.Delete(Ct_id);
        }
        public int DeleteID(int Ct_TreeNum)
        {
            return dal.DeleteID(Ct_TreeNum);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Help_Contrast GetModel(int Ct_id)
        {
            return dal.GetModel(Ct_id);
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

