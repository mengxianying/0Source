using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_boclb ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class PBnet_boclb
	{
		public PBnet_boclb()
		{}
		#region Model
		private int _bocid;
		private string _pbnet_boclbname;
		/// <summary>
		/// 
		/// </summary>
		public int bocid
		{
			set{ _bocid=value;}
			get{return _bocid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PBnet_boclbname
		{
			set{ _pbnet_boclbname=value;}
			get{return _pbnet_boclbname;}
		}
		#endregion Model

	}
}

