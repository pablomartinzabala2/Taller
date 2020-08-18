using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cCompra
    {
        public Int32 InsertarCompra(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,Int32? CodProveedor,string Factura)
        {
            string sql = "insert into Compra(Fecha,CodProveedor,Factura)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            if (CodProveedor != null)
                sql = sql + "," + CodProveedor.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + Factura + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public DataTable GetDetalleCompraxCodInsumo(Int32 CodInsumo)
        {
            string sql = " select *";
            sql = sql + " from Compra c,DetalleCompra d";
            sql = sql + " where c.CodCompra = d.CodCompra";
            sql = sql + " and d.CodInsumo =" + CodInsumo.ToString ();
            sql = sql + " order by c.CodCompra desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDetalleCompraxFecha(DateTime FechaDesde,DateTime FechaHasta,string Insumo)
        {
            string sql = "select (select p.Nombre from Proveedor p where p.CodProveedor = c.CodProveedor)";
            sql = sql + ",(select p.Telefono from Proveedor p where p.CodProveedor = c.CodProveedor)";
            sql = sql + ",c.Factura";
            sql = sql + ",i.Nombre,i.Cantidad,i.Precio,(i.Cantidad* i.Precio) as Total";
            sql = sql + " from Compra c,DetalleCompra dc,Insumo i";
            sql = sql + " where c.CodCompra = dc.CodCompra";
            sql = sql + " and dc.CodInsumo = i.CodInsumo";
            sql = sql + " and c.Fecha >=" + "'" + FechaDesde.ToShortDateString () + "'";
            sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Insumo != "")
                sql = sql + " and i.Nombre like " + "'%" + Insumo  + "%'";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
