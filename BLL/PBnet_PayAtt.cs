using System;
using System.Data;
using System.Collections.Generic;

using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using System.Web.UI.WebControls;
namespace Pbzx.BLL
{
    /// <summary>
    /// PBnet_PayAtt
    /// </summary>
    public partial class PBnet_PayAtt
    {
        private readonly IPBnet_PayAtt dal = DataAccess.CreatePBnet_PayAtt();
        public PBnet_PayAtt()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pa_id)
        {
            return dal.Exists(Pa_id);
        }
        public bool Exists(string Pa_Idol, string Pa_fans, string Pa_PSign)
        {
            return dal.Exists(Pa_Idol, Pa_fans, Pa_PSign);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_PayAtt model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_PayAtt model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Pa_id)
        {

            return dal.Delete(Pa_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Pa_idlist)
        {
            return dal.DeleteList(Pa_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_PayAtt GetModel(int Pa_id)
        {

            return dal.GetModel(Pa_id);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_PayAtt> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_PayAtt> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_PayAtt> modelList = new List<Pbzx.Model.PBnet_PayAtt>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_PayAtt model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_PayAtt();
                    if (dt.Rows[n]["Pa_id"].ToString() != "")
                    {
                        model.Pa_id = int.Parse(dt.Rows[n]["Pa_id"].ToString());
                    }
                    model.Pa_fans = dt.Rows[n]["Pa_fans"].ToString();
                    if (dt.Rows[n]["Pa_time"].ToString() != "")
                    {
                        model.Pa_time = DateTime.Parse(dt.Rows[n]["Pa_time"].ToString());
                    }
                    model.Pa_Idol = dt.Rows[n]["Pa_Idol"].ToString();
                    model.Pa_PSign = dt.Rows[n]["Pa_PSign"].ToString();
                    if (dt.Rows[n]["Pa_state"].ToString() != "")
                    {
                        model.Pa_state = int.Parse(dt.Rows[n]["Pa_state"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}


        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="fansName">粉丝名（添加人名称）</param>
        /// <param name="IdolName">偶像名（关注人名称）</param>
        /// <param name="sign">平台标志</param>
        /// 返回 1  关注成功   返回 0 关注失败  返回 2 已经添加关注
        /// <returns></returns>
        public int AddPayAtt(string fansName, string IdolName, string sign)
        {
            Pbzx.Model.PBnet_PayAtt mod_pt = new Model.PBnet_PayAtt();
            //查询是否已添加关注
            if (Exists(IdolName, fansName, sign))
            {
                return 2;
            }
            else
            {
                //添加
                mod_pt.Pa_fans = fansName;
                mod_pt.Pa_Idol = IdolName;
                mod_pt.Pa_PSign = sign;
                mod_pt.Pa_time = DateTime.Now;
                mod_pt.Pa_state = 0;
                if (Add(mod_pt)>0)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="fansName">粉丝名（添加人名称）</param>
        /// <param name="IdolName">偶像名（关注人名称）</param>
        /// <param name="sign">平台标志</param>
        /// 返回 1  取消成功   返回 0 取消失败  返回 2 您还没有添加关注
        /// <returns></returns>
        public int DeletePayAtt(string fansName, string IdolName, string sign)
        {
            
            //查询是否已添加关注
            if (Exists(IdolName, fansName, sign))
            {
                DataSet ds = GetList("Pa_fans=" + "'" + fansName + "'" + " and Pa_Idol=" + "'" + IdolName + "'" + " and Pa_PSign=" + "'" + sign + "'");
                if (Delete(Convert.ToInt32(ds.Tables[0].Rows[0]["Pa_id"])))
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
            return 0;
        }

        #endregion  Method
    }
}