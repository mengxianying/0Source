using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPlatformPublic_payments 的摘要说明。
    /// </summary>
    public interface IPlatformPublic_payments
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Pp_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PlatformPublic_payments model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.PlatformPublic_payments model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Pp_id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PlatformPublic_payments GetModel(int Pp_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
