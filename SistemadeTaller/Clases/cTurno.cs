using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cTurno
    {
        public void Insertar(string Apellido,string Nombre,string Patente,string Descripcion, DateTime Fecha,string Telefono,string Hora)
        {
            string sql = "Insert into Turno(Apellido,Nombre,Patente,Descripcion,Fecha,Telefono,Hora)";
            sql = sql + " Values(" + Texto(Apellido);
            sql = sql + "," + Texto(Nombre);
            sql = sql + "," + Texto(Patente);
            sql = sql + "," + Texto(Descripcion);
            sql = sql + "," + Texto(Fecha.ToShortDateString ());
            sql = sql + "," + Texto(Telefono);
            sql = sql + "," + Texto(Hora);
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public string Texto(string t)
        {
            string n = "'" + t + "'";
            return n;
        }

        public void Borrar(Int32 CodTurno)
        {
            string sql = "delete from Turno";
            sql = sql + " where CodTurno=" + CodTurno.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetTurnos (DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select * from Turno";
            sql = sql + " where Fecha>=" + Texto(FechaDesde.ToShortDateString());
            sql = sql + " and Fecha<=" + Texto(FechaHasta.ToShortDateString());
            sql = sql + " order by Fecha Desc";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
