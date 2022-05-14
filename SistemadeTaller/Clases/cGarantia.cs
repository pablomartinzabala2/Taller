using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cGarantia
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion, double Importe, Int32? CodOrden,DateTime Fecha)
        {
            string sql = "Insert into Garantia(Importe,CodOrden,Saldo,Fecha)";
            sql = sql + " values (" + Importe.ToString().Replace(",", ".");
            if (CodOrden != null)
                sql = sql + "," + CodOrden.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalGarantia()
        {
            double Importe = 0;
            string sql = "select sum(isnull(Saldo,0)) as Importe";
            sql = sql + " from Garantia";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }

        public double GetTotalxCodOrden(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = "select isnull(sum(Importe),0) as Importe from Garantia ";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());

            }
            return Importe;
        }

        public DataTable GetGarantiasxFecha(DateTime FechaDesde, DateTime FechaHasta,string Patente)
        {
            string sql = "select g.CodGarantia,g.CodOrden,a.Patente,g.Importe,g.Saldo,Cli.Nombre,Cli.Apellido ";
            sql = sql + " from Garantia g,Orden o,Auto a,cliente Cli";
            sql = sql + " where g.CodOrden = o.CodOrden";
            sql = sql + " and o.CodAuto = a.CodAuto";
            sql = sql + " and o.CodCliente = cli.CodCliente";
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'" ;
            sql = sql + " and g.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and g.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by CodOrden desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetGarantiaxCodigo(Int32 CodGarantia)
        {
            string sql = "select g.*,a.Patente";
            sql = sql + " from Garantia g,orden o,auto a";
            sql = sql + " where g.CodOrden = o.CodOrden";
            sql = sql + " and o.CodAuto = a.CodAuto";
            sql = sql + " and CodGarantia=" + CodGarantia.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarPago(Int32 CodGarantia, DateTime Fecha)
        {
            string sql = "Update Garantia set FechaPago =" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " ,Saldo =0";
            sql = sql + " where CodGarantia=" + CodGarantia.ToString ();
            cDb.ExecutarNonQuery(sql);
        }

        public void AnularGarantia(Int32 CodGarantia)
        {
            string sql = "Update Garantia";
            sql = sql + " set Saldo = Importe";
            sql = sql + ",FechaPago = null";
            sql = sql + " where CodGarantia =" + CodGarantia.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetGarantiaxCodOrden(Int32 CodOrden)
        {
            string sql = "select * from Garantia where CodOrden =" + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public double GetTotalGarantiaxFecha(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Importe = 0;
            string sql = "select sum(g.Importe) as Importe from Garantia g, Orden o, Auto a";
            sql = sql + " where g.CodOrden =o.CodOrden ";
            sql = sql + " and o.CodAuto = a.CodAuto";
            sql = sql + " and g.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and g.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente != null)
                sql = sql + " and a.Patente =" + "'" + Patente + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public double GetTotalSaldoGarantiaxFecha(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Importe = 0;
            string sql = "select sum(g.Saldo) as Importe from Garantia g, Orden o, Auto a";
            sql = sql + " where g.CodOrden =o.CodOrden ";
            sql = sql + " and o.CodAuto=a.CodAuto";
            sql = sql + " and g.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and g.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente !=null)
            {
                sql = sql + " and a.Patente =" + "'" + Patente + "'";
            }
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public double GetSaldoGarantiaxCodOrden(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = "select sum(Saldo) as Importe from Garantia";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public DataTable GetGarantiasAdeudadas(string Patente, string Apellido, DateTime Fecha, int ConDeuda,Int32? CodOrden)
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
                sql = sql + " from Garantia gar,Orden o, auto a,cliente cli";
                sql = sql + " where gar.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";               
                sql = sql + " and gar.Saldo>0";
                if (ListaCodAuto != "(")
                    sql = sql + " and o.CodAuto in " + ListaCodAuto.ToString();
                else
                    sql = sql + " and o.CodAuto=-1";
            }
            if (CodOrden != null)
            {
                sql = sql + " select *";
                sql = sql + " from Garantia gar,Orden o, auto a,cliente cli";
                sql = sql + " where gar.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and gar.Saldo>0";
                if (CodOrden !=-1)
                sql = sql + " and o.CodOrden =" + CodOrden.ToString();
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
                sql = sql + " from Garantia gar,Orden o, auto a,cliente cli";
                sql = sql + " where gar.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                
                sql = sql + " and gar.Saldo > 0";
                if (ListaCliente != "(")
                    sql = sql + " and o.CodCliente in " + ListaCliente.ToString();
                else
                    sql = sql + " and o.CodCliente=-1";
            }
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetImporteCobradoxCodOrden(Int32 CodOrden)
        {
            string sql = "select Importe from Garantia";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            sql = sql + " and FechaPago is not null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            Double Importe = 0;
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }
            return Importe;
        }

        public void BorrarGarantia(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "delete from Garantia where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
