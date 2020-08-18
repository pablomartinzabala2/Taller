using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cCobroTarjeta
    {
        public void Registrar(SqlConnection con, SqlTransaction Transaccion,Int32? CodOrden, DateTime Fecha, Int32 CodTarjeta, double Importe,string Cupon,DateTime FechaEmision,Double? Recargo,Int32 CodCliente,Int32? CodVenta)
        {
            string sql = "Insert into CobroTarjeta(CodOrden,Fecha,CodTarjeta,Importe,Saldo,Cupon,FechaEmision,Recargo,CodCliente,CodVenta)";
            if (CodOrden != null)
                sql = sql + "Values(" + CodOrden.ToString();
            else
                sql = sql + "Values(null";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodTarjeta.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'"+ Cupon + "'";
            sql = sql + "," + "'" + FechaEmision.ToShortDateString() + "'";
            if (Recargo != null)
                sql = sql + "," + Recargo.ToString().Replace(",", ".");
            else
                sql = sql + ",null";
            sql = sql + "," + CodCliente.ToString();
            if (CodVenta != null)
                sql = sql + "," + CodVenta.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotal()
        {
            double Importe = 0;
            string sql = "select sum(isnull(Saldo,0)) as Importe";
            sql = sql + " from CobroTarjeta";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }

        public DataTable GetCobroTarjetaxFecha(DateTime FechaDesde,DateTime FechaHasta,Int32? CodOrden,string Cupon,int Impago)
        {
            string sql ="select ct.*,t.Nombre,cli.Apellido,ct.CodOrden as Orden"; //,a.Patente,a.Descripcion as Descripción";
            sql = sql + ",( select au.Patente from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = ct.CodOrden) as Patente";
            sql = sql + ",( select au.Descripcion from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = ct.CodOrden) as Descripcion";
            sql = sql + " from CobroTarjeta ct,Tarjeta t,Cliente cli";
            sql = sql + " where ct.CodTarjeta = t.CodTarjeta";
            sql = sql + " and ct.CodCliente = cli.CodCliente";
            
            if (CodOrden != null)
                sql = sql + " and ct.CodOrden =" + CodOrden.ToString();
            if (Cupon != "")
                sql = sql + " and ct.Cupon like " + "'%" + Cupon + "%'";
            sql = sql + " and ct.Fecha>=" + "'" + FechaDesde.ToShortDateString () + "'" ;
            sql = sql + " and ct.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Impago == 1)
                sql = sql + " and ct.Saldo >0";
            
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetCobroTarjeta(Int32 CodCobro)
        {
            string sql = "select ct.*,t.Nombre,cli.Apellido,cli.Nombre as Nom,ct.CodOrden as Orden"; //,a.Patente,a.Descripcion as Descripción";
            sql = sql + ",( select au.Patente from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = ct.CodOrden) as Patente";
            sql = sql + ",( select au.Descripcion from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = ct.CodOrden) as Descripcion";
            sql = sql + " from CobroTarjeta ct,Tarjeta t,Cliente cli";
            sql = sql + " where ct.CodTarjeta = t.CodTarjeta";
            sql = sql + " and ct.CodCliente = cli.CodCliente";
            sql = sql + " and ct.CodCobro=" + CodCobro.ToString();

            return cDb.ExecuteDataTable(sql);
        }

        /*
        public DataTable  GetCobroTarjeta(Int32 CodCobro)
        {
            string sql = "select ct.*,t.Nombre,cli.Apellido,cli.Nombre as Nom,a.Patente,o.CodOrden";
            sql = sql + " from CobroTarjeta ct,Tarjeta t,Orden o,Cliente cli,auto a";
            sql = sql + " where ct.CodTarjeta = t.CodTarjeta";
            sql = sql + " and ct.CodOrden = o.CodOrden";
            sql = sql + " and o.CodCliente = cli.CodCliente";
            sql = sql + " and o.CodAuto = a.CodAuto";
            sql = sql + " and CodCobro=" + CodCobro.ToString ();
            return cDb.ExecuteDataTable(sql);
        }
        */
        public void CobroTarjeta(Int32 CodCobro,DateTime FechaCobro,Double ImporteCobrado)
        {
            string sql = "Update CobroTarjeta set Saldo =0 "; 
            sql = sql + ",FechaCobro=" + "'" + FechaCobro.ToShortDateString() + "'";
            sql = sql + ",ImporteCobrado=" + ImporteCobrado.ToString().Replace(",", ".");
            sql = sql + " where CodCobro=" + CodCobro.ToString ();
            
            cDb.ExecutarNonQuery(sql);
        }

        public void AnularCobro(Int32 CodCobro)
        {
            string sql = "update CobroTarjeta set Saldo = Importe,FechaCobro=NULL";
            sql = sql + " where CodCobro =" + CodCobro.ToString ();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetCobroTarjetaxCodOrden(Int32 CodOrden)
        {
            string sql = "select * from CobroTarjeta c,Tarjeta t where c.CodTarjeta = t.CodTarjeta and CodOrden =" + CodOrden.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public double GetTotalTarjeta(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Importe) as ImporteTarjeta from CobroTarjeta";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and ImporteCobrado is null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTarjeta"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteTarjeta"].ToString());
             sql = "select sum(ImporteCobrado) as ImporteTarjeta from CobroTarjeta";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and ImporteCobrado is not null";
            trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTarjeta"].ToString() != "")
                    Importe =Importe +  Convert.ToDouble(trdo.Rows[0]["ImporteTarjeta"].ToString());
            return Importe;
        }

        public double GetTotalSaldoTarjeta(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Saldo) as ImporteTarjeta from CobroTarjeta";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTarjeta"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteTarjeta"].ToString());
            return Importe;
        }

        public double GetSaldoTarjetaxCodOrden(Int32 CodOrden)
        {
            double Importe =0;
            string sql = "select sum(Saldo) as Importe from CobroTarjeta";
            sql = sql + " where CodOrden =" + CodOrden.ToString ();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public DataTable GetCobrotarjetaAdeudada(string Patente, string Apellido, DateTime Fecha, int ConDeuda,Int32? CodOrden,string Cupon)
        {
            int b = 0;
            Int32 CodAuto = 0;
            string sql = "";
            string ListaCodAuto = "(";
            if (Patente != "")
            {
                b = 1;
                Clases.cAuto auto = new Clases.cAuto();
                DataTable trdo = auto.GetAutoxContenidoPatente(Patente);
                if (trdo.Rows.Count > 0)
                {
                    if (trdo.Rows[0]["CodAuto"].ToString() != "")
                    {
                        for (int i = 0; i < trdo.Rows.Count; i++)
                        {
                            b = 1;
                            CodAuto = Convert.ToInt32(trdo.Rows[i]["CodAuto"].ToString());
                            if (ListaCodAuto == "(")
                                ListaCodAuto = ListaCodAuto + CodAuto.ToString();
                            else
                                ListaCodAuto = ListaCodAuto + "," + CodAuto.ToString();
                        }
                        ListaCodAuto = ListaCodAuto + ")";
                    }
                }
                sql = sql + " select *";
                sql = sql + " from CobroTarjeta c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and c.Saldo>0";
                if (ListaCodAuto != "(")
                    sql = sql + " and o.CodAuto in " + ListaCodAuto.ToString();
                else
                    sql = sql + " and o.CodAuto=-1";
            }
            if (Cupon != "")
            {
                sql = sql + " select *";
                sql = sql + " from CobroTarjeta c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and c.Saldo>0";
                sql = sql + " and c.Cupon like " + "'%" + Cupon  +"%'";
                b = 1;
            }
            if (CodOrden != null)
            {
                sql = sql + " select *";
                sql = sql + " from CobroTarjeta c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and c.Saldo>0";
                if (CodOrden !=-1)
                sql = sql + " and o.CodOrden=" + CodOrden.ToString();
                b = 1;
            }
            if (b == 0)
            {
                string ListaCliente = "(";
                cCliente cli = new cCliente();
                DataTable trdo = cli.GetClientexApellido(Apellido);
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    if (ListaCliente == "(")
                    {
                        ListaCliente = ListaCliente + trdo.Rows[i]["CodCliente"].ToString();
                    }
                    else
                    {
                        ListaCliente = ListaCliente + "," + trdo.Rows[i]["CodCliente"].ToString();
                    }
                }
                ListaCliente = ListaCliente + ")";
                if (ListaCliente == "()")
                    ListaCliente = "(-1)";
                sql = sql + " select *";
                sql = sql + " from CobroTarjeta c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                
                sql = sql + " and c.Saldo > 0";
                if (ListaCliente != "(")
                    sql = sql + " and o.CodCliente in " + ListaCliente.ToString();
                else
                    sql = sql + " and o.CodCliente=-1";
            }
            return cDb.ExecuteDataTable(sql);
        }

        public double GetSaldo(Int32 CodCobro)
        {
            string sql = " select Saldo from CobroTarjeta";
            sql = sql + " where CodCobro=" + CodCobro.ToString();
            sql = sql + " and FechaCobro is not null";
            Double Saldo = 0;
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Saldo"].ToString() != "")
                    Saldo = Convert.ToDouble(trdo.Rows[0]["Saldo"].ToString());
            return Saldo;
        }

        public double GetSaldoxFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = " select isnull(sum(Saldo),0) as Saldo from CobroTarjeta";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha<= " + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and FechaCobro is not null";
            Double Saldo = 0;
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Saldo"].ToString() != "")
                    Saldo = Convert.ToDouble(trdo.Rows[0]["Saldo"].ToString());
            return Saldo;
        }

        public double GetMontoAnular(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = " select (ImporteCobrado) as Importe ";
            sql = sql + " from CobroTarjeta";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
                if (trdo.Rows[0]["Importe"].ToString() !="")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            return Importe;
        }

        public DataTable GetCobroTarjetaxCodVenta(Int32 CodVenta)
        {
            string  sql ="select ct.*,t.nombre";
            sql = sql + " from CobroTarjeta ct,Tarjeta t";
            sql = sql + " where ct.CodTarjeta=t.CodTarjeta";
            sql = sql + " and ct.CodVenta=" + CodVenta.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetImporteCobradoxCodOrden(Int32 CodOrden)
        {
            string sql = "select ImporteCobrado from CobroTarjeta";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            sql = sql + " and FechaCobro is not null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            Double Importe = 0;
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["ImporteCobrado"].ToString() != "")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteCobrado"].ToString());
                }
            }
            return Importe;
        }

        public void BorrarCobroTarjeta(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden)
        {
            string sql = "delete from CobroTarjeta where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalRecargoTarjeta(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            double ImporteCobrado = 0;
            string sql = "select sum(Importe) as ImporteTarjeta from CobroTarjeta";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and FechaCobro is not null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTarjeta"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteTarjeta"].ToString());
            sql = "select sum(ImporteCobrado) as ImporteTarjeta from CobroTarjeta";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and FechaCobro is not null";
            trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteTarjeta"].ToString() != "")
                    ImporteCobrado  =  Convert.ToDouble(trdo.Rows[0]["ImporteTarjeta"].ToString());
            ImporteCobrado = ImporteCobrado - Importe;
            //importecobrado tiene el recargo
            return ImporteCobrado ;
        }
    }
}
