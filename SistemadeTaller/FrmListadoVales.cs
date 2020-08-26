using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using SistemadeTaller.Clases;
using System.Data.SqlClient;
namespace SistemadeTaller
{
    public partial class FrmListadoVales : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmListadoVales()
        {
            InitializeComponent();
        }

        private void FrmListadoVales_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
            DateTime fecha = DateTime.Now;
            txtFechaHasta.Text = fecha.ToShortDateString();
            fecha = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha.ToShortDateString();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (fun.ValidarFecha(txtFechaDesde.Text) == false)
            {
                Mensaje("La fecha desde es incorrecta");
                return;
            }

            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                Mensaje("La fecha hasta es incorrecta");
                return;
            }

            DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cVale vale = new cVale();
            DataTable trdo = vale.GetValesxFecha(fechaDesde, fechaHasta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 140;
            Grilla.Columns[2].Width = 140;
            Grilla.Columns[6].Width = 100;
            Grilla.Columns[7].Width = 250;
            Grilla.Columns[6].HeaderText = "Devolución";
            Grilla.Columns[2].Visible = false; 
            txtTotal.Text = fun.TotalizarColumna(trdo, "Saldo").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPrincipal.CodVale = null;
            FrmRegistrarVale frm = new FrmRegistrarVale();
            frm.ShowDialog();
        }

        private void btnReintegrar_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFechaRintegro.Text) == false)
            {
                Mensaje("La fecha de reintegro es incorrecta");
                return;
            }

            double Saldo = fun.ToDouble(Grilla.CurrentRow.Cells[5].Value.ToString());
            if (Saldo == 0)
            {
                Mensaje("Ya se ha reintegrado el movimiento");
                return;
            }
            double Importe = fun.ToDouble(Grilla.CurrentRow.Cells[3].Value.ToString());
            DateTime Fecha = Convert.ToDateTime (txtFechaRintegro.Text); 
            Int32 CodVale =Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            string Nombre = Grilla.CurrentRow.Cells[1].Value.ToString();
            string Apellido = Grilla.CurrentRow.Cells[2].Value.ToString();
            string Descripcion = "";
            cVale objVale = new cVale();
            cMovimiento mov = new cMovimiento();
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            try
            {
                objVale.GrabarDevolucion(con, Transaccion, CodVale, Fecha);
                Descripcion = "REINTEGRO VALE " + Nombre + " " + Apellido;
                mov.GrabarMovimientoTransaccion(con, Transaccion, Importe, Descripcion, Fecha, 1, null);
                Mensaje("Datos grabados correctamente");
                Transaccion.Commit();
                con.Close();
                Buscar();
            }
            catch (Exception ex)
            {
                Mensaje("Hubo un error en el proceso de grabación");
                Transaccion.Rollback();
                con.Close();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elemeto");
                return;
            }
            frmPrincipal.CodVale = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            FrmRegistrarVale frm = new FrmRegistrarVale();
            frm.ShowDialog();
        }
    }
}
