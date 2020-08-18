using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cMensajeOrden
    {
        public void InsertarMensajeTran(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden, string Mensaje, DateTime Fecha )
        {
            string sql = "insert into Mensaje(CodOrden,Descripcion,Fecha)";
            sql = sql + "values(" + CodOrden.ToString();
            sql = sql + "," + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetMensajesxCodOrden(Int32 CodOrden)
        {
            string sql = "select CodMensaje, Fecha,Descripcion from Mensaje m";
            sql = sql + " where CodOrden =" + CodOrden.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public void InsertarMensaje( Int32 CodOrden, string Mensaje, DateTime Fecha)
        {
            string sql = "insert into Mensaje(CodOrden,Descripcion,Fecha)";
            sql = sql + "values(" + CodOrden.ToString();
            sql = sql + "," + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }
    }
}
