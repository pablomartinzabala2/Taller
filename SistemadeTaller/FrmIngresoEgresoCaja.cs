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
    public partial class FrmIngresoEgresoCaja : Form
    {
        public FrmIngresoEgresoCaja()
        {
            InitializeComponent();
        }

        private void CargarTipoOperacion()
        {
            cFunciones fun = new Clases.cFunciones();
            string Col = "Codigo;Nombre";
            DataTable tbTipo = fun.CrearTabla(Col);
            string Val = "";
            Val = "1;Ingreso";
            tbTipo = fun.AgregarFilas(tbTipo
                , Val);
            Val = "2;Egreso";
            tbTipo = fun.AgregarFilas(tbTipo
                , Val);
            fun.LlenarComboDatatable(CmbTipoOperacion, tbTipo, "Nombre", "Codigo");
        }

        private void FrmIngresoEgresoCaja_Load(object sender, EventArgs e)
        {
            CargarTipoOperacion();
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

        private Boolean Validar()
        {
            if (CmbTipoOperacion.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar un tipo de operación", "Sistema");
                return false;
            }
            
            if (CmbTipo.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar un tipo de Operación", "Sistema");
                return false;
            }

            if (txtDescripcion.Text =="")
            {
                MessageBox.Show("Debe ingresar una descripción", "Sistema");
                return false ;
            }
            if (txtImporte.Text =="")
            {
                MessageBox.Show("Debe ingresar un importe para continuar", "Sistema");
                return false;

            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (Validar ()==false)
            {
                return;
            }
            int CodTipo = Convert.ToInt32(CmbTipo.SelectedValue);
            string Tipo = "";
            switch(CodTipo)
            {
                case 1:
                    Tipo = "Efectivo";
                    break;
                case 2:
                    Tipo = "Transferencia";
                    break;
            }

            int TipoOperacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            Double Importe = fun.ToDouble(txtImporte.Text);
            string Descripcion = txtDescripcion.Text;
            Int32? CodOrden = null;
            DateTime Fecha = dpFecha.Value;
            Double Debe = 0, Haber = 0;
            if (TipoOperacion == 1)
                Debe = Importe;
            if (TipoOperacion == 2)
                Haber = Importe;
            cMovimientoCaja mov = new cMovimientoCaja();
            mov.Insertar(Descripcion, Debe, Haber, Fecha, CodTipo, Tipo, CodOrden);
            MessageBox.Show("Datos grabados correctamente ");
            Limpiar();
        }

        private void Limpiar ()
        {
            txtDescripcion.Text = "";
            txtImporte.Text = "";
           
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (txtImporte.Text !="")
            {
                txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
