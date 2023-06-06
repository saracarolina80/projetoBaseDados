using System;
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
    public partial class fornecedor : Form
    {
        public fornecedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registoFornecedor registo = new registoFornecedor();
            registo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FornecedorProduto fp = new FornecedorProduto();
            fp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Produtos p = new Produtos();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckPedidos pedidos = new CheckPedidos();
            pedidos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumeroPedidos np = new NumeroPedidos();
            np.Show();
        }
    }
}
