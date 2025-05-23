using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_arltype 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_arltype
	{
		public PBnet_arltype()
		{}
		#region Model
		private int _id;
		private string _pb_title;
		private string _pb_code;
		private int? _pb_type;
		private string _pb_info;
		private int? _pb_viewnum;
		private int? _pb_countnum;
		private int? _pb_mangernum;
		private bool _pb_isout;
		private string _pb_outurl;
		private int? _pb_styleid;
		private bool _pb_isreview;
		private bool _pb_ispost;
		private bool _pb_istop;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pb_Title
		{
			set{ _pb_title=value;}
			get{return _pb_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pb_Code
		{
			set{ _pb_code=value;}
			get{return _pb_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_Type
		{
			set{ _pb_type=value;}
			get{return _pb_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pb_Info
		{
			set{ _pb_info=value;}
			get{return _pb_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_ViewNum
		{
			set{ _pb_viewnum=value;}
			get{return _pb_viewnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_CountNum
		{
			set{ _pb_countnum=value;}
			get{return _pb_countnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_MangerNum
		{
			set{ _pb_mangernum=value;}
			get{return _pb_mangernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pb_IsOut
		{
			set{ _pb_isout=value;}
			get{return _pb_isout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pb_OutURL
		{
			set{ _pb_outurl=value;}
			get{return _pb_outurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pb_StyleId
		{
			set{ _pb_styleid=value;}
			get{return _pb_styleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pb_IsReview
		{
			set{ _pb_isreview=value;}
			get{return _pb_isreview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pb_IsPost
		{
			set{ _pb_ispost=value;}
			get{return _pb_ispost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pb_IsTop
		{
			set{ _pb_istop=value;}
			get{return _pb_istop;}
		}
		#endregion Model

	}
}

