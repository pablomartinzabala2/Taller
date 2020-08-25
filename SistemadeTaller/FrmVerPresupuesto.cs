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
    public partial class FrmVerPresupuesto : Form
    {
        public FrmVerPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmVerPresupuesto_Load(object sender, EventArgs e)
        {
            Int32 CodPresupuesto = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
            // TODO: This line of code loads data into the 'DsSolicitudxsd.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.DsSolicitudxsd.DataTable2, CodPresupuesto);

            this.reportViewer1.RefreshReport();
        }
    }
}
