using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web.UI.WebControls;
using Pbzx.Common;
using System.Text;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类AgentInfo 的摘要说明。
    /// </summary>
    public class AgentInfo
    {
        private readonly IAgentInfo dal = DataAccess.CreateAgentInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("AgentInfo", "ID");
   
        public AgentInfo()
        {
            basicDAL.IsCst = true;
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.AgentInfo model)
        {
           return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.AgentInfo model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.AgentInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.AgentInfo GetModelName(string Name)
        {

            List<Pbzx.Model.AgentInfo> ls = GetModelList(" UserName='" + Name + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.AgentInfo GetModelByCache(int ID)
        {

            string CacheKey = "AgentInfoModel-" + ID ;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.AgentInfo)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.AgentInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.AgentInfo> modelList = new List<Pbzx.Model.AgentInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.AgentInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.AgentInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.Password = ds.Tables[0].Rows[n]["Password"].ToString();
                    model.Name = ds.Tables[0].Rows[n]["Name"].ToString();
                    model.Company = ds.Tables[0].Rows[n]["Company"].ToString();
                    model.Telephone = ds.Tables[0].Rows[n]["Telephone"].ToString();
                    model.Fax = ds.Tables[0].Rows[n]["Fax"].ToString();
                    model.Mobile = ds.Tables[0].Rows[n]["Mobile"].ToString();
                    model.EMail = ds.Tables[0].Rows[n]["EMail"].ToString();
                    model.PostCode = ds.Tables[0].Rows[n]["PostCode"].ToString();
                    model.Province = ds.Tables[0].Rows[n]["Province"].ToString();
                    model.Address = ds.Tables[0].Rows[n]["Address"].ToString();
                    model.UserName = ds.Tables[0].Rows[n]["UserName"].ToString();

                    if (ds.Tables[0].Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[n]["CreateDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[n]["ExpireDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(ds.Tables[0].Rows[n]["Type"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["PricePercent"].ToString() != "")
                    {
                        model.PricePercent = int.Parse(ds.Tables[0].Rows[n]["PricePercent"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    model.Remark = ds.Tables[0].Rows[n]["Remark"].ToString();
             
                    if (ds.Tables[0].Rows[n]["delshow"].ToString() != "")
                    {
                        if ((ds.Tables[0].Rows[n]["delshow"].ToString() == "1") || (ds.Tables[0].Rows[n]["delshow"].ToString().ToLower() == "true"))
                        {
                            model.delshow = true;
                        }
                        else
                        {
                            model.delshow = false;
                        }
                    }
                    if (ds.Tables[0].Rows[n]["countid"].ToString() != "")
                    {
                        model.countid = int.Parse(ds.Tables[0].Rows[n]["countid"].ToString());
                    }
                    model.agtmore = ds.Tables[0].Rows[n]["agtmore"].ToString();
                    model.postmore = ds.Tables[0].Rows[n]["postmore"].ToString();
                    model.agttype = ds.Tables[0].Rows[n]["agttype"].ToString();
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
        ////生成添加新的代理编号

        public int GetNewID()
        {
            return int.Parse(basicDAL.GetValueBySql("select top 1 ID from AgentInfo Order By ID  Desc").ToString()) +1;

        }


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "[PINBLE_CST].dbo.AgentInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        public DataTable GetLisBySql(string strSql)
        {
            return basicDAL.GetLisBySql(strSql);
        }
        public void BindAgentName(DropDownList list)
        {
            DataTable dt = GetLisBySql("select Name  from dbo.AgentInfo where ExpireDate>getdate() and Status=1  group by Name ");
            list.DataTextField = "Name";
            list.DataValueField = "Name";
            list.DataSource = dt;
            list.DataBind();           
            list.Items.Insert(0, new ListItem("所有", ""));
            list.Items[0].Selected = true;
            list.Items.Insert(1, new ListItem("公司注册", "公司注册"));
            list.Items.Insert(2, new ListItem("代理注册", "代理注册"));
            list.Items.Insert(3, new ListItem("充值卡注册", "充值卡注册"));
        }



        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public void ChangeAudit(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public void ChangeState(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }

     }
}

