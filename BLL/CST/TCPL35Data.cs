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
    /// ҵ���߼���TCPL35Data ��ժҪ˵����
    /// </summary>
    public class TCPL35Data
    {
        private readonly ITCPL35Data dal = DataAccess.CreateTCPL35Data();
        public TCPL35Data()
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
        public void Add(Pbzx.Model.TCPL35Data model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.TCPL35Data model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string issue)
        {

            dal.Delete(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.TCPL35Data GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.TCPL35Data GetModelByCache(string issue)
        {

            string CacheKey = "TCPL35DataModel-" + issue;
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
            return (Pbzx.Model.TCPL35Data)objModel;
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
        public List<Pbzx.Model.TCPL35Data> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.TCPL35Data> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.TCPL35Data> modelList = new List<Pbzx.Model.TCPL35Data>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.TCPL35Data model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.TCPL35Data();
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    model.issue = dt.Rows[n]["issue"].ToString();
                    model.code3 = dt.Rows[n]["code3"].ToString();
                    model.code5 = dt.Rows[n]["code5"].ToString();
                    model.testcode = dt.Rows[n]["testcode"].ToString();
                    if (dt.Rows[n]["machine"].ToString() != "")
                    {
                        model.machine = int.Parse(dt.Rows[n]["machine"].ToString());
                    }
                    if (dt.Rows[n]["ball"].ToString() != "")
                    {
                        model.ball = int.Parse(dt.Rows[n]["ball"].ToString());
                    }
                    if (dt.Rows[n]["LastModifyTime"].ToString() != "")
                    {
                        model.LastModifyTime = DateTime.Parse(dt.Rows[n]["LastModifyTime"].ToString());
                    }
                    model.OpName = dt.Rows[n]["OpName"].ToString();
                    model.OpIp = dt.Rows[n]["OpIp"].ToString();
                    if (dt.Rows[n]["P3Sales"].ToString() != "")
                    {
                        model.P3Sales = int.Parse(dt.Rows[n]["P3Sales"].ToString());
                    }
                    if (dt.Rows[n]["DxCount"].ToString() != "")
                    {
                        model.DxCount = int.Parse(dt.Rows[n]["DxCount"].ToString());
                    }
                    if (dt.Rows[n]["Z3Count"].ToString() != "")
                    {
                        model.Z3Count = int.Parse(dt.Rows[n]["Z3Count"].ToString());
                    }
                    if (dt.Rows[n]["Z6Count"].ToString() != "")
                    {
                        model.Z6Count = int.Parse(dt.Rows[n]["Z6Count"].ToString());
                    }
                    if (dt.Rows[n]["P5Sales"].ToString() != "")
                    {
                        model.P5Sales = int.Parse(dt.Rows[n]["P5Sales"].ToString());
                    }
                    if (dt.Rows[n]["P5Count"].ToString() != "")
                    {
                        model.P5Count = int.Parse(dt.Rows[n]["P5Count"].ToString());
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

