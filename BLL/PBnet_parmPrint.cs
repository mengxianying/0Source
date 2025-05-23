using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.BLL
{
    public class PBnet_parmPrint
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_parmPrint", "id");
        public DataTable GetData()
        {
            return basicDAL.GetLisBySql("select * from PBnet_parmPrint ");
        }
    }
}
