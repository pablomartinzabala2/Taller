using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cGastosNegocio
    {
        public void GrabarGastos(DateTime Fecha, Int32? CodEntidad, string Descripcion, double Importe)
        {
            string sql = "Insert into GastosNegocio(Fecha,CodEntidad,Descripcion,Importe)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString() + "'";
            if (CodEntidad == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodEntidad.ToString();
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void BorrarGasto(Int32 CodGasto)
        {
            string sql = "delete from GastosNegocio where CodGasto=" + CodGasto.ToString ();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetGastosNegocioxFecha(DateTime FechaDesde, DateTime FechaHasta, string Descripcion)
        {
            string sql = "select g.CodGasto,";
            sql = sql + "(select e.Nombre from Entidad e where e.CodEntidad = g.CodEntidad) as Concepto";
            sql = sql + ",g.Descripcion,g.Fecha,g.Importe";
            sql = sql + " from GastosNegocio g";           
            sql = sql + " where g.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and g.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Descripcion != "")
                sql = sql + " and Descripcion like" + "'%" + Descripcion + "%'";
            sql = sql + " order by g.CodGasto Desc";
            return cDb.ExecuteDataTable(sql);
        }

        public double GetGastosNegocio(DateTime FechaDesde,DateTime FechaHasta,Int32? CodEntidad)
        {
            double Importe = 0;
            string sql = " select sum(Importe) as Importe";
            sql = sql + " from GastosNegocio";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (CodEntidad != null)
                sql = sql + " and CodEntidad =" + CodEntidad.ToString ();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }
    }
}
