using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface IChipped_Info
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string QNumber);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Chipped_Info model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Chipped_Info model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string QNumber);
        int Delete(string QNumber, string username);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Chipped_Info GetModel(string QNumber);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        #endregion  成员方法

    }
}
