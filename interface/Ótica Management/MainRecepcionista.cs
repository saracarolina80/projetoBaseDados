using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Ótica_Management
{
    public partial class MainRecepcionista : Form
    {

        private SqlConnection CN;


        // CONNECT TO DB
        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = " + ChangeData.DB_string + " ;" + "Initial Catalog = " + ChangeData.username + "; uid = " + ChangeData.username + ";" + "password = " + ChangeData.password);
        }

        private bool TestDBConnection()
        {
            bool temp = false;
            CN = getSGBDConnection();
            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    MessageBox.Show("Successful connection to database " + CN.Database + " on the " + CN.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                    temp = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR \r\n" + ex.Message, "Connection Test", MessageBoxButtons.OK);
                temp = false;
                CN.Close();
            }

            return temp;
        }

        private bool verifySGBDConnection()
        {
            if (CN == null)
                CN = getSGBDConnection();
            TestDBConnection();

            if (CN.State != ConnectionState.Open)
                CN.Open();

            return CN.State == ConnectionState.Open;
        }


        private void registoCliente_Click(object sender, EventArgs e)
        {

            registoCliente registo = new registoCliente();

            registo.Show();

        }


        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            infoCliente info = new infoCliente();

            info.Show();
        }

        private void registoDoutor_Click(object sender, EventArgs e)
        {
            registoDoutor registo = new registoDoutor();

            registo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registoFuncionario registo = new registoFuncionario();
            registo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doutor doutor = new Doutor();
            doutor.Show();
        }

        private void produtos_Click(object sender, EventArgs e)
        {
            Produtos produto = new Produtos();
            produto.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}