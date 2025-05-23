using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���FC7LC ��ժҪ˵����
    /// </summary>
    public class FC7LC
    {
        private readonly IFC7LC dal = DataAccess.CreateFC7LC();
        public FC7LC()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.FC7LC model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.FC7LC model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(string issue)
        {
            return dal.Delete(issue) > 0 ? true : false; 
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.FC7LC GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.FC7LC GetModelByCache(string issue)
        {

            string CacheKey = "FC7LCModel-" + issue;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(issue);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.FC7LC)objModel;
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
        public List<Pbzx.Model.FC7LC> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.FC7LC> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.FC7LC> modelList = new List<Pbzx.Model.FC7LC>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.FC7LC model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.FC7LC();
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    model.issue = dt.Rows[n]["issue"].ToString();
                    model.code = dt.Rows[n]["code"].ToString();
                    model.tcode = dt.Rows[n]["tcode"].ToString();
                    if (dt.Rows[n]["LastModifytime"].ToString() != "")
                    {
                        model.LastModifytime = DateTime.Parse(dt.Rows[n]["LastModifytime"].ToString());
                    }
                    model.OpName = dt.Rows[n]["OpName"].ToString();
                    model.OpIp = dt.Rows[n]["OpIp"].ToString();
                    if (dt.Rows[n]["Sales"].ToString() != "")
                    {
                        model.Sales = int.Parse(dt.Rows[n]["Sales"].ToString());
                    }
                    if (dt.Rows[n]["BonusPool"].ToString() != "")
                    {
                        model.BonusPool = int.Parse(dt.Rows[n]["BonusPool"].ToString());
                    }
                    if (dt.Rows[n]["Count1"].ToString() != "")
                    {
                        model.Count1 = int.Parse(dt.Rows[n]["Count1"].ToString());
                    }
                    if (dt.Rows[n]["Bonus1"].ToString() != "")
                    {
                        model.Bonus1 = int.Parse(dt.Rows[n]["Bonus1"].ToString());
                    }
                    if (dt.Rows[n]["Count2"].ToString() != "")
                    {
                        model.Count2 = int.Parse(dt.Rows[n]["Count2"].ToString());
                    }
                    if (dt.Rows[n]["Bonus2"].ToString() != "")
                    {
                        model.Bonus2 = int.Parse(dt.Rows[n]["Bonus2"].ToString());
                    }
                    if (dt.Rows[n]["Count3"].ToString() != "")
                    {
                        model.Count3 = int.Parse(dt.Rows[n]["Count3"].ToString());
                    }
                    if (dt.Rows[n]["Bonus3"].ToString() != "")
                    {
                        model.Bonus3 = int.Parse(dt.Rows[n]["Bonus3"].ToString());
                    }
                    if (dt.Rows[n]["Count4"].ToString() != "")
                    {
                        model.Count4 = int.Parse(dt.Rows[n]["Count4"].ToString());
                    }
                    if (dt.Rows[n]["Count5"].ToString() != "")
                    {
                        model.Count5 = int.Parse(dt.Rows[n]["Count5"].ToString());
                    }
                    if (dt.Rows[n]["Count6"].ToString() != "")
                    {
                        model.Count6 = int.Parse(dt.Rows[n]["Count6"].ToString());
                    }
                    if (dt.Rows[n]["Count7"].ToString() != "")
                    {
                        model.Count7 = int.Parse(dt.Rows[n]["Count7"].ToString());
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
    }
}

