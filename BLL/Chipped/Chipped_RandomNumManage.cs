using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// Chipped_RandomNum
    /// </summary>
    public class Chipped_RandomNum
    {

        private readonly IChipped_RandomNum dal = DataAccess.CreateChipped_RandomNum();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_RandomNum", "Rn_id");
        public Chipped_RandomNum()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Rn_id)
        {
            return dal.Exists(Rn_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_RandomNum model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_RandomNum model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Rn_id)
        {

            return dal.Delete(Rn_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Rn_idlist)
        {
            return dal.DeleteList(Rn_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_RandomNum GetModel(int Rn_id)
        {

            return dal.GetModel(Rn_id);
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
        public List<Pbzx.Model.Chipped_RandomNum> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_RandomNum> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_RandomNum> modelList = new List<Pbzx.Model.Chipped_RandomNum>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_RandomNum model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_RandomNum();
                    if (dt.Rows[n]["Rn_id"].ToString() != "")
                    {
                        model.Rn_id = int.Parse(dt.Rows[n]["Rn_id"].ToString());
                    }
                    model.Rn_name = dt.Rows[n]["Rn_name"].ToString();
                    if (dt.Rows[n]["Rn_play"].ToString() != "")
                    {
                        model.Rn_play = int.Parse(dt.Rows[n]["Rn_play"].ToString());
                    }
                    if (dt.Rows[n]["Rn_note"].ToString() != "")
                    {
                        model.Rn_note = int.Parse(dt.Rows[n]["Rn_note"].ToString());
                    }
                    if (dt.Rows[n]["Rn_multiple"].ToString() != "")
                    {
                        model.Rn_multiple = int.Parse(dt.Rows[n]["Rn_multiple"].ToString());
                    }
                    if (dt.Rows[n]["Rn_tmtion"].ToString() != "")
                    {
                        model.Rn_tmtion = decimal.Parse(dt.Rows[n]["Rn_tmtion"].ToString());
                    }
                    if (dt.Rows[n]["Rn_mess"].ToString() != "")
                    {
                        model.Rn_mess = int.Parse(dt.Rows[n]["Rn_mess"].ToString());
                    }
                    if (dt.Rows[n]["Rn_state"].ToString() != "")
                    {
                        model.Rn_state = int.Parse(dt.Rows[n]["Rn_state"].ToString());
                    }
                    if (dt.Rows[n]["Rn_time"].ToString() != "")
                    {
                        model.Rn_time = DateTime.Parse(dt.Rows[n]["Rn_time"].ToString());
                    }
                    if (dt.Rows[n]["Rn_num"].ToString() != null)
                    {
                        model.Rn_num = dt.Rows[n]["Rn_num"].ToString();
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_RandomNum", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  Method
    }
}
