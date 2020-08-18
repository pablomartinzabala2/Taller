using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cTabla
    {
        public DataTable CrearTabla(string Lista)
        {
            DataTable Tabla = new DataTable();
            string[] Columnas = Lista.Split(';');
            foreach (string Col in Columnas)
            {
                Tabla.Columns.Add(Col);
            }
            return Tabla;
        }

        public DataTable AgregarFilas(DataTable Tabla, string Lista)
        {

            string[] Datos = Lista.Split(';');
            DataRow r;
            r = Tabla.NewRow();
            int i = 0;
            foreach (string Dato in Datos)
            {
                r[i] = Dato;
                i++;
            }
            Tabla.Rows.Add(r);
            return Tabla;
        }

        public DataTable EliminarFila(DataTable Trdo, string Columna, string Valor)
        {
            for (int i = 0; i < Trdo.Rows.Count; i++)
            {
                if (Trdo.Rows[i][Columna].ToString() == Valor)
                {
                    Trdo.Rows[i].Delete();
                    Trdo.AcceptChanges();
                    i = Trdo.Rows.Count;
                }
            }
            return Trdo;
        }

        public Boolean  Buscar(DataTable Trdo, string Columna, string Valor)
        {
            Boolean Encontro = false;
            for (int i = 0; i < Trdo.Rows.Count; i++)
            {
                if (Trdo.Rows[i][Columna].ToString() == Valor)
                {
                    Encontro = true;
                }
            }
            return Encontro;
        }

        public Boolean BuscarxDos(DataTable Trdo, string Columna1, string Valor1, string Columna2, string Valor2)
        {
            Boolean Encontro = false;
            for (int i = 0; i < Trdo.Rows.Count; i++)
            {
                if (Trdo.Rows[i][Columna1].ToString() == Valor1 && Trdo.Rows[i][Columna2].ToString() == Valor2)
                {
                    Encontro = true;
                }
            }
            return Encontro;
        }

        public Int32 MaxOrden(DataTable trdo, string Columna)
        {
            int max = 0;
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                if((Convert.ToInt32 (trdo.Rows[i][Columna]) >  max))
                    max = Convert.ToInt32 (trdo.Rows[i][Columna]);
            }
            max ++;
            return max;
        }

       
    }
}
