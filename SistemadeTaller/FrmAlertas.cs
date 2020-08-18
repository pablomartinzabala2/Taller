using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace SistemadeTaller
{
    public partial class FrmAlertas : Form
    {
        public FrmAlertas()
        {
            InitializeComponent();
        }

        private void FrmAlertas_Load(object sender, EventArgs e)
        {
            Clases.cAlarma alarma = new Clases.cAlarma();
            DataTable trdo = alarma.GetAlarmasxFecha(DateTime.Now);
            Grilla.DataSource = trdo;
            Grilla.Columns[1].Width = 410;
            Grilla.Columns[0].Visible = false; 
        }
    }
}
