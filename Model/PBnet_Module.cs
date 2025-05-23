using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PBnet_Module
    {

		#region 构造函数
        public PBnet_Module()
		{
		 _id = 0;
		 _name = "";
		 _url = ""; 
         _linkurl = "";
		 _depth = 0;
         _rootid = 0;
         _flagmenu = 0;
         _sort = 0;
         _format = 0;
         _ishome = false;
         _createtime = DateTime.Now;
		}
		#endregion

        #region Model
        private int _id;
        private string _name;
        private string _url;
        private string _linkurl;
        private int _depth;
        private int _rootid;
        private int _flagmenu;
        private int _sort;
        private int _format;
        private bool _ishome;
        private DateTime _createtime;
        private string _tempid;
        private int _allsort;

        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 模块对应的后台地址
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 根ID默然是0，为模块大类
        /// </summary>
        public int RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        /// <summary>
        /// 可视菜单：0否；1是
        /// </summary>
        public int FlagMenu
        {
            set { _flagmenu = value; }
            get { return _flagmenu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Format
        {
            set { _format = value; }
            get { return _format; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsHome
        {
            set { _ishome = value; }
            get { return _ishome; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 临时ID，权限判断用
        /// </summary>
        public string TempID
        {
            set { _tempid = value; }
            get { return _tempid; }
        }

        /// <summary>
        /// 总排序编号
        /// </summary>
        public int AllSort
        {
            set { _allsort = value; }
            get { return _allsort; }
        }

        #endregion Model

    }
}
