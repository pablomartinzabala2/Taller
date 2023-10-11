using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cPagoTransferencia
    {
        public void Insertar(Int32 CodOrden, Double Importe, DateTime Fecha)
        {
            string sql = "insert into PagoTransferencia (";
            sql = sql + "CodOrden,Importe,Fecha";
            sql = sql + ")";
            sql = sql + " values(";
            sql = sql + CodOrden.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void InsertarTran(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden, Double Importe, DateTime Fecha, string Descripcion)
        {
            string sql = "insert into PagoTransferencia (";
            sql = sql + "CodOrden,Importe,Fecha,Descripcion";
            sql = sql + ")";
            sql = sql + " values(";
            sql = sql + CodOrden.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetPagosxCodOrden(Int32 CodOrden)
        {
            string sql = "select * ";
            sql = sql + " from PagoTransferencia ";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarPago(Int32 CodPago)
        {
            string sql = "delete from PagoTransferencia ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.ExecutarNonQuery(sql);
        }

    }
}
