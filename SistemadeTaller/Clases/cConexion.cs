using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SistemadeTaller.Clases
{
    public static  class cConexion
    {
        public static  string Cadenacon()
        {
            //taller 2.0 DESKTOP-BI5616B\SQLEXPRESS
            string cadena = "Data Source=DESKTOP-BI5616B\\SQLEXPRESS;Initial Catalog=TALLER;Integrated Security=True";
            //copiataller
          //   string cadena = "Data Source=DESKTOP-QKECIIE;Initial Catalog=copiataller;Integrated Security=True";
            //    string cadena = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=TALLER;Integrated Security=True";
            //     string cadena = "Data Source=DESKTOP-QKECIIE;Initial Catalog=TALLER;Integrated Security=True";
            //taller
        //    string cadena = "Data Source=AGENCIA2\\SQLEXPRESS;Initial Catalog=TALLER;Integrated Security=True";
            return cadena ;
        }
    }
}
