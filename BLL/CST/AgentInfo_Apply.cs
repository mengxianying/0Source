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
    /// 业务逻辑类AgentInfo_Apply 的摘要说明。
    /// </summary>
    public class AgentInfo_Apply
    {
        private readonly IAgentInfo_Apply dal = DataAccess.CreateAgentInfo_Apply();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("AgentInfo_Apply", "ID");

        public AgentInfo_Apply()
        {
            basicDAL.IsCst = true;
        }
       
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.AgentInfo_Apply model)
        {
           return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.AgentInfo_Apply model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.AgentInfo_Apply GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.AgentInfo_Apply GetModelByCache(int ID)
        {

            string CacheKey = "AgentInfo_ApplyModel-" + ID;
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
            return (Pbzx.Model.AgentInfo_Apply)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.AgentInfo_Apply> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.AgentInfo_Apply> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.AgentInfo_Apply> modelList = new List<Pbzx.Model.AgentInfo_Apply>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.AgentInfo_Apply model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.AgentInfo_Apply();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Company = dt.Rows[n]["Company"].ToString();
                    model.Telephone = dt.Rows[n]["Telephone"].ToString();
                    model.Fax = dt.Rows[n]["Fax"].ToString();
                    model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    model.EMail = dt.Rows[n]["EMail"].ToString();
                    model.PostCode = dt.Rows[n]["PostCode"].ToString();
                    model.Province = dt.Rows[n]["Province"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(dt.Rows[n]["ExpireDate"].ToString());
                    }
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    if (dt.Rows[n]["PricePercent"].ToString() != "")
                    {
                        model.PricePercent = int.Parse(dt.Rows[n]["PricePercent"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["delshow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["delshow"].ToString() == "1") || (dt.Rows[n]["delshow"].ToString().ToLower() == "true"))
                        {
                            model.delshow = true;
                        }
                        else
                        {
                            model.delshow = false;
                        }
                    }
                    if (dt.Rows[n]["countid"].ToString() != "")
                    {
                        model.countid = int.Parse(dt.Rows[n]["countid"].ToString());
                    }
                    model.agtmore = dt.Rows[n]["agtmore"].ToString();
                    model.postmore = dt.Rows[n]["postmore"].ToString();
                    model.agttype = dt.Rows[n]["agttype"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        #endregion  成员方法     
        ////生成添加新的代理编号

        public int GetNewID()
        {
            return int.Parse(basicDAL.GetValueBySql("select top 1 ID from AgentInfo_Apply Order By ID  Desc").ToString()) + 1;

        }


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "[Pinble_Cst].dbo.AgentInfo_Apply", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        public DataTable GetLisBySql(string strSql)
        {
            return basicDAL.GetLisBySql(strSql);
        }
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public void ChangeAudit(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public void ChangeState(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }
    }
}

