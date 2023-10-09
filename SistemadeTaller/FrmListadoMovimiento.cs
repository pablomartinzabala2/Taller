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
    public partial class FrmListadoMovimiento : Form 
    {
        
        public FrmListadoMovimiento()
        {
            InitializeComponent();
        }

        private void FrmListadoMovimiento_Load(object sender, EventArgs e)
        {
            CargarFechas();
            CargarTipo();
        }

        private void CargarTipo()
        {
            cFunciones fun = new Clases.cFunciones();
            string Col = "Codigo;Nombre";
            DataTable tbTipo = fun.CrearTabla(Col);
            string Val = "";
            Val = "1;Efectivo";
            tbTipo = fun.AgregarFilas(tbTipo
                , Val);
            Val = "2;Transferencia";
            tbTipo = fun.AgregarFilas(tbTipo
                , Val);
            fun.LlenarComboDatatable(CmbTipo, tbTipo, "Nombre", "Codigo");
        }

        private void CargarFechas()
        {
            DateTime Fecha = DateTime.Now;
            Fecha = Fecha.AddMonths(-1);
            dpFechaDesde.Value = Fecha;
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            if (CmbTipo.SelectedIndex<1)
            {
                MessageBox.Show("Debe seleccionar un tipo");
                return;
            }
            Buscar();
        }

        private void Buscar()
        {
            Double Ingresos = 0;
            Double Egresos = 0;
            Double Saldo = 0;
            cFunciones fun = new cFunciones();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            int CodTipo = Convert.ToInt32(CmbTipo.SelectedValue);
            cMovimientoCaja mov = new cMovimientoCaja();
            DataTable trdo = mov.Buscar(FechaDesde, FechaHasta, CodTipo);
            Ingresos = fun.TotalizarColumna(trdo, "Debe");
            Egresos = fun.TotalizarColumna(trdo, "Haber");
            Saldo = Ingresos - Egresos;
            trdo = fun.TablaaMiles(trdo, "Debe");
            trdo = fun.TablaaMiles(trdo, "Haber");
            trdo = fun.TablaaFechas(trdo, "Fecha");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;45;15;20;20");
            txtSaldo.Text = fun.FormatoEnteroMiles(Saldo.ToString());
        }
    }
}
