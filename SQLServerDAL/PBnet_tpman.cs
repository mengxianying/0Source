using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_tpman。
	/// </summary>
	public class PBnet_tpman:IPBnet_tpman
	{
		public PBnet_tpman()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Master_Id", "PBnet_tpman"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Master_Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_tpman");
			strSql.Append(" where Master_Id=@Master_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4)};
			parameters[0].Value = Master_Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_tpman model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into PBnet_tpman(");
            strSql.Append("Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State,CpData_Setting,LoginCount,UserGroup,ipLimit,regionLimit)");
            strSql.Append(" values (");
            strSql.Append("@Master_Name,@Master_Password,@Column_Setting,@Setting,@LasTime,@LastIP,@Cookiess,@State,@CpData_Setting,@LoginCount,@UserGroup,@ipLimit,@regionLimit)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Master_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Master_Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Column_Setting", SqlDbType.VarChar,2000),
					new SqlParameter("@Setting", SqlDbType.VarChar,2000),
					new SqlParameter("@LasTime", SqlDbType.SmallDateTime),
					new SqlParameter("@LastIP", SqlDbType.NVarChar,15),
					new SqlParameter("@Cookiess", SqlDbType.NVarChar,10),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@CpData_Setting", SqlDbType.VarChar,2000),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@UserGroup", SqlDbType.VarChar,50),
					new SqlParameter("@ipLimit", SqlDbType.NVarChar,200),
					new SqlParameter("@regionLimit", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Master_Name;
            parameters[1].Value = model.Master_Password;
            parameters[2].Value = model.Column_Setting;
            parameters[3].Value = model.Setting;
            parameters[4].Value = model.LasTime;
            parameters[5].Value = model.LastIP;
            parameters[6].Value = model.Cookiess;
            parameters[7].Value = model.State;
            parameters[8].Value = model.CpData_Setting;
            parameters[9].Value = model.LoginCount;
            parameters[10].Value = model.UserGroup;
            parameters[11].Value = model.ipLimit;
            parameters[12].Value = model.regionLimit;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Pbzx.Model.PBnet_tpman model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update PBnet_tpman set ");
            strSql.Append("Master_Name=@Master_Name,");
            strSql.Append("Master_Password=@Master_Password,");
            strSql.Append("Column_Setting=@Column_Setting,");
            strSql.Append("Setting=@Setting,");
            strSql.Append("LasTime=@LasTime,");
            strSql.Append("LastIP=@LastIP,");
            strSql.Append("Cookiess=@Cookiess,");
            strSql.Append("State=@State,");
            strSql.Append("CpData_Setting=@CpData_Setting,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("UserGroup=@UserGroup,");
            strSql.Append("ipLimit=@ipLimit,");
            strSql.Append("regionLimit=@regionLimit");
            strSql.Append(" where Master_Id=@Master_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Master_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Master_Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Column_Setting", SqlDbType.VarChar,2000),
					new SqlParameter("@Setting", SqlDbType.VarChar,2000),
					new SqlParameter("@LasTime", SqlDbType.SmallDateTime),
					new SqlParameter("@LastIP", SqlDbType.NVarChar,15),
					new SqlParameter("@Cookiess", SqlDbType.NVarChar,10),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@CpData_Setting", SqlDbType.VarChar,2000),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@UserGroup", SqlDbType.VarChar,50),
					new SqlParameter("@ipLimit", SqlDbType.NVarChar,200),
					new SqlParameter("@regionLimit", SqlDbType.NVarChar,100),
					new SqlParameter("@Master_Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Master_Name;
            parameters[1].Value = model.Master_Password;
            parameters[2].Value = model.Column_Setting;
            parameters[3].Value = model.Setting;
            parameters[4].Value = model.LasTime;
            parameters[5].Value = model.LastIP;
            parameters[6].Value = model.Cookiess;
            parameters[7].Value = model.State;
            parameters[8].Value = model.CpData_Setting;
            parameters[9].Value = model.LoginCount;
            parameters[10].Value = model.UserGroup;
            parameters[11].Value = model.ipLimit;
            parameters[12].Value = model.regionLimit;
            parameters[13].Value = model.Master_Id;

		    return	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int Master_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_tpman ");
			strSql.Append(" where Master_Id=@Master_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4)};
			parameters[0].Value = Master_Id;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_tpman GetModel(int Master_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Master_Id,Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State,CpData_Setting,LoginCount,UserGroup,ipLimit,regionLimit from PBnet_tpman ");
            strSql.Append(" where Master_Id=@Master_Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4)
};
            parameters[0].Value = Master_Id;

            Pbzx.Model.PBnet_tpman model = new Pbzx.Model.PBnet_tpman();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Master_Id"].ToString() != "")
                {
                    model.Master_Id = int.Parse(ds.Tables[0].Rows[0]["Master_Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Master_Name"] != null)
                {
                    model.Master_Name = ds.Tables[0].Rows[0]["Master_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Master_Password"] != null)
                {
                    model.Master_Password = ds.Tables[0].Rows[0]["Master_Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Column_Setting"] != null)
                {
                    model.Column_Setting = ds.Tables[0].Rows[0]["Column_Setting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Setting"] != null)
                {
                    model.Setting = ds.Tables[0].Rows[0]["Setting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LasTime"].ToString() != "")
                {
                    model.LasTime = DateTime.Parse(ds.Tables[0].Rows[0]["LasTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastIP"] != null)
                {
                    model.LastIP = ds.Tables[0].Rows[0]["LastIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Cookiess"] != null)
                {
                    model.Cookiess = ds.Tables[0].Rows[0]["Cookiess"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["State"].ToString() == "1") || (ds.Tables[0].Rows[0]["State"].ToString().ToLower() == "true"))
                    {
                        model.State = true;
                    }
                    else
                    {
                        model.State = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CpData_Setting"] != null)
                {
                    model.CpData_Setting = ds.Tables[0].Rows[0]["CpData_Setting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserGroup"] != null)
                {
                    model.UserGroup = ds.Tables[0].Rows[0]["UserGroup"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ipLimit"] != null)
                {
                    model.ipLimit = ds.Tables[0].Rows[0]["ipLimit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["regionLimit"] != null)
                {
                    model.regionLimit = ds.Tables[0].Rows[0]["regionLimit"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
		}



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_tpman GetModelByName(string Master_Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Master_Id,Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State,CpData_Setting,LoginCount,UserGroup,ipLimit,regionLimit from PBnet_tpman ");
            strSql.Append(" where Master_Name=@Master_Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Master_Name", SqlDbType.NVarChar,50)
};
            parameters[0].Value = Master_Name;

            Pbzx.Model.PBnet_tpman model = new Pbzx.Model.PBnet_tpman();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Master_Id"].ToString() != "")
                {
                    model.Master_Id = int.Parse(ds.Tables[0].Rows[0]["Master_Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Master_Name"] != null)
                {
                    model.Master_Name = ds.Tables[0].Rows[0]["Master_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Master_Password"] != null)
                {
                    model.Master_Password = ds.Tables[0].Rows[0]["Master_Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Column_Setting"] != null)
                {
                    model.Column_Setting = ds.Tables[0].Rows[0]["Column_Setting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Setting"] != null)
                {
                    model.Setting = ds.Tables[0].Rows[0]["Setting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LasTime"].ToString() != "")
                {
                    model.LasTime = DateTime.Parse(ds.Tables[0].Rows[0]["LasTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastIP"] != null)
                {
                    model.LastIP = ds.Tables[0].Rows[0]["LastIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Cookiess"] != null)
                {
                    model.Cookiess = ds.Tables[0].Rows[0]["Cookiess"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["State"].ToString() == "1") || (ds.Tables[0].Rows[0]["State"].ToString().ToLower() == "true"))
                    {
                        model.State = true;
                    }
                    else
                    {
                        model.State = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CpData_Setting"] != null)
                {
                    model.CpData_Setting = ds.Tables[0].Rows[0]["CpData_Setting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserGroup"] != null)
                {
                    model.UserGroup = ds.Tables[0].Rows[0]["UserGroup"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ipLimit"] != null)
                {
                    model.ipLimit = ds.Tables[0].Rows[0]["ipLimit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["regionLimit"] != null)
                {
                    model.regionLimit = ds.Tables[0].Rows[0]["regionLimit"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select Master_Id,Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State,CpData_Setting,LoginCount,UserGroup,ipLimit,regionLimit ");
            strSql.Append(" FROM PBnet_tpman ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PBnet_tpman";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

