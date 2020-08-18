using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SistemadeTaller.Clases
{
    public class cTarjeta
    {
        public DataTable GetTarjetas()
        {
            string sql = "select * from Tarjeta";
            sql = sql + " order by Nombre";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
