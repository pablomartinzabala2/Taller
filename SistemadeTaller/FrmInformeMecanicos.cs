using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemadeTaller.Clases;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemadeTaller
{
    public partial class FrmInformeMecanicos : Form
    {
        public FrmInformeMecanicos()
        {
            InitializeComponent();
        }

        private void FrmInformeMecanicos_Load(object sender, EventArgs e)
        {
            CargarMecanico();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            Grafico.Titles.Add("Producción de mecánicos");
        }

        private void CargarMecanico()
        {
            cFunciones fun = new cFunciones();
            cMecanico mec = new cMecanico();
            DataTable trdo = mec.GetMecanicos();
            fun.LlenarComboDatatable(CmbMecanico, trdo, "Apellido", "CodMecanico");
        }

        private void btnVetOrden_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new Clases.cFunciones();
            Int32? CodMecanico = null;
            if (CmbMecanico.SelectedIndex > 0)
                CodMecanico = Convert.ToInt32(CmbMecanico.SelectedValue);
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cMecanico mec = new cMecanico();
            DataTable trdo = mec.GetProduccion(FechaDesde, FechaHasta, CodMecanico);
            
            ArrayList ape = new ArrayList();
            ArrayList Montos = new ArrayList();
           // Grafico.Titles.Add("Producción de mecánicos");
            for (int i=0;i<trdo.Rows.Count;i++)
            {
                ape.Add(trdo.Rows[i]["Apellido"].ToString());
                Montos.Add(Convert.ToDouble(trdo.Rows[i]["Total"].ToString()));
            }
            Grafico.Series[0].Points.DataBindXY(ape, Montos);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "30;30;20;20");
            Grilla.Columns[3].HeaderText = "Total M.O";
        }
    }
}
