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
    public partial class FrmRegistrarGastosGenerales : Form
    {
        public FrmRegistrarGastosGenerales()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha es incorrecta");
                return;
            }

            if (txtEfectivo.Text == "")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }

            if (cmbConcepto.SelectedIndex == 0)
            {
                if (txtDescripcion.Text == "")
                {
                    Mensaje("Debe ingresar una descripción");
                    return;
                }
            }

            if (cmbTipo.SelectedIndex <1)
            {
                Mensaje("Debe seleccionar un tipo de operación ");
                return;
            }

            Int32 CodConcepto = Convert.ToInt32(cmbConcepto.SelectedValue);
            string Empleado = "";
            if (CodConcepto == 6)
            {
                if (CmbMecanico.SelectedIndex < 1)
                {
                    Mensaje("Debe seleccionar un mecánico");
                    return;
                }
                else
                {
                    Empleado = CmbMecanico.Text;
                }
            }

            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            double Importe = fun.ToDouble(txtEfectivo.Text);
            string Descripcion = txtDescripcion.Text;
            Int32? CodEntidad = null;
            string NombreEntidad = "";
            if (cmbConcepto.SelectedIndex > 0)
            {
                CodEntidad = Convert.ToInt32(cmbConcepto.SelectedValue);
                Clases.cEntidad ent = new Clases.cEntidad();
                NombreEntidad = ent.GetNombrexCodigo(Convert.ToInt32(CodEntidad));
            }

            if (NombreEntidad != "")
            {
                Descripcion = NombreEntidad + "," + Descripcion;
            }
            if (CodEntidad == 6)
            {
                Descripcion = cmbConcepto.Text + " " + Empleado.ToString() + " " + txtDescripcion.Text; 
            }
            int CodTipo = 0;
            string Tipo = "";
            switch(CodTipo)
            {
                case 1:
                    Tipo = "Efectivo";
                    break;
                case 2:
                    Tipo = "ransferencia";
                    break;
            }
            CodTipo = Convert.ToInt32(cmbTipo.SelectedValue);
            cMovimientoCaja movCaja = new cMovimientoCaja();
            Clases.cGastosNegocio gasto = new Clases.cGastosNegocio();
            gasto.GrabarGastos(Fecha, CodEntidad, Descripcion, Importe);
            Clases.cMovimiento mov = new Clases.cMovimiento();
            mov.GrabarMovimiento(-1 * Importe, Descripcion, Fecha, 1, null);
            movCaja.Insertar(Descripcion, 0, Importe, Fecha, CodTipo, Tipo,null);

            Mensaje("Datos grabados correctamente");
            txtEfectivo.Text = "";
            txtFecha.Text = "";
            txtDescripcion.Text = "";
            if (cmbConcepto.Items.Count > 0)
                cmbConcepto.SelectedIndex = 0;
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, Clases.cMensaje.Mensaje());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodEntidad";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Entidad";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Entidad":
                        fun.LlenarCombo(cmbConcepto, "Entidad", "Nombre", "CodEntidad");
                        cmbConcepto.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                }
            }

        }

        private void FrmRegistrarGastosGenerales_Load(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbConcepto, "Entidad", "Nombre", "CodEntidad");
            Clases.cMecanico mec = new Clases.cMecanico();
            fun.LlenarComboDatatable(CmbMecanico, mec.GetMecanicos(), "Apellido", "CodMecanico");
            txtFecha.Text = DateTime.Now.ToShortDateString();
            CargarTipo();
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConcepto.SelectedIndex < 1)
                return;
            Int32 CodConcepto = Convert.ToInt32(cmbConcepto.SelectedValue);
            if (CodConcepto != 6)
            {
                lblMecanico.Visible = false;
                CmbMecanico.Visible = false;
            }
            else
            {
                lblMecanico.Visible = true;
                CmbMecanico.Visible = true;
            }
                
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
            fun.LlenarComboDatatable(cmbTipo, tbTipo, "Nombre", "Codigo");
        }
    }
}
