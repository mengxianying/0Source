using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    public class Note_WriteBack
    {
        private static readonly INote_WriteBack dal = DataAccess.CreateNote_WriteBack();

        public Note_WriteBack() { }
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
        public void Add(Pbzx.Model.Note_WriteBack model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.Note_WriteBack model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_WriteBack GetModel(int ID)
        {
            return dal.GetModel(ID);
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
        public List<Pbzx.Model.Note_WriteBack> GetIList()
        {
            return DataTableToList(dal.GetList("").Tables[0]);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Note_WriteBack> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Note_WriteBack> modelList = null;
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                modelList = new List<Pbzx.Model.Note_WriteBack>();
                Pbzx.Model.Note_WriteBack model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Note_WriteBack();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Phone = dt.Rows[n]["Phone"].ToString();

                    model.Content = dt.Rows[n]["Countent"].ToString();

                    model.BeginTime = Convert.ToDateTime(dt.Rows[n]["BeginTime"].ToString());

                    model.Sp_PID = dt.Rows[n]["Sp_PID"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  成员方法
    }
}
