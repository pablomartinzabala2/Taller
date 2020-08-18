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
    public partial class FrmPagoGarantia : Form
    {
        cFunciones fun;
        public FrmPagoGarantia()
        {
            InitializeComponent();
            
        }

        private void FrmPagoGarantia_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            txtCodGarantia.Text = frmPrincipal.CodigoPrincipal.ToString();
            if (txtCodGarantia.Text != "")
            {
                Buscar(Convert.ToInt32(txtCodGarantia.Text));
            }
        }

        private void Buscar(Int32 CodGarantia)
        {
            cGarantia gar = new cGarantia();
            DataTable trdo = gar.GetGarantiaxCodigo(CodGarantia);
            if (trdo.Rows.Count > 0)
            {
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
                txtImporte.Text = trdo.Rows[0]["Importe"].ToString();
                txtSaldo.Text = trdo.Rows[0]["Saldo"].ToString();
                txtCodOrden.Text = trdo.Rows[0]["CodOrden"].ToString();
                if (txtImporte.Text != "")
                {
                    
                    txtImporte.Text = fun.SepararDecimales(txtImporte.Text);
                    txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
                }

                if (txtSaldo.Text != "")
                {
                    txtSaldo.Text = fun.SepararDecimales(txtSaldo.Text);
                    txtSaldo.Text = fun.FormatoEnteroMiles(txtSaldo.Text);
                }
            }
            if (txtSaldo.Text == "0")
            {
                btnGrabar.Enabled = false;
                btnAnular.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = true;
                btnAnular.Enabled = false;
            }
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("Ingresar una fecha válida");
                return;
            }
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            double Importe = fun.ToDouble(txtImporte.Text);
            string Descripcion = "COBRO DE GARANTIA " + txtPatente.Text;
            cGarantia gar = new cGarantia();
            gar.ActualizarPago(Convert.ToInt32(txtCodGarantia.Text), Fecha);
            cMovimiento mov = new cMovimiento();
            mov.GrabarMovimiento (Importe ,Descripcion ,Fecha ,1,Convert.ToInt32 (txtCodOrden.Text));
            Mensaje ("Datos grabados correctamente");
            Buscar (Convert.ToInt32 (txtCodGarantia.Text));
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }
            
            double Importe = fun.ToDouble(txtImporte.Text);
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            cGarantia gar = new cGarantia();
            gar.AnularGarantia(Convert.ToInt32(txtCodGarantia.Text));
            cMovimiento mov = new cMovimiento();
           string  Descripcion = "ANULACION DE PAGO DE GARANTIA , PATENTE" + txtPatente.Text;
            mov.GrabarMovimiento(-1*Importe, Descripcion, Fecha, 1, Convert.ToInt32(txtCodOrden.Text));
            Mensaje("Datos grabados correctamente");
            Buscar(Convert.ToInt32(txtCodGarantia.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal.CampoNombreSecundario = txtCodGarantia.Text;
            Principal.NombreTablaSecundario = "MensajesGarantia";
            FrmMensajesTarjeta form = new FrmMensajesTarjeta();
            form.ShowDialog();
        }
    }
}
