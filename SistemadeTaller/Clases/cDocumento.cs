using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SistemadeTaller.Clases
{
    public  class cDocumento
    {
        public void InsertarDocumentoTransaccion(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,double Importe,Int32? CodOrden, Int32? CodCliente, Int32? CodVenta)
        {
            string sql = "insert into Documento(Fecha,Importe,Saldo,CodOrden,CodCliente,CodVenta)";
            sql = sql + "values (";
            sql = sql + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            if (CodOrden == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodOrden.ToString();
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

        public double GetTotalDocumentos()
        {
            double Importe = 0;
            string sql = "select sum(isnull(Saldo,0)) as Importe";
            sql = sql + " from Documento";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString ()!="")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Importe;
        }
        
        public DataTable GetDocumentoxCodigo(Int32 CodDocumento)
        {
            string sql = "select d.CodDocumento,c.Nombre,c.Apellido";
            sql = sql + ",d.Fecha,d.Importe,d.Saldo,d.CodOrden";
            sql = sql + ",( select au.Patente from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = d.CodOrden) as Patente";
            sql = sql + ",( select au.Descripcion from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = d.CodOrden) as Descripcion";
            sql = sql + " from Documento d,Cliente c";
           // sql = sql + " where d.CodOrden = o.CodOrden";
            sql = sql + " where d.CodCliente = c.CodCliente";
          //  sql = sql + " and au.CodAuto = o.CodAuto";
            sql = sql + " and d.CodDocumento =" + CodDocumento.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void AnularCobro(SqlConnection con, SqlTransaction Transaccion,Int32 CodDocumento,double ImporteAnular)
        {
            string sql = "update documento set Saldo = Saldo +" + ImporteAnular.ToString ().Replace (",",".");
            sql = sql + " where CodDocumento =" + CodDocumento.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public double GetTotalxCodOrden(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = "select isnull(sum(Importe),0) as Importe from Documento ";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());

            }
            return Importe;
        }

        public double GetTotalDocumento(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Importe) as ImporteDocumento from Documento";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteDocumento"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteDocumento"].ToString());
            return Importe;
        }

        public double GetTotalSaldoDocumento(DateTime FechaDesde, DateTime FechaHasta)
        {
            double Importe = 0;
            string sql = "select sum(Saldo) as ImporteDocumento from Documento";
            sql = sql + " where Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteDocumento"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["ImporteDocumento"].ToString());
            return Importe;
        }

        public DataTable GetDocumentoxCodOrden(Int32 CodOrden)
        {
            string sql = "select * from Documento where CodOrden=" + CodOrden.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public double GetSaldoDocumentoxCodOrden(Int32 CodOrden)
        {
            double Importe = 0;
            string sql = "select sum(Saldo) as Importe from Documento";
            sql = sql + " where CodOrden =" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public DataTable GetDocumentosAdeudados(string Patente, string Apellido, DateTime Fecha, int ConDeuda,Int32? CodOrden)
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
                sql = sql + " from Documento doc ,Orden o, auto a,cliente cli";
                sql = sql + " where doc.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and doc.Saldo>0";
                if (ListaCodAuto != "(")
                    sql = sql + " and o.CodAuto in " + ListaCodAuto.ToString();
                else
                    sql = sql + " and o.CodAuto=-1";
            }

            if (CodOrden != null)
            {
                sql = sql + " select *";
                sql = sql + " from Documento doc ,Orden o, auto a,cliente cli";
                sql = sql + " where doc.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and doc.Saldo>0";
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
                sql = sql + " from Documento doc,Orden o, auto a,cliente cli";
                sql = sql + " where doc.CodOrden = o.CodOrden ";
                sql = sql + " and o.CodAuto = a.CodAuto";
                sql = sql + " and o.CodCliente = cli.CodCliente";
                sql = sql + " and doc.Saldo > 0";
                if (ListaCliente != "(")
                    sql = sql + " and o.CodCliente in " + ListaCliente.ToString();
                else
                    sql = sql + " and o.CodCliente=-1";
            }
            return cDb.ExecuteDataTable(sql);
        }
        /*
        public DataTable GetDocumentosxFecha(DateTime FeChaDesde, DateTime FechaHasta, int SoloImpago, Int32? CodOrden)
        {
            string sql = "select d.CodDocumento,o.CodOrden as Orden,a.Patente,a.Descripcion as Descripción,c.Apellido";
            sql = sql + ",d.Fecha,d.Importe,d.Saldo";
            sql = sql + " from Documento d,Cliente c,Orden o,auto a";
            sql = sql + " where d.CodOrden = o.CodOrden";
            sql = sql + " and o.CodCliente = c.CodCliente";
            sql = sql + " and o.CodAuto = a.CodAuto";
            if (CodOrden != null)
                sql = sql + " and o.CodOrden=" + CodOrden.ToString();
            sql = sql + " and d.Fecha >=" + "'" + FeChaDesde.ToShortDateString() + "'";
            sql = sql + " and d.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (SoloImpago == 1)
                sql = sql + " and Saldo >0";
            sql = sql + " order by o.CodOrden desc";
            return cDb.ExecuteDataTable(sql);
        }
         * */

        public DataTable GetDocumentosxFecha(DateTime FeChaDesde, DateTime FechaHasta, int SoloImpago, Int32? CodOrden)
        {
            string sql = "select d.CodDocumento,d.CodOrden as Orden";
             sql = sql + ",( select au.Patente from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = d.CodOrden) as Patente";
            sql = sql + ",( select au.Descripcion from auto au,orden ord ";
            sql = sql + " where au.CodAuto = ord.CodAuto and ord.CodOrden = d.CodOrden) as Descripcion";
            sql = sql + ",c.Apellido";
            sql = sql + ",d.Fecha,d.Importe,d.Saldo";
            sql = sql + " from Documento d,Cliente c";
            sql = sql + " where d.CodCliente = c.CodCliente";
            
            if (CodOrden != null)
                sql = sql + " and d.CodOrden=" + CodOrden.ToString();
            sql = sql + " and d.Fecha >=" + "'" + FeChaDesde.ToShortDateString() + "'";
            sql = sql + " and d.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (SoloImpago == 1)
                sql = sql + " and Saldo >0";
            sql = sql + " order by d.CodOrden desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDocumentoxCodVenta(Int32 CodVenta)
        {
            string sql = "select * from Documento ";
            sql = sql + " where CodVenta=" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarDocumentoxCodOrden(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            string sql = "delete from Documento where CodOrden=" + CodOrden.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
