using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Note_Customize 的摘要说明。
    /// </summary>
    public class Note_Customize
    {
        private static readonly INote_Customize dal = DataAccess.CreateNote_Customize();
        public Note_Customize()
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
        public int Add(Pbzx.Model.Note_Customize model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Note_Customize model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_Customize GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public Pbzx.Model.Note_Customize GetModel(int sid, string username)
        {
            return dal.GetModel(sid, username);
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
        public DataSet GetList()
        {
            return dal.GetList("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Note_Customize> GetByList(string strwhere)
        {
            return DataTableToList(dal.GetList(strwhere).Tables[0]);
        }

        public List<Pbzx.Model.Note_Customize> GetModelByName(string username)
        {
            return dal.GetModelByName(username);
        }
        /// <summary>
        /// 根据条件得到数据列表
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public List<Pbzx.Model.Note_Customize> GetModelBySid(int sid)
        {
            return dal.GetModelBySid(sid);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Note_Customize> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Note_Customize> modelList = null;
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                modelList = new List<Pbzx.Model.Note_Customize>();
                Pbzx.Model.Note_Customize model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Note_Customize();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.SID = Convert.ToInt32(dt.Rows[n]["SID"].ToString());

                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.Price = Convert.ToDecimal(dt.Rows[n]["Price"].ToString());
                    model.BeginTime = Convert.ToDateTime(dt.Rows[n]["BeginTime"].ToString());
                    model.EndTime = Convert.ToDateTime(dt.Rows[n]["EndTime"].ToString());
                    model.ContinuationType = Convert.ToInt32(dt.Rows[n]["ContinuationType"].ToString());
                    model.Status = Convert.ToInt32(dt.Rows[n]["Status"].ToString());
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  成员方法
    }
}
