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
    public partial class FrmMensajesTarjeta : Form
    {
        public FrmMensajesTarjeta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();

            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                MessageBox.Show("La fecha es incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtMensaje.Text == "")
            {
                MessageBox.Show("Debe ingresar un mensaje para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            Clases.cMensajesTarjetas msj = new Clases.cMensajesTarjetas();
            
            if (Principal.NombreTablaSecundario == "MensajesTarjetas")
            {
                string Mensaje = txtMensaje.Text;
                Int32 CodCobro = Convert.ToInt32(txtCodigo.Text);
                DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
                msj.InsertarMensaje(Mensaje, Fecha, CodCobro);
                MessageBox.Show("Datos Grabados Correctamente", Clases.cMensaje.Mensaje());
                DataTable trdo = msj.GetMensajesxCodCobro(CodCobro);
                Grilla.DataSource = trdo;
                Grilla.Columns[1].Width = 400; 
                txtMensaje.Text = "";
            }

            if (Principal.NombreTablaSecundario == "mensajesDocumentos")
            {
                Clases.cMensajesDocumento msjDoc = new Clases.cMensajesDocumento();
                string Mensaje = txtMensaje.Text;
                Int32 CodDoc = Convert.ToInt32(txtCodigo.Text);
                DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
                msjDoc.InsertarMensaje(Mensaje, Fecha, CodDoc);
                MessageBox.Show("Datos Grabados Correctamente", Clases.cMensaje.Mensaje());
                DataTable trdo = msjDoc.GetMensajesxCodDocumento(CodDoc);
                Grilla.DataSource = trdo;
                Grilla.Columns[1].Width = 400;
                txtMensaje.Text = "";
            }

            if (Principal.NombreTablaSecundario == "MensajesGarantia")
            {
                Clases.cMensajesGarantia msjGar = new Clases.cMensajesGarantia();
                string Mensaje = txtMensaje.Text;
                Int32 CodGar = Convert.ToInt32(txtCodigo.Text);
                DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
                msjGar.InsertarMensaje(Mensaje, Fecha, CodGar);
                MessageBox.Show("Datos Grabados Correctamente", Clases.cMensaje.Mensaje());
                DataTable trdo = msjGar.GetMensajesxCodGarantia(CodGar);
                Grilla.DataSource = trdo;
                Grilla.Columns[1].Width = 400;
                txtMensaje.Text = "";
            }
                
        }

        private void FrmMensajesTarjeta_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtCodigo.Text = frmPrincipal.CodigoPrincipal.ToString();
            if (Principal.NombreTablaSecundario == "MensajesTarjetas")
            {
                Clases.cMensajesTarjetas msj = new Clases.cMensajesTarjetas();
                Int32 CodCobro = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                DataTable trdo = msj.GetMensajesxCodCobro(CodCobro);
                Grilla.DataSource = trdo;
                Grilla.Columns[1].Width = 400; 
            }

            if (Principal.NombreTablaSecundario == "mensajesDocumentos")
            {
                Clases.cMensajesDocumento msj = new Clases.cMensajesDocumento();
                Int32 CodDoc = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                DataTable trdo = msj.GetMensajesxCodDocumento(CodDoc);
                Grilla.DataSource = trdo;
                Grilla.Columns[1].Width = 400;
            }

            if (Principal.NombreTablaSecundario == "MensajesGarantia")
            {
                Clases.cMensajesGarantia msjG = new Clases.cMensajesGarantia();
                Int32 CodGar = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                DataTable trdo = msjG.GetMensajesxCodGarantia(CodGar);
                Grilla.DataSource = trdo;
                Grilla.Columns[1].Width = 400;
            }
        }
    }
}
