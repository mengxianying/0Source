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
	/// 业务逻辑类RegisterInfo2 的摘要说明。
	/// </summary>
	public class RegisterInfo2
	{
		private readonly IRegisterInfo2 dal=DataAccess.CreateRegisterInfo2();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("RegisterInfo2", "ID");
		public RegisterInfo2()
		{
            basicDAL.IsCst = true;
        }

		#region  成员方法
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.RegisterInfo2 model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool  Update(Pbzx.Model.RegisterInfo2 model)
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
        public Pbzx.Model.RegisterInfo2 GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.RegisterInfo2 GetModelByCache(int ID)
        {

            string CacheKey = "RegisterInfo2Model-" + ID;
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
            return (Pbzx.Model.RegisterInfo2)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.RegisterInfo2> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.RegisterInfo2> modelList = new List<Pbzx.Model.RegisterInfo2>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.RegisterInfo2 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.RegisterInfo2();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.RN = ds.Tables[0].Rows[n]["RN"].ToString();
                    model.HDSN = ds.Tables[0].Rows[n]["HDSN"].ToString();
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = int.Parse(ds.Tables[0].Rows[n]["UserType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseType"].ToString() != "")
                    {
                        model.UseType = int.Parse(ds.Tables[0].Rows[n]["UseType"].ToString());
                    }
                    model.Operator = ds.Tables[0].Rows[n]["Operator"].ToString();
                    if (ds.Tables[0].Rows[n]["AgentID"].ToString() != "")
                    {
                        model.AgentID = int.Parse(ds.Tables[0].Rows[n]["AgentID"].ToString());
                    }
                    model.AgentName = ds.Tables[0].Rows[n]["AgentName"].ToString();
                    model.PayType = ds.Tables[0].Rows[n]["PayType"].ToString();
                    if (ds.Tables[0].Rows[n]["PayMoney"].ToString() != "")
                    {
                        model.PayMoney = decimal.Parse(ds.Tables[0].Rows[n]["PayMoney"].ToString());
                    }
                    model.PayDetails = ds.Tables[0].Rows[n]["PayDetails"].ToString();
                    model.CardNo = ds.Tables[0].Rows[n]["CardNo"].ToString();
                    model.CardPassword = ds.Tables[0].Rows[n]["CardPassword"].ToString();
                    if (ds.Tables[0].Rows[n]["TimeType"].ToString() != "")
                    {
                        model.TimeType = int.Parse(ds.Tables[0].Rows[n]["TimeType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["RegisterDate"].ToString() != "")
                    {
                        model.RegisterDate = DateTime.Parse(ds.Tables[0].Rows[n]["RegisterDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[n]["ExpireDate"].ToString());
                    }
                    model.Username = ds.Tables[0].Rows[n]["Username"].ToString();
                    model.UserTel = ds.Tables[0].Rows[n]["UserTel"].ToString();
                    model.UserEmail = ds.Tables[0].Rows[n]["UserEmail"].ToString();
                    model.UserAddress = ds.Tables[0].Rows[n]["UserAddress"].ToString();
                    if (ds.Tables[0].Rows[n]["UpdateCount"].ToString() != "")
                    {
                        model.UpdateCount = int.Parse(ds.Tables[0].Rows[n]["UpdateCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LastUpdateDate"].ToString() != "")
                    {
                        model.LastUpdateDate = DateTime.Parse(ds.Tables[0].Rows[n]["LastUpdateDate"].ToString());
                    }
                    model.LastUpdateVersion = ds.Tables[0].Rows[n]["LastUpdateVersion"].ToString();
                    if (ds.Tables[0].Rows[n]["DD_Time"].ToString() != "")
                    {
                        model.DD_Time = DateTime.Parse(ds.Tables[0].Rows[n]["DD_Time"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["DD_Date"].ToString() != "")
                    {
                        model.DD_Date = DateTime.Parse(ds.Tables[0].Rows[n]["DD_Date"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["DD_Count"].ToString() != "")
                    {
                        model.DD_Count = int.Parse(ds.Tables[0].Rows[n]["DD_Count"].ToString());
                    }
                    model.Remarks = ds.Tables[0].Rows[n]["Remarks"].ToString();
                    model.BBsID = ds.Tables[0].Rows[n]["BBsID"].ToString();
                    model.OrgSN = ds.Tables[0].Rows[n]["OrgSN"].ToString();
                    model.OldSN = ds.Tables[0].Rows[n]["OldSN"].ToString();
                    if (ds.Tables[0].Rows[n]["IsReRegistered"].ToString() != "")
                    {
                        model.IsReRegistered = int.Parse(ds.Tables[0].Rows[n]["IsReRegistered"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["RegisterMode"].ToString() != "")
                    {
                        model.RegisterMode = int.Parse(ds.Tables[0].Rows[n]["RegisterMode"].ToString());
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
        #region 自定义方法
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "RegisterInfo2", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// 执行SQL获取数据列表.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {            
            return basicDAL.GetLisBySql(strSql);
        }

        public string GetTotalMoney(string where)
        {
            string result = "";
            string sql = "select count(ID) as TotalID,sum(PayMoney) as TotalMoney from [RegisterInfo2]";
            if(!string.IsNullOrEmpty(where))
            {
                sql += " where "+where;
            }
            DataSet ds = dal.Query(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                object objTotalID = ds.Tables[0].Rows[0]["TotalID"];
                object objTotalMoney = ds.Tables[0].Rows[0]["TotalMoney"];
                if (objTotalID != null && !string.IsNullOrEmpty(objTotalID.ToString()) && objTotalMoney != null && !string.IsNullOrEmpty(objTotalMoney.ToString()))
                {
                    result = ds.Tables[0].Rows[0]["TotalID"] + "&" + ds.Tables[0].Rows[0]["TotalMoney"];
                }
                else
                {
                    result = "0&0";
                }               
            }
            else
            {
                result = "0&0";
            }
            return result;
        }
      
        #endregion
    }
}

