using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类CstMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CstMessage
	{
		public CstMessage()
		{
            _userid = "@#";
        }
		#region Model
		private int _id;
		private string _msgsender;
		private int? _msglevel;
		private int? _msgtype;
		private string _msgcategory;
		private bool _msgsend;
		private string _msgtitle;
		private DateTime _msgtime;
		private string _msgcontent;
		private int? _msgst;
		private string _msgpv;
		private int? _msgit;
		private int? _logincount;
		private int? _totalcount;
		private DateTime? _lltime;
		private DateTime? _posttime1;
		private DateTime? _posttime2;
		private string _userid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgSender
		{
			set{ _msgsender=value;}
			get{return _msgsender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MsgLevel
		{
			set{ _msglevel=value;}
			get{return _msglevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgCategory
		{
			set{ _msgcategory=value;}
			get{return _msgcategory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool MsgSend
		{
			set{ _msgsend=value;}
			get{return _msgsend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgTitle
		{
			set{ _msgtitle=value;}
			get{return _msgtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime MsgTime
		{
			set{ _msgtime=value;}
			get{return _msgtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgContent
		{
			set{ _msgcontent=value;}
			get{return _msgcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MsgST
		{
			set{ _msgst=value;}
			get{return _msgst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgPV
		{
			set{ _msgpv=value;}
			get{return _msgpv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MsgIT
		{
			set{ _msgit=value;}
			get{return _msgit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LoginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TotalCount
		{
			set{ _totalcount=value;}
			get{return _totalcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LLTime
		{
			set{ _lltime=value;}
			get{return _lltime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PostTime1
		{
			set{ _posttime1=value;}
			get{return _posttime1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PostTime2
		{
			set{ _posttime2=value;}
			get{return _posttime2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

