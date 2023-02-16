using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data ;
namespace SistemadeTaller.Clases
{
    public class cAuto
    {
        public Int32 InsertarAutoTran(SqlConnection con, SqlTransaction Transaccion, Int32 CodMarca, string Descripcion, string anio, double? PrecioVenta, string patente, string codCliente, string Chasis, string Motor, string Kilometros,Int32? CodTipoCombustible)
        {
            string sql = "Insert into Auto";
            sql = sql + "(Descripcion,CodMarca,Anio,Patente,CodCliente,Chasis,Motor,Kilometros,CodTipoCombustible)";
            sql = sql + " values(";
            sql = sql  + "'"+ Descripcion + "'";
            sql = sql + ",'" + CodMarca.ToString() + "'";
            sql = sql + "," + "'" + anio  + "'";            
            sql = sql + ",'" + patente + "'";
            sql = sql + ",'" + codCliente + "'";
            sql = sql + "," + "'" + Chasis + "'";
            sql = sql + "," + "'" + Motor + "'";
            sql = sql + "," + "'" + Kilometros + "'";
            if (CodTipoCombustible != null)
                sql = sql + "," + CodTipoCombustible.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            

            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ModificarAutoTran(SqlConnection con, SqlTransaction Transaccion,string CodAuto, string CodMarca, string Descripcion, string patente, Int32? Kilometros,Int32? CodTipoCombustible)
        {
            string sql = "Update Auto Set ";
            sql = sql + "codMarca ='" + CodMarca + "'";
            sql = sql + ",";
            sql = sql + "Descripcion ='" + Descripcion + "'";
            sql = sql + ",";
            sql = sql + "Patente ='" + patente + "' ";
            if (Kilometros != null)
                sql = sql + ",Kilometros =" + Kilometros.ToString();
            else
                sql = sql + ",Kilometros =null";
            if (CodTipoCombustible != null)
                sql = sql + ",CodTipoCombustible=" + CodTipoCombustible.ToString();
            else
                sql = sql + ",CodTipoCombustible=null";
            sql = sql + " WHERE CodAuto ='" + CodAuto + "'";
             cDb.EjecutarNonQueryTransaccion  (con, Transaccion, sql);
        }

        public DataTable GetAutoxPatente(string Patente)
        {
            string sql = "select a.*, ";
            sql = sql + " (select c.NroDocumento from cliente c where c.CodCliente = a.CodCliente ) as NroDoc ";
            sql = sql + " from Auto a ";
            sql = sql + " where a.Patente =" + "'" + Patente + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 GetSiguienteId(SqlConnection con, SqlTransaction Transaccion)
        {
            string sql = "select SCOPE_IDENTITY()";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public DataTable GetAutoxContenidoPatente(string Patente)
        {
            string sql = "select a.* from auto a";
            sql = sql + " where patente like " + "'%" + Patente + "%'";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActuaizarTitularAuto(SqlConnection con, SqlTransaction Transaccion, Int32 CodAuto, Int32 COdCliente)
        {
            string sql = "update auto set CodCliente=" + COdCliente.ToString();
            sql = sql + " where CodAuto =" + CodAuto.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }

    
}
