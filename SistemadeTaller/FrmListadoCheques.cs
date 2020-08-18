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
    public partial class FrmListadoCheques : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmListadoCheques()
        {
            InitializeComponent();
        }

        private void FrmListadoCheques_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            DateTime fecha = DateTime.Now;
            txtFechaHasta.Text = fecha.ToShortDateString();
            fecha = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha.ToShortDateString();
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
            cCheque Cheque = new cCheque();
            DataTable trdo = Cheque.GetChequesxFecha(fechaDesde, fechaHasta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Grilla.Columns[1].HeaderText = "Nro Cheque";
            Grilla.Columns[6].HeaderText = "Fecha Vto";
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[4].Visible = false;
            Grilla.Columns[1].Width = 160;
            Grilla.Columns[2].Width = 150;
            Grilla.Columns[3].Width = 150;
            Grilla.Columns[5].Width = 150;
            Grilla.Columns[7].Visible = false;
            txtTotal.Text = fun.TotalizarColumna(trdo, "Saldo").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodCheque = Grilla.CurrentRow.Cells[0].Value.ToString();
            frmPrincipal.CodigoPrincipal = CodCheque;
            FrmCobroCheque cob = new FrmCobroCheque();
            cob.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
