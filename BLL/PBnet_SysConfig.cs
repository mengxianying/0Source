using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pbzx.BLL
{
    public class PBnet_SysConfig
    {
        //private readonly IPBnet_SysConfig dal=DataAccess.CreatePBnet_SysConfig();
        private readonly Pbzx.SQLServerDAL.PBnet_SysConfig dal = new Pbzx.SQLServerDAL.PBnet_SysConfig();
		public PBnet_SysConfig()
		{}
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
		public int  Add(Pbzx.Model.PBnet_SysConfig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_SysConfig model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_SysConfig GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_SysConfig GetModelByCache(int ID)
		{
			
			string CacheKey = "PBnet_SysConfigModel-" + ID;
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
				catch{}
			}
			return (Pbzx.Model.PBnet_SysConfig)objModel;
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
		public List<Pbzx.Model.PBnet_SysConfig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_SysConfig> modelList = new List<Pbzx.Model.PBnet_SysConfig>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_SysConfig model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_SysConfig();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
					model.Master=ds.Tables[0].Rows[n]["Master"].ToString();
					model.Email=ds.Tables[0].Rows[n]["Email"].ToString();
					model.Telephone=ds.Tables[0].Rows[n]["Telephone"].ToString();
					model.Address=ds.Tables[0].Rows[n]["Address"].ToString();
					model.CopyRight=ds.Tables[0].Rows[n]["CopyRight"].ToString();
					model.CharSet=ds.Tables[0].Rows[n]["CharSet"].ToString();
					model.MailSender=ds.Tables[0].Rows[n]["MailSender"].ToString();
					model.Sender=ds.Tables[0].Rows[n]["Sender"].ToString();
					model.ReplyTo=ds.Tables[0].Rows[n]["ReplyTo"].ToString();
					model.UserName=ds.Tables[0].Rows[n]["UserName"].ToString();
					model.Password=ds.Tables[0].Rows[n]["Password"].ToString();
					model.MailServer=ds.Tables[0].Rows[n]["MailServer"].ToString();
					model.Remark=ds.Tables[0].Rows[n]["Remark"].ToString();
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

        #region �Զ��巽��

        public Pbzx.Model.PBnet_SysConfig GetEntity()
        {
            return dal.GetModel(1);
        }

        public static Pbzx.Model.PBnet_SysConfig WebConfig;

        public static void InitConfig()
        {
            if (string.IsNullOrEmpty(Common.Language.strLang)) Common.Language.strLang = "CN";
            PBnet_SysConfig CfgBLL = new PBnet_SysConfig();
            WebConfig = CfgBLL.GetEntity();
        }

        public static void InitConfig(string xmlfile)
        {
            if (string.IsNullOrEmpty(Common.Language.strLang)) Common.Language.strLang = "CN";
            PBnet_SysConfig CfgBLL = new PBnet_SysConfig();
            WebConfig = CfgBLL.GetEntity();
            Common.Language.Text = MyXML.GetXMLValues(xmlfile);
        }

        #endregion
    }
}
