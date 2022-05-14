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
    public partial class FrmBorrar : Form
    {
        public FrmBorrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClave.Text =="PABLO")
            {
                Borrar();
            }

        }

        private void FrmBorrar_Load(object sender, EventArgs e)
        {

        }

        private void Borrar ()
        {
            string sql = "TRUNCATE TABLE  Cheque";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE CobroDocumento";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE CobroCheque";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE CobroTarjeta";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE Documento";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE Garantia";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE Insumo";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE Movimientos";
            sql = "TRUNCATE TABLE compra";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE DetalleCompra";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE Insumo";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE vale";
            cDb.ExecutarNonQuery(sql);

            sql = "delete from  OrdenDetalle";
            cDb.ExecutarNonQuery(sql);
            sql = "delete from Orden";
            cDb.ExecutarNonQuery(sql);
            sql = "delete from movimientos";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE DetalleVenta";
            cDb.ExecutarNonQuery(sql);
            sql = "TRUNCATE TABLE Venta";
            cDb.ExecutarNonQuery(sql);

            MessageBox.Show("Datos Borrados");
        }
    }
}
