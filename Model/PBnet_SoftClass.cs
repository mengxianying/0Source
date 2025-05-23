using System;
using System.Collections.Generic;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_SoftClass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public class PBnet_SoftClass : IComparer<Pbzx.Model.PBnet_SoftClass>
	{
		public PBnet_SoftClass()
		{
            _intclassid = 0;
            _nvarclassname = "";
            _intparentid = 0;
            _var_parentpath = "";
            _intdepth = 0;
            _nvarreadme = "";
            _nvarlinkurl = "";
            _nvarclasspicurl = "";
        }
		#region Model
		private int _intclassid;
		private string _nvarclassname;
		private int _intparentid;
		private string _var_parentpath;
		private int _intdepth;
		private int _introotid;
		private int _intchild;
		private int _intprevid;
		private int _int_nextid;
		private int _intorderid;
		private string _nvarreadme;
		private int _intsetting;
		private string _nvarlinkurl;
		private string _nvarclasspicurl;
		private int _intskinid;
		private int _intlayoutid;
		private int _intbrowsepurview;
		private int _intaddpurview;
		private bool _bitiselite;
		private bool _pb_showontop;
		/// <summary>
		/// 软件类别编号（主键自动增长）
		/// </summary>
		public int IntClassID
		{
			set{ _intclassid=value;}
			get{return _intclassid;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string NvarClassName
		{
			set{ _nvarclassname=value;}
			get{return _nvarclassname;}
		}
		/// <summary>
		/// 父类别编号
		/// </summary>
		public int IntParentID
		{
			set{ _intparentid=value;}
			get{return _intparentid;}
		}
		/// <summary>
		/// 类别路径
		/// </summary>
		public string Var_ParentPath
		{
			set{ _var_parentpath=value;}
			get{return _var_parentpath;}
		}
		/// <summary>
		/// 类别深度
		/// </summary>
		public int IntDepth
		{
			set{ _intdepth=value;}
			get{return _intdepth;}
		}
		/// <summary>
		/// 根类别编号
		/// </summary>
		public int IntRootID
		{
			set{ _introotid=value;}
			get{return _introotid;}
		}
		/// <summary>
		/// 子类别数量
		/// </summary>
		public int IntChild
		{
			set{ _intchild=value;}
			get{return _intchild;}
		}
		/// <summary>
		/// 上一个编号
		/// </summary>
		public int IntPrevID
		{
			set{ _intprevid=value;}
			get{return _intprevid;}
		}
		/// <summary>
		/// 下一个编号
		/// </summary>
		public int Int_NextID
		{
			set{ _int_nextid=value;}
			get{return _int_nextid;}
		}
		/// <summary>
		/// 排序编号
		/// </summary>
		public int IntOrderID
		{
			set{ _intorderid=value;}
			get{return _intorderid;}
		}
		/// <summary>
		/// 类别说明
		/// </summary>
		public string NvarReadme
		{
			set{ _nvarreadme=value;}
			get{return _nvarreadme;}
		}
		/// <summary>
		/// 类别设置
		/// </summary>
		public int IntSetting
		{
			set{ _intsetting=value;}
			get{return _intsetting;}
		}
		/// <summary>
		/// 类别链接地址
		/// </summary>
		public string NvarLinkUrl
		{
			set{ _nvarlinkurl=value;}
			get{return _nvarlinkurl;}
		}
		/// <summary>
		/// 类别图片地址
		/// </summary>
		public string NvarClassPicUrl
		{
			set{ _nvarclasspicurl=value;}
			get{return _nvarclasspicurl;}
		}
		/// <summary>
		/// 类别皮肤编号
		/// </summary>
		public int IntSkinID
		{
			set{ _intskinid=value;}
			get{return _intskinid;}
		}
		/// <summary>
		/// 类别显示位置编号
		/// </summary>
		public int IntLayoutID
		{
			set{ _intlayoutid=value;}
			get{return _intlayoutid;}
		}
		/// <summary>
		/// 类别浏览可见权限
		/// </summary>
		public int IntBrowsePurview
		{
			set{ _intbrowsepurview=value;}
			get{return _intbrowsepurview;}
		}
		/// <summary>
		/// 类别添加权限
		/// </summary>
		public int IntAddPurview
		{
			set{ _intaddpurview=value;}
			get{return _intaddpurview;}
		}
		/// <summary>
		/// 是否是精华（1:是，0：不是）
		/// </summary>
		public bool BitIsElite
		{
			set{ _bitiselite=value;}
			get{return _bitiselite;}
		}
		/// <summary>
		/// 是否在顶部导航栏显示（1：是，0：不是）
		/// </summary>
		public bool pb_ShowOnTop
		{
			set{ _pb_showontop=value;}
			get{return _pb_showontop;}
		}
		#endregion Model

        #region IComparer<PBnet_Product> 成员
        private bool _isDesc = true;
        public bool IsDesc
        {
            get { return _isDesc; }
            set { _isDesc = value; }
        }

        public int Compare(PBnet_SoftClass x, PBnet_SoftClass y)
        {
            if (IsDesc)
            {
                return x.IntOrderID - y.IntOrderID;
            }
            else
            {
                return y.IntOrderID - x.IntOrderID;
            }
        }

        #endregion

	}
}

