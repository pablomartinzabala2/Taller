using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemadeTaller.Clases;

namespace SistemadeTaller
{
    public partial class FrmIngresoOrden : Form
    {
        #region Variables

        cFunciones fun;
        cTabla tabla;
        //cTabla tablaOrden;
        DataTable tablaOrdenDetalle;
        DataTable tbInsumos;
        DataTable tbTarjeta;
        DataTable tbCheques;
        DataTable tbDetallePresupuesto;
        DataTable tbEfectivo;
        DataTable tbTransferencia;
        Boolean ConfirmaOrden;
        //DataTable tbOrden;
        DataTable tbOrdenDetalle;
        DataTable tbReparacion;
        Boolean MuestraColumnaCosto;
        #endregion

        #region Constructores

        public FrmIngresoOrden()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            fun = new cFunciones();

            fun.LlenarCombo(CmbMarca, "Marca", "Nombre", "CodMarca");
            fun.LlenarCombo(cmbTipoCombustible , "TipoCombustible", "Nombre", "Codigo");
            fun.LlenarCombo(cmbTipoDoc, "TipoDocumento", "Nombre", "CodTipoDoc");
            fun.LlenarCombo(CmbTipoDocumento, "TipoDocumento", "Nombre", "CodTipoDoc");
            cMecanico mec = new cMecanico();
            
            fun.LlenarComboDatatable(CmbMecanico, mec.GetMecanicosActivos(), "Apellido", "CodMecanico");
            cInsumo insumo = new cInsumo ();
            cTarjeta tarjeta = new cTarjeta();
            
            if (CmbTipoDocumento.Items.Count >0)
                CmbTipoDocumento.SelectedIndex = 0;
            fun.LlenarComboDatatable(CmbTarjeta, tarjeta.GetTarjetas(), "Nombre", "CodTarjeta"); 

            txtFechaAltaOrden.Text = DateTime.Now.ToShortDateString();
            txtFechaEntrega.Text = txtFechaAltaOrden.Text; 
            txtFechaEmisionTarjeta.Text = txtFechaAltaOrden.Text; 
            tabla = new cTabla();
            tablaOrdenDetalle = new DataTable();
            tbTarjeta = new DataTable();
            //string ColumnasOrden = "CodOrden;CodCliente;CodMecanico;Fecha";
            string ColumnasOrdenDetalle = "CodTarea;Descripcion";

            //tbOrden = tablaOrden.CrearTabla(ColumnasOrden);
            tbOrdenDetalle = tabla.CrearTabla(ColumnasOrdenDetalle);
            
            string ColInsumos = "CodInsumo;Nombre;Cantidad;PrecioCosto;PrecioVenta;PrecioManoObra;ActualizaStock";
            tbInsumos = tabla.CrearTabla(ColInsumos);
             
            string ColCheques = "NroCheque;Fecha;Importe";
            tbCheques = tabla.CrearTabla(ColCheques);
            cOrden ord = new cOrden();
            Int32 CodOrden = ord.GetMaxOrden();
            lblOrden.Text = "Orden Número " + CodOrden.ToString();
            string ColTarjetas = "CodTarjeta;Nombre;Cupon;Importe;CodCobro;FechaEmision;Recargo";
            tbTarjeta = tabla.CrearTabla(ColTarjetas);
            string ColDetallePresupuesto = "CodArreglo;Nombre;Precio";
            tbDetallePresupuesto = fun.CrearTabla(ColDetallePresupuesto);
            tabPageCliente.Focus();
            MuestraColumnaCosto = false;
            string ColEfectivo = "CodOrden;Fecha;Importe;CodPago;Descripcion";
            tbEfectivo = fun.CrearTabla(ColEfectivo);
            string ColTransfer = "CodOrden;Fecha;Importe;CodPago;Descripcion";
            tbTransferencia = fun.CrearTabla(ColTransfer);
            tbReparacion = fun.CrearTabla("CodReparacion;Nombre;FormaPago");
            if (frmPrincipal.CodigoPrincipal != null)
            {
                 CodOrden = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                BuscarOrden(CodOrden);
            }
            
        }

        private void BuscarReparacion(Int32 CodOrden)
        {
            cTabla tabla = new cTabla();
            cReparacion rep = new cReparacion();
            DataTable trdo = rep.GetReparacion(CodOrden);
            int b = 0;
            int con = 0;
            for (int i=0;i<trdo.Rows.Count;i++)
            {
                if(trdo.Rows[i]["CodReparacion"].ToString ()!="")
                {
                    b = 1;
                    string Cod = trdo.Rows[i]["CodReparacion"].ToString();
                    string Nom = trdo.Rows[i]["Nombre"].ToString();
                    string Val = Cod + ";" + Nom;
                    tabla.AgregarFilas(tbReparacion, Val);
                    con++;
                }
            }
            
            if (b==1)
            {
                GrillaDetalleReparacion.DataSource = tbReparacion;
                cFunciones fun = new cFunciones();
                fun.AnchoColumnas(GrillaDetalleReparacion, "0;100");
            }
        }

        #endregion

        #region Metodos Privados

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private Boolean Validar()
        {
            cFunciones fun = new cFunciones();
            if (fun.ValidarFecha (txtFechaAltaOrden.Text)==false)
            {
                Mensaje("la fecha de ingreso de la orden es incorrecta");
                return false;
            }
            
            if (fun.ValidarFecha(txtFechaEntrega.Text) == false)
            {
                Mensaje("la fecha de ingreso de la orden es incorrecta");
                return false;
            }

            if (txtApellido.Text.ToString() == "")
            {
                Mensaje("Debe ingresar apellido");
                txtApellido.Focus();
                return false;
            }

            if (txtNombre.Text.ToString() == "")
            {
                Mensaje("Debe ingresar nombre");
                txtNombre.Focus();
                return false;
            }

            if (txtTelefono.Text.ToString() == "")
            {
                Mensaje("Debe ingresar teléfono");
                txtTelefono.Focus();
                return false;
            }

            if (txtPatente.Text == "")
            {
                Mensaje("Debe ingresar una patente");
                txtPatente.Focus();
                return false;
            }

            if (txtKms.Text == "")
            {
                Mensaje("Debe ingresar un kilómetros");
                return false;
            }

            if (txtDescripcionVehiculo.Text.ToString() == "")
            {
                Mensaje("Debe ingresar una descripción");
                txtDescripcionVehiculo.Focus();
                return false;
            }

            if (CmbMarca.SelectedIndex <= 0)
            {
                Mensaje("Debe seleccionar una marca");
                CmbMarca.Focus();
                return false;
            }

            

            if (CmbMecanico.SelectedIndex < 1)
            {
                Mensaje("Debe seleccionar un mecánico");
                return false;
            };

            if (ConfirmaOrden ==true)
            if (txtMontoTarjeta.Text != "0" && txtMontoTarjeta.Text != "")
            {
                if (CmbTarjeta.SelectedIndex < 1)
                {
                    Mensaje("Debe seleccionar una tarjeta para continuar");
                    return false; 
                }
            }

            if (ConfirmaOrden == true) 
            if (ValidarImportes() == false)
                return false;

            return true;
        }

