using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SistemadeTaller.Clases
{
    public class cOrdenDetalle
    {
        public void InsertarOrdenDetalleTran(SqlConnection con, SqlTransaction Transaccion, string CodOrden, string CodInsumo,double Cantidad,double Costo,double Venta,Double  ManoObra)
        {
            string sql = "Insert into OrdenDetalle";
            sql = sql + "(CodOrden,CodInsumo,Cantidad,PrecioCosto,PrecioVenta,PrecioManoObra)";
            sql = sql + " values (";
            sql = sql + "'" + CodOrden + "'";
            sql = sql + "," + "'" + CodInsumo + "'";
            sql = sql + "," + Cantidad.ToString().Replace(",", ".");
            sql = sql + "," + Costo.ToString().Replace(",", ".");
            sql = sql + "," + Venta.ToString().Replace(",", ".");
            sql = sql + "," + ManoObra.ToString().Replace(",", ".");
            sql = sql + ")";
             cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void BorrarDetalleOrden(SqlConnection con, SqlTransaction Transaccion, Int32  CodOrden)
        {
            string sql ="delete from OrdenDetalle where CodOrden =" + CodOrden.ToString ();
            cDb.EjecutarNonQueryTransaccion (con,Transaccion ,sql);
        }

        public DataTable GetOrdenDetallexCodOrden(Int32 CodOrden)
        {
            string sql = " select *";
            sql = sql + " from OrdenDetalle o,Insumo i";
            sql = sql + " where o.CodInsumo = i.CodInsumo";
            sql = sql + " and o.CodOrden =" + CodOrden.ToString ();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
