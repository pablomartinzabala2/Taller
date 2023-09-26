using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public  class cPagoEfectivo
    {
        public void Insertar(Int32 CodOrden,Double Importe,DateTime Fecha)
        {
            string sql = "insert into PagoEfectivo (";
            sql = sql + "CodOrden,Importe,Fecha";
            sql = sql + ")";
            sql = sql + " values(";
            sql = sql + CodOrden.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void InsertarTran(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden, Double Importe, DateTime Fecha)
        {
            string sql = "insert into PagoEfectivo (";
            sql = sql + "CodOrden,Importe,Fecha";
            sql = sql + ")";
            sql = sql + " values(";
            sql = sql + CodOrden.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetPagosxCodOrden(Int32 CodOrden)
        {
            string sql = "select * ";
            sql = sql + " from PagoEfectivo ";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarPago(Int32 CodPago)
        {
            string sql = "delete from PagoEfectivo ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
