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
    public partial class FrmListadoCompras : Form
    {
        cFunciones fun;
        public FrmListadoCompras()
        {
            InitializeComponent();
        }

        private void FrmListadoCompras_Load(object sender, EventArgs e)
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
            string Insumo = txtInsumo.Text;
            cCompra compra = new cCompra();
            DataTable trdo = compra.GetDetalleCompraxFecha(fechaDesde, fechaHasta, Insumo);
            trdo = fun.TablaaMiles(trdo, "Precio");
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].HeaderText = "Proveedor";
            Grilla.Columns[1].HeaderText = "Teléfono";
            Grilla.Columns[2].HeaderText = "Factura";
            Grilla.Columns[4].HeaderText = "Cantidad";
            Grilla.Columns[0].Width = 200;
            Grilla.Columns[3].Width = 180;
            double Total = fun.TotalizarColumna(trdo, "Total");
            txtTotal.Text = Total.ToString();
            txtTotal.Text = fun.SepararDecimales(txtTotal.Text);
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
        }
        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }
    }
}
