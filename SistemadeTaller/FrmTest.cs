﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemadeTaller
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            frmPrincipal.CodigoPrincipal = "6";
            FrmVerPresupuesto form = new FrmVerPresupuesto();
            form.Show();
        }
    }
}
