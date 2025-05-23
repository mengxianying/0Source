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
    /// ҵ���߼���FC3DData ��ժҪ˵����
    /// </summary>
    public class FC3DData
    {
        private readonly IFC3DData dal = DataAccess.CreateFC3DData();
        public FC3DData()
        {
        }
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
        public bool Add(Pbzx.Model.FC3DData model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.FC3DData model)
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
        public Pbzx.Model.FC3DData GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.FC3DData GetModelByCache(string issue)
        {

            string CacheKey = "FC3DDataModel-" + issue;
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
            return (Pbzx.Model.FC3DData)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.FC3DData> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.FC3DData> modelList = new List<Pbzx.Model.FC3DData>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.FC3DData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.FC3DData();
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    model.issue = dt.Rows[n]["issue"].ToString();
                    model.testcode = dt.Rows[n]["testcode"].ToString();
                    model.code = dt.Rows[n]["code"].ToString();
                    if (dt.Rows[n]["machine"].ToString() != "")
                    {
                        model.machine = int.Parse(dt.Rows[n]["machine"].ToString());
                    }
                    if (dt.Rows[n]["ball"].ToString() != "")
                    {
                        model.ball = int.Parse(dt.Rows[n]["ball"].ToString());
                    }
                    if (dt.Rows[n]["DXCount"].ToString() != "")
                    {
                        model.DXCount = int.Parse(dt.Rows[n]["DXCount"].ToString());
                    }
                    if (dt.Rows[n]["Z3Count"].ToString() != "")
                    {
                        model.Z3Count = int.Parse(dt.Rows[n]["Z3Count"].ToString());
                    }
                    if (dt.Rows[n]["Z6Count"].ToString() != "")
                    {
                        model.Z6Count = int.Parse(dt.Rows[n]["Z6Count"].ToString());
                    }
                    if (dt.Rows[n]["Sales"].ToString() != "")
                    {
                        model.Sales = int.Parse(dt.Rows[n]["Sales"].ToString());
                    }
                    if (dt.Rows[n]["Bonus"].ToString() != "")
                    {
                        model.Bonus = int.Parse(dt.Rows[n]["Bonus"].ToString());
                    }
                    model.TestOrderB = dt.Rows[n]["TestOrderB"].ToString();
                    model.TestOrderS = dt.Rows[n]["TestOrderS"].ToString();
                    model.TestOrderG = dt.Rows[n]["TestOrderG"].ToString();
                    if (dt.Rows[n]["LastModifyTime"].ToString() != "")
                    {
                        model.LastModifyTime = DateTime.Parse(dt.Rows[n]["LastModifyTime"].ToString());
                    }
                    model.OpName = dt.Rows[n]["OpName"].ToString();
                    model.OpIp = dt.Rows[n]["OpIp"].ToString();
                    model.CodeOrderB = dt.Rows[n]["CodeOrderB"].ToString();
                    model.CodeOrderS = dt.Rows[n]["CodeOrderS"].ToString();
                    model.CodeOrderG = dt.Rows[n]["CodeOrderG"].ToString();
                    model.AttentionCode = dt.Rows[n]["AttentionCode"].ToString();
                    model.decode = dt.Rows[n]["decode"].ToString();
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

