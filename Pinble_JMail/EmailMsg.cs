using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace JMailText
{
    public class EmailMsg
    {

        private string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        private string _Body;
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }

        private string _FromEmail;
        public string FromEmail
        {
            get { return _FromEmail; }
            set { _FromEmail = value; }
        }

        private string _FromName = string.Empty;
        public string FromName
        {
            get { return _FromName; }
            set { _FromName = value; }
        }

        private string _ToEmail;
        public string ToEmail
        {
            get { return _ToEmail; }
            set { _ToEmail = value; }
        }

        private string _ToName = string.Empty;
        public string ToName
        {
            get { return _ToName; }
            set { _ToName = value; }
        }

        private Encoding _BodyEncoding;
        public Encoding BodyEncoding
        {
            get { return _BodyEncoding; }
            set { _BodyEncoding = value; }
        }

        private bool _IsBodyHtml;
        public bool IsBodyHtml
        {
            get { return _IsBodyHtml; }
            set { _IsBodyHtml = value; }
        }
    }
}