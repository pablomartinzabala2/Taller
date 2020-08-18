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
    public partial class FrmCobroCheque : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmCobroCheque()
        {
            InitializeComponent();
        }

        private void FrmCobroCheque_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
            if (frmPrincipal.CodigoPrincipal != null)
            {
                Buscar(Convert.ToInt32(frmPrincipal.CodigoPrincipal));
            }
        }

        private void Buscar(Int32 CodCheque)
        {
            cCheque cheque = new cCheque();
            DataTable trdo = cheque.GetChequexCodigo(CodCheque);
            if (trdo.Rows.Count > 0)
            {
                txtImporte.Text = trdo.Rows[0]["Importe"].ToString();
                txtSaldo.Text = trdo.Rows[0]["Saldo"].ToString();
                txtNroCheque.Text = trdo.Rows[0]["NroCheque"].ToString();
                txtOrden.Text = trdo.Rows[0]["CodOrden"].ToString();
            }
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

            cCobroCheque objCobro = new cCobroCheque();
            DataTable tresul = objCobro.GetCobroChequexCodCheque(CodCheque);
            Grilla.DataSource = tresul;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Visible = false;
            Grilla.Columns[2].Width = 130;
            Grilla.Columns[3].Width = 130;
            if (txtSaldo.Text == "0")
            {
                btnAnular.Enabled = true;
                btnGrabar.Enabled = false;
            }
            else
            {
                btnAnular.Enabled = false;
                btnGrabar.Enabled = true;
            }

        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtaPagar.Text == "")
            {
                Mensaje("Debe ingresar un monto");
            }

            double aPagar = fun.ToDouble(txtaPagar.Text);
            double Saldo = fun.ToDouble(txtSaldo.Text);
            if (aPagar > Saldo)
            {
                Mensaje("El monto a pagar supera el saldo");
                return;
            }

            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha Ingresada es incorrecta");
                return;
            }

            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction tranOrden;
            tranOrden = con.BeginTransaction("TranOrden");
            try
            {
                Int32 CodOrden = Convert.ToInt32(txtOrden.Text);
                Int32 CodCheque = Convert.ToInt32 (frmPrincipal.CodigoPrincipal);
                cCobroCheque objCobro = new cCobroCheque();
                objCobro.RegistrarPago(con, tranOrden, CodCheque, aPagar, Fecha);
                cCheque objCheque = new cCheque();
                objCheque.CobroCheque(con, tranOrden, CodCheque, aPagar);
                cMovimiento mov = new cMovimiento();
                string Descripcion = "COBRO DE CHEQUE " + txtNroCheque.Text;
                mov.GrabarMovimientoTransaccion(con, tranOrden, aPagar, Descripcion, Fecha, 1,CodOrden);
                tranOrden.Commit();
                con.Close();
                Buscar(CodCheque);
                Mensaje("Datos Grabados Correctamente");
            }
            catch (Exception ex)
            {
                tranOrden.Rollback();
                Mensaje("Hubo un error en el proceso de grabación");
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction tranOrden;
            Int32 CodCheque = Convert.ToInt32 (frmPrincipal.CodigoPrincipal);
            tranOrden = con.BeginTransaction("TranOrden");
            try
            {
                cCheque objCheque = new cCheque();
                objCheque.AnularPagoCheque(con, tranOrden, CodCheque);
                cCobroCheque objCobroCheque = new cCobroCheque();
                objCobroCheque.BorrarCobroCheque(con, tranOrden, CodCheque);
                tranOrden.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");

            }
            catch (Exception ex)
            {
                tranOrden.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabación");
            }
            Buscar(CodCheque);
        }
    }
}
