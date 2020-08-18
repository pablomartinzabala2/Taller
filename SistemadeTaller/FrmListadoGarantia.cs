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
    public partial class FrmListadoGarantia : Form
    {
        cFunciones fun;
        public FrmListadoGarantia()
        {
            InitializeComponent();
        }

        private void FrmListadoGarantia_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            DateTime fecha = DateTime.Now;
            txtFechaHasta.Text = fecha.ToShortDateString();
            fecha = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha.ToShortDateString();
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
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
            cGarantia gar = new cGarantia();
            DataTable trdo = gar.GetGarantiasxFecha(fechaDesde, fechaHasta,txtPatente.Text);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].HeaderText = "Orden";
            Grilla.Columns[5].Width = 150;
            Grilla.Columns[6].Width = 160;
            txtTotal.Text = fun.TotalizarColumna(trdo, "Saldo").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            frmPrincipal.CodigoPrincipal = Grilla.CurrentRow.Cells[0].Value.ToString();
            FrmPagoGarantia frm = new FrmPagoGarantia();
            frm.ShowDialog();
        }
    }
}
