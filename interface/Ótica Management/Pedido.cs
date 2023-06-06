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
    public partial class Pedido : Form
    {
        private SqlConnection CN;
        public Pedido()
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

        private void Pedido_Load(object sender, EventArgs e)
        {
            if (verifySGBDConnection())
            {
                string query = "SELECT nome FROM Otica_Fornecedor";
                SqlCommand command = new SqlCommand(query, CN);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    comboBox1.Items.Clear();

                    while (reader.Read())
                    {
                        string nomeFornecedor = reader["nome"].ToString();
                        comboBox1.Items.Add(nomeFornecedor);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao recuperar os nomes dos fornecedores: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Falha ao conectar ao banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (verifySGBDConnection())
            {
                string selectedFornecedor = comboBox1.SelectedItem.ToString();


                string query = "SELECT p.nome FROM Otica_Produto p " +
                "JOIN Otica_Fornecido_Por fp ON p.id = fp.produto_id " +
                "JOIN Otica_Fornecedor f ON fp.fornecedor_nif = f.nif " +
                "WHERE f.nome = @fornecedor";
                //string query = "SELECT nome FROM Otica_Fornecedor";


                SqlCommand command = new SqlCommand(query, CN);
                command.Parameters.AddWithValue("@fornecedor", selectedFornecedor);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        string nomeProduto = reader["nome"].ToString();
                        listBox1.Items.Add(nomeProduto);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao recuperar os produtos do fornecedor: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Falha ao conectar ao banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (verifySGBDConnection())
            {
                string selectedProduto = listBox1.SelectedItem.ToString();
                int quantidade = 0;

                if (!int.TryParse(textBox1.Text, out quantidade))
                {
                    MessageBox.Show("Quantidade inválida. Insira um valor numérico válido.", "Erro de Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "INSERT INTO Otica_Stock (id, produto_id, data_entrada, estado, quantidade) " +
                               "VALUES (@id, @produto_id, @data_entrada, @estado, @quantidade)";

                SqlCommand command = new SqlCommand(query, CN);

                // Definir os parâmetros da instrução SQL
                command.Parameters.AddWithValue("@id", GetNextStockId());
                command.Parameters.AddWithValue("@produto_id", GetProductId(selectedProduto));
                command.Parameters.AddWithValue("@data_entrada", DateTime.Today);
                command.Parameters.AddWithValue("@estado", "Pendente");
                command.Parameters.AddWithValue("@quantidade", quantidade);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pedido registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao registrar o pedido. Verifique os valores fornecidos e tente novamente.", "Erro de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao registrar o pedido: " + ex.Message, "Erro de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falha ao conectar ao banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextStockId()
        {
            string query = "SELECT MAX(id) FROM Otica_Stock";
            SqlCommand command = new SqlCommand(query, CN);
            int maxId = 0;

            try
            {
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    maxId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao obter o próximo ID: " + ex.Message, "Erro de ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return maxId + 1;
        }
        private int GetProductId(string productName)
        {
            string query = "SELECT id FROM Otica_Produto WHERE nome = @nome";
            SqlCommand command = new SqlCommand(query, CN);
            command.Parameters.AddWithValue("@nome", productName);
            int productId = 0;

            try
            {
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    productId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao obter o ID do produto: " + ex.Message, "Erro de ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return productId;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (verifySGBDConnection())
            {
                string selectedProduto = listBox1.SelectedItem.ToString();
                int quantidade = 0;

                if (!int.TryParse(textBox1.Text, out quantidade))
                {
                    MessageBox.Show("Quantidade inválida. Insira um valor numérico válido.", "Erro de Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand command = new SqlCommand("RegistarEntregaProduto", CN);
                command.CommandType = CommandType.StoredProcedure;

                // Definir os parâmetros da stored procedure
                command.Parameters.AddWithValue("@id", GetNextStockId());
                command.Parameters.AddWithValue("@produto_id", GetProductId(selectedProduto));
                command.Parameters.AddWithValue("@data_entrada", DateTime.Today);
                command.Parameters.AddWithValue("@estado", "Pendente");
                command.Parameters.AddWithValue("@quantidade", quantidade);


                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pedido registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao registrar o pedido. Verifique os valores fornecidos e tente novamente.", "Erro de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao registrar o pedido: " + ex.Message, "Erro de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falha ao conectar ao banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
