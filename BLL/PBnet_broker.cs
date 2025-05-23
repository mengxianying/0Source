using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web.UI.WebControls;
using System.Text;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_broker 的摘要说明。
    /// </summary>
    public class PBnet_broker
    {
        private readonly IPBnet_broker dal = DataAccess.CreatePBnet_broker();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_broker", "Id");
        public PBnet_broker()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_broker model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_broker model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_broker GetModelByCache(int Id)
        {

            string CacheKey = "PBnet_brokerModel-" + Id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_broker)objModel;
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
        public List<Pbzx.Model.PBnet_broker> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_broker> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_broker> modelList = new List<Pbzx.Model.PBnet_broker>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_broker model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_broker();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["Pass_time"].ToString() != "")
                    {
                        model.Pass_time = DateTime.Parse(dt.Rows[n]["Pass_time"].ToString());
                    }
                    if (dt.Rows[n]["LastLogin_time"].ToString() != "")
                    {
                        model.LastLogin_time = DateTime.Parse(dt.Rows[n]["LastLogin_time"].ToString());
                    }
                    if (dt.Rows[n]["Apply_time"].ToString() != "")
                    {
                        model.Apply_time = DateTime.Parse(dt.Rows[n]["Apply_time"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    model.Discount_gradeName = dt.Rows[n]["Discount_gradeName"].ToString();
                    if (dt.Rows[n]["Discount_rate"].ToString() != "")
                    {
                        model.Discount_rate = int.Parse(dt.Rows[n]["Discount_rate"].ToString());
                    }
                    if (dt.Rows[n]["Year_tradeMoney"].ToString() != "")
                    {
                        model.Year_tradeMoney = decimal.Parse(dt.Rows[n]["Year_tradeMoney"].ToString());
                    }
                    if (dt.Rows[n]["Year_incomeMoney"].ToString() != "")
                    {
                        model.Year_incomeMoney = decimal.Parse(dt.Rows[n]["Year_incomeMoney"].ToString());
                    }
                    if (dt.Rows[n]["Total_tradeMoney"].ToString() != "")
                    {
                        model.Total_tradeMoney = decimal.Parse(dt.Rows[n]["Total_tradeMoney"].ToString());
                    }
                    if (dt.Rows[n]["Total_incomeMoney"].ToString() != "")
                    {
                        model.Total_incomeMoney = decimal.Parse(dt.Rows[n]["Total_incomeMoney"].ToString());
                    }
                    if (dt.Rows[n]["YearStart_time"].ToString() != "")
                    {
                        model.YearStart_time = DateTime.Parse(dt.Rows[n]["YearStart_time"].ToString());
                    }
                    if (dt.Rows[n]["LastTrade_time"].ToString() != "")
                    {
                        model.LastTrade_time = DateTime.Parse(dt.Rows[n]["LastTrade_time"].ToString());
                    }
                    model.Auditing_Manager = dt.Rows[n]["Auditing_Manager"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
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


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_broker", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker GetModelName(string Name)
        {
            List<Pbzx.Model.PBnet_broker> ls = GetModelList(" UserName='" + Name + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

   
     }
}
 
