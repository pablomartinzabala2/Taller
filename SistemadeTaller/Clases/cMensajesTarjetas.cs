using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SistemadeTaller.Clases
{
    public class cMensajesTarjetas
    {
        public void InsertarMensaje(string Mensaje, DateTime Fecha, Int32 CodCobro)
        {
            string sql = "Insert into MensajesTarjetas";
            sql = sql + "(Mensaje,Fecha,CodCobro)";
            sql = sql + "values(" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodCobro.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensajesxCodCobro(Int32 CodCobro)
        {
            string sql = "select Fecha,Mensaje from MensajesTarjetas";
            sql = sql + " where CodCobro =" + CodCobro.ToString();
            sql = sql + " order by Fecha Desc";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
