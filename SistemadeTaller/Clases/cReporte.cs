using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemadeTaller.Clases
{
    public  class cReporte
    {
        public void Borrar()
        {
            string sql = "delete from Reporte";
            cDb.ExecutarNonQuery(sql);
        }

        public void Insertar(string Campo1,string Campo2,string Campo3,
            string Campo4,string Campo5)
        {
            string sql = "Insert into Reporte(Campo1";
            sql = sql + ",Campo2,Campo3,Campo4,Campo5)";
            sql = sql + " values(";
            sql = sql+ "'" + Campo1 + "'";
            sql = sql + "," + "'" + Campo2 + "'";
            sql = sql + ","  + "'" + Campo3 + "'";
            sql = sql  +"," + "'" + Campo4 + "'";
            sql = sql + "," +"'" + Campo5 + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }
    }
}
