using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_ask_Attach ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int? QuestionId
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// Դ�ļ���ַ
		/// </summary>
		public string OriginalFile
		{
			set{ _originalfile=value;}
			get{return _originalfile;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �ϴ�ʱ��
		/// </summary>
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �ļ���С
		/// </summary>
		public decimal? FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// �ظ�ID
		/// </summary>
		public int? ReplayId
		{
			set{ _replayid=value;}
			get{return _replayid;}
		}
		#endregion Model

	}
}

