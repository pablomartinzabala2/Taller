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
    public partial class FrmListadoTransferencia : Form
    {
        cFunciones fun;
        public FrmListadoTransferencia()
        {
            InitializeComponent();
        }

        private void FrmListadoTransferencia_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha (txtFechaDesde.Text)==false)
            {
                MessageBox.Show("La fecha desde es incorrecta");
                return;
            }
             
            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                MessageBox.Show("La fecha hasta es incorrecta");
                return;
            }

            Buscar();
        }

        private void Buscar()
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cTransferencia tra = new cTransferencia();
            DataTable trdo = tra.GetTransferencia(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;32;33;15;20");
            Grilla.Columns[3].HeaderText = "Fecha"; 
        }
    }
}
