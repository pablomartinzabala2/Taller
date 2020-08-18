using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public  class cMensajesGarantia
    {
        public void InsertarMensaje(string Mensaje, DateTime Fecha, Int32 CodGarantia)
        {
            string sql = "Insert into MensajesGarantia";
            sql = sql + "(Mensaje,Fecha,CodGarantia)";
            sql = sql + "values(" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodGarantia.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensajesxCodGarantia(Int32 CodGarantia)
        {
            string sql = "select Fecha,Mensaje from MensajesGarantia";
            sql = sql + " where CodGarantia =" + CodGarantia.ToString();
            sql = sql + " order by Fecha Desc";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
