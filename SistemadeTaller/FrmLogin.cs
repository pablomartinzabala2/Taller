using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemadeTaller
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnBuscarApe_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Ingresar Nombre de Usuario");
                return;
            }

            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Ingresar una Contraseña");
                return;
            }

            Clases.cUsuario USUARIO = new Clases.cUsuario();
            DataTable trdo = USUARIO.GetUsuario(txtUsuario.Text, txtContraseña.Text);
            if (trdo.Rows.Count > 0)
            {  
                Principal.CodUsuarioLogueado = Convert.ToInt32(trdo.Rows[0]["CodUsuario"].ToString());
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                frmPrincipal p = new frmPrincipal();
                
                p.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario incorrecto", "Información");
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           // prueba();
        }

        private void prueba()
        {
            string Nro = "1000,50";
            Nro = Nro.Replace(".", "");
            //int n = 0;
            double n = 0;
            if (Nro != "")
            {
                n = Convert.ToDouble (Nro);
                Nro = n.ToString("N0");
            }
        }
        
    }
}
