using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cMovimiento
    {
        public void GrabarMovimientoTransaccion(SqlConnection con, SqlTransaction Transaccion,double Importe,string Descripcion,DateTime Fecha, Int32 CodUsuario,Int32? CodOrden)
        {
            string sql = "Insert into Movimientos(Importe,Descripcion,Fecha,CodUsuario,CodOrden)";
            sql = sql + "Values(" + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion +"'";
            sql = sql + "," + "'" + Fecha.ToShortDateString () +"'";
            sql = sql + "," + CodUsuario.ToString();
            if (CodOrden == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodOrden.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);

        }

        public double GetTotalEfectivo()
        {
            double Importe = 0;
            string sql = "select sum(isnull(Importe,0)) as Importe";
            sql = sql + " from Movimientos";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString ()!="") 
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString()); 
            }
            return Importe;
        }

        public void GrabarMovimiento(double Importe, string Descripcion, DateTime Fecha, Int32 CodUsuario, Int32? CodOrden)
        {
            string sql = "Insert into Movimientos(Importe,Descripcion,Fecha,CodUsuario,CodOrden)";
            sql = sql + "Values(" + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodUsuario.ToString();
            if (CodOrden == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodOrden.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);

        }

        public DataTable GetMovimientoxFecha(DateTime FechaDesde, DateTime FechaHasta, string Concepto)
        {
            string sql = "select *";
            sql = sql + " from Movimientos m";
            sql = sql + " where m.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and m.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Concepto != "")
                sql = sql + " and Descripcion like " + "'" + "%" + Concepto + "%" + "'";
            sql = sql + " order by m.CodMovimiento desc";
            return cDb.ExecuteDataTable(sql);
        }
    
        public double   GetTotalxicCodOrden(Int32 CodOrden)
        {
            double Importe =0;
            string sql = "select isnull(sum(Importe),0) as Importe from Movimientos ";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                
            }
            return Importe;
        }

        public void BorrarMovimiento(Int32 CodOrden)
        {
            string sql = "delete from Movimientos ";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public double GetTotalEfectivoxFecha(DateTime FechaDesde,DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(isnull(Importe,0)) as Importe";
            sql = sql + " from Movimientos ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <="+"'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }
    }
}
