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
	/// 业务逻辑类PBnet_ask_Reply 的摘要说明。
	/// </summary>
	public class PBnet_ask_Reply
	{
		private readonly IPBnet_ask_Reply dal=DataAccess.CreatePBnet_ask_Reply();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Reply", "ID");
		public PBnet_ask_Reply()
		{}
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
		public bool  Add(Pbzx.Model.PBnet_ask_Reply model)
		{
            return dal.Add(model) > 0 ? true : false;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_ask_Reply model)
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
		public Pbzx.Model.PBnet_ask_Reply GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_ask_Reply GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_ask_ReplyModel-" + ID;
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
            return (Pbzx.Model.PBnet_ask_Reply)objModel;
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
        public List<Pbzx.Model.PBnet_ask_Reply> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_ask_Reply> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ask_Reply> modelList = new List<Pbzx.Model.PBnet_ask_Reply>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ask_Reply model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ask_Reply();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["QuestionId"].ToString() != "")
                    {
                        model.QuestionId = int.Parse(dt.Rows[n]["QuestionId"].ToString());
                    }
                    model.Content = dt.Rows[n]["Content"].ToString();
                    model.Replyer = dt.Rows[n]["Replyer"].ToString();
                    if (dt.Rows[n]["ReplyTime"].ToString() != "")
                    {
                        model.ReplyTime = DateTime.Parse(dt.Rows[n]["ReplyTime"].ToString());
                    }
                    if (dt.Rows[n]["IsBest"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsBest"].ToString() == "1") || (dt.Rows[n]["IsBest"].ToString().ToLower() == "true"))
                        {
                            model.IsBest = true;
                        }
                        else
                        {
                            model.IsBest = false;
                        }
                    }
                    model.ReferenceBook = dt.Rows[n]["ReferenceBook"].ToString();
                    model.Comment = dt.Rows[n]["Comment"].ToString();
                    if (dt.Rows[n]["GoodComment"].ToString() != "")
                    {
                        model.GoodComment = int.Parse(dt.Rows[n]["GoodComment"].ToString());
                    }
                    if (dt.Rows[n]["BadComment"].ToString() != "")
                    {
                        model.BadComment = int.Parse(dt.Rows[n]["BadComment"].ToString());
                    }
                    if (dt.Rows[n]["AttachId"].ToString() != "")
                    {
                        model.AttachId = int.Parse(dt.Rows[n]["AttachId"].ToString());
                    }
                    if (dt.Rows[n]["ReplyerId"].ToString() != "")
                    {
                        model.ReplyerId = int.Parse(dt.Rows[n]["ReplyerId"].ToString());
                    }
                    if (dt.Rows[n]["Deleted"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Deleted"].ToString() == "1") || (dt.Rows[n]["Deleted"].ToString().ToLower() == "true"))
                        {
                            model.Deleted = true;
                        }
                        else
                        {
                            model.Deleted = false;
                        }
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


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_ask_Reply", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
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
        /// 根据ＩＤ批量删除删除数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string sql = "DELETE FROM PBnet_ask_Reply WHERE Id IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }


        /// <summary>
        /// 根据ＩＤ批量更新数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column, bool trueOrFalse)
        {
            int value = trueOrFalse ? 1 : 0;
            string sql = "update PBnet_ask_Reply set " + column + "=" + value + " WHERE Id IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Reply", "Id");
            basicDAL1.ChangeAudit(id, filed);
        }
        public int ExecuteBySql(string sql)
        {
            return dal.ExecuteBySql(sql);
        }

	}
}

