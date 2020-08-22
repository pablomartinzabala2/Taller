using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace SistemadeTaller
{
    public partial class FrmEnviarMensaje : Form
    {
        public FrmEnviarMensaje()
        {
            InitializeComponent();
        }

        private void FrmEnviarMensaje_Load(object sender, EventArgs e)
        {

           
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            String Id = "jEmcGywFJ0+fSbTg6o73bHBhYmxvbWFydGluemFiYWxhMl9hdF9nbWFpbF9kb3RfY29t";
            string MiCel = "+5493513903881";
           // string MiCel = "+543515514974";
            string Mensaje = "Hola Elsa Leotta";
            try
            {
                string url = "https://Niceapi.Net/API";
                HttpWebRequest reques = (HttpWebRequest)WebRequest.Create(url);
                reques.Method = "POST";
                reques.ContentType = "application/x-www-form-urlencoded";
                reques.Headers.Add("X-APIId", Id);
          
                reques.Headers.Add("X-APIMobile", MiCel);
                using (StreamWriter st = new StreamWriter(reques.GetRequestStream()))
                {
                    st.Write(Mensaje);
                }

                using (StreamReader stSalida = new StreamReader(reques.GetResponse().GetResponseStream()))
                {
                    Console.WriteLine(stSalida.ReadToEnd());
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
