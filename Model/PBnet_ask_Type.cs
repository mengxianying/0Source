using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_ask_Type 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_ask_Type
    {
        public PBnet_ask_Type()
        { }
        #region Model
        private int _id;
        private string _typename;
        private int? _typeid;
        private int _ftypeid;
        private int? _orderid;
        private int _depth;
        private int? _rootid;
        private string _modulefids;
        private bool _bitisauditing;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FTypeID
        {
            set { _ftypeid = value; }
            get { return _ftypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleFIDS
        {
            set { _modulefids = value; }
            get { return _modulefids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BitIsAuditing
        {
            set { _bitisauditing = value; }
            get { return _bitisauditing; }
        }
        #endregion Model

    }
}

