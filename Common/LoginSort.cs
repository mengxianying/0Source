using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Pbzx.Common
{
    public class LoginSort
    {
       // private bool _isHas;
        /// <summary>
        /// �ж��Ƿ��д������Ϣ
        /// </summary>
        /// <param name="_myIndex">��Ϣ����</param>
        /// <returns>�Ƿ���</returns>
        /// author:meng
        public  bool this[string _myIndex]
        {
            get
            {
                //PinbleLogin pb = new PinbleLogin();
                //pb.ReLogin();
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return false;
                }
                bool isfound = false;
                string[] logins =   ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData.Split(new char[] { '|' });
                foreach(string str in logins)
                {
                    if(str == _myIndex)
                    {
                        isfound = true;
                        break;
                    }
                }
                return isfound;
            }
        }

    }
}
