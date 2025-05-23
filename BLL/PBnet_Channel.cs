using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web.UI.WebControls;
using System.Text;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_Channel 的摘要说明。
    /// </summary>
    public class PBnet_Channel
    {
        private readonly IPBnet_Channel dal = DataAccess.CreatePBnet_Channel();
        public PBnet_Channel()
        { }

        public void BindChannelType(DropDownList list, int parentClass)
        {
            DataTable dt = GetLisBySql("select * from PBnet_Channel where ChannelFID =" + parentClass + " and IsAuditing='1' order by OrderID ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                if (parentClass != 0)
                {
                    sb.Append("-|");
                }
                sb.Append(row["ChannelName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["ChannelID"].ToString()));
                BindChannelType(list, int.Parse(row["ChannelID"].ToString()));
            }

        }

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ChannelID)
        {
            return dal.Exists(ChannelID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Channel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.PBnet_Channel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ChannelID)
        {

            dal.Delete(ChannelID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Channel GetModel(int ChannelID)
        {

            return dal.GetModel(ChannelID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_Channel GetModelByCache(int ChannelID)
        {

            string CacheKey = "PBnet_ChannelModel-" + ChannelID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ChannelID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_Channel)objModel;
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
        public List<Pbzx.Model.PBnet_Channel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Channel> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Channel> modelList = new List<Pbzx.Model.PBnet_Channel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Channel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Channel();
                    if (dt.Rows[n]["ChannelID"].ToString() != "")
                    {
                        model.ChannelID = int.Parse(dt.Rows[n]["ChannelID"].ToString());
                    }
                    model.ChannelName = dt.Rows[n]["ChannelName"].ToString();
                    if (dt.Rows[n]["ChannelFID"].ToString() != "")
                    {
                        model.ChannelFID = int.Parse(dt.Rows[n]["ChannelFID"].ToString());
                    }
                    if (dt.Rows[n]["IsAuditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAuditing"].ToString() == "1") || (dt.Rows[n]["IsAuditing"].ToString().ToLower() == "true"))
                        {
                            model.IsAuditing = true;
                        }
                        else
                        {
                            model.IsAuditing = false;
                        }
                    }
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["Depth"].ToString() != "")
                    {
                        model.Depth = int.Parse(dt.Rows[n]["Depth"].ToString());
                    }
                    if (dt.Rows[n]["RootID"].ToString() != "")
                    {
                        model.RootID = int.Parse(dt.Rows[n]["RootID"].ToString());
                    }
                    model.ChannelFIDS = dt.Rows[n]["ChannelFIDS"].ToString();
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_Channel", "ChannelID");
            return bac.GetLisBySql(strSql);
        }
    }
}

