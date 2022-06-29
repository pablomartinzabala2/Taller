using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemadeTaller.Clases;
namespace SistemadeTaller
{
    public partial class FrmHerramienta : Form
    {
        public FrmHerramienta()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar ()==false)
            {
                return;
            }
            string Nombre = txtNombre.Text;
            Double Importe = Convert.ToDouble(txtImporte.Text);
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            cHerramienta herramienta = new cHerramienta();
            cMovimiento mov = new cMovimiento();
            string Descripcion = " Compra de " + Nombre.ToString();

            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction tran = null;
            try
            {
                tran = con.BeginTransaction();
                herramienta.Insertar(con, tran, Nombre, Fecha, Importe);
                mov.GrabarMovimientoTransaccion(con, tran, Importe, Descripcion, Fecha, Principal.CodUsuarioLogueado, null);
                tran.Commit();
                con.Close();
                MessageBox.Show("Datosgrabados correctamente", "Sistema");
            }
            catch (Exception)
            {
                tran.Rollback();
                con.Close();
                MessageBox.Show("Hubo un error en el proceso de grabación", "Sistema");
            }
           
        }

        private void FrmHerramienta_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }

        private bool Validar ()
        {
            cFunciones fun = new Clases.cFunciones();
            if (txtNombre.Text =="")
            {
                MessageBox.Show("Ingresar un nombre", "Sistema");
                return false;
            }

            if (txtImporte.Text =="")
            {
                MessageBox.Show("Ingresar un importe", "Sistema");
                return false;
            }

            if (fun.ValidarFecha (txtFecha.Text)==false)
            {
                MessageBox.Show("La fecha ingresada es incorrecta", "Sistema");
                return false;
            }

            return true;

        }
    }
}
