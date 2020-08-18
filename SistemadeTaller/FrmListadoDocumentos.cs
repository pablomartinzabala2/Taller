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
    public partial class FrmListadoDocumentos : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmListadoDocumentos()
        {
            InitializeComponent();
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
            Int32? CodOrden = null;
            if (txtNroOrden.Text != "")
                CodOrden = Convert.ToInt32(txtNroOrden.Text);
            DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            int SoloImpago = 0;
            if (chkSoloImpago.Checked)
                SoloImpago = 1;
            cDocumento doc = new cDocumento();
            DataTable trdo = doc.GetDocumentosxFecha(fechaDesde, fechaHasta, SoloImpago,CodOrden);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 70;
            Grilla.Columns[2].Width = 210;
            txtTotal.Text = fun.TotalizarColumna(trdo, "Saldo").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
        }

        private void FrmListadoDocumentos_Load(object sender, EventArgs e)
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

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro para continaur");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            frmPrincipal.CodigoPrincipal = Codigo;
            FrmCobroDocumentos form = new FrmCobroDocumentos();
            form.ShowDialog();
        }

        private void txtNroOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }


    }
}
