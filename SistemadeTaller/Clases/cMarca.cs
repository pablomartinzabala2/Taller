using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public class cMarca
    {
        public string GetMarcaxCodigo(Int32 CodMarca)
        {
            string sql = "select nombre from Marca";
            string Marca ="";
            sql = sql + " where CodMarca=" + CodMarca.ToString ();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Nombre"].ToString() != "")
                    Marca = trdo.Rows[0]["Nombre"].ToString();
            return Marca;
        }
    }
}
