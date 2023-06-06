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
    public partial class NumeroPedidos : Form
    {
        private SqlConnection CN;
        public NumeroPedidos()
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

        private void NumeroPedidos_Load(object sender, EventArgs e)
        {
                // Verificar a conexão com o banco de dados
                if (!verifySGBDConnection())
                    return;

                try
                {
                    // Consulta para obter os nomes dos fornecedores
                    string query = "SELECT nome FROM Otica_Fornecedor";

                    // Executar a consulta
                    SqlCommand cmd = new SqlCommand(query, CN);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Limpar o ComboBox antes de adicionar os nomes dos fornecedores
                    comboBox1.Items.Clear();

                    // Ler os nomes dos fornecedores e adicioná-los ao ComboBox
                    while (reader.Read())
                    {
                        string nomeFornecedor = reader.GetString(0);
                        comboBox1.Items.Add(nomeFornecedor);
                    }

                    // Fechar o leitor e a conexão
                    reader.Close();
                    CN.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao obter os nomes dos fornecedores: " + ex.Message);
                }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar se um fornecedor foi selecionado no ComboBox
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione um fornecedor.");
                return;
            }

            // Obter o nome do fornecedor selecionado
            string fornecedorNome = comboBox1.SelectedItem.ToString();

            // Verificar a conexão com o banco de dados
            if (!verifySGBDConnection())
                return;

            try
            {
                // Consulta para obter o NIF do fornecedor com base no nome
                string query = "SELECT nif FROM Otica_Fornecedor WHERE nome = @fornecedor_nome";

                // Criar o comando e adicionar o parâmetro
                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@fornecedor_nome", fornecedorNome);

                // Executar a consulta e obter o NIF do fornecedor
                string fornecedorNIF = cmd.ExecuteScalar()?.ToString();

                // Verificar se o NIF do fornecedor foi encontrado
                if (string.IsNullOrEmpty(fornecedorNIF))
                {
                    MessageBox.Show("Nome de fornecedor inválido.");
                    return;
                }

                // Consulta para executar a UDF
                string udfQuery = "SELECT dbo.GetTotalProductsSuppliedBySupplier(@fornecedor_nif)";

                // Criar o comando e adicionar o parâmetro
                SqlCommand udfCmd = new SqlCommand(udfQuery, CN);
                udfCmd.Parameters.AddWithValue("@fornecedor_nif", fornecedorNIF);

                // Executar a consulta e obter o resultado da UDF
                int totalProducts = (int)udfCmd.ExecuteScalar();

                // Exibir o resultado
                MessageBox.Show("Total de produtos fornecidos pelo fornecedor: " + totalProducts.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao obter o total de produtos fornecidos pelo fornecedor: " + ex.Message);
            }
        }

    }
}
