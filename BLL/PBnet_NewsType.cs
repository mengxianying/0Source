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
	/// ҵ���߼���PBnet_NewsType ��ժҪ˵����
	/// </summary>
	public class PBnet_NewsType
	{
		private readonly IPBnet_NewsType dal=DataAccess.CreatePBnet_NewsType();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_NewsType", "IntNewsTypeID");
		public PBnet_NewsType()
		{}
		#region  ��Ա����

        ///// <summary>
        ///// �õ����ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //    return dal.GetMaxId();
        //}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int IntNewsTypeID)
		{
			return dal.Exists(IntNewsTypeID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_NewsType model)
		{
            return dal.Add(model) > 0 ? true : false; 
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_NewsType model)
		{
           return dal.Update(model) > 0 ? true : false; 
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int IntNewsTypeID)
		{

            return dal.Delete(IntNewsTypeID) > 0 ? true : false; 
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_NewsType GetModel(int IntNewsTypeID)
		{
			
			return dal.GetModel(IntNewsTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_NewsType GetModelByCache(int IntNewsTypeID)
		{
			
			string CacheKey = "PBnet_NewsTypeModel-" + IntNewsTypeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IntNewsTypeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_NewsType)objModel;
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
        public List<Pbzx.Model.PBnet_NewsType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_NewsType> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_NewsType> modelList = new List<Pbzx.Model.PBnet_NewsType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_NewsType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_NewsType();
                    if (dt.Rows[n]["IntNewsTypeID"].ToString() != "")
                    {
                        model.IntNewsTypeID = int.Parse(dt.Rows[n]["IntNewsTypeID"].ToString());
                    }
                    model.VarTypeName = dt.Rows[n]["VarTypeName"].ToString();
                    if (dt.Rows[n]["IntTypeFID"].ToString() != "")
                    {
                        model.IntTypeFID = int.Parse(dt.Rows[n]["IntTypeFID"].ToString());
                    }
                    if (dt.Rows[n]["IntTypeLevel"].ToString() != "")
                    {
                        model.IntTypeLevel = int.Parse(dt.Rows[n]["IntTypeLevel"].ToString());
                    }
                    if (dt.Rows[n]["BitComment"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitComment"].ToString() == "1") || (dt.Rows[n]["BitComment"].ToString().ToLower() == "true"))
                        {
                            model.BitComment = true;
                        }
                        else
                        {
                            model.BitComment = false;
                        }
                    }
                    if (dt.Rows[n]["BitIsAuditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsAuditing"].ToString() == "1") || (dt.Rows[n]["BitIsAuditing"].ToString().ToLower() == "true"))
                        {
                            model.BitIsAuditing = true;
                        }
                        else
                        {
                            model.BitIsAuditing = false;
                        }
                    }
                    model.IntOrderID = dt.Rows[n]["IntOrderID"].ToString();
                    if (dt.Rows[n]["Depth"].ToString() != "")
                    {
                        model.Depth = int.Parse(dt.Rows[n]["Depth"].ToString());
                    }
                    if (dt.Rows[n]["RootID"].ToString() != "")
                    {
                        model.RootID = int.Parse(dt.Rows[n]["RootID"].ToString());
                    }
                    model.ModuleFIDS = dt.Rows[n]["ModuleFIDS"].ToString();
                    model.TypeEnName = dt.Rows[n]["TypeEnName"].ToString();
                    if (dt.Rows[n]["DisCount"].ToString() != "")
                    {
                        model.DisCount = int.Parse(dt.Rows[n]["DisCount"].ToString());
                    }
                    if (dt.Rows[n]["IntSortID"].ToString() != "")
                    {
                        model.IntSortID = int.Parse(dt.Rows[n]["IntSortID"].ToString());
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
        #region   �Լ����巽��
        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_NewsType", "IntNewsTypeID");
            return bac.GetLisBySql(strSql);
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentClass"></param>
        public void BindNewsType(DropDownList list, int parentClass)
        {

            DataTable dt = GetLisBySql("select * from PBnet_NewsType where IntTypeFID =" + parentClass + " and BitIsAuditing=1  order by IntTypeFID ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                if (parentClass != 0)
                {
                    sb.Append("-|");
                }
                sb.Append(row["VarTypeName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["IntNewsTypeID"].ToString()));
                BindNewsType(list, int.Parse(row["IntNewsTypeID"].ToString()));
            }          
        }

        /// <summary>
        /// ����Ƶ����������𷽷�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentClass"></param>
        /// <param name="channelID"></param>
        public void BindNewsTypeByChannel(DropDownList list,int channelID)
        {
            list.Items.Clear();
            DataTable dt = GetLisBySql("select * from PBnet_NewsType where IntTypeLevel='" + channelID + "' and BitIsAuditing=1   order by IntTypeFID ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                if (Convert.ToInt32(row["IntNewsTypeID"]) != 0)
                {
                    sb.Append("-|");
                }
                sb.Append(row["VarTypeName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["IntNewsTypeID"].ToString()));
                BindNewsType(list, int.Parse(row["IntNewsTypeID"].ToString()));
            }

        }



        #endregion �Լ����巽��
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_NewsType", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        public DataTable GetListBySort()
        {
            return basicDAL.GetLisBySql("SELECT * FROM PBnet_NewsType ORDER BY IntSortID ASC");
        }

        public DataTable GetRootList()
        {
            return basicDAL.GetLisBySql("SELECT * FROM PBnet_NewsType WHERE Depth=0");
        }
        /// <summary>
        /// ������²����ID.
        /// </summary>
        public int GetInsertID()
        {            
            return Convert.ToInt32(basicDAL.GetValue("TOP 1 IntNewsTypeID", "", " IntNewsTypeID DESC"));
        }
        
        /// <summary>
        /// ����������Ƶõ������ϸ��Ϣ
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public Pbzx.Model.PBnet_NewsType GetModelByTypeName(string newsType)
        {
            List<Pbzx.Model.PBnet_NewsType> lsNews = GetModelList(" VarTypeName='" + newsType + "'  ");
            if (lsNews.Count > 0)
            {
                return lsNews[0];
            }
            else
            {
                return null;
            }
        }

        public  static string ReturnId(string TypeName)
        {
            Pbzx.BLL.PBnet_NewsType bll = new PBnet_NewsType();
            List<Pbzx.Model.PBnet_NewsType> lsNews = bll.GetModelList(" VarTypeName='" + Input.FilterAll(TypeName) + "'  ");
            if (lsNews.Count > 0)
            {
                return lsNews[0].IntNewsTypeID.ToString();
            }
            else
            {
                return null;
            }
        }
        #region ���ɾ�̬ҳ��

        /// <summary>
        /// ����ID��ȡģ��㼶��ϵ
        /// </summary>
        /// <param name="moduleid"></param>
        /// <returns></returns>
        public string[] ModuleGetContents(int moduleid)
        {
            Pbzx.Model.PBnet_NewsType MI = GetModel(moduleid);
            string[] FIDS = MI.ModuleFIDS.Split(new char[] { '|' });
            return FIDS;
            
        }

        /// <summary>
        /// ����ģ��ID��ȡƵ���ļ�Ŀ¼ �ָ���"/"
        /// </summary>
        /// <param name="Moduleid"></param>
        /// <returns></returns>
        public string ChannelGetFolder(int Moduleid)
        {
            string[] FIDS = ModuleGetContents(Moduleid);
            string FID = null;
            for (int i = 0; i < FIDS.Length; i++)
            {
                FID = FID + dal.GetModel(int.Parse(FIDS[i])).TypeEnName + @"/";//
            }
            return FID;
        }


        /// <summary>
        /// ����ģ��ID��ȡ���򵼺��˵�
        /// </summary>
        /// <param name="Moduleid"></param>
        /// <param name="IsShowIndexName">�Ƿ���ʾ��ҳ����</param>
        /// <param name="flag">���������:>></param>
        /// <returns></returns>
        public string ChannelGetNavigation(int Moduleid, bool IsShowIndexName, string flag)
        {
            string FID = "";
            string[] FIDS = ModuleGetContents(Moduleid);
            if (IsShowIndexName)
                FID = "<a  href='" + WebInit.webBaseConfig.WebUrl + "' target='_self' class='school'>" + WebInit.webBaseConfig.WebName + "</a> >> <a href='" + WebInit.webBaseConfig.WebUrl + "News.htm' target='_self' class='school'>������Ѷ</a>";

            if (!string.IsNullOrEmpty(FIDS[0]))
            {
                for (int i = 0; i < FIDS.Length; i++)
                {
                    Pbzx.Model.PBnet_NewsType mi = dal.GetModel(int.Parse(FIDS[i]));
                    string ChannelName = "<a  style='cursor:pointer;' href='" + WebInit.webBaseConfig.WebUrl + "News_list.aspx?NewsType=" + Input.Encrypt(mi.IntNewsTypeID.ToString()) + "'  class='school'>" + mi.VarTypeName + "</a>";
                    // string ChannelUrl = m;
                    FID += flag + ChannelName;//"<a href='" + ChannelUrl + "'>" ++ "</a>"
                }
            }
            else
            {
                FID = "";
            }
        
            return FID;
        }

        #endregion


        public DataTable GetTitleListByCount(string strWhere, int count)
        {

            StringBuilder strSql = new StringBuilder();
            if (count > 0)
            {
                strSql.Append("select top " + count + " IntNewsTypeID,VarTypeName ");
            }
            else
            {
                strSql.Append("select IntNewsTypeID,VarTypeName ");
            }


            strSql.Append(" FROM PBnet_NewsType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dal.Query(strSql.ToString());
        }

        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_NewsType", "IntNewsTypeID");
            basicDAL1.ChangeAudit(id, filed);
        }
        /// <summary>
        /// �Լ���������û����õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_NewsType GetModelName(string Name)
        {

            List<Pbzx.Model.PBnet_NewsType> ls = GetModelList(" IntOrderID='" + Name + "' and BitIsAuditing=1 and BitComment=1  ");
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
        /// �Ƚϲ���������MusicEntry��������д���
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CompareProductEntry(Pbzx.Model.PBnet_NewsType x, Pbzx.Model.PBnet_NewsType y)
        {
            return ((int)x.IntSortID).CompareTo(((int)y.IntSortID));
        }

        /// <summary>
        /// �õ���������������б�
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_NewsType> GetProductListSort(string strWhere)
        {
            List<Pbzx.Model.PBnet_NewsType> data = GetModelList(strWhere);
            if (data.Count > 1)
            {
                Pbzx.Model.PBnet_NewsType productM = new Pbzx.Model.PBnet_NewsType();
                data.Sort(productM);
            }
            return data;
        }

    }
}

