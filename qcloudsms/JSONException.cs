using System;


namespace qcloudsms
{
    public class JSONException : Exception
    {
        public JSONException()
        { }

        public JSONException(string message) : base(message)
        { }
    }
}