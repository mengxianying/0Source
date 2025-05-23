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
	/// ҵ���߼���PBnet_ask_Type ��ժҪ˵����
	/// </summary>
	public class PBnet_ask_Type
	{
		private readonly IPBnet_ask_Type dal=DataAccess.CreatePBnet_ask_Type();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Type", "Id");
		public PBnet_ask_Type()
		{}
	
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
        public bool Add(Pbzx.Model.PBnet_ask_Type model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_ask_Type model)
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
        public Pbzx.Model.PBnet_ask_Type GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

       /// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_ask_Type GetModelByCache(int Id)
		{
			
			string CacheKey = "PBnet_ask_TypeModel-" + Id;
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
				catch{}
			}
			return (Pbzx.Model.PBnet_ask_Type)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_ask_Type> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_ask_Type> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.PBnet_ask_Type> modelList = new List<Pbzx.Model.PBnet_ask_Type>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_ask_Type model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_ask_Type();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.TypeName=dt.Rows[n]["TypeName"].ToString();
					if(dt.Rows[n]["TypeID"].ToString()!="")
					{
						model.TypeID=int.Parse(dt.Rows[n]["TypeID"].ToString());
					}
					if(dt.Rows[n]["FTypeID"].ToString()!="")
					{
						model.FTypeID=int.Parse(dt.Rows[n]["FTypeID"].ToString());
					}
					if(dt.Rows[n]["OrderID"].ToString()!="")
					{
						model.OrderID=int.Parse(dt.Rows[n]["OrderID"].ToString());
					}
					if(dt.Rows[n]["Depth"].ToString()!="")
					{
						model.Depth=int.Parse(dt.Rows[n]["Depth"].ToString());
					}
					if(dt.Rows[n]["RootID"].ToString()!="")
					{
						model.RootID=int.Parse(dt.Rows[n]["RootID"].ToString());
					}
					model.ModuleFIDS=dt.Rows[n]["ModuleFIDS"].ToString();
					if(dt.Rows[n]["BitIsAuditing"].ToString()!="")
					{
						if((dt.Rows[n]["BitIsAuditing"].ToString()=="1")||(dt.Rows[n]["BitIsAuditing"].ToString().ToLower()=="true"))
						{
						model.BitIsAuditing=true;
						}
						else
						{
							model.BitIsAuditing=false;
						}
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

        /// <summary>
        /// ����������Ƶõ������ϸ��Ϣ
        /// </summary>
        /// <param name="askType"></param>
        /// <returns></returns>
        public Pbzx.Model.PBnet_ask_Type GetModelByTypeName(string askType)
        {
            List<Pbzx.Model.PBnet_ask_Type> lsNews = GetModelList(" TypeName='" + askType + "'");
            if (lsNews.Count > 0)
            {
                return lsNews[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable GetListBySort(int typeID)
        {

            //DataTable dsZY = MyBLL.GetListTitleCount(18, "pb_TypeName='רҵ��'and " + Method.IndexProduct + " ");
            //DataTable dtGS = MyBLL.GetListTitleCount(18, "(pb_TypeName='��Ʊϵͳ') and " + Method.IndexProduct + " ");
            //for (int i = 0; i < dtGS.Rows.Count; i++)
            //{
            //    DataRow myRow = dsZY.NewRow();
            //    myRow.ItemArray = dtGS.Rows[i].ItemArray;
            //    dsZY.Rows.Add(myRow);
            //}
            DataTable dtResult = basicDAL.GetLisBySql("SELECT * FROM PBnet_ask_Type where 1!=1 ");
            DataTable dtRoot = basicDAL.GetLisBySql("SELECT * FROM PBnet_ask_Type where Depth=0  ORDER BY OrderID ASC ");
            for (int i = 0; i < dtRoot.Rows.Count; i++)
            {
                DataRow myResultRow = dtResult.NewRow();
                myResultRow.ItemArray = dtRoot.Rows[i].ItemArray;
                dtResult.Rows.Add(myResultRow);
                DataTable dtSmall = basicDAL.GetLisBySql("SELECT * FROM PBnet_ask_Type where Depth>0 and FTypeID='" + dtRoot.Rows[i]["Id"] + "'  ORDER BY OrderID ASC ");
                for (int j = 0; j < dtSmall.Rows.Count; j++)
                {
                    DataRow myResultRow1 = dtResult.NewRow();
                    myResultRow1.ItemArray = dtSmall.Rows[j].ItemArray;
                    dtResult.Rows.Add(myResultRow1);
                }
            }
            return dtResult;
        }





        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Type", "Id");
            return bac.GetLisBySql(strSql);
        }
        public void BindClass(DropDownList list, int parentClass)
        {

            DataTable dt = GetLisBySql("select * from PBnet_ask_Type where FTypeID =" + parentClass + "order by Id ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                if (parentClass != 0)
                {
                    sb.Append("-|");
                }
                sb.Append(row["TypeName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["Id"].ToString()));
                //�������������������ע
                //BindClass(list, int.Parse(row["Id"].ToString()));
            }

        }
        /// <summary>
        /// ������²����ID.
        /// </summary>
        public int GetInsertID()
        {
            return Convert.ToInt32(basicDAL.GetValue("TOP 1 Id", "", " Id DESC"));
        }
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_ask_Type", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// ����ID��ȡģ��㼶��ϵ
        /// </summary>
        /// <param name="moduleid"></param>
        /// <returns></returns>
        public string[] ModuleGetContents(int moduleid)
        {
            Pbzx.Model.PBnet_ask_Type MI = GetModel(moduleid);

            if(MI == null)
            {
                return new string[] {""};
            }
            string[] FIDS = MI.ModuleFIDS.Split(new char[] { '|' });
            return FIDS;          

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
                FID = "<a href='" + WebInit.ask.WebUrl + "' target='_self'>" + WebInit.ask.WebName + "</a>";
            if (FIDS.Length > 0)
            {
                for (int i = 0; i < FIDS.Length; i++)
                {
                    int tempID = 0;
                    if (int.TryParse(FIDS[i], out tempID))
                    {
                        Pbzx.Model.PBnet_ask_Type mi = dal.GetModel(tempID);//<a href='" + WebInit.ask.WebUrl + "'>
                        string ChannelName = "<a  href='QuestionList.aspx?type=" + Input.Encrypt(mi.Id.ToString()) + "' target='_self'>" + mi.TypeName + "</a>";
                        // string ChannelUrl = m;
                        FID += flag + ChannelName;//"<a href='" + ChannelUrl + "'>" ++ "</a>"
                    }
                }
            }
            else
            {
                FID = "";
            }

            return FID;
        }
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Type", "Id");
            basicDAL1.ChangeAudit(id, filed);
        }
        /// <summary>
        /// �Լ���������û����õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_ask_Type GetModelName(int num)
        {

            List<Pbzx.Model.PBnet_ask_Type> ls = GetModelList(" Id='" + num + "' and BitIsAuditing=1");
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

