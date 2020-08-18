using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemadeTaller.Clases;
namespace SistemadeTaller
{
    public partial class FrmListadoGastosGenerales : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmListadoGastosGenerales()
        {
            InitializeComponent();
        }

        private void FrmListadoGastosGenerales_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
            DateTime fechahoy = DateTime.Now;
            txtFechaHasta.Text = fechahoy.ToShortDateString();
            fechahoy = fechahoy.AddMonths(-1);
            txtFechaDesde.Text = fechahoy.ToShortDateString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            Clases.cGastosNegocio gasto = new Clases.cGastosNegocio();
            DataTable trdo = gasto.GetGastosNegocioxFecha(FechaDesde, FechaHasta, txtDescripcion.Text);
            trdo = fun.TablaaMiles(trdo, "Importe");
            txtTotal.Text = fun.TotalizarColumna(trdo, "Importe").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].Width = 520;
        }

        private void btnRegistrarGasto_Click(object sender, EventArgs e)
        {
            FrmRegistrarGastosGenerales frm = new FrmRegistrarGastosGenerales();
            frm.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje()); 
                return;
            }
            cGastosNegocio obj = new cGastosNegocio();
            Int32 CodGasto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            obj.BorrarGasto(CodGasto);
            DateTime Fecha = DateTime.Now;
            double Importe = fun.ToDouble(Grilla.CurrentRow.Cells[4].Value.ToString());
            string Descripcion ="ANULACION " + Grilla.CurrentRow.Cells[2].Value.ToString();
            //Int32 CodGasto = Convert.ToInt32 (Grilla.CurrentRow.Cells[0].Value.ToString ());
            Clases.cMovimiento mov = new Clases.cMovimiento();
            mov.GrabarMovimiento(Importe, Descripcion, Fecha, 1, null);
            MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
            Buscar();
        }
    }
}
