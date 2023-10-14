using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cReparacion
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden,Int32  CodReparacion,string Nombre,String FormaPago, string ManoObra)
        {
            string sql = "Insert into Reparacion(CodOrden,CodReparacion,Nombre,FormaPago,ManoObra)";
            sql = sql + " values(" + CodOrden;
            sql = sql + "," + CodReparacion.ToString();
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + FormaPago + "'";
            sql = sql + "," + "'" + ManoObra + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void BorrarReparacion(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "delete from Reparacion";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetReparacion(Int32 CodOrden)
        {
            string sql = "select CodReparacion,Nombre";
            sql = sql + " from Reparacion ";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            sql = sql + " and CodReparacion <>0";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
