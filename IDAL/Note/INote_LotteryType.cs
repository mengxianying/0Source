using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层INote_LotteryType 的摘要说明。
    /// </summary>
    public interface INote_LotteryType
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int SID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Note_LotteryType model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Note_LotteryType model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int SID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Note_LotteryType GetModel(int SID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
