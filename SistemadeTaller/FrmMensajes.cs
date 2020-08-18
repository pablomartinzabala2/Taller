using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using SistemadeTaller.Clases; 
using System.Windows.Forms;

namespace SistemadeTaller
{
    public partial class FrmMensajes : Form
    {
        cFunciones fun;
        public FrmMensajes()
        {
            InitializeComponent();
        }

        private void FrmMensajes_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            fun = new cFunciones();
            Int32 CodOrden = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
            txtCodOrden.Text = CodOrden.ToString();
            CargarMensaje(CodOrden);
        }

        private void btnAgregarMensaje_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                MessageBox.Show("Fecha incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtMensaje.Text == "")
            {
                MessageBox.Show("Debe ingresar un mensaje", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cMensajeOrden obj = new Clases.cMensajeOrden();
            Int32 CodOrden = Convert.ToInt32(txtCodOrden.Text);
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            obj.InsertarMensaje(CodOrden, txtMensaje.Text, Fecha);
            CargarMensaje(CodOrden);
            txtMensaje.Text = "";
        }

        private void CargarMensaje(Int32 CodOrden)
        {
            cMensajeOrden msj = new cMensajeOrden();
            DataTable trdo = msj.GetMensajesxCodOrden(CodOrden);
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 90; 
            Grilla.Columns[2].Width = 370; 
            
        }
    }
}
