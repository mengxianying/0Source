using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ISoftwareHelp_TreeStructure 的摘要说明。
    /// </summary>
    public interface IHelp_TreeStructure
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        bool Exists(string name, string lottery, int TreeName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Help_TreeStructure model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Help_TreeStructure model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        int Delete(string Noet);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Help_TreeStructure GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
