using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemadeTaller.Clases;
using System.Data;
namespace SistemadeTaller
{
    public partial class FrmCobroTarjeta : Form
    {
        cFunciones fun;
        cTabla tabla;
        public FrmCobroTarjeta()
        {
            InitializeComponent();
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void FrmCobroTarjeta_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
            if (frmPrincipal.CodigoPrincipal != null)
            {
                Buscar(Convert.ToInt32(frmPrincipal.CodigoPrincipal));
            }
        }

        private void Buscar(Int32 CodCobro)
        {
            int b = 0;
            txtFecha.Text = DateTime.Now.ToShortDateString(); 
            cCobroTarjeta cobro = new cCobroTarjeta();
            DataTable trdo = cobro.GetCobroTarjeta(CodCobro);
            if (trdo.Rows.Count > 0)
            {
                txtNombre.Text = trdo.Rows[0]["Nom"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
                txtImporte.Text = trdo.Rows[0]["Importe"].ToString();
                txtSaldo.Text = trdo.Rows[0]["Saldo"].ToString();
                txtImporte.Text = fun.SepararDecimales(txtImporte.Text);
                txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
                txtSaldo.Text = fun.SepararDecimales(txtSaldo.Text);
                txtSaldo.Text = fun.FormatoEnteroMiles(txtSaldo.Text);
                txtaPagar.Text = trdo.Rows[0]["Importe"].ToString();
                if (txtaPagar.Text != "")
                {
                    txtaPagar.Text = fun.SepararDecimales(txtaPagar.Text);
                    txtaPagar.Text = fun.FormatoEnteroMiles(txtaPagar.Text);
                }
                txtTarjeta.Text = trdo.Rows[0]["Nombre"].ToString();
                txtCodVenta.Text = trdo.Rows[0]["CodVenta"].ToString();
                txtOrden.Text = trdo.Rows[0]["CodOrden"].ToString();
                txtCupon.Text = trdo.Rows[0]["Cupon"].ToString();
                
                
                DateTime FechadeEmision = Convert.ToDateTime(trdo.Rows[0]["FechaEmision"].ToString());
                txtFechaEmision.Text = FechadeEmision.ToShortDateString();
                DateTime FechaOrden = Convert.ToDateTime(trdo.Rows[0]["Fecha"].ToString());
                txtFechaOrden.Text = FechaOrden.ToShortDateString();
                txtRecargo.Text = trdo.Rows[0]["Recargo"].ToString();
                if (trdo.Rows[0]["FechaCobro"].ToString() != "")
                {
                    b = 1;
                    DateTime fechaCobro = Convert.ToDateTime(trdo.Rows[0]["FechaCobro"].ToString());
                    txtFechaCobro.Text = fechaCobro.ToShortDateString();
                    double Imp = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                    double Saldo = Convert.ToDouble(trdo.Rows[0]["Saldo"].ToString());
                    Imp = Imp - Saldo;
                    txtIngresarMonto.Text = Imp.ToString();
                    txtIngresarMonto.Text = fun.SepararDecimales(txtIngresarMonto.Text);
                    txtIngresarMonto.Text = fun.FormatoEnteroMiles(txtIngresarMonto.Text);
                }
                else
                {
                    txtDiferencia.Text = "";
                }
                
            }
            
            if (b == 1)
            {
                btnGrabar.Enabled = false;
                btnAnular.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = true;
                btnAnular.Enabled = false;
            }
            GetSaldo(CodCobro);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("Debe ingresar una fecha válida");
                return;
            }

            if (txtIngresarMonto.Text == "")
            {
                Mensaje("Debe ingresar un importe cobrado");
                return;
            }
            Double Recargo = 0;
            Double ImporteTeorico = Convert.ToDouble(txtImporte.Text);
            Double ImporteCobrado = Convert.ToDouble(txtIngresarMonto.Text);
            Double Saldo = ImporteTeorico - ImporteCobrado;
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Int32? CodOrden = null;
            if (txtOrden.Text != "")
                CodOrden = Convert.ToInt32(txtOrden.Text);
            if (txtRecargo.Text != "")
                Recargo = Convert.ToDouble(txtRecargo.Text);
            Int32 CodCobro = Convert.ToInt32(frmPrincipal.CodigoPrincipal); 
            cCobroTarjeta cobro = new cCobroTarjeta();
            cobro.CobroTarjeta(CodCobro, Fecha, ImporteCobrado, Recargo);
            string Descripcion ="COBRO DE TARJETA " + txtTarjeta.Text;
            double Importe = fun.ToDouble (txtaPagar.Text);
            cMovimiento mov = new cMovimiento ();
            mov.GrabarMovimiento((ImporteCobrado + Recargo) , Descripcion, Fecha, 1, CodOrden);
            /*
            if (Saldo >0)
                mov.GrabarMovimiento(-1*Saldo, "DIFERENCIA NEGATIVA DE TARJETA", Fecha, 1, CodOrden);
            else
                mov.GrabarMovimiento(Saldo, "DIFERENCIA POSITIVA DE TARJETA", Fecha, 1, CodOrden);
            */
              Mensaje ("Datos grabados correctamente");
            Buscar (CodCobro);
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha ingresada es Incorrecta");
                return;
            }
            
            Int32 CodOrden = Convert.ToInt32 (txtOrden.Text);
            DateTime Fecha = Convert.ToDateTime (txtFecha.Text);
            Int32 CodCobro = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
            cCobroTarjeta cobro = new cCobroTarjeta();
            double Importe = GetMontoAnular(CodOrden);
            cobro.AnularCobro(CodCobro);
            string Descripcion = "ANULACION DE COBRO DE TARJETA " + txtTarjeta.Text;
            //double Importe = fun.ToDouble(txtImporte.Text);
            
            cMovimiento mov = new cMovimiento();
            //mov.BorrarMovimiento(CodOrden);
             mov.GrabarMovimiento(-1*Importe, Descripcion, Fecha, 1, CodOrden);
            Mensaje("Datos grabados correctamente");
            Buscar(CodCobro);
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            Principal.CampoNombreSecundario = frmPrincipal.CodigoPrincipal.ToString();
            Principal.NombreTablaSecundario = "MensajesTarjetas";
            FrmMensajesTarjeta form = new FrmMensajesTarjeta();
            form.ShowDialog();

        }

        private void txtIngresarMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        public void GetSaldo(Int32 CodCobro)
        {
            double Saldo = 0;
            cCobroTarjeta cobro = new cCobroTarjeta();
            Saldo  = cobro.GetSaldo(CodCobro);
            if (Saldo > 0)
            {
                string dif = "Diferencia negativa de tarjeta =" + Saldo.ToString();
                txtDiferencia.Text = dif;
            }
            
        }

        public double GetMontoAnular(Int32 CodCobro)
        {
            cCobroTarjeta cobro = new cCobroTarjeta();
            double Monto = cobro.GetMontoAnular(CodCobro);
            return Monto;
        }

       
    }
}
