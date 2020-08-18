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
    public partial class FrmRegistrarAlertascs : Form
    {
        public FrmRegistrarAlertascs()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaDesde.Text) == false)
            {
                MessageBox.Show("La fecha ingresada es incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar un motivo", Clases.cMensaje.Mensaje());
                return;
            }

            Clases.cAlarma alarma = new Clases.cAlarma();
            alarma.GrabarAlarma(txtDescripcion.Text.ToUpper(), Convert.ToDateTime(txtFechaDesde.Text));
            MessageBox.Show("Alarma registrada correctamente", Clases.cMensaje.Mensaje());
            txtDescripcion.Text = "";
        }
    }
}
