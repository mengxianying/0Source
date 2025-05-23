using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
   public class Market_ApplicationItemManage
    {
    //根据反射，找到对应的数据层
       private readonly IMarket_ApplicationItem dal = DataAccess.CreateIMarket_ApplicationItem();
       #region  成员方法
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int Id)
       {
           return dal.Exists(Id);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Pbzx.Model.Market_ApplicationItem model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public int Update(Pbzx.Model.Market_ApplicationItem model)
       {
          return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public int Delete(int Id)
       {
           return dal.Delete(Id);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Pbzx.Model.Market_ApplicationItem GetModel(int Id)
       {
           return dal.GetMain(Id);
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