        private void NuevaMarca()
        {
            Principal.CampoIdSecundario = "CodMarca";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Marca";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void BuscarVehiculo()
        {
            cAuto auto = new cAuto();

            StringBuilder patente = new StringBuilder();

            patente.Append(txtPatente.Text.ToString());

            if (patente.Length > 4)
            {
                DataTable trVehiculo = new DataTable();
                
                trVehiculo = auto.GetAutoxPatente(patente.ToString());

                if (trVehiculo.Rows.Count > 0)
                {
                    txtCodAuto.Text = trVehiculo.Rows[0]["CodAuto"].ToString();
                    txtDescripcionVehiculo.Text = trVehiculo.Rows[0]["Descripcion"].ToString();
                    CmbMarca.SelectedValue = trVehiculo.Rows[0]["CodMarca"].ToString();
                    txtChasis.Text = trVehiculo.Rows[0]["Chasis"].ToString();
                    txtKms.Text = trVehiculo.Rows[0]["Kilometros"].ToString();
                    txtMotor.Text = trVehiculo.Rows[0]["Motor"].ToString();
                    if (trVehiculo.Rows[0]["CodTipoCombustible"].ToString()!="")
                    {
                        string Cod = trVehiculo.Rows[0]["CodTipoCombustible"].ToString();
                        if (cmbTipoCombustible.Items.Count > 0)
                            cmbTipoCombustible.SelectedValue = Cod;
                    }
                    if (trVehiculo.Rows[0]["CodCliente"].ToString() != "")
                    {
                        Int32 CodCliente = Convert.ToInt32(trVehiculo.Rows[0]["CodCliente"].ToString());
                        string NroDoc = trVehiculo.Rows[0]["NroDoc"].ToString();
                        txtNroDoc.Text = NroDoc;
                       // BuscarClixCodigo(CodCliente);
                    }
                }
                else
                {
                    txtCodAuto.Text = String.Empty;
                    txtDescripcionVehiculo.Text = "";
                    CmbMarca.SelectedIndex = 0;
                }

                trVehiculo = null;
            }

            patente = null;
            auto = null;
        }

        private void BuscarClixCodigo(Int32 CodCliente)
        {
            cCliente cli = new Clases.cCliente();
            DataTable trdo = cli.GetClientexCodigo(CodCliente);
            if (trdo.Rows.Count >0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                txtDireccion.Text = trdo.Rows[0]["Direccion"].ToString();
            }
        }

        private void BuscarCliente()
        {
            if (cmbTipoDoc.SelectedIndex == 0)
                return;

            cCliente cliente = new cCliente();

            StringBuilder nroDocumento = new StringBuilder();
            StringBuilder tipoDocumento = new StringBuilder();

            nroDocumento.Append(txtNroDocumento.Text.ToString());
            tipoDocumento.Append(cmbTipoDoc.SelectedIndex.ToString());

            if (nroDocumento.Length > 7)
            {
                DataTable trCliente = new DataTable();

                trCliente = cliente.GetCliente(nroDocumento.ToString(), tipoDocumento.ToString());

                if (trCliente.Rows.Count > 0)
                {
                    txtCodCliente.Text = trCliente.Rows[0]["CodCliente"].ToString();
                    txtApellido.Text = trCliente.Rows[0]["Apellido"].ToString();
                    txtNombre.Text = trCliente.Rows[0]["Nombre"].ToString();
                    txtTelefono.Text = trCliente.Rows[0]["Telefono"].ToString();
                }
                else
                {
                    txtCodCliente.Text = String.Empty;
                    txtApellido.Text = String.Empty;
                    txtNombre.Text = String.Empty;
                    txtTelefono.Text = String.Empty;
                }

                trCliente = null;
            }

            nroDocumento = null;
            tipoDocumento = null;
            cliente = null;
        }

        private void NuevaTarea()
        {
            Principal.CampoIdSecundario = "CodTarea";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Tarea";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        
        private void GrabarOrden()
        {
           // Buscarcliente();
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlTransaction tranOrden;
                tranOrden = con.BeginTransaction("TranOrden");

                try
                {
                    cCliente cliente = new cCliente();

                    string apellidoCli = "";
                    string nombreCli = "";
                    string direccionCli = "";
                    string telefonoCli = "";
                    string nroDocumentoCli = "";
                    string tipoDocumentoCli = "";
                    string Direccion = "";
                    if (txtCodCliente.Text.Trim() == "")
                    {
                        //Inserta un cliente.

                        apellidoCli = txtApellido.Text.ToString();
                        nombreCli = txtNombre.Text.ToString();
                        Direccion = txtDireccion.Text; 
                        direccionCli = "";
                        telefonoCli = txtTelefono.Text.ToString();
                        nroDocumentoCli = txtNroDoc.Text;
                        tipoDocumentoCli = null;
                        Int32? CodTipoDoc = null; 
                        if (CmbTipoDocumento.SelectedIndex > 0)
                            CodTipoDoc = Convert.ToInt32(CmbTipoDocumento.SelectedIndex);
                        txtCodCliente.Text = cliente.InsertarClienteTran(con,
                                                     tranOrden,
                                                     apellidoCli,
                                                     nombreCli,
                                                     direccionCli,
                                                     telefonoCli,
                                                     CodTipoDoc,
                                                     nroDocumentoCli,
                                                     Direccion
                                                     ).ToString();

                        
                    }
                    else
                    { 
                        //Modifica un cliente

                        apellidoCli = txtApellido.Text.ToString();
                        nombreCli = txtNombre.Text.ToString();
                        Direccion = txtDireccion.Text;
                        direccionCli = txtDireccion.Text;
                        telefonoCli = txtTelefono.Text.ToString();
                        nroDocumentoCli = txtNroDoc.Text.ToString();
                        tipoDocumentoCli = cmbTipoDoc.Text.ToString();

                        cliente.ModificarClienteTran(con,
                                                    tranOrden,
                                                    txtCodCliente.Text.ToString().Trim(),
                                                    apellidoCli,
                                                    nombreCli,
                                                    direccionCli,
                                                    telefonoCli,null, nroDocumentoCli, Direccion);
                    }

                    cliente = null;

                    string patenteAuto = "";
                    string descripcionAuto = "";
                    Int32 codMarcaAuto;
                    Int32 anioAuto = 0;
                    double precioVtaAuto = 0.0;
                    string Chasis = "";
                    string Motor = "";
                    string Kilometros = "";
                    Int32? CodTipoCombustible = null;
                    if (cmbTipoCombustible.SelectedIndex > 0)
                        CodTipoCombustible = Convert.ToInt32(cmbTipoCombustible.SelectedValue);

                    cAuto auto = new cAuto();

                    if (txtCodAuto.Text.Trim() == "")
                    {
                        //Inserta un auto.

                        codMarcaAuto = Int32.Parse(CmbMarca.SelectedValue.ToString().Trim());
                        descripcionAuto = txtDescripcionVehiculo.Text.ToString();
                        patenteAuto = txtPatente.Text.ToString();
                        Chasis = txtChasis.Text;
                        Motor = txtMotor.Text;
                        Kilometros = txtKms.Text; 
                        txtCodAuto.Text = auto.InsertarAutoTran(con,
                                              tranOrden,
                                              codMarcaAuto,
                                              descripcionAuto,
                                              anioAuto.ToString().Trim(),
                                              precioVtaAuto,
                                              patenteAuto,
                                              txtCodCliente.Text.ToString().Trim(), Chasis, Motor, Kilometros,CodTipoCombustible).ToString();

                       // txtCodAuto.Text  = auto.GetSiguienteId(con, tranOrden).ToString().Trim();
                    }
                    else
                    {
                        //Modificarta un auto.

                        codMarcaAuto = Int32.Parse(CmbMarca.SelectedValue.ToString().Trim());
                        descripcionAuto = txtDescripcionVehiculo.Text.ToString();
                        patenteAuto = txtPatente.Text.ToString();
                        Int32? kms = null;
                        if (txtKms.Text != "")
                            kms = Convert.ToInt32(txtKms.Text);
                        auto.ModificarAutoTran(con,
                                              tranOrden,
                                              txtCodAuto.Text.ToString().Trim(),
                                              codMarcaAuto.ToString(),
                                              descripcionAuto,                                              
                                              patenteAuto,
                                              kms, CodTipoCombustible);

                    }

                  //  auto = null;

                    cOrden orden = new cOrden();
                    cOrdenDetalle ordenDetalle = new cOrdenDetalle();

                    Int32? codCliente = null; 
                    if (txtCodCliente.Text !="")
                        codCliente = Convert.ToInt32 (txtCodCliente.Text.ToString());
                    String codMecanico = CmbMecanico.SelectedValue.ToString();
                    String fechaAlta = txtFechaAltaOrden.Text.ToString();
                    Int32 CodAuto = Convert.ToInt32 (txtCodAuto.Text);
                    //actualizo el titular del auto
                 //   auto.ActuaizarTitularAuto(con, tranOrden, CodAuto, Convert.ToInt32(codCliente));
                    Int32 CodOrden = 0;
                    int Procesada = 0;
                    DateTime FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                    double ImporteEfectivo = 0;
                    Double Total = 0;
                    Double ImporteTransferencia = 0;
                    if (txtTotalTransferencia.Text !="")
                    {
                        ImporteTransferencia = fun.ToDouble(txtTotalTransferencia.Text);
                    }
                    string Kilometraje = "";

                    Kilometraje = txtKmOrden.Text;

                    if (ConfirmaOrden == true)
                        Procesada = 1;
                    ImporteEfectivo = fun.TotalizarColumna(tbEfectivo, "Importe");
                   // if (txtEfectivo.Text != "")
                     //   ImporteEfectivo = fun.ToDouble(txtEfectivo.Text);
                    if (txtTotalOrden.Text != "")
                        Total = fun.ToDouble(txtTotalOrden.Text);

                    string Descripcion = txtDescripcion.Text;
                    if (ConfirmaOrden ==true)
                        orden.ActualizarNroOrden(con, tranOrden, CodOrden);
                    if (txtCodOrden.Text == "")
                    {
                        CodOrden = orden.InsertarOrdenTran(con, tranOrden, codCliente, codMecanico, fechaAlta, CodAuto, Procesada, Descripcion, ImporteEfectivo, FechaEntrega, Total, Kilometraje, ImporteTransferencia);
                       
                    }
                        
                    else
                    {
                        CodOrden = Convert.ToInt32(txtCodOrden.Text);
                        orden.ModificarOrdenTran(con, tranOrden, Convert.ToInt32(CodOrden), codCliente, codMecanico, fechaAlta, CodAuto, Procesada, Descripcion, ImporteEfectivo, FechaEntrega, Total, Kilometraje,ImporteTransferencia );
                    }

                        ordenDetalle.BorrarDetalleOrden(con,tranOrden,Convert.ToInt32 (CodOrden));
                    foreach (DataRow dr in tbInsumos.Rows)
                        {  
                            ordenDetalle.InsertarOrdenDetalleTran(con,
                                                                  tranOrden,
                                                                  CodOrden.ToString(),
                                                                  dr["CodInsumo"].ToString(),
                                                                  fun.ToDouble(dr["Cantidad"].ToString()),
                                                                  fun.ToDouble(dr["PrecioCosto"].ToString()),
                                                                  fun.ToDouble(dr["PrecioVenta"].ToString()),
                                                                  fun.ToDouble(dr["PrecioManoObra"].ToString())
                                             );
                        }
                        if (ConfirmaOrden ==true)
                            GrabarFormaPago(con, tranOrden, CodOrden);
                        if (ConfirmaOrden)
                            GrabarCostosInsumos(con, tranOrden, CodOrden);
                        if (txtMensajes.Text != "")
                        {
                            string msj = txtMensajes.Text;
                            Clases.cMensajeOrden objMsj = new Clases.cMensajeOrden();
                            objMsj.InsertarMensajeTran(con, tranOrden, CodOrden, msj, Convert.ToDateTime(fechaAlta));
                        }
                    GrabarReparacion(con, tranOrden, CodOrden);
                    GrabarPagosEfectivo(con, tranOrden, CodOrden);
                    GrabarPagosTransferencia(con, tranOrden, CodOrden);
                    tranOrden.Commit();
                    Mensaje("Orden de Trabajo grabada correctamente");
                    orden = null;
                    ordenDetalle = null;
                    Limpiar();
                    cOrden ORD = new cOrden();
                    Int32 CodOrdenNEW = ORD.GetMaxOrden();
                    lblOrden.Text = "Orden Número " + CodOrdenNEW.ToString();
                    ImprimirOrden(CodOrden);
                }
                catch (Exception ex)
                {
                    tranOrden.Rollback();
                    Mensaje("Hubo un error en el proceso de grabación");
                }
                finally
                {   
                    tranOrden = null;
                    con.Close();
                    con = null;
                    
                }
            }

            
        }

        private void Buscarcliente()
        {
            string NroDoc = txtNroDoc.Text;
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientexNroDoc(NroDoc);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodCliente"].ToString ()!="")
                {
                    txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
                }
            }
        }
        private void Limpiar()
        {
            
            txtRecargo.Text = "";
            txtProcesada.Text = "";
            txtKms.Text = "";
            tbOrdenDetalle.Clear();
            txtInsumo.Text = "";
            txtImporteGarantia.Text = "";
            txtCodInsumo.Text = "";
            txtNombre.Text = "";
            txtTotalTransferencia.Text = "";
            tbTarjeta.Clear();
            grillaTarjetas.DataSource = null;
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtCuentaCorriente.Text = "";
            txtCodCliente.Text = "";
            txtCodAuto.Text = "";
            txtNroDocumento.Text = "";
            txtPatente.Text = "";
            txtCodDodumento.Text = "";
            txtDescripcionVehiculo.Text = "";
            txtMotor.Text = "";
            txtChasis.Text = "";
            if (CmbMarca.Items.Count > 0)
                CmbMarca.SelectedIndex = 0;
            txtDescripcionVehiculo.Text = "";
            txtMensajes.Text = "";
            CmbMecanico.SelectedIndex = 0;
            txtCupon.Text = "";
            tbInsumos.Rows.Clear();
           
            txtTotalOrden.Text = "";
            txtEfectivo.Text = "";
            txtTotalCheque.Text = "";
            txtDocumento.Text = "";
            tbCheques.Clear();
            tbInsumos.Clear();
            tbOrdenDetalle.Clear();
            GrillaCheques.DataSource = null;
            txtMontoTarjeta.Text = "";
            CmbTarjeta.SelectedIndex = 0;
            tbReparacion.Rows.Clear();
            GrillaDetalleReparacion.DataSource = tbReparacion;
            LimpiarPresupuesto();
        }

