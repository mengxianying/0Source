using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JMailText
{
    public class SmtpServer
    {
        private string _ServerAddress;
        public string ServerAddress
        {
            get { return _ServerAddress; }
            set { _ServerAddress = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _UserPwd;
        public string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }

        private string _FromEmail;
        public string FromEmail
        {
            get { return _FromEmail; }
            set { _FromEmail = value; }
        }

        private string _FromName;
        public string FromName
        {
            get { return _FromName; }
            set { _FromName = value; }
        }

        private int _Port;

        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private bool _EnableSsl;

        public bool EnableSsl
        {
            get { return _EnableSsl; }
            set { _EnableSsl = value; }
        }
    }
}