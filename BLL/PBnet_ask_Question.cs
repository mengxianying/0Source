using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using System.Web.UI.WebControls;
namespace Pbzx.BLL
{
	/// <summary>
	/// 业务逻辑类PBnet_ask_Question 的摘要说明。
	/// </summary>
	public class PBnet_ask_Question
	{
		private readonly IPBnet_ask_Question dal=DataAccess.CreatePBnet_ask_Question();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Question", "Id");
		public PBnet_ask_Question()
		{}
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
		public int  Add(Pbzx.Model.PBnet_ask_Question model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_ask_Question model)
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
		public Pbzx.Model.PBnet_ask_Question GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_ask_Question GetModelByCache(int Id)
		{
			
			string CacheKey = "PBnet_ask_QuestionModel-" + Id;
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
				catch{}
			}
			return (Pbzx.Model.PBnet_ask_Question)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.PBnet_ask_Question> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_ask_Question> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ask_Question> modelList = new List<Pbzx.Model.PBnet_ask_Question>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ask_Question model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ask_Question();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Content = dt.Rows[n]["Content"].ToString();
                    model.Relay = dt.Rows[n]["Relay"].ToString();
                    model.Asker = dt.Rows[n]["Asker"].ToString();
                    if (dt.Rows[n]["AskTime"].ToString() != "")
                    {
                        model.AskTime = DateTime.Parse(dt.Rows[n]["AskTime"].ToString());
                    }
                    if (dt.Rows[n]["OverTime"].ToString() != "")
                    {
                        model.OverTime = DateTime.Parse(dt.Rows[n]["OverTime"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["Views"].ToString() != "")
                    {
                        model.Views = int.Parse(dt.Rows[n]["Views"].ToString());
                    }
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["FTypeID"].ToString() != "")
                    {
                        model.FTypeID = int.Parse(dt.Rows[n]["FTypeID"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    model.Answerer = dt.Rows[n]["Answerer"].ToString();
                    if (dt.Rows[n]["LargessPoint"].ToString() != "")
                    {
                        model.LargessPoint = int.Parse(dt.Rows[n]["LargessPoint"].ToString());
                    }
                    if (dt.Rows[n]["IsCommend"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsCommend"].ToString() == "1") || (dt.Rows[n]["IsCommend"].ToString().ToLower() == "true"))
                        {
                            model.IsCommend = true;
                        }
                        else
                        {
                            model.IsCommend = false;
                        }
                    }
                    if (dt.Rows[n]["IsAnonymous"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAnonymous"].ToString() == "1") || (dt.Rows[n]["IsAnonymous"].ToString().ToLower() == "true"))
                        {
                            model.IsAnonymous = true;
                        }
                        else
                        {
                            model.IsAnonymous = false;
                        }
                    }
                    if (dt.Rows[n]["AttachId"].ToString() != "")
                    {
                        model.AttachId = int.Parse(dt.Rows[n]["AttachId"].ToString());
                    }
                    if (dt.Rows[n]["Replys"].ToString() != "")
                    {
                        model.Replys = int.Parse(dt.Rows[n]["Replys"].ToString());
                    }
                    if (dt.Rows[n]["AskerId"].ToString() != "")
                    {
                        model.AskerId = int.Parse(dt.Rows[n]["AskerId"].ToString());
                    }
                    if (dt.Rows[n]["AnswererId"].ToString() != "")
                    {
                        model.AnswererId = int.Parse(dt.Rows[n]["AnswererId"].ToString());
                    }
                    if (dt.Rows[n]["BitIsHot"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsHot"].ToString() == "1") || (dt.Rows[n]["BitIsHot"].ToString().ToLower() == "true"))
                        {
                            model.BitIsHot = true;
                        }
                        else
                        {
                            model.BitIsHot = false;
                        }
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
                    if (dt.Rows[n]["Auditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Auditing"].ToString() == "1") || (dt.Rows[n]["Auditing"].ToString().ToLower() == "true"))
                        {
                            model.Auditing = true;
                        }
                        else
                        {
                            model.Auditing = false;
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
        /// <summary>
        /// 根据查询条件，和需要返回的条数返回结果集
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="count">返回的条数</param>
        /// <returns>结果集</returns>
        /// author:孟
        public DataTable GetTitleListByCount(string strWhere, int count)
        {
            return dal.GetList(count, strWhere, " AskTime desc ").Tables[0];
        }

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_ask_Question", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// 根据类别编号得到问题数量
        /// </summary>
        /// <param name="typeId">类别id</param>
        /// <returns>问题数量</returns>
        /// author:meng
        /// date:09-08-17
        public object GetCountByTypeID(string typeId)
        {           
            return dal.GetCountByTypeId(typeId);
        }

        /// <summary>
        /// 根据sql语句返回查询结果
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
            string sql = "DELETE FROM PBnet_ask_Question WHERE Id IN(" + strID + ")";
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
            string sql = "update PBnet_ask_Question set " + column + "=" + value + " WHERE Id IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Question", "Id");
            basicDAL1.ChangeAudit(id, filed);
        }
        public int ExecuteBySql(string sql)
        {
            return dal.ExecuteBySql(sql);
        }
	}
}

