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
    public partial class FrmConsultaTurnoscs : Form
    {
        public FrmConsultaTurnoscs()
        {
            InitializeComponent();
        }

        private void FrmConsultaTurnoscs_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            Fecha = Fecha.AddDays(3);
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddDays(-7);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            Buscar();
        }

        public void Mensaje(string m)
        {
            MessageBox.Show(m, "Sistema");
        }

        private void btnVetOrden_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha (txtFechaHasta.Text)==false)
            {
                Mensaje("La fecha hasta es incorrecta");
                return;
            }

            if (fun.ValidarFecha(txtFechaDesde.Text) == false)
            {
                Mensaje("La fecha desde es incorrecta");
                return;
            }
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new Clases.cFunciones();
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            cTurno turno = new cTurno();
            DataTable trdo = turno.GetTurnos(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
            string Col = "0;15;15;10;10;25;15;10";
            fun.AnchoColumnas(Grilla, Col);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Int32 CodTurno =Convert.ToInt32 ( Grilla.CurrentRow.Cells[0].Value);
            cTurno turno = new cTurno();
            turno.Borrar(CodTurno);
            Mensaje("Turno Eliminado Correctamente");
            Buscar();  
        }
    }
}
