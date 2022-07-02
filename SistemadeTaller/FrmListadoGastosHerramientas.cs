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
    public partial class FrmListadoGastosHerramientas : Form
    {
        public FrmListadoGastosHerramientas()
        {
            InitializeComponent();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            cHerramienta her = new cHerramienta();
            cFunciones fun = new cFunciones();
            if (fun.ValidarFecha (txtFechaDesde.Text)==false)
            {
                MessageBox.Show("La fecha desde es incorrecta");
                return;
            }
             
            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                MessageBox.Show("La fecha hasta es incorrecta");
                return;
            }
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string NOmbre = txtNombre.Text;
            Buscar(FechaDesde, FechaHasta, NOmbre);
            
        }

        private void FrmListadoGastosHerramientas_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            txtFechaHasta.Text = fecha.ToShortDateString();
            fecha = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha.ToShortDateString();
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            Int32 CodUsuario = Principal.CodUsuarioLogueado;
            cUsuario usu = new Clases.cUsuario();
            string Nombre = usu.GetNombreUsuarioxCodUsuario(CodUsuario);
            if (Nombre.ToUpper() == "SERGIO")
            {
                btnAnular.Visible = true;
            }
            else
            {
                btnAnular.Visible = false;
            }
        }

        private void Buscar(DateTime FechaDesde, DateTime FechaHasta, string Nombre)
        {
            cHerramienta her = new Clases.cHerramienta();
            cFunciones fun = new Clases.cFunciones();
            DataTable trdo = her.GetHerramientas(FechaDesde, FechaHasta, Nombre);
            Double  Total = fun.TotalizarColumna(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaFechas(trdo, "Fecha");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;20;50;30");
            txtTotal.Text = fun.FormatoEnteroMiles(Total.ToString());
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento", "Sistema");
                return;
            }
            string msj = "Confirma Eliminar la orden ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            DateTime Fecha = DateTime.Now;
            Int32 CodHerramienta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            cHerramienta herramienta = new cHerramienta();
            cMovimiento mov = new cMovimiento();
            Double Importe = 0;
            Importe = herramienta.GetTotalxCodHerramienta(CodHerramienta);
            string Nombre = herramienta.GetNombre(CodHerramienta);
            string Descripcion = "";
            Descripcion = "Anulación de Compra " + Nombre;
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction tran = null;
            try
            {
                tran = con.BeginTransaction();
                herramienta.Eliminar(con ,tran, CodHerramienta);
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

            Nombre = txtNombre.Text;
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string NOmbre = txtNombre.Text;
            Buscar(FechaDesde, FechaHasta, NOmbre);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmHerramienta frm = new FrmHerramienta();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.Show();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string NOmbre = txtNombre.Text;
            Buscar(FechaDesde, FechaHasta, NOmbre);
        }
    }
}
