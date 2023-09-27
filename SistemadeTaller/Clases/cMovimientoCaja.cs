using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cMovimientoCaja
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,string Descripcion, Double Debe, Double Haber,DateTime Fecha,int CodTipo,string Tipo, Int32? CodOrden)
        {
            string sql = "insert into MovimientoCaja(";
            sql = sql + " Descripcion,Debe,Haber,Fecha,CodTipo,Tipo,CodOrden";
            sql = sql + ")";
            sql = sql + " values(" + "'" + Descripcion + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodTipo.ToString();
            sql = sql + "," + "'" + Tipo + "'";
            if (CodOrden != null)
                sql = sql + "," + CodOrden.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable Buscar(DateTime FechaDesde, DateTime FechaHasta, int CodTipo)
        {   
            string sql = "";
            sql = " select CodMovimiento,Descripcion, Fecha, Debe, Haber ";
            sql = sql + " from MovimientoCaja ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and CodTipo=" + CodTipo.ToString();
            return cDb.ExecuteDataTable(sql);
        } 
    }
}
