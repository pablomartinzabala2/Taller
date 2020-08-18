using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SistemadeTaller.Clases
{
    public  class cMensajesDocumento
    {
        public void InsertarMensaje(string Mensaje, DateTime Fecha, Int32 CodDocumento)
        {
            string sql = "Insert into mensajesDocumentos";
            sql = sql + "(Mensaje,Fecha,CodDocumento)";
            sql = sql + "values(" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodDocumento.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensajesxCodDocumento(Int32 CodDocumento)
        {
            string sql = "select Fecha,Mensaje from mensajesDocumentos";
            sql = sql + " where CodDocumento =" + CodDocumento.ToString();
            sql = sql + " order by Fecha Desc";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
