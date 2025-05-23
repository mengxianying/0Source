using System;
using System.Collections.Generic;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_SoftClass ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �������ţ������Զ�������
		/// </summary>
		public int IntClassID
		{
			set{ _intclassid=value;}
			get{return _intclassid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public string NvarClassName
		{
			set{ _nvarclassname=value;}
			get{return _nvarclassname;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int IntParentID
		{
			set{ _intparentid=value;}
			get{return _intparentid;}
		}
		/// <summary>
		/// ���·��
		/// </summary>
		public string Var_ParentPath
		{
			set{ _var_parentpath=value;}
			get{return _var_parentpath;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int IntDepth
		{
			set{ _intdepth=value;}
			get{return _intdepth;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int IntRootID
		{
			set{ _introotid=value;}
			get{return _introotid;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public int IntChild
		{
			set{ _intchild=value;}
			get{return _intchild;}
		}
		/// <summary>
		/// ��һ�����
		/// </summary>
		public int IntPrevID
		{
			set{ _intprevid=value;}
			get{return _intprevid;}
		}
		/// <summary>
		/// ��һ�����
		/// </summary>
		public int Int_NextID
		{
			set{ _int_nextid=value;}
			get{return _int_nextid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int IntOrderID
		{
			set{ _intorderid=value;}
			get{return _intorderid;}
		}
		/// <summary>
		/// ���˵��
		/// </summary>
		public string NvarReadme
		{
			set{ _nvarreadme=value;}
			get{return _nvarreadme;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int IntSetting
		{
			set{ _intsetting=value;}
			get{return _intsetting;}
		}
		/// <summary>
		/// ������ӵ�ַ
		/// </summary>
		public string NvarLinkUrl
		{
			set{ _nvarlinkurl=value;}
			get{return _nvarlinkurl;}
		}
		/// <summary>
		/// ���ͼƬ��ַ
		/// </summary>
		public string NvarClassPicUrl
		{
			set{ _nvarclasspicurl=value;}
			get{return _nvarclasspicurl;}
		}
		/// <summary>
		/// ���Ƥ�����
		/// </summary>
		public int IntSkinID
		{
			set{ _intskinid=value;}
			get{return _intskinid;}
		}
		/// <summary>
		/// �����ʾλ�ñ��
		/// </summary>
		public int IntLayoutID
		{
			set{ _intlayoutid=value;}
			get{return _intlayoutid;}
		}
		/// <summary>
		/// �������ɼ�Ȩ��
		/// </summary>
		public int IntBrowsePurview
		{
			set{ _intbrowsepurview=value;}
			get{return _intbrowsepurview;}
		}
		/// <summary>
		/// ������Ȩ��
		/// </summary>
		public int IntAddPurview
		{
			set{ _intaddpurview=value;}
			get{return _intaddpurview;}
		}
		/// <summary>
		/// �Ƿ��Ǿ�����1:�ǣ�0�����ǣ�
		/// </summary>
		public bool BitIsElite
		{
			set{ _bitiselite=value;}
			get{return _bitiselite;}
		}
		/// <summary>
		/// �Ƿ��ڶ�����������ʾ��1���ǣ�0�����ǣ�
		/// </summary>
		public bool pb_ShowOnTop
		{
			set{ _pb_showontop=value;}
			get{return _pb_showontop;}
		}
		#endregion Model

        #region IComparer<PBnet_Product> ��Ա
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

