using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SistemadeTaller.Clases; 
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemadeTaller
{
    public partial class FrmEjecutarOrden : Form
    {
        cFunciones fun;
        public FrmEjecutarOrden()
        {
            InitializeComponent();
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void FrmEjecutarOrden_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            DateTime fecha = DateTime.Now;
            txtFechaHasta.Text = fecha.ToShortDateString();
            fecha = fecha.AddMonths(-1);
            txtFechaDesde.Text = fecha.ToShortDateString();
            lblAmarillo.BackColor  = System.Drawing.Color.Yellow;
            lblOrdenesConSaldo.BackColor  = System.Drawing.Color.LightGreen;
            lblOrdenesSinSaldo.BackColor = System.Drawing.Color.LightGray;
            DataTable ttipo = fun.CrearTabla("Codigo;Nombre");
            ttipo = fun.AgregarFilas(ttipo, "1;Pre Ingresadas");
            ttipo = fun.AgregarFilas(ttipo, "2;Con Saldo");
            ttipo = fun.AgregarFilas(ttipo, "3;Sin Saldo");
            fun.LlenarComboDatatable(CmbTipo, ttipo, "Nombre", "Codigo");
            ValidarUsuario();
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void Buscar()
        {
            if (fun.ValidarFecha(txtFechaDesde.Text) == false)
            {
                Mensaje("La fecha desde es incorrecta");
                return;
            }

            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                Mensaje("La fecha hasta es incorrecta");
                return;
            }

            DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string Patente = "";
            if (txtPatente.Text != "")
                Patente = txtPatente.Text;
            string Apellido = "";
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;
            Int32? CodOrden = null;
            if (txtNroOrden.Text != "")
                CodOrden = Convert.ToInt32(txtNroOrden.Text);
            Int32? Tipo = null;
            if (CmbTipo.SelectedIndex > 0)
                Tipo = Convert.ToInt32(CmbTipo.SelectedValue);
            cOrden orden = new cOrden();
            DataTable trdo = orden.GetOrdenxFecha(fechaDesde, fechaHasta, Patente, Apellido, CodOrden,Tipo);
            if (Tipo == 2)
            {
                for (int k = 0; k < trdo.Rows.Count; k++)
                {
                    if (Convert.ToDouble(trdo.Rows[k]["Saldo"].ToString()) == 0)
                    {
                        trdo.Rows[k].Delete();
                    }
                }
                trdo.AcceptChanges();
            }

            if (Tipo == 3)
            {
                for (int k = 0; k < trdo.Rows.Count; k++)
                {
                    if (Convert.ToDouble(trdo.Rows[k]["Saldo"].ToString()) > 0)
                    {
                        trdo.Rows[k].Delete();
                    }
                }
                trdo.AcceptChanges();
            }
            

            trdo = fun.TablaaMiles(trdo, "Costo");
            trdo = fun.TablaaMiles(trdo, "Venta");
            trdo = fun.TablaaMiles(trdo, "ManoObra");
            trdo = fun.TablaaMiles(trdo, "Ganancia");
            trdo = fun.TablaaMiles(trdo, "Efectivo");
            trdo = fun.TablaaMiles(trdo, "Documento");
            trdo = fun.TablaaMiles(trdo, "Cheque");
            trdo = fun.TablaaMiles(trdo, "Tarjeta");
            trdo = fun.TablaaMiles(trdo, "Garantia");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            if (Tipo == 2)
            {
                
            }
            grdOrdenes.DataSource = trdo;
            grdOrdenes.Columns[0].HeaderText = "Orden";
            grdOrdenes.Columns[0].Width = 80;
            grdOrdenes.Columns[4].Width = 60;
            grdOrdenes.Columns[5].Visible = false;
            grdOrdenes.Columns[3].Visible = false;
            grdOrdenes.Columns[7].Visible = false;
            txtTotal.Text = fun.TotalizarColumna(trdo, "Ganancia").ToString();
            txtTotal.Text = fun.SepararDecimales(txtTotal.Text);
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            txtCantidad.Text = trdo.Rows.Count.ToString();
            VerificarUsuario();
            Pintar();
            PintarOrdenesSinSaldo();
            
        }

        private void btnVetOrden_Click(object sender, EventArgs e)
        {
            if (grdOrdenes.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Int32 CodOrden = Convert.ToInt32(grdOrdenes.CurrentRow.Cells[0].Value.ToString());
            frmPrincipal.CodigoPrincipal = CodOrden.ToString();
            FrmIngresoOrden frm = new FrmIngresoOrden();
            frm.ShowDialog();
        }

        private void btnImprimirOrden_Click(object sender, EventArgs e)
        {
            if (grdOrdenes.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Int32 CodOrden = Convert.ToInt32(grdOrdenes.CurrentRow.Cells[0].Value.ToString());
            frmPrincipal.CodigoPrincipal = CodOrden.ToString();
            FrmReporteOrden frm = new FrmReporteOrden();
            frm.Show();
        }

        public void VerificarUsuario()
        {
            cUsuario usu = new cUsuario();
            Int32 CodUsuario = Convert.ToInt32(Principal.CodUsuarioLogueado);
             string Nombre= usu.GetNombreUsuarioxCodUsuario(CodUsuario);
             if (Nombre.ToUpper() != "SERGIO")
             {
                 lblTotal.Visible = false;
                 txtTotal.Visible = false;;
                 grdOrdenes.Columns[11].Visible = false;
                 grdOrdenes.Columns[0].Width = 200;
             }
        }

        private void Pintar()
        {
            for (int i = 0; i < grdOrdenes.Rows.Count - 1; i++)
            {
                if (grdOrdenes.Rows[i].Cells[12].Value.ToString() == "1")
                {
                    grdOrdenes.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void txtNroOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void PintarOrdenesSinSaldo()
        {
            Int32 CodOrden = 0;
            double SaldoTarjeta = 0;
            double SaldoDocumento = 0;
            double SaldoCheque = 0;
            double SaldoGarantia = 0;
            double Suma = 0;
            for (int i = 0; i < grdOrdenes.Rows.Count - 1; i++)
            {
                CodOrden = Convert.ToInt32(grdOrdenes.Rows[i].Cells[0].Value.ToString ());
                SaldoTarjeta = GetSaldoTarjeta(CodOrden);
                SaldoDocumento = GetSaldoDocumento(CodOrden);
                SaldoCheque = GetSaldoCheque(CodOrden);
                SaldoGarantia = GetSaldoGarantia(CodOrden);
                Suma = SaldoTarjeta + SaldoDocumento + SaldoCheque + SaldoGarantia;
                if (Suma == 0)
                {
                    //string xxx = grdOrdenes.Rows[i].Cells["Procesada"].Value.ToString();
                    if (grdOrdenes.Rows[i].Cells["Procesada"].Value.ToString() == "1")
                        grdOrdenes.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        grdOrdenes.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                    
            }
        }

        private double GetSaldoTarjeta(Int32 CodOrden)
        {
            cCobroTarjeta cobro = new cCobroTarjeta ();
            double Saldo = cobro.GetSaldoTarjetaxCodOrden (CodOrden);
            return Saldo;
        }

        private double GetSaldoDocumento(Int32 CodOrden)
        {
            double Saldo = 0;
            cDocumento doc = new cDocumento();
            Saldo = doc.GetSaldoDocumentoxCodOrden(CodOrden);
            return Saldo;
        }

        private double GetSaldoCheque(Int32 CodOrden)
        {
            cCheque cheque = new cCheque();
            double Saldo = 0;
            Saldo = cheque.GetSaldoChequexCodOrden(CodOrden);
            return Saldo;
        }

        private double GetSaldoGarantia(Int32 CodOrden)
        {
            double Saldo = 0;
            cGarantia garantia = new cGarantia();
            Saldo = garantia.GetSaldoGarantiaxCodOrden(CodOrden);
            return Saldo;
        }

        private void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            string msj = "Confirma Eliminar la orden ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                if (grdOrdenes.CurrentRow == null)
                {
                    Mensaje("Debe seleccionar un registro");
                    return;
                }
                Int32 CodOrden = Convert.ToInt32(grdOrdenes.CurrentRow.Cells[0].Value.ToString());
                EliminarOrden(CodOrden);
            }
            catch (Exception ex)
            {
                Mensaje("Hubo un error en el proceso de anulaciñon");
                Mensaje(ex.Message);
            }
        }

        private void EliminarOrden(Int32 CodOrden)
        {
            Double ImporteCobrodoDocumento = 0;
            Int32 CodDocumentoa = 0;
            Double ImporteEfectivoOrden = 0;
            Double ImporteCobradoTarjeta = 0;
            Double ImporteGatantia = 0;
            Double ImporteCheque = 0;

            cOrden orden = new cOrden();
            cCobroDocumento cob = new cCobroDocumento();
            cCobroTarjeta cobTarj = new cCobroTarjeta();
            cGarantia garantia = new Clases.cGarantia();
            cCobroCheque cobroCheque = new cCobroCheque();
            cCheque cheque = new cCheque();

            ImporteEfectivoOrden = orden.GetTotalEfectivoOrden(CodOrden);
            ImporteCobrodoDocumento = cob.GetTotalDocumentoCobrado(CodOrden);
            CodDocumentoa = cob.GetCodDocumentoxCodOrden(CodOrden);
            ImporteCobradoTarjeta = cobTarj.GetImporteCobradoxCodOrden(CodOrden);
            ImporteGatantia = garantia.GetImporteCobradoxCodOrden(CodOrden);
            ImporteCheque = cobroCheque.GetTotalChequeCobrado(CodOrden);

            cMovimiento mov = new cMovimiento();
            cDocumento doc = new cDocumento();
            

            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            DateTime  Fecha = DateTime.Now;
            string Descripcion = "";
            con.Open();
            SqlTransaction tran;
            tran = con.BeginTransaction("TranOrden");
            try
            {
                if (ImporteEfectivoOrden >0)
                {
                    Descripcion = "Anulación Cobro de efectivo, Orden " + CodOrden.ToString();
                    mov.GrabarMovimientoTransaccion(con, tran, -1 * ImporteEfectivoOrden, Descripcion, Fecha, Principal.CodUsuarioLogueado, null);
                }

                if (ImporteCobradoTarjeta > 0)
                {
                    Descripcion = "Anulación Cobro de tarjeta, Orden " + CodOrden.ToString();
                    mov.GrabarMovimientoTransaccion(con, tran, -1 * ImporteCobradoTarjeta, Descripcion, Fecha, Principal.CodUsuarioLogueado, null);
                   
                }

                if (ImporteGatantia>0)
                {
                    Descripcion = "Anulación Cobro de garantía, Orden " + CodOrden.ToString();
                    mov.GrabarMovimientoTransaccion(con, tran, -1 * ImporteGatantia, Descripcion, Fecha, Principal.CodUsuarioLogueado, null);
                    
                }

                if (ImporteCheque >0)
                {
                    //saco los codcheque para borrar los cobros cheques
                    DataTable tbcheque = cheque.GetChquesxCodOrden(CodOrden);
                    if (tbcheque.Rows.Count >0)
                    {
                        for (int i=0;i< tbcheque.Rows.Count;i++)
                        {
                            if (tbcheque.Rows[i]["CodCheque"].ToString ()!="")
                            {
                                Int32 CodCheque = Convert.ToInt32(tbcheque.Rows[i]["CodCheque"].ToString());
                                cobroCheque.BorrarCobroCheque(con, tran, CodCheque);
                            }
                        }
                       
                    }
                    
                    Descripcion = "Anulación Cobro de cheque, Orden " + CodOrden.ToString();
                    mov.GrabarMovimientoTransaccion(con, tran, -1 * ImporteCheque, Descripcion, Fecha, Principal.CodUsuarioLogueado, null);
                }

                if (ImporteCobrodoDocumento >0)
                {
                    Descripcion = "Anulación Cobro de Documento, Orden " + CodOrden.ToString();
                    cob.BorrarCobroDocumentoxCodDocumento(con,tran , CodDocumentoa);
                    mov.GrabarMovimientoTransaccion(con, tran, -1 * ImporteCobrodoDocumento, Descripcion, Fecha, Principal.CodUsuarioLogueado, null);
                   
                }

                garantia.BorrarGarantia(con, tran, CodOrden);
                cheque.BorrarchquexCodOrden(con, tran, CodOrden);
                doc.BorrarDocumentoxCodOrden(con, tran, CodOrden);
                cobTarj.BorrarCobroTarjeta(con, tran, CodOrden);
                orden.EliminarOrden(con, tran, CodOrden);
                tran.Commit();
                Mensaje("Orden de Trabajo eliminada correctamente, se actualizaron las cuentas");
                con.Close();
                Buscar();
            }
            catch (Exception)
            {
                tran.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de anulación");
                throw;
            }
        }

        private void BorrarCobroDocumento(SqlConnection con,SqlTransaction tran,Int32 CodOrden)
        {
            
        }

        private void ValidarUsuario()
        {
            Int32 CodUsuario = Principal.CodUsuarioLogueado;
            cUsuario usu = new Clases.cUsuario();
            string Nombre = usu.GetNombreUsuarioxCodUsuario(CodUsuario);
            if (Nombre.ToUpper()=="SERGIO")
            {
                btnEliminarOrden.Visible = true;
            }
        }

        private void btnImprimirSolicitud_Click(object sender, EventArgs e)
        {
            if (grdOrdenes.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Int32 CodOrden = Convert.ToInt32(grdOrdenes.CurrentRow.Cells[0].Value.ToString());
            frmPrincipal.CodigoPrincipal = CodOrden.ToString();
            FrmVerReporteSolicitud frm = new FrmVerReporteSolicitud();
            frm.Show();
        }
    }
}
