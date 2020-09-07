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
    public partial class FrmListadoPresupuesto : Form
    {
        public FrmListadoPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmListadoPresupuesto_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cPresupuesto pre = new Clases.cPresupuesto();
            DataTable trdo = pre.GetPresupuestoxFecha(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;10;25;25;30;10");
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }
            frmPrincipal.CodigoPrincipal = Grilla.CurrentRow.Cells[0].Value.ToString ();
            FrmVerPresupuesto form = new FrmVerPresupuesto();
            form.Show();
        }
    }
}
