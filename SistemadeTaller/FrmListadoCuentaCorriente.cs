using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemadeTaller.Clases;
using System.Data.SqlClient;
namespace SistemadeTaller
{
    public partial class FrmListadoCuentaCorriente : Form
    {
        cFunciones fun;
        public FrmListadoCuentaCorriente()
        {
            InitializeComponent();
        }

        private void FrmListadoCuentaCorriente_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            DateTime fecha = DateTime.Now;
            txtFechaHasta.Text = fecha.ToShortDateString();
            fecha = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha.ToShortDateString();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cCuentaCorriente cuenta = new cCuentaCorriente();
            DataTable trdo = cuenta.GetCuentasxFecha(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            string Col = "0;25;25;10;10;15;15";
            fun.AnchoColumnas(Grilla, Col);
            Double Total = fun.TotalizarColumna(trdo, "Importe");
            txtTotal.Text = Total.ToString();
        }

        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha (txtFechaCobro.Text)==false)
            {
                Mensaje("La fecha de cobro es incorrecta");
                return;
            }
            DateTime FechaCobro = Convert.ToDateTime(txtFechaCobro.Text);
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elemento para continuar");
                return;
            }
            string sFechaCobro = Grilla.CurrentRow.Cells[5].Value.ToString();
            if (sFechaCobro !="")
            {
                Mensaje("Ya se ha cobrado el registro");
                return;
            }
            Double Importe = 0;
            cCuentaCorriente cuenta = new cCuentaCorriente();
            cMovimiento mov = new cMovimiento();
            string Descripcion = "Cobro de Cuenta Corriente ";
            Descripcion = Descripcion + " " + Grilla.CurrentRow.Cells[1].Value.ToString();
            Int32 CodOrden = Convert.ToInt32(Grilla.CurrentRow.Cells[6].Value.ToString());
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction Tran;
            Tran = con.BeginTransaction();
            try
            {
                Importe = fun.ToDouble(Grilla.CurrentRow.Cells[3].Value.ToString());
                mov.GrabarMovimientoTransaccion(con, Tran, Importe, Descripcion, FechaCobro, Principal.CodUsuarioLogueado, CodOrden);
                cuenta.ActualizarFechacobro(con,Tran ,Convert.ToInt32 (CodOrden), FechaCobro);
                Tran.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Buscar();
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                throw;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaCobro.Text) == false)
            {
                Mensaje("La fecha de cobro es incorrecta");
                return;
            }
            DateTime FechaCobro = Convert.ToDateTime(txtFechaCobro.Text);
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un elemento para continuar");
                return;
            }
            string sFechaCobro = Grilla.CurrentRow.Cells[5].Value.ToString();
            if (sFechaCobro.Trim () == "")
            {
                Mensaje("Debe cobrarse para poder anular");
                return;
            }
            Double Importe = 0;
            cCuentaCorriente cuenta = new cCuentaCorriente();
            cMovimiento mov = new cMovimiento();
            string Descripcion = "Anulacion Cobro de Cuenta Corriente ";
            Descripcion = Descripcion + " " + Grilla.CurrentRow.Cells[1].Value.ToString();
            Int32 CodOrden = Convert.ToInt32(Grilla.CurrentRow.Cells[6].Value.ToString());
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction Tran;
            Tran = con.BeginTransaction();
            try
            {
                Importe = fun.ToDouble(Grilla.CurrentRow.Cells[3].Value.ToString());
                mov.GrabarMovimientoTransaccion(con, Tran,(-1) * Importe, Descripcion, FechaCobro, Principal.CodUsuarioLogueado, CodOrden);
                cuenta.AnularCobro(con, Tran, Convert.ToInt32(CodOrden));
                Tran.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Buscar();
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                throw;
            }
        }
    }
}
