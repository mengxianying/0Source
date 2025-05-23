using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_vipman。
	/// </summary>
	public class PBnet_vipman:IPBnet_vipman
	{
		public PBnet_vipman()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Master_Id", "PBnet_vipman"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Master_Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_vipman");
			strSql.Append(" where Master_Id=@Master_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4)};
			parameters[0].Value = Master_Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_vipman model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_vipman(");
			strSql.Append("Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State)");
			strSql.Append(" values (");
			strSql.Append("@Master_Name,@Master_Password,@Column_Setting,@Setting,@LasTime,@LastIP,@Cookiess,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Master_Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Column_Setting", SqlDbType.NText),
					new SqlParameter("@Setting", SqlDbType.NText),
					new SqlParameter("@LasTime", SqlDbType.SmallDateTime),
					new SqlParameter("@LastIP", SqlDbType.NVarChar,15),
					new SqlParameter("@Cookiess", SqlDbType.NVarChar,10),
					new SqlParameter("@State", SqlDbType.Bit,1)};
			parameters[0].Value = model.Master_Name;
			parameters[1].Value = model.Master_Password;
			parameters[2].Value = model.Column_Setting;
			parameters[3].Value = model.Setting;
			parameters[4].Value = model.LasTime;
			parameters[5].Value = model.LastIP;
			parameters[6].Value = model.Cookiess;
			parameters[7].Value = model.State;

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
		public void Update(Pbzx.Model.PBnet_vipman model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_vipman set ");
			strSql.Append("Master_Name=@Master_Name,");
			strSql.Append("Master_Password=@Master_Password,");
			strSql.Append("Column_Setting=@Column_Setting,");
			strSql.Append("Setting=@Setting,");
			strSql.Append("LasTime=@LasTime,");
			strSql.Append("LastIP=@LastIP,");
			strSql.Append("Cookiess=@Cookiess,");
			strSql.Append("State=@State");
			strSql.Append(" where Master_Id=@Master_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4),
					new SqlParameter("@Master_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Master_Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Column_Setting", SqlDbType.NText),
					new SqlParameter("@Setting", SqlDbType.NText),
					new SqlParameter("@LasTime", SqlDbType.SmallDateTime),
					new SqlParameter("@LastIP", SqlDbType.NVarChar,15),
					new SqlParameter("@Cookiess", SqlDbType.NVarChar,10),
					new SqlParameter("@State", SqlDbType.Bit,1)};
			parameters[0].Value = model.Master_Id;
			parameters[1].Value = model.Master_Name;
			parameters[2].Value = model.Master_Password;
			parameters[3].Value = model.Column_Setting;
			parameters[4].Value = model.Setting;
			parameters[5].Value = model.LasTime;
			parameters[6].Value = model.LastIP;
			parameters[7].Value = model.Cookiess;
			parameters[8].Value = model.State;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Master_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_vipman ");
			strSql.Append(" where Master_Id=@Master_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4)};
			parameters[0].Value = Master_Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_vipman GetModel(int Master_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Master_Id,Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State from PBnet_vipman ");
			strSql.Append(" where Master_Id=@Master_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Master_Id", SqlDbType.Int,4)};
			parameters[0].Value = Master_Id;

			Pbzx.Model.PBnet_vipman model=new Pbzx.Model.PBnet_vipman();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Master_Id"].ToString()!="")
				{
					model.Master_Id=int.Parse(ds.Tables[0].Rows[0]["Master_Id"].ToString());
				}
				model.Master_Name=ds.Tables[0].Rows[0]["Master_Name"].ToString();
				model.Master_Password=ds.Tables[0].Rows[0]["Master_Password"].ToString();
				model.Column_Setting=ds.Tables[0].Rows[0]["Column_Setting"].ToString();
				model.Setting=ds.Tables[0].Rows[0]["Setting"].ToString();
				if(ds.Tables[0].Rows[0]["LasTime"].ToString()!="")
				{
					model.LasTime=DateTime.Parse(ds.Tables[0].Rows[0]["LasTime"].ToString());
				}
				model.LastIP=ds.Tables[0].Rows[0]["LastIP"].ToString();
				model.Cookiess=ds.Tables[0].Rows[0]["Cookiess"].ToString();
				if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["State"].ToString()=="1")||(ds.Tables[0].Rows[0]["State"].ToString().ToLower()=="true"))
					{
						model.State=true;
					}
					else
					{
						model.State=false;
					}
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
			strSql.Append("select Master_Id,Master_Name,Master_Password,Column_Setting,Setting,LasTime,LastIP,Cookiess,State ");
			strSql.Append(" FROM PBnet_vipman ");
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
			parameters[0].Value = "PBnet_vipman";
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

