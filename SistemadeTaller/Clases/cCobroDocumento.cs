using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cCobroDocumento
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,Int32 CodDocumento,DateTime Fecha,double Importe)
        {
            string sql = "insert into CobroDocumento(CodDocumento,Fecha,Importe)";
            sql = sql + "values(" + CodDocumento.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ActualizarSaldo(SqlConnection con, SqlTransaction Transaccion,Int32 CodDocumento,double Importe,DateTime Fecha)
        {
            string sql = "update Documento";
            sql = sql + " set Saldo = Saldo -" + Importe.ToString().Replace (",",".");
            //sql = sql + ", Fecha =" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " where CodDocumento =" + CodDocumento.ToString ();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetCobrosxCodDocumento(Int32 CodDocumento)
        {
            string sql = "select * from CobroDocumento";
            sql = sql + " where CodDocumento=" + CodDocumento.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarCobroDocumento(SqlConnection con, SqlTransaction Transaccion,Int32 CodCobro)
        {
            string sql = "delete from CobroDocumento where CodCobro =" + CodCobro.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Double  GetTotalDocumentoCobrado(Int32 CodOrden)
        {
            Double Importe = 0;
            string sql = "select isnull(sum(c.Importe),0) as Importe from Documento d,CobroDocumento c";
            sql = sql + " where d.CodDocumento=c.CodDocumento";
            sql = sql + " and d.CodOrden=" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Importe"].ToString ()!="")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }

            return Importe;
        }

        public void BorrarCobroDocumentoxCodDocumento(SqlConnection con, SqlTransaction Transaccion, Int32 CodDocumento)
        {
            string sql = "delete from CobroDocumento where CodDocumento =" + CodDocumento.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Int32  GetCodDocumentoxCodOrden(Int32 CodOrden)
        {
            Int32 CodDocumento = 0;
            string sql = "select * from Documento ";
            sql = sql + " where CodOrden=" + CodOrden.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodDocumento"].ToString ()!="")
                {
                    CodDocumento = Convert.ToInt32(trdo.Rows[0]["CodDocumento"].ToString());
                }
            }
            return CodDocumento;
        }

    }

    
}
