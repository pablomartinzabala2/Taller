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
    public partial class FrmVenta : Form
    {
        cTabla tabla;
        DataTable tbVenta;
        cFunciones fun;
        DataTable tbTarjeta;
        DataTable tbCheques;
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            FrmBuscarInsumo frm = new FrmBuscarInsumo();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmPrincipal.CodigoPrincipal != null)
            {
                Int32 CodInsumo = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                cInsumo insumo = new cInsumo();
                DataTable trdo = insumo.GetInsumoxCodigo(CodInsumo);
                if (trdo.Rows.Count > 0)
                {
                    txtCodigo.Text = trdo.Rows[0]["CodInsumo"].ToString();
                    txtCantidad.Text = trdo.Rows[0]["Cantidad"].ToString();
                    txt_Precio.Text = trdo.Rows[0]["Precio"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    if (txtCantidad.Text == "")
                        txtCantidad.Text = "0";

                    if (txt_Precio.Text != "")
                    {
                        txt_Precio.Text = fun.SepararDecimales(txt_Precio.Text);
                        txt_Precio.Text = fun.FormatoEnteroMiles(txt_Precio.Text);
                    }
                    AplicarPorcentaje();
                }
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            tabla = new cTabla();
            tbVenta = new DataTable();
            string col = "CodInsumo;Nombre;Cantidad;Precio;Subtotal";
            tbVenta = tabla.CrearTabla(col);
            string ColCheques = "NroCheque;Fecha;Importe";
            tbCheques = tabla.CrearTabla(ColCheques);
            txtFechaAltaOrden.Text = DateTime.Now.ToShortDateString();
            txtFechaCheque.Text = txtFechaAltaOrden.Text;
            txtFechaEmisionTarjeta.Text = txtFechaCheque.Text;
            string ColTarjetas = "CodTarjeta;Nombre;Cupon;Importe;CodCobro;FechaEmision;Recargo";
            tbTarjeta = tabla.CrearTabla(ColTarjetas);
            fun.LlenarCombo(CmbTarjeta, "Tarjeta", "Nombre", "CodTarjeta");
            fun.LlenarCombo(cmbTipoDoc, "tipodocumento", "Nombre", "CodTipoDoc");
            if (Principal.CodigoPrincipalAbm != null)
                BuscarVenta(Convert.ToInt32(Principal.CodigoPrincipalAbm));
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            Int32 Cantidad = 0;
            int Stock = 0;
            Double Precio = 0;
            Double Subtotal = 0;

            if (txt_Nombre.Text == "")
            {
                Mensaje("Deb Ingresar un Insumo");
                return;
            }
            if (txtPrecioVenta.Text == "")
            {
                Mensaje("Debe ingresar un precio de venta");
                return;
            }
            if (txtIngresarStock.Text == "")
            {
                Mensaje("Debe ingresar una cantidad para continuar");
                return;
            }
            Precio = Convert.ToDouble(txtPrecioVenta.Text);

            string CodInsumo = txtCodigo.Text;
            string Nombre = txt_Nombre.Text;

            if (txtCantidad.Text != "")
                Stock = Convert.ToInt32(txtCantidad.Text);

            if (txtIngresarStock.Text != "")
                Cantidad = Convert.ToInt32(txtIngresarStock.Text);

            if (Cantidad > Stock)
            {
                Mensaje("La cantidad ingresada supera el stock actual");
                return;
            }

            if (tabla.Buscar(tbVenta, "CodInsumo", CodInsumo) == true)
            {
                Mensaje("Ya ingreso el insumo");
                return;
            }
            Subtotal = Precio * Cantidad;
            string Val = CodInsumo + ";" + Nombre;
            Val = Val + ";" + Cantidad.ToString() + ";" + Precio.ToString();
            Val = Val + ";" + Subtotal.ToString();

            tbVenta = tabla.AgregarFilas(tbVenta, Val);
            Grilla.DataSource = tbVenta;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodInsumo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbVenta = tabla.EliminarFila(tbVenta, "CodInsumo", CodInsumo);
            Grilla.DataSource = tbVenta;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFechaAltaOrden.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }
            if (tbVenta.Rows.Count == 0)
            {
                Mensaje("Debe ingresar al menos un producto para vender");
                return;
            }

            if (ValidarImportes() == false)
            {
                Mensaje("La forma de pago no coincide con el total a pagar");
                return;
            }
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            Double Total = 0;
            DateTime Fecha = DateTime.Now;
            if (txtTotal.Text != "")
                Total = fun.ToDouble(txtTotal.Text);
            Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
            cVenta venta = new cVenta();
            Int32 CodVenta = 0;
            Int32 CodInsumo = 0;
            Int32 Cantidad = 0;
            Double Precio = 0;
            Double Subtotal = 0;
            Double Efectivo = 0;
            if (txtEfectivo.Text != "")
                Efectivo = fun.ToDouble(txtEfectivo.Text);

            Int32? CodCliente = null;
            con.Open();
            SqlTransaction tranOrden;
            tranOrden = con.BeginTransaction("TranOrden");
            try
            {
                if (txtApellido.Text != "" && txtNombre.Text != "")
                {
                    CodCliente = GrabarCliente(con, tranOrden);
                }
                CodVenta = venta.InsertarVenta(con, tranOrden, Fecha, Total, CodCliente, Efectivo);
                for (int i = 0; i < tbVenta.Rows.Count; i++)
                {
                    if (tbVenta.Rows[i]["CodInsumo"].ToString() != "")
                    {
                        CodInsumo = Convert.ToInt32(tbVenta.Rows[i]["CodInsumo"].ToString());
                        Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"].ToString());
                        Precio = fun.ToDouble(tbVenta.Rows[i]["Precio"].ToString());
                        Subtotal = fun.ToDouble(tbVenta.Rows[i]["Subtotal"].ToString());
                        venta.InsertarDetalleVenta(con, tranOrden, CodVenta, CodInsumo, Cantidad, Precio, Subtotal);
                        GrabarFormaPago(con, tranOrden, null, CodVenta);
                    }

                }
                tranOrden.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
            }
            catch (Exception ex)
            {
                tranOrden.Rollback();
                con.Close();
            }
        }

        private void txtIngresarStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        public Boolean ValidarImportes()
        {
            double Total = 0;
            double Efectivo = 0;
            double Documentos = 0;
            double Cheques = 0;
            double TotalTarjeta = 0;
            double Subtotal = 0;
            double Garantia = 0;

            if (txtTotal.Text != "")
                Total = fun.ToDouble(txtTotal.Text);
            if (txtEfectivo.Text != "")
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            if (txtDocumento.Text != "")
                Documentos = fun.ToDouble(txtDocumento.Text);
            if (txtTotalCheque.Text != "")
                Cheques = fun.ToDouble(txtTotalCheque.Text);
            if (txtTotalTarjeta.Text != "")
                TotalTarjeta = fun.ToDouble(txtTotalTarjeta.Text);

            // if (txtImporteGarantia.Text != "")
            //    Garantia = fun.ToDouble(txtImporteGarantia.Text);
            Subtotal = Efectivo + Cheques + Documentos + TotalTarjeta + Garantia;
            if (Subtotal != Total)
            {
                Mensaje("No coinciden los montos totales a canelar");
                return false;
            }
            return true;
        }

        private void Limpiar()
        {
            tbVenta.Clear();
            tbTarjeta.Clear();
            tbCheques.Clear();
            txtTotal.Text = "";
            txtTotal.Text = "";
            txt_Nombre.Text = "";
            txtCantidad.Text = "";
            txtPrecioVenta.Text = "";
            txtTotal.Text = "";
            txtIngresarStock.Text = "";
            txt_Precio.Text = "";
            txtDireccion.Text = "";
            txtCodigoBarra.Text = "";
            txtCodCliente.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtNroDocumento.Text = "";
            txtDireccion.Text = "";
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            if (CmbTarjeta.SelectedIndex < 1)
            {
                Mensaje("Debe seleccionar una tarjeta");
                return;
            }
            if (txtCupon.Text == "")
            {
                Mensaje("Debe ingresar un cupón");
                return;
            }

            if (txtMontoTarjeta.Text == "")
            {
                Mensaje("Debe ingresar un monto");
                return;
            }
            string CodTarjeta = CmbTarjeta.SelectedValue.ToString();
            if (tabla.Buscar(tbTarjeta, "CodTarjeta", CodTarjeta) == true)
            {
                Mensaje("Ya se ha ingresado la tarjeta");
                return;
            }


            string Nombre = CmbTarjeta.Text;
            string Cupon = txtCupon.Text;
            string Importe = txtMontoTarjeta.Text;
            string FechaEmision = txtFechaEmisionTarjeta.Text;
            string Recargo = txtRecargo.Text;
            string Lista = CodTarjeta + ";" + Nombre + ";" + Cupon + ";" + Importe + ";" + "-1" + ";" + FechaEmision + ";" + Recargo;
            tbTarjeta = tabla.AgregarFilas(tbTarjeta, Lista);

            txtCupon.Text = "";
            txtMontoTarjeta.Text = "";
            txtTotalTarjeta.Text = fun.TotalizarColumna(tbTarjeta, "Importe").ToString();
            grillaTarjetas.DataSource = tbTarjeta;
            grillaTarjetas.Columns[0].Visible = false;
            grillaTarjetas.Columns[4].Visible = false;
            grillaTarjetas.Columns[3].HeaderText = "Importe";
            grillaTarjetas.Columns[5].HeaderText = "Emision";
            grillaTarjetas.Columns[1].Width = 200;
            grillaTarjetas.Columns[2].Width = 170;
            grillaTarjetas.Columns[0].Visible = false;
            grillaTarjetas.Columns[1].Width = 175;
            grillaTarjetas.Columns[4].Visible = false;
            grillaTarjetas.Columns[5].HeaderText = "Emisión";
        }

        private void btnBorrarTarjeta_Click(object sender, EventArgs e)
        {
            if (grillaTarjetas.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodTarjeta = grillaTarjetas.CurrentRow.Cells[0].Value.ToString();
            tbTarjeta = tabla.EliminarFila(tbTarjeta, "CodTarjeta", CodTarjeta);
            grillaTarjetas.DataSource = tbTarjeta;
            // Double Total = fun.TotalizarColumna(tbTarjeta, "Subtotal");
            //  txtTotal.Text = Total.ToString();
        }

        private void GrabarFormaPago(SqlConnection con, SqlTransaction Transaccion, Int32? CodOrden, Int32? CodVenta)
        {
            DateTime Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
            Int32 CodUsuario = 1;

            cMovimiento mov = new cMovimiento();
            string Descripcion = "VENTA DE REPUESTO ";
            Int32 CodCliente = Convert.ToInt32(txtCodCliente.Text);
            // Descripcion = Descripcion + " " + txtApellido.Text;
            //  Descripcion = Descripcion + " " + txtNombre.Text;
            //  Descripcion = Descripcion + ", PATENTE " + txtPatente.Text;
            if (txtEfectivo.Text != "" && txtEfectivo.Text != "0")
            {
                double Efectivo = fun.ToDouble(txtEfectivo.Text);
                mov.GrabarMovimientoTransaccion(con, Transaccion, Efectivo, Descripcion, Fecha, CodUsuario, CodOrden);
            }

            if (txtDocumento.Text != "" && txtDocumento.Text != "0")
            {
                double Importe = fun.ToDouble(txtDocumento.Text);
                cDocumento doc = new cDocumento();
                doc.InsertarDocumentoTransaccion(con, Transaccion, Fecha, Importe, CodOrden, CodCliente, CodVenta);

            }

            if (txtTotalTarjeta.Text != "" && txtTotalTarjeta.Text != "0")
            {

                cCobroTarjeta cobro = new cCobroTarjeta();
                for (int k = 0; k < tbTarjeta.Rows.Count; k++)
                {
                    double ImporteTarjeta = Convert.ToDouble(tbTarjeta.Rows[k]["Importe"].ToString());
                    Int32 Codtarjeta = Convert.ToInt32(tbTarjeta.Rows[k]["CodTarjeta"].ToString());
                    string Cupon = tbTarjeta.Rows[k]["Cupon"].ToString();
                    DateTime FechaEmision = Convert.ToDateTime(tbTarjeta.Rows[k]["FechaEmision"].ToString());
                    Double? Recargo = null;
                    if (tbTarjeta.Rows[k]["Recargo"].ToString() != "")
                    {
                        Recargo = Convert.ToDouble(tbTarjeta.Rows[k]["Recargo"].ToString());
                    }
                    cobro.Registrar(con, Transaccion, CodOrden, Fecha, Codtarjeta, ImporteTarjeta, Cupon, FechaEmision, Recargo, CodCliente, Convert.ToInt32(CodVenta));
                }





            }

            if (txtTotalCheque.Text != "" && txtTotalCheque.Text != "0")
            {
                cCheque cheque = new cCheque();
                for (int i = 0; i < tbCheques.Rows.Count; i++)
                {
                    string NroCheque = tbCheques.Rows[i]["NroCheque"].ToString();
                    DateTime FechaVto = Convert.ToDateTime(tbCheques.Rows[i]["Fecha"].ToString());
                    double Importe = fun.ToDouble(tbCheques.Rows[i]["Importe"].ToString());
                    cheque.InsertarCheque(con, Transaccion, NroCheque, Importe, CodOrden, Fecha, FechaVto, CodCliente,Convert.ToInt32 (CodVenta));
                }
            }
            /*
            if (txtImporteGarantia.Text != "" && txtImporteGarantia.Text != "0")
            {
                double ImporteGarantia = fun.ToDouble(txtImporteGarantia.Text);
                cGarantia objGarantia = new cGarantia();
                objGarantia.Insertar(con, Transaccion, ImporteGarantia, CodOrden, Fecha);
            }
             * */
        }

        private Int32 GrabarCliente(SqlConnection con, SqlTransaction tran)
        {
            Int32 CodCliente = 0;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Telefono = txtTelefono.Text;
            Int32? CodTipoDoc = null;
            string Direccion = "";
            if (cmbTipoDoc.SelectedIndex > 0)
            {
                CodTipoDoc = Convert.ToInt32(cmbTipoDoc.SelectedValue);
            }
            string NroDocumento = txtNroDocumento.Text;
            Direccion = txtDireccion.Text;
            cCliente cli = new cCliente();
            if (txtCodCliente.Text == "")
            {
                CodCliente = cli.InsertarClienteTran(con, tran, Apellido, Nombre, "", Telefono, CodTipoDoc, NroDocumento,Direccion );
            }
            else
            {
                CodCliente = Convert.ToInt32(txtCodCliente.Text);
                cli.ModificarClienteTran(con, tran, CodCliente.ToString(), Apellido, Nombre, "", Telefono, CodTipoDoc, NroDocumento,Direccion );

            }
            txtCodCliente.Text = CodCliente.ToString();
            return CodCliente;
        }

        private void btnBuscarInsumo_Click_1(object sender, EventArgs e)
        {
            FrmBuscarInsumo frm = new FrmBuscarInsumo();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void btnAgregarInsumo_Click_1(object sender, EventArgs e)
        {
            Int32 Cantidad = 0;
            int Stock = 0;
            Double Precio = 0;
            Double Subtotal = 0;

            if (txt_Nombre.Text == "")
            {
                Mensaje("Deb Ingresar un Insumo");
                return;
            }
            if (txtPrecioVenta.Text == "")
            {
                Mensaje("Debe ingresar un precio de venta");
                return;
            }
            if (txtIngresarStock.Text == "")
            {
                Mensaje("Debe ingresar una cantidad para continuar");
                return;
            }
            Precio = Convert.ToDouble(txtPrecioVenta.Text);

            string CodInsumo = txtCodigo.Text;
            string Nombre = txt_Nombre.Text.Replace(";", ".");

            if (txtCantidad.Text != "")
                Stock = Convert.ToInt32(txtCantidad.Text);

            if (txtIngresarStock.Text != "")
                Cantidad = Convert.ToInt32(txtIngresarStock.Text);

            if (Cantidad > Stock)
            {
                Mensaje("La cantidad ingresada supera el stock actual");
                return;
            }

            if (tabla.Buscar(tbVenta, "CodInsumo", CodInsumo) == true)
            {
                Mensaje("Ya ingreso el insumo");
                return;
            }
            Subtotal = Precio * Cantidad;
            string Val = CodInsumo + ";" + Nombre;
            Val = Val + ";" + Cantidad.ToString() + ";" + Precio.ToString();
            Val = Val + ";" + Subtotal.ToString();

            tbVenta = tabla.AgregarFilas(tbVenta, Val);
            Grilla.DataSource = tbVenta;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 320;
            Grilla.Columns[0].Visible = false;
            
        }

        private void btnEliminarInsumo_Click_1(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodInsumo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbVenta = tabla.EliminarFila(tbVenta, "CodInsumo", CodInsumo);
            Grilla.DataSource = tbVenta;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();

        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtNroDocumento.Text.Length <4)
            {
                return;
            }
            int b = 0;
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientexNroDoc(txtNroDocumento.Text);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
                    txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                    txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                    if (trdo.Rows[0]["CodTipoDoc"].ToString() != "")
                    {
                        string CodTipoDoc = trdo.Rows[0]["CodTipoDoc"].ToString();
                        if (cmbTipoDoc.Items.Count > 0)
                        {
                            cmbTipoDoc.SelectedValue = CodTipoDoc;
                        }
                    }
                    b = 1;
                }
            }
            if (b == 0)
            {
                txtCodCliente.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
            }
        }

        private void btnGrabarVenta_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFechaAltaOrden.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }
            if (tbVenta.Rows.Count == 0)
            {
                Mensaje("Debe ingresar al menos un producto para vender");
                return;
            }

            if (txtApellido.Text == "")
            {
                Mensaje("Debe ingresar un apellido");
                return;
            }
            if (txtNombre.Text == "")
            {
                Mensaje("Debe ingresar un nombre");
                return;
            }

            if (ValidarImportes() == false)
            {
                Mensaje("La forma de pago no coincide con el total a pagar");
                return;
            }
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            Double Total = 0;
            cInsumo insumo = new cInsumo();
            DateTime Fecha = DateTime.Now;
            if (txtTotal.Text != "")
                Total = fun.ToDouble(txtTotal.Text);
            Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
            Double Efectivo = 0;
            if (txtEfectivo.Text != "")
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            cVenta venta = new cVenta();
            Int32 CodVenta = 0;
            Int32 CodInsumo = 0;
            Int32 Cantidad = 0;
            Double Precio = 0;
            Double Subtotal = 0;
            Int32? CodCliente = null;
            con.Open();
            SqlTransaction tranOrden;
            tranOrden = con.BeginTransaction("TranOrden");
            try
            {
                if (txtApellido.Text != "" && txtNombre.Text != "")
                {
                    CodCliente = GrabarCliente(con, tranOrden);
                }

                CodVenta = venta.InsertarVenta(con, tranOrden, Fecha, Total, CodCliente, Efectivo);
                for (int i = 0; i < tbVenta.Rows.Count; i++)
                {
                    if (tbVenta.Rows[i]["CodInsumo"].ToString() != "")
                    {
                        CodInsumo = Convert.ToInt32(tbVenta.Rows[i]["CodInsumo"].ToString());
                        Cantidad = Convert.ToInt32(tbVenta.Rows[i]["Cantidad"].ToString());
                        Precio = fun.ToDouble(tbVenta.Rows[i]["Precio"].ToString());
                        Subtotal = fun.ToDouble(tbVenta.Rows[i]["Subtotal"].ToString());
                        venta.InsertarDetalleVenta(con, tranOrden, CodVenta, CodInsumo, Cantidad, Precio, Subtotal);
                        GrabarFormaPago(con, tranOrden, null, CodVenta);
                        insumo.ActualizarStock(con, tranOrden, CodInsumo, (-1) * Cantidad);
                    }

                }
                tranOrden.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Limpiar();
            }
            catch (Exception ex)
            {
                tranOrden.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabación");
            }
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            string CodigoBarra = txtCodigoBarra.Text;
            cInsumo insumo = new cInsumo();
            DataTable trdoIn = insumo.GetInsumoxCodigoBarra(CodigoBarra);
            if (trdoIn.Rows.Count > 0)
            {
                if (trdoIn.Rows[0]["CodInsumo"].ToString() != "")
                {
                    b = 1;
                    Int32 CodInsumo = Convert.ToInt32(trdoIn.Rows[0]["CodInsumo"].ToString());
                    //cInsumo insumo = new cInsumo();
                    DataTable trdo = insumo.GetInsumoxCodigo(CodInsumo);
                    if (trdo.Rows.Count > 0)
                    {
                        txtCodigo.Text = trdo.Rows[0]["CodInsumo"].ToString();
                        txtCantidad.Text = trdo.Rows[0]["Cantidad"].ToString();
                        txt_Precio.Text = trdo.Rows[0]["Precio"].ToString();
                        txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                        if (txtCantidad.Text == "")
                            txtCantidad.Text = "0";

                        if (txt_Precio.Text != "")
                        {
                            txt_Precio.Text = fun.SepararDecimales(txt_Precio.Text);
                            txt_Precio.Text = fun.FormatoEnteroMiles(txt_Precio.Text);
                        }
                        AplicarPorcentaje();
                    }
                }
            }
            if (b == 0)
            {
                txtCodigo.Text = "";
                txtCantidad.Text = "";
                txt_Precio.Text = "";
                txt_Nombre.Text = "";

            }
        }

        private void AplicarPorcentaje()
        {
            double Costo = 0;
            double Venta = 0;
            double Por = 40;
            if (Radio20.Checked == true)
                Por = 20;
            if (txt_Precio.Text != "")
            {
                Costo = fun.ToDouble(txt_Precio.Text);
                Venta = Costo + (Por * Costo / 100);
                Venta = Math.Round(Venta, 0);
                txtPrecioVenta.Text = Venta.ToString();
                txtPrecioVenta.Text = fun.FormatoEnteroMiles(txtPrecioVenta.Text);
            }
        }

        private void radio40_Click(object sender, EventArgs e)
        {
            AplicarPorcentaje();
        }

        private void Radio20_Click(object sender, EventArgs e)
        {
            AplicarPorcentaje();
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (txtNumeroCheque.Text == "")
            {
                Mensaje("Ingresar un cheque");
                return;
            }

            if (fun.ValidarFecha(txtFechaCheque.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }

            if (txtImporteCheque.Text == "")
            {
                Mensaje("Debe ingresar un importe de cheque");
                return;
            }
            if (tabla.Buscar(tbCheques, "NroCheque", txtNumeroCheque.Text) == true)
            {
                Mensaje("Ya se ha ingresado el cheque");
                return;
            }
            string Valores = txtNumeroCheque.Text;
            Valores = Valores + ";" + txtFechaCheque.Text;
            Valores = Valores + ";" + txtImporteCheque.Text;
            tbCheques = tabla.AgregarFilas(tbCheques, Valores);
            GrillaCheques.DataSource = tbCheques;
            txtTotalCheque.Text = fun.TotalizarColumna(tbCheques, "Importe").ToString();
            if (txtTotalCheque.Text != "")
            {
                txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);
            }
            GrillaCheques.Columns[0].Width = 390;
        }

        private void btnQuitarCheque_Click(object sender, EventArgs e)
        {
            if (GrillaCheques.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string nroCheque = GrillaCheques.CurrentRow.Cells[0].Value.ToString();
            tbCheques = tabla.EliminarFila(tbCheques, "NroCheque", nroCheque);
            GrillaCheques.DataSource = tbCheques;
            txtTotalCheque.Text = fun.TotalizarColumna(tbCheques, "Importe").ToString();
            if (txtTotalCheque.Text != "")
            {
                txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);
            }
        }

        private void BuscarVenta(Int32 CodVenta)
        {
            btnGrabarVenta.Enabled = false;
            btnCancelar.Enabled = false;
            tbVenta.Clear();
            cVenta venta = new cVenta();
            DataTable trdo = venta.GetDetalleVenta(CodVenta);
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                string CodInsumo = trdo.Rows[i]["CodInsumo"].ToString();
                string Nombre = trdo.Rows[i]["Nombre"].ToString();
                string Cantidad = trdo.Rows[i]["Cantidad"].ToString();
                string Precio = trdo.Rows[i]["Precio"].ToString();
                string Subtotal = trdo.Rows[i]["Subtotal"].ToString();
                DataRow r = tbVenta.NewRow();
                r[0] = CodInsumo.ToString();
                r[1] = Nombre;
                r[2] = Cantidad;
                r[3] = Precio;
                r[4] = Subtotal;
                tbVenta.Rows.Add(r);
            }
            Grilla.DataSource = tbVenta;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 310;
            DataTable tb = venta.GetVenta(CodVenta);
            if (tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["Efectivo"].ToString() != "")
                {   
                    Double Efectivo = 0;
                    Efectivo = Convert.ToDouble (tb.Rows[0]["Efectivo"].ToString());
                    txtEfectivo.Text = fun.SepararDecimales(Efectivo.ToString());
                    txtEfectivo.Text = fun.FormatoEnteroMiles(Efectivo.ToString());
                }
                if (tb.Rows[0]["CodCliente"].ToString() != "")
                {
                    
                    if (tb.Rows[0]["CodCliente"].ToString() != "")
                    {
                       
                        Int32 CodCliente = Convert.ToInt32(tb.Rows[0]["CodCliente"].ToString());
                        cCliente cliente = new cCliente();
                        DataTable tbCliente = cliente.GetClientexCodigo(CodCliente);
                        if (tbCliente.Rows.Count > 0)
                        {
                            txtCodCliente.Text = tbCliente.Rows[0]["CodCliente"].ToString();
                            txtNombre.Text = tbCliente.Rows[0]["Nombre"].ToString();
                            txtApellido.Text = tbCliente.Rows[0]["Apellido"].ToString();
                            txtNroDocumento.Text = tbCliente.Rows[0]["NroDocumento"].ToString();
                            txtTelefono.Text = tbCliente.Rows[0]["Telefono"].ToString();
                            if (tbCliente.Rows[0]["CodTipoDoc"].ToString() != "")
                            {
                                string CodTipoDoc = tbCliente.Rows[0]["CodTipoDoc"].ToString();
                                if (cmbTipoDoc.Items.Count > 0)
                                {
                                    cmbTipoDoc.SelectedValue = CodTipoDoc;
                                }
                            }
                        }

                    }
                }

                cDocumento doc = new cDocumento();
                DataTable tdoc = doc.GetDocumentoxCodVenta(CodVenta);
                if (tdoc.Rows.Count > 0)
                {
                    if (tdoc.Rows[0]["Importe"].ToString() != "")
                    {
                        Double Importe = Convert.ToDouble(tdoc.Rows[0]["Importe"].ToString());
                        txtDocumento.Text = Importe.ToString();
                        txtDocumento.Text = fun.SepararDecimales(txtDocumento.Text);
                        txtDocumento.Text = fun.FormatoEnteroMiles(txtDocumento.Text);
                    }
                }
                else
                    txtDocumento.Text = "0";
            }
            BuscarTarjetaxCodVenta(CodVenta);
            BuscarCheque(CodVenta);
        }

        private void BuscarTarjetaxCodVenta(Int32 CodVenta)
        {
            string Values = "";
            cCobroTarjeta cobro = new cCobroTarjeta();
            DataTable trdo = cobro.GetCobroTarjetaxCodVenta(CodVenta);
            if (trdo.Rows.Count > 0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    string Tarjeta = trdo.Rows[i]["Nombre"].ToString();
                    string Cupon = trdo.Rows[i]["Cupon"].ToString();
                    string CodTarjeta = trdo.Rows[i]["CodTarjeta"].ToString();
                    string Importe = trdo.Rows[i]["Importe"].ToString();
                    string CodCobro = trdo.Rows[i]["CodCobro"].ToString();
                    string FechaEmision = trdo.Rows[i]["FechaEmision"].ToString();
                    string Recargo = trdo.Rows[i]["Recargo"].ToString();
                    Values = CodTarjeta + ";" + Tarjeta;
                    Values = Values + ";" + Cupon + ";" + Importe;
                    Values = Values + ";" + CodCobro + ";" + FechaEmision;
                    Values = Values + ";" + Recargo;
                    tbTarjeta = fun.AgregarFilas(tbTarjeta, Values);
                }
                grillaTarjetas.DataSource = tbTarjeta;
                grillaTarjetas.Columns[0].Visible = false;
                grillaTarjetas.Columns[1].Width = 175;
                grillaTarjetas.Columns[4].Visible = false;
                grillaTarjetas.Columns[5].HeaderText = "Emisión";
            }
 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void BuscarCheque(Int32 CodVenta)
        {
            string values = "";
            cCheque cheque = new cCheque();
            DataTable trdo = cheque.GetChequexCodVenta(CodVenta);
            if (trdo.Rows.Count >= 0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    string NroCheque = trdo.Rows[i]["NroCheque"].ToString();
                    string Fecha = trdo.Rows[i]["Fecha"].ToString();
                    string Importe = trdo.Rows[i]["Importe"].ToString();
                    values = NroCheque;
                    values = values + ";" + Fecha ;
                    values = values + ";" + Importe ;  
                      tbCheques = fun.AgregarFilas(tbCheques, values);
                }
                GrillaCheques.DataSource = tbCheques;
                txtTotalCheque.Text = fun.TotalizarColumna(tbCheques, "Importe").ToString();
                if (txtTotalCheque.Text != "")
                {
                    txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);
                }
                GrillaCheques.Columns[0].Width = 390;
            }
        }
    }
}
