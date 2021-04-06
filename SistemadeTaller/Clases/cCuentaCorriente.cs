using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemadeTaller.Clases
{
    public class cCuentaCorriente
    {
        public void Insertar (SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden,DateTime Fecha, Double Importe)
        {
            string sql = "Insert into CuentaCorriente(CodOrden,Fecha,Importe)";
            sql = sql + " values(" + CodOrden.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetCuentaCorriente(Int32 CodOrden)
        {
            string sql = "select * from CuentaCorriente ";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetTotal()
        {
            Double Importe = 0;
            string sql = "select isnull(sum(Importe),0) as Total from CuentaCorriente ";
            sql = sql + " where FechaCobro is null ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Total"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Total"].ToString());
            }
            return Importe;
        }

        public DataTable GetCuentasxFecha(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = " select c.Codigo,a.Patente,a.Descripcion,c.Importe,c.Fecha,c.FechaCobro,c.CodOrden";
            sql = sql + " from CuentaCorriente c, Orden o, Auto a";
            sql = sql + " where c.CodOrden= o.CodOrden";
            sql = sql + " and o.CodAuto=a.CodAuto";  
            sql = sql + " and c.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and c.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }
        
        public void ActualizarFechacobro(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden,DateTime FechaCobro)
        {
            string sql = "update CuentaCorriente ";
            sql = sql + " set FechaCobro=" + "'" + FechaCobro.ToShortDateString() + "'";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void AnularCobro(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "update CuentaCorriente ";
            sql = sql + " set FechaCobro=null";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetSaldoCuentaCorriente(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = "select sum(Importe) as Importe from CuentaCorriente ";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            string sql2 = "select * from CuentaCorriente ";
            sql2 = sql2 + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo2 = cDb.ExecuteDataTable(sql2);
            if (trdo2.Rows.Count >0)
            {
                if (trdo2.Rows[0]["FechaCobro"].ToString ()!="")
                {
                    Importe = 0;
                }
                    
            }
            return Importe;
        }

        public double GetTotalCuentaxFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Importe) as Importe from CuentaCorriente";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }
    }
}
