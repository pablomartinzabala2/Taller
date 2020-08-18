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
    public partial class FrmControl : Form
    {
        public FrmControl()
        {
            InitializeComponent();
        }

        private void FrmControl_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            lblVencidas.BackColor = Color.LightGreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int ConDeuda = 0;
            if (ChkVencida.Checked == true)
                ConDeuda = 1;
            Clases.cFunciones fun = new Clases.cFunciones();
            Int32? CodOrden = null;
            DataTable tResul = fun.CrearTabla("Codigo;Tipo;Orden;Patente;Descripcion;Apellido;Telefono;Celular;Importe;Saldo;Fecha;Vencimiento;Cupon");
            if (txtPatente.Text == "" && txtApellido.Text == "" && txtCodOrden.Text ==""  )
            {
                CodOrden = -1;
            }
            
            if (txtCodOrden.Text != "")
                CodOrden = Convert.ToInt32(txtCodOrden.Text);
            string Cupon = "";
            if (txtCupon.Text != "")
                Cupon = txtCupon.Text;

            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            string Valor = "";
            cCheque cheque = new cCheque();
            DataTable tcheque = cheque.GetChequesAdeudados(txtPatente.Text, txtApellido.Text, Fecha, ConDeuda, CodOrden);
            for (int i = 0; i < tcheque.Rows.Count; i++)
            {
                Valor = tcheque.Rows[i]["CodCheque"].ToString();
                Valor = Valor + ";" + "Cheque";
                Valor = Valor + ";" + tcheque.Rows[i]["CodOrden"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Patente"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Descripcion1"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Apellido"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Telefono"].ToString();
                Valor = Valor + ";"; //+ tcheque.Rows[i]["Celular"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["Fecha"].ToString();
                Valor = Valor + ";" + tcheque.Rows[i]["FechaVto"].ToString();
                Valor = Valor + "; ";
                if (Cupon =="")
                tResul = fun.AgregarFilas(tResul, Valor);
            }

            cGarantia garant = new cGarantia();
            DataTable tGar = garant.GetGarantiasAdeudadas(txtPatente.Text, txtApellido.Text, Fecha, ConDeuda, CodOrden);
            for (int i = 0; i < tGar.Rows.Count; i++)
            {
                Valor = tGar.Rows[i]["CodGarantia"].ToString();
                Valor = Valor + ";" + "Garantía";
                Valor = Valor + ";" + tGar.Rows[i]["CodOrden"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Patente"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Descripcion1"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Apellido"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Telefono"].ToString();
                Valor = Valor + ";"; //+ tcheque.Rows[i]["Celular"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tGar.Rows[i]["Fecha"].ToString();
                Valor = Valor + "; ";
                Valor = Valor + "; ";
                if (Cupon == "") 
                tResul = fun.AgregarFilas(tResul, Valor);
            }

            cDocumento doc = new cDocumento();
            DataTable tdoc = doc.GetDocumentosAdeudados(txtPatente.Text, txtApellido.Text, Fecha, ConDeuda, CodOrden);

            for (int i = 0; i < tdoc.Rows.Count; i++)
            {
                Valor = tdoc.Rows[i]["CodDocumento"].ToString();
                Valor = Valor + ";" + "Documento";
                Valor = Valor + ";" + tdoc.Rows[i]["CodOrden"].ToString();
                Valor = Valor + ";" + tdoc.Rows[i]["Patente"].ToString();
                Valor = Valor + ";" + tdoc.Rows[i]["Descripcion1"].ToString();
                Valor = Valor + ";" + tdoc.Rows[i]["Apellido"].ToString();
                Valor = Valor + ";" + tdoc.Rows[i]["Telefono"].ToString();
                Valor = Valor + ";"; //+ tcheque.Rows[i]["Celular"].ToString();
                Valor = Valor + ";" + tdoc.Rows[i]["Importe"].ToString();
                
                Valor = Valor + ";" + tdoc.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tdoc.Rows[i]["Fecha"].ToString();
                Valor = Valor + "; ";
                Valor = Valor + "; ";
                if (Cupon == "")
                tResul = fun.AgregarFilas(tResul, Valor);
            }

            cCobroTarjeta cobro = new cCobroTarjeta();
            DataTable tcobro = cobro.GetCobrotarjetaAdeudada(txtPatente.Text, txtApellido.Text, Fecha, ConDeuda, CodOrden, Cupon);
            for (int i = 0; i < tcobro.Rows.Count; i++)
            {
                Valor = tcobro.Rows[i]["CodCobro"].ToString();
                Valor = Valor + ";" + "Tarjeta";
                Valor = Valor + ";" + tcobro.Rows[i]["CodOrden"].ToString();
                Valor = Valor + ";" + tcobro.Rows[i]["Patente"].ToString();
                Valor = Valor + ";" + tcobro.Rows[i]["Descripcion1"].ToString();
                Valor = Valor + ";" + tcobro.Rows[i]["Apellido"].ToString();
                Valor = Valor + ";" + tcobro.Rows[i]["Telefono"].ToString();
                Valor = Valor + ";"; //+ tcheque.Rows[i]["Celular"].ToString();
                Valor = Valor + ";" + tcobro.Rows[i]["Importe"].ToString();
                
                Valor = Valor + ";" + tcobro.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tcobro.Rows[i]["Fecha"].ToString();
                Valor = Valor + "; ";
                Valor = Valor + ";" + tcobro.Rows[i]["Cupon"].ToString();
                
                tResul = fun.AgregarFilas(tResul, Valor);
            }
            double Total = fun.TotalizarColumna(tResul, "Saldo");
            txtTotal.Text = Total.ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            tResul = fun.TablaaMiles(tResul, "Importe");
            tResul = fun.TablaaMiles(tResul, "Saldo");
            Grilla.DataSource = tResul;
            Grilla.Columns[0].Visible = false;
            //Grilla.Columns[4].Visible = false;
            Grilla.Columns[7].Visible = false;
            Pintar();
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnCobroPrenda_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            string Tipo = Grilla.CurrentRow.Cells[1].Value.ToString();
            switch (Tipo)
            {
                case "Garantía":
                    frmPrincipal.CodigoPrincipal = Codigo;
            FrmPagoGarantia pago = new FrmPagoGarantia();
            pago.ShowDialog();
                    break;
                case "Documento":
                    frmPrincipal.CodigoPrincipal = Codigo;
            FrmCobroDocumentos frm = new FrmCobroDocumentos();
            frm.ShowDialog();
                    break;
                case "Tarjeta":
                    frmPrincipal.CodigoPrincipal= Codigo;
            FrmCobroTarjeta frmCobro = new FrmCobroTarjeta ();
            frmCobro.ShowDialog ();
                    break;
                case "Cheque":
                    frmPrincipal.CodigoPrincipal = Codigo;
                    FrmCobroCheque cob = new FrmCobroCheque();
                    cob.ShowDialog();
                    break;
            }
        }

        private void txtCodOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.SoloEnteroConPunto(sender, e);
        }

        private void Pintar()
        {
            string Tipo = "";
            DateTime? Vencimiento;
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Tipo = Grilla.Rows[i].Cells[1].Value.ToString(); Grilla.Rows[i].Cells[10].Value.ToString();
                if (Grilla.Rows[i].Cells[11].Value.ToString() != "" && Grilla.Rows[i].Cells[11].Value.ToString().Length >4 ) 
                    Vencimiento = Convert.ToDateTime(Grilla.Rows[i].Cells[11].Value.ToString());
                else
                    Vencimiento = null;
                if (Vencimiento != null)
                {
                    if (Convert.ToDateTime(Vencimiento) < Fecha)
                    {
                        Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }
    }
}
