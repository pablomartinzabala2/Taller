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
    public partial class frmPrincipal : Form
    {
        public static  string CodigoPrincipal;
        
        private int childFormNumber = 0;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            { 
                case "Nueva Orden de Trabajo":

                    FrmIngresoOrden childFormIngresoOrden = new FrmIngresoOrden();
                    childFormIngresoOrden.MdiParent = this;
                    //childFormIngresoOrden.Text = "Ventana " + childFormNumber++;
                    childFormIngresoOrden.Show();

                    break;

                case "Ejecutar Orden de Trabajo":

                    FrmEjecutarOrden childFormEjecutaOrden = new FrmEjecutarOrden();
                    childFormEjecutaOrden.MdiParent = this;
                    //childFormEjecutaOrden.Text = "Ventana " + childFormNumber++;
                    childFormEjecutaOrden.Show();

                    break;

                case "Salir":

                    Close();

                    break;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Clases.cAlarma alarma = new Clases.cAlarma();
            DataTable trdo = alarma.GetAlarmasxFecha(DateTime.Now);
            if (trdo.Rows.Count > 0)
            {
                FrmAlertas frm = new FrmAlertas();
                frm.ShowDialog();
            }
            VerificarUsuario();
        }

        public void VerificarUsuario()
        {
            cUsuario usu = new cUsuario();
            Int32 CodUsuario = Convert.ToInt32(Principal.CodUsuarioLogueado);
            string Nombre = usu.GetNombreUsuarioxCodUsuario(CodUsuario);
            if (Nombre.ToUpper() != "SERGIO")
            {
                menuRentabilidad.Visible = false;
            }
            else
            {
                menuRentabilidad.Visible = true;
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MenuIngresarOrden_Click(object sender, EventArgs e)
        {
            frmPrincipal.CodigoPrincipal = null;
            FrmIngresoOrden childFormEjecutaOrden = new FrmIngresoOrden();
            
            childFormEjecutaOrden.MdiParent = this;
            childFormEjecutaOrden.Show();
       
        }

        private void nuevaOrdenDeTrabajo_Click(object sender, EventArgs e)
        {
            FrmIngresoOrden childFormEjecutaOrden = new FrmIngresoOrden();
            childFormEjecutaOrden.MdiParent = this;
            childFormEjecutaOrden.Show();
        }

        private void MenuListadoOrdenes_Click(object sender, EventArgs e)
        {
            FrmEjecutarOrden frm = new FrmEjecutarOrden();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAbmMecanico  Form = new FrmAbmMecanico();
            Form.MdiParent = this;
            Form.Show();
        }

        private void MenuresumenDeCuentas_Click(object sender, EventArgs e)
        {
            FrmInformeCuentas Form = new FrmInformeCuentas();
            Form.MdiParent = this;
            Form.Show();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoDocumentos Form = new FrmListadoDocumentos();
            Form.MdiParent = this;
            Form.Show();
        }

        private void chequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoCheques Form = new FrmListadoCheques();
            Form.MdiParent = this;
            Form.Show();
        }

        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoTarjeta Form = new FrmListadoTarjeta();
            Form.MdiParent = this;
            Form.Show();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoMovimientos Form = new FrmListadoMovimientos();
            Form.MdiParent = this;
            Form.Show();
        }

        private void resumenDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformeCuentas frm = new FrmInformeCuentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void borrarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBorrar frm = new FrmBorrar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void garantíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoGarantia frm = new FrmListadoGarantia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gastosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoGastosGenerales frm = new FrmListadoGastosGenerales();
            frm.MdiParent = this;
            frm.Show();
        }

        private void insumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbmInsumo frm = new FrmAbmInsumo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void actualizarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraInsumo frm = new FrmCompraInsumo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoStock frm = new FrmListadoStock();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbmProveedor frm = new FrmAbmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoCompras frm = new FrmListadoCompras();
            frm.MdiParent = this;
            frm.Show();
        }

        private void valesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoVales frm = new FrmListadoVales();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ejecutaOrdenDeTrabajo_Click(object sender, EventArgs e)
        {
            FrmEjecutarOrden frm = new FrmEjecutarOrden();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirSistema_Click(object sender, EventArgs e)
        {
            FrmAbmInsumo frm = new FrmAbmInsumo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmRegistrarAlertascs frm = new FrmRegistrarAlertascs();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackUp frm = new FrmBackUp();
            frm.ShowDialog();
        }

        private void menuRentabilidad_Click(object sender, EventArgs e)
        {
            FrmRentabilidad frm = new FrmRentabilidad();
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmAbmMecanico frm = new FrmAbmMecanico();
            frm.MdiParent = this;
            frm.Show();
        }

        private void controlDeOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControl frm = new FrmControl();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoVentas frm = new FrmListadoVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTurnos frm = new FrmTurnos();
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmConsultaTurnoscs form = new SistemadeTaller.FrmConsultaTurnoscs();
            form.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmInformeMecanicos fr = new FrmInformeMecanicos();
            fr.Show();
        }
    }
}
