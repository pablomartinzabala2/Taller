using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SistemadeTaller.Clases
{
    public  class cPresupuesto
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccio,Int32? CodCliente,Int32? CodAuto,DateTime Fecha,Double Total)
        {
            string sql = "Insert into Presupuesto(CodCliente,CodAuto,Fecha,Total)";
            sql = sql + " values(" + CodCliente.ToString();
            sql = sql + "," + CodAuto.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccio, sql);
        }

        public void InsertarDetalle(SqlConnection con, SqlTransaction Transaccio,Int32 CodPresupuesto,Int32 CodArreglo,string Nombre,Double Precio)
        {
            string sql = "insert into DetallePresupuesto(CodPresupuesto,CodArreglo,Nombre,Precio)";
            sql = sql + " values(" + CodPresupuesto.ToString();
            sql = sql + "," + CodArreglo.ToString();
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccio, sql);
        }

        public DataTable GetPresupuestoxFecha(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select p.CodPresupuesto,a.Patente,a.Descripcion,c.Apellido,c.Nombre,p.Fecha";
            sql = sql + " from Presupuesto p, Cliente c, auto a, DetallePresupuesto dp";
            sql = sql + " where p.CodCliente = c.CodCliente ";
            sql = sql + " and p.CodAuto = a.CodAuto ";
            sql = sql + " and p.CodPresupuesto = dp.CodPresupuesto ";
            sql = sql + " and p.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and p.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by p.CodPresupuesto desc";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
