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
    /// ҵ���߼���AgentInfo ��ժҪ˵����
    /// </summary>
    public class AgentInfo
    {
        private readonly IAgentInfo dal = DataAccess.CreateAgentInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("AgentInfo", "ID");
   
        public AgentInfo()
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
        public bool Add(Pbzx.Model.AgentInfo model)
        {
           return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.AgentInfo model)
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
        public Pbzx.Model.AgentInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// �Լ���������û����õ�һ������ʵ��
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
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
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
        ////��������µĴ�����

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
            list.Items.Insert(0, new ListItem("����", ""));
            list.Items[0].Selected = true;
            list.Items.Insert(1, new ListItem("��˾ע��", "��˾ע��"));
            list.Items.Insert(2, new ListItem("����ע��", "����ע��"));
            list.Items.Insert(3, new ListItem("��ֵ��ע��", "��ֵ��ע��"));
        }



        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public void ChangeAudit(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }
        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public void ChangeState(int id, string filed)
        {
            basicDAL.ChangeAudit(id, filed);
        }

     }
}

