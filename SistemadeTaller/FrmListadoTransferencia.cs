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
    public partial class FrmListadoTransferencia : Form
    {
        cFunciones fun;
        public FrmListadoTransferencia()
        {
            InitializeComponent();
        }

        private void FrmListadoTransferencia_Load(object sender, EventArgs e)
        {  
            fun = new Clases.cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            txtFechaCobro.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha (txtFechaDesde.Text)==false)
            {
                MessageBox.Show("La fecha desde es incorrecta");
                return;
            }
             
            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                MessageBox.Show("La fecha hasta es incorrecta");
                return;
            }

            Buscar();
        }

        private void Buscar()
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cTransferencia tra = new cTransferencia();
            DataTable trdo = tra.GetTransferencia(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaFechas(trdo, "FechaCobro");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;30;30;20;20;0");
            Grilla.Columns[3].HeaderText = "Fecha Cobro"; 
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha (txtFechaCobro.Text)==false)
            {
                Mensaje("La fecha de cobro es incorrecta");
                return;
            }
            if (Grilla.CurrentRow==null)
            {
                Mensaje("Debe seleccionar un elemento");
                return;
            }
            if (Grilla.CurrentRow.Cells[3].Value.ToString ()!="")
            {
                Mensaje("Ya se ha cobrado la transferencia");
                return;
            }
            Int32 Codigo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Double Importe = fun.ToDouble(Grilla.CurrentRow.Cells[4].Value.ToString());
            Int32 CodOrden = Convert.ToInt32(Grilla.CurrentRow.Cells[5].Value.ToString());
            DateTime Fecha = Convert.ToDateTime(txtFechaCobro.Text);
            cMovimiento mov = new cMovimiento();
            cTransferencia transfer = new cTransferencia();
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            SqlTransaction tran;
            con.Open();
            tran = con.BeginTransaction();
            try
            {
                transfer.ActualizarFechaCobro(con, tran, Codigo, Fecha);
                mov.GrabarMovimientoTransaccion(con, tran, Importe, "Cobro de transferencia", Fecha, Principal.CodUsuarioLogueado, CodOrden);
                tran.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Buscar();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabación");
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un elemento");
                return;
            }
            if (Grilla.CurrentRow.Cells[3].Value.ToString().Trim () == "")
            {
                Mensaje("Se debe Cobrar la transferencia para anularla");
                return;
            }

            Int32 Codigo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Double Importe = fun.ToDouble(Grilla.CurrentRow.Cells[4].Value.ToString());
            Int32 CodOrden = Convert.ToInt32(Grilla.CurrentRow.Cells[5].Value.ToString());
            DateTime Fecha = Convert.ToDateTime(txtFechaCobro.Text);
            cMovimiento mov = new cMovimiento();
            cTransferencia transfer = new cTransferencia();
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            SqlTransaction tran;
            con.Open();
            tran = con.BeginTransaction();
            try
            {
                transfer.AnularTransferencia (con, tran, Codigo);
                mov.GrabarMovimientoTransaccion(con, tran,(-1)* Importe, "Anulación de Cobro de transferencia", Fecha, Principal.CodUsuarioLogueado, CodOrden);
                tran.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Buscar();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabación");
            }

        }
    }
}
