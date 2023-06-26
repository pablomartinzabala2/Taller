using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public  class cMecanico
    {
        public DataTable GetMecanicos()
        {
            string sql = "Select CodMecanico, (Apellido + ' ' + Nombre) as Apellido";
            sql = sql + " from Mecanico ";
            sql = sql + " order by Apellido ";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetMecanicosActivos()
        {
            string sql = "select * from Mecanico where Activo=1";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetProduccion(DateTime FechaDesde,DateTime FechaHasta, Int32? CodMecanico)
        {
           // string sql = "select m.Apellido,m.Nombre,Count(o.CodOrden) as Cantidad,isnull(sum(o.Total),0) as Total";
            string sql = "select m.Apellido,m.Nombre,Count(o.CodOrden) as Cantidad,isnull(sum(od.PrecioManoObra),0) as Total";
            sql = sql + " from Orden o,Mecanico m,OrdenDetalle od ";
            sql = sql + " where o.CodMecanico=m.CodMecanico";
            sql = sql + " and o.CodOrden=od.CodOrden ";
            sql = sql + " and o.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (CodMecanico != null)
                sql = sql + " and o.CodMecanico=" + CodMecanico.ToString();
            sql = sql + " Group by m.Apellido,m.Nombre";
            sql = sql + " order by m.Apellido,m.Nombre ";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
