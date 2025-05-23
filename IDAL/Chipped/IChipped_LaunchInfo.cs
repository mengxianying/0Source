using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface IChipped_LaunchInfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string QNumber);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.chipped_LaunchInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.chipped_LaunchInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string QNumber);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.chipped_LaunchInfo GetModel(string QNumber);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        DataSet QuerySet(string sql);
        #endregion  成员方法

    }
}
