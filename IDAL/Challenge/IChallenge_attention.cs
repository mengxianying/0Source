using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IChallenge_attention 的摘要说明。
    /// </summary>
    public interface IChallenge_attention
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Att_id);
        bool Exists(string name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Challenge_attention model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Challenge_attention model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Att_id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Challenge_attention GetModel(int Att_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
