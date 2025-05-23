using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    [Serializable]
    public class Note_WriteBack
    {
        public int ID { get; set; }

        public string Phone { get; set; }

        public string Content { get; set; }

        public DateTime BeginTime { get; set; }

        public string Sp_PID { get; set; }
    }
}

