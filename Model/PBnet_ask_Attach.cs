using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_ask_Attach 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PBnet_ask_Attach
	{
		public PBnet_ask_Attach()
		{}
		#region Model
		private int _id;
		private int? _questionid;
		private string _originalfile;
		private string _username;
		private DateTime? _addtime;
		private decimal? _filesize;
		private int? _replayid;
		/// <summary>
		/// 索引
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 问题编号
		/// </summary>
		public int? QuestionId
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// 源文件地址
		/// </summary>
		public string OriginalFile
		{
			set{ _originalfile=value;}
			get{return _originalfile;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 文件大小
		/// </summary>
		public decimal? FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// 回复ID
		/// </summary>
		public int? ReplayId
		{
			set{ _replayid=value;}
			get{return _replayid;}
		}
		#endregion Model

	}
}

