using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SistemadeTaller.Clases
{
    public  class cCliente
    {
        public Int32 InsertarClienteTran(SqlConnection con, SqlTransaction Transaccion, string Apellido, string Nombre, string Direccion, string Telefono, Int32? CodTipoDoc,string NroDocumento,string DireccionCli)
        {
            string sql = "Insert into Cliente";
            sql = sql + "(Nombre,Apellido,Telefono,Calle,CodTipoDoc,NroDocumento,Direccion)";
            sql = sql + " values (";
            sql = sql + "'" + Nombre  +"'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + DireccionCli + "'";
            if (CodTipoDoc != null)
                sql = sql + "," + CodTipoDoc.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + DireccionCli + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);           
        }

        public void ModificarClienteTran(SqlConnection con, SqlTransaction Transaccion,string CodCliente, string Apellido, string Nombre, string Direccion, string Telefono,Int32? CodTipoDoc,string NroDoc,string DireccionCli)
        {
            string sql = "Update Cliente Set ";            
            sql = sql + "nombre ='" + Nombre + "'";
            sql = sql + ",apellido =" + "'" + Apellido + "'";
            sql = sql + ",telefono =" + "'" + Telefono + "'";
            sql = sql + ",calle=" + "'" + Direccion + "' ";
            /*
            if (CodTipoDoc != null)
                sql = sql + ",CodTipoDoc =" + CodTipoDoc.ToString();
            else
                sql = sql + ",CodTipoDoc=null";
                */
            sql = sql + ",NroDocumento =" + "'" + NroDoc + "'";
            sql = sql + ",Direccion=" + "'" + Direccion + "'";
            sql = sql + "WHERE CodCliente = '" + CodCliente + "'";

             cDb.EjecutarNonQueryTransaccion (con, Transaccion, sql);
        }

        public DataTable GetCliente(string NroDocumento,string TipoDocumento)
        {
            string sql = "select * from Cliente cli where cli.NroDocumento =" + "'" + NroDocumento + "' AND cli.CodTipoDoc =" + "'" + TipoDocumento + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 GetSiguienteId(SqlConnection con, SqlTransaction Transaccion)
        {
            string sql = "select SCOPE_IDENTITY()";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public DataTable GetClientexApellido(string Ape)
        {
            string sql = "select * from Cliente where Apellido like " + "'%" + Ape + "%'";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetClientexNroDoc(string NroDoc)
        {
            string sql = "select * from cliente";
            sql = sql + " where NroDocumento=" + "'" + NroDoc + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetClientexCodigo(Int32 CodCliente)
        {
            string sql = "select * from Cliente c";
            sql = sql + " where c.CodCliente=" + CodCliente.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
