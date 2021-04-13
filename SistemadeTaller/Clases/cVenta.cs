using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemadeTaller.Clases
{
    public class cVenta
    {
        public Int32 InsertarVenta(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha, Double Total,Int32? CodCliente,Double Efectivo)
        {
            string sql = "Insert into Venta(Fecha,Total,CodCliente,Efectivo)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void InsertarDetalleVenta(SqlConnection con, SqlTransaction Transaccion,
            Int32 CodVenta,Int32 CodInsumo,Int32 Cantidad,Double Precio,Double Subtotal,Double Costo)
        {
            string sql = "Insert into DetalleVenta(CodVenta,CodInsumo";
            sql = sql + ",Cantidad,Precio,Subtotal,Costo)";
            sql = sql + "Values(" + CodVenta.ToString();
            sql = sql + "," + CodInsumo.ToString();
            sql = sql + "," + Cantidad.ToString();
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + "," + Costo.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetVentas(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select CodVenta,Fecha";
            sql = sql + ",(select c.Apellido from cliente c";
            sql = sql + " where c.CodCliente = v.CodCliente) as Apellido";
            sql = sql + ",(select c.Nombre from cliente c";
            sql = sql + " where c.CodCliente = v.CodCliente) as Nombre";
            sql = sql + ",v.Total";
            sql = sql + " from Venta v";
            sql = sql + " where v.Fecha>=" + "'" + FechaDesde.ToShortDateString () +"'";
            sql = sql + " and v.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by v.CodVenta desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDetalleVenta(Int32 CodVenta)
        {
            string sql = "select d.*,i.Nombre from DetalleVenta d,insumo i";
            sql = sql + " where d.CodInsumo =i.CodInsumo";
            sql = sql + " and d.CodVenta=" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetVenta(Int32 CodVenta)
        {
            string sql = " select * from venta";
            sql = sql + " where CodVenta=" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public double GetCostoInsumoVenta(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Costo = 0;
            string sql = " select (sum(isnull(d.Costo,0))) as Costo";
            sql = sql + " from Venta v,DetalleVenta d";
            sql = sql + " where v.CodVenta= d.CodVenta";
            sql = sql + " and v.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and v.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Costo"].ToString() != "")
                    Costo = Convert.ToDouble(trdo.Rows[0]["Costo"].ToString());
            return Costo;
        }

        public double GetVentaInsumoVenta(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Costo = 0;
            string sql = " select (sum(isnull(d.Subtotal,0))) as Venta";
            sql = sql + " from Venta v,DetalleVenta d";
            sql = sql + " where v.CodVenta= d.CodVenta";
            sql = sql + " and v.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and v.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Venta"].ToString() != "")
                    Costo = Convert.ToDouble(trdo.Rows[0]["Venta"].ToString());
            return Costo;
        }

    }
}
