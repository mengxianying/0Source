using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Collections;
using System.Text;
using System.IO;

namespace Pbzx.Web
{
    public class Refurbish_Soft : System.Web.UI.Page
    {   

        private int _count = 6;

        /// <summary>
        /// 显示多少条
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private int _tileLength = 12;
        /// <summary>
        /// 标题长度
        /// </summary>

        public int TileLength
        {
            get { return _tileLength; }
            set { _tileLength = value; }
        }

    }
}
