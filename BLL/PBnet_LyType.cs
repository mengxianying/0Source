using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.DALFactory;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_LyType ��ժҪ˵����
    /// </summary>
    public class PBnet_LyType
    {
        private readonly IPBnet_LyType dal = DataAccess.CreatePBnet_LyType();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_LyType", "ID");
        public PBnet_LyType()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_LyType model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_LyType model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_LyType GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_LyType GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_LyTypeModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_LyType)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_LyType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_LyType> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_LyType> modelList = new List<Pbzx.Model.PBnet_LyType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_LyType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_LyType();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    if (dt.Rows[n]["IsAuditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAuditing"].ToString() == "1") || (dt.Rows[n]["IsAuditing"].ToString().ToLower() == "true"))
                        {
                            model.IsAuditing = true;
                        }
                        else
                        {
                            model.IsAuditing = false;
                        }
                    }
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        //�õ�
        public DataTable GetListBySort()
        {
            return basicDAL.GetLisBySql("SELECT * FROM PBnet_LyType ORDER BY OrderID ASC");
        }

        /// <summary>
        /// �ı����״̬
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filed"></param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_LyType", "ID");
            basicDAL1.ChangeAudit(id, filed);
        }
    }
}
