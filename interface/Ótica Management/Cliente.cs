﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            compra.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MarcarConsulta mc = new MarcarConsulta();
            mc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recibos recibos = new Recibos();
            recibos.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GastoProdutos gp = new GastoProdutos();
            gp.Show();
        }
    }
}
