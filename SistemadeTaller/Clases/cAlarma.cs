using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public  class cAlarma
    {
        public void GrabarAlarma(string Descripcion, DateTime Fecha)
        {
            string sql = "Insert into Alarma(Nombre,Fecha)";
            sql = sql + "Values(" + "'" + Descripcion + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetAlarmasxFecha(DateTime Fecha)
        {
            string sql = "select * from Alarma";
            sql = sql + " where Fecha =" + "'" + Fecha.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetAlertasxRangoFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select * from Alarma";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
