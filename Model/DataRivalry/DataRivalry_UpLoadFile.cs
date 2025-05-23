using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类DataRivalry_UpLoadFile 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class DataRivalry_UpLoadFile
    {
        public DataRivalry_UpLoadFile()
        { }
        #region Model
        private int _f_drid;
        private int? _f_period;
        private string _f_username;
        private string _f_filename;
        private string _f_filetype;
        private int? _f_filesize;
        private int? _f_filenum;
        private string _f_createname;
        private int? _f_singlegroup;
        private DateTime? _f_addtime;
        private int? _f_lottery;
        private int? _f_state;
        /// <summary>
        /// 
        /// </summary>
        public int F_drID
        {
            set { _f_drid = value; }
            get { return _f_drid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_Period
        {
            set { _f_period = value; }
            get { return _f_period; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_UserName
        {
            set { _f_username = value; }
            get { return _f_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_FileName
        {
            set { _f_filename = value; }
            get { return _f_filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_FileType
        {
            set { _f_filetype = value; }
            get { return _f_filetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_FileSize
        {
            set { _f_filesize = value; }
            get { return _f_filesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_FileNum
        {
            set { _f_filenum = value; }
            get { return _f_filenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_CreateName
        {
            set { _f_createname = value; }
            get { return _f_createname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_SingleGroup
        {
            set { _f_singlegroup = value; }
            get { return _f_singlegroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? F_addTime
        {
            set { _f_addtime = value; }
            get { return _f_addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_lottery
        {
            set { _f_lottery = value; }
            get { return _f_lottery; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_state
        {
            set { _f_state = value; }
            get { return _f_state; }
        }
        #endregion Model
    }
}
