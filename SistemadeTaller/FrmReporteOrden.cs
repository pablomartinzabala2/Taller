using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemadeTaller
{
    public partial class FrmReporteOrden : Form
    {
        public FrmReporteOrden()
        {
            InitializeComponent();
        }

        private void FrmReporteOrden_Load(object sender, EventArgs e)
        {
            Int32 P1 = Convert.ToInt32(frmPrincipal.CodigoPrincipal); 
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1, P1);

            this.reportViewer1.RefreshReport();
        }
    }
}
