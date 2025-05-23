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
    /// 业务逻辑类PBnet_QQ_Group 的摘要说明。
    /// </summary>
    public class PBnet_QQ_Group
    {
        private readonly IPBnet_QQ_Group dal = DataAccess.CreatePBnet_QQ_Group();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_QQ_Group", "ID");
        public PBnet_QQ_Group()
        { }
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
        public int Add(Pbzx.Model.PBnet_QQ_Group model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_QQ_Group model)
        {
            return dal.Update(model) > 0 ? true : false ;
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
        public Pbzx.Model.PBnet_QQ_Group GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Group GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_QQ_GroupModel-" + ID;
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
            return (Pbzx.Model.PBnet_QQ_Group)objModel;
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
        public List<Pbzx.Model.PBnet_QQ_Group> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_QQ_Group> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_QQ_Group> modelList = new List<Pbzx.Model.PBnet_QQ_Group>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_QQ_Group model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_QQ_Group();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.QQ_GroupID = dt.Rows[n]["QQ_GroupID"].ToString();
                    model.QQ_GroupName = dt.Rows[n]["QQ_GroupName"].ToString();
                    if (dt.Rows[n]["QQ_GroupType"].ToString() != "")
                    {
                        model.QQ_GroupType = int.Parse(dt.Rows[n]["QQ_GroupType"].ToString());
                    }
                    if (dt.Rows[n]["IsSoftGroup"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsSoftGroup"].ToString() == "1") || (dt.Rows[n]["IsSoftGroup"].ToString().ToLower() == "true"))
                        {
                            model.IsSoftGroup = true;
                        }
                        else
                        {
                            model.IsSoftGroup = false;
                        }
                    }
                    model.QQ_GroupAdmin = dt.Rows[n]["QQ_GroupAdmin"].ToString();
                    model.QQ_GroupDetails = dt.Rows[n]["QQ_GroupDetails"].ToString();
                    if (dt.Rows[n]["IsEnable"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsEnable"].ToString() == "1") || (dt.Rows[n]["IsEnable"].ToString().ToLower() == "true"))
                        {
                            model.IsEnable = true;
                        }
                        else
                        {
                            model.IsEnable = false;
                        }
                    }
                    if (dt.Rows[n]["SortID"].ToString() != "")
                    {
                        model.SortID = int.Parse(dt.Rows[n]["SortID"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
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

        /// <summary>
        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_QQ_Group", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


    }
}

