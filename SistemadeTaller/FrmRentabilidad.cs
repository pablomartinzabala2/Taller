﻿using System;
using SistemadeTaller.Clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemadeTaller
{
    public partial class FrmRentabilidad : Form
    {
        public FrmRentabilidad()
        {
            InitializeComponent();
        }

        private void FrmRentabilidad_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            DateTime fecha1 = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha1.ToShortDateString();
            txtFechaHasta.Text = fecha.ToShortDateString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaDesde.Text) == false)
            {
                MessageBox.Show("Fecha desde incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                MessageBox.Show("Fecha hasta incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (Convert.ToDateTime(txtFechaDesde.Text) > Convert.ToDateTime(txtFechaHasta.Text))
            {
                MessageBox.Show("La fecha desde debe ser inferior a la fecha hasta", Clases.cMensaje.Mensaje());
                return;
            }
            GetRentabilidad();
        }

        private void GetRentabilidad()
        {
            cCobroTarjeta objCobro = new cCobroTarjeta();
            Clases.cFunciones fun = new Clases.cFunciones ();
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            cOrden orden = new cOrden();
            txtCantidad.Text = orden.CantidadOrdenes(FechaDesde, FechaHasta).ToString();
            
            double Efectivo = orden.GetTotalEfectivo(FechaDesde, FechaHasta);
            txtEfectivo.Text = Efectivo.ToString();
            if (txtEfectivo.Text != "")
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);

            double TotalTarjeta =0;
            cCobroTarjeta cobro = new cCobroTarjeta ();
            TotalTarjeta = cobro.GetTotalTarjeta(FechaDesde, FechaHasta);
            
            //
            Double Saldo = cobro.GetSaldoxFecha(FechaDesde ,FechaHasta);
            txtDiferenciaTarjeta.Text = Saldo.ToString();
            
            TotalTarjeta = TotalTarjeta - Saldo;
            txtTarjeta.Text = TotalTarjeta.ToString(); 
            if (txtTarjeta.Text != "")
                txtTarjeta.Text = fun.FormatoEnteroMiles(txtTarjeta.Text);

            if (txtDiferenciaTarjeta.Text != "")
                txtDiferenciaTarjeta.Text = fun.FormatoEnteroMiles(txtDiferenciaTarjeta.Text);

            cDocumento doc = new cDocumento();
            double ImporteDocu = doc.GetTotalDocumento(FechaDesde, FechaHasta);
            txtImporteDocumento.Text = ImporteDocu.ToString();

            if (txtImporteDocumento.Text != "")
                txtImporteDocumento.Text = fun.FormatoEnteroMiles(txtImporteDocumento.Text);

            cCheque cheque = new cCheque();
            double ImporteCheque = cheque.GetTotalChequexFecha(FechaDesde, FechaHasta);
            txtcheque.Text = ImporteCheque.ToString();
            if (txtcheque.Text != "")
                txtcheque.Text = fun.FormatoEnteroMiles(txtcheque.Text);

           

            cGarantia garantia = new cGarantia();
            double ImporteGarantia = garantia.GetTotalGarantiaxFecha(FechaDesde, FechaHasta);
            txtGarantia.Text = ImporteGarantia.ToString();

            if (txtGarantia.Text != "")
                txtGarantia.Text = fun.FormatoEnteroMiles(txtGarantia.Text);

            double TotalFacturado = Efectivo + TotalTarjeta + ImporteDocu + ImporteCheque + ImporteGarantia;
            txtTotalFacturado.Text = TotalFacturado.ToString();
            if (txtTotalFacturado.Text != "")
                txtTotalFacturado.Text = fun.FormatoEnteroMiles(txtTotalFacturado.Text);

            double GananciaInsumos = orden.GetGananciaInsumo(FechaDesde, FechaHasta);
            double RecargoTarjeta = objCobro.GetTotalRecargoTarjeta(FechaDesde, FechaHasta);
            
            txtGananciaInsumos.Text = GananciaInsumos.ToString();

            if (txtGananciaInsumos.Text != "")
                txtGananciaInsumos.Text = fun.FormatoEnteroMiles(txtGananciaInsumos.Text);
            
            double GananciaMo = orden.GetGananciaManoObra(FechaDesde, FechaHasta);
            txtManoObra.Text = GananciaMo.ToString();

            if (txtManoObra.Text != "")
                txtManoObra.Text = fun.FormatoEnteroMiles(txtManoObra.Text);

            double TotalGanancia = GananciaInsumos + GananciaMo + RecargoTarjeta  - Saldo;
            txtTotalGanancia.Text = TotalGanancia.ToString();
            if (txtTotalGanancia.Text != "")
                txtTotalGanancia.Text = fun.FormatoEnteroMiles(txtTotalGanancia.Text);

            double GastoAlquiler = 0;
            cGastosNegocio gasto = new cGastosNegocio();
            Int32? CodEntidad = 11;
            GastoAlquiler = gasto.GetGastosNegocio(FechaDesde, FechaHasta, CodEntidad);
            txtGastoAlquiler.Text = GastoAlquiler.ToString();
            if (txtGastoAlquiler.Text != "")
                txtGastoAlquiler.Text = fun.FormatoEnteroMiles(txtGastoAlquiler.Text);
             
            double Sueldos = 0;
            CodEntidad = 6;
 
            Sueldos = gasto.GetGastosNegocio(FechaDesde, FechaHasta, CodEntidad);
            txtSueldo.Text = Sueldos.ToString();
            if (txtSueldo.Text != "")
                txtSueldo.Text = fun.FormatoEnteroMiles(txtSueldo.Text);
             
            double Combustible = 0;
            CodEntidad = 13;

            Combustible = gasto.GetGastosNegocio(FechaDesde, FechaHasta, CodEntidad);
            txtCombustible.Text = Combustible.ToString();
            if (txtCombustible.Text != "")
                txtCombustible.Text = fun.FormatoEnteroMiles(txtCombustible.Text);

            double Impuestos = 0;
            CodEntidad = 2;
             
            Impuestos = gasto.GetGastosNegocio(FechaDesde, FechaHasta, CodEntidad);
            txtImpuesto.Text = Impuestos.ToString();
            if (txtImpuesto.Text != "")
                txtImpuesto.Text = fun.FormatoEnteroMiles(txtImpuesto.Text);

            double Varios = 0;
            CodEntidad = null;
             
            Varios = gasto.GetGastosNegocio(FechaDesde, FechaHasta, CodEntidad);
            Varios = Varios - Sueldos - Impuestos - Combustible - GastoAlquiler;
            txtOtrosGastos.Text = Varios.ToString();
            if (txtOtrosGastos.Text != "")
                txtOtrosGastos.Text = fun.FormatoEnteroMiles(txtOtrosGastos.Text);
            double TotalGastos = 0;
            TotalGastos = Varios + Sueldos + Impuestos + Combustible + GastoAlquiler; //+Saldo;
            txtTotalGastos.Text = TotalGastos.ToString();
            if (txtTotalGastos.Text != "")
                txtTotalGastos.Text = fun.FormatoEnteroMiles(txtTotalGastos.Text);

            double Rentabilidad = TotalGanancia - TotalGastos;
            txtRentabilidad.Text = Rentabilidad.ToString();
            if (txtRentabilidad.Text != "")
                txtRentabilidad.Text = fun.FormatoEnteroMiles(txtRentabilidad.Text);

            double SaldoGarantia = garantia.GetTotalSaldoGarantiaxFecha(FechaDesde, FechaHasta);
            txtSaldoGarantia.Text = SaldoGarantia.ToString();

            if (txtSaldoGarantia.Text != "")
                txtSaldoGarantia.Text = fun.FormatoEnteroMiles(txtSaldoGarantia.Text);
            
            double  TotalSaldoTarjeta = cobro.GetTotalSaldoTarjeta(FechaDesde, FechaHasta);
            txtSaldoTarjeta.Text = TotalSaldoTarjeta.ToString();

            if (txtSaldoTarjeta.Text != "")
                txtSaldoTarjeta.Text = fun.FormatoEnteroMiles(txtSaldoTarjeta.Text);
             
            double ImporteSaldoDoc = doc.GetTotalSaldoDocumento(FechaDesde, FechaHasta);
            txtSaldoDocumento.Text = ImporteSaldoDoc.ToString();

            if (txtSaldoDocumento.Text != "")
                txtSaldoDocumento.Text = fun.FormatoEnteroMiles(txtSaldoDocumento.Text);
             
            double ImporteSaldoCheque = cheque.GetTotalSaldoChequexFecha(FechaDesde, FechaHasta);
            txtSaldoCheque.Text = ImporteSaldoCheque.ToString();
            if (txtSaldoCheque.Text != "")
                txtSaldoCheque.Text = fun.FormatoEnteroMiles(txtSaldoCheque.Text);
        
        }
    }
}