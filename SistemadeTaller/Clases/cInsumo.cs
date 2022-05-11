using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cInsumo
    {
        public DataTable GetInsumos()
        {
            string sql = "Select CodInsumo,Nombre";
            sql = sql + " from Insumo";
            sql = sql + " order by Nombre";
            return cDb.ExecuteDataTable(sql);
        }

        public void InsertarInsumo(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden, Int32 CodTarea, Int32 CodInsumo, double PrecioCosto, double PrecioVenta)
        {
            string sql = "insert into InsumosxTarea";
            sql = sql + "(CodOrden,CodTarea,CodInsumo,PrecioCosto,PrecioVenta)";
            sql = sql + "values (" + CodOrden.ToString();
            sql = sql + "," + CodTarea.ToString();
            sql = sql + "," + CodInsumo.ToString();
            sql = sql + "," + PrecioCosto.ToString().Replace(",", ".");
            sql = sql + "," + PrecioVenta.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Int32 IngresarInsumo(string Nombre, string Factura, Int32? CodProveedor)
        {
            string sql = "Insert into Insumo(Nombre,Factura,Proveedor)";
            sql = sql + "values (" + "'" + Nombre + "'";
            sql = sql + "," + "'" + Factura + "'";
            if (CodProveedor != null)
                sql = sql + "," + CodProveedor.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);

        }

        public DataTable GetInsumoxCodigo(Int32 CodInsumo)
        {
            string sql = "select * from Insumo where CodInsumo =" + CodInsumo.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void ModificarInsumo(Int32 CodInsumo, string Nombre, string Factura, Int32? CodProveedor)
        {
            string sql = "Update Insumo set Nombre =" + "'" + Nombre + "'";
            sql = sql + ",Factura =" + "'" + Factura + "'";
            if (CodProveedor != null)
                sql = sql + ",CodProveedor =" + CodProveedor.ToString();
            else
                sql = sql + ",CodProveedor=null";
            sql = sql + " where CodInsumo =" + CodInsumo.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetInsumosxNombre(string Nombre)
        {
            string sql = "select CodInsumo,Nombre,Precio,Cantidad,PrecioVenta from Insumo";
            if (Nombre != "")
            {
                sql = sql + " where Nombre like " + "'%" + Nombre + "%'";
                sql = sql + " and ActualizaStock =1";
            }
            else
            {
                sql = sql + " where ActualizaStock =1";
            }

            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetInsumoxCodigoBarra(string CodigoBarra)
        {
            string sql = "select CodInsumo,Nombre,Precio,Cantidad,PrecioVenta from Insumo";
            sql = sql + " where CodigoBarra=" + "'" + CodigoBarra + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarStock(SqlConnection con, SqlTransaction Transaccion, Int32 CodInsumo, Int32 Cantidad)
        {
            string sql = "update Insumo set Cantidad = isnull(Cantidad,0) +" + Cantidad.ToString();
            sql = sql + " where CodInsumo =" + CodInsumo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalInsumo()
        {
            string sql = "select (isnull(Cantidad,0)*isnull(precio,0)) as Total";
            sql = sql + " from Insumo where ActualizaStock =1";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            cFunciones fun = new cFunciones();
            double Total = fun.TotalizarColumna(trdo, "Total");
            return Total;
        }

        public DataTable GetInsumoxNombre(string Nombre)
        {
            string sql = "select *";
            sql = sql + " from Insumo where ActualizaStock =1";
            if (Nombre != "")
                sql = sql + "and nombre like " + "'%" + Nombre + "%'";
            sql = sql + " order by Nombre ";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarPrecio(SqlConnection con, SqlTransaction Transaccion, Int32 CodInsumo, double Precio, Double PrecioVenta)
        {
            string sql = "Update insumo set precio =" + Precio.ToString().Replace(",", ".");
            sql = sql + ",PrecioVenta=" + PrecioVenta.ToString().Replace(",", ".");
            sql = sql + " where CodInsumo =" + CodInsumo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetDetalleInsumoxCodigoBarra(string CodigoBarra)
        {
            string sql = "select CodInsumo,Nombre,Precio,Cantidad,PrecioVenta from Insumo";
            sql = sql + " where CodigoBarra =" + "'" + CodigoBarra + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetBruto()
        {
            string sql = "select sum(isnull (cantidad,0) * isnull (precio,0)) as total";
            sql = sql + " from insumo ";
            Double Total = 0;
            Total = Convert.ToDouble(cDb.EjecutarEscalar(sql));
            return Total;
        }

        public Int32 InsertrInsumoSimple(string Nombre, Double Precio)
        {
            string sql = "Insert into Insumo(Nombre,Precio)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            sql = sql + "," + Precio.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);
        }
    }
}
