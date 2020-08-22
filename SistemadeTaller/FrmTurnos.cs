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
    public partial class FrmTurnos : Form
    {
        public FrmTurnos()
        {
            InitializeComponent();
        }

        private void FrmTurnos_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }

        public void Mensaje(string m)
        {
            MessageBox.Show(m, "Sistema");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text =="")
            {
                Mensaje("Debe ingresar un apellido");
                return;
            }
            if (txtNombre.Text  == "")
            {
                Mensaje("Debe ingresar un nombre");
                return;
            }
            if (txtPatente.Text  == "")
            {
                Mensaje("Debe ingresar una patente");
                return;
            }
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha (txtFecha.Text)==false)
            {
                Mensaje("La Fecha Ingrsada es incorrecta");
                return;
            }
            string Apellido = txtApellido.Text;
            string Nombre = txtNombre.Text;
            string Patente = txtPatente.Text;
            string Descripcion = txtDescripcion.Text;
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            string Telefono = txtTelefono.Text;
            string Hora = txtHora.Text;
            cTurno turno = new cTurno();
            turno.Insertar(Apellido, Nombre, Patente, Descripcion, Fecha, Telefono,Hora);
            Mensaje("Datos grabados correctamente");
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtPatente.Text = "";
            txtDescripcion.Text = "";
            txtTelefono.Text = "";
            
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            FrmConsultaTurnoscs frm = new SistemadeTaller.FrmConsultaTurnoscs();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha (txtFecha.Text)==false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Fecha = Fecha.AddDays(-1);
            txtFecha.Text = Fecha.ToShortDateString();
        }

        private void btnDelante_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Fecha = Fecha.AddDays(1);
            txtFecha.Text = Fecha.ToShortDateString();
        }
    }
}
