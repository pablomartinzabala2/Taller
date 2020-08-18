using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public  class cMecanico
    {
        public DataTable GetMecanicos()
        {
            string sql = "Select CodMecanico, (Apellido + ' ' + Nombre) as Apellido";
            sql = sql + " from Mecanico ";
            sql = sql + " order by Apellido ";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
