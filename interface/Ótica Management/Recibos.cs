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
    public partial class Recibos : Form
    {
        private SqlConnection CN;
        public Recibos()
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

            return CN.State == ConnectionState.Open;
        }

        private void Recibos_Load(object sender, EventArgs e)
        {
            // Preencher o dropdown com os nomes dos clientes
            FillClientDropdown();
        }

        private void FillClientDropdown()
        {
            CN = getSGBDConnection();
            try
            {
                CN.Open();

                string query = "SELECT nome FROM Otica_Cliente " +
                               "INNER JOIN Otica_Pessoa ON Otica_Cliente.CC = Otica_Pessoa.CC";
                SqlCommand cmd = new SqlCommand(query, CN);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string clientName = reader["nome"].ToString();
                    comboBox1.Items.Add(clientName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os nomes dos clientes: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Limpar o DataGridView antes de exibir os resultados
            dataGridView1.Rows.Clear();

            // Obter o nome do cliente selecionado no dropdown
            string selectedClientName = comboBox1.SelectedItem.ToString();

            CN = getSGBDConnection();
            try
            {
                CN.Open();

                // Consultar a tabela Otica_Fatura para obter as faturas do cliente selecionado
                string query = "SELECT * FROM Otica_Fatura " +
                               "WHERE cliente_cc IN (SELECT Otica_Cliente.CC FROM Otica_Cliente " +
                                                   "INNER JOIN Otica_Pessoa ON Otica_Cliente.CC = Otica_Pessoa.CC " +
                                                   "WHERE Otica_Pessoa.nome = @SelectedClientName)";

                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@SelectedClientName", selectedClientName);
                SqlDataReader reader = cmd.ExecuteReader();

                dataGridView1.Columns.Add("receiptId", "ID");
                dataGridView1.Columns.Add("receiptDescription", "Descrição");
                dataGridView1.Columns.Add("receiptIVA", "IVA");
                dataGridView1.Columns.Add("receiptPrice", "Preço");

                while (reader.Read())
                {
                    string receiptId = reader["id"].ToString();
                    string receiptDescription = reader["descriçao"].ToString();
                    string receiptIVA = reader["iva"].ToString();
                    string receiptPrice = reader["preco"].ToString();
                    // Adicione outras colunas necessárias aqui

                    // Adicionar uma nova linha no DataGridView com os dados da fatura
                    dataGridView1.Rows.Add(receiptId, receiptDescription, receiptIVA, receiptPrice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as faturas: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
