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
    public partial class FrmListadoTarjeta : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmListadoTarjeta()
        {
            InitializeComponent();
        }

        private void FrmListadoTarjeta_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
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
            string cupon = "";
            if (txtCupon.Text != "")
                cupon = txtCupon.Text;
            DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            Int32? CodOrden = null;
            if (txtNroOrden.Text != "")
                CodOrden = Convert.ToInt32(txtNroOrden.Text);
            int Impago = 0;
            if (chkSoloImpago.Checked == true)
                Impago = 1;
            cCobroTarjeta cobro = new cCobroTarjeta();
            DataTable trdo = cobro.GetCobroTarjetaxFecha(fechaDesde, fechaHasta, CodOrden, cupon, Impago);
            trdo = fun.TablaaMiles(trdo, "Saldo");
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[10].Visible = false;
            Grilla.Columns[1].Visible = false;
            Grilla.Columns[2].Visible = false;
            Grilla.Columns[3].Visible = false;
            Grilla.Columns[6].Width = 100;
            Grilla.Columns[7].Width = 100;
            Grilla.Columns[8].Width = 160;
            Grilla.Columns[6].HeaderText = "Cupón";
            Grilla.Columns[7].HeaderText = "Cobro";
            Grilla.Columns[11].HeaderText = "Tarjeta";
            txtTotal.Text = fun.TotalizarColumna(trdo, "Importe").ToString();
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

            string CodCobro = Grilla.CurrentRow.Cells[0].Value.ToString();
            FrmCobroTarjeta form = new FrmCobroTarjeta();
            frmPrincipal.CodigoPrincipal = CodCobro.ToString();
            form.ShowDialog();
        }

        private void txtNroOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }
    }
}
