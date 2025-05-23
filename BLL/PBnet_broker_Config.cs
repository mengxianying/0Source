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
    /// ҵ���߼���PBnet_broker_Config ��ժҪ˵����
    /// </summary>
    public class PBnet_broker_Config
    {
        private readonly IPBnet_broker_Config dal = DataAccess.CreatePBnet_broker_Config();
        public PBnet_broker_Config()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_broker_Config model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_broker_Config model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_broker_Config GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_broker_Config GetModelByCache(int Id)
        {

            string CacheKey = "PBnet_broker_ConfigModel-" + Id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_broker_Config)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_broker_Config> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_broker_Config> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_broker_Config> modelList = new List<Pbzx.Model.PBnet_broker_Config>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_broker_Config model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_broker_Config();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["Discount_grade"].ToString() != "")
                    {
                        model.Discount_grade = int.Parse(dt.Rows[n]["Discount_grade"].ToString());
                    }
                    model.Discount_gradeName = dt.Rows[n]["Discount_gradeName"].ToString();
                    if (dt.Rows[n]["Discount_rate"].ToString() != "")
                    {
                        model.Discount_rate = int.Parse(dt.Rows[n]["Discount_rate"].ToString());
                    }
                    if (dt.Rows[n]["Min_tradeMoney"].ToString() != "")
                    {
                        model.Min_tradeMoney = decimal.Parse(dt.Rows[n]["Min_tradeMoney"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_broker_Config", "Id");
            return bac.GetLisBySql(strSql);
        }


        public void BindGrade(DropDownList list)
        {

            DataTable dt = GetLisBySql("select * from PBnet_broker_Config ");
            foreach (DataRow row in dt.Rows)
            {
                list.Items.Add(new ListItem(row["Discount_gradeName"].ToString(), row["Discount_gradeName"].ToString()));
           }
        }
        public void BindRate(DropDownList list)
        {

            DataTable dt = GetLisBySql("select * from PBnet_broker_Config ");
            foreach (DataRow row in dt.Rows)
            {
                list.Items.Add(new ListItem(row["Discount_rate"].ToString(), row["Discount_rate"].ToString()));
            }
        }
        /// <summary>
        /// �Լ���������û����õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_broker_Config GetGrade(string Grade)
        {

            List<Pbzx.Model.PBnet_broker_Config> ls = GetModelList(" Discount_grade='" + Grade + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

    }
}

