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
    public partial class FrmCompraInsumo : Form
    {
        DataTable tbInsumos;
        cTabla tabla;
        cFunciones fun;
        public FrmCompraInsumo()
        {
            InitializeComponent();
        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            FrmBuscarInsumo frm = new FrmBuscarInsumo();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmPrincipal.CodigoPrincipal !=null)
            {
                Int32 CodInsumo = Convert.ToInt32(frmPrincipal.CodigoPrincipal);
                BuscarInsumoxCodigo(CodInsumo);
            }
        }

        private void FrmCompraInsumo_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            tabla = new cTabla();
            fun = new cFunciones();
            string Columnas = "CodInsumo;Nombre;Cantidad;CantidadTotal;Precio;PrecioVenta";
            tbInsumos = tabla.CrearTabla(Columnas);
            fun.LlenarCombo(CmbProveedor, "Proveedor", "Nombre", "CodProveedor");
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                Mensaje("Debe seleccionar un insumo");
                return;
            }

            if (txtIngresarStock.Text == "")
            {
                Mensaje("Debe ingresar una cantidad de stock");
                return;
            }

            if (txt_Precio.Text  == "")
            {
                Mensaje("Debe ingresar un Precio");
                return;
            }
            if (tabla.Buscar(tbInsumos, "CodInsumo", txtCodigo.Text) == true)
            {
                Mensaje("Ya se ha ingresado el repuesto");
                return;
            }
            Double PrecioVenta = 0;
            Int32 Cantidad = Convert.ToInt32(txtCantidad.Text);
            Int32 IngresarCantidad = Convert.ToInt32(txtIngresarStock.Text);
            Int32 Cantidadtotal = Cantidad + IngresarCantidad;
            string Nombre = txt_Nombre.Text;
            double Precio = fun.ToDouble(txt_Precio.Text);
            double PrecioIva = Precio;
            if (txtPrecioVenta.Text != "")
                PrecioVenta = fun.ToDouble(txtPrecioVenta.Text);
            if (chkAplicarIva.Checked == true)
            {
                double PorIva = 0.21 * Precio;
                PrecioIva = PrecioIva + PorIva;
                PrecioIva = Math.Round(PrecioIva, 0);
            }
            string Valores = txtCodigo.Text;
            Valores = Valores + ";" + Nombre;
            Valores = Valores + ";" + IngresarCantidad;
            Valores = Valores + ";" + Cantidadtotal;
            Valores = Valores + ";" + PrecioIva;
            Valores = Valores + ";" + PrecioVenta.ToString();
            tbInsumos = tabla.AgregarFilas(tbInsumos, Valores);
            Grilla.DataSource = tbInsumos;
            Grilla.Columns[3].HeaderText = "Stock Total";
            Grilla.Columns[5].HeaderText = "Venta";
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[3].Width = 120;
            Grilla.Columns[1].Width = 200; 
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un repuesto");
                return;
            }
            string CodInsumo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbInsumos = tabla.EliminarFila(tbInsumos, "CodInsumo", CodInsumo.ToString());
            Grilla.DataSource = tbInsumos;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (fun.ValidarFecha(txtFecha.Text) == false)
            {
                Mensaje("La fecha ingresada es incorrecta");
                return;
            }
            if (Grilla.Rows.Count < 1)
            {
                Mensaje("Debe ingresar insumos para continuar");
                return;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            Int32 CodCompra = 0;
            Double PrecioVenta = 0;
            Int32? CodProveedor =null ;
            if (CmbProveedor.SelectedIndex >0)
                CodProveedor = Convert.ToInt32 (CmbProveedor.SelectedValue);
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            cCompra objCompra = new cCompra();
            cDetalleCompra objDetalle = new cDetalleCompra();
            cMovimiento mov = new cMovimiento();
            string Descripcion = "";
            try
            {
                cInsumo insumo = new cInsumo();
                CodCompra = objCompra.InsertarCompra(con, Transaccion, Fecha, CodProveedor, txtFactura.Text);
                for (int i = 0; i < Grilla.Rows.Count - 1; i++)
                {
                    Int32 CodInsumo = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value.ToString());
                    string Insumo = Grilla.Rows[i].Cells[1].Value.ToString();
                    Int32 Cantidad = Convert.ToInt32(Grilla.Rows[i].Cells[2].Value.ToString());
                    double Precio = Convert.ToDouble(Grilla.Rows[i].Cells[4].Value.ToString().Replace (",","."));
                    double Total = Cantidad * Precio;
                    Descripcion = "COMPRA REPUESTO " + Insumo.ToString();
                    Descripcion = Descripcion + ", CANTIDAD " + Cantidad.ToString();
                    if (Grilla.Rows[i].Cells["PrecioVenta"].ToString() != "")
                        PrecioVenta = fun.ToDouble(Grilla.Rows[i].Cells["PrecioVenta"].Value.ToString());
                    mov.GrabarMovimientoTransaccion(con, Transaccion,-1* Total, Descripcion, Fecha, 1, null);
                    objDetalle.InsertarDetalle(con, Transaccion, CodCompra, CodInsumo, Cantidad, Precio);
                    insumo.ActualizarStock(con, Transaccion, CodInsumo, Cantidad);
                    insumo.ActualizarPrecio(con, Transaccion, CodInsumo, Precio, PrecioVenta);
                }
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados correctamente");
                Limpiar();
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                con.Close();
                MessageBox.Show("Hubo un error en el proceso de grabación", Clases.cMensaje.Mensaje());
            }

        }

        private void txtIngresarStock_KeyPress(object sender, KeyPressEventArgs e)
        {
             fun.SoloEnteroConPunto(sender, e);
        }

        private void Limpiar()
        {
            tbInsumos.Clear();
            txt_Nombre.Text = "";
            txtPrecioVenta.Text = "";
            CmbProveedor.SelectedIndex = 0;
            txtIngresarStock.Text = "";
            txt_Precio.Text = "";
            Grilla.DataSource = null;
            txtFactura.Text = "";
            txtCantidad.Text = ""; 
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            string Codigo = txtCodigoBarra.Text;
            BuscarInsumoxCodBarra(Codigo);
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
                txtCodigo.Text = "";
                txtCantidad.Text = "";
                txt_Precio.Text = "";
                txt_Nombre.Text = "";
                txtPrecioVenta.Text = "";
            }
        }

        private void BuscarInsumoxCodigo(Int32 CodInsumo)
        {
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
            }
        }
    }
}