        public void  GrabarReparacion(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            Int32 CodReparacion = 0;
            string Nombre ="";
            int b = 0;
            int Con = 0;
            string FormaPago = "";// GetFormaPago();
            string Val = "";
            cReparacion rep = new cReparacion();
            rep.BorrarReparacion(con, Transaccion, CodOrden);
            for (int i = 0; i < tbInsumos.Rows.Count ; i++)
            {
                Nombre = tbInsumos.Rows[i]["Nombre"].ToString();
                FormaPago = tbInsumos.Rows[i]["PrecioVenta"].ToString();
                CodReparacion = (i + 1);
                Val = CodReparacion.ToString() + ";" + Nombre + ";" + FormaPago;
                tbReparacion = fun.AgregarFilas(tbReparacion, Val);
            }
            for (int i=0;i<tbReparacion.Rows.Count;i++)
            {
                if (tbReparacion.Rows[i]["CodReparacion"].ToString ()!="")
                {
                    b = 1;
                    Con++;
                    CodReparacion = Convert.ToInt32(tbReparacion.Rows[i]["CodReparacion"].ToString());
                    Nombre = tbReparacion.Rows[i]["Nombre"].ToString();
                    FormaPago = tbReparacion.Rows[i]["FormaPago"].ToString();
                    if (CodReparacion >0)
                        rep.Insertar(con, Transaccion, CodOrden, CodReparacion, Nombre, FormaPago);
                }
            }
            //inserto como minimo 19 para el reporte
            for (int i=Con;i<10;i++)
            {
                rep.Insertar(con, Transaccion, CodOrden, 0, "", "");
            }
            
        }

        #endregion

        #region Eventos

        private void FrmIngresoOrden_Load(object sender, EventArgs e)
        {
            fun.LlenarCombo(CmbProveedor, "Proveedor", "Nombre", "CodProveedor");
           // fun.LlenarCombo(CmbTipoDocumento, "tipodocumento", "Nombre", "CodTipoDoc");
        }

        private void txtPatente_KeyUp(object sender, KeyEventArgs e)
        {
           // BuscarVehiculo();
        }

