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

        public DataTable GetHerramientas (DateTime FechaDesde,DateTime FechaHasta, string Nombre)
        {
            string sql = "select CodHerramienta,Fecha,Nombre,Importe from Herramienta ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Nombre != "")
                sql = sql + " and Nombre like " + "'%" + Nombre + "%'";
            sql = sql + " order by CodHerramienta Desc";
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetTotalxCodHerramienta(Int32 CodHerramienta)
        {
            Double Total = 0;
            string sql = "select Importe from Herramienta ";
            sql = sql + " where CodHerramienta =" + CodHerramienta.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Importe"].ToString ()!="")
                {
                    Total = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }
            return Total;
        }

        public string  GetNombre(Int32 CodHerramienta)
        {
            string Nombre = "";
            string sql = "select Nombre from Herramienta ";
            sql = sql + " where CodHerramienta =" + CodHerramienta.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Nombre"].ToString() != "")
                {
                    Nombre = (trdo.Rows[0]["Nombre"].ToString());
                }
            }
            return Nombre;
        }

        public void Eliminar(SqlConnection con, SqlTransaction Transaccion, Int32 CodHerramienta)
        {
            string sql = "delete from Herramienta ";
            sql = sql + " where CodHerramienta=" + CodHerramienta.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Double GetTotalxFecha(DateTime FechaDesde,DateTime FechaHasta)
        {
            Double Total = 0; 
            string sql = "select Importe from Herramienta ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                {
                    Total = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }
            return Total;
        }


    }
}
