using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemadeTaller.Clases;
using System.Data.SqlClient;
namespace SistemadeTaller
{
    public partial class FrmRegistrarVale : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmRegistrarVale()
        {
            InitializeComponent();
        }

        private void FrmRegistrarVale_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
            txtFecha.Text = DateTime.Now.ToShortDateString();
            if (frmPrincipal.CodVale !=null)
            {
                BuscarVale(Convert.ToInt32(frmPrincipal.CodVale));
            }
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text == "")
            {
                Mensaje("Debe ingresar un monto para continuar");
                return;
            }

            if (txtApellido.Text == "")
            {
                Mensaje("Debe ingresar un apellido ");
                return;
            }

            if (txtNombre.Text == "")
            {
                Mensaje("Debe ingresar un nombre ");
                return;
            }

            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }

            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            double Importe = fun.ToDouble(txtMonto.Text);
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Descripcion = txtDescripcion.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            string Descrip ="";
            cVale vale = new cVale();
            cMovimiento mov = new cMovimiento();
            try
            {
                vale.Registrar(con, Transaccion, Fecha, Importe, Nombre, Apellido, Descripcion);
                Descrip = "ADELANTO DE DINERO " + txtNombre.Text + " " + txtApellido.Text;
                mov.GrabarMovimientoTransaccion(con, Transaccion,-1* Importe, Descrip, Fecha, 1, null);
                Mensaje("Datos grabados correctamente");
                Transaccion.Commit();
                con.Close();
                Limpiar();
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabación");
            }

        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDescripcion.Text = "";
            txtMonto.Text = "";
        }

        private void BuscarVale(Int32 CodVale)
        {
            cFunciones fun = new cFunciones();
            cVale vale = new cVale();
            DataTable trdo = vale.GetValexCodigo(CodVale);
            if (trdo.Rows.Count >0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtDescripcion.Text = trdo.Rows[0]["Descripcion"].ToString();
                DateTime Fecha = Convert.ToDateTime(trdo.Rows[0]["Fecha"].ToString());
                txtFecha.Text = Fecha.ToShortDateString();
                txtMonto.Text = trdo.Rows[0]["Importe"].ToString();
                if (txtMonto.Text !="")
                {
                    txtMonto.Text = fun.SepararDecimales(txtMonto.Text);
                    txtMonto.Text = fun.FormatoEnteroMiles(txtMonto.Text);
                }
            }
            btnGuardar.Visible = false;
        }


    }
}
