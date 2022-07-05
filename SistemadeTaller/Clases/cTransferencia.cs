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
        public void Grabar(SqlConnection con, SqlTransaction Transaccion,Int32? CodOrden, Double Importe,DateTime Fecha)
        {
            string sql = "insert into Transferencia(CodOrden,Importe,Fecha)";
            if (CodOrden != null)
                sql = sql + " Values(" + CodOrden.ToString();
            else
                sql = sql + " Values(null";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
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

        public Double  GetImporteTransferenciaxCodigo(Int32 Codigo)
        {
            Double Importe = 0;
            string sql = "select * from Transferencia where CodOrden=" + Codigo.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }

        public DataTable GetTransferencia(DateTime FechaDesde,DateTime FechaHasta)
        {
            // string sql = " select t.Codigo, a.Patente,a.Descripcion";
            string sql = " select t.Codigo";
            sql = sql + ",(select a.Patente from auto a, Orden o where o.CodAuto = a.CodAuto and o.CodOrden = t.CodOrden) as Patente ";
            sql = sql + ",(select a.Descripcion from auto a, Orden o where o.CodAuto = a.CodAuto and o.CodOrden = t.CodOrden) as Descripcion ";
            sql = sql + ",t.FechaCobro, t.Importe,t.CodOrden";
            sql = sql + " from Transferencia t";
            sql = sql + " where t.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and t.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarFechaCobro(SqlConnection con, SqlTransaction Transaccion,Int32 Codigo, DateTime Fecha)
        {
            string sql = "Update Transferencia set FechaCobro=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " where Codigo=" + Codigo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void AnularTransferencia(SqlConnection con, SqlTransaction Transaccion, Int32 Codigo)
        {
            string sql = "Update Transferencia set FechaCobro=null";
            sql = sql + " where Codigo=" + Codigo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void BorrarTransferencia(SqlConnection con, SqlTransaction Transaccion, Int32 Codorden)
        {
            string sql = "delete from Transferencia ";
            sql = sql + " where CodOrden =" + Codorden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalTransferencia(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Importe = 0;
            string sql = "select sum(t.Importe) as ImporteTransferencia from transferencia t, Orden o, Auto a ";
            sql = sql + " where t.CodOrden = o.CodOrden ";
            sql = sql + " and o.CodAuto = a.CodAuto";
            sql = sql + " and o.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente != null)
                sql = sql + " and a.Patente =" + "'" + Patente + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTransferencia"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteTransferencia"].ToString());
            
            return Importe;
        }

        public double GetTotal(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Importe) as ImporteTransferencia from transferencia t ";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and FechaCobro is null ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTransferencia"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteTransferencia"].ToString());

            return Importe;
        }
    }
}