        private void txtNroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarCliente();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                   
                    case "Marca":
                        fun.LlenarCombo(CmbMarca, "Marca", "Nombre", "CodMarca");
                        CmbMarca.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    
                    case "Tarjeta":
                        cTarjeta tarjeta = new cTarjeta();
                        fun.LlenarComboDatatable(CmbTarjeta, tarjeta.GetTarjetas(), "Nombre", "CodTarjeta");
                        CmbTarjeta.SelectedValue = Principal.CampoIdSecundarioGenerado; 
                        break;
                }
            }
            if (frmPrincipal.CodigoPrincipal != null)
            {
                ContinuarBusquedaInsumo();
            }
        }

        private void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            NuevaTarea();
        }

        private void CmbTarea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            NuevaMarca();
        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloNumerosEnteros(sender , e);

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloNumerosEnteros(sender , e);

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ConfirmaOrden = true;
            if (Validar() == true)
            {
                try
                {
                    GrabarOrden();
                    
                }
                catch
                {

                }
            }
        }

        #endregion

        private void btnNuevoInsumo_Click(object sender, EventArgs e)
        {
            NuevoInsumo();
        }

        private void NuevoInsumo()
        {
            Principal.CampoIdSecundario = "CodInsumo";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Insumo";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            AgregarInsumo();
        }

        private void AgregarInsumo()
        {

            if (txtInsumo.Text == "")
            {
                Mensaje("Debe seleccionar un insumo");
                return;
            }
            if (txtPrecioCompra.Text == "")
            {
                Mensaje("Debe ingresar un precio de costo");
                return;
            }

            if (txtCantidad.Text == "")
            {
                Mensaje("Ingresar una cantidad");
                return;
            }

            if (txtManoObra.Text == "")
            {
                Mensaje("Debe ingresar un precio de mano de obra");
                return;
            }

            cInsumo objInsumo = new cInsumo();
           

            
            double Por = 0;
            Int32? CodProveedor = null;
            if (CmbProveedor.SelectedIndex > 0)
                CodProveedor = Convert.ToInt32(CmbProveedor.SelectedValue);
            string CodInsumo ="";
            if (txtCodInsumo.Text != "")
            {
                CodInsumo = txtCodInsumo.Text;
              //  objInsumo.ModificarInsumo(Convert.ToInt32(txtCodInsumo.Text), txtInsumo.Text, txtFactura.Text, CodProveedor);

            }
            else
            {
                CodInsumo = objInsumo.IngresarInsumo(txtInsumo.Text, txtFactura.Text, CodProveedor).ToString();
            }
                

            if (tabla.Buscar(tbInsumos, "CodInsumo", CodInsumo) == true)
            {
                tbInsumos = tabla.EliminarFila(tbInsumos, "CodInsumo", CodInsumo.ToString());
            }

            string Nombre = txtInsumo.Text.Replace(";", ".");
            double Costo = Convert.ToDouble(txtPrecioCompra.Text);
            
            double ManoObra = 0;
            double Cantidad = 1;
            if (chkAplicaPorcentaje.Checked ==true)
            if (txtPorcentaje.Text != "")
            {
                Por = Convert.ToDouble(txtPorcentaje.Text.Replace (".",","));
                double PorAplicado = Costo * Por / 100;
                double PrecioVenta = Costo + PorAplicado;
                txtPrecioVenta.Text = PrecioVenta.ToString();
            }
            if (txtPrecioVenta.Text == "")
            {
                Mensaje("Debe ingresar un precio de venta ");
                return;
            }
            if (txtCantidad.Text != "")
            {
                Cantidad = fun.ToDouble(txtCantidad.Text);
            }

            if (txtManoObra.Text != "")
                ManoObra = fun.ToDouble(txtManoObra.Text);

           

            

            if (chkAplicarIva.Checked == true)
            {
                
                    //le aplico el iva al costo
                    double PorIva = 0.21 * fun.ToDouble (txtPrecioCompra.Text);
                    double Precio = fun.ToDouble(txtPrecioCompra.Text);
                    Precio = Precio + PorIva;
                    Precio = Math.Round(Precio, 0);
                    txtPrecioCompra.Text = Precio.ToString();
                     
                    //le aplico el iva a la venta
                    PorIva = 0.21 * fun.ToDouble(txtPrecioVenta.Text);
                    Precio = fun.ToDouble(txtPrecioVenta.Text);
                    Precio = Precio + PorIva;
                    txtPrecioVenta.Text = Precio.ToString();
                
            }

            if (txtPrecioVenta.Text != "")
            {
                txtPrecioVenta.Text = fun.SepararDecimales(txtPrecioVenta.Text);
                txtPrecioVenta.Text = fun.FormatoEnteroMiles(txtPrecioVenta.Text);
            }

            if (txtManoObra.Text != "")
            {
               // txtManoObra.Text = fun.SepararDecimales(txtManoObra.Text);
               // txtManoObra.Text = fun.FormatoEnteroMiles(txtManoObra.Text);
            }
            
            int ActualizaStock = 0;
            if (txtInsumo.Enabled == false)
                ActualizaStock = 1;
            else
                ActualizaStock = 0;

            double TotalCosto = 0;
            double PrecioCosto = fun.ToDouble(txtPrecioCompra.Text);
            TotalCosto = Cantidad * PrecioCosto;

            double  PreVenta = fun.ToDouble (txtPrecioVenta.Text);
            double TotalVenta = Cantidad * PreVenta;

            string Valores =   CodInsumo.ToString();
            Valores = Valores + ";" + Nombre + ";" + Cantidad.ToString() + ";" + fun.FormatoEnteroMiles (TotalCosto.ToString ()) + ";" + fun.FormatoEnteroMiles(TotalVenta.ToString ()) + ";" + fun.FormatoEnteroMiles (txtManoObra.Text) + ";" + ActualizaStock.ToString();
            tbInsumos = tabla.AgregarFilas(tbInsumos, Valores);

            // tbInsumos = fun.TablaaMiles(tbInsumos, "PrecioCosto");
            //  tbInsumos = fun.TablaaMiles(tbInsumos, "PrecioVenta");
            //  tbInsumos = fun.TablaaMiles(tbInsumos, "PrecioManoObra");

            string Col = "";
            if (MuestraColumnaCosto==false)
            {
                Col = "0;40;20;0;20;20;0";
            }
            else
            {
                Col = "0;30;15;15;15;25;0";
            }
             
            GrillaInsumos.DataSource = tbInsumos;
            TotalOrden();
           // GrillaInsumos.Columns[0].Visible = false;
            
            GrillaInsumos.Columns[1].Width = 150;
            GrillaInsumos.Columns[1].HeaderText  = "Descripción";
            GrillaInsumos.Columns[3].HeaderText = "Cantidad";
            GrillaInsumos.Columns[3].HeaderText = "Costo";
            GrillaInsumos.Columns[4].HeaderText = "Venta";
            GrillaInsumos.Columns[5].HeaderText = "Mano Ob.";
            GrillaInsumos.Columns[5].Width = 120;
           // GrillaInsumos.Columns[6].Visible = false;
            fun.AnchoColumnas(GrillaInsumos, Col);
            txtCodInsumo.Text = "";
            txtInsumo.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtManoObra.Text = "";
            txtInsumo.Enabled = true;
        }

        private void TotalOrden()
        {
            double Total = fun.TotalizarColumna(tbInsumos, "PrecioVenta");
            double TotalManoObra = fun.TotalizarColumna(tbInsumos, "PrecioManoObra");
            Total = Total + TotalManoObra;
            txtTotalOrden.Text = Total.ToString();
            txtTotalOrden.Text = fun.SepararDecimales(txtTotalOrden.Text);
            txtTotalOrden.Text = fun.FormatoEnteroMiles(txtTotalOrden.Text);
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            if (GrillaInsumos.CurrentRow == null)
                return;
            Int32 CodInsumo = Convert.ToInt32(GrillaInsumos.CurrentRow.Cells[0].Value.ToString());
            tbInsumos = tabla.EliminarFila(tbInsumos, "CodInsumo", CodInsumo.ToString ());
            GrillaInsumos.DataSource = tbInsumos;
            TotalOrden();
            txtCantidad.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtManoObra.Text = "";
            txtCodInsumo.Text = "";
            txtInsumo.Text = "";
        }

        private void BorrarInsumosxTarea(Int32 CodTarea)
        {
            string ColInsumos = "CodTarea;CodInsumo;Nombre;PrecioCosto;PrecioVenta";
            DataTable trdo = tabla.CrearTabla(ColInsumos);
            string Values = "";
            for (int i = 0; i < tbInsumos.Rows.Count; i++)
            {
                if (tbInsumos.Rows[i]["CodTarea"].ToString() != CodTarea.ToString())
                {
                    Values = tbInsumos.Rows[i][0].ToString();
                    Values = Values +";"+ tbInsumos.Rows[i][1].ToString();
                    Values = Values + ";" + tbInsumos.Rows[i][2].ToString();
                    Values = Values + ";" + tbInsumos.Rows[i][3].ToString();
                    trdo = tabla.AgregarFilas(trdo, Values);
                }
            }
            tbInsumos = trdo;
            GrillaInsumos.DataSource = tbInsumos;
        }

        private void GrabarInsumos(SqlConnection con, SqlTransaction tran,Int32 CodOrden)
        {
            cInsumo insumo = new cInsumo();
            int i=0;
            double PrecioCosto = 0;
            double PrecioVenta = 0;

            for (i = 0; i < tbInsumos.Rows.Count ; i++)
            {
                Int32 CodTarea =Convert.ToInt32 (tbInsumos.Rows[i][0].ToString());
                Int32 CodInsumo = Convert.ToInt32(tbInsumos.Rows[i][1].ToString());
                PrecioCosto = Convert.ToDouble(tbInsumos.Rows[i][3].ToString());
                PrecioVenta = Convert.ToDouble(tbInsumos.Rows[i][4].ToString());
                insumo.InsertarInsumo(con, tran, CodOrden, CodTarea, CodInsumo, PrecioCosto, PrecioVenta);
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
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
            double TotalTransferencia = 0;
            double CuentaCorriente = 0;

            if (txtTotalOrden.Text != "")
                Total = fun.ToDouble(txtTotalOrden.Text);
            Efectivo = fun.TotalizarColumna(tbEfectivo, "Importe");
            /*
            if (txtEfectivo.Text != "")
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            */
            if (txtDocumento.Text != "")
                Documentos = fun.ToDouble(txtDocumento.Text);
            if (txtTotalCheque.Text != "")
                Cheques = fun.ToDouble(txtTotalCheque.Text);
            if (txtTotalTarjeta.Text != "")
                TotalTarjeta = fun.ToDouble(txtTotalTarjeta.Text);
            if (txtTotalTransferencia.Text != "")
                TotalTransferencia = fun.ToDouble(txtTotalTransferencia.Text);
            if (txtCuentaCorriente.Text != "")
                CuentaCorriente = fun.ToDouble(txtCuentaCorriente.Text);

            if (txtImporteGarantia.Text != "")
                Garantia = fun.ToDouble(txtImporteGarantia.Text);
            Subtotal = Efectivo + Cheques + Documentos + TotalTarjeta + Garantia + TotalTransferencia + CuentaCorriente;
            if (Subtotal != Total)
            {
                Mensaje("No coinciden los montos totales a canelar");
                return false;
            }
            return true;
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodTarjeta";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Tarjeta";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (txtNumeroCheque.Text == "")
            {
                Mensaje("Ingresar un cheque");
                return;
            }

            if (fun.ValidarFecha (txtFecha.Text) ==false)
            {
                Mensaje ("La fecha ingresada es incorrecta");
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
            Valores = Valores + ";" + txtFecha.Text;
            Valores = Valores + ";" + txtImporteCheque.Text;
            tbCheques = tabla.AgregarFilas(tbCheques, Valores);
            GrillaCheques.DataSource = tbCheques;
            txtTotalCheque.Text = fun.TotalizarColumna(tbCheques, "Importe").ToString();
            if (txtTotalCheque.Text != "")
            {
                txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);
            }
            fun.AnchoColumnas(GrillaCheques,"50;25;25");
            CalcularSaldo();
            //GrillaCheques.Columns[0].Width = 390;
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

        private void GrabarFormaPago(SqlConnection con, SqlTransaction Transaccion,Int32 CodOrden)
        {
            DateTime Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
            Int32 CodUsuario =1;
            cMovimiento mov = new cMovimiento();
            string Descripcion = "COBRO DE SERVICIO ";
            Descripcion = Descripcion + " " + txtApellido.Text;
            Descripcion = Descripcion + " " + txtNombre.Text;
            Descripcion = Descripcion + ", PATENTE " + txtPatente.Text;
            if (txtEfectivo.Text != "" && txtEfectivo.Text !="0")
            {
                double Efectivo = fun.ToDouble(txtEfectivo.Text);
                mov.GrabarMovimientoTransaccion(con, Transaccion, Efectivo, Descripcion, Fecha, CodUsuario, CodOrden);
            }

            if (txtDocumento.Text != "" && txtDocumento.Text != "0")
            {  
                double Importe = fun.ToDouble(txtDocumento.Text);
                Int32? CodClie = Convert.ToInt32 (txtCodCliente.Text);
                cDocumento doc = new cDocumento();
                doc.InsertarDocumentoTransaccion(con, Transaccion, Fecha, Importe, CodOrden, CodClie,null);
               
            }

            if (txtTotalTarjeta.Text != "" && txtTotalTarjeta.Text != "0")
            {
                Int32 CodCliente = Convert.ToInt32(txtCodCliente.Text);
                cCobroTarjeta cobro = new cCobroTarjeta();
                for (int k = 0; k < tbTarjeta.Rows.Count; k++)
                {
                    double ImporteTarjeta = Convert.ToDouble(tbTarjeta.Rows[k]["Importe"].ToString ());
                    Int32 Codtarjeta = Convert.ToInt32(tbTarjeta.Rows[k]["CodTarjeta"].ToString());
                    string Cupon = tbTarjeta.Rows[k]["Cupon"].ToString();
                    DateTime FechaEmision = Convert.ToDateTime(tbTarjeta.Rows[k]["FechaEmision"].ToString());
                    Double? Recargo = null;
                    if (tbTarjeta.Rows[k]["Recargo"].ToString() != "")
                    {
                        Recargo = Convert.ToDouble(tbTarjeta.Rows[k]["Recargo"].ToString());
                    }
                    cobro.Registrar(con, Transaccion, CodOrden, Fecha, Codtarjeta, ImporteTarjeta, Cupon, FechaEmision, Recargo,CodCliente,null);
                }            
            }

            if (txtTotalCheque.Text != "" && txtTotalCheque.Text != "0")
            {
                cCheque cheque = new cCheque();
                for (int i = 0; i < tbCheques.Rows.Count; i++)
                {
                    Int32? CodCliente = null;
                    if (txtCodCliente.Text != "")
                        CodCliente = Convert.ToInt32(txtCodCliente.Text);
                    string NroCheque = tbCheques.Rows[i]["NroCheque"].ToString();
                    DateTime FechaVto = Convert.ToDateTime(tbCheques.Rows[i]["Fecha"].ToString());
                    double Importe = fun.ToDouble(tbCheques.Rows[i]["Importe"].ToString());
                    cheque.InsertarCheque(con, Transaccion, NroCheque, Importe, CodOrden, Fecha, FechaVto, CodCliente, null);
                }
            }

            if (txtImporteGarantia.Text != "" && txtImporteGarantia.Text != "0")
            {
                double ImporteGarantia = fun.ToDouble(txtImporteGarantia.Text);
                cGarantia objGarantia = new cGarantia();
                objGarantia.Insertar(con, Transaccion, ImporteGarantia, CodOrden,Fecha);
            }
             
            if (txtTotalTransferencia.Text != "" && txtTotalTransferencia.Text != "0")
            {  
                GrabarTransferencia(con, Transaccion, CodOrden, Fecha);
            }

            if (txtCuentaCorriente.Text !="" && txtCuentaCorriente.Text !="0")
            {
                cCuentaCorriente cuenta = new cCuentaCorriente();
                Double ImporteCC = fun.ToDouble(txtCuentaCorriente.Text);
                cuenta.Insertar(con, Transaccion, CodOrden, Fecha, ImporteCC);
            }
        }

        private void btnNuevaTarjeta_Click(object sender, KeyPressEventArgs e)
        {

        }

        private void txtImporteGarantia_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }
        
        private void BuscarOrden(Int32 CodOrden)
        {
            txtCodOrden.Text = CodOrden.ToString();
            cOrden orden = new cOrden();
            DataTable trdo = orden.GetOrdenxCodigo(CodOrden);
            if (trdo.Rows.Count > 0)
            {  
                DateTime Fecha = Convert.ToDateTime(trdo.Rows[0]["Fecha"].ToString());
                txtFechaAltaOrden.Text = Fecha.ToShortDateString();
                txtDescripcionVehiculo.Text = trdo.Rows[0]["Descripcion"].ToString();
                txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                if (trdo.Rows[0]["CodTipoDoc"].ToString()!="")
                {
                    string CodTipoDoc = trdo.Rows[0]["CodTipoDoc"].ToString();
                    CmbTipoDocumento.SelectedValue = CodTipoDoc;
                   // if (CmbTipoDocumento.Items.Count > 0)
                   //     CmbTipoDocumento.SelectedIndex = 0;
                }
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                txtCodAuto.Text = trdo.Rows[0]["CodAuto"].ToString();
                txtKms.Text = trdo.Rows[0]["Kilometros"].ToString();
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
                txtKmOrden.Text = trdo.Rows[0]["kilometraje"].ToString();
                txtChasis.Text = trdo.Rows[0]["Chasis"].ToString();
                txtMotor.Text = trdo.Rows[0]["Motor"].ToString();
                txtDescripcion.Text = trdo.Rows[0]["DescripcionOrden"].ToString();
                CmbMarca.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                CmbMecanico.SelectedValue = trdo.Rows[0]["CodMecanico"].ToString();
                txtProcesada.Text = trdo.Rows[0]["Procesada"].ToString();
                txtEfectivo.Text = trdo.Rows[0]["ImporteEfectivo"].ToString();
              //  txtEfectivo.Text = fun.SepararDecimales(txtEfectivo.Text);
             //   txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
                if (txtProcesada.Text == "1")
                {
                    btnGrabar.Enabled = false;
                    btnPreIngresarOrden.Enabled = false;
                    btnAgregarEfectivo.Enabled = false;
                    btnQuitarEfectivo.Enabled = false;

                }

                txtTotalTransferencia.Text = trdo.Rows[0]["ImporteTransferencia"].ToString();
                if (txtTotalTransferencia.Text !="" && txtTotalTransferencia.Text !="0")
                {
                    txtTotalTransferencia.Text = fun.FormatoEnteroMiles(txtTotalTransferencia.Text);
                }
            }
            cOrdenDetalle ordDet = new cOrdenDetalle();
            DataTable tb = ordDet.GetOrdenDetallexCodOrden(CodOrden);
            string Valores = "";
            tbInsumos.Clear();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    Valores = tb.Rows[i]["CodInsumo"].ToString();
                    Valores = Valores + ";" + tb.Rows[i]["Nombre"].ToString().Replace(";",".");
                    Valores = Valores + ";" + tb.Rows[i]["Cantidad"].ToString();
                    Valores = Valores + ";" + tb.Rows[i]["PrecioCosto"].ToString();
                    Valores = Valores + ";" + tb.Rows[i]["PrecioVenta"].ToString();
                    Valores = Valores + ";" + tb.Rows[i]["PrecioManoObra"].ToString();
                    Valores = Valores + ";" + tb.Rows[i]["ActualizaStock"].ToString(); 
                    tbInsumos = tabla.AgregarFilas(tbInsumos, Valores);
                }
                tbInsumos = fun.TablaaMiles(tbInsumos, "PrecioCosto");
                tbInsumos = fun.TablaaMiles(tbInsumos, "PrecioVenta");
                tbInsumos = fun.TablaaMiles(tbInsumos, "PrecioManoObra");
                tbInsumos = fun.TablaaMiles(tbInsumos, "Cantidad");
                GrillaInsumos.DataSource = tbInsumos;
                GrillaInsumos.Columns[6].Visible = false; 
            }
            lblOrden.Text = "Orden Número " + CodOrden.ToString();
            //formas de pago
            cMovimiento mov = new cMovimiento();
           

            cDocumento doc = new cDocumento();
            double ImporteDocumento = doc.GetTotalxCodOrden(CodOrden);
            txtDocumento.Text = ImporteDocumento.ToString();
            DataTable tdoc = doc.GetDocumentoxCodOrden(CodOrden);
            int bdoc = 0;
            if (tdoc.Rows.Count >0)
                if (tdoc.Rows[0]["CodDocumento"].ToString() != "")
                {
                    bdoc = 1;
                    btnVerDocumento.Visible = true;
                    txtCodDodumento.Text = tdoc.Rows[0]["CodDocumento"].ToString();
                }
            if (bdoc == 0)
            {
                btnVerDocumento.Visible = false;
                txtCodDodumento.Text = "";
            }


            tbCheques.Clear();
            cCheque objCheque = new cCheque();
            DataTable tcheque = objCheque.GetChequesxCodOrden(CodOrden);
            int banCheque = 0;
            if (tcheque.Rows.Count > 0)
            {
                for (int i = 0; i < tcheque.Rows.Count; i++)
                {
                    btnVerCheque.Visible = true;
                    banCheque = 1;
                    Valores = tcheque.Rows[i]["NroCheque"].ToString();
                    Valores = Valores + ";" + tcheque.Rows[i]["Fecha"].ToString();
                    Valores = Valores + ";" + tcheque.Rows[i]["Importe"].ToString();

                    tbCheques = tabla.AgregarFilas(tbCheques, Valores);
                }
                GrillaCheques.DataSource = tbCheques;
                txtTotalCheque.Text = fun.TotalizarColumna(tbCheques, "Importe").ToString();
            }
            if (banCheque == 0)
            {
                txtTotalCheque.Text = "0";
                btnVerCheque.Visible = false;
            }

            int banTarjeta = 0;
            cCobroTarjeta cobTarjeta = new cCobroTarjeta();
            DataTable ttarjeta = cobTarjeta.GetCobroTarjetaxCodOrden(CodOrden);
            if (ttarjeta.Rows.Count > 0)
            {
                if (ttarjeta.Rows[0]["CodOrden"].ToString() != "")
                {
                    for (int k = 0; k < ttarjeta.Rows.Count; k++)
                    {
                        banTarjeta = 1;
                        string Values = ttarjeta.Rows[k]["CodTarjeta"].ToString();
                        Values = Values + ";" + ttarjeta.Rows[k]["Nombre"].ToString();
                        Values = Values + ";" + ttarjeta.Rows[k]["Cupon"].ToString();
                        Values = Values + ";" + ttarjeta.Rows[k]["Importe"].ToString();
                        Values = Values + ";" + ttarjeta.Rows[k]["CodCobro"].ToString();
                        tbTarjeta = tabla.AgregarFilas(tbTarjeta, Values);
                    }
                    txtTotalTarjeta.Text = fun.TotalizarColumna(tbTarjeta, "Importe").ToString();
                    if (txtTotalTarjeta.Text != "")
                    {

                    }
                    tbTarjeta = fun.TablaaMiles(tbTarjeta, "Importe");
                    
                    grillaTarjetas.DataSource = tbTarjeta;
                    grillaTarjetas.Columns[0].Visible = false;
                    grillaTarjetas.Columns[4].Visible = false;
                    grillaTarjetas.Columns[3].HeaderText = "Importe";
                    grillaTarjetas.Columns[1].Width = 200;
                    grillaTarjetas.Columns[2].Width = 170;
                    // txtCupon.Text = ttarjeta.Rows[0]["Cupon"].ToString();
                   // txtMontoTarjeta.Text = ttarjeta.Rows[0]["Importe"].ToString();
                   // CmbTarjeta.SelectedValue = ttarjeta.Rows[0]["CodTarjeta"].ToString();
                   // txtMontoTarjeta.Text = fun.SepararDecimales(txtMontoTarjeta.Text);
                  //  txtMontoTarjeta.Text = fun.FormatoEnteroMiles(txtMontoTarjeta.Text);
                }
            }
            if (banTarjeta == 1)
                btnPagarTarjeta.Visible = true;
            else
                btnPagarTarjeta.Visible = false; 

            cGarantia gar = new cGarantia();
            double ImporteGarantia = gar.GetTotalxCodOrden(CodOrden);
            txtImporteGarantia.Text = ImporteGarantia.ToString();
            DataTable tGarantia = gar.GetGarantiaxCodOrden(CodOrden);
            int bgar = 0;
            if (tGarantia.Rows.Count > 0)
            {
                if (tGarantia.Rows[0]["CodGarantia"].ToString() != "")
                {
                    txtCodGarantia.Text = tGarantia.Rows[0]["CodGarantia"].ToString();
                    bgar = 1;
                    btnVerGarantia.Visible = true;
                }
            }
            if (bgar == 0)
            {
                txtCodGarantia.Text = "";
                btnVerGarantia.Visible = false;
            }
            TotalOrden();
            if (tbInsumos.Rows.Count > 0)
            {
                GrillaInsumos.Columns[0].Visible = false;
                GrillaInsumos.Columns[1].Width = 150;
                GrillaInsumos.Columns[1].HeaderText = "Descripción";
                GrillaInsumos.Columns[3].HeaderText = "Cantidad";
                GrillaInsumos.Columns[3].HeaderText = "Costo";
                GrillaInsumos.Columns[4].HeaderText = "Venta";
                GrillaInsumos.Columns[5].HeaderText = "Mano Obra";
                GrillaInsumos.Columns[5].Width = 120;
            }
            BuscarReparacion(CodOrden);
            cTransferencia transfer = new cTransferencia();
            Double  ImporteTransferencia = transfer.GetImporteTransferenciaxCodigo(CodOrden);
            if (ImporteTransferencia > 0)
            {
                txtTotalTransferencia.Text = ImporteTransferencia.ToString();
                txtTotalTransferencia.Text = fun.SepararDecimales(txtTotalTransferencia.Text);
                txtTotalTransferencia.Text = fun.FormatoEnteroMiles(txtTotalTransferencia.Text);
            }
            cCuentaCorriente cuenta = new cCuentaCorriente();
            DataTable trdoCuenta = cuenta.GetCuentaCorriente(CodOrden);
            if (trdoCuenta.Rows.Count >0)
            {
                txtCuentaCorriente.Text = trdoCuenta.Rows[0]["Importe"].ToString();
                txtCuentaCorriente.Text = fun.SepararDecimales(txtCuentaCorriente.Text);
                txtCuentaCorriente.Text = fun.FormatoEnteroMiles(txtCuentaCorriente.Text);
            }
            BuscarPagoxCodOrden(CodOrden);
            BuscarPagoTransferenciaxCodOrden(CodOrden);
            CalcularSaldo();
        }
        
        private void btnPreIngresarOrden_Click(object sender, EventArgs e)
        {

        }

        private void GrillaInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrillaInsumos.CurrentRow == null)
                return;
            txtCodInsumo.Text = GrillaInsumos.CurrentRow.Cells[0].Value.ToString();
            txtInsumo.Text = GrillaInsumos.CurrentRow.Cells[1].Value.ToString();
            txtCantidad.Text = GrillaInsumos.CurrentRow.Cells[2].Value.ToString();
            txtPrecioCompra.Text = GrillaInsumos.CurrentRow.Cells[3].Value.ToString();
            txtPrecioVenta.Text = GrillaInsumos.CurrentRow.Cells[4].Value.ToString();
            txtManoObra.Text = GrillaInsumos.CurrentRow.Cells[5].Value.ToString();

            /*
            cInsumo insu = new cInsumo();
            if (GrillaInsumos.CurrentRow != null)
            {
                DataTable trdo = insu.GetInsumoxCodigo(Convert.ToInt32(GrillaInsumos.CurrentRow.Cells[0].Value.ToString()));
                if (trdo.Rows.Count > 0)
                {
                    txtFactura.Text = trdo.Rows[0]["Factura"].ToString();
                    if (trdo.Rows[0]["CodProveedor"].ToString() != "")
                        CmbProveedor.SelectedValue = trdo.Rows[0]["CodProveedor"].ToString();
                    else
                        CmbProveedor.SelectedIndex = 0;
                }
            }
             */
            
        }

        private void btnPreIngresarOrden_Click_1(object sender, EventArgs e)
        {
            ConfirmaOrden = false;
            if (Validar() == true)
            {
                try
                {
                    GrabarOrden();

                }
                catch
                {

                }
            }
        }

        private void GrabarCostosInsumos(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            double Importe = 0;
            string Insumo = "";
            string Descripcion = "";
            Int32 Cantidad = 0;
            Int32 CodInsumo =0;
            string ActualizaStock = "";
            DateTime Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
            cMovimiento mov = new cMovimiento();
            cInsumo insumo = new cInsumo();
            for (int i = 0; i < tbInsumos.Rows.Count; i++)
            {
                CodInsumo = Convert.ToInt32(tbInsumos.Rows[i][0].ToString());
                Insumo = tbInsumos.Rows[i][1].ToString();
                Importe = fun.ToDouble(tbInsumos.Rows[i][3].ToString());
                Descripcion = "COSTO DE REPUESTO " + Insumo;
                Descripcion = Descripcion + ", PATENTE =" + txtPatente.Text;
                Cantidad = Convert.ToInt32(tbInsumos.Rows[i][2].ToString());
                ActualizaStock = tbInsumos.Rows[i][6].ToString();
                if (ActualizaStock !="1")
                    mov.GrabarMovimientoTransaccion(con, Transaccion,-1* Importe, Descripcion, Fecha, 1, CodOrden);
                if (ActualizaStock == "1")
                    insumo.ActualizarStock(con, Transaccion, CodInsumo,-1* Cantidad);
            }
        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            FrmBuscarInsumo frm = new FrmBuscarInsumo();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void ContinuarBusquedaInsumo()
        {
            if (frmPrincipal.CodigoPrincipal != null)
            {
                
                Int32 CodInsumo = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                BuscarInsumoxCodigo(CodInsumo);
            }
        }

        private void BuscarInsumoxCodigo(Int32 CodInsumo)
        {
            cInsumo insumo = new cInsumo();
            DataTable trdo = insumo.GetInsumoxCodigo(CodInsumo);
            if (trdo.Rows.Count > 0)
            {
                txtCodInsumo.Text = trdo.Rows[0]["CodInsumo"].ToString();
                txtStockActual.Text = trdo.Rows[0]["Cantidad"].ToString();
                txtPrecioCompra.Text = trdo.Rows[0]["Precio"].ToString();
                txtPrecioVenta.Text = trdo.Rows[0]["PrecioVenta"].ToString();
                txtInsumo.Text = trdo.Rows[0]["Nombre"].ToString();
                if (txtStockActual.Text == "")
                    txtStockActual.Text = "0";
                txtInsumo.Enabled = false;
                if (txtPrecioCompra.Text != "")
                {
                    txtPrecioCompra.Text = fun.SepararDecimales(txtPrecioCompra.Text);
                    txtPrecioCompra.Text = fun.FormatoEnteroMiles(txtPrecioCompra.Text);
                }

                if (txtPrecioVenta.Text != "")
                {
                    txtPrecioVenta.Text = fun.SepararDecimales(txtPrecioVenta.Text);
                    txtPrecioVenta.Text = fun.FormatoEnteroMiles(txtPrecioVenta.Text);
                }
            }
            cCompra objCompra = new cCompra();
            DataTable tcompra = objCompra.GetDetalleCompraxCodInsumo(CodInsumo);
            if (tcompra.Rows.Count > 0)
            {
                txtFactura.Text = tcompra.Rows[0]["Factura"].ToString();
                if (tcompra.Rows[0]["CodProveedor"].ToString() != "")
                {
                    CmbProveedor.SelectedValue = tcompra.Rows[0]["CodProveedor"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInsumo.Text = "";
            txtCodInsumo.Text = "";
            txtInsumo.Enabled = true;
            txtStockActual.Text = "";
            CmbProveedor.SelectedIndex = 0;
        }

        private void btnMensaje_Click(object sender, EventArgs e)
        {
            if (txtCodOrden.Text == "")
            {
                Mensaje("Debe registrar la orden para grabar mensajes");
                return;
            }

            frmPrincipal.CodigoPrincipal = txtCodOrden.Text;
            FrmMensajes frm = new FrmMensajes();
            frm.ShowDialog();
        }

        private void txtKms_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloNumerosEnteros(sender, e); 
            
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            frmPrincipal.CodigoPrincipal = txtCodDodumento.Text;
            FrmCobroDocumentos frm = new FrmCobroDocumentos();
            frm.ShowDialog();
        }

        private void btnVerCheque_Click(object sender, EventArgs e)
        {
            cCheque cheque = new cCheque ();
            if (GrillaCheques.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un cheque");
                return;
            }
            string NroCheque = GrillaCheques.CurrentRow.Cells[0].Value.ToString();
            DataTable tcheque = cheque.GetChequexNroCheque(NroCheque);
            if (tcheque.Rows.Count > 0)
            {
                if (tcheque.Rows[0]["CodCheque"].ToString() != "")
                {
                    frmPrincipal.CodigoPrincipal = tcheque.Rows[0]["CodCheque"].ToString();
                    FrmCobroCheque cob = new FrmCobroCheque();
                    cob.ShowDialog();
                }
            }
        }

        private void btnVerGarantia_Click(object sender, EventArgs e)
        {
            frmPrincipal.CodigoPrincipal = txtCodGarantia.Text;
            FrmPagoGarantia pago = new FrmPagoGarantia();
            pago.ShowDialog();
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
            string CodTarjeta =CmbTarjeta.SelectedValue.ToString ();
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
            fun.AnchoColumnas(grillaTarjetas,"0;40;15;15;0;15;15");
            /*
            grillaTarjetas.Columns[0].Visible = false;
            grillaTarjetas.Columns[4].Visible = false;
            grillaTarjetas.Columns[3].HeaderText = "Importe";
            grillaTarjetas.Columns[5].HeaderText = "Emision";
            grillaTarjetas.Columns[1].Width = 200;
            grillaTarjetas.Columns[2].Width = 170;
            */
            CalcularSaldo();
        }

        private void btnQuitarTarjeta_Click(object sender, EventArgs e)
        {
            if (grillaTarjetas.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            tbTarjeta = tabla.EliminarFila(tbTarjeta, "CodTarjeta", grillaTarjetas.CurrentRow.Cells[0].Value.ToString());
            grillaTarjetas.DataSource = tbTarjeta;
            txtTotalTarjeta.Text = fun.TotalizarColumna(tbTarjeta, "Importe").ToString(); 
        }

        private void btnPagarTarjeta_Click(object sender, EventArgs e)
        {
            if (grillaTarjetas.CurrentRow == null)
            {
                Mensaje("Seleccione un registro");
                return;
            }
            string CodCobro = grillaTarjetas.CurrentRow.Cells[4].Value.ToString ();  
            frmPrincipal.CodigoPrincipal= CodCobro ;
            FrmCobroTarjeta frm = new FrmCobroTarjeta ();
            frm.ShowDialog ();
        }

        private void txtRecargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            string CodigoBarra = txtCodigoBarra.Text;
            BuscarInsumoxCodBarra(CodigoBarra);
        }

        private void BuscarInsumoxCodBarra(string CodigoBarra)
        {
            cInsumo insumo = new cInsumo();
            DataTable trdo = insumo.GetInsumoxCodigoBarra(CodigoBarra);
            int b = 0;
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodInsumo"].ToString() != "")
                {
                    b = 1;
                    Int32 CodInsumo = Convert.ToInt32(trdo.Rows[0]["CodInsumo"].ToString());
                    BuscarInsumoxCodigo(CodInsumo);
                }
            }
            if (b == 0)
            {
                txtCodInsumo.Text = "";
                txtStockActual.Text = "";
                txtPrecioCompra.Text = "";
                txtPrecioVenta.Text = "";
                txtInsumo.Text = "";
                txtStockActual.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

         }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (txtDetalleReparacion.Text =="")
            {
                Mensaje("Ingresar un detalle de reparación");
                return;
            }
            string Reparacion = txtDetalleReparacion.Text;
            Int32 CodReparacion = 0;
            for (int i=0;i<tbReparacion.Rows.Count;i++)
            {
                if (tbReparacion.Rows[i]["CodReparacion"].ToString ()!="")
                {
                    CodReparacion = Convert.ToInt32(tbReparacion.Rows[i]["CodReparacion"].ToString());
                }
            }
            CodReparacion++;
            string Val = CodReparacion + ";" + Reparacion;
            cFunciones fun = new cFunciones();
            tbReparacion = fun.AgregarFilas(tbReparacion, Val);
            GrillaDetalleReparacion.DataSource = tbReparacion;
            
            fun.AnchoColumnas(GrillaDetalleReparacion, "0;100");
            txtDetalleReparacion.Text = "";
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (GrillaDetalleReparacion.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodReparacion = GrillaDetalleReparacion.CurrentRow.Cells[0].Value.ToString();
            cTabla tabla = new cTabla();
            tbReparacion = tabla.EliminarFila(tbReparacion, "CodReparacion", CodReparacion);
            GrillaDetalleReparacion.DataSource = tbReparacion;  
        }

        private string GetFormaPago()
        {
            string Forma = "";
            if (txtEfectivo.Text !="")
                if (txtEfectivo.Text !="0")
                {
                    Forma = "Efectivo: " + txtEfectivo.Text;
                }
            if (txtDocumento.Text != "")
                if (txtDocumento.Text != "0")
                {
                    if (Forma == "")
                        Forma = "Documento: " + txtDocumento.Text;
                    else
                        Forma = Forma + ", Documento: " + txtDocumento.Text;
                }

            if (txtTotalTarjeta.Text != "")
                if (txtTotalTarjeta.Text != "0")
                {
                    if (Forma == "")
                        Forma = "Tarjeta: " + txtTotalTarjeta.Text;
                    else
                        Forma = Forma + ", Tarjeta: " + txtTotalTarjeta.Text;
                }
            if (txtTotalCheque.Text != "")
                if (txtTotalCheque.Text != "0")
                {
                    if (Forma == "")
                        Forma = "Cheque: " + txtTotalCheque.Text;
                    else
                        Forma = Forma + ", Cheque: " + txtTotalCheque.Text;
                }
            if (txtImporteGarantia.Text != "")
                if (txtImporteGarantia.Text != "0")
                {
                    if (Forma == "")
                        Forma = "Garantía: " + txtImporteGarantia.Text;
                    else
                        Forma = Forma + ", Garantía: " + txtImporteGarantia.Text;
                }
            

            return Forma;
        }

        private void ImprimirOrden(Int32 CodOrden)
        {
            frmPrincipal.CodigoPrincipal = CodOrden.ToString();
            FrmVerReporteSolicitud frm = new FrmVerReporteSolicitud();
            frm.Show();
        }

        private void btnGrabarPresupuesto_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (fun.ValidarFecha(txtFechaAltaOrden.Text) == false)
            {
                Mensaje("la fecha de ingreso de la orden es incorrecta");
                return ;
            }

            if (fun.ValidarFecha(txtFechaEntrega.Text) == false)
            {
                Mensaje("la fecha de ingreso de la orden es incorrecta");
                return ;
            }

            if (txtApellido.Text.ToString() == "")
            {
                Mensaje("Debe ingresar apellido");
                txtApellido.Focus();
                return;
            }

            if (txtNombre.Text.ToString() == "")
            {
                Mensaje("Debe ingresar nombre");
                txtNombre.Focus();
                return;
            }

            if (txtPatente.Text == "")
            {
                Mensaje("Debe ingresar una patente");
                txtPatente.Focus();
                return;
            }

            if (txtDescripcionVehiculo.Text.ToString() == "")
            {
                Mensaje("Debe ingresar una descripción");
                txtDescripcionVehiculo.Focus();
                return;
            }
            GrabarPresupuesto();
        }

        private void GrabarPresupuesto()
        {
            SqlConnection con = new SqlConnection(cConexion.Cadenacon());
            con.Open();
            SqlTransaction tranOrden;
            tranOrden = con.BeginTransaction("TranOrden");
            try
            {
               
                cCliente cliente = new cCliente();

                string apellidoCli = "";
                string nombreCli = "";
                string direccionCli = "";
                string telefonoCli = "";
                string nroDocumentoCli = "";
                string tipoDocumentoCli = "";
                string Direccion = "";
                if (txtCodCliente.Text.Trim() == "")
                {
                    //Inserta un cliente.

                    apellidoCli = txtApellido.Text.ToString();
                    nombreCli = txtNombre.Text.ToString();
                    Direccion = txtDireccion.Text;
                    direccionCli = "";
                    telefonoCli = txtTelefono.Text.ToString();
                    nroDocumentoCli = txtNroDoc.Text;
                    tipoDocumentoCli = null;
                    Int32? CodTipoDoc = null;
                    if (cmbTipoDoc.SelectedIndex > 0)
                        CodTipoDoc = Convert.ToInt32(cmbTipoDoc.SelectedIndex);
                    txtCodCliente.Text = cliente.InsertarClienteTran(con,
                                                 tranOrden,
                                                 apellidoCli,
                                                 nombreCli,
                                                 direccionCli,
                                                 telefonoCli,
                                                 CodTipoDoc,
                                                 "",
                                                 Direccion
                                                 ).ToString();


                }
                else
                {
                    //Modifica un cliente

                    apellidoCli = txtApellido.Text.ToString();
                    nombreCli = txtNombre.Text.ToString();
                    Direccion = txtDireccion.Text;
                    direccionCli = "";
                    telefonoCli = txtTelefono.Text.ToString();
                    nroDocumentoCli = txtNroDocumento.Text.ToString();
                    tipoDocumentoCli = cmbTipoDoc.Text.ToString();

                    cliente.ModificarClienteTran(con,
                                                tranOrden,
                                                txtCodCliente.Text.ToString().Trim(),
                                                apellidoCli,
                                                nombreCli,
                                                direccionCli,
                                                telefonoCli, null, "", Direccion);
                }

                cliente = null;

                string patenteAuto = "";
                string descripcionAuto = "";
                Int32 codMarcaAuto;
                Int32 anioAuto = 0;
                double precioVtaAuto = 0.0;
                string Chasis = "";
                string Motor = "";
                string Kilometros = "";
                Int32? CodTipoCombustible = null;
                if (cmbTipoCombustible.SelectedIndex > 0)
                    CodTipoCombustible = Convert.ToInt32(cmbTipoCombustible.SelectedValue);

                cAuto auto = new cAuto();

                if (txtCodAuto.Text.Trim() == "")
                {
                    //Inserta un auto.

                    codMarcaAuto = Int32.Parse(CmbMarca.SelectedValue.ToString().Trim());
                    descripcionAuto = txtDescripcionVehiculo.Text.ToString();
                    patenteAuto = txtPatente.Text.ToString();
                    Chasis = txtChasis.Text;
                    Motor = txtMotor.Text;
                    Kilometros = txtKms.Text;
                    txtCodAuto.Text = auto.InsertarAutoTran(con,
                                          tranOrden,
                                          codMarcaAuto,
                                          descripcionAuto,
                                          anioAuto.ToString().Trim(),
                                          precioVtaAuto,
                                          patenteAuto,
                                          txtCodCliente.Text.ToString().Trim(), Chasis, Motor, Kilometros, CodTipoCombustible).ToString();

                    // txtCodAuto.Text  = auto.GetSiguienteId(con, tranOrden).ToString().Trim();
                }
                else
                {
                    //Modificarta un auto.

                    codMarcaAuto = Int32.Parse(CmbMarca.SelectedValue.ToString().Trim());
                    descripcionAuto = txtDescripcionVehiculo.Text.ToString();
                    patenteAuto = txtPatente.Text.ToString();
                    Int32? kms = null;
                    if (txtKms.Text != "")
                        kms = Convert.ToInt32(txtKms.Text);
                    auto.ModificarAutoTran(con,
                                          tranOrden,
                                          txtCodAuto.Text.ToString().Trim(),
                                          codMarcaAuto.ToString(),
                                          descripcionAuto,
                                          patenteAuto,
                                          kms, CodTipoCombustible);

                }

                auto = null;
                //grabo la orden 
                DateTime Fecha = Convert.ToDateTime(txtFechaAltaOrden.Text);
                Int32? CodCliente = Convert.ToInt32(txtCodCliente.Text);
                Int32? CodAuto = Convert.ToInt32(txtCodAuto.Text);
                Double Total = 0;
                if (txtTotalPresupuesto.Text !="")
                {
                    Total = fun.ToDouble(txtTotalPresupuesto.Text);
                }
                cPresupuesto Prep = new cPresupuesto();
                Int32 CodPresupuesto = Prep.Insertar(con, tranOrden, CodCliente, CodAuto, Fecha, Total);
                frmPrincipal.CodigoPrincipal = CodPresupuesto.ToString();
                for (int i=0;i<tbDetallePresupuesto.Rows.Count;i++)
                {
                    Int32 CodArreglo = Convert.ToInt32(tbDetallePresupuesto.Rows[i]["CodArreglo"].ToString());
                    string NombreArreglo = tbDetallePresupuesto.Rows[i]["Nombre"].ToString();
                    Double PrecioArreglo = fun.ToDouble(tbDetallePresupuesto.Rows[i]["Precio"].ToString());
                    Prep.InsertarDetalle(con, tranOrden, CodPresupuesto, CodArreglo, NombreArreglo , PrecioArreglo);
                }
                tranOrden.Commit();
                con.Close();
                Mensaje("Presupuesto grabado correctamente");
                FrmVerPresupuesto form = new FrmVerPresupuesto();
                form.Show();
            }
            catch (Exception ex)
            {
                Mensaje("Error: " + ex.ToString());
                tranOrden.Rollback();
                con.Close();
                
            }
        }

        private void btnAgregarDetallePresupuesto_Click(object sender, EventArgs e)
        {
            if (txtNombreArreglo.Text =="")
            {
                Mensaje("Ingresar detalle");
                return;
            }

            if (txtPrecioArreglo.Text  == "")
            {
                Mensaje("Ingresar IngresarPrecio");
                return;
            }
            string Nombre = txtNombreArreglo.Text;
            string Precio = txtPrecioArreglo.Text;
            int CodArreglo = 0;
            for (int i=0;i<tbDetallePresupuesto.Rows.Count;i++)
            {
                if (tbDetallePresupuesto.Rows[i]["CodArreglo"].ToString() != "")
                    CodArreglo = Convert.ToInt32(tbDetallePresupuesto.Rows[i]["CodArreglo"].ToString());
            }
            CodArreglo++;  
            string Val = CodArreglo.ToString() + ";" + Nombre + ";" + Precio;
            cFunciones fun = new cFunciones();
            fun.AgregarFilas(tbDetallePresupuesto, Val);
            GrillaDetallePresupuesto.DataSource = tbDetallePresupuesto;
            fun.AnchoColumnas(GrillaDetallePresupuesto, "0;50;50");
            Double TotalPresupuesto = fun.TotalizarColumna(tbDetallePresupuesto, "Precio");
            txtTotalPresupuesto.Text = TotalPresupuesto.ToString();
            if (txtTotalPresupuesto.Text !="")
            {
                txtTotalPresupuesto.Text = fun.FormatoEnteroMiles(txtTotalPresupuesto.Text);
            }
            txtNombreArreglo.Text = "";
            txtPrecioArreglo.Text = "";
        }

        private void LimpiarPresupuesto()
        {
            tbDetallePresupuesto.Rows.Clear();
            GrillaDetallePresupuesto.DataSource = tbDetallePresupuesto;
            txtTotalPresupuesto.Text = "";
        }

        private void btnQuitarDetallePresupuesto_Click(object sender, EventArgs e)
        {
            if (GrillaDetallePresupuesto.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elemento");
                return;
            }
            cFunciones fun2 = new cFunciones();
            string CodArreglo = GrillaDetallePresupuesto.CurrentRow.Cells[0].Value.ToString();
            cTabla fun = new cTabla();
            tbDetallePresupuesto = fun.EliminarFila(tbDetallePresupuesto, "CodArreglo", CodArreglo);
            GrillaDetallePresupuesto.DataSource = tbDetallePresupuesto;
            Double TotalPresupuesto = fun.TotalizarColumna  (tbDetallePresupuesto, "Precio");
            txtTotalPresupuesto.Text = TotalPresupuesto.ToString();
            if (txtTotalPresupuesto.Text != "")
            {
                txtTotalPresupuesto.Text = fun2.FormatoEnteroMiles(txtTotalPresupuesto.Text);
            }
        }

        private void txtTotalTransferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e);
        }

        private void txtTotalTransferencia_Leave(object sender, EventArgs e)
        {
            if (txtTotalTransferencia.Text !="")
            {
                txtTotalTransferencia.Text = fun.SepararDecimales(txtTotalTransferencia.Text);
                txtTotalTransferencia.Text = fun.FormatoEnteroMiles(txtTotalTransferencia.Text);
            }
        }

        private void GrabarTransferencia(SqlConnection con, SqlTransaction tran,Int32 CodOrden, DateTime Fecha)
        {
            Double Importe = fun.ToDouble(txtTotalTransferencia.Text);
            cTransferencia obj = new cTransferencia();
            obj.Grabar(con, tran, CodOrden, Importe, Fecha);
            /*
            cMovimientoCaja mov = new cMovimientoCaja();
            string Descripcion = "Transferencia " + txtPatente.Text;
            mov.Insertar(con, tran, Descripcion, Importe, 0, Fecha, 2, "Transferencia", Convert.ToInt32 (CodOrden));
                */    
    }

        private void txtCuentaCorriente_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.SoloEnteroConPunto(sender, e); fun.SoloEnteroConPunto(sender, e);
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MuestraColumnaCosto == false)
                MuestraColumnaCosto = true;
            else
                MuestraColumnaCosto = false;
            string Col = "";
            if (MuestraColumnaCosto == false)
            {
                Col = "0;40;20;0;20;20;0";
            }
            else
            {
                Col = "0;30;15;15;15;25;0";
                GrillaInsumos.Columns[3].Visible = true;
            }
            cFunciones fun = new cFunciones();
            fun.AnchoColumnas(GrillaInsumos, Col);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtEfectivo.Text =="")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }
            Double Importe = Convert.ToDouble(txtEfectivo.Text);
            DateTime Fecha = dpFechaEfectivo.Value;
            Int32 CodOrden = 0;
            string Val = CodOrden.ToString() + ";" + Fecha.ToShortDateString();
            Val = Val + ";" + fun.FormatoEnteroMiles(Importe.ToString());
            tbEfectivo = fun.AgregarFilas(tbEfectivo, Val);
            GrillaEfectivo.DataSource = tbEfectivo;

        }

        private void GrabarPagosEfectivo(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            cMovimientoCaja mov = new cMovimientoCaja();
            cPagoEfectivo pago = new cPagoEfectivo(); 
            Int32 CodigoOrden = 0;
            DateTime Fecha = DateTime.Now;
            Double Importe = 0;
            string Descripcion = "";
            for (int i = 0; i < tbEfectivo.Rows.Count; i++)
            {
                CodigoOrden = Convert.ToInt32(tbEfectivo.Rows[i]["CodOrden"]);
                Fecha = Convert.ToDateTime(tbEfectivo.Rows[i]["Fecha"]);
                Importe = fun.ToDouble(tbEfectivo.Rows[i]["Importe"].ToString ());
                Descripcion = tbEfectivo.Rows[i]["Descripcion"].ToString();
                if (CodigoOrden == 0)
                {
                    pago.InsertarTran(con, Transaccion, CodOrden, Importe, Fecha, Descripcion);
                    mov.Insertar(con, Transaccion, Descripcion, Importe, 0, Fecha, 1, "Efectivo", CodOrden);
                }
                    
            }
        }

        private void GrabarPagosTransferencia(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden)
        {
            cMovimientoCaja mov = new cMovimientoCaja();
            cPagoTransferencia pago = new cPagoTransferencia();
            Int32 CodigoOrden = 0;
            DateTime Fecha = DateTime.Now;
            Double Importe = 0;
            string Descripcion = ""; 
            for (int i = 0; i < tbTransferencia.Rows.Count; i++)
            {
                CodigoOrden = Convert.ToInt32(tbTransferencia.Rows[i]["CodOrden"]);
                Fecha = Convert.ToDateTime(tbTransferencia.Rows[i]["Fecha"]);
                Importe = fun.ToDouble(tbTransferencia.Rows[i]["Importe"].ToString());
                Descripcion = tbTransferencia.Rows[i]["Descripcion"].ToString();
                if (CodigoOrden == 0)
                {
                    pago.InsertarTran(con, Transaccion, CodOrden, Importe, Fecha, Descripcion);
                    mov.Insertar(con, Transaccion, Descripcion, Importe, 0, Fecha, 2, "Transferencia", CodOrden);
                }

            }
        }

        public void BuscarPagoxCodOrden(Int32 CodOrden)
        {
            string Val = "";
            DateTime Fecha = DateTime.Now;
            Double Importe = 0;
            Int32 CodPago = 0;
            string Descripcion = "";
            tbEfectivo.Rows.Clear();
            cPagoEfectivo pago = new Clases.cPagoEfectivo();
            DataTable trdo = pago.GetPagosxCodOrden(CodOrden);
            for (int i = 0; i < trdo.Rows.Count  ; i++)
            {
                CodOrden = Convert.ToInt32(trdo.Rows[i]["CodOrden"]);
                Importe = Convert.ToDouble(trdo.Rows[i]["Importe"]);
                Fecha = Convert.ToDateTime(trdo.Rows[i]["Fecha"]);
                CodPago = Convert.ToInt32(trdo.Rows[i]["CodPago"]);
                Descripcion = trdo.Rows[i]["Descripcion"].ToString();
                Val = CodOrden.ToString() + ";" + Fecha.ToShortDateString() + ";" + fun.FormatoEnteroMiles(Importe.ToString()) + ";" + CodPago.ToString();
                Val = Val + ";" + Descripcion;
                tbEfectivo = fun.AgregarFilas(tbEfectivo, Val);
            }
            GrillaEfectivo.DataSource = tbEfectivo;
            fun.AnchoColumnas(GrillaEfectivo, "0;25;25;0;50");
        }

        public void BuscarPagoTransferenciaxCodOrden(Int32 CodOrden)
        {
            string Val = "";
            DateTime Fecha = DateTime.Now;
            Double Importe = 0;
            Int32 CodPago = 0;  
            string Descripcion = "";
            tbTransferencia.Rows.Clear();
            cPagoTransferencia pago = new Clases.cPagoTransferencia();
            DataTable trdo = pago.GetPagosxCodOrden(CodOrden);
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                CodOrden = Convert.ToInt32(trdo.Rows[i]["CodOrden"]);
                Importe = Convert.ToDouble(trdo.Rows[i]["Importe"]);
                Fecha = Convert.ToDateTime(trdo.Rows[i]["Fecha"]);
                CodPago = Convert.ToInt32(trdo.Rows[i]["CodPago"]);
                Descripcion = trdo.Rows[i]["Descripcion"].ToString();
                Val = CodOrden.ToString() + ";" + Fecha.ToShortDateString() + ";" + fun.FormatoEnteroMiles(Importe.ToString()) + ";" + CodPago.ToString();
                Val = Val + ";" + Descripcion;
                tbTransferencia = fun.AgregarFilas(tbTransferencia, Val);
            }
            GrillaTransferencia.DataSource = tbTransferencia;
            fun.AnchoColumnas(GrillaTransferencia, "0;25;25;0;50");
        }

        private void btnAgregarEfectivo_Click(object sender, EventArgs e)
        {
            if (txtEfectivo.Text == "")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }
            Double Importe = Convert.ToDouble(txtEfectivo.Text);
            DateTime Fecha = dpFechaEfectivo.Value;
            Int32 CodOrden = 0;
            Int32 CodPago = 0;
            string Descripcion = "";
            Descripcion = txtDescripcionEfectivo.Text;
            string Val = CodOrden.ToString() + ";" + Fecha.ToShortDateString();
            Val = Val + ";" + fun.FormatoEnteroMiles(Importe.ToString()) + ";" + CodPago.ToString();
            Val = Val + ";" + Descripcion;
            tbEfectivo = fun.AgregarFilas(tbEfectivo, Val);
            GrillaEfectivo.DataSource = tbEfectivo;
            CalcularSaldo();
            fun.AnchoColumnas(GrillaEfectivo, "0;25;25;0;50");
        }

        private void btnQuitarEfectivo_Click(object sender, EventArgs e)
        {
            if (GrillaEfectivo.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            } 
            Int32 CodPago = Convert.ToInt32(GrillaEfectivo.CurrentRow.Cells[3].Value);
            tbEfectivo = fun.EliminarFila (tbEfectivo, "CodPago", CodPago.ToString ());
            GrillaEfectivo.DataSource = tbEfectivo;
            if (CodPago > 0)
            {
                cPagoEfectivo pago = new Clases.cPagoEfectivo();
                pago.BorrarPago(CodPago);
                // aca actualiza el movimiento
            }
            CalcularSaldo();
        }

        private void btnAgregarTransferencia_Click(object sender, EventArgs e)
        {  
            if (txtImporteTransferencia.Text == "")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }
            Double Importe = Convert.ToDouble(txtImporteTransferencia.Text);
            DateTime Fecha = dpFechaTransferencia.Value;
            Int32 CodOrden = 0;
            Int32 CodPago = 0; 
            string Descripcion = "";
            Descripcion = txtDescripcionTransferencia.Text;
            string Val = CodOrden.ToString() + ";" + Fecha.ToShortDateString();
            Val = Val + ";" + fun.FormatoEnteroMiles(Importe.ToString()) + ";" + CodPago.ToString();
            Val = Val + ";" + Descripcion;
            tbTransferencia = fun.AgregarFilas(tbTransferencia, Val);
            GrillaTransferencia.DataSource = tbTransferencia;
            Double Total = fun.TotalizarColumna(tbTransferencia, "Importe");
            txtTotalTransferencia.Text = fun.FormatoEnteroMiles(Total.ToString());
            CalcularSaldo();
            fun.AnchoColumnas(GrillaTransferencia, "0;25;25;0;50");
        }

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            BuscarVehiculo();
        }

        private void CalcularSaldo()
        {
            Double Total = fun.ToDouble(txtTotalOrden.Text);
            Double Subtotal = 0;
            Double Saldo = 0;
            Double Efectivo = fun.TotalizarColumna(tbEfectivo, "Importe");
            Double Transferencia = fun.TotalizarColumna(tbTransferencia, "Importe");
            Double Documentos = 0;
            Double Tarjeta = 0;
            Double Cheque = 0;
            Double Garantia = 0;
            Double CuentaCorriente = 0;
            if (txtImporteGarantia.Text != "")
                Garantia = fun.ToDouble(txtImporteGarantia.Text);
            if (txtDocumento.Text != "")
                Documentos = fun.ToDouble(txtDocumento.Text);
            if (txtCuentaCorriente.Text != "")
                CuentaCorriente = fun.ToDouble(txtCuentaCorriente.Text);
            Tarjeta = fun.TotalizarColumna(tbTarjeta, "Importe");
            Cheque = fun.TotalizarColumna(tbCheques, "Importe");
            Subtotal = Efectivo + Transferencia + Documentos + Tarjeta + Cheque + Garantia + CuentaCorriente;
            Saldo = Total - Subtotal;
            txtSaldo.Text = fun.FormatoEnteroMiles(Saldo.ToString());
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            CalcularSaldo();
        }

        private void txtImporteGarantia_Leave(object sender, EventArgs e)
        {
            CalcularSaldo();
        }

        private void txtCuentaCorriente_Leave(object sender, EventArgs e)
        {
            CalcularSaldo();
        }

        private void btnQuitarTransferencia_Click(object sender, EventArgs e)
        {  
            if (GrillaTransferencia.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Int32 CodPago = Convert.ToInt32(GrillaTransferencia.CurrentRow.Cells[3].Value);
            tbTransferencia = fun.EliminarFila(tbTransferencia, "CodPago", CodPago.ToString());
            GrillaTransferencia.DataSource = tbTransferencia;
            if (CodPago > 0)
            {
                cPagoTransferencia  pago = new Clases.cPagoTransferencia();
                pago.BorrarPago(CodPago);
                // aca actualiza el movimiento
            }
            Double Total = fun.TotalizarColumna(tbTransferencia, "Importe");
            txtTotalTransferencia.Text = fun.FormatoEnteroMiles(Total.ToString());
            CalcularSaldo();
        }
    }

}
