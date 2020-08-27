using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public  class cTransferencia
    {
        public void Grabar(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden, Double Importe)
        {
            string sql = "insert into Transferencia(CodOrden,Importe)";
            sql = sql + " Values(" + CodOrden.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Double GetTotal()
        {
            Double Total = 0;
            string sql = "select isnull(sum(Importe),0) as Total ";
            sql = sql + " from Transferencia ";
            sql = sql + " where FechaCobro is null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Total"].ToString() != "")
                    Total = Convert.ToDouble(trdo.Rows[0]["Total"].ToString());
            return Total;
        }

        public DataTable GetTransferencia(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = " select t.Codigo, a.Patente,a.Descripcion,t.FechaCobro, t.Importe";
            sql = sql + " from Orden o,Auto a, Transferencia t";
            sql = sql + " where o.CodAuto = a.CodAuto ";
            sql = sql + " and o.CodOrden = t.CodOrden ";
            sql = sql + " and o.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
