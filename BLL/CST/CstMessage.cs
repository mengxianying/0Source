using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���CstMessage ��ժҪ˵����
    /// </summary>
    public class CstMessage
    {
        private readonly ICstMessage dal = DataAccess.CreateCstMessage();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CstMessage", "ID");

        public CstMessage()
        {
            basicDAL.IsCst = true;
        }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.CstMessage model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CstMessage model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false; 
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CstMessage GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CstMessage GetModelByCache(int ID)
        {

            string CacheKey = "CstMessageModel-" + ID;
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
            return (Pbzx.Model.CstMessage)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.CstMessage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CstMessage> modelList = new List<Pbzx.Model.CstMessage>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CstMessage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CstMessage();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.MsgSender = ds.Tables[0].Rows[n]["MsgSender"].ToString();
                    if (ds.Tables[0].Rows[n]["MsgLevel"].ToString() != "")
                    {
                        model.MsgLevel = int.Parse(ds.Tables[0].Rows[n]["MsgLevel"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["MsgType"].ToString() != "")
                    {
                        model.MsgType = int.Parse(ds.Tables[0].Rows[n]["MsgType"].ToString());
                    }
                    model.MsgCategory = ds.Tables[0].Rows[n]["MsgCategory"].ToString();
                    if (ds.Tables[0].Rows[n]["MsgSend"].ToString() != "")
                    {
                        if ((ds.Tables[0].Rows[n]["MsgSend"].ToString() == "1") || (ds.Tables[0].Rows[n]["MsgSend"].ToString().ToLower() == "true"))
                        {
                            model.MsgSend = true;
                        }
                        else
                        {
                            model.MsgSend = false;
                        }
                    }
                    model.MsgTitle = ds.Tables[0].Rows[n]["MsgTitle"].ToString();
                    if (ds.Tables[0].Rows[n]["MsgTime"].ToString() != "")
                    {
                        model.MsgTime = DateTime.Parse(ds.Tables[0].Rows[n]["MsgTime"].ToString());
                    }
                    model.MsgContent = ds.Tables[0].Rows[n]["MsgContent"].ToString();
                    if (ds.Tables[0].Rows[n]["MsgST"].ToString() != "")
                    {
                        model.MsgST = int.Parse(ds.Tables[0].Rows[n]["MsgST"].ToString());
                    }
                    model.MsgPV = ds.Tables[0].Rows[n]["MsgPV"].ToString();
                    if (ds.Tables[0].Rows[n]["MsgIT"].ToString() != "")
                    {
                        model.MsgIT = int.Parse(ds.Tables[0].Rows[n]["MsgIT"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(ds.Tables[0].Rows[n]["LoginCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["TotalCount"].ToString() != "")
                    {
                        model.TotalCount = int.Parse(ds.Tables[0].Rows[n]["TotalCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LLTime"].ToString() != "")
                    {
                        model.LLTime = DateTime.Parse(ds.Tables[0].Rows[n]["LLTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["PostTime1"].ToString() != "")
                    {
                        model.PostTime1 = DateTime.Parse(ds.Tables[0].Rows[n]["PostTime1"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["PostTime2"].ToString() != "")
                    {
                        model.PostTime2 = DateTime.Parse(ds.Tables[0].Rows[n]["PostTime2"].ToString());
                    }
                    model.UserID = ds.Tables[0].Rows[n]["UserID"].ToString();
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

        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public  void ChangeAudit(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }
        #endregion  ��Ա����

        #region

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch("ID", "CstMessage", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ������²����ID.
        /// </summary>
        public int GetInsertID()
        {
            return Convert.ToInt32(basicDAL.GetValue("TOP 1 ID", "", " ID DESC"));
        }


       
        #endregion
    }
}

