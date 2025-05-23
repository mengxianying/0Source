using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// Chipped_issueN
    /// </summary>
    public class Chipped_issueN
    {
        private readonly IChipped_issueN dal = DataAccess.CreateChipped_issueN();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_issueN", "In_id");
        public Chipped_issueN()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int In_id)
        {
            return dal.Exists(In_id);
        }
        public bool Exists(string In_num)
        {
            return dal.Exists(In_num);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_issueN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_issueN model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int In_id)
        {

            return dal.Delete(In_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string In_idlist)
        {
            return dal.DeleteList(In_idlist);
        }

        public bool DeleteRn(int In_RnId)
        {
            return dal.DeleteRn(In_RnId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_issueN GetModel(int In_id)
        {

            return dal.GetModel(In_id);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetListView(string strWhere)
        {
            return dal.GetListView(strWhere);
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
        public List<Pbzx.Model.Chipped_issueN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_issueN> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_issueN> modelList = new List<Pbzx.Model.Chipped_issueN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_issueN model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_issueN();
                    if (dt.Rows[n]["In_id"].ToString() != "")
                    {
                        model.In_id = int.Parse(dt.Rows[n]["In_id"].ToString());
                    }
                    if (dt.Rows[n]["In_RnId"].ToString() != "")
                    {
                        model.In_RnId = int.Parse(dt.Rows[n]["In_RnId"].ToString());
                    }
                    model.In_num = dt.Rows[n]["In_num"].ToString();
                    if (dt.Rows[n]["In_mark"].ToString() != "")
                    {
                        model.In_mark = int.Parse(dt.Rows[n]["In_mark"].ToString());
                    }
                    model.In_issue = dt.Rows[n]["In_issue"].ToString();
                    if (dt.Rows[n]["In_multiple"].ToString() != "")
                    {
                        model.In_multiple = int.Parse(dt.Rows[n]["In_multiple"].ToString());
                    }
                    if (dt.Rows[n]["In_money"].ToString() != "")
                    {
                        model.In_money = decimal.Parse(dt.Rows[n]["In_money"].ToString());
                    }
                    if (dt.Rows[n]["In_state"].ToString() != "")
                    {
                        model.In_state = int.Parse(dt.Rows[n]["In_state"].ToString());
                    }
                    if (dt.Rows[n]["In_bouns"].ToString() != "")
                    {
                        model.In_bouns = decimal.Parse(dt.Rows[n]["In_bouns"].ToString());
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_issueN", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  Method
    }
}

