using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cVale
    {
        public void Registrar(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha, Double Importe, string Nombre, string Apellido,string Descripcion)
        {
            string sql = "Insert into Vale(Fecha,Importe,Nombre,Apellido,Saldo,Descripcion)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetValesxFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select v.CodVale, v.Nombre,v.Apellido,v.Importe,v.Fecha,v.Saldo,v.FechaDevolucion,v.Descripcion";
            sql = sql + " from Vale v";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString () + "'";
            sql = sql + " and v.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by v.CodVale Desc";
            return cDb.ExecuteDataTable(sql);
        }

        public void GrabarDevolucion(SqlConnection con, SqlTransaction Transaccion,Int32 CodVale, DateTime Fecha)
        {
            string sql = "update vale set Saldo= 0";
            sql = sql + ",FechaDevolucion =" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " where CodVale =" + CodVale.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void AnularDevolucion(SqlConnection con, SqlTransaction Transaccion, Int32 CodVale)
        {
            string sql = "update vale set Saldo= Importe";
            sql = sql + ",FechaDevolucion = null ";
            sql = sql + " where CodVale =" + CodVale.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalVales()
        {
            double Importe = 0;
            string sql = "select sum(isnull(Saldo,0)) as Importe";
            sql = sql + " from Vale";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }

        public DataTable GetValexCodigo(Int32 CodVale)
        {
            string sql = "select * from Vale ";
            sql = sql + " where CodVale=" + CodVale.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
