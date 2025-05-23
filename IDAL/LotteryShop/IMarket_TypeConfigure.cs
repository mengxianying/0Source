using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 数据接口层
    /// 创建人：杨良伟
    /// 创建时间：2010-10-20
    /// </summary>
    public interface IMarket_TypeConfigure
    {
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ConfigureID);

		/// <summary>
		/// 增加一条数据
		/// </summary>
	    int Add(Pbzx.Model.Market_TypeConfigure model);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    void Update(Pbzx.Model.Market_TypeConfigure model);
		

		/// <summary>
		/// 删除一条数据
		/// </summary>
	     void Delete(int ConfigureID);
		


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.Market_TypeConfigure GetModel(int ConfigureID);
		
			
			

		/// <summary>
		/// 获得数据列表
		/// </summary>
	    DataSet GetList(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);



		#endregion  成员方法
    }
}
