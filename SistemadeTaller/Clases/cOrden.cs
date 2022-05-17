using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SistemadeTaller.Clases
{
    public class cOrden
    {
        public Int32 InsertarOrdenTran(SqlConnection con, SqlTransaction Transaccion, Int32? CodCliente, string CodMecanico, string FechaAlta,Int32 CodAuto,Int32? Procesada,string Descripcion, double ImporteEfectivo,
            DateTime FechaEntrega,Double Total,string Kilometraje)
        {
            string sql = "Insert into Orden";
            sql = sql + "(CodCliente,CodMecanico,Fecha,CodAuto,Procesada,Descripcion,ImporteEfectivo,FechaEntrega,Total,Kilometraje)";
            sql = sql + " values (";
            if (CodCliente !=null)
                sql = sql + "'" + CodCliente.ToString () + "'";
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + CodMecanico + "'";
            sql = sql + "," + "'" + FechaAlta + "'";
            sql = sql + "," + CodAuto.ToString();
            sql = sql + "," + Procesada.ToString();
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + "," + ImporteEfectivo.ToString().Replace(",", ".");
            sql = sql + "," + "'" + FechaEntrega.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Kilometraje + "'";
            sql = sql + ")";
            
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ModificarOrdenTran(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden, Int32? CodCliente, string CodMecanico, string FechaAlta, Int32 CodAuto, int Procesada, string Descripcion, double ImporteEfectivo, DateTime FechaEntregao,Double Total,string kilometraje)
        {
            string sql = "Update Orden";
            if (CodCliente != null)
                sql = sql + " set CodCliente =" + CodCliente.ToString();
            else
                sql = sql + " set CodCliente =null";
            sql = sql + ",CodMecanico =" + CodMecanico.ToString();
            sql = sql + ",Fecha =" + "'" + FechaAlta.ToString() + "'";
            sql = sql + ",CodAuto =" + CodAuto.ToString();
            sql = sql + ", Procesada =" + Procesada.ToString();
            sql = sql + ", Descripcion =" + "'" + Descripcion +"'";
            sql = sql + ",ImporteEfectivo = " + ImporteEfectivo.ToString().Replace(",", ".");
            sql = sql + ", FechaEntrega=" + "'" + FechaEntregao.ToShortDateString() + "'";
            sql = sql + ",Total=" + Total.ToString().Replace(",", ".");
            sql = sql + ",kilometraje=" + "'" + kilometraje + "'";
            sql = sql + " where CodOrden =" + CodOrden.ToString ();
            
            
             cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Int32 GetSiguienteId(SqlConnection con, SqlTransaction Transaccion)
        {
            string sql = "select SCOPE_IDENTITY()";
            return cDb.EjecutarEscalarTransaccion(con,Transaccion,sql);
        }

        public DataTable GetOrdenxFecha(DateTime FechaDesde, DateTime FechaHasta,string Patente,string Apellido,Int32? CodOrden,Int32? Tipo)
        {
            string sql = "select o.CodOrden,a.Patente,a.Descripcion";
            sql = sql + ",(select m.Nombre from Marca m where m.CodMarca= a.CodMarca) as Marca";
            sql = sql + ",o.Fecha";
            sql = sql + ",(select cli.Nombre from Cliente cli where cli.CodCliente= o.CodCliente) as Nombre";
            sql = sql + ",(select cli.Apellido from Cliente cli where cli.CodCliente= o.CodCliente) as Apellido";
            sql = sql + ",m.Apellido as Mecánico";
            sql = sql + ",(select isnull(sum(PrecioCosto),0) from OrdenDetalle od where od.CodOrden=o.CodOrden) as Costo ";
            sql = sql + ",(select isnull(sum(PrecioVenta),0) from OrdenDetalle od where od.CodOrden=o.CodOrden) as Venta ";
            sql = sql + ",(select isnull(sum(PrecioManoObra),0) from OrdenDetalle od where od.CodOrden=o.CodOrden) as ManoObra ";
            sql = sql + ",((select isnull(sum(PrecioVenta),0) from OrdenDetalle od where od.CodOrden=o.CodOrden) - ";
            sql = sql + " (select isnull(sum(PrecioCosto),0) from OrdenDetalle od where od.CodOrden=o.CodOrden)  ";
            sql = sql + " - ( select isnull(sum(Saldo),0) from cobroTarjeta cob where cob.CodOrden = o.CodOrden and cob.FechaCobro is not null )";
            sql = sql + " + (select isnull(sum(CobroTar3.ImporteCobrado),0) - isnull(sum(CobroTar3.Importe) ,0) from CobroTarjeta CobroTar3 where CobroTar3.CodOrden= o.CodOrden and CobroTar3.FechaCobro is not null)";
          //  sql = sql + "+ (select isnull(sum(cc.Importe),0) from CuentaCorriente cc where cc.CodOrden=o.CodOrden)";
            sql = sql + " + (select isnull(sum(PrecioManoObra),0) from OrdenDetalle od where od.CodOrden=o.CodOrden)) as Ganancia  ";
            sql = sql + ",o.Procesada";
            sql = sql + ",o.ImporteEfectivo as Efectivo";
            sql = sql + ",(select sum(Importe) from Documento doc where doc.CodOrden= o.CodOrden) as Documento";
            sql = sql + ",(select sum(Importe) from Cheque che where che.CodOrden= o.CodOrden) as Cheque";
            sql = sql + ",(select sum(Importe) from CuentaCorriente cc where cc.CodOrden= o.CodOrden) as CuentaCorriente";
            sql = sql + ",((select isnull(sum(Importe),0) from CobroTarjeta CobroTar where CobroTar.CodOrden= o.CodOrden and CobroTar.FechaCobro is null) + (select isnull(sum(CobroTar2.ImporteCobrado),0) from CobroTarjeta CobroTar2 where CobroTar2.CodOrden= o.CodOrden and CobroTar2.FechaCobro is not null)) as Tarjeta";
            sql = sql + ",(select sum(Importe) from Garantia Garan where Garan.CodOrden= o.CodOrden) as Garantia";
            sql = sql + ",((select isnull(sum(Saldo),0) from CobroTarjeta CobTar where CobTar.CodOrden = o.CodOrden)";
            sql = sql + " + (select isnull(sum(Saldo),0) from Documento Docum where Docum.CodOrden = o.CodOrden)";
            sql = sql + " + (select isnull(sum(Saldo),0) from Cheque Checka where Checka.CodOrden = o.CodOrden)";
            sql = sql + " + (select isnull(sum(Saldo),0) from Garantia gara where gara.CodOrden = o.CodOrden)";
            sql = sql + ") as Saldo";
            //parte nueva 17/5/22
            sql = sql + ",(select sum(isnull(ddd.Cantidad,0)*isnull(ddd.PrecioVenta,0)) from OrdenDetalle ddd where ddd.CodOrden = o.CodOrden) as VentaInsumo ";
            sql = sql + ",(select sum(isnull(ddd.Cantidad,0)*isnull(ddd.PrecioCosto,0)) from OrdenDetalle ddd where ddd.CodOrden = o.CodOrden) as CostoInsumo ";
            sql = sql + ",((select sum(isnull(ddd.Cantidad,0)*isnull(ddd.PrecioVenta,0)) from OrdenDetalle ddd where ddd.CodOrden = o.CodOrden) - (select sum(isnull(ddd.Cantidad,0)*isnull(ddd.PrecioCosto,0)) from OrdenDetalle ddd where ddd.CodOrden = o.CodOrden)) as GananciaInsumo ";
          //  sql = sql + ", ((select isnull(ddd.Cantidad,0)*isnull(ddd.PrecioVenta,0) from OrdenDetalle ddd where ddd.CodOrden = o.CodOrden)) - sum(select isnull(ddd.Cantidad,0)*isnull(ddd.PrecioCosto,0) from OrdenDetalle ddd where ddd.CodOrden = o.CodOrden)) as GananciaInsumo";
            sql = sql + " from orden o,auto a,Mecanico m,cliente cli";
            sql = sql + " where o.CodAuto = a.CodAuto";
            sql = sql + " and o.CodMecanico = m.CodMecanico";
            sql = sql + " and o.CodCliente = cli.CodCliente";
            sql = sql + " and o.Fecha >=" + "'" + FechaDesde + "'" ;
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta  + "'";
            if (Patente != "")
                sql = sql + " and a.Patente like " + "'%" + Patente  + "%'" ;
            if (Apellido != "")
                sql = sql + "and cli.Apellido like " + "'%" + Apellido  + "%'";
            if (CodOrden != null)
                sql = sql + " and o.CodOrden =" + CodOrden.ToString() ;
            if (Tipo != null)
            {
                if (Tipo == 1)
                    sql = sql + " and o.Procesada =0";

                if (Tipo == 3)
                    sql = sql + " and o.Procesada =1";
                
            }
            sql = sql + " order by CodOrden desc";
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 GetMaxOrden()
        {
            Int32 CodOrden =0;
            string sql = "select max(CodOrden) as CodOrden from Orden";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodOrden"].ToString() != "")
                    CodOrden = Convert.ToInt32(trdo.Rows[0]["CodOrden"].ToString());
            CodOrden++;
            return CodOrden;
        }

        public DataTable GetOrdenxCodigo(Int32 CodOrden)
        {
            string sql = " select  c.CodCliente,c.Telefono, c.Apellido,c.Nombre";
            sql = sql + ", a.CodAuto,a.CodMarca,a.Patente,a.Descripcion,a.Chasis,a.Motor,a.Kilometros,o.CodMecanico,o.Procesada,o.Descripcion as DescripcionOrden,o.ImporteEfectivo,o.Fecha";
            sql = sql + " from Orden o,Cliente c,Auto a";
            sql = sql + " where o.CodCliente = c.CodCliente";
            sql = sql + " and o.CodAuto = a.CodAuto";
            sql = sql + " and o.CodOrden =" + CodOrden.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 CantidadOrdenes(DateTime FechaDesde, DateTime FechaHasta,string Patente)
        {  
            Int32 Cantidad = 0;
            string sql = "select count(*) as Cantidad from Orden o,auto a";
            sql = sql + " where o.CodAuto=a.CodAuto";
            sql = sql + " and o.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente != null)
                sql = sql + " and a.Patente=" + "'" + Patente + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
                if (trdo.Rows[0]["Cantidad"].ToString ()!="")
                    Cantidad = Convert.ToInt32 (trdo.Rows[0]["Cantidad"].ToString ());
            
            return Cantidad;
        }

        public double GetTotalEfectivo(DateTime FechaDesde,DateTime FechaHasta,string Patente)
        { 
            double Importe =0;
            string sql = "select sum(ImporteEfectivo) as ImporteEfectivo from Orden o,Auto a";
            sql = sql + " where o.CodAuto = a.CodAuto";
            sql = sql + " and o.Fecha>=" + "'" + FechaDesde.ToShortDateString () + "'" ;
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente != null)
                sql = sql + " and a.Patente =" + "'" + Patente + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteEfectivo"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteEfectivo"].ToString());
            return Importe;
        }

        public double GetGananciaInsumo(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Ganancia = 0;
            string sql = " select  (sum(od.PrecioVenta) - sum(od.PrecioCosto)) as Ganancia";
            sql = sql + " from Orden o,OrdenDetalle od, auto a";
            sql = sql + " where o.CodOrden = od.CodOrden";
            sql = sql + " and o.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and o.CodAuto = a.CodAuto ";
            if (Patente != null)
                sql = sql + " and a.Patente = " + "'" + Patente + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Ganancia"].ToString() != "")
                    Ganancia = Convert.ToDouble(trdo.Rows[0]["Ganancia"].ToString());
            return Ganancia;
        }

        public double GetGananciaManoObra(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Ganancia = 0;
            string sql = " select (sum(od.PrecioManoObra)) as Ganancia";
            sql = sql + " from Orden o,OrdenDetalle od, auto a";
            sql = sql + " where o.CodOrden = od.CodOrden";
            sql = sql + " and o.CodAuto = a.CodAuto ";
            sql = sql + " and o.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente !=null)
            {
                sql = sql + " and a.Patente =" + "'" + Patente + "'";
            }
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Ganancia"].ToString() != "")
                    Ganancia = Convert.ToDouble(trdo.Rows[0]["Ganancia"].ToString());
            return Ganancia;
        }

        public Double GetTotalEfectivoOrden(Int32 CodOrden)
        {
            Double Importe = 0;
            string sql = "select isnull(sum(ImporteEfectivo),0) as Importe from Orden ";
            sql = sql + " where CodOrden=" + CodOrden.ToString ();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }

            return Importe;
        }

        public void EliminarOrden(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "Delete from ordendetalle where CodOrden =" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
             sql = "Delete from orden where CodOrden =" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void ActualizarNroOrden(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "update Orden set NroOrden=" + CodOrden.ToString();
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetVentaInsumo(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Venta = 0;
            string sql = " select (sum(od.PrecioVenta)) as Venta";
            sql = sql + " from Orden o,OrdenDetalle od, Auto a";
            sql = sql + " where o.CodOrden = od.CodOrden";
            sql = sql + " and o.CodAuto = a.CodAuto ";
            sql = sql + " and o.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente !=null)
            {
                sql = sql + " and a.Patente =" + "'" + Patente + "'";
            }
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Venta"].ToString() != "")
                    Venta = Convert.ToDouble(trdo.Rows[0]["Venta"].ToString());
            return Venta;
        }

        public double GetCostoInsumo(DateTime FechaDesde, DateTime FechaHasta, string Patente )
        {
            double Costo = 0;
            string sql = " select (sum(od.PrecioCosto)) as Costo";
            sql = sql + " from Orden o,OrdenDetalle od, Auto a";
            sql = sql + " where o.CodOrden = od.CodOrden";
            sql = sql + " and o.CodAuto = a.CodAuto ";
            sql = sql + " and o.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and o.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Costo"].ToString() != "")
                    Costo = Convert.ToDouble(trdo.Rows[0]["Costo"].ToString());
            return Costo;
        }

    }
} 
