using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_SoftClass。
	/// </summary>
	public class PBnet_SoftClass:IPBnet_SoftClass
	{
		public PBnet_SoftClass()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("IntClassID", "PBnet_SoftClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int IntClassID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_SoftClass");
			strSql.Append(" where IntClassID=@IntClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IntClassID", SqlDbType.Int,4)};
			parameters[0].Value = IntClassID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_SoftClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_SoftClass(");
			strSql.Append("NvarClassName,IntParentID,Var_ParentPath,IntDepth,IntRootID,IntChild,IntPrevID,Int_NextID,IntOrderID,NvarReadme,IntSetting,NvarLinkUrl,NvarClassPicUrl,IntSkinID,IntLayoutID,IntBrowsePurview,IntAddPurview,BitIsElite,pb_ShowOnTop)");
			strSql.Append(" values (");
			strSql.Append("@NvarClassName,@IntParentID,@Var_ParentPath,@IntDepth,@IntRootID,@IntChild,@IntPrevID,@Int_NextID,@IntOrderID,@NvarReadme,@IntSetting,@NvarLinkUrl,@NvarClassPicUrl,@IntSkinID,@IntLayoutID,@IntBrowsePurview,@IntAddPurview,@BitIsElite,@pb_ShowOnTop)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NvarClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@IntParentID", SqlDbType.Int,4),
					new SqlParameter("@Var_ParentPath", SqlDbType.VarChar,50),
					new SqlParameter("@IntDepth", SqlDbType.Int,4),
					new SqlParameter("@IntRootID", SqlDbType.Int,4),
					new SqlParameter("@IntChild", SqlDbType.Int,4),
					new SqlParameter("@IntPrevID", SqlDbType.Int,4),
					new SqlParameter("@Int_NextID", SqlDbType.Int,4),
					new SqlParameter("@IntOrderID", SqlDbType.Int,4),
					new SqlParameter("@NvarReadme", SqlDbType.NVarChar,500),
					new SqlParameter("@IntSetting", SqlDbType.Int,4),
					new SqlParameter("@NvarLinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@NvarClassPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@IntSkinID", SqlDbType.Int,4),
					new SqlParameter("@IntLayoutID", SqlDbType.Int,4),
					new SqlParameter("@IntBrowsePurview", SqlDbType.Int,4),
					new SqlParameter("@IntAddPurview", SqlDbType.Int,4),
					new SqlParameter("@BitIsElite", SqlDbType.Bit,1),
					new SqlParameter("@pb_ShowOnTop", SqlDbType.Bit,1)};
			parameters[0].Value = model.NvarClassName;
			parameters[1].Value = model.IntParentID;
			parameters[2].Value = model.Var_ParentPath;
			parameters[3].Value = model.IntDepth;
			parameters[4].Value = model.IntRootID;
			parameters[5].Value = model.IntChild;
			parameters[6].Value = model.IntPrevID;
			parameters[7].Value = model.Int_NextID;
			parameters[8].Value = model.IntOrderID;
			parameters[9].Value = model.NvarReadme;
			parameters[10].Value = model.IntSetting;
			parameters[11].Value = model.NvarLinkUrl;
			parameters[12].Value = model.NvarClassPicUrl;
			parameters[13].Value = model.IntSkinID;
			parameters[14].Value = model.IntLayoutID;
			parameters[15].Value = model.IntBrowsePurview;
			parameters[16].Value = model.IntAddPurview;
			parameters[17].Value = model.BitIsElite;
			parameters[18].Value = model.pb_ShowOnTop;

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
		public int Update(Pbzx.Model.PBnet_SoftClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_SoftClass set ");
			strSql.Append("NvarClassName=@NvarClassName,");
			strSql.Append("IntParentID=@IntParentID,");
			strSql.Append("Var_ParentPath=@Var_ParentPath,");
			strSql.Append("IntDepth=@IntDepth,");
			strSql.Append("IntRootID=@IntRootID,");
			strSql.Append("IntChild=@IntChild,");
			strSql.Append("IntPrevID=@IntPrevID,");
			strSql.Append("Int_NextID=@Int_NextID,");
			strSql.Append("IntOrderID=@IntOrderID,");
			strSql.Append("NvarReadme=@NvarReadme,");
			strSql.Append("IntSetting=@IntSetting,");
			strSql.Append("NvarLinkUrl=@NvarLinkUrl,");
			strSql.Append("NvarClassPicUrl=@NvarClassPicUrl,");
			strSql.Append("IntSkinID=@IntSkinID,");
			strSql.Append("IntLayoutID=@IntLayoutID,");
			strSql.Append("IntBrowsePurview=@IntBrowsePurview,");
			strSql.Append("IntAddPurview=@IntAddPurview,");
			strSql.Append("BitIsElite=@BitIsElite,");
			strSql.Append("pb_ShowOnTop=@pb_ShowOnTop");
			strSql.Append(" where IntClassID=@IntClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IntClassID", SqlDbType.Int,4),
					new SqlParameter("@NvarClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@IntParentID", SqlDbType.Int,4),
					new SqlParameter("@Var_ParentPath", SqlDbType.VarChar,50),
					new SqlParameter("@IntDepth", SqlDbType.Int,4),
					new SqlParameter("@IntRootID", SqlDbType.Int,4),
					new SqlParameter("@IntChild", SqlDbType.Int,4),
					new SqlParameter("@IntPrevID", SqlDbType.Int,4),
					new SqlParameter("@Int_NextID", SqlDbType.Int,4),
					new SqlParameter("@IntOrderID", SqlDbType.Int,4),
					new SqlParameter("@NvarReadme", SqlDbType.NVarChar,500),
					new SqlParameter("@IntSetting", SqlDbType.Int,4),
					new SqlParameter("@NvarLinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@NvarClassPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@IntSkinID", SqlDbType.Int,4),
					new SqlParameter("@IntLayoutID", SqlDbType.Int,4),
					new SqlParameter("@IntBrowsePurview", SqlDbType.Int,4),
					new SqlParameter("@IntAddPurview", SqlDbType.Int,4),
					new SqlParameter("@BitIsElite", SqlDbType.Bit,1),
					new SqlParameter("@pb_ShowOnTop", SqlDbType.Bit,1)};
			parameters[0].Value = model.IntClassID;
			parameters[1].Value = model.NvarClassName;
			parameters[2].Value = model.IntParentID;
			parameters[3].Value = model.Var_ParentPath;
			parameters[4].Value = model.IntDepth;
			parameters[5].Value = model.IntRootID;
			parameters[6].Value = model.IntChild;
			parameters[7].Value = model.IntPrevID;
			parameters[8].Value = model.Int_NextID;
			parameters[9].Value = model.IntOrderID;
			parameters[10].Value = model.NvarReadme;
			parameters[11].Value = model.IntSetting;
			parameters[12].Value = model.NvarLinkUrl;
			parameters[13].Value = model.NvarClassPicUrl;
			parameters[14].Value = model.IntSkinID;
			parameters[15].Value = model.IntLayoutID;
			parameters[16].Value = model.IntBrowsePurview;
			parameters[17].Value = model.IntAddPurview;
			parameters[18].Value = model.BitIsElite;
			parameters[19].Value = model.pb_ShowOnTop;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int IntClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_SoftClass ");
			strSql.Append(" where IntClassID=@IntClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IntClassID", SqlDbType.Int,4)};
			parameters[0].Value = IntClassID;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_SoftClass GetModel(int IntClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 IntClassID,NvarClassName,IntParentID,Var_ParentPath,IntDepth,IntRootID,IntChild,IntPrevID,Int_NextID,IntOrderID,NvarReadme,IntSetting,NvarLinkUrl,NvarClassPicUrl,IntSkinID,IntLayoutID,IntBrowsePurview,IntAddPurview,BitIsElite,pb_ShowOnTop from PBnet_SoftClass ");
			strSql.Append(" where IntClassID=@IntClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IntClassID", SqlDbType.Int,4)};
			parameters[0].Value = IntClassID;

			Pbzx.Model.PBnet_SoftClass model=new Pbzx.Model.PBnet_SoftClass();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["IntClassID"].ToString()!="")
				{
					model.IntClassID=int.Parse(ds.Tables[0].Rows[0]["IntClassID"].ToString());
				}
				model.NvarClassName=ds.Tables[0].Rows[0]["NvarClassName"].ToString();
				if(ds.Tables[0].Rows[0]["IntParentID"].ToString()!="")
				{
					model.IntParentID=int.Parse(ds.Tables[0].Rows[0]["IntParentID"].ToString());
				}
				model.Var_ParentPath=ds.Tables[0].Rows[0]["Var_ParentPath"].ToString();
				if(ds.Tables[0].Rows[0]["IntDepth"].ToString()!="")
				{
					model.IntDepth=int.Parse(ds.Tables[0].Rows[0]["IntDepth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntRootID"].ToString()!="")
				{
					model.IntRootID=int.Parse(ds.Tables[0].Rows[0]["IntRootID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntChild"].ToString()!="")
				{
					model.IntChild=int.Parse(ds.Tables[0].Rows[0]["IntChild"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntPrevID"].ToString()!="")
				{
					model.IntPrevID=int.Parse(ds.Tables[0].Rows[0]["IntPrevID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Int_NextID"].ToString()!="")
				{
					model.Int_NextID=int.Parse(ds.Tables[0].Rows[0]["Int_NextID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntOrderID"].ToString()!="")
				{
					model.IntOrderID=int.Parse(ds.Tables[0].Rows[0]["IntOrderID"].ToString());
				}
				model.NvarReadme=ds.Tables[0].Rows[0]["NvarReadme"].ToString();
				if(ds.Tables[0].Rows[0]["IntSetting"].ToString()!="")
				{
					model.IntSetting=int.Parse(ds.Tables[0].Rows[0]["IntSetting"].ToString());
				}
				model.NvarLinkUrl=ds.Tables[0].Rows[0]["NvarLinkUrl"].ToString();
				model.NvarClassPicUrl=ds.Tables[0].Rows[0]["NvarClassPicUrl"].ToString();
				if(ds.Tables[0].Rows[0]["IntSkinID"].ToString()!="")
				{
					model.IntSkinID=int.Parse(ds.Tables[0].Rows[0]["IntSkinID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntLayoutID"].ToString()!="")
				{
					model.IntLayoutID=int.Parse(ds.Tables[0].Rows[0]["IntLayoutID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntBrowsePurview"].ToString()!="")
				{
					model.IntBrowsePurview=int.Parse(ds.Tables[0].Rows[0]["IntBrowsePurview"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IntAddPurview"].ToString()!="")
				{
					model.IntAddPurview=int.Parse(ds.Tables[0].Rows[0]["IntAddPurview"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BitIsElite"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["BitIsElite"].ToString()=="1")||(ds.Tables[0].Rows[0]["BitIsElite"].ToString().ToLower()=="true"))
					{
						model.BitIsElite=true;
					}
					else
					{
						model.BitIsElite=false;
					}
				}
				if(ds.Tables[0].Rows[0]["pb_ShowOnTop"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pb_ShowOnTop"].ToString()=="1")||(ds.Tables[0].Rows[0]["pb_ShowOnTop"].ToString().ToLower()=="true"))
					{
						model.pb_ShowOnTop=true;
					}
					else
					{
						model.pb_ShowOnTop=false;
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
			strSql.Append("select IntClassID,NvarClassName,IntParentID,Var_ParentPath,IntDepth,IntRootID,IntChild,IntPrevID,Int_NextID,IntOrderID,NvarReadme,IntSetting,NvarLinkUrl,NvarClassPicUrl,IntSkinID,IntLayoutID,IntBrowsePurview,IntAddPurview,BitIsElite,pb_ShowOnTop ");
			strSql.Append(" FROM PBnet_SoftClass ");
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
			parameters[0].Value = "PBnet_SoftClass";
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

