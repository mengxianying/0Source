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
    /// 业务逻辑类PBnet_ask_User 的摘要说明。
    /// </summary>
    public class PBnet_ask_User
    {
        private readonly IPBnet_ask_User dal = DataAccess.CreatePBnet_ask_User();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_ask_User", "ID");
        public PBnet_ask_User()
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
        public bool Add(Pbzx.Model.PBnet_ask_User model)
        {
            return dal.Add(model) > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_ask_User model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

           return dal.Delete(ID)>0?true:false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ask_User GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_ask_User GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_ask_UserModel-" + ID;
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
            return (Pbzx.Model.PBnet_ask_User)objModel;
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
        public List<Pbzx.Model.PBnet_ask_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_ask_User> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ask_User> modelList = new List<Pbzx.Model.PBnet_ask_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ask_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ask_User();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["Point"].ToString() != "")
                    {
                        model.Point = int.Parse(dt.Rows[n]["Point"].ToString());
                    }
                    if (dt.Rows[n]["Pointpenalty"].ToString() != "")
                    {
                        model.Pointpenalty = int.Parse(dt.Rows[n]["Pointpenalty"].ToString());
                    }
                    if (dt.Rows[n]["OtherPointpenalty"].ToString() != "")
                    {
                        model.OtherPointpenalty = int.Parse(dt.Rows[n]["OtherPointpenalty"].ToString());
                    }
                    if (dt.Rows[n]["AskNum"].ToString() != "")
                    {
                        model.AskNum = int.Parse(dt.Rows[n]["AskNum"].ToString());
                    }
                    if (dt.Rows[n]["ReplyNum"].ToString() != "")
                    {
                        model.ReplyNum = int.Parse(dt.Rows[n]["ReplyNum"].ToString());
                    }
                    if (dt.Rows[n]["Best_ReplyNum"].ToString() != "")
                    {
                        model.Best_ReplyNum = int.Parse(dt.Rows[n]["Best_ReplyNum"].ToString());
                    }
                    if (dt.Rows[n]["OpenTime"].ToString() != "")
                    {
                        model.OpenTime = DateTime.Parse(dt.Rows[n]["OpenTime"].ToString());
                    }
                    if (dt.Rows[n]["Ask_DelNum"].ToString() != "")
                    {
                        model.Ask_DelNum = int.Parse(dt.Rows[n]["Ask_DelNum"].ToString());
                    }
                    model.UserGroup = dt.Rows[n]["UserGroup"].ToString();
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["Score"].ToString() != "")
                    {
                        model.Score = int.Parse(dt.Rows[n]["Score"].ToString());
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
        /// 得到当前拼搏吧用户资料
        /// </summary>
        /// <returns></returns>
        public static Pbzx.Model.PBnet_ask_User GetCurrentAsker()
        {
            string uName = Method.Get_UserName;
            Pbzx.BLL.PBnet_ask_User bll = new PBnet_ask_User();
            List<Pbzx.Model.PBnet_ask_User> ls = bll.GetModelList(" UserName='" + uName + "'");
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
        /// 根据用户名得到实例
        /// </summary>
        /// <returns></returns>
        public Pbzx.Model.PBnet_ask_User GetModelName(string Name)
        {

            List<Pbzx.Model.PBnet_ask_User> ls = GetModelList(" UserName='" + Name + "'");
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
        /// 根据用户编号得到用户头衔
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTitleByID(int id)
        {
            Pbzx.Model.PBnet_ask_User userModel = GetModel(id);
            if(userModel == null)
            {
                return "";
            }            
            return Method.GetUserTitle(Convert.ToString(userModel.Score - userModel.Pointpenalty - userModel.OtherPointpenalty));
        }


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_ask_User", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }



        /// <summary>
        /// 执行sql语句返回单个值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetSingleData(string sql)
        {
            return basicDAL.GetValueBySql(sql);
        }

        /// <summary>
        /// 根据Sql语句查询
        /// </summary>
        /// <returns></returns>
        public DataTable Query(string sql)
        {
            return basicDAL.GetLisBySql(sql);
        }
    }
}

