using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web.UI.WebControls;
using System.Text;
using Pbzx.Common;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_UrlMaping 的摘要说明。
    /// </summary>
    public class PBnet_UrlMaping
    {
        private readonly IPBnet_UrlMaping dal = DataAccess.CreatePBnet_UrlMaping();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_UrlMaping", "MapID");
        public PBnet_UrlMaping()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MapID)
        {
            return dal.Exists(MapID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_UrlMaping model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_UrlMaping model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MapID)
        {

            return dal.Delete(MapID) > 0 ? true : false; 
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UrlMaping GetModel(int MapID)
        {

            return dal.GetModel(MapID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_UrlMaping GetModelByCache(int MapID)
        {

            string CacheKey = "PBnet_UrlMapingModel-" + MapID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(MapID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_UrlMaping)objModel;
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
        public List<Pbzx.Model.PBnet_UrlMaping> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_UrlMaping> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_UrlMaping> modelList = new List<Pbzx.Model.PBnet_UrlMaping>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_UrlMaping model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_UrlMaping();
                    if (dt.Rows[n]["MapID"].ToString() != "")
                    {
                        model.MapID = int.Parse(dt.Rows[n]["MapID"].ToString());
                    }
                    if (dt.Rows[n]["FID"].ToString() != "")
                    {
                        model.FID = int.Parse(dt.Rows[n]["FID"].ToString());
                    }
                    model.Html = dt.Rows[n]["Html"].ToString();
                    model.Aspx = dt.Rows[n]["Aspx"].ToString();
                    if (dt.Rows[n]["Depth"].ToString() != "")
                    {
                        model.Depth = int.Parse(dt.Rows[n]["Depth"].ToString());
                    }
                    model.PageName = dt.Rows[n]["PageName"].ToString();
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["RootID"].ToString() != "")
                    {
                        model.RootID = int.Parse(dt.Rows[n]["RootID"].ToString());
                    }
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法

        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_UrlMaping", "MapID");
            return bac.GetLisBySql(strSql);
        }
        public void BindUrlMaping(DropDownList list, int FID)
        {

            DataTable dt = GetLisBySql("select * from PBnet_UrlMaping where FID =" + FID + "order by MapID ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                if (FID != 0)
                {
                    sb.Append("-|");
                }
                sb.Append(row["PageName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["MapID"].ToString()));
                BindUrlMaping(list, int.Parse(row["MapID"].ToString()));
            }
        }

        public void BindUrlMaping(DropDownList list, int FID,int typeID)
        {

            DataTable dt = GetLisBySql("select * from PBnet_UrlMaping where typeID="+typeID+" and FID =" + FID + "order by MapID ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                if (FID != 0)
                {
                    sb.Append("-|");
                }
                sb.Append(row["PageName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["MapID"].ToString()));
                BindUrlMaping(list, int.Parse(row["MapID"].ToString()),typeID);
            }
        }

        public DataTable GetListBySort() 
        {
            return basicDAL.GetLisBySql("SELECT * FROM PBnet_UrlMaping ORDER BY RootID,Depth,OrderID ASC");

        }

        public DataTable GetListBySort(int typeID)
        {

            //DataTable dsZY = MyBLL.GetListTitleCount(18, "pb_TypeName='专业版'and " + Method.IndexProduct + " ");
            //DataTable dtGS = MyBLL.GetListTitleCount(18, "(pb_TypeName='出票系统') and " + Method.IndexProduct + " ");
            //for (int i = 0; i < dtGS.Rows.Count; i++)
            //{
            //    DataRow myRow = dsZY.NewRow();
            //    myRow.ItemArray = dtGS.Rows[i].ItemArray;
            //    dsZY.Rows.Add(myRow);
            //}
            DataTable dtResult = basicDAL.GetLisBySql("SELECT * FROM PBnet_UrlMaping where TypeID=" + typeID + " and 1!=1 ");
            DataTable dtRoot =   basicDAL.GetLisBySql("SELECT * FROM PBnet_UrlMaping where TypeID=" + typeID + " and Depth=0  ORDER BY OrderID ASC ");
            for (int i = 0; i < dtRoot.Rows.Count;i++ )
            {
                DataRow myResultRow = dtResult.NewRow();
                myResultRow.ItemArray = dtRoot.Rows[i].ItemArray;
                dtResult.Rows.Add(myResultRow);
                DataTable dtSmall = basicDAL.GetLisBySql("SELECT * FROM PBnet_UrlMaping where TypeID=" + typeID + " and Depth>0 and FID='" + dtRoot.Rows[i]["MapID"] + "'  ORDER BY OrderID ASC ");
                for (int j = 0; j < dtSmall.Rows.Count;j++ )
                {
                    DataRow myResultRow1 = dtResult.NewRow();
                    myResultRow1.ItemArray = dtSmall.Rows[j].ItemArray;
                    dtResult.Rows.Add(myResultRow1);
                }
            }
            return dtResult;
        }
        /// <summary>
        /// 获得最新插入的ID.
        /// </summary>
        public int GetInsertID()
        {
            return Convert.ToInt32(basicDAL.GetValue("TOP 1 MapID", "", " MapID DESC"));
        }

        /// <summary>
        /// 根据频道ID生成静态页面（根据参数选择是否生成该频道下面的所有子类别页面）
        /// </summary>
        /// <param name="ID">当前频道编号</param>
        /// <param name="isAllCreate"></param>
        /// <returns></returns>
        public void CreatHtmlByChannelID(int ID, bool isAllCreate)
        {
            if (!isAllCreate)
            {
                Pbzx.Model.PBnet_UrlMaping model = GetModel(ID);
                if (model.Aspx.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/PB_Manage/" + model.Aspx + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.PageName.Trim() + "成功！');</script>");
                }
                else if (model.Aspx.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(model.Aspx);
                }
                else
                {
                    if (Files.Create(model.Html, model.Aspx))
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.PageName.Trim() + "成功！');</script>");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.PageName.Trim() + "失败！');</script>");
                    }
                }
            }
            else
            {
                Pbzx.Model.PBnet_UrlMaping model = GetModel(ID);
                if (model.Aspx.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/PB_Manage/" + model.Aspx + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.PageName.Trim() + "成功！');</script>");
                }
                else if (model.Aspx.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(model.Aspx);
                }
                else
                {
                    Files.Create(model.Html, model.Aspx);
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.PageName.Trim() + "成功！');</script>");
                }               
                DataSet ds = GetList(" FID=" + ID);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Files.Create(row["Html"].ToString(), row["Aspx"].ToString());
                        CreatHtmlByChannelID(int.Parse(row["MapID"].ToString()), true);
                    }
                }
                
            }
        }


        /// <summary>
        /// 根据频道ID生成静态页面（根据参数选择是否生成该频道下面的所有子类别页面）
        /// </summary>
        /// <param name="ID">当前频道编号</param>
        /// <param name="isAllCreate"></param>
        /// <returns></returns>
        public void CreatHtmlBy(int ID, bool isAllCreate)
        {
            if (!isAllCreate)
            {
                Pbzx.Model.PBnet_UrlMaping model = GetModel(ID);
                if (model.Aspx.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/PB_Manage/" + model.Aspx + ".aspx");
                    
                }
                else if (model.Aspx.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(model.Aspx);
                }
                else
                {
                    if (Files.Create(model.Html, model.Aspx))
                    {
                       
                    }
                    else
                    {
                       
                    }
                }
            }
            else
            {
                Pbzx.Model.PBnet_UrlMaping model = GetModel(ID);
                if (model.Aspx.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/PB_Manage/" + model.Aspx + ".aspx");
                    
                }
                else if (model.Aspx.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(model.Aspx);
                }
                else
                {
                    Files.Create(model.Html, model.Aspx);
                    
                }
                DataSet ds = GetList(" FID=" + ID);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Files.Create(row["Html"].ToString(), row["Aspx"].ToString());
                        CreatHtmlByChannelID(int.Parse(row["MapID"].ToString()), true);
                    }
                }

            }
        }
        /// <summary>
        /// 批量生成静态页面
        /// </summary>
        /// <param name="ids"></param>
        public void CreateHtmlByBatch(string ids)
        {
           string [] myIds = ids.Split(new char[] {','});
            foreach(string str in myIds)
            {
                CreatHtmlByChannelID(int.Parse(str), false);
            }
            System.Web.HttpContext.Current.Response.Write("<script>alert('批量生成静态页面成功！');</script>");
        }
        /// <summary>
        /// 全部生成静态页面
        /// </summary>
        public void CreateHtmlByBatch()
        {
            DataTable  dt = GetAllList().Tables[0];
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Pbzx.Model.PBnet_UrlMaping model = GetModel(Convert.ToInt32(row["MapID"]));
                    if (model.Aspx.IndexOf(".aspx") < 0)
                    {
                        System.Web.HttpContext.Current.Server.Execute("/PB_Manage/" + model.Aspx + ".aspx");
                    }
                    else if (model.Aspx.IndexOf("RefurbishCpXml.aspx") > 0)
                    {
                        System.Web.HttpContext.Current.Server.Execute(model.Aspx);                         
                    }
                    else
                    {
                        Files.Create(model.Html, model.Aspx);
                    }
                }
                System.Web.HttpContext.Current.Response.Write("<script>alert('全部生成静态页面成功！');</script>");
            }
        }


        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UrlMaping GetModelName(string Name)
        {
            List<Pbzx.Model.PBnet_UrlMaping> ls = GetModelList(" PageName='" + Name + "'");
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
        /// 根据页面名称删除数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int DelName(string strID)
        {
            string sql = "DELETE FROM PBnet_UrlMaping WHERE PageName ='" + strID + "'";
            return dal.ExecuteBySql(sql);
        }
    }
}

