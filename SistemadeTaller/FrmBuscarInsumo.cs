using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemadeTaller.Clases;
using System.Data;
namespace SistemadeTaller
{
    public partial class FrmBuscarInsumo : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmBuscarInsumo()
        {
            InitializeComponent();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            cInsumo insumo = new cInsumo();
            DataTable trdo = insumo.GetInsumosxNombre(txtInsumo.Text);
            trdo = fun.TablaaMiles(trdo, "Precio");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 400;
            Grilla.Columns[2].Width = 100;
            Grilla.Columns[3].Width = 100;
        }

        private void FrmBuscarInsumo_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje()); 
                return;
            }
            string CodInsumo = Grilla.CurrentRow.Cells[0].Value.ToString();
            frmPrincipal.CodigoPrincipal = CodInsumo.ToString();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal.CodigoPrincipal = null;
            this.Close();
        }
    }
}
