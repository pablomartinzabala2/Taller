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
    public partial class FrmListadoStock : Form
    {
        cFunciones fun;
        cTabla tabla; 
        public FrmListadoStock()
        {
            InitializeComponent();
        }

        private void FrmListadoStock_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImprimirOrden_Click(object sender, EventArgs e)
        {
            int b = 0;
            string Precio = "";
            cReporte reporte = new cReporte();
            reporte.Borrar();
            for (int i = 0; i < Grilla.Rows.Count-1; i++)
            {
                b = 1;
                if (Grilla.Columns[4].Visible == false)
                    Precio = "";
                else
                    Precio = Grilla.Rows[i].Cells[4].Value.ToString();
                reporte.Insertar(Grilla.Rows[i].Cells[1].Value.ToString(),
                    Grilla.Rows[i].Cells[3].Value.ToString(),
                    Grilla.Rows[i].Cells[2].Value.ToString(),
                    Precio , "");
            }
            if (b == 1)
            {
                FrmReporteStockcs frm = new FrmReporteStockcs();
                frm.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cInsumo insumo = new cInsumo();
            DataTable trdo = insumo.GetInsumosxNombre(txtNombre.Text);
            trdo = fun.TablaaMiles(trdo, "Precio");
            trdo = fun.TablaaMiles(trdo, "PrecioVenta");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 420;
            Grilla.Columns[2].Width = 100;
            Grilla.Columns[3].Width = 100;
            Grilla.Columns[4].HeaderText = "Venta";
            Grilla.Columns[4].Visible = true;
        }

        private void btnLinterna_Click(object sender, EventArgs e)
        {
            if (Grilla.Columns[4].Visible ==true )
                Grilla.Columns[4].Visible = false;
            else
                Grilla.Columns[4].Visible = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            string CodigoBarra = txtCodigoBarra.Text;
            if (CodigoBarra.Length >5)
            {  //
                cInsumo insumo = new Clases.cInsumo();
                DataTable trdo = insumo.GetDetalleInsumoxCodigoBarra(CodigoBarra);
                if (trdo.Rows.Count >0)
                {
                    trdo = fun.TablaaMiles(trdo, "Precio");
                    trdo = fun.TablaaMiles(trdo, "PrecioVenta");
                    Grilla.DataSource = trdo;
                    Grilla.Columns[0].Visible = false;
                    Grilla.Columns[1].Width = 420;
                    Grilla.Columns[2].Width = 100;
                    Grilla.Columns[3].Width = 100;
                    Grilla.Columns[4].HeaderText = "Venta";
                    Grilla.Columns[4].Visible = true;
                }
                
            }
        }
    }
}
