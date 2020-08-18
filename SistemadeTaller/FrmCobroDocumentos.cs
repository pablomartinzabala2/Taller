using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using SistemadeTaller.Clases;
using System.Data.SqlClient;
namespace SistemadeTaller
{
    public partial class FrmCobroDocumentos : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmCobroDocumentos()
        {
            InitializeComponent();
            fun = new cFunciones();
            tabla = new cTabla();
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void FrmCobroDocumentos_Load(object sender, EventArgs e)
        {
            if (frmPrincipal.CodigoPrincipal != null)
                Buscar(Convert.ToInt32(frmPrincipal.CodigoPrincipal));
        }

        private void Buscar(Int32 CodDocumento)
        {
            cDocumento doc = new cDocumento();
            DataTable trdo = doc.GetDocumentoxCodigo(CodDocumento);
            if (trdo.Rows.Count > 0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text  = trdo.Rows[0]["Apellido"].ToString();
                txtImporte.Text = trdo.Rows[0]["Importe"].ToString();
                txtSaldo.Text = trdo.Rows[0]["Saldo"].ToString();
                txtOrden.Text = trdo.Rows[0]["CodOrden"].ToString();
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
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
            cCobroDocumento cob = new cCobroDocumento();
            DataTable tresul = cob.GetCobrosxCodDocumento(CodDocumento);
            tresul = fun.TablaaMiles(tresul, "Importe");
            Grilla.DataSource = tresul;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Visible = false;
            Grilla.Columns[3].Width = 120;
            if (txtSaldo.Text == "0")
            {
                
                btnGrabar.Enabled = false;
            }
            else
            {
                
                btnGrabar.Enabled = true;
            }
        }

        private void txtaPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void txtaPagar_Leave(object sender, EventArgs e)
        {
            if (txtaPagar.Text == "")
            {
                txtaPagar.Text = fun.FormatoEnteroMiles(txtaPagar.Text);
                Mensaje("Debe ingresar un monto");
                return;
            }
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtaPagar.Text == "")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }
            double Saldo = fun.ToDouble(txtSaldo.Text);
            double aPagar = fun.ToDouble(txtaPagar.Text);
            if (aPagar > Saldo)
            {
                Mensaje("El importe ingresado supera el saldo");
                return;
            }

            if (fun.ValidarFecha (txtFecha.Text)==false)
            {
                Mensaje ("Debe ingresar una fecha para continuar");
            }
            cMovimiento mov = new cMovimiento();
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            SqlTransaction tran;
           
            cCobroDocumento cobro = new cCobroDocumento();
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            tran = con.BeginTransaction();
            Int32 CodDocumento = Convert.ToInt32 (frmPrincipal.CodigoPrincipal);
            string Descripcion = "COBRO DE DOCUMENTO CLIENTE " + txtApellido.Text + " " + txtApellido.Text + " " + txtNombre.Text;
            Descripcion = Descripcion + ", PATENTE " + txtPatente.Text;
            
            try
            {
                cobro.Insertar(con, tran, CodDocumento, Fecha, aPagar);
                cobro.ActualizarSaldo(con, tran, CodDocumento, aPagar, Fecha);
                Int32? CodOrden = null;
                if (txtOrden.Text != "")
                    CodOrden = Convert.ToInt32(txtOrden.Text);
                mov.GrabarMovimientoTransaccion(con, tran, aPagar, Descripcion, Fecha, 1, CodOrden);
                tran.Commit();
                con.Close();
                Buscar(CodDocumento);
                Mensaje("Datos grabados correctamente");
                
            }
            catch (Exception ex)
            {
                
                Mensaje("Hubo un error en el proceso de grabación");
                tran.Rollback ();
                con.Close();
            }
        }


        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha es incorrecta");
                return;
            }
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Int32 CodDocumento = Convert.ToInt32 (frmPrincipal.CodigoPrincipal);
            Int32 CodOrden = Convert.ToInt32 (txtOrden.Text); 
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction tranOrden;
            tranOrden = con.BeginTransaction("TranOrden");
            try
            {
                double ImporteAnular = fun.ToDouble(Grilla.CurrentRow.Cells[3].Value.ToString());  
                cDocumento docu = new cDocumento ();
                docu.AnularCobro (con,tranOrden ,CodDocumento,ImporteAnular);
                Int32 CodCobro = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
                cCobroDocumento cob = new cCobroDocumento ();
                cob.BorrarCobroDocumento(con, tranOrden, CodCobro);              
                string Descripcion = "ANULACION COBRO DE DOCUMENTO CLIENTE " + txtApellido.Text + " " + txtApellido.Text + " " + txtNombre.Text;
                Descripcion = Descripcion + ", PATENTE " + txtPatente.Text;
                cMovimiento mov = new cMovimiento();
                mov.GrabarMovimientoTransaccion(con, tranOrden,-1* ImporteAnular, Descripcion, Fecha, 1, CodOrden);
                
                tranOrden.Commit();
                con.Close ();
                Mensaje("Datos anulados correctamente");
                Buscar(CodDocumento);
            }
            catch (Exception ex)
            {
                tranOrden.Rollback ();
                con.Close ();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal.CampoNombreSecundario = frmPrincipal.CodigoPrincipal.ToString();
            Principal.NombreTablaSecundario = "mensajesDocumentos";
            FrmMensajesTarjeta form = new FrmMensajesTarjeta();
            form.ShowDialog();
        }      
    }
}
