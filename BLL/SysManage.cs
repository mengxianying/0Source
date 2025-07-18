using System.Data;
using Pbzx.Model;
namespace Pbzx.BLL
{
	/// <summary>
	/// SysManage 的摘要说明。
	/// </summary>
	public class SysManage
	{
        //从工厂里面创建产品类的数据访问对象
        Pbzx.IDAL.ISysManage dal = DALFactory.DataAccess.CreateSysManage();

		public SysManage()
		{
        }

        #region 基本方法
        public int AddTreeNode(SysNode node)
		{			
			return dal.AddTreeNode(node);
		}
		public void UpdateNode(SysNode node)
		{			
			dal.UpdateNode(node);
		}
		public void DelTreeNode(int nodeid)
		{			
			dal.DelTreeNode(nodeid);
		}
		public DataSet GetTreeList(string strWhere)
		{			
			return dal.GetTreeList(strWhere);
		}
		public SysNode GetNode(int NodeID)
		{			
			return dal.GetNode(NodeID);
        }

        #endregion

        #region 日志管理
        public void AddLog(string time,string loginfo,string Particular)
		{			
			dal.AddLog(time,loginfo,Particular);
		}
		public void DelOverdueLog(int days)
		{						
			dal.DelOverdueLog(days);
		}
		public void DeleteLog(string Idlist)
		{			
			string str="";
			if(Idlist.Trim()!="")
			{
				str=" ID in ("+Idlist+")";
			}
			dal.DeleteLog(str);
		}
		public void DeleteLog(string timestart,string timeend)
		{			
			string str=" datetime>'"+timestart+"' and datetime<'"+timeend+"'";
			dal.DeleteLog(str);
		}
		public DataSet GetLogs(string strWhere)
		{			
			return dal.GetLogs(strWhere);
		}
		public DataRow GetLog(string ID)
		{			
			return dal.GetLog(ID);
        }

        #endregion


    }
}
