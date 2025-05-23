using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Help_Contrast 的摘要说明。
    /// </summary>
    public class Help_Contrast
    {
        private static readonly IHelp_Contrast dal = DataAccess.CreateHelp_Contrast();
        public Help_Contrast()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Ct_id)
        {
            return dal.Exists(Ct_id);
        }
        public bool Exists(string Ct_TreeNum, string Ct_software)
        {
            return dal.Exists(Ct_TreeNum, Ct_software);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_Contrast model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Help_Contrast model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Ct_id)
        {
            return dal.Delete(Ct_id);
        }
        public int DeleteID(int Ct_TreeNum)
        {
            return dal.DeleteID(Ct_TreeNum);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_Contrast GetModel(int Ct_id)
        {
            return dal.GetModel(Ct_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  成员方法
    }
}

