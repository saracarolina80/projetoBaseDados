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
    public partial class Doutor : Form
    {
        public Doutor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            infoCliente info = new infoCliente();

            info.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Receita receita = new Receita();
            receita.Show();
        }
    }
}
