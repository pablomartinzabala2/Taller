namespace SistemadeTaller
{
    partial class FrmInformeMecanicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnVetOrden = new System.Windows.Forms.Button();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-99, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Fecha desde";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 34);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe de producción";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Grafico);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.Grilla);
            this.panel2.Controls.Add(this.btnVetOrden);
            this.panel2.Controls.Add(this.txtFechaHasta);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFechaDesde);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(4, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 416);
            this.panel2.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemadeTaller.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(410, 11);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(31, 28);
            this.btnEliminar.TabIndex = 104;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(17, 47);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(494, 98);
            this.Grilla.TabIndex = 103;
            // 
            // btnVetOrden
            // 
            this.btnVetOrden.Image = global::SistemadeTaller.Properties.Resources.zoom;
            this.btnVetOrden.Location = new System.Drawing.Point(373, 13);
            this.btnVetOrden.Name = "btnVetOrden";
            this.btnVetOrden.Size = new System.Drawing.Size(31, 28);
            this.btnVetOrden.TabIndex = 71;
            this.btnVetOrden.UseVisualStyleBackColor = true;
            this.btnVetOrden.Click += new System.EventHandler(this.btnVetOrden_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(291, 16);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(76, 23);
            this.txtFechaHasta.TabIndex = 65;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Fecha Hasta";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(110, 16);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(76, 23);
            this.txtFechaDesde.TabIndex = 61;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha desde";
            // 
            // Grafico
            // 
            chartArea2.Name = "ChartArea1";
            this.Grafico.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Grafico.Legends.Add(legend2);
            this.Grafico.Location = new System.Drawing.Point(17, 151);
            this.Grafico.Name = "Grafico";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Grafico.Series.Add(series2);
            this.Grafico.Size = new System.Drawing.Size(504, 258);
            this.Grafico.TabIndex = 105;
            this.Grafico.Text = "chart1";
            // 
            // FrmInformeMecanicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(545, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformeMecanicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmInformeMecanicos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnVetOrden;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart Grafico;
    }
}