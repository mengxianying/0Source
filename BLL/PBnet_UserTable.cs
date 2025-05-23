using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using Pbzx.Common;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_UserTable 的摘要说明。
    /// </summary>
    public class PBnet_UserTable
    {
        private readonly IPBnet_UserTable dal = DataAccess.CreatePBnet_UserTable();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_UserTable", "Id");
        public PBnet_UserTable()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntId)
        {
            return dal.Exists(IntId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_UserTable model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_UserTable model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int IntId)
        {

            return dal.Delete(IntId) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserTable GetModel(int IntId)
        {

            return dal.GetModel(IntId);
        }
        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserTable GetModelName(string Name)
        {

            List<Pbzx.Model.PBnet_UserTable> ls = GetModelList(" UserName='" + Name + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_UserTable GetModelByCache(int IntId)
        {

            string CacheKey = "PBnet_UserTableModel-" + IntId;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntId);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_UserTable)objModel;
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
        public List<Pbzx.Model.PBnet_UserTable> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_UserTable> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_UserTable> modelList = new List<Pbzx.Model.PBnet_UserTable>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_UserTable model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_UserTable();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.RealName = dt.Rows[n]["RealName"].ToString();
                    model.TradePwd = dt.Rows[n]["TradePwd"].ToString();
                    model.CardID = dt.Rows[n]["CardID"].ToString();
                    model.Province = dt.Rows[n]["Province"].ToString();
                    model.City = dt.Rows[n]["City"].ToString();
                    model.PostCode = dt.Rows[n]["PostCode"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.Telphone = dt.Rows[n]["Telphone"].ToString();
                    model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    model.MSN = dt.Rows[n]["MSN"].ToString();
                    if (dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Sex"].ToString() == "1") || (dt.Rows[n]["Sex"].ToString().ToLower() == "true"))
                        {
                            model.Sex = true;
                        }
                        else
                        {
                            model.Sex = false;
                        }
                    }
                    model.BankName = dt.Rows[n]["BankName"].ToString();
                    model.BankInfo = dt.Rows[n]["BankInfo"].ToString();
                    model.AccountNumber = dt.Rows[n]["AccountNumber"].ToString();
                    if (dt.Rows[n]["CurrentMoney"].ToString() != "")
                    {
                        model.CurrentMoney = decimal.Parse(dt.Rows[n]["CurrentMoney"].ToString());
                    }
                    if (dt.Rows[n]["FrozenMoney"].ToString() != "")
                    {
                        model.FrozenMoney = decimal.Parse(dt.Rows[n]["FrozenMoney"].ToString());
                    }
                    if (dt.Rows[n]["LastTrade_time"].ToString() != "")
                    {
                        model.LastTrade_time = DateTime.Parse(dt.Rows[n]["LastTrade_time"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
                    }
                    if (dt.Rows[n]["OperateTime"].ToString() != "")
                    {
                        model.OperateTime = DateTime.Parse(dt.Rows[n]["OperateTime"].ToString());
                    }
                    model.OperateManager = dt.Rows[n]["OperateManager"].ToString();
                    model.OperateResult = dt.Rows[n]["OperateResult"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["EmailState"].ToString() != "")
                    {
                        model.EmailState = int.Parse(dt.Rows[n]["EmailState"].ToString());
                    }
                    if (dt.Rows[n]["AccountNumberState"].ToString() != "")
                    {
                        model.AccountNumberState = int.Parse(dt.Rows[n]["AccountNumberState"].ToString());
                    }
                    model.EmailCode = dt.Rows[n]["EmailCode"].ToString();
                    model.AccountNumberCode = dt.Rows[n]["AccountNumberCode"].ToString();
                    if (dt.Rows[n]["EmailCodeTime"].ToString() != "")
                    {
                        model.EmailCodeTime = DateTime.Parse(dt.Rows[n]["EmailCodeTime"].ToString());
                    }
                    if (dt.Rows[n]["AccountNumberCodeTime"].ToString() != "")
                    {
                        model.AccountNumberCodeTime = DateTime.Parse(dt.Rows[n]["AccountNumberCodeTime"].ToString());
                    }
                    if (dt.Rows[n]["EmailCodeCount"].ToString() != "")
                    {
                        model.EmailCodeCount = int.Parse(dt.Rows[n]["EmailCodeCount"].ToString());
                    }
                    if (dt.Rows[n]["AccountNumberCodeCount"].ToString() != "")
                    {
                        model.AccountNumberCodeCount = int.Parse(dt.Rows[n]["AccountNumberCodeCount"].ToString());
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

        public static Pbzx.Model.PBnet_UserTable GetCurrentRealInfoUser()
        {
            PBnet_UserTable uBLL = new PBnet_UserTable();
            return uBLL.GetModelName(Method.Get_UserName);
        }

        public static Pbzx.Model.PBnet_UserTable GetRealInfoByUname(string userName)
        {
            PBnet_UserTable uBLL = new PBnet_UserTable();
            return uBLL.GetModelName(userName);
        }



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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_UserTable", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
    }
}

