using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data ;
namespace SistemadeTaller.Clases
{
    public class cCobroCheque
    {
        public void RegistrarPago(SqlConnection con, SqlTransaction Transaccion,Int32 CodCheque,double Importe,DateTime Fecha)
        {
            string sql = "insert into CobroCheque(CodCheque,Importe,Fecha)";
            sql = sql + " Values(" + CodCheque.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetCobroChequexCodCheque(Int32 CodCheque)
        {
            string sql = "select * from CobroCheque";
            sql = sql + " where CodCheque =" + CodCheque.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarCobroCheque(SqlConnection con, SqlTransaction Transaccion,Int32 CodCheque)
        {
            string sql = "Delete from CobroCheque where CodCheque=" + CodCheque.ToString ();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Double GetTotalChequeCobrado(Int32 CodOrden)
        {
            Double Importe = 0;
            string sql = "select isnull(sum(ch.Importe),0) as Importe";
            sql = sql + " from cheque c,cobrocheque  ch";
            sql = sql + " where c.CodCheque=ch.CodCheque";
            sql = sql + " and c.CodOrden=" + CodOrden.ToString();
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

      

    }
}
