using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cDetalleCompra
    {
        public void InsertarDetalle(SqlConnection con, SqlTransaction Transaccion,Int32 CodCompra,Int32 CodInsumo,Int32 Cantidad,double Precio)
        {
            string sql = "insert into DetalleCompra(CodCompra,CodInsumo,Cantidad,Precio)";
            sql = sql + "values (" + CodCompra.ToString();
            sql = sql + "," + CodInsumo.ToString();
            sql = sql + "," + Cantidad.ToString();
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
