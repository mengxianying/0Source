using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pbzx.Web.Contorls
{
    public partial class UcShuang : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (MyDataSource != null)
                {
                    ///期号
                    this.TempletShuangHaoIssue1.MyDataSource = MyDataSource;
                    if (!AddXuHao)
                    {
                        TempletShuangHaoIssue1.AddXuHao = false;
                    }
                    else
                    {
                        TempletShuangHaoIssue1.AddXuHao = true;
                    }
                    if (!AddCode)
                    {
                        TempletShuangHaoIssue1.AddCode = false;
                    }
                    else
                    {
                        TempletShuangHaoIssue1.AddCode = true;
                    }
                    this.TempletShuangHaoIssue1.CzName = CzName;

                    ///号码
                    if (!AddYiLou)
                    {
                        this.TempletShuangHaoCode1.DisplayYiLou = false;
                        this.TempletShuangHaoTCode1.DisplayYiLou = false;
                    }
                    else
                    {
                        this.TempletShuangHaoCode1.DisplayYiLou = true;
                        this.TempletShuangHaoTCode1.DisplayYiLou = true;
                    }

                    this.TempletShuangHaoCode1.MinCode = MinCode;
                    this.TempletShuangHaoCode1.MaxCode = MaxCode;

                    if (MaxTcode > 1)
                    {
                        this.tdIssue.Style.Add("width", "10%");
                        this.tdCode.Style.Add("width", "55%");
                        this.Hua.Style.Add("width", "35%");

                        this.TempletShuangHaoTCode1.Visible = true;
                        this.TempletShuangHaoTCode1.MinCode = MinTcode;
                        this.TempletShuangHaoTCode1.MaxCode = MaxTcode;
                        this.TempletShuangHaoTCode1.MyDataSource = MyDataSource;
                    }
                    else
                    {
                        this.tdIssue.Style.Add("width", "30%");
                        this.tdCode.Style.Add("width", "70%");
                        this.Hua.Visible = false;
                        this.TempletShuangHaoTCode1.Visible = false;
                    }

                    this.TempletShuangHaoCode1.MyDataSource = MyDataSource;

                }


            }
        }

        private bool _addXuHao = true;

        /// <summary>
        /// 是否添加序号列
        /// </summary>
        public bool AddXuHao
        {
            get { return _addXuHao; }
            set { _addXuHao = value; }
        }


        private bool _addCode = true;

        /// <summary>
        /// 是否添加号码列
        /// </summary>
        public bool AddCode
        {
            get { return _addCode; }
            set { _addCode = value; }
        }

        private DataTable _myDataSource;

        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable MyDataSource
        {
            get { return _myDataSource; }
            set { _myDataSource = value; }
        }


        private string _czName;
        /// <summary>
        /// 彩种名称
        /// </summary>
        public string CzName
        {
            get { return _czName; }
            set { _czName = value; }
        }


        private bool _addYiLou = true;

        /// <summary>
        /// 是否显示遗漏
        /// </summary>
        public bool AddYiLou
        {
            get { return _addYiLou; }
            set { _addYiLou = value; }
        }

        private int _maxCode;
        /// <summary>
        ///开奖号码大号
        /// </summary>
        public int MaxCode
        {
            get { return _maxCode; }
            set { _maxCode = value; }
        }

        private int _minCode;
        /// <summary>
        /// 开奖号码小号
        /// </summary>
        public int MinCode
        {
            get { return _minCode; }
            set { _minCode = value; }
        }

        private int _maxTcode = 0;
        /// <summary>
        /// 特别号码大号
        /// </summary>
        public int MaxTcode
        {
            get { return _maxTcode; }
            set { _maxTcode = value; }
        }
        private int _minTcode = 0;

        /// <summary>
        /// 特别号码小号
        /// </summary>
        public int MinTcode
        {
            get { return _minTcode; }
            set { _minTcode = value; }
        }

    }
}