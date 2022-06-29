using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SistemadeTaller.Clases
{
    public class cHerramienta
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,string Nombre, DateTime Fecha, Double Importe)
        {
            string sql = "Insert into Herramienta(";
            sql = sql + "Nombre,Fecha,Importe)";
            sql = sql + " Values(";
            sql = sql + "" + "'" + Nombre + "'";
            sql = sql + "," +"'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetHerramientas (DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select * from Herramienta ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }

    }
}
