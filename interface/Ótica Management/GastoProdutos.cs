using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class GastoProdutos : Form
    {
        private SqlConnection CN;
        public GastoProdutos()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = " + ChangeData.DB_string + " ;" + "Initial Catalog = " + ChangeData.username + "; uid = " + ChangeData.username + ";" + "password = " + ChangeData.password);
        }


        private bool verifySGBDConnection()
        {
            if (CN == null)
                CN = getSGBDConnection();

            if (CN.State != ConnectionState.Open)
                CN.Open();
            //  MessageBox.Show("DATABASE CONNECTED");

            return CN.State == ConnectionState.Open;
        }

        private void GastoProdutos_load(object sender, EventArgs e)
        {
            try
            {
                if (!verifySGBDConnection())
                    return;

                string query = "SELECT CC FROM Otica_Cliente";

                SqlCommand command = new SqlCommand(query, CN);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int cc = reader.GetInt32(0);
                    comboBox1.Items.Add(cc);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os números de CC dos clientes: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verifySGBDConnection())
                    return;

                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um cliente.");
                    return;
                }

                int cliente_cc = Convert.ToInt32(comboBox1.SelectedItem);

                string query = "SELECT dbo.CalculateTotalSales(@cliente_cc)";

                SqlCommand command = new SqlCommand(query, CN);
                command.Parameters.AddWithValue("@cliente_cc", cliente_cc);

                float totalSales = Convert.ToSingle(command.ExecuteScalar());

                MessageBox.Show("Total Sales: " + totalSales.ToString("0.00"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular o Total Sales: " + ex.Message);
            }
        }

    }
}

