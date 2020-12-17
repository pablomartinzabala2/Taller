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
    public partial class FrmInformeCuentas : Form
    {
        cFunciones fun;
        public FrmInformeCuentas()
        {
            InitializeComponent();
        }

        private void FrmInformeCuentas_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            Buscar();
        }

        private void Buscar()
        {
            cMovimiento mov = new cMovimiento();
            double Efectivo = mov.GetTotalEfectivo();
            txtEfectivo.Text = Efectivo.ToString();
            txtEfectivo.Text = fun.SepararDecimales(txtEfectivo.Text);
            txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
            cDocumento doc = new cDocumento();
            double ImporteDoc = doc.GetTotalDocumentos();
            txtDocumentos.Text = ImporteDoc.ToString();
            txtDocumentos.Text = fun.SepararDecimales(txtDocumentos.Text);
            txtDocumentos.Text = fun.FormatoEnteroMiles(txtDocumentos.Text);
            cCobroTarjeta cobro = new cCobroTarjeta();
            txtTotalTarjeta.Text = cobro.GetTotal().ToString();
            txtTotalTarjeta.Text = fun.SepararDecimales(txtTotalTarjeta.Text);
            txtTotalTarjeta.Text = fun.FormatoEnteroMiles(txtTotalTarjeta.Text);
            cCheque cheque = new cCheque();
            txtTotalCheque.Text = cheque.GetTotalCheque().ToString();
            txtTotalCheque.Text = fun.SepararDecimales(txtTotalCheque.Text);
            txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);

            cGarantia garantia = new cGarantia();
            txtGarantia.Text = garantia.GetTotalGarantia().ToString();
            txtGarantia.Text = fun.SepararDecimales(txtGarantia.Text);
            txtGarantia.Text = fun.FormatoEnteroMiles(txtGarantia.Text);

            cInsumo insumo = new cInsumo();
            txtTotalInsumo.Text = insumo.GetTotalInsumo().ToString();
            txtTotalInsumo.Text = fun.SepararDecimales(txtTotalInsumo.Text);
            txtTotalInsumo.Text = fun.FormatoEnteroMiles(txtTotalInsumo.Text);

            cVale vale = new cVale();
            txtTotalVale.Text = vale.GetTotalVales().ToString();
            txtTotalVale.Text = fun.SepararDecimales(txtTotalVale.Text);
            txtTotalVale.Text = fun.FormatoEnteroMiles(txtTotalVale.Text);

            cTransferencia tra = new Clases.cTransferencia();
            txtTotalTransferencia.Text = tra.GetTotal().ToString();
            txtTotalTransferencia.Text = fun.SepararDecimales(txtTotalTransferencia.Text);
            txtTotalTransferencia.Text = fun.FormatoEnteroMiles(txtTotalTransferencia.Text);

            cCuentaCorriente cuenta = new cCuentaCorriente();
            Double ImporteCuenta = cuenta.GetTotal();
            txtCuentaCorriente.Text = ImporteCuenta.ToString();
            txtCuentaCorriente.Text = fun.SepararDecimales(txtCuentaCorriente.Text);
            txtCuentaCorriente.Text = fun.FormatoEnteroMiles(txtCuentaCorriente.Text);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
