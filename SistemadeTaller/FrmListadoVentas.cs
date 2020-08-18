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
    public partial class FrmListadoVentas : Form
    {
        public FrmListadoVentas()
        {
            InitializeComponent();
        }

        private void FrmListadoVentas_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void Buscar()
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cFunciones fun = new cFunciones();
            cVenta venta = new cVenta();
            DataTable trdo = venta.GetVentas(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].Width = 170;
            Grilla.Columns[3].Width = 180;
            txtTotal.Text = fun.TotalizarColumna(trdo, "Total").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            Principal.CodigoPrincipalAbm = null;
            FrmVenta frm = new FrmVenta();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show ("Debe seleccionar un registro");
                return ;
            }
            string CodVenta = Grilla.CurrentRow.Cells[0].Value.ToString ();
            Principal.CodigoPrincipalAbm = CodVenta;
            FrmVenta frm = new FrmVenta ();
            frm.Show ();
        }
    }
}
