using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public class cCheque
    {
        public void InsertarCheque(SqlConnection con, SqlTransaction Transaccion,string NroCheque,double Importe,Int32? CodOrden,DateTime Fecha,DateTime FechaVto,Int32? CodCliente,Int32? CodVenta)
        {
            string sql = "insert into Cheque(NroCheque,Importe,Saldo,CodOrden,Fecha,FechaVto,CodCliente,CodVenta)";
            sql = sql + "Values(" + "'" + NroCheque +"'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            if (CodOrden == null) 
                sql = sql + ",null";
            else
                sql = sql + "," + CodOrden.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + FechaVto.ToShortDateString() + "'";
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            if (CodVenta != null)
                sql = sql + "," + CodVenta.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalCheque()
        {
            double Importe = 0;
            string sql = "select sum(isnull(Saldo,0)) as Importe";
            sql = sql + " from Cheque";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }

        public DataTable GetChequesxFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select * from Cheque ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString () + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetChequexCodigo(Int32 CodCheque)
        {
            string sql = "select * from Cheque where CodCheque=" + CodCheque.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void CobroCheque(SqlConnection con, SqlTransaction Transaccion,Int32 CodCheque, double Importe)
        {
            string sql = "update Cheque set Saldo = Saldo -" + Importe.ToString ().Replace (",",".");
            sql = sql + " where CodCheque =" + CodCheque.ToString (); ;
            cDb.EjecutarNonQueryTransaccion (con,Transaccion ,sql);
        }

        public void AnularPagoCheque(SqlConnection con, SqlTransaction Transaccion,Int32 CodCheque)
        {
            string sql = "Update Cheque set Saldo = Importe";
            sql = sql + " where CodCheque =" + CodCheque.ToString ();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetChequesxCodOrden(Int32 CodOrden)
        {
            string sql = "Select * from Cheque where CodOrden =" + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable  GetChequexNroCheque(string NroCheque)
        {
            string sql ="select * from Cheque where NroCheque=" + "'" + NroCheque + "'";
            return cDb.ExecuteDataTable (sql);
        }

    
        public double GetTotalChequexFecha(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        {
            double Importe = 0;
            string sql = "select sum(c.Importe) as Importe from Cheque c,Orden o, auto a";
            sql = sql + " where c.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and c.CodOrden = o.CodOrden ";
            sql = sql + " and o.CodAuto = a.CodAuto ";
            sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " and c.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
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

        public double GetTotalSaldoChequexFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Saldo) as Importe from Cheque";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public double GetSaldoChequexCodOrden(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = "select sum(Saldo) as Importe from Cheque";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public DataTable GetChequesAdeudados(string Patente, string Apellido, DateTime Fecha, int ConDeuda,Int32? CodOrden)
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
                sql = sql + " from Cheque c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                if (ConDeuda == 1)
                    sql = sql + " and c.FechaVto <" + "'" + Fecha.ToShortDateString() + "'";
                sql = sql + " and c.Saldo>0";
                if (ListaCodAuto != "(")
                    sql = sql + " and o.CodAuto in " + ListaCodAuto.ToString();
                else
                    sql = sql + " and o.CodAuto=-1";
            }
            if (CodOrden != null)
            {
                sql = sql + " select *";
                sql = sql + " from Cheque c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                if (ConDeuda == 1)
                    sql = sql + " and c.FechaVto <" + "'" + Fecha.ToShortDateString() + "'";
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
                sql = sql + " from Cheque c,Orden o, auto a,cliente cli";
                sql = sql + " where c.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                if (ConDeuda == 1)
                    sql = sql + " and c.FechaVto <" + "'" + Fecha.ToShortDateString() + "'";
                sql = sql + " and c.Saldo > 0";
                if (ListaCliente != "(")
                    sql = sql + " and o.CodCliente in " + ListaCliente.ToString();
                else
                    sql = sql + " and o.CodCliente=-1";
            }
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetChequexCodVenta(Int32 CodVenta)
        {
            string sql = "select * from cheque ";
            sql = sql + " where CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable  GetChquesxCodOrden(Int32 CodOrden)
        {
            string sql = "select * from Cheque ";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            return trdo;
        }

        public void BorrarchquexCodOrden(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "delete from Cheque where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
