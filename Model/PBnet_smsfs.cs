using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_smsfs 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_smsfs
	{
		public PBnet_smsfs()
		{}
		#region Model
		private int _id;
		private int? _pb_smsid;
		private string _pbnet_smsfsmsg;
		private DateTime? _pb_intime;
		private string _pb_author;
		private bool _pb_isnew;
		private int? _pb_cpnum;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_smsid
		{
			set{ _pb_smsid=value;}
			get{return _pb_smsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PBnet_smsfsmsg
		{
			set{ _pbnet_smsfsmsg=value;}
			get{return _pbnet_smsfsmsg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? pb_intime
		{
			set{ _pb_intime=value;}
			get{return _pb_intime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pb_author
		{
			set{ _pb_author=value;}
			get{return _pb_author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pb_isnew
		{
			set{ _pb_isnew=value;}
			get{return _pb_isnew;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_cpnum
		{
			set{ _pb_cpnum=value;}
			get{return _pb_cpnum;}
		}
		#endregion Model

	}
}

