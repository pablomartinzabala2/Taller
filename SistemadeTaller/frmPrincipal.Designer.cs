namespace SistemadeTaller
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.insumoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIngresarOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuListadoOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chequesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarjetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.garantíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gastosGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.almacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRentabilidad = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeOperacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.ToolStrip();
            this.nuevaOrdenDeTrabajo = new System.Windows.Forms.ToolStripButton();
            this.ejecutaOrdenDeTrabajo = new System.Windows.Forms.ToolStripButton();
            this.salirSistema = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArchivo,
            this.MenuOrden,
            this.listadoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // MenuArchivo
            // 
            this.MenuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insumoToolStripMenuItem,
            this.actualizarStockToolStripMenuItem,
            this.proveedorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cToolStripMenuItem,
            this.registroDeTurnosToolStripMenuItem});
            this.MenuArchivo.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.MenuArchivo.Name = "MenuArchivo";
            this.MenuArchivo.Size = new System.Drawing.Size(60, 20);
            this.MenuArchivo.Text = "Archivo";
            // 
            // insumoToolStripMenuItem
            // 
            this.insumoToolStripMenuItem.Name = "insumoToolStripMenuItem";
            this.insumoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.insumoToolStripMenuItem.Text = "Insumo";
            this.insumoToolStripMenuItem.Click += new System.EventHandler(this.insumoToolStripMenuItem_Click);
            // 
            // actualizarStockToolStripMenuItem
            // 
            this.actualizarStockToolStripMenuItem.Name = "actualizarStockToolStripMenuItem";
            this.actualizarStockToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.actualizarStockToolStripMenuItem.Text = "Actualizar stock";
            this.actualizarStockToolStripMenuItem.Click += new System.EventHandler(this.actualizarStockToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem2.Text = "Mecánico";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cToolStripMenuItem.Text = "Copia de seguridad";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // registroDeTurnosToolStripMenuItem
            // 
            this.registroDeTurnosToolStripMenuItem.Name = "registroDeTurnosToolStripMenuItem";
            this.registroDeTurnosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.registroDeTurnosToolStripMenuItem.Text = "Registro de turnos";
            this.registroDeTurnosToolStripMenuItem.Click += new System.EventHandler(this.registroDeTurnosToolStripMenuItem_Click);
            // 
            // MenuOrden
            // 
            this.MenuOrden.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuIngresarOrden,
            this.MenuListadoOrdenes});
            this.MenuOrden.Name = "MenuOrden";
            this.MenuOrden.Size = new System.Drawing.Size(52, 20);
            this.MenuOrden.Text = "Orden";
            // 
            // MenuIngresarOrden
            // 
            this.MenuIngresarOrden.Name = "MenuIngresarOrden";
            this.MenuIngresarOrden.Size = new System.Drawing.Size(116, 22);
            this.MenuIngresarOrden.Text = "Ingresar";
            this.MenuIngresarOrden.Click += new System.EventHandler(this.MenuIngresarOrden_Click);
            // 
            // MenuListadoOrdenes
            // 
            this.MenuListadoOrdenes.Name = "MenuListadoOrdenes";
            this.MenuListadoOrdenes.Size = new System.Drawing.Size(116, 22);
            this.MenuListadoOrdenes.Text = "Listado";
            this.MenuListadoOrdenes.Click += new System.EventHandler(this.MenuListadoOrdenes_Click);
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resumenDeCuentasToolStripMenuItem,
            this.mToolStripMenuItem,
            this.documentosToolStripMenuItem,
            this.chequesToolStripMenuItem,
            this.tarjetasToolStripMenuItem,
            this.garantíaToolStripMenuItem,
            this.gastosGeneralesToolStripMenuItem,
            this.almacenToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.valesToolStripMenuItem,
            this.menuRentabilidad,
            this.controlDeOperacionesToolStripMenuItem,
            this.ventaToolStripMenuItem});
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.listadoToolStripMenuItem.Text = "Listado";
            // 
            // resumenDeCuentasToolStripMenuItem
            // 
            this.resumenDeCuentasToolStripMenuItem.Name = "resumenDeCuentasToolStripMenuItem";
            this.resumenDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.resumenDeCuentasToolStripMenuItem.Text = "Resumen de cuentas";
            this.resumenDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.resumenDeCuentasToolStripMenuItem_Click);
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mToolStripMenuItem.Text = "Movimientos";
            this.mToolStripMenuItem.Click += new System.EventHandler(this.mToolStripMenuItem_Click);
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.documentosToolStripMenuItem.Text = "Documentos";
            this.documentosToolStripMenuItem.Click += new System.EventHandler(this.documentosToolStripMenuItem_Click);
            // 
            // chequesToolStripMenuItem
            // 
            this.chequesToolStripMenuItem.Name = "chequesToolStripMenuItem";
            this.chequesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.chequesToolStripMenuItem.Text = "Cheques";
            this.chequesToolStripMenuItem.Click += new System.EventHandler(this.chequesToolStripMenuItem_Click);
            // 
            // tarjetasToolStripMenuItem
            // 
            this.tarjetasToolStripMenuItem.Name = "tarjetasToolStripMenuItem";
            this.tarjetasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.tarjetasToolStripMenuItem.Text = "Tarjetas";
            this.tarjetasToolStripMenuItem.Click += new System.EventHandler(this.tarjetasToolStripMenuItem_Click);
            // 
            // garantíaToolStripMenuItem
            // 
            this.garantíaToolStripMenuItem.Name = "garantíaToolStripMenuItem";
            this.garantíaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.garantíaToolStripMenuItem.Text = "Garantía";
            this.garantíaToolStripMenuItem.Click += new System.EventHandler(this.garantíaToolStripMenuItem_Click);
            // 
            // gastosGeneralesToolStripMenuItem
            // 
            this.gastosGeneralesToolStripMenuItem.Name = "gastosGeneralesToolStripMenuItem";
            this.gastosGeneralesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.gastosGeneralesToolStripMenuItem.Text = "Gastos generales";
            this.gastosGeneralesToolStripMenuItem.Click += new System.EventHandler(this.gastosGeneralesToolStripMenuItem_Click);
            // 
            // almacenToolStripMenuItem
            // 
            this.almacenToolStripMenuItem.Name = "almacenToolStripMenuItem";
            this.almacenToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.almacenToolStripMenuItem.Text = "Almacen";
            this.almacenToolStripMenuItem.Click += new System.EventHandler(this.almacenToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // valesToolStripMenuItem
            // 
            this.valesToolStripMenuItem.Name = "valesToolStripMenuItem";
            this.valesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.valesToolStripMenuItem.Text = "Vales";
            this.valesToolStripMenuItem.Click += new System.EventHandler(this.valesToolStripMenuItem_Click);
            // 
            // menuRentabilidad
            // 
            this.menuRentabilidad.Name = "menuRentabilidad";
            this.menuRentabilidad.Size = new System.Drawing.Size(197, 22);
            this.menuRentabilidad.Text = "Rentabilidad";
            this.menuRentabilidad.Click += new System.EventHandler(this.menuRentabilidad_Click);
            // 
            // controlDeOperacionesToolStripMenuItem
            // 
            this.controlDeOperacionesToolStripMenuItem.Name = "controlDeOperacionesToolStripMenuItem";
            this.controlDeOperacionesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.controlDeOperacionesToolStripMenuItem.Text = "Control de operaciones";
            this.controlDeOperacionesToolStripMenuItem.Click += new System.EventHandler(this.controlDeOperacionesToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaOrdenDeTrabajo,
            this.ejecutaOrdenDeTrabajo,
            this.salirSistema,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 24);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(632, 39);
            this.menuPrincipal.TabIndex = 5;
            this.menuPrincipal.Text = "ToolStrip";
            // 
            // nuevaOrdenDeTrabajo
            // 
            this.nuevaOrdenDeTrabajo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevaOrdenDeTrabajo.Image = ((System.Drawing.Image)(resources.GetObject("nuevaOrdenDeTrabajo.Image")));
            this.nuevaOrdenDeTrabajo.ImageTransparentColor = System.Drawing.Color.Black;
            this.nuevaOrdenDeTrabajo.Name = "nuevaOrdenDeTrabajo";
            this.nuevaOrdenDeTrabajo.Size = new System.Drawing.Size(36, 36);
            this.nuevaOrdenDeTrabajo.Text = "Nueva Orden de Trabajo";
            this.nuevaOrdenDeTrabajo.Click += new System.EventHandler(this.nuevaOrdenDeTrabajo_Click);
            // 
            // ejecutaOrdenDeTrabajo
            // 
            this.ejecutaOrdenDeTrabajo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ejecutaOrdenDeTrabajo.Image = ((System.Drawing.Image)(resources.GetObject("ejecutaOrdenDeTrabajo.Image")));
            this.ejecutaOrdenDeTrabajo.ImageTransparentColor = System.Drawing.Color.Black;
            this.ejecutaOrdenDeTrabajo.Name = "ejecutaOrdenDeTrabajo";
            this.ejecutaOrdenDeTrabajo.Size = new System.Drawing.Size(36, 36);
            this.ejecutaOrdenDeTrabajo.Text = "Listado de ordenes de Trabajo";
            this.ejecutaOrdenDeTrabajo.Click += new System.EventHandler(this.ejecutaOrdenDeTrabajo_Click);
            // 
            // salirSistema
            // 
            this.salirSistema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salirSistema.Image = global::SistemadeTaller.Properties.Resources.package_development_32x32_32;
            this.salirSistema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salirSistema.Name = "salirSistema";
            this.salirSistema.Size = new System.Drawing.Size(36, 36);
            this.salirSistema.Text = "Insumos";
            this.salirSistema.Click += new System.EventHandler(this.salirSistema_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Alertas";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::SistemadeTaller.Properties.Resources.Agenda;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA TALLER";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo;
        private System.Windows.Forms.ToolStrip menuPrincipal;
        private System.Windows.Forms.ToolStripButton nuevaOrdenDeTrabajo;
        private System.Windows.Forms.ToolStripButton ejecutaOrdenDeTrabajo;
        private System.Windows.Forms.ToolStripButton salirSistema;
        private System.Windows.Forms.ToolStripMenuItem MenuOrden;
        private System.Windows.Forms.ToolStripMenuItem MenuIngresarOrden;
        private System.Windows.Forms.ToolStripMenuItem MenuListadoOrdenes;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chequesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarjetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem garantíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gastosGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insumoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenDeCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem almacenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRentabilidad;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeOperacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}



