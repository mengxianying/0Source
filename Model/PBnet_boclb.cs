using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_boclb 。(属性说明自动提取数据库字段的描述信息)
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

