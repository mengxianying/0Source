﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层Challenge_config
    /// </summary>
    public interface IChallenge_config
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Challenge_config model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.Challenge_config model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        bool DeleteList(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Challenge_config GetModel(int id);
        Pbzx.Model.Challenge_config GetModelS(string aState);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
