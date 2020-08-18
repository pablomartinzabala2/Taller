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
    public partial class FrmReporteStockcs : Form
    {
        public FrmReporteStockcs()
        {
            InitializeComponent();
        }

        private void FrmReporteStockcs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.Reporte' table. You can move, or remove it, as needed.
            this.ReporteTableAdapter.Fill(this.DataSet2.Reporte);

            this.reportViewer1.RefreshReport();
        }
    }
}
