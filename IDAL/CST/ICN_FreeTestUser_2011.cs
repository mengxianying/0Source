using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface ICN_FreeTestUser_2011
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
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.CN_FreeTestUser2011 model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.CN_FreeTestUser2011 model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.CN_FreeTestUser2011 GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
