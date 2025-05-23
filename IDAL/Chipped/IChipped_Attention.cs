using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IChipped_Attention 的摘要说明。
	/// </summary>
	public interface IChipped_Attention
	{
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int id);
        bool Exists(string AName, string AttentionName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Chipped_Attention model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Pbzx.Model.Chipped_Attention model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string name);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Chipped_Attention GetModel(int id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
	}
}

